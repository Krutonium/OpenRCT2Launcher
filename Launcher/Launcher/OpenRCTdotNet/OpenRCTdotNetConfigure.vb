Imports Launcher.My
Imports Launcher.My.Resources

Namespace OpenRCTdotNet
    Public Class OpenRCTdotNetConfigure

        Private Sub OpenRCTdotNetConfigure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Icon = OpenRCTIcon
            FormBorderStyle = FormBorderStyle.Fixed3D
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            ChkUploadTime.Checked = Settings.OpenRCTdotNetUploadTime
            chkUploadSaves.Checked = Settings.OpenRCTdotNetSaveGames
            If chkUploadSaves.Checked = True Then
                lblWarning.Text = "Warning" + vbNewLine + OpenRCTdotNetConfigureSlowDownWarn
            End If

            lblUsername.Text = OpenRCTdotNetConfigure_loggedInAs & Settings.OpenRCTdotNetUsername
        End Sub

        Private Sub ChkUploadTime_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUploadTime.CheckedChanged
            Settings.OpenRCTdotNetUploadTime = ChkUploadTime.Checked
            Settings.HasChanged = True
            Settings.Save()
        End Sub

        Private Sub chkUploadSaves_CheckedChanged(sender As Object, e As EventArgs) Handles chkUploadSaves.CheckedChanged
            Settings.OpenRCTdotNetSaveGames = chkUploadSaves.Checked
            Settings.HasChanged = True
            Settings.Save()
            If chkUploadSaves.Checked Then
                lblWarning.Text = "Warning" + vbNewLine + OpenRCTdotNetConfigureSlowDownWarn
            Else
                lblWarning.Text = ""
            End If
        End Sub
    End Class
End Namespace