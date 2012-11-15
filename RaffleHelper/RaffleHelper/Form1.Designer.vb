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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEntrants = New System.Windows.Forms.TextBox()
        Me.lblNumQueue = New System.Windows.Forms.Label()
        Me.txtDrawNum = New System.Windows.Forms.TextBox()
        Me.lblWinner = New System.Windows.Forms.Label()
        Me.btnRandomDotOrg = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(638, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Step 1: Copy Steam chat log. Everyone who wants to enter must have said something" & _
    " at least once (without using the /me command)."
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(16, 30)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(635, 23)
        Me.btn1.TabIndex = 1
        Me.btn1.Text = "Click when chat is copied"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(501, 39)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'txtEntrants
        '
        Me.txtEntrants.Location = New System.Drawing.Point(16, 110)
        Me.txtEntrants.Multiline = True
        Me.txtEntrants.Name = "txtEntrants"
        Me.txtEntrants.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEntrants.Size = New System.Drawing.Size(635, 207)
        Me.txtEntrants.TabIndex = 3
        '
        'lblNumQueue
        '
        Me.lblNumQueue.AutoSize = True
        Me.lblNumQueue.Location = New System.Drawing.Point(13, 333)
        Me.lblNumQueue.Name = "lblNumQueue"
        Me.lblNumQueue.Size = New System.Drawing.Size(502, 13)
        Me.lblNumQueue.TabIndex = 4
        Me.lblNumQueue.Text = "Step 3: Enter a number between 1 and X (including X), or click the ""Get number fr" & _
    "om random.org"" button."
        '
        'txtDrawNum
        '
        Me.txtDrawNum.Location = New System.Drawing.Point(16, 350)
        Me.txtDrawNum.Name = "txtDrawNum"
        Me.txtDrawNum.Size = New System.Drawing.Size(100, 20)
        Me.txtDrawNum.TabIndex = 5
        '
        'lblWinner
        '
        Me.lblWinner.AutoSize = True
        Me.lblWinner.Location = New System.Drawing.Point(16, 393)
        Me.lblWinner.Name = "lblWinner"
        Me.lblWinner.Size = New System.Drawing.Size(189, 13)
        Me.lblWinner.TabIndex = 6
        Me.lblWinner.Text = "Step 4: And the winner is...nobody yet."
        '
        'btnRandomDotOrg
        '
        Me.btnRandomDotOrg.Location = New System.Drawing.Point(122, 347)
        Me.btnRandomDotOrg.Name = "btnRandomDotOrg"
        Me.btnRandomDotOrg.Size = New System.Drawing.Size(165, 23)
        Me.btnRandomDotOrg.TabIndex = 7
        Me.btnRandomDotOrg.Text = "Get Number from random.org"
        Me.btnRandomDotOrg.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 425)
        Me.Controls.Add(Me.btnRandomDotOrg)
        Me.Controls.Add(Me.lblWinner)
        Me.Controls.Add(Me.txtDrawNum)
        Me.Controls.Add(Me.lblNumQueue)
        Me.Controls.Add(Me.txtEntrants)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Zamby's Raffle Helper - Written by Xixo12e"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEntrants As System.Windows.Forms.TextBox
    Friend WithEvents lblNumQueue As System.Windows.Forms.Label
    Friend WithEvents txtDrawNum As System.Windows.Forms.TextBox
    Friend WithEvents lblWinner As System.Windows.Forms.Label
    Friend WithEvents btnRandomDotOrg As System.Windows.Forms.Button

End Class
