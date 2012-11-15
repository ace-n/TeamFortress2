Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form1

    ' Formatting guide to items in item list
    ' Item 1,Item 1 (repeat),Item 1 (repeat),Item 2,Item 3,(Item 4 Option 1,Item 4 Option 2),Item 5;Possible result 1,Possible result 2, Possible Result 3...
    '   NO SPACES AFTER COMMAS!

    Declare Function Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer) As Integer

    Dim WC As New WebClient
    Public ItemListPath As String = "C:\Users\Aessa\Desktop\tf2trades.txt"

    Dim ItemNameList As New List(Of String)
    Dim ItemPriceList As Integer()

    Public Function Average(Numbers As List(Of Integer))
        Dim A As Double = 0
        For Each N As Integer In Numbers
            A += N
        Next
        Return A / Numbers.Count
    End Function

    Private Sub btn_Click(sender As System.Object, e As System.EventArgs) Handles btnQueryPrices.Click

        ' --- Get items list ---

        ' Input verification
        If String.IsNullOrWhiteSpace(Dir(ItemListPath)) Then
            MsgBox("ERROR: File path of item list points to a non-existent file!")
            Exit Sub
        End If

        ' Clear current items listbox
        lbxItems.Items.Clear()
        lbxPProfit.Items.Clear()
        lbxPSell.Items.Clear()
        lbxPSupply.Items.Clear()

        ' Get/parse text
        Dim Rdr As New StreamReader(ItemListPath)
        While Rdr.Peek <> -1

            ' Get current line
            Dim ReadLine As String = ""
            ReadLine = Rdr.ReadLine()

            ' Skip line if null
            If ReadLine.Length < 6 Then
                Continue While
            End If

            ' -- Update items listbox --
            Dim ILB_ItemsLine As String = ReadLine

            ' Check for multiple components
            Dim ILB_Components As String() = ReadLine.Substring(0, ReadLine.IndexOf(";")).Split(",")
            For Each Component As String In ILB_Components

                Dim CmpntCnt As Integer = 0

                ' Count/remove repetitions
                Dim CIdx As Integer = ILB_ItemsLine.IndexOf(Component)
                While CIdx <> -1

                    If CmpntCnt > 0 Then
                        ILB_ItemsLine = ILB_ItemsLine.Remove(CIdx, Component.Length)
                        CIdx -= Component.Length + 1 ' Since the repeat was removed, the later anti-repeat offset is cancelled here
                    End If

                    ' Update values
                    CIdx = ILB_ItemsLine.IndexOf(Component, CIdx + Component.Length - 1)
                    CmpntCnt += 1

                End While

                ' Place repetition indicator in front of text (in proper place)
                If CmpntCnt > 1 Then
                    ILB_ItemsLine = ILB_ItemsLine.Replace(Component, CStr(CmpntCnt) & "* " & Component)
                End If

                ' Maintain item names list
                If CmpntCnt = 1 Then
                    If Not ItemNameList.Contains(Component.ToLower) Then
                        ItemNameList.Add(Component.ToLower)
                    End If
                End If

            Next

            ' Add final product to the list of items if necessary
            Dim Component2 As String = ReadLine.Substring(ReadLine.IndexOf(";") + 1).ToLower
            If Not ItemNameList.Contains(Component2) Then
                ItemNameList.Add(Component2)
            End If

            ' Add finalized line to items listbox
            ILB_ItemsLine = ILB_ItemsLine.Replace(";", " → ").Replace(",,", ",").Replace(",,", ",").Replace(",,", ",").Replace(",", " + ")
            lbxItems.Items.Add(ILB_ItemsLine)

        End While

        ' Query per-item prices
        ItemPriceList = TF2WH.QueryPriceMultiple(ItemNameList.ToArray, WC)

        MsgBox("Querying stage 1 of 3 (General query) complete.")

        ' --- Create supply price list --- (WIP!)
        For i = 0 To ItemNameList.Count - 1

            ' Get current item price
            Dim ItemPriceStr As String = ItemPriceList.GetValue(i)

            ' Check to make sure price is valid
            If CInt(ItemPriceStr) < 1 Then

                ' Price isn't valid
                ItemPriceStr = "<<NONE>>"

            End If

            ' Replace
            For j = 0 To lbxItems.Items.Count - 1

                Dim SupplyPriceStr As String
                If i <> 0 Then
                    SupplyPriceStr = lbxPSupply.Items.Item(j)
                Else
                    SupplyPriceStr = lbxItems.Items.Item(j)
                End If

                Dim Part2 As String = SupplyPriceStr.Substring(SupplyPriceStr.IndexOf("→") - 1)
                SupplyPriceStr = SupplyPriceStr.Substring(0, SupplyPriceStr.IndexOf("→") - 1).ToLower
                SupplyPriceStr = SupplyPriceStr.Replace(ItemNameList.Item(i), ItemPriceStr)

                ' Update listboxes
                If i <> 0 Then
                    lbxPSupply.Items.Item(j) = SupplyPriceStr & Part2
                Else
                    lbxPSupply.Items.Add(SupplyPriceStr & Part2)
                End If

            Next

        Next

        ' Final calculation
        For i = 0 To lbxPSupply.Items.Count - 1

            Dim SupplyStr As String = lbxPSupply.Items.Item(i)
            SupplyStr = SupplyStr.Substring(0, SupplyStr.IndexOf("→") - 1).Replace(" ", "")

            If SupplyStr.Contains("<<none>>") Then
                SupplyStr = "N/A"
            Else
                Try
                    SupplyStr = RegexAlgebra.RegexFunctionEvaluate(SupplyStr)
                Catch
                End Try
            End If

            lbxPSupply.Items.Item(i) = SupplyStr

        Next

        MsgBox("Querying stage 2 of 3 (Missing items query) complete.")

        ' --- Create result price list ---
        For i = 0 To lbxItems.Items.Count - 1

            Dim Result As String = lbxItems.Items.Item(i)
            Result = Result.Substring(Result.IndexOf("→ ") + 2)
            lbxPSell.Items.Add(CInt(ItemPriceList.GetValue(ItemNameList.IndexOf(Result.ToLower))))

        Next

        ' --- Some formatting ---

        ' Update N/A status
        For i = 0 To lbxItems.Items.Count - 1

            Dim lbxStr As String = lbxPSell.Items.Item(i) & lbxPSupply.Items.Item(i)
            If lbxStr.Contains("-1") Or lbxStr.Contains("<<none>>") Then

                ' Update listboxes
                lbxPSell.Items.Item(i) = "N/A"
                lbxPSupply.Items.Item(i) = "N/A"

            End If

        Next

        ' --- Create profit/loss list ---
        For i = 0 To lbxItems.Items.Count - 1

            ' Handle N/A items
            If lbxPSupply.Items.Item(i) = "N/A" Then
                lbxPProfit.Items.Add("N/A")
                Continue For
            End If

            ' Calculate profit/loss
            Dim ProfitStr As String = CStr(CInt(lbxPSell.Items.Item(i)) - CInt(lbxPSupply.Items.Item(i)))
            If CStr(ProfitStr.First) <> "-" Then
                ProfitStr = "+" & ProfitStr
            End If

            ' Add to list
            lbxPProfit.Items.Add(ProfitStr)

        Next

        MsgBox("Querying stage 3 of 3 (Price calculations) complete.")

    End Sub

    ' Auto-scrolls to the selected item in all lists
    Public FreezeLists As Boolean = False
    Private Sub UpdateListSelection(Idx As Integer)

        FreezeLists = True

        lbxItems.SelectedIndex = lbxItems.Items.Count - 1
        lbxItems.SelectedIndex = Idx

        lbxPSell.SelectedIndex = lbxPSell.Items.Count - 1
        lbxPSell.SelectedIndex = Idx

        lbxPSupply.SelectedIndex = lbxPSell.Items.Count - 1
        lbxPSupply.SelectedIndex = lbxItems.SelectedIndex

        lbxPProfit.SelectedIndex = lbxPSell.Items.Count - 1
        lbxPProfit.SelectedIndex = lbxItems.SelectedIndex

        FreezeLists = False

    End Sub

#Region "Scrolling updaters"
    Private Sub SelectUpdate1(sender As System.Object, e As System.EventArgs) Handles lbxItems.SelectedIndexChanged

        If Not FreezeLists Then
            UpdateListSelection(lbxItems.SelectedIndex)
        End If

    End Sub

    Private Sub SelectUpdate2(sender As System.Object, e As System.EventArgs) Handles lbxPSupply.SelectedIndexChanged

        If Not FreezeLists Then
            UpdateListSelection(lbxPSupply.SelectedIndex)
        End If

    End Sub

    Private Sub SelectUpdate3(sender As System.Object, e As System.EventArgs) Handles lbxPSell.SelectedIndexChanged

        If Not FreezeLists Then
            UpdateListSelection(lbxPSell.SelectedIndex)
        End If

    End Sub

    Private Sub SelectUpdate4(sender As System.Object, e As System.EventArgs) Handles lbxPProfit.SelectedIndexChanged

        If Not FreezeLists Then
            UpdateListSelection(lbxPProfit.SelectedIndex)
        End If

    End Sub
#End Region

    Private Sub btnUpdateCraftableList_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateCraftableList.Click
        FormCraftableListFormatter.Visible = Not FormCraftableListFormatter.Visible
    End Sub
End Class

Public Class RegexAlgebra

    Shared Function RegexFunctionEvaluate(ByVal ExprStrMasterIn As String)

        Dim RadDegConver As Integer = 1

        ' Make sure the number of parenthesis is appropriate
        Dim StrA As String = ExprStrMasterIn.Replace("(", "").Replace("[", "")
        Dim StrB As String = ExprStrMasterIn.Replace(")", "").Replace("]", "")
        If StrA.Length <> StrB.Length Then
            MsgBox("Mismatched parenthesis/brackets")
            'Throw New Exception("FunctionEvaluate ERROR: The parentheses do not line up properly. Function: " & ExprStrMasterIn)
            Return 0
        End If

        ' Variables
        Dim ExprStrMaster As String = ExprStrMasterIn

        ' Remove any commas
        If ExprStrMaster.Contains(",") Then
            ExprStrMaster = ExprStrMaster.LastIndexOf(",")
        End If

        ' Regex
        Dim NumberRegex As New Regex("(-|_|)([0-9]|:v:)+")
        Dim SubRegex As New Regex("[0-9]+-(_|[0-9])+")
        Dim RegexParenConstant As New Regex(":y:(_|[0-9]|:v:)+:z:")
        Dim RegexParen As New Regex("(:y:)(:A:|:S:|:M:|:D:|:E:|_|-|[0-9]|:v:)*(:z:)")
        Dim RegexOperator As New Regex("(:A:|:S:|:M:|:D:|:E:|:y:|:z:|:w:|:x:)")

        ' If there is a constant that is enclosed by parenthesis, remove the parenthesis
        ExprStrMaster = ExprStrMaster.Replace("(", ":y:").Replace(")", ":z:").Replace(".", ":v:")

        ' ---------- Negative formatting ----------

        ' :S: a negative = :A:
        ExprStrMaster = ExprStrMaster.Replace("--", ":A:")

        ' For - (:S: and negative)
        Dim SubMatch As Match = SubRegex.Match(ExprStrMaster)

        ' --------- Mass formatting ---------
        ' Note: perhaps make a multiple parameter replacement system that does one pass and replaces everything
        ' HINT: Conduct all possible preformat functions before sending function (in a batch manner)
        ExprStrMaster = ExprStrMaster.Replace("pi", CStr(Math.PI)).Replace(" ", "").Replace("+", ":A:").Replace("*", ":M:").Replace("/", ":D:").Replace("^", ":E:")

        ' For functions
        ExprStrMaster = ExprStrMaster.Replace("[", ":w:").Replace("]", ":x:")


        ' Loop through parenthesis
        Dim PastExprStrMaster As String = ""
        While NumberRegex.Match(ExprStrMaster).Length <> ExprStrMaster.Length

            ' If past expression equals current one, there is an error


            Dim MatchParen As Match = RegexParen.Match(ExprStrMaster)

            ' Operate on parenthesis-enclosed string
            Dim ExprStr As String = ExprStrMaster
            If MatchParen.Success() Then

                ExprStr = RegexParen.Match(ExprStrMaster).Value
                ExprStr = ExprStr.Substring(3, ExprStr.Length - 6)

            End If

            ' Unaltered copy of ExprStr
            Dim ExprStrCopy As String = ExprStr

            ' If ExprStr is a constant, drop the surrounding parenthesis and try again
            If NumberRegex.Match(ExprStr).Length = ExprStr.Length And MatchParen.Success Then

                ExprStrMaster = ExprStrMaster.Replace(MatchParen.Value, ExprStr)
                Continue While

            End If

            ' Step 0: Organize negatives
            ' Replace all subtraction -'s with ":S:"
            While SubRegex.Match(ExprStr).Success

                SubMatch = SubRegex.Match(ExprStr)
                ExprStr = ExprStr.Replace(SubMatch.Value, SubMatch.Value.Replace("-", ":S:"))

            End While

            ExprStr = ExprStr.Replace("--", ":A:")
            ExprStr = ExprStr.Replace("-", "_")
            ExprStr = ExprStr.Replace(".", ":v:")

            ' If the function is purely a number, exit the solving loop
            If NumberRegex.Match(ExprStrMaster).Length = ExprStrMaster.Length Then
                Continue While
            End If

            ' Main loop
            While True

                ' If the function isn't fully solvable, throw an exception (to say that there was a problem with the function)
                'If PastExprStrMaster = ExprStr Then
                '    Throw New Exception("FunctionEvaluate ERROR: Improper function entered; Function: " & ExprStrMasterIn & ", Solution: " & ExprStrMaster)
                '    Return 0
                'End If

                ' Basic formatting - after all, "--" = "+"
                ExprStr = ExprStr.Replace("--", ":A:")
                ExprStr = ExprStr.Replace(".", ":v:")

                ' Uses PEMDAS

                ' Step 1: Define Regex systems
                Dim AddRegex As New Regex("(-|_|[0-9]|:v:)+:A:(_|[0-9]|:v:)+")
                Dim MulRegex As New Regex("(-|_|[0-9]|:v:)+:M:(_|[0-9]|:v:)+")
                Dim DivRegex As New Regex("(-|_|[0-9]|:v:)+:D:(_|[0-9]|:v:)+")
                Dim ExpRegex As New Regex("(-|_|[0-9]|:v:)+:E:(_|[0-9]|:v:)+")
                Dim SubNumRegex As New Regex("(-|_|[0-9]|:v:)+:S:(_|[0-9]|:v:)+")

                Dim VecLenRegex As New Regex("veclen:w:(_|[0-9]|:v:)+,(_|[0-9]|:v:)+:x:")
                Dim ClampRegex As New Regex("clamp:w:(_|[0-9]|:v:)+,(_|[0-9]|:v:)+,(_|[0-9]|:v:)+:x:")

                ' Step 2: Define Regex matches
                Dim AddMatch As Match = AddRegex.Match(ExprStr)
                SubMatch = SubNumRegex.Match(ExprStr)
                Dim MulMatch As Match = MulRegex.Match(ExprStr)
                Dim DivMatch As Match = DivRegex.Match(ExprStr)
                Dim ExpMatch As Match = ExpRegex.Match(ExprStr)

                Dim VecLenMatch As Match = VecLenRegex.Match(ExprStr)
                Dim ClampMatch As Match = ClampRegex.Match(ExprStr)

                ' Step 3: Functions
                If VecLenMatch.Success Then

                    ' Get X
                    Dim Base As String = VecLenMatch.Value.Substring(3)
                    Dim NumX As String = NumberRegex.Match(Base).Value

                    ' Get Y
                    Dim NumY As String = NumberRegex.Match(Base, NumX.Length + 1).Value

                    ' Calculate vector length
                    Dim Result As Double = Math.Sqrt(CDbl(NumX) ^ 2 + CDbl(NumY) ^ 2)

                    ' Replace data in string
                    ExprStr = ExprStr.Replace(VecLenMatch.Value, Result)

                    ' Continue
                    ExprStr = ExprStr.Replace(".", ":v:")
                    PastExprStrMaster = ExprStrMaster
                    Continue While

                End If

                If ClampMatch.Success Then

                    ' TEST 
                    Dim Base As String = ClampMatch.Value.Substring(9)

                    ' Get Num
                    Dim Num As String = NumberRegex.Match(Base).Value.Replace(":v:", ".").Replace("_", "-")

                    ' Get Min
                    Dim Min As String = NumberRegex.Match(Base, Num.Length + 1).Value.Replace(":v:", ".").Replace("_", "-")

                    ' Get Max
                    Dim Max As String = NumberRegex.Match(Base, Num.Length + Min.Length + 2).Value.Replace(":v:", ".").Replace("_", "-")

                    ' Make sure min is smaller than max
                    If CDbl(Min) > CDbl(Max) Then
                        Throw New ArithmeticException("FunctionEvaluate ERROR: Clamping function's MINIMUM value is more than its MAXIMUM; Function: " & ExprStrMasterIn & ", Solution: " & ExprStrMaster)
                        Return 0
                    End If

                    ' Calculate result
                    Dim ResultNum As Double = Num
                    If ResultNum > Max Then
                        ResultNum = Max
                    ElseIf ResultNum < Min Then
                        ResultNum = Min
                    End If

                    ' Replace string data
                    ExprStr = ExprStr.Replace(ClampMatch.Value, ResultNum)
                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    ' Continue
                    ExprStr = ExprStr.Replace(".", ":v:")
                    PastExprStrMaster = ExprStrMaster
                    Continue While


                End If

                ' Step 4: Trig functions
                Dim SinRegex As New Regex("sin" & ":w:" & "(-|_|)([0-9]|:v:)+" & ":x:")
                Dim CosRegex As New Regex("cos" & ":w:" & "(-|_|)([0-9]|:v:)+" & ":x:")
                Dim TanRegex As New Regex("tan" & ":w:" & "(-|_|)([0-9]|:v:)+" & ":x:")

                Dim SinMatch As Match = SinRegex.Match(ExprStr)
                Dim CosMatch As Match = CosRegex.Match(ExprStr)
                Dim TanMatch As Match = TanRegex.Match(ExprStr)

                Dim AsinRegex As New Regex("asin" & ":w:" & "(-|_|)([0-9]|:v:)+" & ":x:")
                Dim AcosRegex As New Regex("acos" & ":w:" & "(-|_|)([0-9]|:v:)+" & ":x:")
                Dim AtanRegex As New Regex("atan" & ":w:" & "(-|_|)([0-9]|:v:)+" & ":x:")

                Dim AsinMatch As Match = AsinRegex.Match(ExprStr)
                Dim AcosMatch As Match = AcosRegex.Match(ExprStr)
                Dim AtanMatch As Match = AtanRegex.Match(ExprStr)

                If AsinMatch.Success Then

                    ' Get number
                    Dim Num As Double = NumberRegex.Match(AsinMatch.Value).Value.Replace("_", "-").Replace(":v:", ".")

                    ExprStr = ExprStr.Replace(AsinMatch.Value, CStr(Math.Asin(Num * RadDegConver)).Replace("_", "-").Replace(":v:", "."))
                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    ' Continue
                    Continue While

                End If

                If AcosMatch.Success Then

                    ' Get number
                    Dim Num As Double = NumberRegex.Match(AcosMatch.Value).Value.Replace("_", "-").Replace(":v:", ".")

                    ExprStr = ExprStr.Replace(AcosMatch.Value, CStr(Math.Cos(Num * RadDegConver)).Replace("_", "-").Replace(":v:", "."))
                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    ' Continue
                    Continue While

                End If

                If AtanMatch.Success Then

                    ' Get number
                    Dim Num As Double = NumberRegex.Match(AtanMatch.Value).Value.Replace("_", "-").Replace(":v:", ".")

                    ExprStr = ExprStr.Replace(AtanMatch.Value, CStr(Math.Tan(Num * RadDegConver)).Replace("_", "-").Replace(":v:", "."))
                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    ' Continue
                    Continue While

                End If

                If SinMatch.Success Then

                    ' Get number
                    Dim Num As Double = NumberRegex.Match(SinMatch.Value).Value.Replace("_", "-").Replace(":v:", ".")

                    ExprStr = ExprStr.Replace(SinMatch.Value, CStr(Math.Sin(Num * RadDegConver)).Replace("_", "-").Replace(":v:", "."))
                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    ' Continue
                    Continue While

                End If

                If CosMatch.Success Then

                    ' Get number
                    Dim Num As Double = NumberRegex.Match(CosMatch.Value).Value.Replace("_", "-").Replace(":v:", ".")

                    ExprStr = ExprStr.Replace(CosMatch.Value, CStr(Math.Cos(Num * RadDegConver)).Replace("_", "-").Replace(":v:", "."))
                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    ' Continue
                    Continue While

                End If

                If TanMatch.Success Then

                    ' Get number
                    Dim Num As Double = NumberRegex.Match(TanMatch.Value).Value.Replace("_", "-").Replace(":v:", ".")

                    ExprStr = ExprStr.Replace(TanMatch.Value, CStr(Math.Tan(Num * RadDegConver)).Replace("_", "-").Replace(":v:", "."))
                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    ' Continue
                    Continue While

                End If

                ' Step 5: :E:s
                If ExpMatch.Success Then

                    ' Get A number
                    Dim NumA As String = NumberRegex.Match(ExpMatch.Value).Value
                    NumA = NumA.Replace(":v:", ".").Replace("_", "-")

                    ' Get B number
                    Dim NumB As String = NumberRegex.Match(ExpMatch.Value, NumA.Length + 2).Value
                    NumB = NumB.Replace(":v:", ".").Replace("_", "-")

                    ' Conduct operation
                    Dim Result As String = NumA ^ NumB
                    Result = Result.Replace("-", "_").Replace(".", ":v:")

                    ExprStr = ExprStr.Replace(ExpMatch.Value, Result)


                    ' Reformat
                    ExprStr = ExprStr.Replace(".", ":v:")
                    ExprStr = ExprStr.Replace("-", "neg")

                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    PastExprStrMaster = ExprStrMaster

                    ' Retry loop
                    Continue While

                End If

                ' Step 6: Multiplication (only acts if there is no division closer to the left)
                If MulMatch.Success And ((MulMatch.Index < DivMatch.Index) Or Not DivMatch.Success) Then

                    ' Get A number
                    Dim NumA As String = NumberRegex.Match(MulMatch.Value).Value
                    NumA = NumA.Replace(":v:", ".").Replace("_", "-")

                    ' Get B number
                    Dim NumB As String = NumberRegex.Match(MulMatch.Value, MulMatch.Index + NumA.Length + 2).Value
                    NumB = NumB.Replace(":v:", ".").Replace("_", "-")

                    ' Conduct operation
                    Dim Result As String = CStr(CDbl(NumA) * CDbl(NumB))
                    Result = Result.Replace("-", "_").Replace(".", ":v:")

                    ExprStr = ExprStr.Replace(MulMatch.Value, Result)

                    ' Reformat
                    ExprStr = ExprStr.Replace(".", ":v:")
                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    PastExprStrMaster = ExprStrMaster

                    ' Retry loop
                    Continue While

                End If

                ' Step 7: Division
                If DivMatch.Success Then

                    ' Get A number
                    Dim NumA As String = NumberRegex.Match(DivMatch.Value).Value
                    NumA = NumA.Replace(":v:", ".").Replace("_", "-")

                    ' Get B number
                    Dim NumB As String = NumberRegex.Match(DivMatch.Value, NumA.Length + 2).Value
                    NumB = NumB.Replace(":v:", ".").Replace("_", "-")

                    ' Conduct operation
                    Dim Result As String = CStr(CDbl(NumA) / CDbl(NumB))
                    Result = Result.Replace("-", "_").Replace(".", ":v:")

                    ExprStr = ExprStr.Replace(DivMatch.Value, Result)

                    ' Reformat
                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    PastExprStrMaster = ExprStrMaster

                    ' Retry loop
                    Continue While

                End If

                ' Step 8: Addition (only acts if there is no subtraction closer to the left)
                If AddMatch.Success And ((AddMatch.Index < SubMatch.Index) Or (Not SubMatch.Success)) Then

                    ' Get A number
                    Dim NumA As String = NumberRegex.Match(AddMatch.Value).Value
                    NumA = NumA.Replace(":v:", ".").Replace("_", "-")

                    ' Get B number
                    Dim NumB As String = NumberRegex.Match(AddMatch.Value, NumA.Length + 2).Value
                    NumB = NumB.Replace(":v:", ".").Replace("_", "-")

                    ' Conduct operation
                    Dim Result As String = (CDbl(NumA) + CDbl(NumB))
                    Result = Result.Replace("-", "_").Replace(".", ":v:")

                    ExprStr = ExprStr.Replace(AddMatch.Value.Replace("-", "_"), Result)

                    ' Reformat
                    ExprStr = ExprStr.Replace(".", ":v:")
                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    PastExprStrMaster = ExprStrMaster

                    ' Retry loop
                    Continue While

                End If

                ' Step 9: Subtraction
                If SubMatch.Success Then

                    ' Get A number
                    Dim NumA As String = NumberRegex.Match(SubMatch.Value).Value
                    NumA = NumA.Replace(":v:", ".").Replace("_", "-")

                    ' Get B number
                    Dim NumB As String = NumberRegex.Match(SubMatch.Value, NumA.Length + 2).Value
                    NumB = NumB.Replace(":v:", ".").Replace("_", "-")

                    ' Conduct operation
                    Dim Result As String = CDbl(NumA) - CDbl(NumB)
                    Result = Result.Replace("-", "_").Replace(".", ":v:")

                    ExprStr = ExprStr.Replace(SubMatch.Value, Result)
                    ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)

                    PastExprStrMaster = ExprStrMaster

                    ' Retry loop
                    Continue While

                End If

                ' Update master expression string
                ExprStrMaster = ExprStrMaster.Replace(ExprStrCopy, ExprStr)
                Exit While

            End While

            ' Check to make sure that the function is written properly
            If ExprStrCopy = ExprStr Then

                ' If a valid number is found, perform a few exception fixing operations and return it
                If NumberRegex.Match(ExprStrMaster).Success Then

                    Return CDbl(ExprStrMaster.Replace(":v:", ".").Replace("_", "-"))

                Else

                    ' If the function cannot be completed, cause an error
                    Throw New ArithmeticException("FunctionEvaluate ERROR: Improper function entered; Function: " & ExprStrMasterIn & ", Solution: " & ExprStrMaster)
                    Return 0

                End If

            End If

        End While


        Return CDbl(ExprStrMaster.Replace(":v:", ".").Replace("_", "-"))

    End Function


End Class

Public Class TF2WH

    Shared Function QueryPriceOne(ItemNameExact As String, ByRef WClient As WebClient) As Integer

        ' Get HTML source
        Dim HTMLStr As String = WClient.DownloadString("http://www.tf2wh.com/items.php?search=" & ItemNameExact.Replace(" ", "+"))
        Dim HTMLLines As String() = HTMLStr.Split(vbLf)

        ' Isolate meaningful data
        For i = 0 To HTMLLines.Count - 1

            Dim Line As String = HTMLLines.GetValue(i).ToString
            If Line.StartsWith("<li style") Then

                ' Format
                Line = Line.Substring(Line.IndexOf("style='color:"))
                Line = Line.Substring(Line.IndexOf(">") + 1)

                ' Get name
                Dim ItemName As String = Line.Substring(0, Line.IndexOf("<"))
                If ItemName.ToLower = ItemNameExact.ToLower Then

                    ' Get price
                    Dim ItemPrice As String = Line.Substring(Line.IndexOf("="))
                    ItemPrice = ItemPrice.Substring(0, ItemPrice.IndexOf("c"))
                    ItemPrice = ItemPrice.Substring(ItemPrice.IndexOf(">") + 1)

                    Return CInt(ItemPrice)

                End If
            End If

        Next

        Return -1

    End Function
    Shared Function QueryPriceMultiple(ItemNameList As String(), ByRef WClient As WebClient) As Integer()

        ' Array of prices
        Dim PriceArray(ItemNameList.Count - 1) As Integer

        ' Get HTML source
        Dim HTMLStr As String = WClient.DownloadString("http://www.tf2wh.com/items.php?search=")
        Dim HTMLLines As String() = HTMLStr.Split(vbLf)

        ' Isolate meaningful data
        For i = 0 To HTMLLines.Count - 1

            Dim Line As String = HTMLLines.GetValue(i).ToString
            Dim MatchCnt As Integer = (Line.Length - Line.Replace("<li style", "").Length) / 9

            If Line.StartsWith("<li style") And MatchCnt = 1 Then

                ' Format
                Line = Line.Substring(Line.IndexOf("style='color:"))
                Line = Line.Substring(Line.IndexOf(">") + 1)

                ' Get name
                Dim ItemName As String = Line.Substring(0, Line.IndexOf("<"))
                Dim Idx As Integer = Array.IndexOf(ItemNameList, ItemName.ToLower)
                If Idx <> -1 Then

                    ' Get price
                    Dim ItemPrice As String = Line.Substring(Line.IndexOf("="))
                    ItemPrice = ItemPrice.Substring(0, ItemPrice.IndexOf("c"))
                    ItemPrice = ItemPrice.Substring(ItemPrice.IndexOf(">") + 1)
                    ItemPrice = ItemPrice.Replace(",", "")

                    ' Put it into price array
                    PriceArray.SetValue(CInt(ItemPrice), Idx)

                End If
            End If
        Next

        ' Individually query any missing items (1/2)
        For i = 0 To PriceArray.Count - 1
            If PriceArray.GetValue(i) = 0 Then
                PriceArray.SetValue(QueryPriceOne(ItemNameList.GetValue(i), WClient), i)
            End If
        Next

        Dim Q = 1

        ' Return price array
        Return PriceArray

    End Function

End Class