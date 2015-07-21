Imports System.Windows.Forms
Imports Launcher.My

Public Class FirstRunDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StableButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        My.Settings.DownloadDevelop = False
        Settings.FirstRun = False
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevelopmentButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        My.Settings.DownloadDevelop = True
        Settings.FirstRun = False
        My.Settings.Save()
        Me.Close()
    End Sub

End Class
