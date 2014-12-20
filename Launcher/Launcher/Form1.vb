Imports System.IO
Imports System.Net
Imports System.Threading
Imports Microsoft.Win32

Public Class frmLauncher

    Dim URL As String = "https://openrct2.com/download/latest" ' Should always give us the latest download ;)
    Dim VerURL As String = "https://www.dropbox.com/s/9uk7qdb5s4coakn/OpenRCTV.txt?dl=1"
    Dim RemoteVer As Integer        'Will contain the version of OpenRCT2 from the server
    Dim LocalVer As Integer         'Will contain the version of OpenRCT2 on this computer

    Dim RemoteDone As Boolean = False   'These two variables act as flags so that we know when both processes are complete.
    Dim LocalDone As Boolean = False

    Dim OpenRCTEXEName As String = "openrct2.exe"   'So it's easy to change when/if it gets changed officially.
    Dim OpenRCTDLLName As String = "openrct2.dll"

    Dim LauncherVersion As Integer = "1" 'The Version of the launcher, so we can update the launcher as well.

    Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim GetRemote = New Thread(AddressOf GetRemoteVer)
        Dim GetLocal = New Thread(AddressOf GetLocalVer)
        Dim GetLauncher = New Thread(AddressOf LauncherUpdate)
        GetRemote.Start()
        GetLocal.Start()
        GetLauncher.Start()
    End Sub

    Private Sub GetRemoteVer()
        If My.Computer.Network.IsAvailable = True Then
            Try 'If the computer has a network connection but no internet, we want to avoid crashing.
                Dim WC As New WebClient
                RemoteVer = WC.DownloadString(VerURL & "L")
            Catch ex As Exception
                'MsgBox(ex.ToString)
                RemoteVer = Integer.MinValue
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
            'MsgBox(ex.ToString)
        End Try
        LocalDone = True
    End Sub
    Private Sub LauncherUpdate()

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

    Private Sub cmdLaunchGame_Click(sender As Object, e As EventArgs) Handles cmdLaunchGame.Click
        If File.Exists(OpenRCTEXEName) And File.Exists(OpenRCTDLLName) Then
            Dim Launch As New ProcessStartInfo
            Launch.WindowStyle = ProcessWindowStyle.Normal
            Launch.FileName = OpenRCTEXEName
            Process.Start(Launch)
            Close()
        Else
            'Code that does a force update
        End If
    End Sub
End Class
