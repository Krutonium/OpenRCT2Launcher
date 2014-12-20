Imports System.IO
Imports System.Net
Imports System.Threading
Imports Microsoft.Win32

Public Class frmLauncher

    Dim URL As String = "https://openrct2.com/download/latest" ' Should always give us the latest download ;)
    Dim VerURL As String = "https://www.dropbox.com/s/9uk7qdb5s4coakn/OpenRCTV.txt?dl=1"
    Dim RemoteVer As Integer
    Dim LocalVer As Integer

    Dim RemoteDone As Boolean = False
    Dim LocalDone As Boolean = False

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim GetRemote = New Thread(AddressOf GetRemoteVer)
        Dim GetLocal = New Thread(AddressOf GetLocalVer)
        GetRemote.Start()
        GetLocal.Start()
    End Sub

    Private Sub GetRemoteVer()
        If My.Computer.Network.IsAvailable = True Then
            Try 'If the computer has a network connection but no internet, we want to avoid crashing.
                Dim WC As New WebClient
                RemoteVer = WC.DownloadString(VerURL)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        RemoteDone = True
    End Sub

    Private Sub GetLocalVer()
        Try
            Dim Reg As RegistryKey = (Registry.CurrentUser.CreateSubKey("OpenRCT2Launcher"))
            If Reg.GetValue("LocalVer") Is Nothing Then
                Reg.SetValue("LocalVer", "0")
                LocalVer = "0"
            Else
                LocalVer = Reg.GetValue("LocalVer")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        LocalDone = True
    End Sub

    Private Sub tmrCheckIfDone_Tick(sender As Object, e As EventArgs) Handles tmrCheckIfDone.Tick
        If LocalDone = True And RemoteDone = True Then
            tmrCheckIfDone.Enabled = False
            If RemoteVer > LocalVer Then
                lblStatus.Text = "Update is Available"
            Else
                lblStatus.Text = "Up to Date"
            End If
        End If
    End Sub
End Class
