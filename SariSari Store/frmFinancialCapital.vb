Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmFinancialCapital
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
            MsgBox("Please enter store account name", vbCritical, Me.Text)
            txtAccount.Focus()
            Exit Sub
        ElseIf txtAmount.Value <= 0 Then
            MsgBox("Please enter capital", vbCritical, Me.Text)
            txtAmount.Focus()
            Exit Sub
        End If
        If mode.Text = "edit" Then
            com.CommandText = "update tblcapital set accountno='" & accountno.Text & "', Capital='" & txtAmount.Value & "', datestart='" & txtDate.Text & "' where capitalid='" & capitalid.Text & "'" : com.ExecuteNonQuery()
            com.CommandText = "update tbljournal set journalmode=0, accountno='" & GLobalStoreID & "', itemcode='" & GLobalGLfinancial & "',remarks='" & txtAccount.Text & "', debit='" & txtAmount.Value & "', credit='0', datetrn='" & txtDate.Text & "' where referenceno='" & capitalid.Text & "'" : com.ExecuteNonQuery()
        Else
            com.CommandText = "insert into tblcapital set capitalid='" & capitalid.Text & "', accountno='" & accountno.Text & "', Capital='" & txtAmount.Value & "', datestart='" & txtDate.Text & "'" : com.ExecuteNonQuery()
            com.CommandText = "insert into tbljournal set referenceno='" & capitalid.Text & "',journalmode=0, accountno='" & GLobalStoreID & "', itemcode='" & GLobalGLfinancial & "',remarks='" & txtAccount.Text & "', debit='" & txtAmount.Value & "', credit='0', datetrn='" & txtDate.Text & "'" : com.ExecuteNonQuery()
        End If
        txtAccount.Text = "" : mode.Text = "" : txtAccount.Focus()
        FilterItem()
    End Sub

    Private Sub frmItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FilterItem()
        txtDate.Text = Format(Now)
        com.CommandText = "select * from tblstakeholder order by accountname asc" : rst = com.ExecuteReader()
        txtAccount.Items.Clear()
        While rst.Read()
            txtAccount.Items.Add(New ComboBoxItem(rst("accountname"), rst("acctnumber")))
        End While
        rst.Close()
    End Sub
    Private Sub txtAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccount.SelectedIndexChanged
        If txtAccount.Text <> "" Then
            accountno.Text = DirectCast(txtAccount.SelectedItem, ComboBoxItem).HiddenValue()
        Else
            accountno.Text = ""
        End If
    End Sub
    Public Sub FilterItem()
        Try
            Em.DataSource = Nothing : dst = New DataSet
            msda = New MySqlDataAdapter("select capitalid,(select accountname from tblstakeholder where accountno = tblstakeholder.acctnumber) as 'Stakeholder',Capital,((Capital/(select sum(b.capital) from tblcapital as b))*100) as 'Stock', datestart as 'Date' from tblcapital", conn)
            msda.Fill(dst, 0)
            Em.DataSource = dst.Tables(0)
            With Em
                .Columns("capitalid").Visible = False
            End With

            GridColumnAlignment(Em, {"Date", "Stock"}, DataGridViewContentAlignment.MiddleCenter)
            GridColumnAlignment(Em, {"Capital"}, DataGridViewContentAlignment.MiddleRight)

            capitalid.Text = codeGenerator("tblcapital", "capitalid", 6, "CAPL", "100001")
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
        com.CommandText = "select * from tblstore where accountno='" & Em.Item("accountno", Em.CurrentRow.Index).Value() & "'" : rst = com.ExecuteReader
        While rst.Read
            capitalid.Text = rst("accountno").ToString
            txtAccount.Text = rst("accountname").ToString
            txtAmount.Value = rst("capital").ToString
            txtDate.Text = rst("datestart").ToString
        End While
        rst.Close()
        mode.Text = "edit"
    End Sub

    Private Sub TagAsInactiveMemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TagAsInactiveMemberToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to delete selected item?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            com.CommandText = "delete from tblcapital where capitalid='" & Em.Item("capitalid", Em.CurrentRow.Index).Value() & "'" : com.ExecuteNonQuery()
            com.CommandText = "delete from tbljournal where referenceno='" & Em.Item("capitalid", Em.CurrentRow.Index).Value() & "'" : com.ExecuteNonQuery()
            frmPassbookLedger.FilterLedger()
            FilterItem()
            MessageBox.Show("Stakeholder Successfully Deleted", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdLocalData_Click(sender As Object, e As EventArgs) Handles cmdLocalData.Click
        FilterItem()
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        frmStakeholder.ShowDialog(Me)
        com.CommandText = "select * from tblstakeholder order by accountname asc" : rst = com.ExecuteReader()
        txtAccount.Items.Clear()
        While rst.Read()
            txtAccount.Items.Add(New ComboBoxItem(rst("accountname"), rst("acctnumber")))
        End While
        rst.Close()
    End Sub
End Class
