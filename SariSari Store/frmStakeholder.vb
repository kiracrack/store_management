Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmStakeholder
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub MyDataGridView_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Em.CellMouseDown
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Me.Em.CurrentCell = Me.Em.Rows(e.RowIndex).Cells(e.ColumnIndex)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If txtAccount.Text = "" Then
            MsgBox("Please enter Stakeholder name", vbCritical, Me.Text)
            txtAccount.Focus()
            Exit Sub
        End If
        If mode.Text = "edit" Then
            com.CommandText = "update tblstakeholder set accountname='" & rchar(txtAccount.Text) & "' where acctnumber='" & acctnumber.Text & "'" : com.ExecuteNonQuery()
        Else
            com.CommandText = "insert into tblstakeholder set acctnumber='" & acctnumber.Text & "',accountname='" & rchar(txtAccount.Text) & "'" : com.ExecuteNonQuery()
        End If
        txtAccount.Text = "" : mode.Text = "" : txtAccount.Focus()
        FilterItem()
    End Sub

    Private Sub frmItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FilterItem()
    End Sub
    Public Sub FilterItem()
        Try
            Em.DataSource = Nothing : dst = New DataSet
            msda = New MySqlDataAdapter("select acctnumber,accountname as 'Account Name' from tblstakeholder order by accountname asc", conn)
            msda.Fill(dst, 0)
            Em.DataSource = dst.Tables(0)
            With Em
                .Columns("acctnumber").Visible = False
            End With
            acctnumber.Text = codeGenerator("tblstakeholder", "acctnumber", 6, "SH", "100001")
        Catch errMYSQL As MySqlException
            MessageBox.Show("Form:" & Me.Name & vbCrLf _
                            & "Module:" & "form_load" & vbCrLf _
                            & "Message:" & errMYSQL.Message & vbCrLf _
                            & "Details:" & errMYSQL.StackTrace, _
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            MessageBox.Show("Form:" & Me.Name & vbCrLf _
                            & "Module:" & "form_load" & vbCrLf _
                            & "Message:" & errMS.Message & vbCrLf _
                            & "Details:" & errMS.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub MyDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Em.CellFormatting
        If Not IsNothing(e.Value) And e.ColumnIndex > 1 Then
            If IsNumeric(e.Value) Then
                e.Value = Format(CDbl(e.Value).ToString("n"), e.CellStyle.Format)
            End If
        End If
    End Sub
    Private Sub EditChapterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditChapterToolStripMenuItem.Click
        com.CommandText = "select * from tblstakeholder where acctnumber='" & Em.Item("acctnumber", Em.CurrentRow.Index).Value() & "'" : rst = com.ExecuteReader
        While rst.Read
            acctnumber.Text = rst("acctnumber").ToString
            txtAccount.Text = rst("accountname").ToString
        End While
        rst.Close()
        mode.Text = "edit"
    End Sub

    Private Sub TagAsInactiveMemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TagAsInactiveMemberToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to delete selected item?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            com.CommandText = "delete from tblstakeholder where acctnumber='" & Em.Item("acctnumber", Em.CurrentRow.Index).Value() & "'" : com.ExecuteNonQuery()
            FilterItem()
            MessageBox.Show("Account Successfully Deleted", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdLocalData_Click(sender As Object, e As EventArgs) Handles cmdLocalData.Click
        FilterItem()
    End Sub
End Class
