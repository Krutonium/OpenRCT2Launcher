Imports System.IO
Imports Microsoft.Win32
Imports System.Threading
Imports Newtonsoft.Json.Linq

Public Class frmLauncher
    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main.Initialize() 'Initialize Main class

        'Check for updates
        Control.CheckForIllegalCrossThreadCalls = False
        Dim Thread = New Thread(AddressOf GameCheckAndUpdate)
        Thread.Start()

        PictureBox1.Image = My.Resources.rollercoaster_tycoon_2_001
        Icon = My.Resources.cat_paw

        'If the OpenRCT2 folder doesn't exist, create it
        If Directory.Exists(Main.OpenRCT2Folder) = False Then
            Directory.CreateDirectory(Main.OpenRCT2Folder)
        End If

        'If the programm couldn't find the path look for it in the registry
        If Main.OpenRCT2Config.GamePath = Nothing Then
            Try
                Main.OpenRCT2Config.GamePath = Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup").GetValue("Path")
                Main.OpenRCT2Config.HasChanged = True
            Catch ex As Exception
                MsgBox("Have you installed and ran RCT2 at least once? If not, then please do so and try again.")
            End Try
        End If

        If Main.LauncherConfig.UserID <> Nothing Then
            'Add code here for Stats etc.
        End If
    End Sub

    Private Sub cmdLaunchGame_Click(sender As Object, e As EventArgs) Handles cmdLaunchGame.Click
        If File.Exists(Main.OpenRCT2EXE) And File.Exists(Main.OpenRCT2DLL) Then
            Dim Launch As New ProcessStartInfo

            'Redirect output if needed
            If Main.LauncherConfig.SaveOutput Then
                If Directory.Exists(Path.GetDirectoryName(Main.LauncherConfig.OutputPath)) Then
                    Launch.RedirectStandardOutput = True
                    Launch.RedirectStandardError = True
                    Launch.UseShellExecute = False
                End If
            End If

            Launch.WorkingDirectory = Main.OpenRCT2BinFolder    'OpenRCT2's Executibles will be stored here, so we make this the working dir.
            Launch.FileName = Main.OpenRCT2EXE                  'The EXE of course.

            If Main.LauncherConfig.Verbose Then
                Launch.Arguments += "--verbose"
            End If

            If Main.LauncherConfig.Arguments <> "" Then
                If Launch.Arguments <> "" Then 'Add space to arguments (is this necessary?)
                    Launch.Arguments += " "
                End If

                Launch.Arguments += Main.LauncherConfig.Arguments
            End If

            'Save before starting the *.exe to prevent it from failing to load
            If Main.LauncherConfig.HasChanged Then
                Main.LauncherConfig.SaveINI(Main.LauncherConfigFile)
                Main.LauncherConfig.HasChanged = False
            End If

            Dim Process As Process = Process.Start(Launch)

            'Start new thread for saving the output of the *.exe
            If Main.LauncherConfig.SaveOutput Then
                If Directory.Exists(Path.GetDirectoryName(Main.LauncherConfig.OutputPath)) Then
                    Dim Thread = New Thread(Sub() WriteOutput(Process))
                    Thread.Start()
                End If
            End If


            'THIS NEEDS TO REMAIN LAST BECAUSE IT HANDLES WHETHER WE NEED TO CLOSE!
            If Main.LauncherConfig.UploadTime = True Then
                Me.Visible = False
                tmrUsedForUploadingTime.Enabled = True
            Else
                Close()
            End If


        Else
            MsgBox("OpenRCT2 Not Installed or Not Found!, Downloading. When it is done, feel free to press play again.")

            'Redownload
            Dim Thread = New Thread(AddressOf GameUpdate)
            Thread.Start()
        End If
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim Thread = New Thread(AddressOf GameUpdate)
        Thread.Start()
    End Sub

    Private Sub cmdOptions_Click(sender As Object, e As EventArgs) Handles cmdOptions.Click
        frmOptions.ShowDialog()
    End Sub

    Private Sub cmdExtras_Click(sender As Object, e As EventArgs) Handles cmdExtras.Click
        Extras.ShowDialog()
    End Sub

    Private Sub frmLauncher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Save changes
        If Main.LauncherConfig.HasChanged Then
            Main.LauncherConfig.SaveINI(Main.LauncherConfigFile)
        End If

        If Main.OpenRCT2Config.HasChanged Then
            Main.OpenRCT2Config.SaveINI(Main.OpenRCT2ConfigFile)
        End If
    End Sub

    Private Sub WriteOutput(Process As Process)
        Dim TaskOut As Task(Of String) = Process.StandardOutput.ReadToEndAsync() 'I need to use Async here because it crashes the game if I won't use it
        Dim TaskError As Task(Of String) = Process.StandardError.ReadToEndAsync()

        'Wait for both tasks to get done
        TaskOut.Wait()
        TaskError.Wait()

        'Write output to file
        Dim Writer As New StreamWriter(Main.LauncherConfig.OutputPath)
        Writer.WriteLine("Standart Output:")
        Writer.WriteLine(TaskOut.Result)
        Writer.WriteLine("Standart Error:")
        Writer.WriteLine(TaskError.Result)
        Writer.Close()
    End Sub

    Private Sub GameCheckAndUpdate()
        cmdLaunchGame.Enabled = False
        cmdUpdate.Enabled = False

        Try
            'Get remote version from the webpage
            Dim RemoteVersion As String = Main.RemoteVersionGet()

            If RemoteVersion = Nothing Then 'Couldn't find the URL
                cmdLaunchGame.Enabled = True
                cmdUpdate.Enabled = True
                Return
            End If

            If RemoteVersion <> Main.LauncherConfig.LocalVersion Then
                Main.Update(RemoteVersion)
            End If
        Catch ex As Exception
        End Try

        cmdLaunchGame.Enabled = True
        cmdUpdate.Enabled = True
    End Sub

    Private Sub GameUpdate()
        cmdLaunchGame.Enabled = False
        cmdUpdate.Enabled = False

        Try
            Dim RemoteVersion As String = Main.RemoteVersionGet() 'Get remote version from the webpage

            If RemoteVersion = Nothing Then 'Couldn't find the URL
                cmdLaunchGame.Enabled = True
                cmdUpdate.Enabled = True
                Return
            End If

            Main.Update(RemoteVersion)
        Catch ex As Exception
            MessageBox.Show("Failed to download update")
        End Try

        cmdLaunchGame.Enabled = True
        cmdUpdate.Enabled = True
    End Sub

    Dim minutesPlayed As Integer = 0

    Private Sub tmrUsedForUploadingTime_Tick(sender As Object, e As EventArgs) Handles tmrUsedForUploadingTime.Tick

        'This code will run every 1 minutes if UploadTime is Enabled. It will add 1 minute, then if the game is closed,  upload and exit.
        minutesPlayed += 1

        Dim isRunning = Process.GetProcessesByName("openrct2.exe")
        If isRunning.Count > 0 Then
            ' Process is running
        Else
            ' Process is not running
            Const secret As String = "NXgFj50WlithAa5sK9Z3WGAGnboyJTrwRHcaNd78vAq6LvywEyzAfahDlFb5zCCqjOB62JfxkGE5bcCQLbr0mIDHoPMYropLd0Sg"
            Dim WS As New System.Net.WebClient
            Dim Response As String = WS.DownloadString("https://openrct.net/api/?a=set_time_played&user=" & Main.LauncherConfig.UserID & _
                                                       "&minutes=" & minutesPlayed.ToString() & "&auth=" & Main.LauncherConfig.UserKey & "&secret=" & secret)
            'We aren't actually using the output for anything - in fact, all we are doing is informing the server that the player played for x minutes.
            Close()
        End If
    End Sub
End Class