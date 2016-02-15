Public Class Enterpassword
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim temp = TextBox1.Text
        If temp = "" Then
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If
        Dim a As Integer = Form1.dataGridView1.CurrentRow.Index
        Objects(a).AccPass = TextBox1.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Enterpassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
    End Sub
End Class