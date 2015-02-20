Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.IO.Compression
Imports Launcher.My
Imports HelperLibrary.Classes

Public Class Main
    Public Shared OpenRCT2Config As New OpenRCT2Config

    'Paths to files and folders

    Shared Sub Initialize()
        OpenRCT2Config.LoadDefault()
        OpenRCT2Config.LoadINI(Constants.OpenRCT2ConfigFile)
    End Sub

    Shared Async Function RemoteVersionGet() As Task(Of String)
        If My.Computer.Network.IsAvailable = True Then
            Try 'If the computer has a network connection but no internet, we want to avoid crashing.
                Return Await (New WebClient).DownloadStringTaskAsync(Constants.UpdateVersionURL)
            Catch ex As Exception 'because I want to grab the Download URL at the same time.
            End Try
        End If

        Return Nothing
    End Function

    Shared Sub Update(remoteVersion As String)
        Try
            Dim WS As New WebClient

            If Directory.Exists(Constants.OpenRCT2Bin) Then
                Directory.Delete(Constants.OpenRCT2Bin, True)      'Delete old folder if it exists.
            End If

            Directory.CreateDirectory(Constants.OpenRCT2Bin)

            WS.DownloadFile(Constants.UpdateURL, Constants.OpenRCT2Bin + "\update.zip")

            ZipFile.ExtractToDirectory(Constants.OpenRCT2Bin + "\update.zip", Constants.OpenRCT2Bin)    'Extracts to said folder.
            File.Delete(Constants.OpenRCT2Bin + "\update.zip")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class