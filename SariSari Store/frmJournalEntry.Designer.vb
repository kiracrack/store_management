<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJournalEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJournalEntry))
        Me.txtdatetrn = New System.Windows.Forms.DateTimePicker()
        Me.txtItem = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDebit = New System.Windows.Forms.NumericUpDown()
        Me.txtCredit = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAccount = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdPost = New System.Windows.Forms.Button()
        Me.accountno = New System.Windows.Forms.TextBox()
        Me.itemcode = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mode = New System.Windows.Forms.TextBox()
        Me.trnid = New System.Windows.Forms.TextBox()
        Me.journalmode = New System.Windows.Forms.TextBox()
        Me.txtcurrentBalance = New System.Windows.Forms.TextBox()
        Me.ckSavings = New System.Windows.Forms.CheckBox()
        Me.txtSavings = New System.Windows.Forms.TextBox()
        CType(Me.txtDebit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCredit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtdatetrn
        '
        Me.txtdatetrn.CustomFormat = "yyyy-MM-dd"
        Me.txtdatetrn.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtdatetrn.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtdatetrn.Location = New System.Drawing.Point(125, 34)
        Me.txtdatetrn.Name = "txtdatetrn"
        Me.txtdatetrn.Size = New System.Drawing.Size(181, 22)
        Me.txtdatetrn.TabIndex = 1
        Me.txtdatetrn.Value = New Date(2011, 12, 14, 0, 0, 0, 0)
        '
        'txtItem
        '
        Me.txtItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtItem.DropDownHeight = 120
        Me.txtItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtItem.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtItem.ForeColor = System.Drawing.Color.Black
        Me.txtItem.FormattingEnabled = True
        Me.txtItem.IntegralHeight = False
        Me.txtItem.ItemHeight = 13
        Me.txtItem.Location = New System.Drawing.Point(125, 59)
        Me.txtItem.Margin = New System.Windows.Forms.Padding(4)
        Me.txtItem.MaxDropDownItems = 9
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(278, 21)
        Me.txtItem.Sorted = True
        Me.txtItem.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(25, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 15)
        Me.Label9.TabIndex = 244
        Me.Label9.Text = "Date Transaction"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(56, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 15)
        Me.Label1.TabIndex = 245
        Me.Label1.Text = "Select Item"
        '
        'cmdAdd
        '
        Me.cmdAdd.BackColor = System.Drawing.Color.White
        Me.cmdAdd.ForeColor = System.Drawing.Color.Black
        Me.cmdAdd.Location = New System.Drawing.Point(405, 58)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(43, 23)
        Me.cmdAdd.TabIndex = 247
        Me.cmdAdd.Text = "Add"
        Me.cmdAdd.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(86, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 15)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "Debit"
        '
        'txtDebit
        '
        Me.txtDebit.DecimalPlaces = 2
        Me.txtDebit.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtDebit.Location = New System.Drawing.Point(125, 108)
        Me.txtDebit.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.txtDebit.Name = "txtDebit"
        Me.txtDebit.Size = New System.Drawing.Size(148, 22)
        Me.txtDebit.TabIndex = 4
        Me.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCredit
        '
        Me.txtCredit.DecimalPlaces = 2
        Me.txtCredit.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtCredit.Location = New System.Drawing.Point(125, 133)
        Me.txtCredit.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.Size = New System.Drawing.Size(148, 22)
        Me.txtCredit.TabIndex = 5
        Me.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(82, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 15)
        Me.Label3.TabIndex = 251
        Me.Label3.Text = "Credit"
        '
        'txtAccount
        '
        Me.txtAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtAccount.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txtAccount.ForeColor = System.Drawing.Color.Black
        Me.txtAccount.FormattingEnabled = True
        Me.txtAccount.ItemHeight = 13
        Me.txtAccount.Location = New System.Drawing.Point(125, 11)
        Me.txtAccount.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.Size = New System.Drawing.Size(278, 21)
        Me.txtAccount.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(69, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 15)
        Me.Label4.TabIndex = 254
        Me.Label4.Text = "Account"
        '
        'cmdPost
        '
        Me.cmdPost.Location = New System.Drawing.Point(125, 157)
        Me.cmdPost.Name = "cmdPost"
        Me.cmdPost.Size = New System.Drawing.Size(150, 30)
        Me.cmdPost.TabIndex = 6
        Me.cmdPost.Text = "Post Entry"
        Me.cmdPost.UseVisualStyleBackColor = True
        '
        'accountno
        '
        Me.accountno.Location = New System.Drawing.Point(405, 10)
        Me.accountno.Name = "accountno"
        Me.accountno.Size = New System.Drawing.Size(47, 22)
        Me.accountno.TabIndex = 256
        Me.accountno.Visible = False
        '
        'itemcode
        '
        Me.itemcode.Location = New System.Drawing.Point(405, 83)
        Me.itemcode.Name = "itemcode"
        Me.itemcode.Size = New System.Drawing.Size(47, 22)
        Me.itemcode.TabIndex = 257
        Me.itemcode.Visible = False
        '
        'txtRemarks
        '
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(125, 83)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(278, 22)
        Me.txtRemarks.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(69, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 259
        Me.Label5.Text = "Remarks"
        '
        'mode
        '
        Me.mode.Location = New System.Drawing.Point(357, 260)
        Me.mode.Name = "mode"
        Me.mode.Size = New System.Drawing.Size(47, 22)
        Me.mode.TabIndex = 261
        Me.mode.Visible = False
        '
        'trnid
        '
        Me.trnid.Location = New System.Drawing.Point(304, 260)
        Me.trnid.Name = "trnid"
        Me.trnid.Size = New System.Drawing.Size(47, 22)
        Me.trnid.TabIndex = 260
        Me.trnid.Visible = False
        '
        'journalmode
        '
        Me.journalmode.Location = New System.Drawing.Point(357, 234)
        Me.journalmode.Name = "journalmode"
        Me.journalmode.Size = New System.Drawing.Size(47, 22)
        Me.journalmode.TabIndex = 262
        Me.journalmode.Visible = False
        '
        'txtcurrentBalance
        '
        Me.txtcurrentBalance.Location = New System.Drawing.Point(304, 234)
        Me.txtcurrentBalance.Name = "txtcurrentBalance"
        Me.txtcurrentBalance.Size = New System.Drawing.Size(47, 22)
        Me.txtcurrentBalance.TabIndex = 263
        Me.txtcurrentBalance.Visible = False
        '
        'ckSavings
        '
        Me.ckSavings.AutoSize = True
        Me.ckSavings.Enabled = False
        Me.ckSavings.Location = New System.Drawing.Point(278, 112)
        Me.ckSavings.Name = "ckSavings"
        Me.ckSavings.Size = New System.Drawing.Size(103, 17)
        Me.ckSavings.TabIndex = 278
        Me.ckSavings.Text = "Add to Savings"
        Me.ckSavings.UseVisualStyleBackColor = True
        Me.ckSavings.Visible = False
        '
        'txtSavings
        '
        Me.txtSavings.BackColor = System.Drawing.Color.Yellow
        Me.txtSavings.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSavings.Location = New System.Drawing.Point(278, 133)
        Me.txtSavings.Name = "txtSavings"
        Me.txtSavings.ReadOnly = True
        Me.txtSavings.Size = New System.Drawing.Size(125, 22)
        Me.txtSavings.TabIndex = 279
        Me.txtSavings.Text = "0.00"
        Me.txtSavings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSavings.Visible = False
        '
        'frmJournalEntry
        '
        Me.AcceptButton = Me.cmdPost
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 196)
        Me.Controls.Add(Me.txtSavings)
        Me.Controls.Add(Me.ckSavings)
        Me.Controls.Add(Me.txtcurrentBalance)
        Me.Controls.Add(Me.journalmode)
        Me.Controls.Add(Me.mode)
        Me.Controls.Add(Me.trnid)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.itemcode)
        Me.Controls.Add(Me.accountno)
        Me.Controls.Add(Me.cmdPost)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAccount)
        Me.Controls.Add(Me.txtCredit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDebit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtdatetrn)
        Me.Controls.Add(Me.txtItem)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmJournalEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Journal Entry"
        CType(Me.txtDebit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCredit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtdatetrn As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDebit As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtCredit As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdPost As System.Windows.Forms.Button
    Friend WithEvents accountno As System.Windows.Forms.TextBox
    Friend WithEvents itemcode As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents mode As System.Windows.Forms.TextBox
    Friend WithEvents trnid As System.Windows.Forms.TextBox
    Friend WithEvents journalmode As System.Windows.Forms.TextBox
    Friend WithEvents txtcurrentBalance As System.Windows.Forms.TextBox
    Friend WithEvents ckSavings As System.Windows.Forms.CheckBox
    Friend WithEvents txtSavings As System.Windows.Forms.TextBox

End Class
