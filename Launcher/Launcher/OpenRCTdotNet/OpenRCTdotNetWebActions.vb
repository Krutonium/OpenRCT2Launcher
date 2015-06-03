Imports System
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Launcher.My
Imports Launcher.OpenRCTdotNet
Imports Launcher.My.Resources
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text

Namespace OpenRCTdotNet
    Public Class OpenRCTdotNetWebActions
        Private Shared ReadOnly Secret As String = Settings.OpenRCTdotNetAPISecret
        Private Const URLBase As String = "https://openrct.net/api/"

        Private Const LoginAuthCodeKey = "authCode"
        Private Const LoginUserIdKey = "userID"
        Private Const LoginUsernameKey = "username"
        Private Const LoginErrorKey = "error"

        Public Shared Async Function Login(username As String, password As String, saveLogin As Boolean) As Task(Of OpenRCTdotNetUser)
            Dim jsonResult As JObject
            Dim downloadUri As New Uri(String.Format("{0}{1}/auth.json", "https://openrct.net/api/v2/", Secret))
            Try
                'Dim serverResponse As String = Await (New WebClient).DownloadStringTaskAsync(downloadUri)

                Dim request As WebRequest = WebRequest.Create(downloadUri)
                request.Method = "POST"
                Dim postData As String = String.Format("username={0}&password={1}", username, password)
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
                request.ContentType = "application/x-www-form-urlencoded"
                request.ContentLength = byteArray.Length
                Dim dataStream As Stream = request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()
                Dim response As WebResponse = request.GetResponse()
                dataStream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim serverResponse As String = reader.ReadToEnd()
                reader.Close()
                dataStream.Close()
                response.Close()
                'MsgBox(serverResponse) 'debug
                jsonResult = JObject.Parse(serverResponse)
            Catch ex As WebException
                Return Nothing
            Catch ex As JsonSerializationException
                Return Nothing
            End Try

            If jsonResult.SelectToken(LoginErrorKey) IsNot Nothing Then
                If jsonResult.SelectToken("moreInfo") IsNot Nothing Then
                    Throw New OpenRCTdotNetWebActionException(jsonResult.SelectToken("moreInfo"))
                Else
                    Throw New OpenRCTdotNetWebActionException("An error happened: " & jsonResult.SelectToken(LoginErrorKey).ToString())
                End If

            End If

            If saveLogin Then
                Settings.OpenRCTdotNetUserAuthCode = jsonResult.SelectToken(LoginAuthCodeKey)
                Settings.OpenRCTdotNetUserID = jsonResult.SelectToken(LoginUserIdKey)
                Settings.OpenRCTdotNetUsername = jsonResult.SelectToken(LoginUsernameKey)
                If jsonResult.SelectToken("userRank") = "2" Then
                    Settings.Donator = True
                End If
                Settings.HasChanged = True
            End If

            Return New OpenRCTdotNetUser(Settings.OpenRCTdotNetUsername, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode)
        End Function

        Public Shared Async Function SaveUploadTime(minutesPlayed As Integer) As Task
            minutesPlayed += Settings.OpenRCTdotNetPlaytimeCache
            'Dim downloadUri As New Uri(String.Format("{0}?a=set_time_played&user={1}&auth={2}&secret={3}&minutes={4}", URLBase, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, Secret, minutesPlayed))
            Dim downloadUri As New Uri(String.Format("{0}{1}/coastercloud/playtime.json", "https://openrct.net/api/v2/", Secret))
            Try
                'Await (New WebClient).DownloadStringTaskAsync(downloadUri)
                Dim request As WebRequest = WebRequest.Create(downloadUri)
                request.Method = "POST"
                Dim postData As String = String.Format("userID={0}&auth={1}&minutes={2}", Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, minutesPlayed)
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
                request.ContentType = "application/x-www-form-urlencoded"
                request.ContentLength = byteArray.Length
                Dim dataStream As Stream = request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()
                Dim response As WebResponse = request.GetResponse()
                dataStream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim serverResponse As String = reader.ReadToEnd()
                reader.Close()
                dataStream.Close()
                response.Close()
                'MsgBox(serverResponse) 'debug

                Settings.OpenRCTdotNetPlaytimeCache = 0
                Settings.HasChanged = True
            Catch ex As WebException
                'No internet available or server down: retry next time
                Settings.OpenRCTdotNetPlaytimeCache = Integer.Parse(minutesPlayed)
                Settings.HasChanged = True
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
            Dim downloadUri As New Uri(String.Format("{0}{1}/coastercloud.json", "https://openrct.net/api/v2/", Secret))

            Dim RCT2SavedGamesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2/save/"

            Try
                'Await (New WebClient).DownloadStringTaskAsync(downloadUri)
                Dim request As WebRequest = WebRequest.Create(downloadUri)
                request.Method = "POST"
                Dim postData As String = String.Format("userID={0}&auth={1}", Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode)
                Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
                request.ContentType = "application/x-www-form-urlencoded"
                request.ContentLength = byteArray.Length
                Dim dataStream As Stream = request.GetRequestStream()
                dataStream.Write(byteArray, 0, byteArray.Length)
                dataStream.Close()
                Dim response As WebResponse = request.GetResponse()
                dataStream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim serverResponse As String = reader.ReadToEnd()
                reader.Close()
                dataStream.Close()
                response.Close()
                'MsgBox(serverResponse) 'debug



                jsonResult = JObject.Parse(serverResponse)

                If jsonResult.SelectToken("error") Is Nothing Then


                    Dim results As List(Of JToken) = jsonResult.Children().ToList
                    For Each item As JProperty In results

                        Dim thisFile = RCT2SavedGamesPath & item.Value("propername").ToString
                        If UpdateSyncForm = True Then
                            OpenRCTdotNetSyncSaves.lblStatus.Text = OpenRCTdotNetSaveSyncStatusDown & " " & item.Value("propername").ToString
                        End If
                        System.Windows.Forms.Application.DoEvents()

                        'check if file exists, if it does, check if it's older than the cloud file and if so; download, if it does not; download
                        Dim doDownload = False

                        If File.Exists(thisFile) Then

                            Dim infoReader As System.IO.FileInfo
                            infoReader = My.Computer.FileSystem.GetFileInfo(thisFile)
                            If infoReader.LastWriteTime.ToUniversalTime < Date.Parse(item.Value("savedate")) Then
                                doDownload = True
                            End If

                        Else
                            doDownload = True
                        End If

                        If doDownload Then
                            If File.Exists(thisFile) Then
                                File.Delete(thisFile)
                            End If

                            'Dim downloadFileUri As New Uri(String.Format("{0}?a=get_savegame&user={1}&auth={2}&secret={3}&file={4}", URLBase, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, Secret, item.Value("propername").ToString))
                            'Call (New WebClient).DownloadFile(downloadFileUri, thisFile)
                            Dim downloadFileUri As New Uri(String.Format("{0}{1}/coastercloud/{2}", "https://openrct.net/api/v2/", Secret, item.Value("propername").ToString().ToLower()))
                            request = WebRequest.Create(downloadFileUri)
                            request.Method = "POST"
                            postData = String.Format("userID={0}&auth={1}", Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode)
                            byteArray = Encoding.UTF8.GetBytes(postData)
                            request.ContentType = "application/x-www-form-urlencoded"
                            request.ContentLength = byteArray.Length


                            dataStream = request.GetRequestStream()
                            dataStream.Write(byteArray, 0, byteArray.Length)
                            dataStream.Close()
                            response = request.GetResponse()
                            Dim s As Stream = response.GetResponseStream()
                            
                            'Source stream with requested document  
                            Dim SourceStream = response.GetResponseStream()

                            'SourceStream has no ReadAll, so we must read data block-by-block  
                            'Temporary Buffer and block size  
                            Dim Buffer(4096) As Byte, BlockSize As Integer

                            'Memory stream to store data  
                            Dim TempStream As New MemoryStream
                            Do
                                BlockSize = SourceStream.Read(Buffer, 0, 4096)
                                If BlockSize > 0 Then TempStream.Write(Buffer, 0, BlockSize)
                            Loop While BlockSize > 0

                            Dim theFile As New FileStream(thisFile, FileMode.Create, FileAccess.Write)
                            TempStream.WriteTo(theFile)
                            theFile.Close()
                            TempStream.Close()

                            s.Close()
                            response.Close()


                            File.SetLastWriteTime(thisFile, New DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(Integer.Parse(item.Value("savedateUNIX").ToString)).ToUniversalTime())
                            ' set writetime to custom time from website so it doesnt get overwritten when another computer gets added
                        End If
                    Next
                End If
            Catch ex As Exception
                MsgBox("Error. Please take a screenshot and let the developers know." & ex.ToString)
            End Try
        End Function

        Public Shared Async Function UploadSaves(Optional ByVal UpdateSyncForm As Boolean = False) As Task
            Dim jsonResult As JObject
            'Find local path where games are saved
            Dim RCT2SavedGamesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "/OpenRCT2/save"

            Dim di As New DirectoryInfo(RCT2SavedGamesPath)
            Dim fiArr As FileInfo() = di.GetFiles()
            Dim fri As FileInfo
            Try
                For Each fri In fiArr
                    If fri.FullName.ToLower.EndsWith(".sv6") Then
                        Dim doUpload As Boolean = False
                        If UpdateSyncForm = True Then
                            OpenRCTdotNetSyncSaves.lblStatus.Text = OpenRCTdotNetSaveSyncStatusUpload & " " & fri.ToString()
                        End If
                        System.Windows.Forms.Application.DoEvents()
                        Dim uploadFileUri As New Uri(String.Format("{0}{1}/coastercloud/info/{2}.json", "https://openrct.net/api/v2/", Secret, fri.Name.ToLower().Substring(0, fri.Name.Length - 4)))
                        Debug.WriteLine(uploadFileUri.ToString())

                        'Dim serverResponse As String = (New WebClient).DownloadString(uploadFileUri)
                        Dim request As WebRequest = WebRequest.Create(uploadFileUri)
                        request.Method = "POST"
                        Dim postData As String = String.Format("userID={0}&auth={1}", Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode)
                        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
                        request.ContentType = "application/x-www-form-urlencoded"
                        request.ContentLength = byteArray.Length
                        Dim dataStream As Stream = request.GetRequestStream()
                        dataStream.Write(byteArray, 0, byteArray.Length)
                        dataStream.Close()
                        Dim response As WebResponse = request.GetResponse()
                        dataStream = response.GetResponseStream()
                        Dim reader As New StreamReader(dataStream)
                        Dim serverResponse As String = reader.ReadToEnd()
                        reader.Close()
                        dataStream.Close()
                        response.Close()

                        'MsgBox(serverResponse)
                        jsonResult = JObject.Parse(serverResponse)
                        If jsonResult.SelectToken("error") Is Nothing Then
                            Dim tmpSource() As Byte
                            Dim tmpHash() As Byte
                            tmpSource = File.ReadAllBytes(fri.FullName)
                            tmpHash = New MD5CryptoServiceProvider().ComputeHash(tmpSource)
                            Dim i As Integer
                            Dim HashB As New StringBuilder(tmpHash.Length)
                            For i = 0 To tmpHash.Length - 1
                                HashB.Append(tmpHash(i).ToString("X2"))     'Calculating MD5 for comparison.
                            Next
                            Dim Hash As String = HashB.ToString
                            If Hash = jsonResult.SelectToken("MD5").ToString.ToUpper = False Then
                                If DateTime.Compare(DateTime.Parse(ConvertTimestamp(jsonResult.SelectToken("savedateUNIX").ToString())), fri.LastWriteTime.ToUniversalTime) < 0 Then
                                    'Dim savedTime = ConvertDateTime(fri.LastWriteTime)
                                    'Dim doUploadFileUri As New Uri(String.Format("{0}?a=add_savegame&user={1}&auth={2}&savedtime={3}&secret={4}", URLBase, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, savedTime, Secret))
                                    'OpenRCTdotNetSyncSaves.Text = fri.ToString
                                    'Call (New WebClient).UploadFile(doUploadFileUri, fri.FullName)
                                    doUpload = True
                                End If
                            End If
                        Else
                            If jsonResult.SelectToken("moreInfo") = "Savegame not found" Then
                                ' the game isn't found on the server, so I don't even have to check if I want to upload
                                'Dim savedTime = ConvertDateTime(fri.LastWriteTime)
                                'Dim doUploadFileUri As New Uri(String.Format("{0}?a=add_savegame&user={1}&auth={2}&savedtime={3}&secret={4}", URLBase, Settings.OpenRCTdotNetUserID, Settings.OpenRCTdotNetUserAuthCode, savedTime, Secret))
                                'OpenRCTdotNetSyncSaves.Text = fri.ToString
                                'Call (New WebClient).UploadFile(doUploadFileUri, fri.FullName)
                                doUpload = True
                            Else
                                MsgBox(jsonResult.SelectToken("error"))
                            End If
                        End If
                        If doUpload Then
                            'MsgBox("Uploading " & fri.Name)

                            Dim savedTime = ConvertDateTime(fri.LastWriteTime)
                            Dim doUploadFileUri As New Uri(String.Format("{0}{1}/coastercloud/add.json", "https://openrct.net/api/v2/", Secret))
                            'filepath: fri.FullName
                            Dim boundary As String = Guid.NewGuid().ToString().Replace("-", String.Empty)
                            Dim obj = HttpWebRequest.Create(doUploadFileUri)
                            Dim objWebReq = CType(obj, HttpWebRequest)
                            objWebReq.ContentType = "multipart/form-data; boundary=" + boundary
                            objWebReq.Method = "POST"

                            Dim memStream = New MemoryStream(100240)
                            Dim writer = New StreamWriter(memStream)

                            writer.Write("--" + boundary + vbCrLf)
                            writer.Write("Content-Disposition: form-data; name=""{0}""{1}{2}", "userID", vbCrLf, vbCrLf)
                            writer.Write(Settings.OpenRCTdotNetUserID)
                            writer.Write(vbCrLf)


                            writer.Write("--" + boundary + vbCrLf)
                            writer.Write("Content-Disposition: form-data; name=""{0}""{1}{2}", "auth", vbCrLf, vbCrLf)
                            writer.Write(Settings.OpenRCTdotNetUserAuthCode)
                            writer.Write(vbCrLf)

                            writer.Write("--" + boundary + vbCrLf)
                            writer.Write("Content-Disposition: form-data; name=""{0}""{1}{2}", "savedtime", vbCrLf, vbCrLf)
                            writer.Write(savedTime)
                            writer.Write(vbCrLf)

                            'File
                            writer.Write("--" + boundary + vbCrLf)
                            writer.Write("Content-Disposition: form-data; name=""{0}""; filename=""{1}""{2}", "file", fri.FullName, vbCrLf)
                            writer.Write("Content-Type: application/octet-stream " + vbCrLf + vbCrLf)
                            'writer.Write(File.ReadAllBytes(fri.FullName).ToArray())
                            writer.Flush()

                            Using file = New FileStream(fri.FullName, FileMode.Open, FileAccess.Read)
                                Dim bytes(file.Length) As Byte
                                file.Read(bytes, 0, Integer.Parse(file.Length))
                                memStream.Write(bytes, 0, Integer.Parse(file.Length))
                            End Using


                            writer.Write(vbCrLf)

                            writer.Write("--{0}--{1}", boundary, vbCrLf)

                            writer.Flush()

                            objWebReq.ContentLength = memStream.Length
                            Dim rStream = objWebReq.GetRequestStream()
                            memStream.WriteTo(rStream)
                            memStream.Close()

                            Dim WebResponse = objWebReq.GetResponse()
                            Dim stReader = New StreamReader(WebResponse.GetResponseStream())
                            Dim output = stReader.ReadToEnd()

                            'MsgBox(output)

                        End If
                    End If
                Next fri
            Catch ex As Exception
                OpenRCTdotNetSyncSaves.lblStatus.Text = ("An Error Occured - Please try again.")
                'MsgBox(ex.ToString)
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
