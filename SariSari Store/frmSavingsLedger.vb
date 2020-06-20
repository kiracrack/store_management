Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmSavingsLedger
    Dim showSerach As Boolean = False
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        ElseIf keyData = Keys.F3 Then
            If showSerach = True Then
                txtSearch.Visible = False
                txtSearch.Text = ""
                showSerach = False
            Else
                txtSearch.Visible = True
                txtSearch.Focus()
                showSerach = True
            End If
        End If
        Return ProcessCmdKey
    End Function
    Private Sub em_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Em.CellMouseDown
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Me.Em.CurrentCell = Me.Em.Rows(e.RowIndex).Cells(e.ColumnIndex)
        End If
    End Sub

    Private Sub frmItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdatetrn.Value = Format(Now.AddDays(-1))
        ShowDetails()
        FilterLedger()
    End Sub

    Public Sub ShowDetails()
        com.CommandText = "select sum(totalsavings) as 'ttlsavings' from tblsavings" : rst = com.ExecuteReader
        While rst.Read
            txtCurrentSavings.Text = Format(Val(rst("ttlsavings").ToString), "n")
        End While
        rst.Close()
    End Sub
    Private Sub txtdatetrn_ValueChanged(sender As Object, e As EventArgs) Handles txtdatetrn.ValueChanged
        FilterLedger()
    End Sub
    Public Sub FilterLedger()
        Try
            Em.Rows.Clear()
            Em.ColumnCount = 7
            Em.ColumnHeadersVisible = True

            Em.Columns(0).Name = "trnid"
            Em.Columns(1).Name = "Date"
            Em.Columns(2).Name = "Description"
            Em.Columns(3).Name = "Total Amount"
            Em.Columns(4).Name = "Savings"
            Em.Columns(5).Name = "Net Savings"
            Em.Columns(6).Name = "Balance"

             Dim cnt As Integer = 0 : Dim currbalance As Double = 0
            com.CommandText = "select *,date_format(datetrn,'%d-%m-%Y') as 'dt',concat((select itemname from tblitem where itemcode = tblsavings.itemcode), case when remarks = '' then '' else concat(' - ',remarks) end ) as description from tblsavings where (concat((select itemname from tblitem where itemcode = tblsavings.itemcode), case when remarks = '' then '' else concat(' - ',remarks) end ) like '%" & txtSearch.Text & "%') order by datetrn,trnid asc"
            rst = com.ExecuteReader
            While rst.Read
                If cnt = 0 Then
                    currbalance = Val(rst("totalsavings"))
                    If CDate(rst("datetrn").ToString) >= CDate(txtdatetrn.Value.ToShortDateString) Then
                        Em.Rows.Add(rst("trnid").ToString, rst("dt").ToString, rst("description").ToString, rst("totalamount"), rst("savings") & " %", rst("totalsavings"), currbalance)
                    End If
                Else
                    currbalance = Val(currbalance + rst("totalsavings"))
                    If CDate(rst("datetrn").ToString) >= CDate(txtdatetrn.Value.ToShortDateString) Then
                        Em.Rows.Add(rst("trnid").ToString, rst("dt").ToString, rst("description").ToString, rst("totalamount"), rst("savings") & " %", rst("totalsavings"), currbalance)
                    End If
                End If
                cnt = cnt + 1
            End While
            rst.Close()

            GridHideColumn(Em, {"trnid"})
            GridColumnAlignment(Em, {"Date", "Savings"}, DataGridViewContentAlignment.MiddleCenter)
            GridColumnAlignment(Em, {"Total Amount", "Net Savings", "Balance"}, DataGridViewContentAlignment.MiddleRight)

            ShowDetails()
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
    Private Sub em_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles Em.CellFormatting
        If Not IsNothing(e.Value) And e.ColumnIndex > 1 Then
            If IsNumeric(e.Value) Then
                e.Value = Format(CDbl(e.Value).ToString("n"), e.CellStyle.Format)
            End If
        End If
    End Sub
    Private Sub EditChapterToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles EditChapterToolStripMenuItem.Click
        frmJournalEntry.trnid.Text = Em.Item("trnid", Em.CurrentRow.Index).Value()
        frmJournalEntry.journalmode.Text = "store"
        frmJournalEntry.mode.Text = "edit"
        frmJournalEntry.Show(Me)
    End Sub

    Private Sub TagAsInactiveMemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TagAsInactiveMemberToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to delete selected record?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            com.CommandText = "delete from tbljournal where trnid='" & Em.Item("trnid", Em.CurrentRow.Index).Value() & "'" : com.ExecuteNonQuery()
            FilterLedger()
            MessageBox.Show("Record Successfully Deleted", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdLocalData_Click(sender As Object, e As EventArgs) Handles cmdLocalData.Click
        FilterLedger()
    End Sub

    Private Sub AddRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddRecordToolStripMenuItem.Click
        frmJournalEntry.journalmode.Text = "store"
        frmJournalEntry.Show()
    End Sub


    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        FilterLedger()
    End Sub
End Class
