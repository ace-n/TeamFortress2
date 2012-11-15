Public Class FormCraftableListFormatter

    Private Sub btnFormat_Click(sender As System.Object, e As System.EventArgs) Handles btnFormat.Click

        ' Format text
        txtBox.Lines = FormatRawData(txtBox.Lines)

        ' Reminder
        MsgBox("Items file is located at " + Form1.ItemListPath)

    End Sub

    Private Function FormatRawData(ByVal RawData As String()) As String()

        ' DATA from HERE: http://www.tf2crafting.info/blueprints/

        ' --- PART 1: Input processing, round 1 ---
        Dim LinesList As New List(Of String)
        Dim IsInResultsStage As Boolean = False

        For i = 0 To RawData.Count - 1

            ' Get current line
            Dim Line As String = RawData.GetValue(i)

            ' Exclusion conditions
            If String.IsNullOrWhiteSpace(Line) Or Line.Contains("+") Or Line.Contains("=") Then
                Continue For
            End If

            ' Get next line if one exists
            Dim NextLine As String = ""
            If i <> RawData.Count - 1 Then
                NextLine = RawData.GetValue(i + 1)
            End If


            ' Get third line if one exists
            Dim ThirdLine As String = ""
            If i < RawData.Count - 2 Then
                ThirdLine = RawData.GetValue(i + 2)
            End If

            ' Check for numbers (auto-repetition)
            Dim Skip As Boolean = False
            For j = 2 To 10
                If Line = CStr(j) & "x" Then

                    Dim Str As String = ""
                    For k = 0 To j - 1
                        Str &= NextLine & ","
                    Next

                    ' Add line
                    LinesList.Add(Str)
                    i += 1
                    Skip = True
                    Exit For

                End If
            Next

            ' Add line
            If Not Skip Then
                If NextLine.Contains("+") Then
                    LinesList.Add(Line + ",")
                    i += 1
                ElseIf NextLine.Contains("=") Then
                    IsInResultsStage = True
                    LinesList.Add(Line + ";")
                    i += 1
                ElseIf Line.Contains("Fabricate") Then
                    IsInResultsStage = False
                    LinesList.Add("")
                ElseIf IsInResultsStage And Not NextLine.Contains("Fabricate") Then
                    LinesList.Add(Line + ",")
                Else
                    LinesList.Add(Line)
                End If
            End If

        Next

        ' --- PART 2: Grouping items together appropriately ---
        Dim LinesList2 As New List(Of String)
        Dim CurLine As String = ""
        For i = 0 To LinesList.Count - 1

            If String.IsNullOrWhiteSpace(LinesList.Item(i)) Then
                LinesList2.Add(CurLine)
                CurLine = ""
            Else
                CurLine &= LinesList.Item(i)
            End If

        Next

        ' Update textbox
        Return LinesList2.ToArray

    End Function

End Class