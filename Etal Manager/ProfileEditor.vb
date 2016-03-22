Imports System.Collections.ObjectModel
Imports System.IO

Public Class ProfileEditor

    Private Sub AutoDetedPathButton_Click(sender As Object, e As EventArgs) Handles AutoDetedPathButton.Click
        Dim key As Microsoft.Win32.RegistryKey

        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Blizzard Entertainment\Diablo II")
        If key Is Nothing Then
            Return
        End If

        Dim D2Path As String = key.GetValue("InstallPath").ToString()
        If D2Path.Substring(D2Path.Length - 1, 1) = "\" Then
            D2Path = D2Path & "Game.exe"
        Else
            D2Path = D2Path & "\Game.exe"
        End If
        D2PathTBox.Text = D2Path
        NewObject.D2Path = D2Path
    End Sub


    Private Sub ManualSeekPathButton_Click(sender As Object, e As EventArgs) Handles ManualSeekPathButton.Click
        Dim D2Path As String = "C:\"
        Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog
        openFileDialog1.Filter = "Loader files|Game*.exe|All files|*.*"
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            D2Path = openFileDialog1.FileName
            D2PathTBox.Text = D2Path
            NewObject.D2Path = D2Path
        End If
    End Sub




    Private Sub OkAcceptButton_Click(sender As Object, e As EventArgs) Handles OkAcceptButton.Click
        If ProfileNameTBox.Text = "" Then
            MessageBox.Show("Profile name not set", "Error")
            Return
        End If
        If D2PathTBox.Text = "" Then
            MessageBox.Show("Game Path not Entered", "Error")
            Return
        End If
        If AccountNameTBox.Text = "" Then
            MessageBox.Show("Account Name not Entered", "Error")
            Return
        End If

        'If GameNameTBox.Text = "" And RandomGameNameCBox.Checked = False Then
        ' MessageBox.Show("Game Name not Entered", "Error")
        'Return
        ' End If

        NewObject.ProfileName = ProfileNameTBox.Text
        NewObject.D2Path = D2PathTBox.Text
        If WindowedCBox.Checked = True Then
            NewObject.WindowMode = 1
        ElseIf WindowedCBox.Checked = False Then
            NewObject.WindowMode = 0
        End If
        If NoSoundCBox.Checked = True Then
            NewObject.D2Sound = 1
        ElseIf NoSoundCBox.Checked = False Then
            NewObject.D2Sound = 0
        End If
        If LowQualityCBox.Checked = True Then
            NewObject.D2Quality = 1
        ElseIf LowQualityCBox.Checked = False Then
            NewObject.D2Quality = 0
        End If
        If DirectTextCBox.Checked = True Then
            NewObject.D2DirectText = 1
        ElseIf DirectTextCBox.Checked = False Then
            NewObject.D2DirectText = 0
        End If
        If MinimizedCBox.Checked = True Then
            NewObject.D2Minimized = 1
        ElseIf MinimizedCBox.Checked = False Then
            NewObject.D2Minimized = 0
        End If
        'NewObject.CDkeys = textBox3.Text
        If GamesPerKeyTBox.Text = Nothing Then
            NewObject.CDkeySwap = 0
        Else
            NewObject.CDkeySwap = GamesPerKeyTBox.Text
        End If

        NewObject.AccountName = AccountNameTBox.Text
        'NewObject.AccPass - deliberately left out - we grab this when user selects run
        NewObject.D2PlayType = PlayTypeDBox.SelectedIndex
        NewObject.D2Difficulty = DifficultyDBox.SelectedIndex

        If ServerDBox.Text = "U.S.West" Then NewObject.Realm = 1
        If ServerDBox.Text = "U.S.East" Then NewObject.Realm = 2
        If ServerDBox.Text = "Asia" Then NewObject.Realm = 3
        If ServerDBox.Text = "Europe" Then NewObject.Realm = 4

        If RandomGameNameCBox.Checked = True Then
            NewObject.randomGame = 1
        ElseIf RandomGameNameCBox.Checked = False Then
            NewObject.randomGame = 0
        End If
        If RandomGamePasswordCBox.Checked = True Then
            NewObject.randompass = 1
        ElseIf RandomGamePasswordCBox.Checked = False Then
            NewObject.randompass = 0
        End If
        NewObject.GameName = GameNameTBox.Text
        NewObject.GamePass = GamePasswordTBox.Text
        If radioButton1.Checked = True Then
            NewObject.CharPosition = 0
        ElseIf radioButton2.Checked = True Then
            NewObject.CharPosition = 1
        ElseIf radioButton3.Checked = True Then
            NewObject.CharPosition = 2
        ElseIf radioButton4.Checked = True Then
            NewObject.CharPosition = 3
        ElseIf radioButton5.Checked = True Then
            NewObject.CharPosition = 4
        ElseIf radioButton6.Checked = True Then
            NewObject.CharPosition = 5
        ElseIf radioButton7.Checked = True Then
            NewObject.CharPosition = 6
        ElseIf radioButton8.Checked = True Then
            NewObject.CharPosition = 7
        End If
        If EntryPointDBox.SelectedIndex = 0 Then
            NewObject.D2starter = ""
        Else
            NewObject.D2starter = EntryPointDBox.Text
        End If


        NewObject.CDkeyOwner = "" : NewObject.CDkeyClassic = "" : NewObject.CDkeyExpansion = ""
        For index = 0 To CDKeysDataGrid.RowCount - 1
            If NewObject.CDkeyOwner = Nothing Then
                NewObject.CDkeyOwner = CDKeysDataGrid.Rows(index).Cells(0).Value
                NewObject.CDkeyClassic = CDKeysDataGrid.Rows(index).Cells(1).Value
                NewObject.CDkeyExpansion = CDKeysDataGrid.Rows(index).Cells(2).Value
            Else

                NewObject.CDkeyOwner = NewObject.CDkeyOwner + ";" + CDKeysDataGrid.Rows(index).Cells(0).Value
                NewObject.CDkeyClassic = NewObject.CDkeyClassic + ";" + CDKeysDataGrid.Rows(index).Cells(1).Value
                NewObject.CDkeyExpansion = NewObject.CDkeyExpansion + ";" + CDKeysDataGrid.Rows(index).Cells(2).Value
            End If
        Next
        'MessageBox.Show(NewObject.D2starter)
        If ProfileEditoraction = "edit" Then
            'DeepCopy()
            Objects(editposition) = NewObject 'may need to do a deep copy here
            Manager.ProfilesDataGrid.Rows(editposition).Cells(0).Value = Objects(editposition).ProfileName

        Else
            Objects.Add(NewObject)
            Manager.ProfilesDataGrid.Rows(Objects.Count - 1).Cells(0).Value = Objects(Objects.Count - 1).ProfileName
            Manager.ProfilesDataGrid.Rows(Objects.Count - 1).Cells(2).Value = 0
            Manager.ProfilesDataGrid.Rows(Objects.Count - 1).Cells(3).Value = 0
            Manager.ProfilesDataGrid.Rows(Objects.Count - 1).Cells(4).Value = 0
            Manager.ProfilesDataGrid.Rows(Objects.Count - 1).Cells(5).Value = 0
        End If

        Me.Close()
    End Sub

    Private Sub RandomGameNameCBox_CheckedChanged(sender As Object, e As EventArgs) Handles RandomGameNameCBox.CheckedChanged
        If RandomGameNameCBox.Checked = True Then
            GameNameTBox.Enabled = False
        ElseIf RandomGameNameCBox.Checked = False Then
            GameNameTBox.Enabled = True
        End If
    End Sub

    Private Sub RandomGamePasswordCBox_CheckedChanged(sender As Object, e As EventArgs) Handles RandomGamePasswordCBox.CheckedChanged
        If RandomGamePasswordCBox.Checked = True Then
            GamePasswordTBox.Enabled = False
        ElseIf RandomGamePasswordCBox.Checked = False Then
            GamePasswordTBox.Enabled = True
        End If
    End Sub

    Private Sub ProfileEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.Left = Manager.Left + 20
        'Me.Top = Manager.Top + 80
        CDKeysDataGrid.Rows.Clear()
        D2PathTBox.Clear()
        GameNameTBox.Clear()
        GamePasswordTBox.Clear()
        AccountNameTBox.Clear()
        EntryPointDBox.Items.Clear()
        EntryPointDBox.Items.Add("Loader only")


        If Directory.Exists(Application.StartupPath & "/scripts") Then
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath + "\scripts", FileIO.SearchOption.SearchTopLevelOnly, "*.ntj")
                Dim str As Array = foundFile.Split("\")
                Dim temp As String = str(str.Length - 1)
                If temp.Length < 62 Then
                    EntryPointDBox.Items.Add(temp)
                End If
            Next
        End If
        Dim x As Integer = 0

        If ProfileEditoraction = "edit" Then
            NewObject = Objects(editposition)
            Me.ProfileNameTBox.SelectAll()
        Else
            NewObject = New Profiles
            'PlayTypeDBox.SelectedIndex = 0
            'radioButton1.Checked = True
            'DifficultyDBox.SelectedIndex = 0
            'ServerDBox.SelectedIndex = 0
        End If

        'MessageBox.Show("Value = " & x, "edit debug")
        ProfileNameTBox.Text = NewObject.ProfileName
        D2PathTBox.Text = NewObject.D2Path
        WindowedCBox.Checked = NewObject.WindowMode
        NoSoundCBox.Checked = NewObject.D2Sound
        LowQualityCBox.Checked = NewObject.D2Quality
        DirectTextCBox.Checked = NewObject.D2DirectText
        MinimizedCBox.Checked = NewObject.D2Minimized
        'textBox3.Text = Objects(x).CDkeys
        GamesPerKeyTBox.Text = NewObject.CDkeySwap
        AccountNameTBox.Text = NewObject.AccountName
        'NewObject.AccPass - deliberately left out - we grab this when user selects run
        PlayTypeDBox.SelectedIndex = NewObject.D2PlayType
        DifficultyDBox.SelectedIndex = NewObject.D2Difficulty
        ServerDBox.SelectedIndex = NewObject.Realm - 1
        GameNameTBox.Text = NewObject.GameName
        GamePasswordTBox.Text = NewObject.GamePass
        RandomGameNameCBox.Checked = NewObject.randomGame
        RandomGamePasswordCBox.Checked = NewObject.randompass
        If NewObject.CharPosition = 0 Then
            radioButton1.Checked = True
        ElseIf NewObject.CharPosition = 1 Then
            radioButton2.Checked = True
        ElseIf NewObject.CharPosition = 2 Then
            radioButton3.Checked = True
        ElseIf NewObject.CharPosition = 3 Then
            radioButton4.Checked = True
        ElseIf NewObject.CharPosition = 4 Then
            radioButton5.Checked = True
        ElseIf NewObject.CharPosition = 5 Then
            radioButton6.Checked = True
        ElseIf NewObject.CharPosition = 6 Then
            radioButton7.Checked = True
        ElseIf NewObject.CharPosition = 7 Then
            radioButton8.Checked = True
        End If
        For y = 0 To EntryPointDBox.Items.Count - 1
            If NewObject.D2starter = EntryPointDBox.Items(y) Then EntryPointDBox.SelectedIndex = y
        Next

        If EntryPointDBox.SelectedIndex < 0 Then EntryPointDBox.Text = "Loader Only"
        displaykeys()

        Return

    End Sub

    Private Sub AddKeyButton_Click(sender As Object, e As EventArgs) Handles AddKeyButton.Click
        If D2PathTBox.Text = Nothing Then
            MessageBox.Show("You need to set Diablo folder first")
            Return
        End If
        AddRawKeys.ShowDialog()
        displaykeys()
        Dim keys = CDKeysDataGrid.RowCount - 1
        If keys >= 0 Then
            CDKeysDataGrid.Rows(keys).Selected = True
        End If

    End Sub

    Private Sub displaykeys()

        If NewObject.CDkeyOwner = Nothing Then Return
        CDKeysDataGrid.Rows.Clear()
        Dim temp = NewObject.CDkeyOwner.Split(";")
        Dim temp1 = NewObject.CDkeyClassic.Split(";")
        Dim temp2 = NewObject.CDkeyExpansion.Split(";")
        For index = 0 To temp.Length - 1
            If temp(index) = Nothing Then Continue For
            CDKeysDataGrid.Rows.Add(temp(index), temp1(index), temp2(index))
        Next

    End Sub

    Private Sub RemoveKeyButton_Click(sender As Object, e As EventArgs) Handles RemoveKeyButton.Click
        If CDKeysDataGrid.Rows.Count <= 0 Then
            Return
        End If
        Dim x = CDKeysDataGrid.CurrentRow.Index
        CDKeysDataGrid.Rows.RemoveAt(x)

        NewObject.CDkeyOwner = "" : NewObject.CDkeyClassic = "" : NewObject.CDkeyExpansion = ""
        For index = 0 To CDKeysDataGrid.RowCount - 1
            If NewObject.CDkeyOwner = Nothing Then
                NewObject.CDkeyOwner = CDKeysDataGrid.Rows(index).Cells(0).Value
                NewObject.CDkeyClassic = CDKeysDataGrid.Rows(index).Cells(1).Value
                NewObject.CDkeyExpansion = CDKeysDataGrid.Rows(index).Cells(2).Value
            Else

                NewObject.CDkeyOwner = NewObject.CDkeyOwner + ";" + CDKeysDataGrid.Rows(index).Cells(0).Value
                NewObject.CDkeyClassic = NewObject.CDkeyClassic + ";" + CDKeysDataGrid.Rows(index).Cells(1).Value
                NewObject.CDkeyExpansion = NewObject.CDkeyExpansion + ";" + CDKeysDataGrid.Rows(index).Cells(2).Value
            End If
        Next

    End Sub

    Private Sub ProfileEditor_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ProfileNameTBox.Focus()
    End Sub

    Private Sub button4_Click(sender As Object, e As EventArgs) Handles button4.Click
        Me.Close()
    End Sub

    Private Sub DeepCopy()

        Objects(editposition).ProfileName = NewObject.ProfileName
        Objects(editposition).D2Path = NewObject.D2Path
        Objects(editposition).WindowMode = NewObject.WindowMode
        Objects(editposition).D2Sound = NewObject.D2Sound
        Objects(editposition).D2Quality = NewObject.D2Quality
        Objects(editposition).D2DirectText = NewObject.D2DirectText
        Objects(editposition).D2Minimized = NewObject.D2Minimized
        Objects(editposition).CDkeySwap = NewObject.CDkeySwap
        Objects(editposition).AccountName = NewObject.AccountName
        Objects(editposition).AccPass = NewObject.AccPass
        Objects(editposition).D2PlayType = NewObject.D2PlayType
        Objects(editposition).D2Difficulty = NewObject.D2Difficulty
        Objects(editposition).Realm = NewObject.Realm
        Objects(editposition).randomGame = NewObject.randomGame
        Objects(editposition).randompass = NewObject.randompass
        Objects(editposition).GameName = NewObject.GameName
        Objects(editposition).GamePass = NewObject.GamePass
        Objects(editposition).CharPosition = NewObject.CharPosition
        Objects(editposition).D2starter = NewObject.D2starter
        Objects(editposition).D2PID = NewObject.D2PID
        Objects(editposition).Run = NewObject.Run
        Objects(editposition).Chickens = NewObject.Chickens
        Objects(editposition).Restarts = NewObject.Restarts
        Objects(editposition).Deaths = NewObject.Deaths
        Objects(editposition).Flags = NewObject.Flags
        Objects(editposition).CDkeyOwner = NewObject.CDkeyOwner
        Objects(editposition).CDkeyClassic = NewObject.CDkeyClassic
        Objects(editposition).CDkeyExpansion = NewObject.CDkeyExpansion


    End Sub

    Private Sub GamesPerKeyTBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GamesPerKeyTBox.KeyPress
        If GamesPerKeyTBox.Text.Length = 2 Then
            e.Handled = True
            Return
        End If

        If (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub
End Class