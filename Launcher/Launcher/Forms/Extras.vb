Imports System.IO
Imports System.Text
Imports HelperLibrary.Utils
Imports Launcher.My
Imports Launcher.My.Resources
Imports Microsoft.Win32
Imports Launcher.OpenRCTdotNet

Namespace Forms
    Public Class Extras
        'This Chunk here gets the Install Directories and CD Path's for RCT1 & 2.
        Dim Key1 As RegistryKey
        Dim RCT1CD As String
        Dim RCT1 As String
        Dim Key2 As RegistryKey
        Dim RCT2CD As String
        Dim RCT2 As String
        'End Chunk


        ReadOnly _dropboxPath As String = GetDropBoxPath()
        ReadOnly _openRCT2Folder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2"

        Private Sub Extras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Icon = OpenRCTIcon
            FormBorderStyle = FormBorderStyle.Fixed3D
            WindowState = FormWindowState.Normal
            MaximizeBox = False
            Call SetupReg()
            Call CheckIfLoggedIn()
        End Sub

        Private Sub SetupReg()
            Try
                Key1 = Registry.LocalMachine.OpenSubKey("Software\fish technology group\rollercoaster tycoon setup")
                RCT1CD = Key1.GetValue("SetupPath")
                RCT1 = Key1.GetValue("Path")
                Key2 = Registry.LocalMachine.OpenSubKey("Software\Infogrames\rollercoaster tycoon 2 setup")
                RCT2CD = Key2.GetValue("SetupPath")   'Where RCT2 sees the CD as located
                RCT2 = Key2.GetValue("Path")
                Settings.OptionsDialogRCT1 = True
            Catch ex As Exception
                If Settings.OptionsDialogRCT1 = False Then
                    Settings.OptionsDialogRCT1 = True
                    MsgBox(extras_setupReg_noRegisterKeys)
                End If
                cmdCSS17.Enabled = False
                cmdCSS17File.Enabled = True
                cmdDebug.Enabled = True
            End Try
        End Sub

        Private Sub CheckIfLoggedIn()
            If Settings.OpenRCTdotNetUserID = Nothing Then
                'If we ever want to do somthing if they are not logged in, here is the place!\
                cmdSyncSaves.Enabled = False
                cmdOpenRCTNetFeatures.Enabled = False
            Else
                cmdOpenRCTNetFeatures.Enabled = True
                cmdSyncSaves.Enabled = True
            End If
        End Sub

        Private Sub cmdCSS17_Click(sender As Object, e As EventArgs) Handles cmdCSS17.Click
            MsgBox(extras_cdSoundtrack_firstWarning_text, MsgBoxStyle.Information, extras_cdSoundtrack_firstWarning_title)

            Try
                FileCopy(RCT1CD & "/Data/CSS17.dat", RCT2 & "/Data/CSS50.dat")
            Catch ex As Exception
                MsgBox(extras_cdSoundtrack_failed_text & ex.ToString, MsgBoxStyle.Critical, common_errorOccurred)
                Return
            End Try

            MsgBox(extras_cdSoundtrack_done_text, MsgBoxStyle.Information, common_complete)
        End Sub

        Private Sub cmdCSS17File_Click(sender As Object, e As EventArgs) Handles cmdCSS17File.Click

            OFD1.Filter = "RCT1 Theme Music|*.dat"
            MsgBox(extras_fileSoundtrack_hint)
            OFD1.ShowDialog()

            If File.Exists(OFD1.FileName) Then
                Try
                    FileCopy(OFD1.FileName, RCT2 & "/Data/CSS50.dat")
                Catch ex As Exception
                    MsgBox(extras_cdSoundtrack_failed_text & ex.ToString, MsgBoxStyle.Critical, common_errorOccurred)
                    Return
                End Try
                MsgBox(extras_cdSoundtrack_done_text, MsgBoxStyle.Information, common_complete)
            Else
                MsgBox(extras_fileSoundtrack_noFileSelected)
            End If
        End Sub

        Private Sub cmdDebug_Click(sender As Object, e As EventArgs) Handles cmdDebug.Click
            MsgBox("RollerCoaster Tycoon 1: " & vbNewLine & RCT1 & vbNewLine & _
                   RCT1CD & vbNewLine & vbNewLine & _
                   "RollerCoaster Tycoon 2: " & vbNewLine & RCT2 & vbNewLine & _
                   RCT2CD & vbNewLine & vbNewLine & _
                   "Dropbox: " & vbNewLine & _dropboxPath)   'This Section is a Debug button - so I can find out a users path.
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
            If _dropboxPath = Nothing Then
                MsgBox(extras_syncDropbox_notInstalled)
            Else
                Dim response = (MsgBox(extras_syncDropbox_firstWarning_text, MsgBoxStyle.YesNo, extras_syncDropbox_firstWarning_title))
                If response = DialogResult.Yes Then
                    Dim SavePathOriginal As String = RCT2 & "\Saved Games"
                    Dim DropBoxSavePath As String = _dropboxPath & "\OpenRCT2Saves"
                    If Not Directory.Exists(DropBoxSavePath) Then
                        Directory.CreateDirectory(DropBoxSavePath)
                    End If

                    If CopyFilesToFolderAndLink(SavePathOriginal, DropBoxSavePath) And CopyFilesToFolderAndLink(_openRCT2Folder & "\save", DropBoxSavePath) Then
                        MsgBox(extras_syncDropbox_moved_text, , extras_syncDropbox_moved_title)
                    End If
                End If
            End If
        End Sub

        Private Sub cmdSyncAnyFolder_Click(sender As Object, e As EventArgs) Handles cmdSyncAnyFolder.Click
            Dim result = MsgBox(extras_anyFolderSync_firstWarning_text, MsgBoxStyle.YesNo, extras_anyFolderSync_firstWarning_title)
            If result = DialogResult.Yes Then
                FBD.Description = extras_anyFolderSync_fileDialog_desc
                FBD.ShowDialog()
                Dim SavePathOriginal As String = RCT2 & "\Saved Games"

                If CopyFilesToFolderAndLink(SavePathOriginal, FBD.SelectedPath) And CopyFilesToFolderAndLink(_openRCT2Folder & "", FBD.SelectedPath) Then
                    MsgBox(extras_anyFolderSync_done, , extras_syncDropbox_moved_title)
                Else
                    MsgBox(extras_anyFolderSync_error_notexists)
                End If
            End If
        End Sub

        Private Shared Function CopyFilesToFolderAndLink(sourcePath As String, targetPath As String) As Boolean
            If Not Directory.Exists(targetPath) Then
                Return False
            End If

            FileActions.CopyDirectory(sourcePath, targetPath)

            ReparsePoint.Create(sourcePath, targetPath, True, ReparsePoint.LinkType.DirectoryLink)

            Return True
        End Function

        Private Sub cmdLoginOpenRCTnet_Click(sender As Object, e As EventArgs) Handles cmdLoginOpenRCTnet.Click
            OpenRCTdotNetLogin.ShowDialog()
        End Sub

        Private Sub cmdOpenRCTNetFeatures_Click(sender As Object, e As EventArgs) Handles cmdOpenRCTNetFeatures.Click
            OpenRCTdotNetConfigure.ShowDialog()
        End Sub

        Private Sub cmdSyncSaves_Click(sender As Object, e As EventArgs) Handles cmdSyncSaves.Click
            OpenRCTdotNetSyncSaves.ShowDialog()
        End Sub

        Private Sub cmdWebStore_Click(sender As Object, e As EventArgs) Handles cmdWebStore.Click
            OpenRCTdotNetStoreBrowser.Visible = True
        End Sub
    End Class
End Namespace