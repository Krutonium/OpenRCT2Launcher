Imports Microsoft.Win32
Imports System.IO
Public Class Extras
    'This Chunk here gets the Install Directories and CD Path's for RCT1 & 2.
    Dim Key1 As RegistryKey
    Dim RCT1CD As String
    Dim RCT1 As String
    Dim Key2 As RegistryKey
    Dim RCT2CD As String
    Dim RCT2 As String
    'End Chunk
    Private Sub Extras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.cat_paw
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.WindowState = FormWindowState.Normal
        Me.MaximizeBox = False
    End Sub

    Private Sub SetupReg()
        Try
            Key1 = Registry.LocalMachine.OpenSubKey("Software\fish technology group\rollercoaster tycoon setup")
            RCT1CD = Key1.GetValue("SetupPath")
            RCT1 = Key1.GetValue("Path")
            Key2 = Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup")
            RCT2CD = Key2.GetValue("SetupPath")   'Where RCT2 sees the CD as located
            RCT2 = Key2.GetValue("Path")
        Catch ex As Exception
            MsgBox("Do you have Both RCT1 & RCT2 Installed? If you do, please open an issue on GitHub.")
            cmdCSS17.Enabled = False
            cmdCSS17File.Enabled = True
            cmdDebug.Enabled = False
        End Try
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