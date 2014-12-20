Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Threading
Imports Microsoft.Win32
Imports System.Text.RegularExpressions

Public Class frmLauncher

    Dim URL As String = "https://openrct2.com/download/latest" ' Need to replace with Download from Version Text
    Dim VerURL As String = "https://www.dropbox.com/s/9uk7qdb5s4coakn/OpenRCTV.txt?dl=1"
    Dim RemoteVer As Integer        'Will contain the version of OpenRCT2 from the server
    Dim LocalVer As Integer         'Will contain the version of OpenRCT2 on this computer

    Dim RemoteDone As Boolean = False   'These two variables act as flags so that we know when both processes are complete.
    Dim LocalDone As Boolean = False

    Dim OpenRCTEXEName As String = "openrct2.exe"   'So it's easy to change when/if it gets changed officially.
    Dim OpenRCTDLLName As String = "openrct2.dll"

    Dim LauncherVersion As Integer = "1" 'The Version of the launcher, so we can update the launcher as well.

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim GetRemote = New Thread(AddressOf GetRemoteVer)
        Dim GetLocal = New Thread(AddressOf GetLocalVer)
        Dim GetLauncher = New Thread(AddressOf LauncherUpdate)
        GetRemote.Start()
        GetLocal.Start()
        GetLauncher.Start()
    End Sub

    Private Sub GetRemoteVer()
        If My.Computer.Network.IsAvailable = True Then
            Try 'If the computer has a network connection but no internet, we want to avoid crashing.
                Dim WC As New WebClient
                RemoteVer = WC.DownloadString(VerURL)       'Later on I am going to have to do some additional processing
            Catch ex As Exception                           'because I want to grab the Download URL at the same time.
                'MsgBox(ex.ToString)
                RemoteVer = Integer.MinValue
            End Try
        End If
        RemoteDone = True
    End Sub

    Private Sub GetLocalVer()
        Try
            Dim Reg As RegistryKey = (Registry.CurrentUser.CreateSubKey("OpenRCT2Launcher"))
            If Reg.GetValue("LocalVer") Is Nothing Then
                Reg.SetValue("LocalVer", "0")
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
            If RemoteVer > LocalVer Then
                lblStatus.Text = "Update is Available"
            Else
                lblStatus.Text = "Up to Date"
            End If
        End If
    End Sub

    Private Sub cmdLaunchGame_Click(sender As Object, e As EventArgs) Handles cmdLaunchGame.Click
        If File.Exists(OpenRCTEXEName) And File.Exists(OpenRCTDLLName) Then
            Dim Launch As New ProcessStartInfo
            Launch.WindowStyle = ProcessWindowStyle.Maximized
            Launch.FileName = OpenRCTEXEName
            Process.Start(Launch)
            Close()
        Else
            'Code that does a force update
        End If
    End Sub

    Private Sub DownloadUpdate()
        Try
            Dim WS As New WebClient
            WS.DownloadFile(URL, Path.GetTempPath & "OpenRCT2Update.html")
            Dim HTML As String = File.ReadAllText(Path.GetTempPath & "OpenRCT2Update.html")
            Dim Stuff As ArrayList = ParseLinks(HTML)
            For Each thing In Stuff
                If thing.ToString.ToLower.StartsWith("http://cdn.limetric.com/games/openrct2") And thing.ToString.ToLower.EndsWith(".zip") Then
                    WS.DownloadFile(thing, "./update.zip")
                End If
            Next
            ZipFile.ExtractToDirectory("./update.zip", "./")
            File.Delete("./update.zip")
        Catch ex As Exception
        End Try
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call DownloadUpdate()
    End Sub
End Class
