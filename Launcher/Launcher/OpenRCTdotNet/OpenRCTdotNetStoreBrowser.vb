Imports Launcher.My.Resources
Imports Launcher.My
Imports Launcher.OpenRCTdotNet
Imports System.Net
Imports System.IO
Imports System.IO.Compression
Public Class OpenRCTdotNetStoreBrowser

    Private Sub OpenRCTdotNetStoreBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = OpenRCTIcon
        Me.Text = "OpenRCT.net Store"

        If Settings.OpenRCTdotNetUserID <> Nothing Then

            ' dont show ads if you're logged in: no need for an auth key, just add ?loggedin
            WebBrowser1.Url = New System.Uri("https://openrct.net/store.php?loggedin")

        End If


    End Sub
    Private Sub WebBrowser_Navigating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        'If Not e.Url.IsFile Then
        'MsgBox(e.Url.ToString)
        'End If
        Dim uu As String = e.Url.ToString.ToUpper
        If uu.EndsWith(".ZIP") Or uu.EndsWith(".RCT2MOD") Or uu.EndsWith(".SV6") Or uu.EndsWith(".SC6") Or uu.EndsWith(".ZIP") = True Then
            'MsgBox("Canceling Nav")
            e.Cancel = True
        End If
        DownloadFileAndInstall(e.Url.ToString)
    End Sub

    Private Sub DownloadFileAndInstall(ByVal URL As String)
        Dim WS As New WebClient
        Dim Saves = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2/save/"
        Dim TempF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2/temp/"
        If Directory.Exists(TempF) = False Then
            Directory.CreateDirectory(TempF)
        End If
        Dim RCT2LocReg = My.Computer.Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup")
        Dim RCT2Loc = RCT2LocReg.GetValue("Path")

        If URL.ToUpper.EndsWith(".SV6") Then
            MsgBox("Installing Save...")
            WS.DownloadFileAsync(New Uri(URL), RCT2Loc & "/Saved Games/" & Path.GetFileName(URL))
        ElseIf URL.ToUpper.EndsWith(".SC6") Then
            MsgBox("Installing Scenario...")
            WS.DownloadFileAsync(New Uri(URL), RCT2Loc & "/Scenarios/" & Path.GetFileName(URL))
        ElseIf URL.ToUpper.EndsWith(".DAT") Then
            MsgBox("Installing Object...")
            WS.DownloadFileAsync(New Uri(URL), RCT2Loc & "/ObjData/" & Path.GetFileName(URL))
        ElseIf URL.ToUpper.EndsWith(".ZIP") Then
            MsgBox("Installing Pack...")
            WS.DownloadFile(New Uri(URL), TempF & "\" & Path.GetFileName(URL))
            'WS.DownloadFile(New Uri(URL), RCT2Loc & "/ZIP/" & Path.GetFileName(URL))
            If Directory.Exists(TempF & "/Extracted") Then
                Directory.Delete(TempF & "/Extracted", True)
            End If
            ZipFile.ExtractToDirectory(TempF & "\" & Path.GetFileName(URL), TempF & "/Extracted")
            For Each Filee In Directory.GetFiles(TempF & "/Extracted", ".", SearchOption.AllDirectories)
                If Filee.ToUpper.EndsWith(".DAT") Then
                    File.Copy(Filee, RCT2Loc & "/ObjData/" & Path.GetFileName(Filee), True)
                End If
                If Filee.ToUpper.EndsWith(".SC6") Then
                    File.Copy(Filee, RCT2Loc & "/Scenarios/" & Path.GetFileName(Filee), True)
                End If
                If Filee.ToUpper.EndsWith(".SV6") Then
                    File.Copy(Filee, RCT2Loc & "/Saved Games/" & Path.GetFileName(Filee), True)
                End If
            Next
            MsgBox("Pack Installed.")
        ElseIf URL.ToUpper.EndsWith(".RCT2MOD") Then
            MsgBox("Installing modpack...")
            WS.DownloadFile(New Uri(URL), TempF & "\" & Path.GetFileName(URL))
            'WS.DownloadFile(New Uri(URL), RCT2Loc & "/ZIP/" & Path.GetFileName(URL))
            If Directory.Exists(TempF & "/Extracted") Then
                Directory.Delete(TempF & "/Extracted", True)
            End If
            ZipFile.ExtractToDirectory(TempF & "\" & Path.GetFileName(URL), TempF & "/Extracted")
            For Each Filee In Directory.GetFiles(TempF & "/Extracted/Data", ".", SearchOption.AllDirectories)
                File.Copy(Filee, RCT2Loc & "/Data/" & Path.GetFileName(Filee), True)
            Next
            For Each Filee In Directory.GetFiles(TempF & "/Extracted/ObjData", ".", SearchOption.AllDirectories)
                File.Copy(Filee, RCT2Loc & "/ObjData/" & Path.GetFileName(Filee), True)
            Next
            For Each Filee In Directory.GetFiles(TempF & "/Extracted/Scenarios", ".", SearchOption.AllDirectories)
                File.Copy(Filee, RCT2Loc & "/Scenarios/" & Path.GetFileName(Filee), True)
            Next
            For Each Filee In Directory.GetFiles(TempF & "/Extracted/Saved Games", ".", SearchOption.AllDirectories)
                File.Copy(Filee, RCT2Loc & "/Saved Games/" & Path.GetFileName(Filee), True)
            Next
            Directory.Delete(TempF & "/Extracted", True)
            File.Delete(TempF & "\" & Path.GetFileName(URL))
            MsgBox("Modpack Installed.")
        End If
    End Sub
End Class