<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form0
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
        Me.btnWHtoSSform = New System.Windows.Forms.Button()
        Me.btnCraftForm = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnWHtoSSform
        '
        Me.btnWHtoSSform.Location = New System.Drawing.Point(12, 12)
        Me.btnWHtoSSform.Name = "btnWHtoSSform"
        Me.btnWHtoSSform.Size = New System.Drawing.Size(272, 23)
        Me.btnWHtoSSform.TabIndex = 0
        Me.btnWHtoSSform.Text = "Warehouse --> Spreadsheet"
        Me.btnWHtoSSform.UseVisualStyleBackColor = True
        '
        'btnCraftForm
        '
        Me.btnCraftForm.Location = New System.Drawing.Point(12, 41)
        Me.btnCraftForm.Name = "btnCraftForm"
        Me.btnCraftForm.Size = New System.Drawing.Size(272, 23)
        Me.btnCraftForm.TabIndex = 1
        Me.btnCraftForm.Text = "Craftables"
        Me.btnCraftForm.UseVisualStyleBackColor = True
        '
        'Form0
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 76)
        Me.Controls.Add(Me.btnCraftForm)
        Me.Controls.Add(Me.btnWHtoSSform)
        Me.Name = "Form0"
        Me.Text = "TF2 Merch Monitor by Xixo12e"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnWHtoSSform As System.Windows.Forms.Button
    Friend WithEvents btnCraftForm As System.Windows.Forms.Button
End Class
