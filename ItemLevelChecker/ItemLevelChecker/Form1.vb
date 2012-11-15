Imports SHDocVw
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form1

    Declare Function Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer) As Integer

    ' Auto-check values
    Public LastAutoCheckTime As Integer = My.Computer.Clock.TickCount
    Public AutoCheckInterval As Integer = 0
    Public CheckIsAuto As Boolean = False

    ' Prevents concurrent search requests
    Public SearchIsBusy As Boolean = False

    ' IE Browser instance
    Public WithEvents IEObj As New InternetExplorer

    ' Item list (IL prefix = item list)
    Public ILNames, ILwhIds As New List(Of String) ' Data from the local system
    Public ILLevels, ILCraftNums As New List(Of String) ' Data from the web

    ' Misc. vars
    Public DoOnlineSearch As Boolean = True
    Private Sub Loader() Handles MyBase.Load

        ' -- Load item data --
        Dim Sr As New StreamReader("C:\Users\Ace\Desktop\TF2 HATS.txt")
        While Sr.Peek <> -1

            ' Get line
            Dim SLine As String = Sr.ReadLine.Trim

            ' Remove any comments
            Dim Idx As Integer = SLine.IndexOf("//")
            Dim Comment As String = ""
            If Idx > 0 Then ' Remove the part of line that is a comment
                Comment = SLine.Remove(0, Idx + 2).Trim
                SLine = SLine.Remove(Idx).Trim
            ElseIf Idx = 0 Then ' Entire line is a comment
                Continue While
            End If

            ' Add item to lists
            ILNames.Add(Comment)
            ILwhIds.Add(SLine)

        End While

        ' Run auto-checking reminder worker
        autoCheckWorker.RunWorkerAsync()

        ' Continue
        IEObj.Navigate("http://www.tf2wh.com/item.php?login")

        ' -- Log-in process --
        ' Handle log-in process
        IEObj.Visible = True
        If MsgBox("Please log-in to tf2wh.com. Click OK AFTER you are logged in. Click CANCEL to close the program.", MsgBoxStyle.SystemModal + MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Me.Close()
        End If

    End Sub

    Private Sub OnClosingHandler() Handles Me.FormClosing

        ' Attempt to kill the IE window - if this fails, close the form anyway
        Try
            IEObj.Quit()
        Catch
        End Try

    End Sub

    Private Sub btnSearchClick()

        ' Prevent the user and the system from making concurrent search requests
        If Not SearchIsBusy Then
            Search()
        End If

    End Sub

    ' Searches
    Private Sub Search()

        ' -- Input verification --
        ' Input verification (#1)
        If String.IsNullOrWhiteSpace(txtLevels.Text) Then
            MsgBox("Please enter the levels of the item that you are searching for. When searching for different levels, separate them with a comma.")
            Exit Sub
        End If

        ' Input verification (#2)
        Dim S As String = txtLevels.Text
        For i = 0 To 9
            S = S.Replace(CStr(i), "")
        Next
        S = S.Replace(",", "")
        If S.Length > 0 Then
            MsgBox("The level list is invalid. When searching for different levels, separate them with a comma.")
            Exit Sub
        End If

        pbar.Maximum = ILwhIds.Count - 1

        ' -- Query TF2WH (if required) --
        If DoOnlineSearch Then

            ' Clear cached data
            ILLevels.Clear()
            ILCraftNums.Clear()

            ' Start querying
            For i = 0 To ILwhIds.Count - 1

                ' Get WH ID
                Dim whId As String = ILwhIds.Item(i)

                ' Navigate
                IEObj.Navigate("http://www.tf2wh.com/item.php?id=" & whId & "&specific=1")
                While IEObj.ReadyState < 4
                    Sleep(60)
                End While

                ' Get HTML
                Dim HTML As String = IEObj.Document.Body.OuterHTML

                ' Get levels
                Dim RgxLevels As MatchCollection = Regex.Matches(HTML, ", Level \d+")
                Dim SOut As String = ";"
                For Each M As Match In RgxLevels

                    Dim Val As String = M.Value.Remove(0, 8) & ";"
                    If Not SOut.Contains(Val) Then
                        SOut &= Val
                    End If

                Next
                ILLevels.Add(SOut)

                ' Get craft numbers
                '   NOTE: These are unique, so checking for repeats is unnecessary
                SOut = ";"
                Dim RgxCraftNums As MatchCollection = Regex.Matches(HTML, "#\d+, Level")
                For Each M As Match In RgxCraftNums
                    Dim MStr As String = M.Value.Remove(0, 1)
                    SOut &= MStr.Remove(MStr.Length - 7) & ";"
                Next
                ILCraftNums.Add(SOut)

                ' TEST
                pbar.Value = i

            Next

        End If

        ' -- Find matching items --
        Dim OutputList As New List(Of String)

        ' Parse input
        Dim DesiredLevels As String() = txtLevels.Text.Replace(";", " ").Replace(",", " ").Split(" ")
        Dim DesiredCrafts As String() = txtCrafts.Text.Replace(";", " ").Replace(",", " ").Split(" ")

        ' Check for level/craft matches
        For i = 0 To ILLevels.Count - 1

            Dim LevelOutputStr As String = ""

            ' Levels
            For Each DesdLvl In DesiredLevels
                If ILLevels.Item(i).Contains(";" & DesdLvl.ToString & ";") Then

                    ' Add level to output
                    If LevelOutputStr.Length = 0 Then
                        LevelOutputStr &= "level(s) "
                    Else
                        LevelOutputStr &= ", "
                    End If
                    LevelOutputStr &= DesdLvl

                End If
            Next

            ' Crafts
            Dim CraftOutputStr As String = ""
            For Each DesdCraft In DesiredCrafts
                If ILCraftNums.Item(i).Contains(";" & DesdCraft.ToString & ";") Then

                    ' Add craft # to output
                    If CraftOutputStr.Length = 0 Then
                        CraftOutputStr &= "craft number(s) "
                    Else
                        CraftOutputStr &= ", "
                    End If
                    CraftOutputStr &= DesdCraft

                End If
            Next

            ' Final output
            If CraftOutputStr.Length <> 0 OrElse LevelOutputStr.Length <> 0 Then
                Dim FinalOutStr As String = "Item " & ILwhIds.Item(i) & " [" & ILNames.Item(i) & "] found with "

                If CraftOutputStr.Length <> 0 Then
                    FinalOutStr &= CraftOutputStr
                End If
                If LevelOutputStr.Length <> 0 Then
                    FinalOutStr &= LevelOutputStr
                End If

                ' Add to output list
                OutputList.Add(FinalOutStr)

            End If

        Next

        ' Mark search as complete
        DoOnlineSearch = False

        ' Show list to user (if not on auto-check mode)
        If OutputList.Count <> 0 Then
            If MsgBox("Copy match list to clipboard? (" & OutputList.Count & " item(s) found)", MsgBoxStyle.OkCancel + MsgBoxStyle.SystemModal) = MsgBoxResult.Ok Then

                Dim OutStr As String = ""
                For Each OS As String In OutputList
                    OutStr &= OS & vbCrLf
                Next
                My.Computer.Clipboard.SetText(OutStr)

            End If
        ElseIf Not CheckIsAuto Then
            MsgBox("No matching items were found.", MsgBoxStyle.SystemModal)
        End If

        ' Reset pBar
        pbar.Value = 0

        ' Reset auto-check/search is-busy flags
        CheckIsAuto = False
        SearchIsBusy = False

    End Sub

    ' Scans the item's page for level/craft # data (OLD)
    Private Sub Stage4()

        ' --- Levels ---

        ' Isolate level data
        Dim HTMLLevels As String = IEObj.Document.Body.InnerHTML
        HTMLLevels = HTMLLevels.Substring(Math.Max(0, HTMLLevels.IndexOf("Specific variants")))

        ' Get levels that are being searched for
        Dim LevelNums As String() = (txtLevels.Text & ",").Split(",")

        ' Search for the levels
        Dim LevelsFound As New List(Of String)
        For Each LNum As String In LevelNums
            If HTMLLevels.Contains("Level " & LNum & " ") And Not String.IsNullOrWhiteSpace(LNum) Then
                LevelsFound.Add(LNum)
            End If
        Next

        ' Report results
        If LevelsFound.Count = 0 Then
            MsgBox("No specific variants with those levels were found for the item.")
        Else
            Dim LStr As String = ""
            For Each L As String In LevelsFound
                LStr &= L & ", "
            Next

            MsgBox("Items with the following levels were found: " & LStr.Substring(0, LStr.Length - 2))
        End If

        ' --- Craft #s ---

    End Sub

    Private Sub btnRequery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequery.Click
        DoOnlineSearch = True
    End Sub

    Private Sub autoChgd() Handles cbxAutoOn.CheckedChanged
        Label3.Enabled = cbxAutoOn.Checked
        txtAutoInterval.Enabled = cbxAutoOn.Checked
    End Sub

    Private Sub hideIeChgd() Handles cbxHideIE.CheckedChanged
        IEObj.Visible = Not cbxHideIE.Checked
    End Sub

    ' Automatic checking system
    Private Sub autoCheckWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles autoCheckWorker.DoWork

        While True

            ' If auto-check is off, sleep a little and continue
            If cbxAutoOn.Checked = False OrElse AutoCheckInterval < 1 Then
                Sleep(200)
                Continue While
            End If

            ' Sleep appropriate amount of time
            Sleep(AutoCheckInterval * 60000)

            ' Perform auto-check
            If Not CheckIsAuto Then ' CheckIsAuto resets if the search completes - if it hasn't completed, CheckIsAuto is TRUE and no second search request is made
                CheckIsAuto = True
                DoOnlineSearch = True
                If Not SearchIsBusy Then ' Prevent the user and the system from making concurrent search requests
                    SearchIsBusy = True
                    Search() ' Strangely enough, the backgroundWorker appears to do this in its own thread - not in the main one
                End If
            End If

        End While

    End Sub

    Private Sub txtAutoInterval_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAutoInterval.TextChanged

        Dim Int As Integer
        If Integer.TryParse(txtAutoInterval.Text, Int) Then
            If Int > 0 Then
                AutoCheckInterval = Int
                txtAutoInterval.BackColor = Color.White
            Else
                txtAutoInterval.BackColor = Color.Red
            End If
        Else
            txtAutoInterval.BackColor = Color.Red
        End If

    End Sub

    Private Sub searchWorker_DoWork() Handles btnClick.Click
        Search()
    End Sub

End Class