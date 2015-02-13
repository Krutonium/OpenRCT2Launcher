Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Threading
Imports Microsoft.Win32
Imports System.Text.RegularExpressions
Imports Launcher.My.Resources

Public Class frmLauncher

    Dim OpenRCT2Folder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2"
    Dim OpenRCT2Config As String = OpenRCT2Folder & "/config.ini"

    Dim URL As String = "https://openrct2.com/download/latest" ' Download link for UnOfficial 3rd party builds.
    Dim RemoteVer As String        'Will contain the version of OpenRCT2 from the server
    Dim LocalVer As String         'Will contain the version of OpenRCT2 on this computer

    Dim RemoteDone As Boolean = False   'These two variables act as flags so that we know when both processes are complete.
    Dim LocalDone As Boolean = False

    Dim OpenRCTEXEName As String = ".\OpenRCT2\openrct2.exe"   'So it's easy to change when/if it gets changed officially.
    Dim OpenRCTDLLName As String = ".\OpenRCT2\openrct2.dll"

    Dim LauncherVersion As Integer = "1" 'The Version of the launcher, so we can update the launcher as well. Need to write code.

    Dim Key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
    Dim Reg As RegistryKey = Key.CreateSubKey("OpenRCT2Launcher")

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Dim GetRemote = New Thread(AddressOf GetRemoteVer)
        Dim GetLocal = New Thread(AddressOf GetLocalVer)        'Threads for Update Checking.
        'Dim GetLauncher = New Thread(AddressOf LauncherUpdate)
        GetRemote.Start()
        GetLocal.Start()
        'GetLauncher.Start()
        PictureBox1.Image = rollercoaster_tycoon_2_001
        If Reg.GetValue("Verbose") = "True" Then
            chkVerbose.Checked = True
        End If
        Icon = cat_paw
        FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        WindowState = FormWindowState.Normal
        MaximizeBox = False
        chkLogToFile.Visible = False
        If Directory.Exists(OpenRCT2Folder) = False Then
            Directory.CreateDirectory(OpenRCT2Folder)
        End If
        If File.Exists(OpenRCT2Config) = False Then
            Try
                Dim RCT2Reg = Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup")
                Dim InstalledDir As String = RCT2Reg.GetValue("Path")
                File.WriteAllText(OpenRCT2Config, "[general]" & vbNewLine & _
                                  "game_path = " & InstalledDir & vbNewLine & _
                                  "fullscreen_mode = borderless_fullscreen")
            Catch ex As Exception
                MsgBox(frmLauncher_Load_neverRun)
                If File.Exists(OpenRCT2Config) Then File.Delete(OpenRCT2Config)
            End Try
        End If
    End Sub

    Private Sub GetRemoteVer()
        If My.Computer.Network.IsAvailable = True Then
            Try 'If the computer has a network connection but no internet, we want to avoid crashing.
                Dim WS As New WebClient
                WS.DownloadFile(URL, Path.GetTempPath & "OpenRCT2Update.html")
                Dim HTML As String = File.ReadAllText(Path.GetTempPath & "OpenRCT2Update.html")
                For Each link In ParseLinks(HTML)
                    If link Like "http://cdn.limetric.com/games/openrct2*.zip" Then
                        RemoteVer = link
                        Exit For
                    End If
                Next
            Catch ex As Exception                           'because I want to grab the Download URL at the same time.

            End Try
        End If
        RemoteDone = True
    End Sub

    Private Sub GetLocalVer()
        Try
            If Reg.GetValue("LocalVer") Is Nothing Then
                Reg.SetValue("LocalVer", "0", RegistryValueKind.String)
                LocalVer = "0"
            Else
                LocalVer = Reg.GetValue("LocalVer")
            End If
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        If Directory.Exists(".\OpenRCT2") = False Then
            LocalVer = 0
        End If
        LocalDone = True
    End Sub
    Private Sub LauncherUpdate()
        'Really should add some updater here...
        'For now, this will never be called, disabled above.
    End Sub
    Private Sub tmrCheckIfDone_Tick(sender As Object, e As EventArgs) Handles tmrCheckIfDone.Tick
        If LocalDone = True And RemoteDone = True Then
            tmrCheckIfDone.Enabled = False              'Disables itself from running  further, and has the UpdateGUI call run to Check for Updates.
            Call UpdateGUI()
        End If
    End Sub

    Private Sub UpdateGUI()
        If RemoteVer <> LocalVer Then           'If the local and remote versions are not in sync, Update
            lblStatus.Text = frmLauncher_updateStateMessage_updating
            Call DownloadUpdate()
        Else                                    'Otherwise we are up to date :D
            lblStatus.Text = frmLauncher_updateStateMessage_uptodate
            cmdLaunchGame.Enabled = True
            cmdForceUpdate.Enabled = True       'Enabling these Buttons :)
        End If
    End Sub

    Private Sub cmdLaunchGame_Click(sender As Object, e As EventArgs) Handles cmdLaunchGame.Click
        If File.Exists(OpenRCTEXEName) And File.Exists(OpenRCTDLLName) Then
            Dim Launch As New ProcessStartInfo
            Launch.WorkingDirectory = ".\OpenRCT2"          'OpenRCT2's Executibles will be stored here, so we make this the working dir.
            Launch.FileName = "OpenRCT2.exe"                'The EXE of course.
            If chkVerbose.Checked = True Then
                Launch.Arguments = "--verbose"              'This will allow easier debugging for anyone using this Launcher.
                Reg.SetValue("Verbose", "True", RegistryValueKind.String)
            Else                                            'It also saves the state so that the next time the launcher is run, it can put the check box back.
                Reg.SetValue("Verbose", "False", RegistryValueKind.String)
            End If
            If chkLogToFile.Checked = True Then
                Launch.Arguments = Launch.Arguments & " >C:\Users\Kenton\Desktop\Log.txt 2>&1"
            End If
            'MsgBox(Launch.Arguments)
            Process.Start(Launch)
            Close()

        Else
            MsgBox(frmLauncher_launchGame_RCT2NotFound)
            lblStatus.Text = frmLauncher_launchGame_updateMessage
            cmdLaunchGame.Enabled = False
            cmdForceUpdate.Enabled = False
            Call DownloadUpdate()
        End If
    End Sub

    Private Sub DownloadUpdate()
        cmdLaunchGame.Enabled = False
        cmdForceUpdate.Enabled = False           'Added these because we may as well not keep calling them over and over.
        Dim Download = New Thread(AddressOf ActualDownload)
        Download.Start()
    End Sub

    Private Sub ActualDownload()
        Try
            Dim WS As New WebClient
            WS.DownloadFile(RemoteVer, "./update.zip")
            If Directory.Exists("OpenRCT2") Then
                Directory.Delete("OpenRCT2", True)      'Delete old folder if it exists.
            End If
            ZipFile.ExtractToDirectory("./update.zip", "./OpenRCT2")    'Extracts to said folder.
            File.Delete("./update.zip")
            Reg.SetValue("LocalVer", RemoteVer)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        lblStatus.Text = frmLauncher_updateStateMessage_uptodate
        cmdLaunchGame.Enabled = True
        cmdForceUpdate.Enabled = True
    End Sub

    Public Iterator Function ParseLinks(ByVal HTML As String) As IEnumerable(Of String)
        Dim objRegEx As Regex
        Dim objMatch As Match
        ' Create regular expression
        objRegEx = New System.Text.RegularExpressions.Regex("a.*href\s*=\s*(?:""(?<1>[^""]*)""|(?<1>\S+))", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Compiled)
        ' Match expression to HTML
        objMatch = objRegEx.Match(HTML)
        ' Loop through matches and add <1> to ArrayList
        While objMatch.Success
            Dim strMatch As String
            strMatch = objMatch.Groups(1).ToString
            Yield strMatch
            objMatch = objMatch.NextMatch()
        End While
    End Function

    Private Sub cmdForceUpdate_Click(sender As Object, e As EventArgs) Handles cmdForceUpdate.Click
        lblStatus.Text = frmLauncher_update_forceUpdate
        Call DownloadUpdate()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub cmdExtras_Click(sender As Object, e As EventArgs) Handles cmdExtras.Click
        Extras.Show()
    End Sub

    Private Sub chkLogToFile_CheckedChanged(sender As Object, e As EventArgs) Handles chkLogToFile.CheckedChanged

    End Sub
End Class
