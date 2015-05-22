Imports Launcher.My.Resources
Imports Launcher.My
Imports Launcher.OpenRCTdotNet
Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports ORCT2ModPacker
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Runtime.InteropServices

Public Class OpenRCTdotNetStoreBrowser

    Dim ModName As String
    Dim description As String
    Dim Author As String
    Dim DownloadLink As String
    Dim WS As New WebClient


    Private Sub OpenRCTdotNetStoreBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2

        Me.Icon = OpenRCTIcon
        Me.Text = "OpenRCT.net Store"

        If Settings.OpenRCTdotNetUserID <> Nothing Then
            'Changing the User Agent ;)
            ChangeUserAgent("OpenRCT2LauncherStoreBrowser")
            ' dont show ads if you're logged in: no need for an auth key, just add ?loggedin
            WebBrowser1.Url = New System.Uri("https://openrct.net/store.php?loggedin")
        End If

    End Sub

    Private Sub WebBrowser_Navigating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        Dim uu As String = e.Url.ToString.ToUpper
        Dim url As String = Path.GetExtension(uu)
        If Path.GetExtension(url) = ".RCT2MOD" Then
            e.Cancel = True
            DownloadFileAndInstall(e.Url.ToString)
        End If

    End Sub

    Private Sub DownloadFileAndInstall(ByVal URL As String)
        Dim Saves = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2/save/"
        Dim TempF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2/temp/"
        If Directory.Exists(TempF) = False Then
            Directory.CreateDirectory(TempF)
        End If
        Dim RCT2LocReg = My.Computer.Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup")
        Dim RCT2Loc = RCT2LocReg.GetValue("Path")

        'New Code, Should hopefully solve the issue with Download Prompts

        Path.GetFileName(URL)
        Dim serverResponse As String = WS.DownloadString("https://openrct.net/api/?a=get_store_file&file=" & Path.GetFileName(URL) & "&secret=" & Settings.OpenRCTdotNetAPISecret)
        Dim jsonResult = JObject.Parse(serverResponse)
        ModName = jsonResult.SelectToken("name")
        description = jsonResult.SelectToken("description")
        Author = jsonResult.SelectToken("author")
        DownloadLink = jsonResult.SelectToken("download")
        Dim Result = MsgBox("Install " & ModName & " from " & Author & "?" & vbNewLine & vbNewLine & "Description: " & description, MsgBoxStyle.OkCancel, "Install " & ModName & "?")
        If Result = MsgBoxResult.Ok Then
            Try
                tsslStatus.Text = ("Please Wait, Installing " & ModName & "...")
                AddHandler WS.DownloadProgressChanged, AddressOf Progress
                AddHandler WS.DownloadFileCompleted, AddressOf InstallMod
                WS.DownloadFileAsync(New Uri(DownloadLink), TempF & "/pack.RCT2MOD")
            Catch ex As Exception
                tsslStatus.Text = "An error occured."
            End Try
        End If
    End Sub
    Private Sub Progress(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        tsslStatus.Text = ("Please Wait, Downloading " & ModName & " - " & e.ProgressPercentage & "% Downloaded.")
    End Sub
    Private Sub InstallMod()
        tsslStatus.Text = "Please Wait, Installing " & ModName & "..."
        Dim TempF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2/temp/"
        Dim RCT2LocReg = My.Computer.Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup")
        Dim RCT2Loc = RCT2LocReg.GetValue("Path")
        Dim Installer As New UnPackMod
        Installer.UnPackMod(TempF & "/pack.RCT2MOD", RCT2Loc)
        tsslStatus.Text = (ModName & " installed successfully!")
        resettext.Enabled = True
    End Sub

    Private Sub resettext_Tick(sender As Object, e As EventArgs) Handles resettext.Tick
        tsslStatus.Text = "Shop"
        resettext.Enabled = False
    End Sub

    <DllImport("urlmon.dll", CharSet:=CharSet.Ansi)> _
    Private Shared Function UrlMkSetSessionOption(ByVal dwOption As Integer, ByVal pBuffer As String, ByVal dwBufferLength As Integer, ByVal dwReserved As Integer) As Integer
    End Function
    Const URLMON_OPTION_USERAGENT As Integer = &H10000001
    Public Function ChangeUserAgent(ByVal Agent As String)
        UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0)
    #End Function
End Class