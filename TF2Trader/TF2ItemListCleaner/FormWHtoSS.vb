Imports System.Net

Public Class FormWHtoSS

    Public WC As New WebClient

    Private Sub btnQueryPrices_Click(sender As System.Object, e As System.EventArgs) Handles btnQueryPrices.Click

        ' Populate equivalency textboxes
        txtBudsVal.Text = CStr(TF2WH.QueryPriceOne("Earbuds", WC))
        txtKeyVal.Text = CStr(TF2WH.QueryPriceOne("Mann Co. Supply Crate Key", WC))
        txtRefVal.Text = CStr(TF2WH.QueryPriceOne("Refined Metal", WC))

        ' Query prices from TF2SS

    End Sub
End Class