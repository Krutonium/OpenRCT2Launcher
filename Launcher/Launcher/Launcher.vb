Imports System.IO
Imports Microsoft.Win32
Imports Launcher.My.Resources
Imports Launcher.My
Imports HelperLibrary.Classes
Imports Launcher.Forms
Imports Launcher.OpenRCTdotNet

Public Class frmLauncher
    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main.Initialize() 'Initialize Main class

        'Check for updates
        CheckForIllegalCrossThreadCalls = False

        Task.Run(DirectCast(Async Sub() Await GameUpdate(False), Action))
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.Image = Logo
        Icon = OpenRCTIcon

        'If the OpenRCT2 folder doesn't exist, create it
        If Directory.Exists(Constants.OpenRCT2Folder) = False Then
            Directory.CreateDirectory(Constants.OpenRCT2Folder)
        End If

        'If the programm couldn't find the path look for it in the registry
        If Main.OpenRCT2Config.GamePath = Nothing Then
            Try
                Main.OpenRCT2Config.GamePath = Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup").GetValue("Path")
                Main.OpenRCT2Config.HasChanged = True
            Catch ex As Exception
                MsgBox(frmLauncher_Load_neverRun)
            End Try
        End If

        If Settings.OpenRCTdotNetUserID <> Nothing Then
            'Add code here for Stats etc.
        End If
    End Sub

    Private Async Sub cmdLaunchGame_Click(sender As Object, e As EventArgs) Handles cmdLaunchGame.Click
        If File.Exists(Constants.OpenRCT2Exe) And File.Exists(Constants.OpenRCT2Dll) Then
            Dim launchProcess As New ProcessStartInfo

            'Redirect output if needed
            If Settings.SaveOutput Then
                If Directory.Exists(Path.GetDirectoryName(Settings.OutputPath)) Then
                    launchProcess.RedirectStandardOutput = True
                    launchProcess.RedirectStandardError = True
                    launchProcess.UseShellExecute = False
                End If
            End If

            launchProcess.WorkingDirectory = Constants.OpenRCT2Bin     'OpenRCT2's Executibles will be stored here, so we make this the working dir.
            launchProcess.FileName = Constants.OpenRCT2Exe                  'The EXE of course.

            If Settings.Verbose Then
                launchProcess.Arguments += "--verbose"
            End If

            If Settings.Arguments <> "" Then
                If launchProcess.Arguments <> "" Then 'Add space to arguments (is this necessary?)
                    launchProcess.Arguments += " "
                End If

                launchProcess.Arguments += Settings.Arguments
            End If

            'Save before starting the *.exe to prevent it from failing to load
            If Settings.HasChanged Then
                Settings.HasChanged = False
                Settings.Save()
            End If

            If Main.OpenRCT2Config.HasChanged Then
                Await Main.OpenRCT2Config.SaveINI(Constants.OpenRCT2ConfigFile)
                Main.OpenRCT2Config.HasChanged = False
            End If

            Dim process As Process = process.Start(launchProcess)

            'Start new thread for saving the output of the *.exe
            If Settings.SaveOutput Then
                If Directory.Exists(Path.GetDirectoryName(Settings.OutputPath)) Then
                    Await WriteOutput(process)
                End If
            End If


            'THIS NEEDS TO REMAIN LAST BECAUSE IT HANDLES WHETHER WE NEED TO CLOSE!
            If Settings.OpenRCTdotNetUploadTime = True Then
                Visible = False
                tmrUsedForUploadingTime.Enabled = True
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
    End Sub

    Private Sub cmdExtras_Click(sender As Object, e As EventArgs) Handles cmdExtras.Click
        Extras.ShowDialog()
    End Sub

    Private Sub frmLauncher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Save changes
        If Settings.HasChanged Then
            Settings.Save()
        End If

        If Main.OpenRCT2Config.HasChanged Then
            Task.Run(DirectCast(Async Sub() Await Main.OpenRCT2Config.SaveINI(Constants.OpenRCT2ConfigFile), Action))
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

        Try
            'Get remote version from the webpage
            Dim remoteVersion As String = Await Main.RemoteVersionGet()

            If remoteVersion = Nothing Then 'Couldn't find the URL
                RunWithInvoke(Sub(this)
                                  this.cmdLaunchGame.Enabled = True
                                  this.cmdUpdate.Enabled = True
                              End Sub)
                Return
            End If

            If remoteVersion <> Settings.LocalVersion Or force Then
                Main.Update(remoteVersion)
            End If
        Catch ex As Exception
        End Try

        RunWithInvoke(Sub(this)
                          this.cmdLaunchGame.Enabled = True
                          this.cmdUpdate.Enabled = True
                          this.cmdLaunchGame.Select()
                      End Sub)
    End Function

    ' keep minutes played offline until game exits
    Private _minutesPlayed As Integer = 0

    Private Sub tmrUsedForUploadingTime_Tick(sender As Object, e As EventArgs) Handles tmrUsedForUploadingTime.Tick
        If Not Settings.OpenRCTdotNetSaveGames Then
            Return
        End If
        'This code will run every 1 minutes if OpenRCTdotNetUploadTime is Enabled. It will add 1 minute, then if the game is closed,  upload and exit.
        _minutesPlayed += 1

        Dim isRunning = Process.GetProcessesByName("openrct2")
        If isRunning.Count > 0 Then
            ' Process is running
            Return
        Else
            ' Process is not running
            Task.Run(DirectCast(Async Sub() Await OpenRCTdotNetWebActions.SaveUploadTime(_minutesPlayed), Action))
            Close()
        End If
    End Sub
End Class
