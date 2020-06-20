Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmPassbookLedger
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
        com.CommandText = "select * from tblstore" : rst = com.ExecuteReader()
        While rst.Read()
            Me.Text = rst("accountname").ToString & " " & Me.Text
            accountno.Text = rst("accountno").ToString
            txtBeginningAsset.Text = Format(Val(rst("beginningasset").ToString), "n")
        End While
        rst.Close()
        ShowDetails()
        FilterLedger()
    End Sub

    Public Sub ShowDetails()
        com.CommandText = "select sum(debit) as ttldebit, sum(credit) as ttlcredit,  sum(debit)-sum(credit) as 'balance' from tbljournal where accountno='" & accountno.Text & "' and referenceno is null" : rst = com.ExecuteReader
        While rst.Read
            txtTotalSale.Text = Format(Val(rst("ttldebit").ToString), "n")
            txtTotalExpenses.Text = Format(Val(rst("ttlcredit").ToString), "n")
            txtCurrentBalance.Text = Format(Val(rst("balance").ToString), "n")
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
            Em.Columns(3).Name = "Debit"
            Em.Columns(4).Name = "Credit"
            Em.Columns(5).Name = "Balance"
            Em.Columns(6).Name = "Balance Asset"

            Dim cnt As Integer = 0 : Dim currbalance As Double = 0 : Dim BalanceAsset As Double = 0
            com.CommandText = "select *,date_format(datetrn,'%d-%m-%Y') as 'dt',concat((select itemname from tblitem where itemcode = tbljournal.itemcode), case when remarks = '' then '' else concat(' - ',remarks) end ) as description from tbljournal inner join tblitem on tbljournal.itemcode = tblitem.itemcode where accountno='" & accountno.Text & "' and (concat((select itemname from tblitem where itemcode = tbljournal.itemcode), case when remarks = '' then '' else concat(' - ',remarks) end ) like '%" & txtSearch.Text & "%') order by datetrn,trnid asc"
            rst = com.ExecuteReader
            While rst.Read
                If cnt = 0 Then
                    currbalance = Val((rst("debit")) + currbalance) - rst("credit")
                    BalanceAsset = Val(CC(txtBeginningAsset.Text)) - currbalance
                    If CDate(rst("datetrn").ToString) >= CDate(txtdatetrn.Value.ToString) Then
                        Em.Rows.Add(rst("trnid").ToString, rst("dt").ToString, rst("description").ToString, rst("debit"), rst("credit"), currbalance, BalanceAsset)
                    End If
                Else
                    currbalance = Val((rst("debit")) + currbalance) - rst("credit")
                    If rst("referenceno").ToString = "" Then
                        Dim creditadd As Double = 0
                        If rst("credit") > 0 And (rst("category") = 0 Or rst("category") = 2) Then
                            creditadd = rst("credit")
                        Else
                            creditadd = 0
                        End If
                        BalanceAsset = (BalanceAsset - rst("debit")) + creditadd
                    Else
                        BalanceAsset = BalanceAsset
                    End If

                    If CDate(rst("datetrn").ToString) >= CDate(txtdatetrn.Value.ToShortDateString) Then
                        ' MsgBox(CDate(rst("datetrn").ToString) & "-" & CDate(txtdatetrn.Value.ToShortDateString))
                        Em.Rows.Add(rst("trnid").ToString, rst("dt").ToString, rst("description").ToString, rst("debit"), rst("credit"), currbalance, BalanceAsset)
                    End If
                End If
                cnt = cnt + 1
            End While
            rst.Close()

            GridHideColumn(Em, {"trnid"})
            GridColumnAlignment(Em, {"Date"}, DataGridViewContentAlignment.MiddleCenter)
            GridColumnAlignment(Em, {"Debit", "Credit", "Balance", "Balance Asset"}, DataGridViewContentAlignment.MiddleRight)

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
