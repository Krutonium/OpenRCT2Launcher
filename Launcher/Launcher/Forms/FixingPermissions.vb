Imports System.IO
Imports Microsoft.Win32

Public Class FixingPermissions
    Dim Key2 = Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup")
    Dim RCT2 = Key2.GetValue("Path")

    Private Sub FixingPermissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.OpenRCTIcon
        Me.Text = My.Resources.FixingPermissionsTitle
        Label1.Text = "Please Wait..."
        tmrFixPermissions.Start()
    End Sub

    Private Sub ClearReadOnly(parentDirectory As DirectoryInfo)
        If parentDirectory IsNot Nothing Then
            parentDirectory.Attributes = FileAttributes.Normal
            For Each fi As FileInfo In parentDirectory.GetFiles()
                fi.Attributes = FileAttributes.Normal
            Next
            For Each di As DirectoryInfo In parentDirectory.GetDirectories()
                ClearReadOnly(di)
            Next
            Me.Close()
        End If
    End Sub

    Private Sub tmrFixPermissions_Tick(sender As Object, e As EventArgs) Handles tmrFixPermissions.Tick
        tmrFixPermissions.Stop()
        ClearReadOnly(RCT2)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class