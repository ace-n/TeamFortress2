Imports SHDocVw
Imports System.IO

Public Class Form1

    ' IE Browser instance
    Public WithEvents IEObj As New InternetExplorer

    ' Misc. vars
    Dim LoggedIn As Boolean = False
    Dim ReadyToSearch As Boolean = False
    Dim AtStage3 As Boolean = False

    Private Sub Stage1(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' -- Log-in process --
        ' Handle log-in process
        IEObj.Visible = True
        If MsgBox("Please log-in to tf2wh.com. Click OK AFTER you are logged in. Click CANCEL to close the program.", MsgBoxStyle.SystemModal + MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
            Me.Close()
        End If

        ' Continue
        IEObj.Navigate("http://www.tf2wh.com/item.php?login")
        LoggedIn = True

    End Sub

    Private Sub OnClosingHandler() Handles Me.FormClosing
        IEObj.Quit()
    End Sub

    ' This connects all the stages together
    Private Sub LoggedInEvent() Handles IEObj.DocumentComplete
        If LoggedIn And Not ReadyToSearch Then
            If IEObj.LocationURL.StartsWith("http://www.tf2wh.com") And Not IEObj.LocationURL.Contains("login") Then
                ReadyToSearch = True

                ' Hide IE browser
                IEObj.Visible = False

            End If
        ElseIf ReadyToSearch And Not AtStage3 Then
            Try
                Stage3() ' Trigger stage 3
                AtStage3 = True
            Catch
                AtStage3 = False
                MsgBox("The search operation failed due to a programming error (Stage 3 - Launch)")
            End Try
        Else
            Stage4()
        End If
    End Sub

    ' Loads the search page
    Private Sub Stage2(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        ' Input verification (#1)
        If String.IsNullOrWhiteSpace(txtLevels.Text) Then
            MsgBox("Please enter the levels of the item that you are searching for. When searching for different levels, separate them with a comma.")
        End If

        ' Input verification (#2)
        If String.IsNullOrWhiteSpace(txtItems.Text) Then
            MsgBox("Please enter the name of the item that you are searching for.")
        End If

        ' Input verification (#3)
        Dim S As String = txtLevels.Text
        For i = 0 To 9
            S = S.Replace(CStr(i), "")
        Next
        S = S.Replace(",", "")
        If S.Length > 0 Then
            MsgBox("The level list is invalid. When searching for different levels, separate them with a comma.")
        End If

        ' Go to search page
        Try
            IEObj.Navigate("http://www.tf2wh.com/items.php?search=" & txtItems.Text.Replace(" ", "+"))
        Catch
            MsgBox("The search operation failed due to an internet error.")
        End Try

    End Sub

    ' Scans the search page / Loads the individual item's page
    Private Sub Stage3()

        ' Check to make sure there is at least 1 search result
        If IEObj.Document.Body.InnerHTML.Contains("No Items could be found") Then
            MsgBox("No items with the name " & Chr(34) & txtItems.Text & Chr(34) & " were found.")
            Exit Sub
        End If

        Dim S As String = "item.php?id="

        ' Warn the user if there are multiple results
        Dim HTML As String = IEObj.Document.Body.InnerHTML
        HTML = HTML.Substring(Math.Max(0, HTML.IndexOf("Search results")))

        If HTML.Length - HTML.Replace(S, "").Length > 12 Then
            MsgBox("Multiple matching items were found. The topmost one will be chosen.")
        End If

        ' Click on the first result
        Dim Idx As Integer = HTML.IndexOf(S)
        Dim URL As String = HTML.Substring(Idx, HTML.IndexOf(Chr(34), Idx) - Idx)

        ' Navigate to page / Complete item search
        Try
            IEObj.Navigate("http://www.tf2wh.com/" & URL & "&specific=1")
            AtStage3 = False
        Catch
            MsgBox("The search operation failed due to an internet error. (Stage 4 - Launch)")
        End Try

    End Sub

    ' Scans the item's page for level/craft # data
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

End Class

' Class for holding data about a given item
Public Class TF2Item

    ' Property value holders
    Public SName As String

    ' Properties
    Public ReadOnly Property Name As String
        Get
            Return SName
        End Get
    End Property

    ' Item creator
    Public Sub New(ByVal Name As String, ByVal LvlList As List(Of String), ByVal CraftNumList As List(Of String))

    End Sub



End Class