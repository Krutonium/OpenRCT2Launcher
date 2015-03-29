Imports Launcher.My
Imports Launcher.My.Resources

Namespace OpenRCTdotNet
    Public Class OpenRCTdotNetConfigure

        Private Sub OpenRCTdotNetConfigure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Icon = OpenRCTIcon
            If Settings.OpenRCTdotNetUploadTime = True Then
                ChkUploadTime.Checked = True
            End If
            If Settings.OpenRCTdotNetSaveGames = True Then
                chkUploadSaves.Checked = True
                lblWarning.Text = "Warning" + vbNewLine + OpenRCTdotNetConfigureSlowDownWarn
            End If

            lblUsername.Text = OpenRCTdotNetConfigure_loggedInAs & Settings.OpenRCTdotNetUsername
        End Sub

        Private Sub ChkUploadTime_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUploadTime.CheckedChanged
            Settings.OpenRCTdotNetUploadTime = ChkUploadTime.Checked
            Settings.HasChanged = True
        End Sub

        Private Sub chkUploadSaves_CheckedChanged(sender As Object, e As EventArgs) Handles chkUploadSaves.CheckedChanged
            Settings.OpenRCTdotNetUploadTime = chkUploadSaves.Checked
            Settings.HasChanged = True

            If chkUploadSaves.Checked Then
                lblWarning.Text = "Warning" + vbNewLine + OpenRCTdotNetConfigureSlowDownWarn
            Else
                lblWarning.Text = ""
            End If
        End Sub
    End Class
End Namespace