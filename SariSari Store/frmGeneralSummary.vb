Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmGeneralSummary
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub em_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
            Me.Em.CurrentCell = Me.Em.Rows(e.RowIndex).Cells(e.ColumnIndex)
        End If
    End Sub

    Private Sub frmItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdatetrn.MinDate = CDate(qrysingledata("datestart", "datestart", "tblstore")).AddDays(1)
        txtdatetrn.Text = Format(Now.ToString("MMMM dd, yyyy"))
        loadSummary()
    End Sub
    Public Sub loadSummary()
        Try
            UpdateFinancialSummary(CDate(txtdatetrn.Text).ToString("yyyy-MM-dd"))
            Em.DataSource = Nothing : dst = New DataSet
            msda = New MySqlDataAdapter("select Description,Amount from tblfinancial where financialdate='" & CDate(txtdatetrn.Text).ToString("yyyy-MM-dd") & "' order by sortorder asc", conn)
            msda.Fill(dst, 0)
            Em.DataSource = dst.Tables(0)

            For i = 0 To Em.RowCount - 1
                If Em.Rows(i).Cells("Description").Value = "NET INCOME" Then
                    If Val(CC(Em.Rows(i).Cells("Amount").Value)) > 0 Then
                        Em.Rows(i).DefaultCellStyle.BackColor = Color.Green
                        Em.Rows(i).DefaultCellStyle.ForeColor = Color.White
                        Em.Rows(i).DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    Else
                        Em.Rows(i).DefaultCellStyle.BackColor = Color.Red
                        Em.Rows(i).DefaultCellStyle.ForeColor = Color.White
                        Em.Rows(i).DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    End If
                ElseIf Em.Rows(i).Cells("Description").Value = "TOTAL SAVINGS" Then
                    Em.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    Em.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    Em.Rows(i).DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                End If
            Next

            Em.Columns(0).Width = 260
            GridColumnAlignment(Em, {"Amount"}, DataGridViewContentAlignment.MiddleRight)
            Em.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            Em.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
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
        If Not IsNothing(e.Value) And e.ColumnIndex > 0 Then
            If IsNumeric(e.Value) Then
                e.Value = Format(CDbl(e.Value).ToString("n"), e.CellStyle.Format)
            End If
        End If
    End Sub
   
    Private Sub cmdPost_Click(sender As Object, e As EventArgs) Handles cmdPost.Click
        loadSummary()
    End Sub

    Private Sub Em_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Em.CellContentClick

    End Sub
End Class
