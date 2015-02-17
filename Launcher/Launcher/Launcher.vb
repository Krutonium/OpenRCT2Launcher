Imports System.IO
Imports Microsoft.Win32
Imports System.Threading
Imports Launcher.My.Resources

Public Class frmLauncher
    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Main.Initialize() 'Initialize Main class

        'Check for updates
        CheckForIllegalCrossThreadCalls = False
        Dim Thread = New Thread(AddressOf GameCheckAndUpdate)
        Thread.Start()

        PictureBox1.Image = rollercoaster_tycoon_2_001
        Icon = cat_paw

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
                MsgBox(frmLauncher_Load_neverRun)
            End Try
        End If
    End Sub

    Private Async Sub cmdLaunchGame_Click(sender As Object, e As EventArgs) Handles cmdLaunchGame.Click
        If File.Exists(Main.OpenRCT2EXE) And File.Exists(Main.OpenRCT2DLL) Then
            Dim launch As New ProcessStartInfo

            'Redirect output if needed
            If Main.LauncherConfig.SaveOutput Then
                If Directory.Exists(Path.GetDirectoryName(Main.LauncherConfig.OutputPath)) Then
                    launch.RedirectStandardOutput = True
                    launch.RedirectStandardError = True
                    launch.UseShellExecute = False
                End If
            End If

            launch.WorkingDirectory = Main.OpenRCT2BinFolder    'OpenRCT2's Executibles will be stored here, so we make this the working dir.
            launch.FileName = Main.OpenRCT2EXE                  'The EXE of course.

            If Main.LauncherConfig.Verbose Then
                launch.Arguments += "--verbose "
            End If

            If Main.LauncherConfig.Arguments <> "" Then
                launch.Arguments += Main.LauncherConfig.Arguments
            End If

            'Save before starting the *.exe to prevent it from failing to load
            If Main.LauncherConfig.HasChanged Then
                Main.LauncherConfig.SaveINI(Main.LauncherConfigFile)
                Main.LauncherConfig.HasChanged = False
            End If

            Dim process As Process = process.Start(launch)

            'Start new thread for saving the output of the *.exe
            If Main.LauncherConfig.SaveOutput Then
                If Directory.Exists(Path.GetDirectoryName(Main.LauncherConfig.OutputPath)) Then
                    Await WriteOutput(process)
                End If
            End If

            Close()
        Else
            MsgBox(frmLauncher_launchGame_RCT2NotFound)

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

    Private Async Function WriteOutput(process As Process) As Task
        Dim out = Await process.StandardOutput.ReadToEndAsync()
        Dim errorEnd = Await process.StandardError.ReadToEndAsync()

        'Write output to file
        Dim writer As New StreamWriter(Main.LauncherConfig.OutputPath)
        writer.WriteLine("Standard Output:")
        writer.WriteLine(out)
        writer.WriteLine("Standard Error:")
        writer.WriteLine(errorEnd)
        writer.Close()
    End Function

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
            MessageBox.Show(frmLauncher_update_failed)
        End Try

        cmdLaunchGame.Enabled = True
        cmdUpdate.Enabled = True
    End Sub
End Class