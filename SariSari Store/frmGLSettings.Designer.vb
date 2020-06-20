<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGLSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGLSettings))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtItem = New System.Windows.Forms.ComboBox()
        Me.itemcode = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(211, 55)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(148, 31)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Save"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(9, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 15)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "GL Item of Financial Capital"
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
        Me.txtItem.Location = New System.Drawing.Point(12, 30)
        Me.txtItem.Margin = New System.Windows.Forms.Padding(4)
        Me.txtItem.MaxDropDownItems = 9
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(347, 21)
        Me.txtItem.Sorted = True
        Me.txtItem.TabIndex = 257
        '
        'itemcode
        '
        Me.itemcode.Location = New System.Drawing.Point(143, 60)
        Me.itemcode.Name = "itemcode"
        Me.itemcode.Size = New System.Drawing.Size(62, 22)
        Me.itemcode.TabIndex = 258
        Me.itemcode.Visible = False
        '
        'frmGLSettings
        '
        Me.AcceptButton = Me.Button3
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 94)
        Me.Controls.Add(Me.itemcode)
        Me.Controls.Add(Me.txtItem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmGLSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GL Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItem As System.Windows.Forms.ComboBox
    Friend WithEvents itemcode As System.Windows.Forms.TextBox

End Class
