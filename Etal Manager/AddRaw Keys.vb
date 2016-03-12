Public Class AddRawKeys
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click

        If KeyMpqNameTBox.Text.Length = 0 Then
            KeyMpqNameTBox.Focus()
            WarningsLabel.Text = "Must enter a Name" : Return
            Return
        End If

        Dim folder = NewObject.D2Path.Replace("Game.exe", "")

        If KeyMpqNameTBox.Text.Contains(".mpq") = True Then

            If My.Computer.FileSystem.FileExists(folder & KeyMpqNameTBox.Text) Then
                NewObject.CDkeyOwner = NewObject.CDkeyOwner & ";" & KeyMpqNameTBox.Text
                NewObject.CDkeyClassic = NewObject.CDkeyClassic & ";"
                NewObject.CDkeyExpansion = NewObject.CDkeyExpansion & ";"
                Me.Close()
            Else
                WarningsLabel.Text = "File must be Diablo II instaltion folder" & vbCrLf & "              or filename is incorrect!!"
                Return
            End If

        End If
        If ClassicKeyTBox.Text.Length <> 16 And ClassicKeyTBox.Text.Length <> 26 Then
            ClassicKeyTBox.Focus()
            WarningsLabel.Text = "Invalid Classic key - must be 16 or 26 - (" & ClassicKeyTBox.Text.Length & ")" : Return
            Return
        End If

        If ExpansionKeyTBox.Text.Length <> 16 And ExpansionKeyTBox.Text.Length <> 26 Then
            ExpansionKeyTBox.Focus()
            WarningsLabel.Text = "Invalid Expansion key - must be 16 or 26 - (" & ExpansionKeyTBox.Text.Length & ")" : Return
        End If


        If NewObject.CDkeyOwner = Nothing Then
            NewObject.CDkeyOwner = KeyMpqNameTBox.Text
            NewObject.CDkeyClassic = ClassicKeyTBox.Text
            NewObject.CDkeyExpansion = ExpansionKeyTBox.Text
        Else

            NewObject.CDkeyOwner = NewObject.CDkeyOwner + ";" + KeyMpqNameTBox.Text
            NewObject.CDkeyClassic = NewObject.CDkeyClassic + ";" + ClassicKeyTBox.Text
            NewObject.CDkeyExpansion = NewObject.CDkeyExpansion + ";" + ExpansionKeyTBox.Text
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