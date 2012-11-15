<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWHtoSS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbx1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbnSSHigh = New System.Windows.Forms.RadioButton()
        Me.rbnSSLow = New System.Windows.Forms.RadioButton()
        Me.btnQueryPrices = New System.Windows.Forms.Button()
        Me.gbx2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBudsVal = New System.Windows.Forms.TextBox()
        Me.txtKeyVal = New System.Windows.Forms.TextBox()
        Me.txtRefVal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCurName = New System.Windows.Forms.TextBox()
        Me.txtCurSSPrice = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbx1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbx2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbx1
        '
        Me.gbx1.Controls.Add(Me.Panel1)
        Me.gbx1.Controls.Add(Me.btnQueryPrices)
        Me.gbx1.Location = New System.Drawing.Point(765, 11)
        Me.gbx1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbx1.Name = "gbx1"
        Me.gbx1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbx1.Size = New System.Drawing.Size(161, 135)
        Me.gbx1.TabIndex = 15
        Me.gbx1.TabStop = False
        Me.gbx1.Text = "Control Panel"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbnSSHigh)
        Me.Panel1.Controls.Add(Me.rbnSSLow)
        Me.Panel1.Location = New System.Drawing.Point(12, 60)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(133, 63)
        Me.Panel1.TabIndex = 17
        '
        'rbnSSHigh
        '
        Me.rbnSSHigh.AutoSize = True
        Me.rbnSSHigh.Location = New System.Drawing.Point(4, 33)
        Me.rbnSSHigh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbnSSHigh.Name = "rbnSSHigh"
        Me.rbnSSHigh.Size = New System.Drawing.Size(120, 21)
        Me.rbnSSHigh.TabIndex = 1
        Me.rbnSSHigh.TabStop = True
        Me.rbnSSHigh.Text = "Sell HIGH ($$)"
        Me.rbnSSHigh.UseVisualStyleBackColor = True
        '
        'rbnSSLow
        '
        Me.rbnSSLow.AutoSize = True
        Me.rbnSSLow.Location = New System.Drawing.Point(5, 5)
        Me.rbnSSLow.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbnSSLow.Name = "rbnSSLow"
        Me.rbnSSLow.Size = New System.Drawing.Size(110, 21)
        Me.rbnSSLow.TabIndex = 0
        Me.rbnSSLow.TabStop = True
        Me.rbnSSLow.Text = "Sell LOW ($)"
        Me.rbnSSLow.UseVisualStyleBackColor = True
        '
        'btnQueryPrices
        '
        Me.btnQueryPrices.Location = New System.Drawing.Point(9, 25)
        Me.btnQueryPrices.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnQueryPrices.Name = "btnQueryPrices"
        Me.btnQueryPrices.Size = New System.Drawing.Size(144, 28)
        Me.btnQueryPrices.TabIndex = 2
        Me.btnQueryPrices.Text = "Query Prices"
        Me.btnQueryPrices.UseVisualStyleBackColor = True
        '
        'gbx2
        '
        Me.gbx2.Controls.Add(Me.Label8)
        Me.gbx2.Controls.Add(Me.txtBudsVal)
        Me.gbx2.Controls.Add(Me.txtKeyVal)
        Me.gbx2.Controls.Add(Me.txtRefVal)
        Me.gbx2.Controls.Add(Me.Label7)
        Me.gbx2.Controls.Add(Me.Label6)
        Me.gbx2.Controls.Add(Me.Label5)
        Me.gbx2.Location = New System.Drawing.Point(765, 154)
        Me.gbx2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbx2.Name = "gbx2"
        Me.gbx2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbx2.Size = New System.Drawing.Size(161, 394)
        Me.gbx2.TabIndex = 16
        Me.gbx2.TabStop = False
        Me.gbx2.Text = "Currency Values"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 272)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 85)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "<<<<<<<>>>>>>>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Currency item values" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "based on TF2WH.com" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "queries" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<<<<<<<>>>>>>>" & _
            ""
        '
        'txtBudsVal
        '
        Me.txtBudsVal.Location = New System.Drawing.Point(12, 183)
        Me.txtBudsVal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBudsVal.Name = "txtBudsVal"
        Me.txtBudsVal.Size = New System.Drawing.Size(132, 22)
        Me.txtBudsVal.TabIndex = 15
        '
        'txtKeyVal
        '
        Me.txtKeyVal.Location = New System.Drawing.Point(12, 117)
        Me.txtKeyVal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtKeyVal.Name = "txtKeyVal"
        Me.txtKeyVal.Size = New System.Drawing.Size(132, 22)
        Me.txtKeyVal.TabIndex = 14
        '
        'txtRefVal
        '
        Me.txtRefVal.Location = New System.Drawing.Point(12, 52)
        Me.txtRefVal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRefVal.Name = "txtRefVal"
        Me.txtRefVal.Size = New System.Drawing.Size(132, 22)
        Me.txtRefVal.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 164)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 17)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Earbuds (WH c)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 96)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Key (WH c)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 31)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Refined (WH c)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(368, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Current Item Name (Highlight text and CTRL-N to update)"
        '
        'txtCurName
        '
        Me.txtCurName.Location = New System.Drawing.Point(16, 36)
        Me.txtCurName.Name = "txtCurName"
        Me.txtCurName.Size = New System.Drawing.Size(365, 22)
        Me.txtCurName.TabIndex = 18
        '
        'txtCurSSPrice
        '
        Me.txtCurSSPrice.Location = New System.Drawing.Point(16, 103)
        Me.txtCurSSPrice.Name = "txtCurSSPrice"
        Me.txtCurSSPrice.Size = New System.Drawing.Size(365, 22)
        Me.txtCurSSPrice.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(447, 17)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Current Item Spreadsheet Price (Highlight text and CTRL-P to update)"
        '
        'FormWHtoSS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 558)
        Me.Controls.Add(Me.txtCurSSPrice)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCurName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbx2)
        Me.Controls.Add(Me.gbx1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormWHtoSS"
        Me.Text = "TF2 Merch Monitor by Xixo12e - TF2WH (buy) to TF2 Spreadsheet (sell)"
        Me.gbx1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gbx2.ResumeLayout(False)
        Me.gbx2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbx1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbnSSHigh As System.Windows.Forms.RadioButton
    Friend WithEvents rbnSSLow As System.Windows.Forms.RadioButton
    Friend WithEvents btnQueryPrices As System.Windows.Forms.Button
    Friend WithEvents gbx2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBudsVal As System.Windows.Forms.TextBox
    Friend WithEvents txtKeyVal As System.Windows.Forms.TextBox
    Friend WithEvents txtRefVal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCurName As System.Windows.Forms.TextBox
    Friend WithEvents txtCurSSPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
