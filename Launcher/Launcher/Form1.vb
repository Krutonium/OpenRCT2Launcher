Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Threading
Imports Microsoft.Win32
Imports System.Text.RegularExpressions

Public Class frmLauncher


    Dim URL As String = "https://openrct2.com/download/latest" ' Need to replace with Download from Version Text
    Dim RemoteVer As String        'Will contain the version of OpenRCT2 from the server
    Dim LocalVer As String         'Will contain the version of OpenRCT2 on this computer

    Dim RemoteDone As Boolean = False   'These two variables act as flags so that we know when both processes are complete.
    Dim LocalDone As Boolean = False

    Dim OpenRCTEXEName As String = ".\OpenRCT2\openrct2.exe"   'So it's easy to change when/if it gets changed officially.
    Dim OpenRCTDLLName As String = ".\OpenRCT2\openrct2.dll"

    Dim LauncherVersion As Integer = "1" 'The Version of the launcher, so we can update the launcher as well.

    Dim Key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
    Dim Reg As RegistryKey = Key.CreateSubKey("OpenRCT2Launcher")

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Dim GetRemote = New Thread(AddressOf GetRemoteVer)
        Dim GetLocal = New Thread(AddressOf GetLocalVer)
        Dim GetLauncher = New Thread(AddressOf LauncherUpdate)
        GetRemote.Start()
        GetLocal.Start()
        GetLauncher.Start()
        PictureBox1.Image = My.Resources.rollercoaster_tycoon_2_001
        If Reg.GetValue("Verbose") = "True" Then
            chkVerbose.Checked = True
        End If
    End Sub

    Private Sub GetRemoteVer()
        If My.Computer.Network.IsAvailable = True Then
            Try 'If the computer has a network connection but no internet, we want to avoid crashing.
                Dim WS As New WebClient
                WS.DownloadFile(URL, Path.GetTempPath & "OpenRCT2Update.html")
                Dim HTML As String = File.ReadAllText(Path.GetTempPath & "OpenRCT2Update.html")
                Dim Links As ArrayList = ParseLinks(HTML)
                For Each link In Links
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
        LocalDone = True
    End Sub
    Private Sub LauncherUpdate()

    End Sub
    Private Sub tmrCheckIfDone_Tick(sender As Object, e As EventArgs) Handles tmrCheckIfDone.Tick
        If LocalDone = True And RemoteDone = True Then
            tmrCheckIfDone.Enabled = False
            Call UpdateGUI()
        End If
    End Sub

    Private Sub UpdateGUI()
        If RemoteVer <> LocalVer Then
            lblStatus.Text = "Updating..."
            Call DownloadUpdate()
        Else
            lblStatus.Text = "Up to Date!"
            cmdLaunchGame.Enabled = True
            cmdForceUpdate.Enabled = True
        End If
    End Sub

    Private Sub cmdLaunchGame_Click(sender As Object, e As EventArgs) Handles cmdLaunchGame.Click
        If File.Exists(OpenRCTEXEName) And File.Exists(OpenRCTDLLName) Then
            Dim Launch As New ProcessStartInfo
            Launch.WorkingDirectory = ".\OpenRCT2"
            Launch.FileName = "OpenRCT2.exe"
            If chkVerbose.Checked = True Then
                Launch.Arguments = "--verbose"
                Reg.SetValue("Verbose", "True", RegistryValueKind.String)
            Else
                Reg.SetValue("Verbose", "False", RegistryValueKind.String)
            End If
            Process.Start(Launch)
            Close()

        Else
            MsgBox("OpenRCT2 Not Installed or Not Found!")
            'Code that does a force update
        End If
    End Sub

    Private Sub DownloadUpdate()
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
        lblStatus.Text = "Up to Date!"
        cmdLaunchGame.Enabled = True
        cmdForceUpdate.Enabled = True
    End Sub

    Public Function ParseLinks(ByVal HTML As String) As ArrayList
        Dim objRegEx As Regex
        Dim objMatch As Match
        Dim arrLinks As New System.Collections.ArrayList()
        ' Create regular expression
        objRegEx = New System.Text.RegularExpressions.Regex("a.*href\s*=\s*(?:""(?<1>[^""]*)""|(?<1>\S+))", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Compiled)
        ' Match expression to HTML
        objMatch = objRegEx.Match(HTML)
        ' Loop through matches and add <1> to ArrayList
        While objMatch.Success
            Dim strMatch As String
            strMatch = objMatch.Groups(1).ToString
            arrLinks.Add(strMatch)
            objMatch = objMatch.NextMatch()
        End While
        ' Pass back results
        Return arrLinks
    End Function

    Private Sub cmdForceUpdate_Click(sender As Object, e As EventArgs) Handles cmdForceUpdate.Click
        cmdForceUpdate.Enabled = False
        cmdLaunchGame.Enabled = False
        lblStatus.Text = "Force Updating..."
        Call DownloadUpdate()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
