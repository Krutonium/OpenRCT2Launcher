Namespace OpenRCTdotNet
    Public Class OpenRCTdotNetUser
        Public Username As String
        Public UserID As String
        Public AuthCode As String

        Public Sub New(Username As String, UserID As String, AuthCode As String)
            Me.Username = Username
            Me.UserID = UserID
            Me.AuthCode = AuthCode
        End Sub
    End Class
End Namespace