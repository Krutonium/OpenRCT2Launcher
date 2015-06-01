Imports System.IO
Imports System.IO.Compression
Public Class ModPack
    Dim Dir As String = Nothing
    Dim Name As String = Nothing
    Dim Desc As String = Nothing
    Dim Auth As String = Nothing
    Dim Preview As String = Nothing
    Dim Zip As String = Nothing
    Dim LastError As String = Nothing
    Dim Temp As String = Path.GetTempPath & "ModPacker\"

    Public Function PackMod()
        Try
            System.IO.Directory.Delete(Temp, True)
        Catch ex As Exception

        End Try
        'MAKING SURE ALL NEEDED SETTINGS ARE SET
        LastError = Nothing
        If Dir = Nothing Then
            LastError = "DIR_MISSING"
        ElseIf Name = Nothing Then
            LastError = "NAME_MISSING"
        ElseIf Desc = Nothing Then
            LastError = "DESC_MISSING"
        ElseIf Preview = Nothing Then
            LastError = "PREVIEW_MISSING"
        ElseIf Auth = Nothing Then
            LastError = "AUTHOR_MISSING"
        ElseIf Zip = Nothing Then
            LastError = "ZIP_MISSING"
        End If
        If LastError = Nothing = False Then Return False
        'AT THIS POINT WE WILL TRUST THE DATA.
        If File.Exists(Zip) Then
            File.Copy(Zip, Zip & ".bak")
            File.Delete(Zip)
        End If
        System.IO.Directory.CreateDirectory(Temp)
        File.Copy(Preview, Temp & "Preview" & Path.GetExtension(Preview))
        Dim InfoFile As String = Name & "¬" & Auth & "¬" & Desc
        CopyDirectory(Dir, Temp)
        File.WriteAllText(Temp & "info.RCT2", InfoFile)
        ZipFile.CreateFromDirectory(Temp, Zip, CompressionLevel.Optimal, False)
        System.IO.Directory.Delete(Temp, True)
        Return True
    End Function
    Public Property ZipLocation As String
        Get
            Return Zip
        End Get
        Set(value As String)
            Zip = value
        End Set
    End Property
    Private Sub CopyDirectory(ByVal sourcePath As String, ByVal destinationPath As String)
        Dim sourceDirectoryInfo As New System.IO.DirectoryInfo(sourcePath)

        ' If the destination folder don't exist then create it
        If Not System.IO.Directory.Exists(destinationPath) Then
            System.IO.Directory.CreateDirectory(destinationPath)
        End If

        Dim fileSystemInfo As System.IO.FileSystemInfo
        For Each fileSystemInfo In sourceDirectoryInfo.GetFileSystemInfos
            Dim destinationFileName As String =
                System.IO.Path.Combine(destinationPath, fileSystemInfo.Name)

            ' Now check whether its a file or a folder and take action accordingly
            If TypeOf fileSystemInfo Is System.IO.FileInfo Then
                System.IO.File.Copy(fileSystemInfo.FullName, destinationFileName, True)
            Else
                ' Recursively call the mothod to copy all the neste folders
                CopyDirectory(fileSystemInfo.FullName, destinationFileName)
            End If
        Next
    End Sub
    Public Property PreviewImage As String
        Get
            Return Preview
        End Get
        Set(value As String)
            Preview = value
        End Set
    End Property
    Public Property Author As String
        Get
            Return Auth
        End Get
        Set(value As String)
            Auth = value
        End Set
    End Property
    Public Property Directory As String
        Get
            Return Dir
        End Get
        Set(value As String)
            Dir = value
        End Set
    End Property
    Public Property ModName As String
        Get
            Return Name
        End Get
        Set(value As String)
            Name = value
        End Set
    End Property
    Public Property Description As String
        Get
            Return Desc
        End Get
        Set(value As String)
            Desc = value
        End Set
    End Property
    Public ReadOnly Property LastErrorReason As String
        Get
            Return LastError
        End Get
    End Property
End Class

Public Class UnPackMod
    Dim Dir As String = Nothing
    Dim Name As String = Nothing
    Dim Desc As String = Nothing
    Dim Auth As String = Nothing
    Dim Temp As String = Path.GetTempPath & "ModPacker\"
    Dim Themes As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\OpenRCT2\colour schemes\"
    Public Sub GetInfoFromMod(ByVal ModFilePath As String)
        Using zippedFile As ZipArchive = ZipFile.Open(ModFilePath, ZipArchiveMode.Read)
            Dim ntry As ZipArchiveEntry = zippedFile.GetEntry("info.RCT2")
            Using reader As New BinaryReader(ntry.Open())
                If Directory.Exists(Temp) = True Then
                    Directory.Delete(Temp, True)
                    Directory.CreateDirectory(Temp)
                Else
                    Directory.CreateDirectory(Temp)
                End If
                System.IO.File.WriteAllBytes(Temp & "info.txt", ReadAllBytes(reader))
            End Using
        End Using
        Dim Setting As String = File.ReadAllText(Temp & "info.txt")
        Directory.Delete(Temp, True)
        Dim Cut() = Setting.Split("¬")
        Name = Cut(0)
        Auth = Cut(1)
        Desc = Cut(2)
    End Sub
    Public Sub UnPackMod(ModFilePath As String, RCT2Dir As String)
        If Directory.Exists(Temp) Then
            Directory.Delete(Temp, True)
            Directory.CreateDirectory(Temp)
        Else
            Directory.CreateDirectory(Temp)
        End If
        If Directory.Exists(RCT2Dir) = False Then
            Directory.CreateDirectory(RCT2Dir)
        End If
        ZipFile.ExtractToDirectory(ModFilePath, Temp)
        Try
            If Directory.Exists(Temp & "ObjData") Then
                If Directory.Exists(RCT2Dir & "\ObjData") = False Then
                    Directory.CreateDirectory(RCT2Dir & "\ObjData")
                End If
                For Each File In Directory.GetFiles(Temp & "ObjData")
                    System.IO.File.Copy(File, RCT2Dir & "\ObjData\" & Path.GetFileName(File), True)
                Next
            End If
            If Directory.Exists(Temp & "Data") Then
                If Directory.Exists(RCT2Dir & "\Data") = False Then
                    Directory.CreateDirectory(RCT2Dir & "\Data")
                End If
                For Each File In Directory.GetFiles(Temp & "Data")
                    System.IO.File.Copy(File, RCT2Dir & "\Data\" & Path.GetFileName(File), True)
                Next
            End If
            If Directory.Exists(Temp & "Scenarios") Then
                If Directory.Exists(RCT2Dir & "\Scenarios") = False Then
                    Directory.CreateDirectory(RCT2Dir & "\Scenarios")
                End If
                For Each File In Directory.GetFiles(Temp & "Scenarios")
                    System.IO.File.Copy(File, RCT2Dir & "\Scenarios\" & Path.GetFileName(File), True)
                Next
            End If
            If Directory.Exists(Temp & "Tracks") Then
                If Directory.Exists(RCT2Dir & "\Tracks") = False Then
                    Directory.CreateDirectory(RCT2Dir & "\Tracks")
                End If
                For Each File In Directory.GetFiles(Temp & "Tracks")
                    System.IO.File.Copy(File, RCT2Dir & "\Tracks\" & Path.GetFileName(File), True)
                Next
            End If
            If Directory.Exists(Temp & "Saves") Then
                If Directory.Exists(RCT2Dir & "\Saves") = False Then
                    Directory.CreateDirectory(RCT2Dir & "\Saves")
                End If
                For Each File In Directory.GetFiles(Temp & "Saves")
                    System.IO.File.Copy(File, RCT2Dir & "\Saves\" & Path.GetFileName(File), True)
                Next
            End If
            If Directory.Exists(Temp & "\Themes") Then
                If Directory.Exists(Themes) = False Then
                    Directory.CreateDirectory(Themes)
                End If
                For Each File In Directory.GetFiles(Temp & "\Themes")
                    'MsgBox(File & " " & Themes & Path.GetFileName(File))
                    System.IO.File.Copy(File, Themes & Path.GetFileName(File), True)
                Next
            End If
            If File.Exists(Temp & "\license.txt") And 0 = 1 Then '0=1 because I wanted this code disabled, but not commented out.
                Dim resp = MsgBox("Open Licence File?", MsgBoxStyle.YesNo)
                If resp = MsgBoxResult.Yes Then
                    Dim notepad As New ProcessStartInfo
                    notepad.FileName = ("Notepad.exe")
                    notepad.Arguments = (Temp & "\license.txt")
                    Process.Start(notepad).WaitForExit()
                End If
            End If
        Catch ex As Exception
            MsgBox("Sorry, but it seems you have a CD based install of the game. To use this, your going to need to install your game somewhere other than Program Files.", MsgBoxStyle.Critical, "Error :( ")
        End Try

        Directory.Delete(Temp, True)
    End Sub
    Public ReadOnly Property ModName As String
        Get
            Return Name
        End Get
    End Property
    Public ReadOnly Property Author As String
        Get
            Return Auth
        End Get
    End Property
    Public ReadOnly Property Descripton As String
        Get
            Return Desc
        End Get
    End Property
    Function ReadAllBytes(reader As BinaryReader) As Byte()
        Const bufferSize As Integer = 4096
        Using ms As New MemoryStream()
            Dim buffer(bufferSize) As Byte
            Dim count As Integer
            Do
                count = reader.Read(buffer, 0, buffer.Length)
                If count > 0 Then ms.Write(buffer, 0, count)
            Loop While count <> 0

            Return ms.ToArray()
        End Using
    End Function
End Class