Public Class frmJournalMode

   
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmJournalEntry.journalmode.Text = "store"
        frmJournalEntry.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmJournalEntry.journalmode.Text = "credit"
        frmJournalEntry.Show()
        Me.Close()
    End Sub
End Class
