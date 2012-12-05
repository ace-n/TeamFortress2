Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class Dialog1

    Public Shared ActiveSearchStruct As Form1.WHSearchStruct

    Private Sub cancelClick() Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ' Load the active search structure into the textboxes
    Private Sub LoadSearchStruct() Handles MyBase.Load

        ' Levels
        Dim LString As String = ""
        If ActiveSearchStruct.Levels IsNot Nothing Then ' Null check
            For Each L As String In ActiveSearchStruct.Levels
                LString &= L & ","
            Next
            LString = LString.Remove(LString.Length - 1)
        End If

        ' Craft #s
        Dim CString As String = ""
        If ActiveSearchStruct.Crafts IsNot Nothing Then ' Null check
            For Each C As String In ActiveSearchStruct.Crafts
                CString &= C & ","
            Next
            CString = CString.Remove(CString.Length - 1)
        End If

        ' Update textboxes
        txtLevels.Text = LString
        txtCrafts.Text = CString
        txtKeyword.Text = ActiveSearchStruct.Keyword

    End Sub

    ' Update the search structure with the data from the textboxes
    Private Sub UpdateSearchStruct() Handles btnSave.Click

        ' Validate input data
        Dim EndErrorText As String = "text is incorrectly formatted. No update has been performed."
        If Not validateLevelsOrCrafts(txtLevels.Text) Then
            MsgBox("The levels " + EndErrorText)
            Exit Sub
        ElseIf Not validateLevelsOrCrafts(txtCrafts.Text) Then
            MsgBox("The crafts " + EndErrorText)
            Exit Sub
        End If

        ' Update search structure
        ActiveSearchStruct.Crafts = txtCrafts.Text.Split(",")
        ActiveSearchStruct.Levels = txtLevels.Text.Split(",")
        ActiveSearchStruct.Keyword = txtKeyword.Text

        ' Close the form
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    ' --- Input validators ---
    Private Function validateLevelsOrCrafts(ByVal Text As String) As Boolean

        Dim SSplit = Text.Split(",")
        For Each Str As String In SSplit

            If Regex.Match(Str, "(<|>|)\d+").Length <> Str.Length Then
                Return False ' Error spotted!
            End If

        Next

        ' No error spotted - return true
        Return True

    End Function

    Private Sub txtLevels_TextChanged() Handles txtLevels.TextChanged
        If validateLevelsOrCrafts(txtLevels.Text) Then
            txtLevels.BackColor = Color.White
        Else
            txtLevels.BackColor = Color.Red
        End If
    End Sub

    Private Sub txtCrafts_TextChanged() Handles txtCrafts.TextChanged
        If validateLevelsOrCrafts(txtCrafts.Text) Then
            txtCrafts.BackColor = Color.White
        Else
            txtCrafts.BackColor = Color.Red
        End If
    End Sub

End Class
