Imports HelperLibrary.Classes
Imports Launcher.Forms
Imports Launcher.My
Imports Launcher.My.Resources
Imports Launcher.OpenRCTdotNet
Imports Launcher.OpenRCTdotNetStoreBrowser
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports Microsoft.Win32

Public Class frmLauncher

    Private Sub frmLauncher_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If My.Computer.Keyboard.AltKeyDown Then
            Me.Text = "Current Version: " + Settings.LocalVersion 'Hold Alt, and the title of the launcher shows the current version :)
        End If
    End Sub

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Check for updates
        Dim ArgCount As Integer = My.Application.CommandLineArgs.Count
        If ArgCount > 0 Then
            Dim X As Integer = 0
            Do Until X = ArgCount
                Launcher.OpenRCTdotNetStoreBrowser.WebBrowser1.Url = New Uri(My.Application.CommandLineArgs(X))
                X += 1
            Loop
            MsgBox("Complete.")
            Me.Close()
        End If
        My.Settings.Upgrade()

        If Settings.FirstRun = True Then
            Dim ShouldDLDevelop = MsgBox("Do you want to download Development Builds or Stable Builds? You can change this later in Options -> Launcher tab. (Yes = Development, No = Stable)", vbYesNo, "Develop or Stable?")
            If ShouldDLDevelop = MsgBoxResult.Yes Then
                My.Settings.DownloadDevelop = True
            Else
                My.Settings.DownloadDevelop = False
            End If
            Settings.FirstRun = False
            My.Settings.Save()
        End If
        CheckForIllegalCrossThreadCalls = False

        GameConfig.load(Constants.OpenRCT2ConfigFile)

        Settings.HasChanged = False

        'Dim strPath As String = System.IO.Path.GetDirectoryName( _
        'System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        Dim FileName As String = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
        'strPath = strPath.Remove(0, 6)
        'strPath = strPath & FileName
        'MsgBox(strPath)
        Try
            If File.Exists(Constants.OpenRCT2Folder & "\StubPath.path") Then
                File.Delete(Constants.OpenRCT2Folder & "\StubPath.path")
            End If
            File.WriteAllText(Constants.OpenRCT2Folder & "\StubPath.path", FileName)
        Catch ex As Exception
            'silently fail.
        End Try

        If Settings.CheckUpdates Then
            Task.Run(DirectCast(Async Sub() Await GameUpdate(False), Action))
        End If

        If Settings.OpenRCTdotNetPlaytimeCache > 0 Then
            Task.Run(DirectCast(Async Sub() Await OpenRCTdotNetWebActions.SaveUploadTime(0), Action))
        End If

        cmdLaunchGame.Enabled = Directory.Exists(GameConfig.values.GamePath)

        'PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        'PictureBox1.Image = Logo
        Icon = OpenRCTIcon

        'If the OpenRCT2 folder doesn't exist, create it
        If Directory.Exists(Constants.OpenRCT2Folder) = False Then
            Directory.CreateDirectory(Constants.OpenRCT2Folder)
        End If

        If String.IsNullOrEmpty(GameConfig.values.GamePath) Then
            MsgBox(frmLauncher_Load_neverRun)
        End If


        ' Try
        'If Settings.Donator = True = False Then
        'Dim WS As New WebClient
        'If WS.DownloadString("https://openrct.net/launcher/Launcher/ShouldDonate.txt") = "1" Then
        'If Settings.ShowDonateUser = True Then
        'pbDonate.Visible = True
        'End If
        'Else
        'pbDonate.Visible = False
        'End If
        'End If
        '
        'Catch ex As Exception
        '
        'End Try

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
                    Process.StartInfo.RedirectStandardError = True
                    Process.StartInfo.UseShellExecute = False
                End If
            End If

            Process.StartInfo.WorkingDirectory = Constants.OpenRCT2Bin 'OpenRCT2's executables will be stored here, so we make this the working dir.
            Process.StartInfo.FileName = Constants.OpenRCT2Exe 'The EXE of course.

            If Settings.Verbose Then
                Process.StartInfo.Arguments += "--verbose "
            End If

            If Settings.Arguments <> "" Then
                Process.StartInfo.Arguments += Settings.Arguments
            End If

            GameConfig.save(Constants.OpenRCT2ConfigFile)

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

        cmdLaunchGame.Enabled = Directory.Exists(GameConfig.values.GamePath)
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

        GameConfig.save(Constants.OpenRCT2ConfigFile)
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

    Public Async Function GameUpdate(force As Boolean) As Task
        RunWithInvoke(Sub(this)
                          this.cmdLaunchGame.Enabled = False
                          this.cmdUpdate.Enabled = False
                      End Sub) 'Thread safety requires an invoke

        Dim WS As New WebClient

        Try
            'Get remote version from the webpage
            Dim remoteVersion As String

            If Settings.DownloadDevelop = True Then
                remoteVersion = Await WS.DownloadStringTaskAsync(Constants.UpdateVersionDevelopURL)
            Else
                remoteVersion = Await WS.DownloadStringTaskAsync(Constants.UpdateVersionStableURL)
            End If

            If remoteVersion = Nothing Then
                Exit Try
            End If

            If (remoteVersion <> Settings.LocalVersion And Not Settings.InstallUpdates) And Not force Then
                If MessageBox.Show("There is a new version of OpenRCT2 available. Do you want to download it?", "OpenRCT2 Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Information) <> Windows.Forms.DialogResult.Yes Then
                    Exit Try
                End If
            End If

            If remoteVersion <> Settings.LocalVersion Or force Then
                If Directory.Exists(Constants.OpenRCT2Bin) Then
                    Directory.Delete(Constants.OpenRCT2Bin, True)      'Delete old folder if it exists.
                End If

                Directory.CreateDirectory(Constants.OpenRCT2Bin)
                If Settings.DownloadDevelop = True Then
                    WS.DownloadFile(Constants.UpdateDevelopURL, Constants.OpenRCT2Bin + "\update.zip")
                Else
                    WS.DownloadFile(Constants.UpdateStableURL, Constants.OpenRCT2Bin + "\update.zip")
                End If

                ZipFile.ExtractToDirectory(Constants.OpenRCT2Bin + "\update.zip", Constants.OpenRCT2Bin)    'Extracts to said folder.
                File.Delete(Constants.OpenRCT2Bin + "\update.zip")

                Settings.LocalVersion = remoteVersion
                Settings.HasChanged = True
            End If
        Catch ex As Exception
        End Try

        RunWithInvoke(Sub(this)
                          this.cmdLaunchGame.Enabled = Directory.Exists(GameConfig.values.GamePath)
                          this.cmdUpdate.Enabled = True
                          this.cmdLaunchGame.Select()
                      End Sub)
    End Function

    Private Sub SyncSaves()
        Task.Run(DirectCast(Async Sub() Await OpenRCTdotNetWebActions.UploadSaves(False), Action))
        Task.Run(DirectCast(Async Sub() Await OpenRCTdotNetWebActions.DownloadSaves(False), Action))
    End Sub

    Private Sub pbDonate_Click(sender As Object, e As EventArgs)
        Settings.ShowDonateUser = False
        Settings.HasChanged = True
        Settings.Save()
        Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=8N95FU9CJKAY6")
        'pbDonate.Visible = False
    End Sub

    Function HasInternet() As Boolean
        Try
            Return My.Computer.Network.Ping("8.8.8.8") 'ping Google :')
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub wbSlideshow_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles wbSlideshow.Navigating
        If HasInternet() Then
            wbSlideshow.Visible = True
            PictureBox1.Visible = False

            If e.Url.ToString = "https://openrct.net/inLauncher/open_store" Then
                OpenRCTdotNetStoreBrowser.Visible = True
                e.Cancel = True
            ElseIf e.Url.ToString <> "https://openrct.net/inLauncher/launcher.html" Then
                Process.Start(e.Url.ToString)
                e.Cancel = True
            End If
        Else
            e.Cancel = True
            wbSlideshow.Visible = False
            PictureBox1.Visible = True
        End If

    End Sub

End Class
