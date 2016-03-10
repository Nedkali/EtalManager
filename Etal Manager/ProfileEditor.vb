Imports System.Collections.ObjectModel
Imports System.IO

Public Class ProfileEditor

    Private Sub AutoDetedPathButton_Click(sender As Object, e As EventArgs) Handles AutoDetedPathButton.Click
        Dim key As Microsoft.Win32.RegistryKey

        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Blizzard Entertainment\Diablo II")
        If key Is Nothing Then
            RegErrorAck()
            Return
        End If

        Dim D2Path As String = key.GetValue("InstallPath").ToString()
        D2Path = D2Path & "\Game.exe"
        D2Path.Replace("\\", "\")
        D2PathTBox.Text = D2Path
    End Sub

    Private Sub RegErrorAck()
        MessageBox.Show("Unable to locate Registry entry", "ERROR", MessageBoxButtons.OK)
    End Sub

    Private Sub ManualSeekPathButton_Click(sender As Object, e As EventArgs) Handles ManualSeekPathButton.Click
        Dim D2Path As String = "C:\"
        Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog
        openFileDialog1.Filter = "Loader files|Game*.exe|All files|*.*"
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            D2Path = openFileDialog1.FileName
            D2PathTBox.Text = D2Path
        End If
    End Sub

    Private Sub ProfileCancelButton_Click(sender As Object, e As EventArgs) Handles ProfileCancelButton.Click
        Me.Close()
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

        If GameNameTBox.Text = "" And RandomGameNameCBox.Checked = False Then
            MessageBox.Show("Game Name not Entered", "Error")
            Return
        End If


        If ProfileEditoraction = "edit" Then
            Dim x As Integer = Manager.ProfilesDataGrid.CurrentRow.Index
            Objects(x).ProfileName = ProfileNameTBox.Text
            Objects(x).AccPass = ""
            Objects(x).D2Path = D2PathTBox.Text
            If WindowedCBox.Checked = True Then Objects(x).WindowMode = 1
            If WindowedCBox.Checked = False Then Objects(x).WindowMode = 0
            If NoSoundCBox.Checked = True Then Objects(x).D2Sound = 1
            If NoSoundCBox.Checked = False Then Objects(x).D2Sound = 0
            If LowQualityCBox.Checked = True Then Objects(x).D2Quality = 1
            If LowQualityCBox.Checked = False Then Objects(x).D2Quality = 0
            If DirectTextCBox.Checked = True Then Objects(x).D2DirectText = 1
            If DirectTextCBox.Checked = False Then Objects(x).D2DirectText = 0
            If MinimizedCBox.Checked = True Then Objects(x).D2Minimized = 1
            If MinimizedCBox.Checked = False Then Objects(x).D2Minimized = 0

            Objects(x).CDkeyOwner = "" : Objects(x).CDkeyClassic = "" : Objects(x).CDkeyExpansion = ""
            For index = 0 To CDKeysDataGrid.Rows.Count - 1
                If CDKeysDataGrid.Rows(index).Cells(0).Value.ToString() = Nothing Then Continue For

                If Objects(x).CDkeyOwner = Nothing Then
                    Objects(x).CDkeyOwner = CDKeysDataGrid.Rows(index).Cells(0).Value
                    Objects(x).CDkeyClassic = CDKeysDataGrid.Rows(index).Cells(1).Value
                    Objects(x).CDkeyExpansion = CDKeysDataGrid.Rows(index).Cells(2).Value
                Else
                    Objects(x).CDkeyOwner = Objects(x).CDkeyOwner & ";" & CDKeysDataGrid.Rows(index).Cells(0).Value
                    Objects(x).CDkeyClassic = Objects(x).CDkeyClassic & ";" & CDKeysDataGrid.Rows(index).Cells(1).Value
                    Objects(x).CDkeyExpansion = Objects(x).CDkeyExpansion & ";" & CDKeysDataGrid.Rows(index).Cells(2).Value
                End If
            Next

            'Objects(x).CDkeys = textBox3.Text
            Objects(x).CDkeySwap = GamesPerKeyTBox.Text
            Objects(x).AccountName = AccountNameTBox.Text
            'NewObject.AccPass - deliberately left out - we grab this when user selects run
            Objects(x).D2PlayType = PlayTypeDBox.SelectedIndex
            Objects(x).D2Difficulty = DifficultyDBox.SelectedIndex

            If ServerDBox.Text = "U.S.West" Then Objects(x).Realm = 1
            If ServerDBox.Text = "U.S.East" Then Objects(x).Realm = 2
            If ServerDBox.Text = "Asia" Then Objects(x).Realm = 3
            If ServerDBox.Text = "Europe" Then Objects(x).Realm = 4

            If RandomGameNameCBox.Checked = True Then Objects(x).randomGame = 1
            If RandomGameNameCBox.Checked = False Then Objects(x).randomGame = 0
            If RandomGamePasswordCBox.Checked = True Then Objects(x).randompass = 1
            If RandomGamePasswordCBox.Checked = False Then Objects(x).randompass = 0
            Objects(x).GameName = GameNameTBox.Text
            Objects(x).GamePass = GamePasswordTBox.Text
            If radioButton1.Checked = True Then Objects(x).CharPosition = 0
            If radioButton2.Checked = True Then Objects(x).CharPosition = 1
            If radioButton3.Checked = True Then Objects(x).CharPosition = 2
            If radioButton4.Checked = True Then Objects(x).CharPosition = 3
            If radioButton5.Checked = True Then Objects(x).CharPosition = 4
            If radioButton6.Checked = True Then Objects(x).CharPosition = 5
            If radioButton7.Checked = True Then Objects(x).CharPosition = 6
            If radioButton8.Checked = True Then Objects(x).CharPosition = 7
            If EntryPointDBox.Text = "Loader Only" Then
                Objects(x).D2starter = ""
            Else
                Objects(x).D2starter = EntryPointDBox.Text
            End If
            If Objects(x).CDkeySwap = Nothing Then
                Objects(x).CDkeySwap = 0
            End If


            Manager.ProfilesDataGrid.Rows(x).Cells(0).Value = Objects(x).ProfileName
            Me.Close()
            Return
        End If

        If ProfileNameTBox.Text = Nothing Then Return
        Dim NewObject As New Profiles
        NewObject.ProfileName = ProfileNameTBox.Text
        NewObject.D2Path = D2PathTBox.Text
        If WindowedCBox.Checked = True Then NewObject.WindowMode = 1
        If WindowedCBox.Checked = False Then NewObject.WindowMode = 0
        If NoSoundCBox.Checked = True Then NewObject.D2Sound = 1
        If NoSoundCBox.Checked = False Then NewObject.D2Sound = 0
        If LowQualityCBox.Checked = True Then NewObject.D2Quality = 1
        If LowQualityCBox.Checked = False Then NewObject.D2Quality = 0
        If DirectTextCBox.Checked = True Then NewObject.D2DirectText = 1
        If DirectTextCBox.Checked = False Then NewObject.D2DirectText = 0
        If MinimizedCBox.Checked = True Then NewObject.D2Minimized = 1
        If MinimizedCBox.Checked = False Then NewObject.D2Minimized = 0
        'NewObject.CDkeys = textBox3.Text
        NewObject.CDkeySwap = GamesPerKeyTBox.Text
        NewObject.AccountName = AccountNameTBox.Text
        'NewObject.AccPass - deliberately left out - we grab this when user selects run
        NewObject.D2PlayType = PlayTypeDBox.SelectedIndex
        NewObject.D2Difficulty = DifficultyDBox.SelectedIndex

        If ServerDBox.Text = "U.S.West" Then NewObject.Realm = 1
        If ServerDBox.Text = "U.S.East" Then NewObject.Realm = 2
        If ServerDBox.Text = "Asia" Then NewObject.Realm = 3
        If ServerDBox.Text = "Europe" Then NewObject.Realm = 4

        If RandomGameNameCBox.Checked = True Then NewObject.randomGame = 1
        If RandomGameNameCBox.Checked = False Then NewObject.randomGame = 0
        If RandomGamePasswordCBox.Checked = True Then NewObject.randompass = 1
        If RandomGamePasswordCBox.Checked = False Then NewObject.randompass = 0
        NewObject.GameName = GameNameTBox.Text
        NewObject.GamePass = GamePasswordTBox.Text
        If radioButton1.Checked = True Then NewObject.CharPosition = 0
        If radioButton2.Checked = True Then NewObject.CharPosition = 1
        If radioButton3.Checked = True Then NewObject.CharPosition = 2
        If radioButton4.Checked = True Then NewObject.CharPosition = 3
        If radioButton5.Checked = True Then NewObject.CharPosition = 4
        If radioButton6.Checked = True Then NewObject.CharPosition = 5
        If radioButton7.Checked = True Then NewObject.CharPosition = 6
        If radioButton8.Checked = True Then NewObject.CharPosition = 7
        If EntryPointDBox.SelectedIndex = 0 Then NewObject.D2starter = ""
        If EntryPointDBox.SelectedIndex > 0 Then NewObject.D2starter = EntryPointDBox.SelectedText

        Objects.Add(NewObject)

        Manager.ProfilesDataGrid.Rows(Objects.Count - 1).Cells(0).Value = Objects(Objects.Count - 1).ProfileName

        Me.Close()
    End Sub

    Private Sub RandomGameNameCBox_CheckedChanged(sender As Object, e As EventArgs) Handles RandomGameNameCBox.CheckedChanged
        If RandomGameNameCBox.Checked = True Then
            GameNameTBox.Enabled = False
        End If
        If RandomGameNameCBox.Checked = False Then
            GameNameTBox.Enabled = True
        End If
    End Sub

    Private Sub RandomGamePasswordCBox_CheckedChanged(sender As Object, e As EventArgs) Handles RandomGamePasswordCBox.CheckedChanged
        If RandomGamePasswordCBox.Checked = True Then
            GamePasswordTBox.Enabled = False
        End If
        If RandomGamePasswordCBox.Checked = False Then
            GamePasswordTBox.Enabled = True
        End If
    End Sub

    Private Sub ProfileEditor_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.Left = Manager.Left + 20
        'Me.Top = Manager.Top + 80
        CDKeysDataGrid.Rows.Clear()

        EntryPointDBox.Items.Clear()
        EntryPointDBox.Items.Add("Loader only")
        EntryPointDBox.SelectedIndex = 0

        If Directory.Exists(Application.StartupPath & "/scripts") Then
            For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath + "\scripts", FileIO.SearchOption.SearchTopLevelOnly, "*.ntj")
                Dim str As Array = foundFile.Split("\")
                Dim temp As String = str(str.Length - 1)
                If temp.Length < 62 Then
                    EntryPointDBox.Items.Add(temp)
                End If
            Next
        End If


        If ProfileEditoraction = "edit" Then

            Dim x As Integer = Manager.ProfilesDataGrid.CurrentRow.Index

            'MessageBox.Show("Value = " & x, "edit debug")
            ProfileNameTBox.Text = Objects(x).ProfileName
            D2PathTBox.Text = Objects(x).D2Path
            WindowedCBox.Checked = Objects(x).WindowMode
            NoSoundCBox.Checked = Objects(x).D2Sound
            LowQualityCBox.Checked = Objects(x).D2Quality
            DirectTextCBox.Checked = Objects(x).D2DirectText
            MinimizedCBox.Checked = Objects(x).D2Minimized
            'textBox3.Text = Objects(x).CDkeys
            GamesPerKeyTBox.Text = Objects(x).CDkeySwap
            AccountNameTBox.Text = Objects(x).AccountName
            'NewObject.AccPass - deliberately left out - we grab this when user selects run
            PlayTypeDBox.SelectedIndex = Objects(x).D2PlayType
            DifficultyDBox.SelectedIndex = Objects(x).D2Difficulty
            ServerDBox.SelectedIndex = Objects(x).Realm - 1
            GameNameTBox.Text = Objects(x).GameName
            GamePasswordTBox.Text = Objects(x).GamePass
            RandomGameNameCBox.Checked = Objects(x).randomGame
            RandomGamePasswordCBox.Checked = Objects(x).randompass
            If Objects(x).CharPosition = 0 Then radioButton1.Checked = True
            If Objects(x).CharPosition = 1 Then radioButton2.Checked = True
            If Objects(x).CharPosition = 2 Then radioButton3.Checked = True
            If Objects(x).CharPosition = 3 Then radioButton4.Checked = True
            If Objects(x).CharPosition = 4 Then radioButton5.Checked = True
            If Objects(x).CharPosition = 5 Then radioButton6.Checked = True
            If Objects(x).CharPosition = 6 Then radioButton7.Checked = True
            If Objects(x).CharPosition = 7 Then radioButton8.Checked = True
            For y = 0 To EntryPointDBox.Items.Count - 1
                If Objects(x).D2starter = EntryPointDBox.Items(y) Then EntryPointDBox.SelectedIndex = y
            Next
            If EntryPointDBox.SelectedIndex < 0 Then EntryPointDBox.Text = "Loader Only"

            displaykeys(x)
            Return
        End If
        ProfileNameTBox.Clear()
        D2PathTBox.Clear()
        WindowedCBox.Checked = True
        NoSoundCBox.Checked = False
        LowQualityCBox.Checked = False
        DirectTextCBox.Checked = False
        MinimizedCBox.Checked = False
        AccountNameTBox.Clear()
        GamesPerKeyTBox.Text = "0"
        EntryPointDBox.SelectedIndex = 0
        PlayTypeDBox.SelectedIndex = 0
        ServerDBox.SelectedIndex = 0
        DifficultyDBox.SelectedIndex = 0
        GamePasswordTBox.Enabled = False
        GameNameTBox.Enabled = False
        RandomGamePasswordCBox.Checked = True
        RandomGameNameCBox.Checked = True
        radioButton1.Checked = True
    End Sub

    Private Sub AddKeyButton_Click(sender As Object, e As EventArgs) Handles AddKeyButton.Click
        If D2PathTBox.Text = Nothing Then
            MessageBox.Show("You need to set Diablo folder first")
            Return
        End If
        Dim x = Manager.ProfilesDataGrid.CurrentRow.Index
        AddRawKeys.ShowDialog()
        displaykeys(x)
    End Sub

    Private Sub displaykeys(ByVal x)


        If Objects(x).CDkeyOwner = Nothing Then Return
        CDKeysDataGrid.Rows.Clear()

        Dim temp = Objects(x).CDkeyOwner.Split(";")
        Dim temp1 = Objects(x).CDkeyClassic.Split(";")
        Dim temp2 = Objects(x).CDkeyExpansion.Split(";")
        For index = 0 To temp.Length - 1
            CDKeysDataGrid.Rows.Add(temp(index), temp1(index), temp2(index))
        Next

    End Sub

    Private Sub RemoveKeyButton_Click(sender As Object, e As EventArgs) Handles RemoveKeyButton.Click
        If CDKeysDataGrid.Rows.Count <= 0 Then
            Return
        End If
        Dim x = CDKeysDataGrid.CurrentRow.Index
        CDKeysDataGrid.Rows.RemoveAt(x)

    End Sub

    Private Sub ProfileEditor_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ProfileNameTBox.Focus()
    End Sub

End Class