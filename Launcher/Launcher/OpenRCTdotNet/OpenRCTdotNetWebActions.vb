Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Launcher.My

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
    End Class

    Public Class OpenRCTdotNetWebActionException
        Inherits Exception

        Public Sub New(message As String)
            MyBase.New(message)
        End Sub
    End Class
End Namespace
