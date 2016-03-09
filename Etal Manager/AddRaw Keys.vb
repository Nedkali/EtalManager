Public Class AddRawKeys
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        Dim a = Form1.dataGridView1.CurrentRow.Index

        If KeyMpqNameTBox.Text.Length = 0 Then
            KeyMpqNameTBox.Focus()
            Label4.Text = "Must enter a Name" : Return
            Return
        End If

        Dim folder = Objects(a).D2Path
        folder = folder.Replace("Game.exe", "")

        If KeyMpqNameTBox.Text.Contains(".mpq") = True Then

            If My.Computer.FileSystem.FileExists(folder & KeyMpqNameTBox.Text) Then
                Objects(a).CDkeyOwner = Objects(a).CDkeyOwner & ";" & KeyMpqNameTBox.Text
                Objects(a).CDkeyClassic = Objects(a).CDkeyClassic & ";"
                Objects(a).CDkeyExpansion = Objects(a).CDkeyExpansion & ";"
                Me.Close()
            Else
                Label4.Text = "File must be Diablo II instaltion folder" & vbCrLf & "              or filename is incorrect!!"
                Return
            End If

        End If
        If ClassicKeyTBox.Text.Length <> 16 And ClassicKeyTBox.Text.Length <> 26 Then
            ClassicKeyTBox.Focus()
            Label4.Text = "Invalid Expansion key - must be 16 or 26" & ClassicKeyTBox.Text.Length : Return
            Return
        End If

        If ExpansionKeyTBox.Text.Length <> 16 And ExpansionKeyTBox.Text.Length <> 26 Then
            ExpansionKeyTBox.Focus()
            Label4.Text = "Invalid Expansion key - must be 16 or 26" & ExpansionKeyTBox.Text.Length : Return
        End If


        If Objects(a).CDkeyOwner = Nothing Then
            Objects(a).CDkeyOwner = KeyMpqNameTBox.Text
            Objects(a).CDkeyClassic = ClassicKeyTBox.Text
            Objects(a).CDkeyExpansion = ExpansionKeyTBox.Text
        Else
            Dim temp = Objects(a).CDkeyOwner
            Dim classic = Objects(a).CDkeyClassic
            Dim expans = Objects(a).CDkeyExpansion
            Objects(a).CDkeyOwner = temp + ";" + KeyMpqNameTBox.Text
            Objects(a).CDkeyClassic = classic + ";" + ClassicKeyTBox.Text
            Objects(a).CDkeyExpansion = expans + ";" + ExpansionKeyTBox.Text
        End If
        Me.Close()
    End Sub

    Private Sub AddRawKeys_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyMpqNameTBox.Clear()
        ClassicKeyTBox.Clear()
        ExpansionKeyTBox.Clear()
        KeyMpqNameTBox.Focus()
    End Sub
End Class