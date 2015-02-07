Imports Microsoft.Win32
Imports System.IO
Public Class Extras
    'This Chunk here gets the Install Directories and CD Path's for RCT1 & 2.
    Dim Key1 As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\fish technology group\rollercoaster tycoon setup")
    Dim RCT1CD As String = Key1.GetValue("SetupPath")   'Where RCT sees the CD as located
    Dim RCT1 As String = Key1.GetValue("Path")          'Actual Install Location
    Dim Key2 As RegistryKey = Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup")
    Dim RCT2CD As String = Key2.GetValue("SetupPath")   'Where RCT2 sees the CD as located
    Dim RCT2 As String = Key2.GetValue("Path")          'Actual Install Location
    'End Chunk
    Private Sub Extras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.cat_paw
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.WindowState = FormWindowState.Normal
        Me.MaximizeBox = False
    End Sub

    Private Sub cmdCSS17_Click(sender As Object, e As EventArgs) Handles cmdCSS17.Click
        MsgBox("If you are using a CD to run RollerCoaster Tycoon 1, Please insert it now.", MsgBoxStyle.Information, "Please Insert RCT 1 CD")
        Try
            FileCopy(RCT1CD & "/Data/CSS17.dat", RCT2 & "/Data/CSS50.dat")
        Catch ex As Exception
            MsgBox("Failed to copy file - Do you have the CD inserted and the game installed?" & vbNewLine & vbNewLine & "Exact Error:" & vbNewLine & ex.ToString, MsgBoxStyle.Critical, "An Error has occured!")
        End Try

        MsgBox("Done! Assuming you saw no errors, your all good to go!", MsgBoxStyle.Information, "Complete")
    End Sub

    Private Sub cmdCSS17File_Click(sender As Object, e As EventArgs) Handles cmdCSS17File.Click

        OFD1.Filter = "RCT1 Theme Music|*.dat"
        MsgBox("The file you are looking for is CSS17.dat")
        OFD1.ShowDialog()
        If File.Exists(OFD1.FileName) Then
            FileCopy(OFD1.FileName, RCT2 & "/Data/CSS50.dat")
        Else
            MsgBox("No File Selected.")
        End If
        MsgBox("Done! Assuming you saw no errors, your all good to go!", MsgBoxStyle.Information, "Complete")
    End Sub

    Private Sub cmdDebug_Click(sender As Object, e As EventArgs) Handles cmdDebug.Click
        MsgBox("RollerCoaster Tycoon 1: " & vbNewLine & RCT1 & vbNewLine & _
               RCT1CD & vbNewLine & vbNewLine & _
               "RollerCoaster Tycoon 2: " & vbNewLine & RCT2 & vbNewLine & _
               RCT2CD)   'This Section is a Debug button - so I can find out a users path.
    End Sub
End Class