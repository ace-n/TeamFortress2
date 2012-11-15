<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCraftableListFormatter
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFormat = New System.Windows.Forms.Button()
        Me.txtBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(454, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter the copied item text below. Get information HERE: http://www.tf2crafting.in" & _
    "fo/blueprints/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnFormat
        '
        Me.btnFormat.Location = New System.Drawing.Point(248, 434)
        Me.btnFormat.Name = "btnFormat"
        Me.btnFormat.Size = New System.Drawing.Size(75, 23)
        Me.btnFormat.TabIndex = 1
        Me.btnFormat.Text = "Format"
        Me.btnFormat.UseVisualStyleBackColor = True
        '
        'txtBox
        '
        Me.txtBox.Location = New System.Drawing.Point(6, 26)
        Me.txtBox.Multiline = True
        Me.txtBox.Name = "txtBox"
        Me.txtBox.Size = New System.Drawing.Size(555, 402)
        Me.txtBox.TabIndex = 2
        '
        'FormCraftableListFormatter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 459)
        Me.Controls.Add(Me.txtBox)
        Me.Controls.Add(Me.btnFormat)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormCraftableListFormatter"
        Me.Text = "Craftables List Formatter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFormat As System.Windows.Forms.Button
    Friend WithEvents txtBox As System.Windows.Forms.TextBox
End Class
