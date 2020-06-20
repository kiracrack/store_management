Imports System.IO
Imports MySql.Data.MySqlClient

Public Class frmGLSettings
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        com.CommandText = "select * from tblitem order by itemname asc" : rst = com.ExecuteReader()
        txtItem.Items.Clear()
        While rst.Read()
            txtItem.Items.Add(New ComboBoxItem(rst("itemname"), rst("itemcode")))
        End While
        rst.Close()
    End Sub
    Private Sub txtItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItem.SelectedIndexChanged
        If txtItem.Text <> "" Then
            itemcode.Text = DirectCast(txtItem.SelectedItem, ComboBoxItem).HiddenValue()
        Else
            itemcode.Text = ""
        End If
    End Sub
   
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If countrecord("tblglsettings") = 0 Then
            com.CommandText = "insert into tblglsettings set glfinancial='" & itemcode.Text & "'" : com.ExecuteNonQuery()
        Else
            com.CommandText = "update tblglsettings set glfinancial='" & itemcode.Text & "'" : com.ExecuteNonQuery()
        End If
        MessageBox.Show("GL Successfully Saved", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
