Imports Microsoft.Win32
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports JunctionPoints

Public Class Extras
    'This Chunk here gets the Install Directories and CD Path's for RCT1 & 2.
    Dim Key1 As RegistryKey
    Dim RCT1CD As String
    Dim RCT1 As String
    Dim Key2 As RegistryKey
    Dim RCT2CD As String
    Dim RCT2 As String
    'End Chunk

    Dim DropboxPath As String = GetDropBoxPath()

    Dim OpenRCT2Folder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2"

    Private Sub Extras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.cat_paw
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.WindowState = FormWindowState.Normal
        Me.MaximizeBox = False
        Call SetupReg()
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
            MsgBox("The launcher could not find the registry keys. Do you have Both RCT1 & RCT2 Installed? If you do, please open an issue on GitHub.")
            cmdCSS17.Enabled = False
            cmdCSS17File.Enabled = True
            cmdDebug.Enabled = True
        End Try
    End Sub


    Private Sub cmdCSS17_Click(sender As Object, e As EventArgs) Handles cmdCSS17.Click
        MsgBox("If you are using a CD to run RollerCoaster Tycoon 1, Please insert it now.", MsgBoxStyle.Information, "Please Insert RCT 1 CD")

        Try
            FileCopy(RCT1CD & "/Data/CSS17.dat", RCT2 & "/Data/CSS50.dat")
        Catch ex As Exception
            MsgBox("Failed to copy file - Do you have the CD inserted and the game installed?" & vbNewLine & vbNewLine & "Exact Error:" & vbNewLine & ex.ToString, MsgBoxStyle.Critical, "An Error has occured!")
            Return
        End Try

        MsgBox("Done! You're all good to go!", MsgBoxStyle.Information, "Complete")
    End Sub

    Private Sub cmdCSS17File_Click(sender As Object, e As EventArgs) Handles cmdCSS17File.Click

        OFD1.Filter = "RCT1 Theme Music|*.dat"
        MsgBox("The file you are looking for is CSS17.dat")
        OFD1.ShowDialog()

        If File.Exists(OFD1.FileName) Then
            Try
                FileCopy(OFD1.FileName, RCT2 & "/Data/CSS50.dat")
            Catch ex As Exception
                MsgBox("Failed to copy file - Do you have the CD inserted and the game installed?" & vbNewLine & vbNewLine & "Exact Error:" & vbNewLine & ex.ToString, MsgBoxStyle.Critical, "An Error has occured!")
                Return
            End Try
            MsgBox("Done! You're all good to go!", MsgBoxStyle.Information, "Complete")
        Else
            MsgBox("No file selected.")
        End If
    End Sub

    Private Sub cmdDebug_Click(sender As Object, e As EventArgs) Handles cmdDebug.Click
        MsgBox("RollerCoaster Tycoon 1: " & vbNewLine & RCT1 & vbNewLine & _
               RCT1CD & vbNewLine & vbNewLine & _
               "RollerCoaster Tycoon 2: " & vbNewLine & RCT2 & vbNewLine & _
               RCT2CD & vbNewLine & vbNewLine & _
               "Dropbox: " & vbNewLine & DropboxPath)   'This Section is a Debug button - so I can find out a users path.
    End Sub

    Private Shared Function GetDropBoxPath() As String
        Dim appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim dbPath = Path.Combine(appDataPath, "Dropbox\host.db")

        If Not File.Exists(dbPath) Then
            Return Nothing
        End If

        Dim lines = File.ReadAllLines(dbPath)
        Dim dbBase64Text = Convert.FromBase64String(lines(1))
        Dim folderPath = Encoding.UTF8.GetString(dbBase64Text)

        Return folderPath
    End Function

    Private Sub cmdDropboxSync_Click(sender As Object, e As EventArgs) Handles cmdDropboxSync.Click
        If DropboxPath = Nothing Then
            MsgBox("Sorry, I don't think you have Dropbox Installed.")
        Else
            Dim Response = (MsgBox("Are you sure you want to move your Saves to Dropbox?", MsgBoxStyle.YesNo, "Move Saves?"))
            If Response = DialogResult.Yes Then
                Dim SavePathOriginal As String = RCT2 & "\Saved Games"
                Dim DropBoxSavePath As String = DropboxPath & "\OpenRCT2 Saves"
                If Directory.Exists(DropBoxSavePath) = False Then
                    Directory.CreateDirectory(DropBoxSavePath)
                End If
                Try
                    For Each Save In Directory.EnumerateFiles(SavePathOriginal)
                        File.Copy(Save, DropBoxSavePath & "/" & Path.GetFileName(Save), True)
                    Next
                Catch ex As Exception
                    'If there is no pre-existing files or the directory does not exist this will error out.
                End Try
                Try
                    For Each Save In Directory.EnumerateFiles(OpenRCT2Folder & "/save")
                        File.Copy(Save, DropBoxSavePath & "/" & Path.GetFileName(Save), True)
                    Next
                Catch ex As Exception

                End Try
                Try
                    Directory.Delete(SavePathOriginal, True)
                Catch ex As Exception
                End Try
                Try
                    Directory.Delete(OpenRCT2Folder & "/save", True)
                Catch ex As Exception

                End Try
                Dim CreateSymLink As New ProcessStartInfo
                CreateSymLink.FileName = ("C:\Windows\System32\cmd.exe")
                CreateSymLink.Arguments = ("/c mklink /J """ & SavePathOriginal & """ """ & DropBoxSavePath & """")
                CreateSymLink.Verb = ("runas")
                CreateSymLink.WorkingDirectory = ""
                Process.Start(CreateSymLink)
                CreateSymLink.Arguments = ("/c mklink /J """ & OpenRCT2Folder & "/save" & """ """ & DropBoxSavePath & """")
                Process.Start(CreateSymLink)
                MsgBox("Saves moved to Dropbox and Linked!", , "Saves Moved!")
            ElseIf Response = DialogResult.No Then
                'They answered no... so no.
            End If
        End If
    End Sub

    Private Sub cmdSyncAnyFolder_Click(sender As Object, e As EventArgs) Handles cmdSyncAnyFolder.Click
        Dim Result = MsgBox("Are you sure you want to move your saves to a new folder?", MsgBoxStyle.YesNo, "Are you sure?")
        If Result = DialogResult.Yes Then
            FBD.Description = ("Select where you want the saves to be stored.")
            FBD.ShowDialog()
            If Directory.Exists(FBD.SelectedPath) = True Then
                Dim SavePathOriginal As String = RCT2 & "\Saved Games"
                Try
                    For Each Save In Directory.EnumerateFiles(SavePathOriginal)
                        File.Copy(Save, FBD.SelectedPath & "/" & Path.GetFileName(Save), True)
                    Next
                Catch ex As Exception
                    'Error's if folder doesn't exist/contain files.
                End Try
                Try
                    Directory.Delete(SavePathOriginal, True)
                Catch ex As Exception
                End Try

                Try
                    JunctionPoint.Create(SavePathOriginal, FBD.SelectedPath, True)
                Catch ex As Exception
                    'No NTFS filesystem, create normal symlink
                    CreateSymbolicLink(SavePathOriginal, FBD.SelectedPath, SymbolicLink.Directory)
                End Try

                MsgBox("Saves moved to Dropbox and Linked!", , "Saves Moved!")
            Else
                MsgBox("The folder you selected doesn't exist!")
            End If
        End If
    End Sub

    <DllImport("kernel32.dll")> _
    Private Shared Function CreateSymbolicLink(lpSymlinkName As String, lpTargetName As String, dwFlags As SymbolicLink) As Boolean
    End Function

    Enum SymbolicLink
        File = 0
        Directory = 1
    End Enum

End Class