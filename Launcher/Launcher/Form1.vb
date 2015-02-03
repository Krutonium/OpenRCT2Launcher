Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Threading
Imports Microsoft.Win32
Imports System.Text.RegularExpressions
Imports System.Random

Public Class frmLauncher

    Dim URL As String = "https://openrct2.com/download/latest" ' Need to replace with Download from Version Text
    Dim RemoteVer As String        'Will contain the version of OpenRCT2 from the server
    Dim LocalVer As String         'Will contain the version of OpenRCT2 on this computer

    Dim RemoteDone As Boolean = False   'These two variables act as flags so that we know when both processes are complete.
    Dim LocalDone As Boolean = False

    Dim OpenRCTEXEName As String = ".\OpenRCT2\openrct2.exe"   'So it's easy to change when/if it gets changed officially.
    Dim OpenRCTDLLName As String = ".\OpenRCT2\openrct2.dll"

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
                Dim WS As New WebClient
                WS.DownloadFile(URL, Path.GetTempPath & "OpenRCT2Update.html")
                Dim HTML As String = File.ReadAllText(Path.GetTempPath & "OpenRCT2Update.html")
                Dim Stuff As ArrayList = ParseLinks(HTML)
                For Each thing In Stuff
                    If thing.ToString.ToLower.StartsWith("http://cdn.limetric.com/games/openrct2") And thing.ToString.ToLower.EndsWith(".zip") Then
                        RemoteVer = thing
                    End If
                Next
            Catch ex As Exception                           'because I want to grab the Download URL at the same time.

            End Try
        End If
        RemoteDone = True
    End Sub

    Private Sub GetLocalVer()
        Try
            Dim Reg As RegistryKey = (Registry.CurrentUser.CreateSubKey("OpenRCT2Launcher"))
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
            If RemoteVer = LocalVer = False Then
                lblStatus.Text = "Update is Available"
            Else
                lblStatus.Text = "Up to Date"
            End If
        End If
    End Sub

    Private Sub cmdLaunchGame_Click(sender As Object, e As EventArgs) Handles cmdLaunchGame.Click
        If File.Exists(OpenRCTEXEName) And File.Exists(OpenRCTDLLName) Then
            Dim Launch As New ProcessStartInfo
            Launch.WorkingDirectory = ".\OpenRCT2"
            Launch.FileName = "OpenRCT2.exe"
            Process.Start(Launch)
            Close()

        Else
            MsgBox("OpenRCT2 Not Installed or Not Found!")
            'Code that does a force update
        End If
    End Sub

    Private Sub DownloadUpdate()
        Try
            Dim WS As New WebClient
            WS.DownloadFile(URL, Path.GetTempPath & "OpenRCT2Update.html")
            Dim HTML As String = File.ReadAllText(Path.GetTempPath & "OpenRCT2Update.html")
            Dim Stuff As ArrayList = ParseLinks(HTML)
            Dim RemoteURL As String = Nothing
            For Each thing In Stuff
                If thing.ToString.ToLower.StartsWith("http://cdn.limetric.com/games/openrct2") And thing.ToString.ToLower.EndsWith(".zip") Then
                    WS.DownloadFile(thing, "./update.zip")
                    RemoteURL = thing
                End If
            Next
            If Directory.Exists("OpenRCT2") Then

                Directory.Delete("OpenRCT2", True)
            End If
            ZipFile.ExtractToDirectory("./update.zip", "./OpenRCT2")
            File.Delete("./update.zip")
            Dim Reg As RegistryKey = (Registry.CurrentUser.CreateSubKey("OpenRCT2Launcher"))
            Reg.SetValue("LocalVer", RemoteURL)
        Catch ex As Exception
            MsgBox(ex.ToString)
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
