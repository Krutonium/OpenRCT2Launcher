Imports Launcher.My
Imports Launcher.My.Resources

Namespace OpenRCTdotNet
    Public Class OpenRCTdotNetConfigure

        Private Sub OpenRCTdotNetConfigure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Icon = cat_paw
            If Settings.UploadTime = True Then
                ChkUploadTime.Checked = True
            End If

            lblUsername.Text = OpenRCTdotNetConfigure_loggedInAs & Settings.Username
        End Sub

        Private Sub ChkUploadTime_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUploadTime.CheckedChanged
            If ChkUploadTime.Checked = True Then
                Settings.UploadTime = True
            Else
                Settings.UploadTime = False
            End If
            Settings.HasChanged = True
        End Sub
    End Class
End Namespace