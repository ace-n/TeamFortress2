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
        Me.btnClick = New System.Windows.Forms.Button()
        Me.btnRequery = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxHideIE = New System.Windows.Forms.CheckBox()
        Me.cbxAutoOn = New System.Windows.Forms.CheckBox()
        Me.txtAutoInterval = New System.Windows.Forms.TextBox()
        Me.autoCheckWorker = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pbar = New System.Windows.Forms.ProgressBar()
        Me.searchWorker = New System.ComponentModel.BackgroundWorker()
        Me.gbxItemSets = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvActiveTrades = New System.Windows.Forms.DataGridView()
        Me.clKeyword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clCrafts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clLevels = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clOPTrade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clReferrer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.gbxItemSets.SuspendLayout()
        CType(Me.dgvActiveTrades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClick
        '
        Me.btnClick.Location = New System.Drawing.Point(642, 497)
        Me.btnClick.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClick.Name = "btnClick"
        Me.btnClick.Size = New System.Drawing.Size(100, 28)
        Me.btnClick.TabIndex = 3
        Me.btnClick.Text = "Search!"
        Me.btnClick.UseVisualStyleBackColor = True
        '
        'btnRequery
        '
        Me.btnRequery.Location = New System.Drawing.Point(629, 533)
        Me.btnRequery.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRequery.Name = "btnRequery"
        Me.btnRequery.Size = New System.Drawing.Size(126, 28)
        Me.btnRequery.TabIndex = 7
        Me.btnRequery.Text = "Requery TF2WH"
        Me.btnRequery.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Autocheck interval (min)"
        '
        'cbxHideIE
        '
        Me.cbxHideIE.AutoSize = True
        Me.cbxHideIE.Location = New System.Drawing.Point(271, 21)
        Me.cbxHideIE.Name = "cbxHideIE"
        Me.cbxHideIE.Size = New System.Drawing.Size(216, 21)
        Me.cbxHideIE.TabIndex = 9
        Me.cbxHideIE.Text = "Hide Internet Explorer window"
        Me.cbxHideIE.UseVisualStyleBackColor = True
        '
        'cbxAutoOn
        '
        Me.cbxAutoOn.AutoSize = True
        Me.cbxAutoOn.Location = New System.Drawing.Point(16, 21)
        Me.cbxAutoOn.Name = "cbxAutoOn"
        Me.cbxAutoOn.Size = New System.Drawing.Size(144, 21)
        Me.cbxAutoOn.TabIndex = 10
        Me.cbxAutoOn.Text = "Enable Autocheck"
        Me.cbxAutoOn.UseVisualStyleBackColor = True
        '
        'txtAutoInterval
        '
        Me.txtAutoInterval.Location = New System.Drawing.Point(16, 65)
        Me.txtAutoInterval.Name = "txtAutoInterval"
        Me.txtAutoInterval.Size = New System.Drawing.Size(100, 22)
        Me.txtAutoInterval.TabIndex = 11
        Me.txtAutoInterval.Text = "5"
        '
        'autoCheckWorker
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxAutoOn)
        Me.GroupBox1.Controls.Add(Me.cbxHideIE)
        Me.GroupBox1.Controls.Add(Me.txtAutoInterval)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 445)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(544, 101)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'pbar
        '
        Me.pbar.Location = New System.Drawing.Point(15, 552)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(544, 23)
        Me.pbar.TabIndex = 13
        '
        'gbxItemSets
        '
        Me.gbxItemSets.Controls.Add(Me.Button1)
        Me.gbxItemSets.Location = New System.Drawing.Point(562, 12)
        Me.gbxItemSets.Name = "gbxItemSets"
        Me.gbxItemSets.Size = New System.Drawing.Size(232, 478)
        Me.gbxItemSets.TabIndex = 14
        Me.gbxItemSets.TabStop = False
        Me.gbxItemSets.Text = "Item Sets"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(55, 283)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "DBG UPDATE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Stored Searches"
        '
        'dgvActiveTrades
        '
        Me.dgvActiveTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActiveTrades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clKeyword, Me.clCrafts, Me.clLevels, Me.clOPTrade, Me.clReferrer})
        Me.dgvActiveTrades.Location = New System.Drawing.Point(15, 33)
        Me.dgvActiveTrades.Name = "dgvActiveTrades"
        Me.dgvActiveTrades.RowTemplate.Height = 24
        Me.dgvActiveTrades.Size = New System.Drawing.Size(541, 406)
        Me.dgvActiveTrades.TabIndex = 16
        '
        'clKeyword
        '
        Me.clKeyword.HeaderText = "Keyword"
        Me.clKeyword.Name = "clKeyword"
        '
        'clCrafts
        '
        Me.clCrafts.HeaderText = "Craft #s"
        Me.clCrafts.Name = "clCrafts"
        '
        'clLevels
        '
        Me.clLevels.HeaderText = "Levels"
        Me.clLevels.Name = "clLevels"
        '
        'clOPTrade
        '
        Me.clOPTrade.HeaderText = "Outpost ID"
        Me.clOPTrade.Name = "clOPTrade"
        '
        'clReferrer
        '
        Me.clReferrer.HeaderText = "Referrer"
        Me.clReferrer.Name = "clReferrer"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 585)
        Me.Controls.Add(Me.dgvActiveTrades)
        Me.Controls.Add(Me.btnRequery)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gbxItemSets)
        Me.Controls.Add(Me.pbar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClick)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "TF2 ITS - Scanner WIP"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbxItemSets.ResumeLayout(False)
        CType(Me.dgvActiveTrades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClick As System.Windows.Forms.Button
    Friend WithEvents btnRequery As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbxHideIE As System.Windows.Forms.CheckBox
    Friend WithEvents cbxAutoOn As System.Windows.Forms.CheckBox
    Friend WithEvents txtAutoInterval As System.Windows.Forms.TextBox
    Friend WithEvents autoCheckWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pbar As System.Windows.Forms.ProgressBar
    Friend WithEvents searchWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents gbxItemSets As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvActiveTrades As System.Windows.Forms.DataGridView
    Friend WithEvents clKeyword As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clCrafts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clLevels As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clOPTrade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clReferrer As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
