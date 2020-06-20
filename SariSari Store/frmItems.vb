Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmItems
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtItemName.Text = "" Then
            MsgBox("Please enter item name", vbCritical, Me.Text)
            txtItemName.Focus()
            Exit Sub
        ElseIf countqry("tblitem", "itemname='" & rchar(txtItemName.Text) & "'") > 0 And mode.Text <> "edit" Then
            MsgBox("Item Name already exists", vbCritical, Me.Text)
            txtItemName.Focus()
            Exit Sub
        End If
        Dim assetcategory As String = ""
        If rad_salesConsumables.Checked = True Then
            assetcategory = "category=0"

        ElseIf rad_billingsAndPayments.Checked = True Then
            assetcategory = "category=1"

        ElseIf rad_otherasset.Checked = True Then
            assetcategory = "category=2"

        ElseIf rad_liabilities.Checked = True Then
            assetcategory = "category=3"
        End If
        If mode.Text = "edit" Then
            com.CommandText = "update tblitem set itemname='" & rchar(txtItemName.Text) & "'," & assetcategory & " where itemcode='" & itemcode.Text & "'" : com.ExecuteNonQuery()
        Else
            com.CommandText = "insert into tblitem set itemname='" & rchar(txtItemName.Text) & "', " & assetcategory & "" : com.ExecuteNonQuery()
        End If
        itemcode.Text = "" : txtItemName.Text = "" : mode.Text = "" : rad_salesConsumables.Checked = True : txtItemName.Focus()
        FilterItem()
    End Sub

    Private Sub frmItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FilterItem()
    End Sub
    Public Sub FilterItem()
        Try
            Em.DataSource = Nothing : dst = New DataSet
            msda = New MySqlDataAdapter("select itemcode,itemname as 'Item Name',case when category=0 then 'Sales Consumable Asset' when category=1 then 'Billings and Payments'  when category=2 then 'Other Asset'  when category=3 then 'Liabilities'  end as 'Category' from tblitem where itemname like '%" & rchar(txtSearch.Text) & "%' order by itemname", conn)
            msda.Fill(dst, 0)
            Em.DataSource = dst.Tables(0)
            With Em
                .Columns("itemcode").Visible = False
            End With

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

    Private Sub EditChapterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditChapterToolStripMenuItem.Click
        com.CommandText = "select * from tblitem where itemcode='" & Em.Item("itemcode", Em.CurrentRow.Index).Value() & "'" : rst = com.ExecuteReader
        While rst.Read
            itemcode.Text = rst("itemcode").ToString
            txtItemName.Text = rst("itemname").ToString
            If rst("category") = 0 Then
                rad_salesConsumables.Checked = True

            ElseIf rst("category") = 1 Then
                rad_billingsAndPayments.Checked = True

            ElseIf rst("category") = 2 Then
                rad_otherasset.Checked = True

            ElseIf rst("category") = 3 Then
                rad_liabilities.Checked = True
            End If
        End While
        rst.Close()
        mode.Text = "edit"
    End Sub

    Private Sub TagAsInactiveMemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TagAsInactiveMemberToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to delete selected item?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            com.CommandText = "delete from tblitem where itemcode='" & Em.Item("itemcode", Em.CurrentRow.Index).Value() & "'" : com.ExecuteNonQuery()
            FilterItem()
            MessageBox.Show("Item Successfully Deleted", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdLocalData_Click(sender As Object, e As EventArgs) Handles cmdLocalData.Click
        FilterItem()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles rad_otherasset.CheckedChanged

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        FilterItem()
    End Sub
End Class
