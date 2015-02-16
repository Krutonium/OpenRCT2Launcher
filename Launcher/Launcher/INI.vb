Imports System.IO
Imports System.Text
Imports System.Collections.Generic

Public Class INISection
    Public Name As String
    Public Keys As New List(Of String)
    Public Values As New List(Of String)

    Public Sub New(Name As String)
        Me.Name = Name
    End Sub
End Class

Public Class INI
    Dim Sections As New List(Of INISection)

    Public Sub Load(File As String)
        Dim Reader As StreamReader

        Reader = My.Computer.FileSystem.OpenTextFileReader(File, Encoding.ASCII)

        While Reader.EndOfStream = False 'Quit when at the end
            Dim Line As String = Reader.ReadLine()

            If Line.Length = 0 Or Line.Trim(" ").Length = 0 Then 'If line has a length of 0 or only consits of whitespaces, get next line
                Continue While
            End If

            If Line.Trim(" ")(0) = "#" Then 'Go to next line when the line represents a comment (first non whitespace character is a number sign)
                Continue While
            End If

            If Line.Contains("[") And Line.Contains("]") Then 'Two square brackets with text in between represent a section
                Sections.Add(New INISection(Line.Substring(Line.IndexOf("[") + 1, Line.IndexOf("]") - Line.IndexOf("[") - 1)))
            ElseIf Line.Contains("=") Then 'A equals sign represents a key and a value
                Sections(Sections.Count - 1).Keys.Add(Line.Substring(0, Line.IndexOf("=")).Trim(" "))
                Sections(Sections.Count - 1).Values.Add(Line.Substring(Line.IndexOf("=") + 1).Trim(" "))
            End If
        End While

        Reader.Close() 'I don't think I have to do this but I think it's safer
    End Sub

    Public Sub Save(File As String)
        Dim Writer As StreamWriter

        Writer = My.Computer.FileSystem.OpenTextFileWriter(File, False, Encoding.ASCII)

        For Each Section In Sections
            Writer.WriteLine("[" + Section.Name + "]")

            For Index = 0 To Section.Keys.Count - 1
                Writer.WriteLine(Section.Keys(Index) + " = " + Section.Values(Index))
            Next
        Next

        Writer.Close()
    End Sub

    Public Function FindValue(Name As String, Key As String) As String
        For Each Section In Sections
            If Section.Name = Name Then
                Dim Index As Integer = Section.Keys.IndexOf(Key)

                If Index <> -1 Then
                    Return Section.Values(Index)
                End If
            End If
        Next

        Return Nothing
    End Function

    Public Sub SetValue(Name As String, Key As String, Value As String)
        'Check if section exists
        For Each Section In Sections
            If Section.Name = Name Then
                'Check if key exists
                For Index = 0 To Section.Keys.Count - 1
                    If Section.Keys(Index) = Key Then
                        Section.Values(Index) = Value
                        Return
                    End If
                Next

                Section.Keys.Add(Key)
                Section.Values.Add(Value)
                Return
            End If
        Next

        Sections.Add(New INISection(Name))
        Sections(Sections.Count - 1).Keys.Add(Key)
        Sections(Sections.Count - 1).Values.Add(Value)
    End Sub

    Public Sub Clear()
        Sections.Clear()
    End Sub
End Class