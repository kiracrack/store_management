<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItems))
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.Em = New System.Windows.Forms.DataGridView()
        Me.cms_em = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditChapterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TagAsInactiveMemberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdLocalData = New System.Windows.Forms.ToolStripMenuItem()
        Me.itemcode = New System.Windows.Forms.TextBox()
        Me.mode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rad_salesConsumables = New System.Windows.Forms.RadioButton()
        Me.rad_billingsAndPayments = New System.Windows.Forms.RadioButton()
        Me.rad_otherasset = New System.Windows.Forms.RadioButton()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.rad_liabilities = New System.Windows.Forms.RadioButton()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms_em.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cmdSave.Location = New System.Drawing.Point(311, 23)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(52, 24)
        Me.cmdSave.TabIndex = 2
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'txtItemName
        '
        Me.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemName.Location = New System.Drawing.Point(11, 24)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(298, 22)
        Me.txtItemName.TabIndex = 0
        '
        'Em
        '
        Me.Em.AllowUserToAddRows = False
        Me.Em.AllowUserToDeleteRows = False
        Me.Em.AllowUserToResizeColumns = False
        Me.Em.AllowUserToResizeRows = False
        Me.Em.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Em.BackgroundColor = System.Drawing.Color.White
        Me.Em.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Em.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.Em.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Em.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Em.ContextMenuStrip = Me.cms_em
        Me.Em.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Em.Location = New System.Drawing.Point(11, 93)
        Me.Em.Margin = New System.Windows.Forms.Padding(2)
        Me.Em.MultiSelect = False
        Me.Em.Name = "Em"
        Me.Em.ReadOnly = True
        Me.Em.RowHeadersVisible = False
        Me.Em.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Em.Size = New System.Drawing.Size(351, 306)
        Me.Em.TabIndex = 218
        '
        'cms_em
        '
        Me.cms_em.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditChapterToolStripMenuItem, Me.TagAsInactiveMemberToolStripMenuItem, Me.ToolStripSeparator4, Me.cmdLocalData})
        Me.cms_em.Name = "ContextMenuStrip1"
        Me.cms_em.Size = New System.Drawing.Size(141, 76)
        '
        'EditChapterToolStripMenuItem
        '
        Me.EditChapterToolStripMenuItem.Image = Global.SariSari_Store.My.Resources.Resources.notebook__pencil
        Me.EditChapterToolStripMenuItem.Name = "EditChapterToolStripMenuItem"
        Me.EditChapterToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.EditChapterToolStripMenuItem.Text = "Edit Item"
        '
        'TagAsInactiveMemberToolStripMenuItem
        '
        Me.TagAsInactiveMemberToolStripMenuItem.Image = Global.SariSari_Store.My.Resources.Resources.notebook__minus
        Me.TagAsInactiveMemberToolStripMenuItem.Name = "TagAsInactiveMemberToolStripMenuItem"
        Me.TagAsInactiveMemberToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.TagAsInactiveMemberToolStripMenuItem.Text = "Delete Item"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(137, 6)
        '
        'cmdLocalData
        '
        Me.cmdLocalData.Image = Global.SariSari_Store.My.Resources.Resources.arrow_continue_090
        Me.cmdLocalData.Name = "cmdLocalData"
        Me.cmdLocalData.Size = New System.Drawing.Size(140, 22)
        Me.cmdLocalData.Tag = "1"
        Me.cmdLocalData.Text = "Refresh Data"
        '
        'itemcode
        '
        Me.itemcode.Location = New System.Drawing.Point(39, 163)
        Me.itemcode.Name = "itemcode"
        Me.itemcode.Size = New System.Drawing.Size(47, 22)
        Me.itemcode.TabIndex = 220
        Me.itemcode.Visible = False
        '
        'mode
        '
        Me.mode.Location = New System.Drawing.Point(92, 175)
        Me.mode.Name = "mode"
        Me.mode.Size = New System.Drawing.Size(47, 22)
        Me.mode.TabIndex = 221
        Me.mode.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 15)
        Me.Label1.TabIndex = 256
        Me.Label1.Text = "Complete Specific Item Name"
        '
        'rad_salesConsumables
        '
        Me.rad_salesConsumables.AutoSize = True
        Me.rad_salesConsumables.Checked = True
        Me.rad_salesConsumables.Location = New System.Drawing.Point(11, 49)
        Me.rad_salesConsumables.Name = "rad_salesConsumables"
        Me.rad_salesConsumables.Size = New System.Drawing.Size(153, 17)
        Me.rad_salesConsumables.TabIndex = 257
        Me.rad_salesConsumables.TabStop = True
        Me.rad_salesConsumables.Text = "Sales Consumables Asset"
        Me.rad_salesConsumables.UseVisualStyleBackColor = True
        '
        'rad_billingsAndPayments
        '
        Me.rad_billingsAndPayments.AutoSize = True
        Me.rad_billingsAndPayments.Location = New System.Drawing.Point(11, 71)
        Me.rad_billingsAndPayments.Name = "rad_billingsAndPayments"
        Me.rad_billingsAndPayments.Size = New System.Drawing.Size(137, 17)
        Me.rad_billingsAndPayments.TabIndex = 258
        Me.rad_billingsAndPayments.Text = "Billings and Payments"
        Me.rad_billingsAndPayments.UseVisualStyleBackColor = True
        '
        'rad_otherasset
        '
        Me.rad_otherasset.AutoSize = True
        Me.rad_otherasset.Location = New System.Drawing.Point(170, 49)
        Me.rad_otherasset.Name = "rad_otherasset"
        Me.rad_otherasset.Size = New System.Drawing.Size(90, 17)
        Me.rad_otherasset.TabIndex = 259
        Me.rad_otherasset.Text = "Other Assets"
        Me.rad_otherasset.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearch.Location = New System.Drawing.Point(11, 398)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(351, 22)
        Me.txtSearch.TabIndex = 260
        '
        'rad_liabilities
        '
        Me.rad_liabilities.AutoSize = True
        Me.rad_liabilities.Location = New System.Drawing.Point(170, 71)
        Me.rad_liabilities.Name = "rad_liabilities"
        Me.rad_liabilities.Size = New System.Drawing.Size(73, 17)
        Me.rad_liabilities.TabIndex = 261
        Me.rad_liabilities.Text = "Liabilities"
        Me.rad_liabilities.UseVisualStyleBackColor = True
        '
        'frmItems
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 428)
        Me.Controls.Add(Me.rad_liabilities)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.rad_otherasset)
        Me.Controls.Add(Me.rad_billingsAndPayments)
        Me.Controls.Add(Me.rad_salesConsumables)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mode)
        Me.Controls.Add(Me.itemcode)
        Me.Controls.Add(Me.Em)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.cmdSave)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item List"
        CType(Me.Em, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms_em.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents Em As System.Windows.Forms.DataGridView
    Friend WithEvents cms_em As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditChapterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TagAsInactiveMemberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdLocalData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents itemcode As System.Windows.Forms.TextBox
    Friend WithEvents mode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rad_salesConsumables As System.Windows.Forms.RadioButton
    Friend WithEvents rad_billingsAndPayments As System.Windows.Forms.RadioButton
    Friend WithEvents rad_otherasset As System.Windows.Forms.RadioButton
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents rad_liabilities As System.Windows.Forms.RadioButton

End Class
