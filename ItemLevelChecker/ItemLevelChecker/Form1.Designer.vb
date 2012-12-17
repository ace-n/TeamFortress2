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
        Me.components = New System.ComponentModel.Container()
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvActiveTrades = New System.Windows.Forms.DataGridView()
        Me.clKeyword = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clLevels = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clCrafts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clBuyerID64 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clOPTrade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clReferrer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsItemsView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GoToTF2OPTradeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoToUserSteamPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopySearchResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenTF2WHPagesOfResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompareResultsToABackpackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.cbxHighlightSuccesses = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvActiveTrades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsItemsView.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClick
        '
        Me.btnClick.Location = New System.Drawing.Point(995, 404)
        Me.btnClick.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClick.Name = "btnClick"
        Me.btnClick.Size = New System.Drawing.Size(100, 28)
        Me.btnClick.TabIndex = 3
        Me.btnClick.Text = "Search!"
        Me.btnClick.UseVisualStyleBackColor = True
        '
        'btnRequery
        '
        Me.btnRequery.Location = New System.Drawing.Point(982, 440)
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
        Me.GroupBox1.Size = New System.Drawing.Size(892, 101)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'pbar
        '
        Me.pbar.Location = New System.Drawing.Point(15, 552)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(889, 23)
        Me.pbar.TabIndex = 13
        '
        'gbxItemSets
        '
        Me.gbxItemSets.Location = New System.Drawing.Point(928, 12)
        Me.gbxItemSets.Name = "gbxItemSets"
        Me.gbxItemSets.Size = New System.Drawing.Size(232, 237)
        Me.gbxItemSets.TabIndex = 14
        Me.gbxItemSets.TabStop = False
        Me.gbxItemSets.Text = "Item Sets"
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
        Me.dgvActiveTrades.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvActiveTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvActiveTrades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clKeyword, Me.clLevels, Me.clCrafts, Me.clBuyerID64, Me.clOPTrade, Me.clReferrer})
        Me.dgvActiveTrades.ContextMenuStrip = Me.cmsItemsView
        Me.dgvActiveTrades.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvActiveTrades.Location = New System.Drawing.Point(15, 33)
        Me.dgvActiveTrades.Name = "dgvActiveTrades"
        Me.dgvActiveTrades.RowTemplate.Height = 24
        Me.dgvActiveTrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvActiveTrades.Size = New System.Drawing.Size(889, 406)
        Me.dgvActiveTrades.TabIndex = 16
        '
        'clKeyword
        '
        Me.clKeyword.HeaderText = "Keyword"
        Me.clKeyword.MinimumWidth = 50
        Me.clKeyword.Name = "clKeyword"
        Me.clKeyword.Width = 150
        '
        'clLevels
        '
        Me.clLevels.HeaderText = "Levels"
        Me.clLevels.MinimumWidth = 50
        Me.clLevels.Name = "clLevels"
        Me.clLevels.Width = 150
        '
        'clCrafts
        '
        Me.clCrafts.HeaderText = "Craft #s"
        Me.clCrafts.MinimumWidth = 50
        Me.clCrafts.Name = "clCrafts"
        Me.clCrafts.Width = 150
        '
        'clBuyerID64
        '
        Me.clBuyerID64.HeaderText = "Buyer ID64"
        Me.clBuyerID64.MinimumWidth = 100
        Me.clBuyerID64.Name = "clBuyerID64"
        Me.clBuyerID64.Width = 150
        '
        'clOPTrade
        '
        Me.clOPTrade.HeaderText = "Outpost ID"
        Me.clOPTrade.MinimumWidth = 50
        Me.clOPTrade.Name = "clOPTrade"
        Me.clOPTrade.ToolTipText = "Double Click to go to trade"
        '
        'clReferrer
        '
        Me.clReferrer.HeaderText = "Referrer"
        Me.clReferrer.MinimumWidth = 50
        Me.clReferrer.Name = "clReferrer"
        Me.clReferrer.Width = 150
        '
        'cmsItemsView
        '
        Me.cmsItemsView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GoToTF2OPTradeToolStripMenuItem, Me.GoToUserSteamPageToolStripMenuItem, Me.CopySearchResultsToolStripMenuItem, Me.OpenTF2WHPagesOfResultsToolStripMenuItem, Me.CompareResultsToABackpackToolStripMenuItem})
        Me.cmsItemsView.Name = "cmsItemsView"
        Me.cmsItemsView.Size = New System.Drawing.Size(284, 146)
        '
        'GoToTF2OPTradeToolStripMenuItem
        '
        Me.GoToTF2OPTradeToolStripMenuItem.Name = "GoToTF2OPTradeToolStripMenuItem"
        Me.GoToTF2OPTradeToolStripMenuItem.Size = New System.Drawing.Size(283, 24)
        Me.GoToTF2OPTradeToolStripMenuItem.Text = "Go to TF2OP trade"
        '
        'GoToUserSteamPageToolStripMenuItem
        '
        Me.GoToUserSteamPageToolStripMenuItem.Name = "GoToUserSteamPageToolStripMenuItem"
        Me.GoToUserSteamPageToolStripMenuItem.Size = New System.Drawing.Size(283, 24)
        Me.GoToUserSteamPageToolStripMenuItem.Text = "Go to user steam page (TODO)"
        '
        'CopySearchResultsToolStripMenuItem
        '
        Me.CopySearchResultsToolStripMenuItem.Name = "CopySearchResultsToolStripMenuItem"
        Me.CopySearchResultsToolStripMenuItem.Size = New System.Drawing.Size(283, 24)
        Me.CopySearchResultsToolStripMenuItem.Text = "Copy search results"
        '
        'OpenTF2WHPagesOfResultsToolStripMenuItem
        '
        Me.OpenTF2WHPagesOfResultsToolStripMenuItem.Name = "OpenTF2WHPagesOfResultsToolStripMenuItem"
        Me.OpenTF2WHPagesOfResultsToolStripMenuItem.Size = New System.Drawing.Size(283, 24)
        Me.OpenTF2WHPagesOfResultsToolStripMenuItem.Text = "Open results' TF2WH pages"
        '
        'CompareResultsToABackpackToolStripMenuItem
        '
        Me.CompareResultsToABackpackToolStripMenuItem.Name = "CompareResultsToABackpackToolStripMenuItem"
        Me.CompareResultsToABackpackToolStripMenuItem.Size = New System.Drawing.Size(283, 24)
        Me.CompareResultsToABackpackToolStripMenuItem.Text = "Compare to backpack (WIP)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox4)
        Me.GroupBox2.Controls.Add(Me.CheckBox3)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Controls.Add(Me.cbxHighlightSuccesses)
        Me.GroupBox2.Location = New System.Drawing.Point(928, 256)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(235, 141)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options (These are WIP)"
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(7, 105)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(191, 21)
        Me.CheckBox4.TabIndex = 3
        Me.CheckBox4.Text = "Save/Load past searches"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(7, 78)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(151, 21)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.Text = "Save/Load settings"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(7, 50)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(160, 21)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "Ignore keyword case"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'cbxHighlightSuccesses
        '
        Me.cbxHighlightSuccesses.AutoSize = True
        Me.cbxHighlightSuccesses.Checked = True
        Me.cbxHighlightSuccesses.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxHighlightSuccesses.Location = New System.Drawing.Point(7, 22)
        Me.cbxHighlightSuccesses.Name = "cbxHighlightSuccesses"
        Me.cbxHighlightSuccesses.Size = New System.Drawing.Size(217, 21)
        Me.cbxHighlightSuccesses.TabIndex = 0
        Me.cbxHighlightSuccesses.Text = "Highlight successful searches"
        Me.cbxHighlightSuccesses.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(969, 476)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 28)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Update item schema"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1172, 585)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvActiveTrades)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnRequery)
        Me.Controls.Add(Me.pbar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbxItemSets)
        Me.Controls.Add(Me.btnClick)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "TF2 ITS - Scanner WIP (Upgrade Stage 2.5/3)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvActiveTrades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsItemsView.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents dgvActiveTrades As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbxHighlightSuccesses As System.Windows.Forms.CheckBox
    Friend WithEvents cmsItemsView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GoToTF2OPTradeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GoToUserSteamPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopySearchResultsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenTF2WHPagesOfResultsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompareResultsToABackpackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clKeyword As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clLevels As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clCrafts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clBuyerID64 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clOPTrade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clReferrer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
