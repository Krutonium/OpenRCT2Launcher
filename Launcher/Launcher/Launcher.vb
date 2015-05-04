Imports HelperLibrary.Classes
Imports Launcher.Forms
Imports Launcher.My
Imports Launcher.My.Resources
Imports Launcher.OpenRCTdotNet
Imports Microsoft.Win32
Imports System.IO
Imports System.IO.Compression
Imports System.Net

Public Class frmLauncher

    Private Sub frmLauncher_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If My.Computer.Keyboard.AltKeyDown Then
            Me.Text = "Current Version: " + Settings.LocalVersion 'Hold Alt, and the title of the launcher shows the current version :)
        End If
    End Sub

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Check for updates

        'My.Settings.Upgrade()

        CheckForIllegalCrossThreadCalls = False

        OpenRCT2Config.Load(Constants.OpenRCT2ConfigFile)

        Settings.HasChanged = False

        If Settings.CheckUpdates Then
            Task.Run(DirectCast(Async Sub() Await GameUpdate(False), Action))
        End If

        If Settings.OpenRCTdotNetPlaytimeCache > 0 Then
            Task.Run(DirectCast(Async Sub() Await OpenRCTdotNetWebActions.SaveUploadTime(0), Action))
        End If

        cmdLaunchGame.Enabled = Directory.Exists(OpenRCT2Config.GamePath)

        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.Image = Logo
        Icon = OpenRCTIcon

        'If the OpenRCT2 folder doesn't exist, create it
        If Directory.Exists(Constants.OpenRCT2Folder) = False Then
            Directory.CreateDirectory(Constants.OpenRCT2Folder)
        End If

        'If the programm couldn't find the path look for it in the registry
        If String.IsNullOrEmpty(OpenRCT2Config.GamePath) Then
            Try
                OpenRCT2Config.GamePath = Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup").GetValue("Path")
                OpenRCT2Config.HasChanged = True
            Catch ex As Exception
                MsgBox(frmLauncher_Load_neverRun)
            End Try
        End If

        Try
            If Settings.Donator = True = False Then
                Dim WS As New WebClient
                If WS.DownloadString("https://openrct.net/launcher/Launcher/ShouldDonate.txt") = "1" Then
                    If Settings.ShowDonateUser = True Then
                        pbDonate.Visible = True
                    End If
                Else
                    pbDonate.Visible = False
                End If
            End If

        Catch ex As Exception

        End Try

        If Settings.OpenRCTdotNetSaveGames Then
            SyncSaves()
        End If
    End Sub

    Private Async Sub cmdLaunchGame_Click(sender As Object, e As EventArgs) Handles cmdLaunchGame.Click
        If File.Exists(Constants.OpenRCT2Exe) And File.Exists(Constants.OpenRCT2Dll) Then
            Dim Process As New Process

            'Redirect output if needed
            If Settings.SaveOutput Then
                If Directory.Exists(Path.GetDirectoryName(Settings.OutputPath)) Then
                    Process.StartInfo.RedirectStandardOutput = True
                    Process.StartInfo.RedirectStandardError  = True
                    Process.StartInfo.UseShellExecute        = False
                End If
            End If

            Process.StartInfo.WorkingDirectory = Constants.OpenRCT2Bin 'OpenRCT2's Executibles will be stored here, so we make this the working dir.
            Process.StartInfo.FileName         = Constants.OpenRCT2Exe 'The EXE of course.

            If Settings.Verbose Then
                Process.StartInfo.Arguments += "--verbose "
            End If

            If Settings.Arguments <> "" Then
                Process.StartInfo.Arguments += Settings.Arguments
            End If

            'Save before starting the *.exe to prevent it from failing to load
            If OpenRCT2Config.HasChanged Then
                Await OpenRCT2Config.Save(Constants.OpenRCT2ConfigFile)
                OpenRCT2Config.HasChanged = False
            End If

            Process.Start()

            'Start new thread for saving the output of the *.exe
            If Settings.SaveOutput Then
                If Directory.Exists(Path.GetDirectoryName(Settings.OutputPath)) Then
                    Await WriteOutput(Process)
                End If
            End If


            'THIS NEEDS TO REMAIN LAST BECAUSE IT HANDLES WHETHER WE NEED TO CLOSE!
            If Settings.OpenRCTdotNetUploadTime = True Or Settings.OpenRCTdotNetSaveGames = True Then
                Dim uTime As Int64 ' Int64 instead of Integer so we can count past 2038
                uTime = (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds

                Visible = False

                Process.WaitForExit()


                If Settings.OpenRCTdotNetUploadTime Then
                    Dim diff As Int64
                    diff = (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds - uTime
                    diff = Math.Round(diff / 60)
                    Call OpenRCTdotNetWebActions.SaveUploadTime(diff)
                End If


                If Settings.OpenRCTdotNetSaveGames Then
                    ' i'm using Call here instead of SyncSaves() since, for some reason, that doesn't work here (probably because we do Close a few lines later)
                    ' but that doesn't seem to be a problem since the app is invisible to the user and up and downloading shouldn't take THAT long
                    Call OpenRCTdotNetWebActions.UploadSaves(False)
                    Call OpenRCTdotNetWebActions.DownloadSaves(False)
                End If

                Close()

            Else
                Close()
            End If
        Else
            MsgBox(frmLauncher_launchGame_RCT2NotFound)

            'Redownload
            Await GameUpdate(True)
        End If
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Task.Run(DirectCast(Async Sub() Await GameUpdate(True), Action))
    End Sub

    Private Sub cmdOptions_Click(sender As Object, e As EventArgs) Handles cmdOptions.Click
        FrmOptions.ShowDialog()

        cmdLaunchGame.Enabled = Directory.Exists(OpenRCT2Config.GamePath)
    End Sub

    Private Sub cmdExtras_Click(sender As Object, e As EventArgs) Handles cmdExtras.Click
        Extras.ShowDialog()
    End Sub

    Private Sub frmLauncher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Save changes
        If Settings.HasChanged Then
            Settings.HasChanged = False
            Settings.Save()
        End If

        If OpenRCT2Config.HasChanged Then
            Task.Run(DirectCast(Async Sub() Await OpenRCT2Config.Save(Constants.OpenRCT2ConfigFile), Action))
        End If
    End Sub

    Private Async Function WriteOutput(process As Process) As Task
        Dim out As String = Await process.StandardOutput.ReadToEndAsync() 'I need to use Async here because it crashes the game if I won't use it
        Dim e As String = Await process.StandardError.ReadToEndAsync()

        'Write output to file
        Dim writer As New StreamWriter(Settings.OutputPath)
        Await writer.WriteLineAsync("Standard Output:")
        Await writer.WriteLineAsync(out)
        Await writer.WriteLineAsync("Standard Error:")
        Await writer.WriteLineAsync(e)
        writer.Close()
    End Function

    Private Async Function GameUpdate(force As Boolean) As Task
        RunWithInvoke(Sub(this)
                          this.cmdLaunchGame.Enabled = False
                          this.cmdUpdate.Enabled = False
                      End Sub) 'Thread safety requires an invoke

        Dim WS As New WebClient

        Try
            'Get remote version from the webpage
            Dim remoteVersion As String = Await WS.DownloadStringTaskAsync(Constants.UpdateVersionURL)

            If remoteVersion = Nothing Then
                Exit Try
            End If

            If (remoteVersion <> Settings.LocalVersion And Not Settings.InstallUpdates) And Not force
                If MessageBox.Show("There is a new version of OpenRCT2 available. Do you want to download it?", "OpenRCT2 Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.Yes
                    Exit Try
                End If
            End If

            If remoteVersion <> Settings.LocalVersion Or force Then
                If Directory.Exists(Constants.OpenRCT2Bin) Then
                    Directory.Delete(Constants.OpenRCT2Bin, True)      'Delete old folder if it exists.
                End If

                Directory.CreateDirectory(Constants.OpenRCT2Bin)

                WS.DownloadFile(Constants.UpdateURL, Constants.OpenRCT2Bin + "\update.zip")

                ZipFile.ExtractToDirectory(Constants.OpenRCT2Bin + "\update.zip", Constants.OpenRCT2Bin)    'Extracts to said folder.
                File.Delete(Constants.OpenRCT2Bin + "\update.zip")

                Settings.LocalVersion = remoteVersion
                Settings.HasChanged = True
            End If
        Catch ex As Exception
        End Try

        RunWithInvoke(Sub(this)
                          this.cmdLaunchGame.Enabled = Directory.Exists(OpenRCT2Config.GamePath)
                          this.cmdUpdate.Enabled = True
                          this.cmdLaunchGame.Select()
                      End Sub)
    End Function

    Private Sub SyncSaves()
        Task.Run(DirectCast(Async Sub() Await OpenRCTdotNetWebActions.UploadSaves(False), Action))
        Task.Run(DirectCast(Async Sub() Await OpenRCTdotNetWebActions.DownloadSaves(False), Action))
    End Sub

    Private Sub pbDonate_Click(sender As Object, e As EventArgs) Handles pbDonate.Click
        Settings.ShowDonateUser = False
        Settings.HasChanged = True
        Settings.Save()
        Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=8N95FU9CJKAY6")
        pbDonate.Visible = False
    End Sub
End Class
