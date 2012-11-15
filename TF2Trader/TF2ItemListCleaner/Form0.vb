Public Class Form0

    Private Sub ShowCraftables(sender As System.Object, e As System.EventArgs) Handles btnCraftForm.Click
        Form1.Visible = Not Form1.Visible
    End Sub

    Private Sub ShowWHtoSS(sender As System.Object, e As System.EventArgs) Handles btnWHtoSSform.Click
        FormWHtoSS.Visible = Not FormWHtoSS.Visible
    End Sub
End Class