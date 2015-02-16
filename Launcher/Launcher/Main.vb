Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Environment
Imports System.IO.Compression

Public Class Main
    Public Shared OpenRCT2Config As New OpenRCT2Config
    Public Shared LauncherConfig As New LauncherConfig

    'Paths to files and folders
    Public Shared OpenRCT2Folder As String = GetFolderPath(SpecialFolder.MyDocuments) + "\OpenRCT2"
    Public Shared OpenRCT2BinFolder As String = OpenRCT2Folder + "\bin"
    Public Shared OpenRCT2ConfigFile As String = OpenRCT2Folder + "\config.ini"
    Public Shared OpenRCT2EXE As String = OpenRCT2BinFolder + "\openrct2.exe"
    Public Shared OpenRCT2DLL As String = OpenRCT2BinFolder + "\openrct2.dll"
    Public Shared LauncherConfigFile As String = OpenRCT2Folder + "\launcher.ini"

    Public Shared URLLatest As String = "https://openrct.net/latest.zip"
    Public Shared URLRemoteVersion As String = "https://openrct.net/latest.zip?a=version"

    Public Shared LauncherVersion As Integer = 1

    Shared Sub Initialize()
        OpenRCT2Config.LoadDefault()
        LauncherConfig.LoadDefault()

        OpenRCT2Config.LoadINI(OpenRCT2ConfigFile)
        LauncherConfig.LoadINI(LauncherConfigFile)
    End Sub

    Shared Function RemoteVersionGet() As String
        If My.Computer.Network.IsAvailable = True Then
            Try 'If the computer has a network connection but no internet, we want to avoid crashing.
                Return (New WebClient).DownloadString(URLRemoteVersion)
            Catch ex As Exception 'because I want to grab the Download URL at the same time.
            End Try
        End If

        Return Nothing
    End Function

    Shared Sub Update(RemoteVersion As String)
        Try
            Dim WS As New WebClient

            If Directory.Exists(OpenRCT2BinFolder) Then
                Directory.Delete(OpenRCT2BinFolder, True)      'Delete old folder if it exists.
            End If

            Directory.CreateDirectory(OpenRCT2BinFolder)

            WS.DownloadFile(URLLatest, OpenRCT2BinFolder + "\update.zip")

            ZipFile.ExtractToDirectory(OpenRCT2BinFolder + "\update.zip", OpenRCT2BinFolder)    'Extracts to said folder.
            File.Delete(OpenRCT2BinFolder + "\update.zip")

            LauncherConfig.HasChanged = True
            LauncherConfig.LocalVersion = RemoteVersion
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class