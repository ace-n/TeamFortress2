﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.btnUpdateCraftableList = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbxItems = New System.Windows.Forms.ListBox()
        Me.lbxPSupply = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbxPSell = New System.Windows.Forms.ListBox()
        Me.lbxPProfit = New System.Windows.Forms.ListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbx1 = New System.Windows.Forms.GroupBox()
        Me.btnQueryPrices = New System.Windows.Forms.Button()
        Me.gbx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUpdateCraftableList
        '
        Me.btnUpdateCraftableList.Location = New System.Drawing.Point(7, 49)
        Me.btnUpdateCraftableList.Name = "btnUpdateCraftableList"
        Me.btnUpdateCraftableList.Size = New System.Drawing.Size(109, 41)
        Me.btnUpdateCraftableList.TabIndex = 1
        Me.btnUpdateCraftableList.Text = "Open Craftable List Tool"
        Me.btnUpdateCraftableList.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Items Required (Price)"
        '
        'lbxItems
        '
        Me.lbxItems.FormattingEnabled = True
        Me.lbxItems.Location = New System.Drawing.Point(12, 29)
        Me.lbxItems.Name = "lbxItems"
        Me.lbxItems.ScrollAlwaysVisible = True
        Me.lbxItems.Size = New System.Drawing.Size(501, 420)
        Me.lbxItems.TabIndex = 3
        '
        'lbxPSupply
        '
        Me.lbxPSupply.FormattingEnabled = True
        Me.lbxPSupply.Location = New System.Drawing.Point(510, 29)
        Me.lbxPSupply.Name = "lbxPSupply"
        Me.lbxPSupply.Size = New System.Drawing.Size(80, 420)
        Me.lbxPSupply.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(516, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Supply Price"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(596, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Result Price"
        '
        'lbxPSell
        '
        Me.lbxPSell.FormattingEnabled = True
        Me.lbxPSell.Location = New System.Drawing.Point(587, 29)
        Me.lbxPSell.Name = "lbxPSell"
        Me.lbxPSell.Size = New System.Drawing.Size(80, 420)
        Me.lbxPSell.TabIndex = 7
        '
        'lbxPProfit
        '
        Me.lbxPProfit.FormattingEnabled = True
        Me.lbxPProfit.Location = New System.Drawing.Point(666, 29)
        Me.lbxPProfit.Name = "lbxPProfit"
        Me.lbxPProfit.Size = New System.Drawing.Size(80, 420)
        Me.lbxPProfit.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(678, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Profit/Loss"
        '
        'gbx1
        '
        Me.gbx1.Controls.Add(Me.btnQueryPrices)
        Me.gbx1.Controls.Add(Me.btnUpdateCraftableList)
        Me.gbx1.Location = New System.Drawing.Point(752, 13)
        Me.gbx1.Name = "gbx1"
        Me.gbx1.Size = New System.Drawing.Size(121, 436)
        Me.gbx1.TabIndex = 10
        Me.gbx1.TabStop = False
        Me.gbx1.Text = "Control Panel"
        '
        'btnQueryPrices
        '
        Me.btnQueryPrices.Location = New System.Drawing.Point(7, 20)
        Me.btnQueryPrices.Name = "btnQueryPrices"
        Me.btnQueryPrices.Size = New System.Drawing.Size(108, 23)
        Me.btnQueryPrices.TabIndex = 2
        Me.btnQueryPrices.Text = "Query Prices"
        Me.btnQueryPrices.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 453)
        Me.Controls.Add(Me.gbx1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbxPProfit)
        Me.Controls.Add(Me.lbxPSell)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbxPSupply)
        Me.Controls.Add(Me.lbxItems)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "TF2 Merch Monitor by Xixo12e - Crafting (TF2 WH)"
        Me.gbx1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUpdateCraftableList As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbxItems As System.Windows.Forms.ListBox
    Friend WithEvents lbxPSupply As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbxPSell As System.Windows.Forms.ListBox
    Friend WithEvents lbxPProfit As System.Windows.Forms.ListBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbx1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnQueryPrices As System.Windows.Forms.Button

End Class
