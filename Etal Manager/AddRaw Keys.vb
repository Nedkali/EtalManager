Public Class AddRawKeys
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim a = Form1.dataGridView1.CurrentRow.Index

        If TextBox1.Text.Length = 0 Then
            TextBox1.Focus()
            Label4.Text = "Must enter a Name" : Return
            Return
        End If

        If TextBox2.Text.Length <> 16 And TextBox2.Text.Length <> 26 Then
            TextBox2.Focus()
            Label4.Text = "Invalid Expansion key - must be 16 or 26" & TextBox2.Text.Length : Return
            Return
        End If

        If TextBox3.Text.Length <> 16 And TextBox3.Text.Length <> 26 Then
            TextBox3.Focus()
            Label4.Text = "Invalid Expansion key - must be 16 or 26" & TextBox3.Text.Length : Return
        End If


        If Objects(a).CDkeyOwner = Nothing Then
            Objects(a).CDkeyOwner = TextBox1.Text
            Objects(a).CDkeyClassic = TextBox2.Text
            Objects(a).CDkeyExpansion = TextBox3.Text
        Else
            Dim temp = Objects(a).CDkeyOwner
            Dim classic = Objects(a).CDkeyClassic
            Dim expans = Objects(a).CDkeyExpansion
            Objects(a).CDkeyOwner = temp + ";" + TextBox1.Text
            Objects(a).CDkeyClassic = classic + ";" + TextBox2.Text
            Objects(a).CDkeyExpansion = expans + ";" + TextBox1.Text
        End If
        Me.Close()
    End Sub
End Class