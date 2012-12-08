Imports SHDocVw
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form1

    Declare Function Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer) As Integer

    ' List of active search structures
    Public ActiveSearchStructsList As New List(Of WHSearchClass)

    ' Auto-check values
    Public LastAutoCheckTime As Integer = My.Computer.Clock.TickCount
    Public AutoCheckInterval As Integer = 0
    Public CheckIsAuto As Boolean = False
    Public LastSearchTimestamp As Date ' Used so the user knows at what time the item was found (if they were away and something was found, thus stopping the program w/a dialog box)

    ' Indicates if selected ranges have changed
    Public SelectedRangesChanged As Boolean = False

    ' Prevents concurrent search requests
    Public SearchIsBusy As Boolean = False

    ' IE Browser instance
    Public WithEvents IEObj As New InternetExplorer

    ' List of index ranges corresponding to each item set
    Public SetRanges As New List(Of Point)

    ' List of checkboxes corresponding to each item set
    Public SetCbxes As New List(Of CheckBox)

    ' Item list (IL prefix = item list)
    Public ILNames, ILwhIds As New List(Of String) ' Data from the local system
    Public ILLevels, ILCraftNums As New List(Of List(Of Integer)) ' Data from the web

    ' Name of file with item links
    Public FileName As String = "TF2 HATS.txt"

    ' Current file location
    Public MePath As String

    ' List of stored trades
    Public StoredTradeFPath As String

    ' Misc. vars
    Public DoOnlineSearch As Boolean = True
    Private Sub Loader() Handles MyBase.Load

        ' Update executable location (MePath)
        MePath = Process.GetCurrentProcess.MainModule.FileName
        MePath = MePath.Remove(MePath.LastIndexOf("\") + 1)

        ' Update stored trade filepath
        StoredTradeFPath = MePath + "storedtrades.txt"

        ' Load trades
        LoadTradesOnOpen()

        ' -- Load item data --
        Dim LPath1 As String = MePath + FileName

        ' Kudos to http://www.dreamincode.net/forums/topic/69080-desktop-directory/
        Dim LPath2 As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\" + FileName

        ' Check to make sure URL list exists
        Dim ListPath As String = ""
        If File.Exists(LPath2) Then
            ListPath = LPath2
        ElseIf File.Exists(LPath1) Then
            ListPath = LPath1
        End If

        ' If URL list can't be found, report error
        If ListPath.Length < 2 Then
            MsgBox("No TF2WH URL list found. File should be called " + FileName + " and be either on the desktop or this program's launch directory.")
            Me.Close()
        End If

        ' Create starting checkbox
        Dim newCbx As New CheckBox
        newCbx.Width = gbxItemSets.Width - 20
        newCbx.Location = New Point(10, 25)
        newCbx.Visible = True

        ' Add starting checkbox to checkbox lists
        SetCbxes.Add(newCbx)
        gbxItemSets.Controls.Add(newCbx)

        ' Selection range start/end values
        Dim RngStart As Integer = 0
        Dim RngEnd As Integer = 0

        ' Line counter
        Dim Cnt As Integer = 0

        Dim Sr As New StreamReader(ListPath)
        While Sr.Peek <> -1

            ' Get line
            Dim SLine2 As String = Sr.ReadLine ' DBG
            Dim SLine As String = SLine2.Trim
            Cnt += 1

            ' Remove any comments
            Dim Idx As Integer = SLine.IndexOf("//")
            Dim Comment As String = ""
            If Idx > 0 Then ' Remove the part of line that is a comment
                Comment = SLine.Remove(0, Idx + 2).Trim
                SLine = SLine.Remove(Idx).Trim
            ElseIf Idx = 0 Then ' Entire line is a comment

                Dim cbxObj As CheckBox = SetCbxes.Last

                ' If a checkbox has just been added to the list, assign a name to it
                If cbxObj.Text.Length = 0 Then
                    cbxObj.Text = SLine.Remove(0, 3)
                End If

                ' Add null value to lists
                ILNames.Add("")
                ILwhIds.Add("")

                Continue While
            End If

            If SLine.Length < 1 OrElse String.IsNullOrWhiteSpace(SLine) Then

                ' This line (probably) indicates the start of a new section
                If Chr(Sr.Peek) = "/" Then ' Nexr line is most likely a comment (either that or incorrectly formatted)

                    ' Add item index range to range list
                    RngEnd = Cnt
                    SetRanges.Add(New Point(RngStart, RngEnd))
                    RngStart = Cnt + 1

                    ' Add checkbox control to panel
                    newCbx = New CheckBox
                    newCbx.Visible = True
                    newCbx.Width = gbxItemSets.Width - 20
                    newCbx.Location = New Point(10, (SetCbxes.Count + 1) * 25)
                    AddHandler newCbx.CheckedChanged, AddressOf selectedRangesChgd

                    SetCbxes.Add(newCbx)
                    gbxItemSets.Controls.Add(newCbx)

                End If

                ' Add null value to lists
                ILNames.Add("")
                ILwhIds.Add("")

                Continue While
            End If

            ' Add item to lists
            ILNames.Add(Comment)
            ILwhIds.Add(SLine)

        End While

        ' Add last set range to list
        SetRanges.Add(New Point(RngStart, ILwhIds.Count - 1))

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
            SearchAgain()
        End If

    End Sub

    ' Cache update
    Private Sub UpdateCache()

        ' -- End input verification --

        pbar.Maximum = ILwhIds.Count - 1

        ' -- Query TF2WH (if required) --
        Dim ItemsQueried As Integer = 0 ' Moved outside the DoOnlineSearch if for DBG purposes
        If DoOnlineSearch Then

            SelectedRangesChanged = False

            ' Clear cached data
            ILLevels.Clear()
            ILCraftNums.Clear()

            ' Update progress bar's max value
            Dim TotalItemsChecked As Integer = 0
            For j = 0 To SetRanges.Count - 1
                If SetCbxes.Item(j).Checked Then
                    TotalItemsChecked += SetRanges.Item(j).Y - SetRanges.Item(j).X
                End If
            Next
            If TotalItemsChecked = 0 Then
                pbar.Maximum = ILwhIds.Count ' Use if no set ranges exist
            Else
                pbar.Maximum = TotalItemsChecked
            End If

            ' Start querying
            For i = 0 To ILwhIds.Count - 1

                ' Get WH ID
                Dim whId As String = ILwhIds.Item(i)

                ' Skip out of range IDs
                Dim InRange As Boolean = SetRanges.Count = 0 ' If no set ranges have been declared, the value is ALWAYS IN RANGE
                For j = 0 To SetRanges.Count - 1
                    If SetRanges.Item(j).X <= i AndAlso SetRanges.Item(j).Y >= i AndAlso SetCbxes.Item(j).Checked Then
                        InRange = True
                        Exit For
                    End If
                Next
                If Not InRange Then

                    ' Add null values (to preserve list order)
                    ILLevels.Add(New List(Of Integer))
                    ILCraftNums.Add(New List(Of Integer))

                    Continue For

                End If

                ' Progress bar (if statement is a mandatory exception handler)
                If pbar.Maximum >= ItemsQueried Then
                    pbar.Value = ItemsQueried
                End If

                ' Skip null IDs
                ItemsQueried += 1 ' This is here because the item ranges include both null and valid values
                If whId.Length < 1 Then

                    ' Add null values (to preserve list order)
                    ILLevels.Add(New List(Of Integer))
                    ILCraftNums.Add(New List(Of Integer))

                    Continue For

                End If

                ' Navigate
                IEObj.Navigate("http://www.tf2wh.com/item.php?id=" & whId & "&specific=1")
                While IEObj.ReadyState < 4
                    Sleep(60)
                End While

                ' Get HTML
                Dim HTML As String = IEObj.Document.Body.OuterHTML

                ' Get levels
                Dim RgxLevels As MatchCollection = Regex.Matches(HTML, ", Level \d+")
                Dim LstLevels As New List(Of Integer)
                For Each M As Match In RgxLevels

                    Dim Val As String = M.Value.Remove(0, 8)
                    If Not LstLevels.Contains(Val) Then
                        LstLevels.Add(Val)
                    End If

                Next
                ILLevels.Add(LstLevels)

                ' Get craft numbers
                '   NOTE: These are unique to each instance of an item, so checking for repeats is unnecessary
                Dim RgxCraftNums As MatchCollection = Regex.Matches(HTML, "#\d+, Level")
                Dim LstCrafts As New List(Of Integer)
                For Each M As Match In RgxCraftNums
                    Dim MStr As String = M.Value.Remove(0, 1)
                    LstCrafts.Add(CInt(MStr.Remove(MStr.Length - 7)))
                Next
                ILCraftNums.Add(LstCrafts)

            Next

        End If

        ' Reset pBar
        pbar.Value = 0

        ' Search the cache
        'SearchCache(txtLevels.Text.Replace(";", " ").Replace(",", " ").Split(" "), _
        '            txtCrafts.Text.Replace(";", " ").Replace(",", " ").Split(" "))

    End Sub

    ' Perform active searches
    Private Sub SearchAgain()

        ' List of results
        Dim ResultsList As New List(Of String)

        ' Perform searches
        For i As Integer = 0 To ActiveSearchStructsList.Count - 1
            Dim SearchObj As WHSearchClass = ActiveSearchStructsList.Item(i)
            ResultsList.AddRange(SearchCache(SearchObj.Levels, SearchObj.Crafts, SearchObj.Keyword))
        Next

        ' Report results
        If ResultsList.Count > 0 AndAlso
            MsgBox("Copy matching item list to clipboard? (" & ResultsList.Count & " item(s) found)", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then

            ' Output result to clipboard
            My.Computer.Clipboard.SetText(String.Join(vbLf, ResultsList))

        ElseIf Not CheckIsAuto Then

            ' Notify user that nothing was found if the search was user-initiated
            MsgBox("No matching items were found.")

        End If

    End Sub

    ' Search cache given parameters
    Public Function SearchCache(ByVal DesiredLevels As String(), ByVal DesiredCrafts As String(), Optional ByVal Keyword As String = "") As List(Of String)

        ' -- Find matching items --
        Dim OutputList As New List(Of String)

        ' Check for level/craft matches
        For i = 0 To ILLevels.Count - 1

            Dim LevelOutputStr As String = ""

            ' Skip nulls
            If ILLevels.Item(i).Count = 0 AndAlso ILCraftNums.Item(i).Count = 0 Then
                Continue For
            End If

            ' If keyword is valid, check that current hat's comment contains the keyword
            If Keyword.Length <> 0 AndAlso _
                ILNames.Item(i).IndexOf(Keyword, StringComparison.InvariantCultureIgnoreCase) = -1 Then
                Continue For
            End If

            ' Levels
            For Each DesdLvl In DesiredLevels

                ' Skip null conditions
                If DesdLvl.Length < 1 Then
                    Continue For
                End If

                For Each AvailableLevel In ILLevels.Item(i)

                    If EvalCondition(DesdLvl, AvailableLevel) Then

                        ' Current level is valid - add it to output
                        If LevelOutputStr.Length = 0 Then
                            LevelOutputStr &= "level(s) "
                        Else
                            LevelOutputStr &= ", "
                        End If
                        LevelOutputStr &= AvailableLevel

                    End If

                Next
            Next

            ' Crafts
            Dim CraftOutputStr As String = ""
            For Each DesdCraft In DesiredCrafts

                ' Skip null conditions
                If DesdCraft.Length < 1 Then
                    Continue For
                End If

                For Each AvailableCraft In ILCraftNums.Item(i)

                    If EvalCondition(DesdCraft, AvailableCraft) Then

                        ' Current craft # is valid - add it to output
                        If CraftOutputStr.Length = 0 Then
                            CraftOutputStr &= "craft number(s) "
                        Else
                            CraftOutputStr &= ", "
                        End If
                        CraftOutputStr &= AvailableCraft

                    End If

                Next
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

        ' Update last (automatic) search timestamp
        LastSearchTimestamp = My.Computer.Clock.LocalTime

        ' Reset auto-check/search is-busy flags
        CheckIsAuto = False
        SearchIsBusy = False

        ' Return results of search
        Return OutputList

    End Function

    ' Function that evaluates conditions and determines if they are true/false
    '   NOTE: This DOES NOT validate incoming conditions!
    Private Function EvalCondition(ByVal Condition As String, ByVal Number As Integer) As Boolean

        If Char.IsNumber(Condition.First) Then

            ' Equal
            Return Condition = Number.ToString

        ElseIf Condition.First = "<"c Then

            ' Less than
            Return Number < CInt(Condition.Remove(0, 1))

        Else

            ' More than
            Return Number > CInt(Condition.Remove(0, 1))

        End If

    End Function

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

    Private Sub selectedRangesChgd()
        SelectedRangesChanged = True
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
                    SearchAgain() ' Strangely enough, the backgroundWorker appears to do this in its own thread - not in the main one
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

        ' Query WH, if necessary
        If DoOnlineSearch Then
            UpdateCache()
        End If

        ' Search
        SearchAgain()

    End Sub

    'Private Sub txtCrafts_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '' Combine lines
    'Dim Lines As String() = txtCrafts.Lines
    'If Lines.Count > 1 Then
    '    Dim TotalString As String = ""
    '    If txtCrafts.Text.Contains(",") Then
    '        For Each S As String In Lines
    '            TotalString &= S
    '        Next
    '    Else
    '        For Each S As String In Lines
    '            TotalString &= S & ","
    '        Next
    '        TotalString = TotalString.Remove(TotalString.Length - 2) ' Remove last comma
    '    End If

    '    ' Update text
    '    txtCrafts.Text = TotalString

    'End If


    'End Sub

    'Private Sub btnNewSearch_Click() Handles btnNewSearch.Click

    '    ' Show new search creation dialog
    '    Dialog1.ActiveSearchStruct = New WHSearchClass ' Create new search
    '    Dim DlgResult As DialogResult = Dialog1.ShowDialog() ' Show dialog

    '    ' Add search to list of active searches, if appropriate
    '    If DlgResult = DialogResult.OK Then
    '        ActiveSearchStructsList.Add(Dialog1.ActiveSearchStruct)
    '    End If

    '    ' Update the list of items
    '    updateListOfActiveSearches()

    'End Sub

    ' Update DataGridView (with changes from the list of active searches)

    Private Sub updateDataGridView()

        ' Add new rows, if necessary
        '   NOTE: There should be (number of items + 1) rows since some functions disregard the last row (on purpose - whenever the user edits a data grid, the last row is always empty)
        If ActiveSearchStructsList.Count + 1 > dgvActiveTrades.RowCount Then
            dgvActiveTrades.Rows.Add(ActiveSearchStructsList.Count + 1 - dgvActiveTrades.RowCount)
        End If

        ' Populate existing rows
        For i = 0 To ActiveSearchStructsList.Count - 1

            ' Get active row
            Dim ActiveRow As DataGridViewRow = dgvActiveTrades.Rows.Item(i)

            ' Get active WHSearchStruct
            Dim ActiveWHSS As WHSearchClass = ActiveSearchStructsList.Item(i)

            ' Add stuff to the active row
            ActiveRow.Cells(0).Value = ActiveWHSS.Keyword
            ActiveRow.Cells(1).Value = String.Join(",", ActiveWHSS.Levels)
            ActiveRow.Cells(2).Value = String.Join(",", ActiveWHSS.Crafts)
            ActiveRow.Cells(3).Value = ActiveWHSS.OutpostID
            ActiveRow.Cells(4).Value = ActiveWHSS.Referrer

        Next

    End Sub

    ' Update list of active searches (with changes from the data grid view)
    Private Sub updateListOfActiveSearches() Handles dgvActiveTrades.RowLeave, dgvActiveTrades.RowsRemoved, dgvActiveTrades.LostFocus, dgvActiveTrades.MouseLeave

        ' Clear ActiveSearchStructsList
        ActiveSearchStructsList.Clear()

        For i As Integer = 0 To dgvActiveTrades.RowCount - 2 ' Skip the last row, because it will always be empty

            ' Update active searches list
            Dim ActiveSearchObj As New WHSearchClass
            Dim ActiveRow As DataGridViewRow = dgvActiveTrades.Rows.Item(i)

            ' Check if current row is valid - skip it if it isn't
            If Not WHSearchClass.validateLevelsOrCrafts(ActiveRow.Cells(1).EditedFormattedValue.ToString) Or Not WHSearchClass.validateLevelsOrCrafts(ActiveRow.Cells(2).EditedFormattedValue.ToString) Then

                ' Error detected
                'MsgBox("Error in levels/crafts specification in row " + (i + 1).ToString + ". That row's data was not updated.")
                dgvActiveTrades.Rows.Item(i).DefaultCellStyle.BackColor = Color.OrangeRed
                Continue For

            Else

                ' Uncolor the row
                dgvActiveTrades.Rows.Item(i).DefaultCellStyle.BackColor = Color.White

            End If

            ' Update search object
            ActiveSearchObj.Keyword = ActiveRow.Cells(0).EditedFormattedValue
            ActiveSearchObj.Levels = ActiveRow.Cells(1).EditedFormattedValue.ToString.Split(",")
            ActiveSearchObj.Crafts = ActiveRow.Cells(2).EditedFormattedValue.ToString.Split(",")
            ActiveSearchObj.OutpostID = ActiveRow.Cells(3).EditedFormattedValue.ToString
            ActiveSearchObj.Referrer = ActiveRow.Cells(4).EditedFormattedValue.ToString

            ' Add search object to active search list
            ActiveSearchStructsList.Add(ActiveSearchObj)

        Next

    End Sub

    ' Serialize trades and output them to a file
    Private Sub SaveTradesOnClose() Handles Me.FormClosing

        Dim sWriter As New StreamWriter(StoredTradeFPath)

        ' Serialize trades
        For i = 0 To ActiveSearchStructsList.Count - 1
            sWriter.WriteLine(ActiveSearchStructsList.Item(i).Serialize())
        Next

        ' Write to file
        sWriter.Flush()

    End Sub

    ' Load serialized trades from file
    '   This is called by the main starting procedure
    Private Sub LoadTradesOnOpen()

        ' Check to make sure that trade file exists
        If Not File.Exists(StoredTradeFPath) Then
            MsgBox("No stored trades were loaded because none could be found.")
            Exit Sub
        End If

        ' Load trades from file
        Dim sReader As New StreamReader(StoredTradeFPath)
        While sReader.Peek <> -1

            Dim sLine As String = sReader.ReadLine

            ' Error message
            Dim ErrorMsg As String = "An invalid trade (" + sLine + ") was found in the stored trades file. Click OK to skip it, or CANCEL to stop loading trades."

            ' Some really simple validation - stronger validation is done in the trade object constructor
            If sLine.Length > 8 AndAlso Not sLine.Contains(";") Then ' 4 separators * 2 characters per separator = 8 characters minimum (assuming line has no meaning)
                If MsgBox(ErrorMsg, MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then

                    ' An error was detected
                    '   Clear the loaded items and stop loading any more
                    ActiveSearchStructsList.Clear()
                    sReader.Close()
                    Exit Sub

                Else
                    Continue While ' Skip the item
                End If
            ElseIf sLine.Length < 9 Then ' Skip lines with 8 characters or less (including lines consisting entirely of separators)
                Continue While
            End If

            ' Enter new trade into database
            Try
                ActiveSearchStructsList.Add(New WHSearchClass(sLine))
            Catch e As ArgumentException

                If MsgBox(ErrorMsg, MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then

                    ' Clear the loaded items and stop loading any more
                    ActiveSearchStructsList.Clear()
                    sReader.Close()
                    Exit Sub

                End If

            End Try

        End While

        ' Close the StreamReader
        sReader.Close()

        ' Update the dataGridView
        updateDataGridView()

    End Sub

End Class