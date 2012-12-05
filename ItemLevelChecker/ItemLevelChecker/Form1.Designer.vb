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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClick = New System.Windows.Forms.Button()
        Me.txtLevels = New System.Windows.Forms.TextBox()
        Me.txtCrafts = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.btnNewSearch = New System.Windows.Forms.Button()
        Me.dgvActiveTrades = New System.Windows.Forms.DataGridView()
        Me.cl_Keyword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_Levels = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_crafts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_tf2outpostTradeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.gbxItemSets.SuspendLayout()
        CType(Me.dgvActiveTrades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 9)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(326, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Enter the levels to look for (separated by commas)"
        '
        'btnClick
        '
        Me.btnClick.Location = New System.Drawing.Point(20, 138)
        Me.btnClick.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClick.Name = "btnClick"
        Me.btnClick.Size = New System.Drawing.Size(100, 28)
        Me.btnClick.TabIndex = 3
        Me.btnClick.Text = "Search!"
        Me.btnClick.UseVisualStyleBackColor = True
        '
        'txtLevels
        '
        Me.txtLevels.Location = New System.Drawing.Point(20, 30)
        Me.txtLevels.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLevels.Name = "txtLevels"
        Me.txtLevels.Size = New System.Drawing.Size(491, 22)
        Me.txtLevels.TabIndex = 4
        Me.txtLevels.Text = "1,42,69,99,100,0"
        '
        'txtCrafts
        '
        Me.txtCrafts.Location = New System.Drawing.Point(20, 95)
        Me.txtCrafts.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCrafts.MaximumSize = New System.Drawing.Size(491, 22)
        Me.txtCrafts.Multiline = True
        Me.txtCrafts.Name = "txtCrafts"
        Me.txtCrafts.Size = New System.Drawing.Size(491, 22)
        Me.txtCrafts.TabIndex = 6
        Me.txtCrafts.Text = "<100,666,777,999,1000,1337,2000,3000,4000,5000,6000,6666,6969,7000,7777,8000,9000" & _
            ",9999,10000,31337"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 74)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(377, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Enter the craft numbers to look for (separated by commas)"
        '
        'btnRequery
        '
        Me.btnRequery.Location = New System.Drawing.Point(128, 138)
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
        Me.GroupBox1.Location = New System.Drawing.Point(20, 182)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(491, 100)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'pbar
        '
        Me.pbar.Location = New System.Drawing.Point(23, 288)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(487, 23)
        Me.pbar.TabIndex = 13
        '
        'gbxItemSets
        '
        Me.gbxItemSets.Controls.Add(Me.Button1)
        Me.gbxItemSets.Location = New System.Drawing.Point(518, 12)
        Me.gbxItemSets.Name = "gbxItemSets"
        Me.gbxItemSets.Size = New System.Drawing.Size(232, 303)
        Me.gbxItemSets.TabIndex = 14
        Me.gbxItemSets.TabStop = False
        Me.gbxItemSets.Text = "Item Sets"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(23, 246)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 332)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Stored Searches"
        '
        'btnNewSearch
        '
        Me.btnNewSearch.Location = New System.Drawing.Point(323, 550)
        Me.btnNewSearch.Name = "btnNewSearch"
        Me.btnNewSearch.Size = New System.Drawing.Size(127, 23)
        Me.btnNewSearch.TabIndex = 17
        Me.btnNewSearch.Text = "Add New Search"
        Me.btnNewSearch.UseVisualStyleBackColor = True
        '
        'dgvActiveTrades
        '
        Me.dgvActiveTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActiveTrades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cl_Keyword, Me.cl_Levels, Me.cl_crafts, Me.cl_tf2outpostTradeID})
        Me.dgvActiveTrades.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvActiveTrades.Location = New System.Drawing.Point(25, 353)
        Me.dgvActiveTrades.Name = "dgvActiveTrades"
        Me.dgvActiveTrades.RowTemplate.Height = 24
        Me.dgvActiveTrades.Size = New System.Drawing.Size(725, 150)
        Me.dgvActiveTrades.TabIndex = 18
        '
        'cl_Keyword
        '
        Me.cl_Keyword.HeaderText = "Keyword"
        Me.cl_Keyword.Name = "cl_Keyword"
        Me.cl_Keyword.Width = 200
        '
        'cl_Levels
        '
        Me.cl_Levels.HeaderText = "Levels"
        Me.cl_Levels.Name = "cl_Levels"
        '
        'cl_crafts
        '
        Me.cl_crafts.HeaderText = "Craft #s"
        Me.cl_crafts.Name = "cl_crafts"
        '
        'cl_tf2outpostTradeID
        '
        Me.cl_tf2outpostTradeID.HeaderText = "Outpost Trade #"
        Me.cl_tf2outpostTradeID.Name = "cl_tf2outpostTradeID"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 585)
        Me.Controls.Add(Me.dgvActiveTrades)
        Me.Controls.Add(Me.btnNewSearch)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gbxItemSets)
        Me.Controls.Add(Me.pbar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnRequery)
        Me.Controls.Add(Me.txtCrafts)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLevels)
        Me.Controls.Add(Me.btnClick)
        Me.Controls.Add(Me.Label2)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "TF2 Scanner - Ace N"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbxItemSets.ResumeLayout(False)
        CType(Me.dgvActiveTrades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnClick As System.Windows.Forms.Button
    Friend WithEvents txtLevels As System.Windows.Forms.TextBox
    Friend WithEvents txtCrafts As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents btnNewSearch As System.Windows.Forms.Button
    Friend WithEvents dgvActiveTrades As System.Windows.Forms.DataGridView
    Friend WithEvents cl_Keyword As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cl_Levels As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cl_crafts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cl_tf2outpostTradeID As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
