Imports Microsoft.Win32
Imports System.IO
Imports System.Text

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
            MsgBox(My.Resources.strings.extras_registry_keys_not_found)
            cmdCSS17.Enabled = False
            cmdCSS17File.Enabled = True
            cmdDebug.Enabled = True
        End Try
    End Sub


    Private Sub cmdCSS17_Click(sender As Object, e As EventArgs) Handles cmdCSS17.Click
        MsgBox(My.Resources.strings.extras_rct1_music_copy_insert_disk_text, MsgBoxStyle.Information, My.Resources.strings.extras_rct1_music_copy_insert_disk_title)

        Dim succes As Boolean = True

        Try
            FileCopy(RCT1CD & "/Data/CSS17.dat", RCT2 & "/Data/CSS50.dat")
        Catch ex As Exception
            MsgBox(My.Resources.strings.extras_rct1_music_copy_failed_text & vbNewLine & vbNewLine & My.Resources.strings.extras_rct1_music_copy_exact_error & vbNewLine & ex.ToString, MsgBoxStyle.Critical, My.Resources.strings.extras_rct1_music_copy_failed_title)
            succes = False
        End Try

        If succes Then
            MsgBox(My.Resources.strings.extras_rct1_music_copy_succes_text, MsgBoxStyle.Information, My.Resources.strings.extras_rct1_music_copy_succes_title)
        End If

    End Sub

    Private Sub cmdCSS17File_Click(sender As Object, e As EventArgs) Handles cmdCSS17File.Click

        OFD1.Filter = "RCT1 Theme Music|*.dat"
        MsgBox(My.Resources.strings.extras_rct1_music_manual_copy_file_instrutions)
        OFD1.ShowDialog()

        If File.Exists(OFD1.FileName) Then
            Dim succes As Boolean = True
            Try
                FileCopy(OFD1.FileName, RCT2 & "/Data/CSS50.dat")
            Catch ex As Exception
                succes = False
                MsgBox(My.Resources.strings.extras_rct1_music_copy_failed_text & vbNewLine & vbNewLine & My.Resources.strings.extras_rct1_music_copy_exact_error & vbNewLine & ex.ToString, MsgBoxStyle.Critical, My.Resources.strings.extras_rct1_music_copy_failed_title)
            End Try
            If succes Then
                MsgBox(My.Resources.strings.extras_rct1_music_copy_succes_text, MsgBoxStyle.Information, My.Resources.strings.extras_rct1_music_copy_succes_title
                       )
            End If
        Else
            MsgBox(My.Resources.strings.extras_rct1_music_manual_copy_no_file_selected)
        End If
    End Sub

    Private Sub cmdDebug_Click(sender As Object, e As EventArgs) Handles cmdDebug.Click
        MsgBox(My.Resources.strings.extras_debug_rct1 & vbNewLine & RCT1 & vbNewLine & _
               RCT1CD & vbNewLine & vbNewLine & _
               My.Resources.strings.extras_rct1_music_copy_exact_error & vbNewLine & RCT2 & vbNewLine & _
               RCT2CD & vbNewLine & vbNewLine & _
               My.Resources.strings.extras_debug_dropbox & vbNewLine & DropboxPath)   'This Section is a Debug button - so I can find out a users path.
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
            MsgBox(My.Resources.strings.extras_cloud_save_dropbox_not_installed)
        Else
            Dim Response = (MsgBox(My.Resources.strings.extras_cloud_save_dropbox_text, MsgBoxStyle.YesNo, My.Resources.strings.extras_cloud_save_dropbox_title))
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
                    Directory.Delete(SavePathOriginal, True)
                Catch ex As Exception

                End Try
                Dim CreateSymLink As New ProcessStartInfo
                CreateSymLink.FileName = ("C:\Windows\System32\cmd.exe")
                CreateSymLink.Arguments = ("/c mklink /J """ & SavePathOriginal & """ """ & DropBoxSavePath & """")
                CreateSymLink.Verb = ("runas")
                CreateSymLink.WorkingDirectory = ""
                Process.Start(CreateSymLink)
                MsgBox(My.Resources.strings.extras_cloud_save_dropbox_succes_text, , My.Resources.strings.extras_cloud_save_dropbox_succes_title)
            ElseIf Response = DialogResult.No Then
                'They answered no... so no.
            End If
        End If
    End Sub

    Private Sub cmdSyncAnyFolder_Click(sender As Object, e As EventArgs) Handles cmdSyncAnyFolder.Click
        Dim Result = MsgBox(My.Resources.strings.extras_cloud_save_folder_text, MsgBoxStyle.YesNo, My.Resources.strings.extras_cloud_save_folder_title)
        If Result = DialogResult.Yes Then
            FBD.Description = (My.Resources.strings.extras_cloud_save_folder_select)
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
                Dim CreateSymLink As New ProcessStartInfo
                CreateSymLink.FileName = ("C:\Windows\System32\cmd.exe")
                CreateSymLink.Arguments = ("/c mklink /J """ & SavePathOriginal & """ """ & FBD.SelectedPath & """")
                CreateSymLink.Verb = ("runas")
                CreateSymLink.WorkingDirectory = ""
                Process.Start(CreateSymLink)
                MsgBox(My.Resources.strings.extras_cloud_save_folder_succes_text, , My.Resources.strings.extras_cloud_save_folder_succes_title)
            Else
                MsgBox(My.Resources.strings.extras_cloud_save_folder_does_not_exist)
            End If
        End If
    End Sub
End Class