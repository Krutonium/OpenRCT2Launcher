Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Launcher.My
Imports Launcher.OpenRCTdotNet
Imports Launcher.My.Resources

Namespace OpenRCTdotNet
    Public Class OpenRCTdotNetWebActions
        Private Shared ReadOnly Secret As String = Settings.OpenRCTdotNetAPISecret
        Private Const URLBase As String = "https://openrct.net/api/"

        Private Const LoginAuthCodeKey = "authcode"
        Private Const LoginUserIdKey = "user_id"
        Private Const LoginUsernameKey = "user_name"
        Private Const LoginErrorKey = "error"

        Public Shared Async Function Login(username As String, password As String, saveLogin As Boolean) As Task(Of OpenRCTdotNetUser)
            Dim jsonResult As JObject
            Dim downloadUri As New Uri(String.Format("{0}?a=auth&username={1}&password={2}&secret={3}", URLBase, username, password, Secret))
            Try
                Dim serverResponse As String = Await (New WebClient).DownloadStringTaskAsync(downloadUri)
                jsonResult = JObject.Parse(serverResponse)
            Catch ex As WebException
                Return Nothing
            Catch ex As JsonSerializationException
                Return Nothing
            End Try

            If jsonResult.SelectToken(LoginErrorKey) IsNot Nothing Then
                Throw New OpenRCTdotNetWebActionException(jsonResult.SelectToken(LoginErrorKey))
            End If

            If saveLogin Then
                Settings.OpenRCTdotNetUserAuthCode = jsonResult.SelectToken(LoginAuthCodeKey)
                Settings.OpenRCTdotNetUserID = jsonResult.SelectToken(LoginUserIdKey)
                Settings.OpenRCTdotNetUsername = jsonResult.SelectToken(LoginUsernameKey)
                Settings.HasChanged = True
            End If

            Return New OpenRCTdotNetUser(Settings.OpenRCTdotNetUsername, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode)
        End Function

        Public Shared Async Function SaveUploadTime(minutesPlayed As Integer) As Task
            Dim downloadUri As New Uri(String.Format("{0}?a=set_time_played&user={1}&auth={2}&secret={3}&minutes={4}", URLBase, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, Secret, minutesPlayed))
            Try
                Await (New WebClient).DownloadStringTaskAsync(downloadUri)
            Catch ex As Exception
                'TODO: Add eror handling
            End Try
        End Function


        Public Shared Function ConvertTimestamp(ByVal timestamp As Integer) As DateTime
            Return New DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp)
        End Function
        Public Shared Function ConvertDateTime(ByVal timestamp As DateTime) As Integer
            Return (timestamp.ToUniversalTime - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds
        End Function

        Public Shared Async Function DownloadSaves(Optional ByVal UpdateSyncForm As Boolean = False) As Task
            Dim jsonResult As JObject
            Dim downloadUri As New Uri(String.Format("{0}?a=get_savegames&user={1}&auth={2}&secret={3}", URLBase, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, Secret))
            Dim RCT2SavedGamesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2/save/"

            Try
                Dim serverResponse As String = Await (New WebClient).DownloadStringTaskAsync(downloadUri)
                jsonResult = JObject.Parse(serverResponse)

                If jsonResult.SelectToken("error") Is Nothing Then


                    Dim results As List(Of JToken) = jsonResult.Children().ToList
                    For Each item As JProperty In results

                        Dim thisFile = RCT2SavedGamesPath & item.Value("propername").ToString
                        If UpdateSyncForm = True Then
                            OpenRCTdotNetSyncSaves.lblStatus.Text = OpenRCTdotNetSaveSyncStatusDown & item.Value("propername").ToString
                        End If
                        System.Windows.Forms.Application.DoEvents()

                        'check if file exists, if it does, check if it's older than the cloud file and if so; download, if it does not; download
                        If File.Exists(thisFile) Then

                            Dim infoReader As System.IO.FileInfo
                            infoReader = My.Computer.FileSystem.GetFileInfo(thisFile)
                            If infoReader.LastWriteTime.ToUniversalTime < Date.Parse(item.Value("savedate")) Then
                                File.Delete(thisFile)

                                Dim downloadFileUri As New Uri(String.Format("{0}?a=get_savegame&user={1}&auth={2}&secret={3}&file={4}", URLBase, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, Secret, item.Value("propername").ToString))
                                Call (New WebClient).DownloadFile(downloadFileUri, thisFile)
                                File.SetLastWriteTime(thisFile, New DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Integer.Parse(item.Value("savedateUNIX").ToString)).ToUniversalTime())
                                ' set writetime to custom time from website so it doesnt get overwritten when another computer gets added
                            End If

                        Else

                            Dim downloadFileUri As New Uri(String.Format("{0}?a=get_savegame&user={1}&auth={2}&secret={3}&file={4}", URLBase, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, Secret, item.Value("propername").ToString))
                            Call (New WebClient).DownloadFile(downloadFileUri, thisFile)
                            File.SetLastWriteTime(thisFile, New DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Integer.Parse(item.Value("savedateUNIX").ToString)).ToUniversalTime())
                            ' set writetime to custom time from website so it doesnt get overwritten when another computer gets added
                        End If
                    Next
                End If
            Catch ex As WebException
                'TODO: Add eror handling
                MsgBox(ex.ToString)
            Catch ex As JsonSerializationException
                'TODO: Add eror handling
                MsgBox(ex.ToString)
            End Try
        End Function

        Public Shared Async Function UploadSaves(Optional ByVal UpdateSyncForm As Boolean = False) As Task
            Dim jsonResult As JObject
            'Find local path where games are saved
            Dim RCT2SavedGamesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2/save"

            ' Make a reference to a directory.
            Dim di As New DirectoryInfo(RCT2SavedGamesPath)
            ' Get a reference to each file in that directory.
            Dim fiArr As FileInfo() = di.GetFiles()
            ' Display the names of the files.
            Dim fri As FileInfo
            For Each fri In fiArr
                If fri.FullName.ToLower.EndsWith(".sv6") Then
                    If UpdateSyncForm = True Then
                        OpenRCTdotNetSyncSaves.lblStatus.Text = OpenRCTdotNetSaveSyncStatusUpload & " " & fri.ToString()
                    End If
                    System.Windows.Forms.Application.DoEvents()
                    Dim uploadFileUri As New Uri(String.Format("{0}?a=get_savegame&user={1}&auth={2}&secret={3}&file={4}&info=true", URLBase, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, Secret, fri.Name))
                    Dim serverResponse As String = (New WebClient).DownloadString(uploadFileUri)

                    jsonResult = JObject.Parse(serverResponse)

                    If jsonResult.SelectToken("error") Is Nothing Then
                        If DateTime.Compare(DateTime.Parse(ConvertTimestamp(jsonResult.SelectToken("savedateUNIX").ToString())), fri.LastWriteTime.ToUniversalTime) < 0 Then
                            Dim savedTime = ConvertDateTime(fri.LastWriteTime)
                            Dim doUploadFileUri As New Uri(String.Format("{0}?a=add_savegame&user={1}&auth={2}&savedtime={3}&secret={4}", URLBase, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, savedTime, Secret))
                            Call (New WebClient).UploadFile(doUploadFileUri, fri.FullName)
                        End If
                    Else
                        If jsonResult.SelectToken("error") = "Savegame not found" Then
                            ' the game isn't found on the server, so I don't even have to check if I want to upload
                            Dim savedTime = ConvertDateTime(fri.LastWriteTime)
                            Dim doUploadFileUri As New Uri(String.Format("{0}?a=add_savegame&user={1}&auth={2}&savedtime={3}&secret={4}", URLBase, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, savedTime, Secret))
                            Call (New WebClient).UploadFile(doUploadFileUri, fri.FullName)
                        Else
                            MsgBox(jsonResult.SelectToken("error"))
                        End If
                    End If
                End If
            Next fri
        End Function

    End Class

    Public Class OpenRCTdotNetWebActionException
        Inherits Exception

        Public Sub New(message As String)
            MyBase.New(message)
        End Sub
    End Class
End Namespace
