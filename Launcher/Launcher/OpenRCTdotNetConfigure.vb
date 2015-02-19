Imports Launcher.My.Resources
Public Class OpenRCTdotNetConfigure

    Private Sub OpenRCTdotNetConfigure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = cat_paw
        If Main.LauncherConfig.UploadTime = True Then
            ChkUploadTime.Checked = True
        End If

        lblUsername.Text = "You are logged in as " & Main.LauncherConfig.UserName
    End Sub

    Private Sub ChkUploadTime_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUploadTime.CheckedChanged
        If ChkUploadTime.Checked = True Then
            Main.LauncherConfig.UploadTime = True
        Else
            Main.LauncherConfig.UploadTime = False
        End If
        Main.LauncherConfig.HasChanged = True
    End Sub
End Class