Imports Launcher.My.Resources
Imports System.Net
Imports Newtonsoft.Json.Linq
Imports Launcher.My

Public Class OpenRCTdotNetLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OK.Click
        Dim username As String = UsernameTextBox.Text
        Dim password As String = PasswordTextBox.Text
        Const secret As String = "NXgFj50WlithAa5sK9Z3WGAGnboyJTrwRHcaNd78vAq6LvywEyzAfahDlFb5zCCqjOB62JfxkGE5bcCQLbr0mIDHoPMYropLd0Sg"
        Dim WC As New WebClient 'Switched the above to const because I wanted it all to line up, plus that should never change, so all things considered, it worked out well.
        Dim json As JObject = JObject.Parse(WC.DownloadString("https://openrct.net/api/?a=auth&username=" & username & "&password=" & password & "&secret=" & secret))
        'MsgBox(json.SelectToken("error"))
        If json.SelectToken("error") Is Nothing Then
            Dim user As String = json.SelectToken("user_name")
            MsgBox("Welcome " & user & "!")
            Settings.UserKey = json.SelectToken("authcode")
            Settings.UserID = json.SelectToken("user_id")
            Settings.UserName = json.SelectToken("user_name")
            Settings.HasChanged = True
            Close()
        Else
            MsgBox(json.SelectToken("error"))
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Cancel.Click
        Close()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogoPictureBox.Image = rollercoaster_tycoon_2_001
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://openrct.net/")
    End Sub
End Class
