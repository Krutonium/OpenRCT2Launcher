Imports Microsoft.Win32
Imports System.IO
Public Class Extras

    Private Sub Extras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.cat_paw
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.WindowState = FormWindowState.Normal
        Me.MaximizeBox = False
    End Sub

    Private Sub cmdCSS17_Click(sender As Object, e As EventArgs) Handles cmdCSS17.Click
        MsgBox("If you are using a CD to run RCT1, Please insert it now.")
        Try
            Dim Key1 As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\fish technology group\rollercoaster tycoon setup")
            Dim RCT1 As String = Key1.GetValue("SetupPath")     'CSS17.dat seems to be kept on the CD for DRM Purposes.
            Dim Key2 As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup")
            Dim RCT2 As String = Key2.GetValue("Path")

            'MsgBox("RCT1 " & RCT1)      'Debugging, Remove
            'MsgBox("RCT2 " & RCT2)

            FileCopy(RCT1 & "/Data/CSS17.dat", RCT2 & "/Data/CSS50.dat")
        Catch ex As Exception
            MsgBox("Failed to copy file - Do you have the CD inserted and the game installed?" & vbNewLine & vbNewLine & "Exact Error:" & vbNewLine & ex.ToString)
        End Try

        MsgBox("Done!")
    End Sub
End Class