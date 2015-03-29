Imports Launcher.My.Resources
Imports Launcher.My
Imports Launcher.OpenRCTdotNet

Public Class OpenRCTdotNetSyncSaves

    Private Sub OpenRCTdotNetSyncSaves_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = OpenRCTIcon
        lblStatus.Text = OpenRCTdotNetSaveSyncIdle
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
    End Sub

    Private Async Sub cmdSync_Click(sender As Object, e As EventArgs) Handles cmdSync.Click
        cmdSync.Enabled = False
        Await OpenRCTdotNetWebActions.UploadSaves(True)
        Await OpenRCTdotNetWebActions.DownloadSaves(True)
        lblStatus.Text = OpenRCTdotNetSaveSyncIdle
        cmdSync.Enabled = True
    End Sub
End Class