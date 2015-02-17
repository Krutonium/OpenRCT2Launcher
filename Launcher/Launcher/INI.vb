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

        Reader = My.Computer.FileSystem.OpenTextFileReader(File, Encoding.UTF8)

        While Reader.EndOfStream = False 'Quit when at the end
            Dim Line As String = Reader.ReadLine()

            Line = Line.TrimStart() 'Remove whitespaces from the beginning of the line

            If Line.Length = 0 Then 'String contains only whitespaces
                Continue While
            End If

            If Line(0) = "[" Then 'Line is a section
                If Line.IndexOfAny(New Char() {" ", "]"}, 1) = -1 Or (Line.IndexOfAny(New Char() {"#", "["}, 1) <> -1 And Line.IndexOfAny(New Char() {"#", "["}, 1) < Line.IndexOfAny(New Char() {" ", "]"}, 1)) Then
                    Continue While
                Else
                    Sections.Add(New INISection(Line.Substring(1, Line.IndexOfAny(New Char() {" ", "]"}, 1) - 1)))
                End If
            ElseIf Sections.Count <> 0 Then
                If Not Line.Contains("=") Or (Line.IndexOfAny("#") <> -1 And Line.IndexOfAny("#") < Line.IndexOfAny(New Char() {" ", "="})) Then
                    Continue While
                Else
                    Dim Key As String = Line.Substring(0, Line.IndexOfAny(New Char() {" ", "="}))
                    Dim Value As String = Line.Substring(Line.IndexOf("=") + 1).TrimStart()

                    If Value.Length = 0 Then
                        Continue While
                    End If

                    If Value(0) = Chr(34) Then 'String starts with quotation marks
                        Value = Value.Substring(1, Value.Length - 2)
                    ElseIf Value.IndexOfAny(New Char() {" ", "#"}) <> -1 Then
                        Value = Value.Substring(0, Value.IndexOfAny(New Char() {" ", "#"}))
                    End If

                    Sections(Sections.Count - 1).Keys.Add(Key)
                    Sections(Sections.Count - 1).Values.Add(Value)
                End If
            End If
        End While

        Reader.Close() 'I don't think I have to do this but I think it's safer
    End Sub

    Public Sub Save(File As String)
        Dim Writer As StreamWriter

        Writer = My.Computer.FileSystem.OpenTextFileWriter(File, False, Encoding.UTF8)

        For Each Section In Sections
            Writer.WriteLine("[" + Section.Name + "]")

            For Index = 0 To Section.Keys.Count - 1
                If Section.Values(Index).Contains(" ") Or Section.Values(Index).Contains("#") Or Section.Values(Index).Length = 0 Then
                    Writer.WriteLine(Section.Keys(Index) + " = " + Chr(34) + Section.Values(Index) + Chr(34))
                Else
                    Writer.WriteLine(Section.Keys(Index) + " = " + Section.Values(Index))
                End If
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