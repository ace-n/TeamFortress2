<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtCapX = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCapY = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCapSize = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.txtSenseMul = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGameTitle = New System.Windows.Forms.TextBox()
        Me.cbxRelWin = New System.Windows.Forms.CheckBox()
        Me.cbxAutoShoot = New System.Windows.Forms.CheckBox()
        Me.cbxLeadTargs = New System.Windows.Forms.CheckBox()
        Me.rbnRed = New System.Windows.Forms.RadioButton()
        Me.rbnBlu = New System.Windows.Forms.RadioButton()
        Me.txtEffCnt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtClrRng = New System.Windows.Forms.TextBox()
        Me.txtHeadRng = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMinMouseMovementLen = New System.Windows.Forms.TextBox()
        Me.txtScanRate = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtCapX
        '
        Me.txtCapX.Location = New System.Drawing.Point(160, 7)
        Me.txtCapX.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCapX.Name = "txtCapX"
        Me.txtCapX.Size = New System.Drawing.Size(121, 22)
        Me.txtCapX.TabIndex = 0
        Me.txtCapX.Text = "410"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "X Range"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 43)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Y Range"
        '
        'txtCapY
        '
        Me.txtCapY.Location = New System.Drawing.Point(160, 39)
        Me.txtCapY.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCapY.Name = "txtCapY"
        Me.txtCapY.Size = New System.Drawing.Size(121, 22)
        Me.txtCapY.TabIndex = 3
        Me.txtCapY.Text = "410"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 75)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Stretch Size"
        '
        'txtCapSize
        '
        Me.txtCapSize.Location = New System.Drawing.Point(160, 71)
        Me.txtCapSize.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCapSize.Name = "txtCapSize"
        Me.txtCapSize.Size = New System.Drawing.Size(121, 22)
        Me.txtCapSize.TabIndex = 5
        Me.txtCapSize.Text = "90"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(387, 202)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(17, 107)
        Me.lbl.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(71, 17)
        Me.lbl.TabIndex = 8
        Me.lbl.Text = "Sensitivity"
        '
        'txtSenseMul
        '
        Me.txtSenseMul.Location = New System.Drawing.Point(160, 103)
        Me.txtSenseMul.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSenseMul.Name = "txtSenseMul"
        Me.txtSenseMul.Size = New System.Drawing.Size(121, 22)
        Me.txtSenseMul.TabIndex = 9
        Me.txtSenseMul.Text = "3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 140)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Game Title" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtGameTitle
        '
        Me.txtGameTitle.Location = New System.Drawing.Point(160, 137)
        Me.txtGameTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtGameTitle.MaxLength = 500
        Me.txtGameTitle.Name = "txtGameTitle"
        Me.txtGameTitle.Size = New System.Drawing.Size(121, 22)
        Me.txtGameTitle.TabIndex = 11
        Me.txtGameTitle.Text = "Team Fortress 2"
        '
        'cbxRelWin
        '
        Me.cbxRelWin.AutoSize = True
        Me.cbxRelWin.Location = New System.Drawing.Point(343, 6)
        Me.cbxRelWin.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxRelWin.Name = "cbxRelWin"
        Me.cbxRelWin.Size = New System.Drawing.Size(207, 21)
        Me.cbxRelWin.TabIndex = 12
        Me.cbxRelWin.Text = "Aim relative to game window"
        Me.cbxRelWin.UseVisualStyleBackColor = True
        '
        'cbxAutoShoot
        '
        Me.cbxAutoShoot.AutoSize = True
        Me.cbxAutoShoot.Checked = True
        Me.cbxAutoShoot.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxAutoShoot.Location = New System.Drawing.Point(343, 38)
        Me.cbxAutoShoot.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxAutoShoot.Name = "cbxAutoShoot"
        Me.cbxAutoShoot.Size = New System.Drawing.Size(208, 21)
        Me.cbxAutoShoot.TabIndex = 13
        Me.cbxAutoShoot.Text = "Enable auto-shoot (+ CTRL)"
        Me.cbxAutoShoot.UseVisualStyleBackColor = True
        '
        'cbxLeadTargs
        '
        Me.cbxLeadTargs.AutoSize = True
        Me.cbxLeadTargs.Checked = True
        Me.cbxLeadTargs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxLeadTargs.Location = New System.Drawing.Point(343, 66)
        Me.cbxLeadTargs.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxLeadTargs.Name = "cbxLeadTargs"
        Me.cbxLeadTargs.Size = New System.Drawing.Size(110, 21)
        Me.cbxLeadTargs.TabIndex = 14
        Me.cbxLeadTargs.Text = "Lead targets"
        Me.cbxLeadTargs.UseVisualStyleBackColor = True
        '
        'rbnRed
        '
        Me.rbnRed.AutoSize = True
        Me.rbnRed.Location = New System.Drawing.Point(343, 95)
        Me.rbnRed.Margin = New System.Windows.Forms.Padding(4)
        Me.rbnRed.Name = "rbnRed"
        Me.rbnRed.Size = New System.Drawing.Size(189, 21)
        Me.rbnRed.TabIndex = 15
        Me.rbnRed.TabStop = True
        Me.rbnRed.Text = "Shoot RED players (pink)"
        Me.rbnRed.UseVisualStyleBackColor = True
        '
        'rbnBlu
        '
        Me.rbnBlu.AutoSize = True
        Me.rbnBlu.Location = New System.Drawing.Point(343, 127)
        Me.rbnBlu.Margin = New System.Windows.Forms.Padding(4)
        Me.rbnBlu.Name = "rbnBlu"
        Me.rbnBlu.Size = New System.Drawing.Size(227, 21)
        Me.rbnBlu.TabIndex = 16
        Me.rbnBlu.TabStop = True
        Me.rbnBlu.Text = "Shoot BLU players (lime green)"
        Me.rbnBlu.UseVisualStyleBackColor = True
        '
        'txtEffCnt
        '
        Me.txtEffCnt.Location = New System.Drawing.Point(160, 169)
        Me.txtEffCnt.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEffCnt.MaxLength = 500
        Me.txtEffCnt.Name = "txtEffCnt"
        Me.txtEffCnt.Size = New System.Drawing.Size(121, 22)
        Me.txtEffCnt.TabIndex = 18
        Me.txtEffCnt.Text = "2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 172)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 17)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Efficiency"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 204)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 17)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Color Range"
        '
        'txtClrRng
        '
        Me.txtClrRng.Location = New System.Drawing.Point(160, 201)
        Me.txtClrRng.Margin = New System.Windows.Forms.Padding(4)
        Me.txtClrRng.MaxLength = 500
        Me.txtClrRng.Name = "txtClrRng"
        Me.txtClrRng.Size = New System.Drawing.Size(121, 22)
        Me.txtClrRng.TabIndex = 20
        Me.txtClrRng.Text = "14"
        '
        'txtHeadRng
        '
        Me.txtHeadRng.Location = New System.Drawing.Point(160, 233)
        Me.txtHeadRng.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHeadRng.MaxLength = 500
        Me.txtHeadRng.Name = "txtHeadRng"
        Me.txtHeadRng.Size = New System.Drawing.Size(121, 22)
        Me.txtHeadRng.TabIndex = 22
        Me.txtHeadRng.Text = "10"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 236)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Min/Max Clamp"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 267)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 17)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Minimum Movement"
        '
        'txtMinMouseMovementLen
        '
        Me.txtMinMouseMovementLen.Location = New System.Drawing.Point(160, 263)
        Me.txtMinMouseMovementLen.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMinMouseMovementLen.MaxLength = 500
        Me.txtMinMouseMovementLen.Name = "txtMinMouseMovementLen"
        Me.txtMinMouseMovementLen.Size = New System.Drawing.Size(121, 22)
        Me.txtMinMouseMovementLen.TabIndex = 24
        Me.txtMinMouseMovementLen.Text = "0"
        '
        'txtScanRate
        '
        Me.txtScanRate.Location = New System.Drawing.Point(160, 295)
        Me.txtScanRate.Margin = New System.Windows.Forms.Padding(4)
        Me.txtScanRate.MaxLength = 500
        Me.txtScanRate.Name = "txtScanRate"
        Me.txtScanRate.Size = New System.Drawing.Size(121, 22)
        Me.txtScanRate.TabIndex = 26
        Me.txtScanRate.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 299)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 17)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Screenscans / sec"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 338)
        Me.Controls.Add(Me.txtScanRate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtMinMouseMovementLen)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtHeadRng)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtClrRng)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEffCnt)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.rbnBlu)
        Me.Controls.Add(Me.rbnRed)
        Me.Controls.Add(Me.cbxLeadTargs)
        Me.Controls.Add(Me.cbxAutoShoot)
        Me.Controls.Add(Me.cbxRelWin)
        Me.Controls.Add(Me.txtGameTitle)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSenseMul)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtCapSize)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCapY)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCapX)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Blackjack 3.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCapX As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCapY As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCapSize As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents txtSenseMul As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGameTitle As System.Windows.Forms.TextBox
    Friend WithEvents cbxRelWin As System.Windows.Forms.CheckBox
    Friend WithEvents cbxAutoShoot As System.Windows.Forms.CheckBox
    Friend WithEvents cbxLeadTargs As System.Windows.Forms.CheckBox
    Friend WithEvents rbnRed As System.Windows.Forms.RadioButton
    Friend WithEvents rbnBlu As System.Windows.Forms.RadioButton
    Friend WithEvents txtEffCnt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtClrRng As System.Windows.Forms.TextBox
    Friend WithEvents txtHeadRng As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMinMouseMovementLen As System.Windows.Forms.TextBox
    Friend WithEvents txtScanRate As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
