Imports System.Net

Public Class Form1

    Public EntrantsCnt As Integer = 0

    Private Sub GetEntrants(sender As System.Object, e As System.EventArgs) Handles btn1.Click

        ' Split up clipboard
        Dim LineList As String() = My.Computer.Clipboard.GetText.Split(vbLf)

        ' Check for numbers
        Dim ContainsTimestamp As Boolean = True
        For Each Line As String In LineList
            If Line.Contains(":") AndAlso Not Line.Contains("http://steamcommunity.com/id/") Then
                If Not Integer.TryParse(Line.Substring(0, 3).Replace(":", ""), New Integer) Then
                    ContainsTimestamp = False
                    Exit For
                End If
            End If
        Next

        ' Get entrants
        Dim Entrants As New List(Of String)
        For Each Line As String In LineList

            Dim Username As String = Line
            Dim Idx As Integer = 0

            ' Remove timestamp
            If ContainsTimestamp Then
                Idx = Line.IndexOf("-")
                If Idx > 0 Then
                    Username = Line.Remove(0, Idx + 2)
                Else
                    Continue For
                End If
            End If

            ' Remove username
            Idx = Username.IndexOf(":")
            If Idx > 0 Then
                Username = Username.Remove(Idx)
            Else
                Continue For
            End If

            ' Add username to list
            If Not txtEntrants.Text.Contains(Username & vbCrLf) And Username.Length > 0 Then
                txtEntrants.AppendText(Username & vbCrLf)
            End If
        Next

        ' Get entrants count
        EntrantsCnt = 0
        For Each Line As String In txtEntrants.Lines
            If Line.Length > 1 Then
                EntrantsCnt += 1
            End If
        Next

        ' Update label
        If EntrantsCnt > 0 Then
            lblNumQueue.Text = "Step 3: Enter a number between 1 and " & EntrantsCnt.ToString & " (including " & EntrantsCnt.ToString & "), or click the " & Chr(34) & "Get number from random.org" & Chr(34) & "button."
        Else
            lblNumQueue.Text = "Step 3: You haven't completed steps 1 and 2 yet!"
        End If

    End Sub

    Private Sub EntrantsChanged(sender As System.Object, e As System.EventArgs) Handles txtEntrants.TextChanged

        ' Get entrants count
        EntrantsCnt = 0
        For Each Line As String In txtEntrants.Lines
            If Line.Length > 1 Then
                EntrantsCnt += 1
            End If
        Next

        ' Update label
        If EntrantsCnt > 0 Then
            lblNumQueue.Text = "Step 3: Enter a number between 1 and " & EntrantsCnt.ToString & " (including " & EntrantsCnt.ToString & "), or click the " & Chr(34) & "Get number from random.org" & Chr(34) & "button."
        Else
            lblNumQueue.Text = "Step 3: You haven't completed steps 1 and 2 yet!"
        End If

    End Sub

    Private Sub txtDrawNum_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDrawNum.TextChanged

        Dim N As Integer = 0

        ' Text box color
        If Integer.TryParse(txtDrawNum.Text, N) AndAlso EntrantsCnt > 0 Then
            If N > 0 AndAlso N <= EntrantsCnt Then
                txtDrawNum.BackColor = Color.White
            Else
                txtDrawNum.BackColor = Color.Red
            End If
        Else
            txtDrawNum.BackColor = Color.Red
        End If

        ' Winner announcement
        If N > 0 AndAlso N <= EntrantsCnt Then

            ' Get winning entrant
            Dim Cnt As Integer = 0
            For i = 0 To txtEntrants.Lines.Count - 1

                If txtEntrants.Lines.GetValue(i).Length > 1 Then
                    Cnt += 1
                End If

                If Cnt = N Then
                    Cnt = i
                    Exit For
                End If

            Next

            lblWinner.Text = "Step 4: And the winner is..." & txtEntrants.Lines.GetValue(Cnt)
        Else
            lblWinner.Text = "Step 4: And the winner is...nobody yet."
        End If

    End Sub

    ' Get requested number from random.org
    Private Sub btnRandomDotOrg_Click(sender As System.Object, e As System.EventArgs) Handles btnRandomDotOrg.Click

        ' Get page HTML
        Dim WC As New WebClient
        Dim RandStr As String = WC.DownloadString("http://www.random.org/integers/?num=1&min=1&max=" & EntrantsCnt.ToString & "&col=1&base=10&format=html&rnd=new")

        ' --- Isolate random number ---

        ' Operation 1
        Dim Idx As Integer = RandStr.IndexOf("your random numbers")
        If Idx > 0 Then
            RandStr = RandStr.Remove(0, Idx + 43)
        Else
            MsgBox("Something went wrong with the random.org system.")
            Exit Sub
        End If

        ' Operation 2
        Idx = RandStr.IndexOf("</")
        If Idx > 0 Then
            RandStr = RandStr.Remove(Idx - 1)
        Else
            MsgBox("Something went wrong with the random.org system.")
            Exit Sub
        End If

        ' Return result
        Try
            txtDrawNum.Text = RandStr
        Catch
            MsgBox("Something went wrong with the random.org system.")
        End Try

    End Sub

End Class
