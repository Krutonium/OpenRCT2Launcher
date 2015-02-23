Imports Launcher.My
Imports Launcher.My.Resources

Namespace OpenRCTdotNet
    Public Class OpenRCTdotNetConfigure

        Private Sub OpenRCTdotNetConfigure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Icon = OpenRCTIcon
            If Settings.OpenRCTdotNetUploadTime = True Then
                ChkUploadTime.Checked = True
            End If

            lblUsername.Text = OpenRCTdotNetConfigure_loggedInAs & Settings.OpenRCTdotNetUsername
        End Sub

        Private Sub ChkUploadTime_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUploadTime.CheckedChanged
            Settings.OpenRCTdotNetUploadTime = ChkUploadTime.Checked
            Settings.HasChanged = True
        End Sub

        Private Sub chkUploadSaves_CheckedChanged(sender As Object, e As EventArgs) Handles chkUploadSaves.CheckedChanged
            Settings.OpenRCTdotNetSaveGames = chkUploadSaves.Checked
            Settings.HasChanged = True
        End Sub
    End Class
End Namespace