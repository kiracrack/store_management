Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmStoreAccount
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
  
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If txtAccount.Text = "" Then
            MsgBox("Please enter store name", vbCritical, Me.Text)
            txtAccount.Focus()
            Exit Sub
        ElseIf txtAmount.Value <= 0 Then
            MsgBox("Please enter Beginning Asset", vbCritical, Me.Text)
            txtAmount.Focus()
            Exit Sub
        End If
        If countrecord("tblstore") > 0 Then
            com.CommandText = "update tblstore set accountname='" & rchar(txtAccount.Text) & "', beginningasset='" & txtAmount.Value & "',savings='" & txtSavings.Value & "', datestart='" & txtDate.Text & "' where accountno='" & accountno.Text & "'" : com.ExecuteNonQuery()
        Else
            com.CommandText = "insert into tblstore set accountno='" & accountno.Text & "',accountname='" & rchar(txtAccount.Text) & "', beginningasset='" & txtAmount.Value & "',savings='" & txtSavings.Value & "', datestart='" & txtDate.Text & "'" : com.ExecuteNonQuery()
        End If
        MessageBox.Show("Account Successfully Saved", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtAccount.Focus()
    End Sub

    Private Sub frmItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If countrecord("tblstore") = 0 Then
            txtDate.Text = Format(Now)
        Else
            com.CommandText = "select * from tblstore" : rst = com.ExecuteReader
            While rst.Read
                accountno.Text = rst("accountno").ToString
                txtAccount.Text = rst("accountname").ToString
                txtAmount.Value = rst("beginningasset").ToString
                txtSavings.Value = rst("savings").ToString
                txtDate.Text = rst("datestart").ToString
            End While
            rst.Close()
        End If
    End Sub
   
    Private Sub MyDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        If Not IsNothing(e.Value) And e.ColumnIndex > 1 Then
            If IsNumeric(e.Value) Then
                e.Value = Format(CDbl(e.Value).ToString("n"), e.CellStyle.Format)
            End If
        End If
    End Sub

End Class
