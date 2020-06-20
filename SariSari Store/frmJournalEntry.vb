Imports MySql.Data.MySqlClient

Public Class frmJournalEntry
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmPosting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtdatetrn.Text = Format(Now)
        Try
            If journalmode.Text = "credit" Then
                com.CommandText = "select * from tblcreditaccount order by accountname asc" : rst = com.ExecuteReader()
                txtAccount.Items.Clear()
                While rst.Read()
                    txtAccount.Items.Add(New ComboBoxItem(rst("accountname"), rst("acctnumber")))
                End While
                rst.Close()

                ckSavings.Visible = False
                txtSavings.Visible = False

            Else
                com.CommandText = "select * from tblstore order by accountname asc" : rst = com.ExecuteReader()
                txtAccount.Items.Clear()
                While rst.Read()
                    txtAccount.Items.Add(New ComboBoxItem(rst("accountname"), rst("accountno")))
                End While
                rst.Close()
                txtAccount.SelectedIndex = 0
                If GlobalEnableSavings = True Then
                    ckSavings.Text = "Add to Savings " & GlobalSavings & " %"
                    ckSavings.Visible = True
                End If
            End If

            com.CommandText = "select * from tblitem order by itemname asc" : rst = com.ExecuteReader()
            txtItem.Items.Clear()
            While rst.Read()
                txtItem.Items.Add(New ComboBoxItem(rst("itemname"), rst("itemcode")))
            End While
            rst.Close()
            If mode.Text = "edit" Then
                Dim jmode As String = ""
                If journalmode.Text = "credit" Then
                    jmode = " tblcreditaccount where acctnumber=tbljournal.accountno "
                Else
                    jmode = " tblstore where accountno=tbljournal.accountno "
                End If
                Dim account As String = ""
                com.CommandText = "select *,(select accountname from " & jmode & ") as 'account', " _
                              + " (select itemname from tblitem where itemcode = tbljournal.itemcode) as 'item' from tbljournal where trnid='" & trnid.Text & "'" : rst = com.ExecuteReader
                While rst.Read
                    account = rst("account").ToString
                    accountno.Text = rst("accountno").ToString
                    txtItem.Text = rst("item").ToString
                    itemcode.Text = rst("itemcode").ToString
                    txtdatetrn.Text = rst("datetrn").ToString
                    txtRemarks.Text = rst("remarks").ToString
                    txtDebit.Value = rst("debit").ToString
                    txtCredit.Value = rst("credit").ToString
                End While
                rst.Close()
                txtAccount.Text = account
            End If
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

    Private Sub txtAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccount.SelectedIndexChanged
        If txtAccount.Text <> "" Then
            accountno.Text = DirectCast(txtAccount.SelectedItem, ComboBoxItem).HiddenValue()
            com.CommandText = "select sum(debit) as ttldebit, sum(credit) as ttlcredit,  (sum(debit)-sum(credit)+ +(select sum(capital) from tblcapital) - (select sum(beginningasset) from tblstore)) as 'balance' from tbljournal where accountno='" & accountno.Text & "'" : rst = com.ExecuteReader
            While rst.Read
                txtcurrentBalance.Text = Format(Val(rst("balance").ToString), "n")
            End While
            rst.Close()
        Else
            accountno.Text = ""
        End If
    End Sub
    Private Sub txtItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItem.SelectedIndexChanged
        If txtItem.Text <> "" Then
            itemcode.Text = DirectCast(txtItem.SelectedItem, ComboBoxItem).HiddenValue()
        Else
            itemcode.Text = ""
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles cmdPost.Click
        If txtAccount.Text = "" Then
            MsgBox("Please select account", vbCritical, Me.Text)
            txtAccount.Focus()
            Exit Sub
        ElseIf txtItem.Text = "" Then
            MsgBox("Please select item", vbCritical, Me.Text)
            txtItem.Focus()
            Exit Sub
        ElseIf txtDebit.Value <= 0 And txtCredit.Value <= 0 Then
            MsgBox("Please enter debit amount or credit amount", vbCritical, Me.Text)
            txtDebit.Focus()
            Exit Sub
        ElseIf txtDebit.Value > 0 And txtCredit.Value > 0 Then
            MsgBox("Please enter amount either debit or credit", vbCritical, Me.Text)
            txtDebit.Focus()
            Exit Sub
        ElseIf txtCredit.Value > Val(CC(txtcurrentBalance.Text)) And journalmode.Text = "store" Then
            MsgBox("Your credit limit is " & txtcurrentBalance.Text & " only!" & Environment.NewLine & "Please update your capital to continue transaction", vbCritical, Me.Text)
            txtCredit.Focus()
            Exit Sub
        End If
        If MessageBox.Show("Are you sure you want to continue post entry?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim jmode As String = "" : Dim totaldebit As Double = 0
            If journalmode.Text = "credit" Then
                jmode = " journalmode=1 "
                totaldebit = txtDebit.Value
            Else
                If ckSavings.Checked = True Then
                    totaldebit = txtDebit.Value - Val(txtSavings.Text)
                Else
                    totaldebit = txtDebit.Value
                End If
                jmode = " journalmode=0 "
            End If
            If mode.Text = "edit" Then
                com.CommandText = "update tbljournal set " & jmode & ", accountno='" & accountno.Text & "', itemcode='" & itemcode.Text & "',remarks='" & rchar(txtRemarks.Text) & "', debit='" & totaldebit & "', credit='" & txtCredit.Value & "', datetrn='" & txtdatetrn.Text & "' where trnid='" & trnid.Text & "'" : com.ExecuteNonQuery()
            Else
                com.CommandText = "insert into tbljournal set " & jmode & ", accountno='" & accountno.Text & "', itemcode='" & itemcode.Text & "',remarks='" & rchar(txtRemarks.Text) & "', debit='" & totaldebit & "', credit='" & txtCredit.Value & "', datetrn='" & txtdatetrn.Text & "'" : com.ExecuteNonQuery()
            End If

            If journalmode.Text <> "credit" Then
                If ckSavings.Checked = True Then
                    com.CommandText = "insert into tblsavings set datetrn='" & txtdatetrn.Text & "', itemcode='" & itemcode.Text & "', totalamount='" & txtDebit.Value & "', savings='" & GlobalSavings & "', totalsavings='" & txtSavings.Text & "',remarks='" & rchar(txtRemarks.Text) & "'" : com.ExecuteNonQuery()
                End If
            End If
            trnid.Text = "" : mode.Text = "" : txtItem.SelectedIndex = -1 : itemcode.Text = "" : txtRemarks.Text = "" : txtDebit.Value = 0 : txtSavings.Text = "0" : txtCredit.Value = 0 : txtItem.Focus()
            If journalmode.Text = "credit" Then
                frmCreditLedger.FilterLedger()
            Else
                frmPassbookLedger.FilterLedger()
            End If

            MessageBox.Show("Entry Successfully Posted", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub cmdWorkSave_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        frmItems.ShowDialog(Me)
        com.CommandText = "select * from tblitem order by itemname asc" : rst = com.ExecuteReader()
        txtItem.Items.Clear()
        While rst.Read()
            txtItem.Items.Add(New ComboBoxItem(rst("itemname"), rst("itemcode")))
        End While
        rst.Close()
        txtItem.Focus()
    End Sub

    Private Sub ckSavings_CheckedChanged(sender As Object, e As EventArgs) Handles ckSavings.CheckedChanged
        If ckSavings.Checked = True Then
            txtSavings.Visible = True
            txtSavings.Text = FormatNumber((Val(GlobalSavings) / 100) * txtDebit.Value, 2)
        Else
            txtSavings.Visible = False
        End If
      
    End Sub

    Private Sub txtDebit_ValueChanged(sender As Object, e As EventArgs) Handles txtDebit.ValueChanged
        If GlobalEnableSavings = True Then
            If txtDebit.Value < 1 Then
                ckSavings.Enabled = False
                ckSavings.Checked = False
            Else
                ckSavings.Enabled = True
                ckSavings.Checked = True
            End If
            If ckSavings.Checked = True Then
                txtSavings.Text = FormatNumber((Val(GlobalSavings) / 100) * txtDebit.Value, 2)
            End If

        End If
    End Sub
End Class
