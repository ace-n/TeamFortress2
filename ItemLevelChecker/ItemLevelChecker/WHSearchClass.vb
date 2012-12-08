Public Class WHSearchClass

    ' Search object
    Public Levels As String()
    Public Crafts As String()
    Public Keyword As String
    Public OutpostID As String
    Public Referrer As String

    ' Serialization method
    Public Function Serialize() As String
        Return String.Join(",", Levels) + ";" + String.Join(",", Crafts) + ";" + Keyword + ";" + OutpostID + ";" + Referrer
    End Function

    ' Deserialization method (a constructor)
    Public Sub New(ByVal ConstructorString As String)

        Dim SSplit As String() = ConstructorString.Split(";")

        ' Validation
        If SSplit.Length <> 5 OrElse Not validateLevelsOrCrafts(SSplit.GetValue(0).ToString) OrElse Not validateLevelsOrCrafts(SSplit.GetValue(1).ToString) Then
            Throw New ArgumentException("Invalid serialization of WHSearchClass.")
            Return
        End If

        ' Save data into new object
        Levels = SSplit.GetValue(0).ToString.Split(",")
        Crafts = SSplit.GetValue(1).ToString.Split(",")
        Keyword = SSplit.GetValue(2).ToString
        OutpostID = SSplit.GetValue(3).ToString
        Referrer = SSplit.GetValue(4).ToString

    End Sub

    ' Parameter-supplied constructor
    Public Sub New(ByVal Levels As String, ByVal Crafts As String, ByVal Keyword As String, ByVal OutpostID As String, ByVal Referrer As String)

        ' Save data into new object
        Me.Levels = Levels.Split(",")
        Me.Crafts = Crafts.Split(",")
        Me.Keyword = Keyword
        Me.OutpostID = OutpostID
        Me.Referrer = Referrer

    End Sub

    ' Null constructor
    Public Sub New()
    End Sub

    ' --- Input validator ---
    Public Shared Function validateLevelsOrCrafts(ByVal Text As String) As Boolean

        ' Validate text
        Dim SSplit = Text.Split(",")
        For Each Str As String In SSplit

            If System.Text.RegularExpressions.Regex.Match(Str, "(<|>|)\d+").Length <> Str.Length Then
                Return False ' Error spotted!
            End If

        Next

        ' No error spotted - return true
        Return True

    End Function

End Class
