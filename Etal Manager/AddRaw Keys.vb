Public Class AddRawKeys
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        If KeyMpqNameTBox.Text.Length = 0 Then
            WarningsLabel.Text = "Must enter a Name"
            KeyMpqNameTBox.Focus()
            Return
        End If

        Dim folder = NewObject.D2Path.Replace("Game.exe", "")

        If KeyMpqNameTBox.Text.Contains(".mpq") = True Then
            If My.Computer.FileSystem.FileExists(folder & KeyMpqNameTBox.Text) Then
                If ClassicKeyTBox.Text.Length < 1 Then
                    NewObject.CDkeyOwner = NewObject.CDkeyOwner & ";" & KeyMpqNameTBox.Text
                    NewObject.CDkeyClassic = NewObject.CDkeyClassic & ";"
                    NewObject.CDkeyExpansion = NewObject.CDkeyExpansion & ";"
                    Me.Close()
                Else
                    WarningsLabel.Text = "Only set to use a MPQ file or raw keys. Not both."
                    Return
                End If
            Else
                WarningsLabel.Text = "File must be in Diablo II installation folder" & vbCrLf & "or filename is incorrect!!"
                Return
            End If
        End If

        If ClassicKeyTBox.Text.Length <> 16 And ClassicKeyTBox.Text.Length <> 26 Then
            WarningsLabel.Text = "Invalid Classic key - must be 16 or 26 - (" & ClassicKeyTBox.Text.Length & ")"
            ClassicKeyTBox.Focus()
            Return
        End If

        If ExpansionKeyTBox.Text.Length <> 16 And ExpansionKeyTBox.Text.Length <> 26 Then
            WarningsLabel.Text = "Invalid Expansion key - must be 16 or 26 - (" & ExpansionKeyTBox.Text.Length & ")"
            ExpansionKeyTBox.Focus()
            Return
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
        WarningsLabel.Text = ""
        ClassicKeyTBox.Clear()
        ExpansionKeyTBox.Clear()
        KeyMpqNameTBox.Clear()
        KeyMpqNameTBox.Focus()
    End Sub

End Class