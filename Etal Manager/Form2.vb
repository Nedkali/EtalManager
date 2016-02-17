Imports System.Collections.ObjectModel

Public Class Form2

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click
        Dim key As Microsoft.Win32.RegistryKey

        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Blizzard Entertainment\Diablo II")
        If key Is Nothing Then
            RegErrorAck()
            Return
        End If

        Dim D2Path As String = key.GetValue("InstallPath").ToString()
        D2Path = D2Path & "\Game.exe"
        D2Path.Replace("\\", "\")
        textBox2.Text = D2Path
    End Sub

    Private Sub RegErrorAck()
        MessageBox.Show("Unable to locate Registry entry", "ERROR", MessageBoxButtons.OK)
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim D2Path As String = "C:\"
        Dim openFileDialog1 As OpenFileDialog = New OpenFileDialog
        openFileDialog1.Filter = "Loader files|Game.exe|All files|*.*"
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            D2Path = openFileDialog1.FileName
            textBox2.Text = D2Path
        End If
    End Sub

    Private Sub button4_Click(sender As Object, e As EventArgs) Handles button4.Click
        Me.Close()
    End Sub


    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click
        If textBox1.Text = "" Then
            MessageBox.Show("Profile name not set", "Error")
            Return
        End If
        If textBox2.Text = "" Then
            MessageBox.Show("Game Path not Entered", "Error")
            Return
        End If
        If textBox5.Text = "" Then
            MessageBox.Show("Account Name not Entered", "Error")
            Return
        End If



        If form2action = "edit" Then
            Dim x As Integer = Form1.dataGridView1.CurrentRow.Index
            Objects(x).ProfileName = textBox1.Text
            Objects(x).D2Path = textBox2.Text
            If checkBox1.Checked = True Then Objects(x).WindowMode = 1
            If checkBox1.Checked = False Then Objects(x).WindowMode = 0
            If checkBox2.Checked = True Then Objects(x).D2Sound = 1
            If checkBox2.Checked = False Then Objects(x).D2Sound = 0
            If checkBox3.Checked = True Then Objects(x).D2Quality = 1
            If checkBox3.Checked = False Then Objects(x).D2Quality = 0
            If checkBox4.Checked = True Then Objects(x).D2DirectText = 1
            If checkBox4.Checked = False Then Objects(x).D2DirectText = 0
            If checkBox5.Checked = True Then Objects(x).D2Minimized = 1
            If checkBox5.Checked = False Then Objects(x).D2Minimized = 0
            Objects(x).CDkeys = textBox3.Text
            Objects(x).CDkeySwap = textBox4.Text
            Objects(x).AccountName = textBox5.Text
            'NewObject.AccPass - deliberately left out - we grab this when user selects run
            Objects(x).D2PlayType = comboBox2.SelectedIndex
            Objects(x).D2Difficulty = comboBox4.SelectedIndex
            Objects(x).Realm = comboBox3.SelectedIndex
            If checkBox7.Checked = True Then Objects(x).randomGame = 1
            If checkBox7.Checked = False Then Objects(x).randomGame = 0
            If checkBox6.Checked = True Then Objects(x).randompass = 1
            If checkBox6.Checked = False Then Objects(x).randompass = 0
            Objects(x).GameName = textBox7.Text
            Objects(x).GamePass = textBox6.Text
            If radioButton1.Checked = True Then Objects(x).CharPosition = 0
            If radioButton2.Checked = True Then Objects(x).CharPosition = 1
            If radioButton3.Checked = True Then Objects(x).CharPosition = 2
            If radioButton4.Checked = True Then Objects(x).CharPosition = 3
            If radioButton5.Checked = True Then Objects(x).CharPosition = 4
            If radioButton6.Checked = True Then Objects(x).CharPosition = 5
            If radioButton7.Checked = True Then Objects(x).CharPosition = 6
            If radioButton8.Checked = True Then Objects(x).CharPosition = 7
            If comboBox1.Text = "Loader Only" Then
                Objects(x).D2starter = ""
            Else
                Objects(x).D2starter = comboBox1.Text
            End If



            Form1.dataGridView1.Rows(x).Cells(0).Value = Objects(x).ProfileName
            Me.Close()
            Return
        End If

        Return
        If textBox1.Text = Nothing Then Return
        Dim NewObject As New Profiles
        NewObject.ProfileName = textBox1.Text
        NewObject.D2Path = textBox2.Text
        If checkBox1.Checked = True Then NewObject.WindowMode = 1
        If checkBox1.Checked = False Then NewObject.WindowMode = 0
        If checkBox2.Checked = True Then NewObject.D2Sound = 1
        If checkBox2.Checked = False Then NewObject.D2Sound = 0
        If checkBox3.Checked = True Then NewObject.D2Quality = 1
        If checkBox3.Checked = False Then NewObject.D2Quality = 0
        If checkBox4.Checked = True Then NewObject.D2DirectText = 1
        If checkBox4.Checked = False Then NewObject.D2DirectText = 0
        If checkBox5.Checked = True Then NewObject.D2Minimized = 1
        If checkBox5.Checked = False Then NewObject.D2Minimized = 0
        NewObject.CDkeys = textBox3.Text
        NewObject.CDkeySwap = textBox4.Text
        NewObject.AccountName = textBox5.Text
        'NewObject.AccPass - deliberately left out - we grab this when user selects run
        NewObject.D2PlayType = comboBox2.SelectedIndex
        NewObject.D2Difficulty = comboBox4.SelectedIndex
        NewObject.Realm = comboBox3.SelectedIndex
        If checkBox7.Checked = True Then NewObject.randomGame = 1
        If checkBox7.Checked = False Then NewObject.randomGame = 0
        If checkBox6.Checked = True Then NewObject.randompass = 1
        If checkBox6.Checked = False Then NewObject.randompass = 0
        NewObject.GameName = textBox7.Text
        NewObject.GamePass = textBox6.Text
        If radioButton1.Checked = True Then NewObject.CharPosition = 0
        If radioButton2.Checked = True Then NewObject.CharPosition = 1
        If radioButton3.Checked = True Then NewObject.CharPosition = 2
        If radioButton4.Checked = True Then NewObject.CharPosition = 3
        If radioButton5.Checked = True Then NewObject.CharPosition = 4
        If radioButton6.Checked = True Then NewObject.CharPosition = 5
        If radioButton7.Checked = True Then NewObject.CharPosition = 6
        If radioButton8.Checked = True Then NewObject.CharPosition = 7
        If comboBox1.SelectedIndex = 0 Then NewObject.D2starter = ""
        If comboBox1.SelectedIndex > 0 Then NewObject.D2starter = comboBox1.SelectedText

        Objects.Add(NewObject)

        Form1.dataGridView1.Rows(Objects.Count - 1).Cells(0).Value = Objects(Objects.Count - 1).ProfileName ' testing purpose only

        Me.Close()
    End Sub

    Private Sub checkBox7_CheckedChanged(sender As Object, e As EventArgs) Handles checkBox7.CheckedChanged
        If checkBox7.Checked = True Then
            textBox7.Enabled = False
        End If
        If checkBox7.Checked = False Then
            textBox7.Enabled = True
        End If
    End Sub

    Private Sub checkBox6_CheckedChanged(sender As Object, e As EventArgs) Handles checkBox6.CheckedChanged
        If checkBox6.Checked = True Then
            textBox6.Enabled = False
        End If
        If checkBox6.Checked = False Then
            textBox6.Enabled = True
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.Left = Form1.Left + 20
        'Me.Top = Form1.Top + 80
        comboBox1.Items.Clear()
        comboBox1.Items.Add("Loader only")
        comboBox1.SelectedIndex = 0
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(Application.StartupPath + "\scripts", FileIO.SearchOption.SearchTopLevelOnly, "*.ntj")
            Dim str As Array = foundFile.Split("\")
            Dim temp As String = str(str.Length - 1)
            If temp.Length < 62 Then
                comboBox1.Items.Add(temp)
            End If

        Next

        If form2action <> "edit" Then
            Objects.Add(New Profiles)
            Form1.dataGridView1.Rows(Objects.Count - 1).Selected = True
            Form1.dataGridView1.CurrentCell = Form1.dataGridView1.Item(0, Objects.Count - 1)
            form2action = "edit"
        End If

        If form2action = "edit" Then

            Dim x As Integer = Form1.dataGridView1.CurrentRow.Index

            'MessageBox.Show("Value = " & x, "edit debug")
            textBox1.Text = Objects(x).ProfileName
            textBox2.Text = Objects(x).D2Path
            checkBox1.Checked = Objects(x).WindowMode
            checkBox2.Checked = Objects(x).D2Sound
            checkBox3.Checked = Objects(x).D2Quality
            checkBox4.Checked = Objects(x).D2DirectText
            checkBox5.Checked = Objects(x).D2Minimized
            textBox3.Text = Objects(x).CDkeys
            textBox4.Text = Objects(x).CDkeySwap
            textBox5.Text = Objects(x).AccountName
            'NewObject.AccPass - deliberately left out - we grab this when user selects run
            comboBox2.SelectedIndex = Objects(x).D2PlayType
            comboBox4.SelectedIndex = Objects(x).D2Difficulty
            comboBox3.SelectedIndex = Objects(x).Realm
            textBox7.Text = Objects(x).GameName
            textBox6.Text = Objects(x).GamePass
            checkBox7.Checked = Objects(x).randomGame
            checkBox6.Checked = Objects(x).randompass
            If Objects(x).CharPosition = 0 Then radioButton1.Checked = True
            If Objects(x).CharPosition = 1 Then radioButton2.Checked = True
            If Objects(x).CharPosition = 2 Then radioButton3.Checked = True
            If Objects(x).CharPosition = 3 Then radioButton4.Checked = True
            If Objects(x).CharPosition = 4 Then radioButton5.Checked = True
            If Objects(x).CharPosition = 5 Then radioButton6.Checked = True
            If Objects(x).CharPosition = 6 Then radioButton7.Checked = True
            If Objects(x).CharPosition = 7 Then radioButton8.Checked = True
            For y = 0 To comboBox1.Items.Count - 1
                If Objects(x).D2starter = comboBox1.Items(y) Then comboBox1.SelectedIndex = y
            Next
            If comboBox1.SelectedIndex < 0 Then comboBox1.Text = "Loader Only"

            displaykeys(x)


            Return
        End If
        textBox1.Clear()
        textBox2.Clear()
        textBox3.Clear()
        checkBox1.Checked = True
        checkBox2.Checked = False
        checkBox3.Checked = False
        checkBox4.Checked = False
        checkBox5.Checked = False
        textBox5.Clear()
        textBox4.Text = "0"
        comboBox1.SelectedIndex = 0
        comboBox2.SelectedIndex = 0
        comboBox3.SelectedIndex = 0
        comboBox4.SelectedIndex = 0
        textBox6.Enabled = False
        textBox7.Enabled = False
        checkBox6.Checked = True
        checkBox7.Checked = True
        radioButton1.Checked = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim x = Form1.dataGridView1.CurrentRow.Index
        AddRawKeys.ShowDialog()
        displaykeys(x)
    End Sub

    Private Sub displaykeys(ByVal x)

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        If Objects(x).CDkeyOwner = Nothing Then Return

        Dim temp = Objects(x).CDkeyOwner.Split(";")
        For index = 0 To temp.Length - 1
            ListBox1.Items.Add(temp(index))
        Next

        temp = Objects(x).CDkeyClassic.Split(";")
        For index = 0 To temp.Length - 1
            ListBox2.Items.Add(temp(index))
        Next

        temp = Objects(x).CDkeyExpansion.Split(";")
        For index = 0 To temp.Length - 1
            ListBox3.Items.Add(temp(index))
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim keyindex = ListBox1.SelectedIndex
        Dim x As Integer = Form1.dataGridView1.CurrentRow.Index
        If ListBox1.SelectedItem.ToString() <> Nothing Then

            Dim temp As String = ListBox1.SelectedItem.ToString()
            Objects(x).CDkeyOwner = Objects(x).CDkeyOwner.Replace(temp, "")
            Objects(x).CDkeyOwner = Objects(x).CDkeyOwner.Replace(";;", "")
            temp = ListBox2.Items(keyindex).ToString()
            Objects(x).CDkeyClassic = Objects(x).CDkeyClassic.Replace(temp, "")
            Objects(x).CDkeyClassic = Objects(x).CDkeyClassic.Replace(";;", "")
            temp = ListBox3.Items(keyindex).ToString()
            Objects(x).CDkeyExpansion = Objects(x).CDkeyExpansion.Replace(temp, "")
            Objects(x).CDkeyExpansion = Objects(x).CDkeyExpansion.Replace(";;", "")
            CleanKeys(x)

        End If
        displaykeys(x)
        If ListBox1.Items.Count > 0 Then
            ListBox1.SelectedIndex = 0
        End If


    End Sub
    Private Sub CleanKeys(ByVal x)

        Objects(x).CDkeyOwner = Objects(x).CDkeyOwner.TrimEnd(";")
        Objects(x).CDkeyOwner = Objects(x).CDkeyOwner.TrimStart(";")

        Objects(x).CDkeyClassic = Objects(x).CDkeyClassic.TrimEnd(";")
        Objects(x).CDkeyClassic = Objects(x).CDkeyClassic.TrimStart(";")

        Objects(x).CDkeyExpansion = Objects(x).CDkeyExpansion.TrimEnd(";")
        Objects(x).CDkeyExpansion = Objects(x).CDkeyExpansion.TrimStart(";")


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox1.SelectedIndex
        ListBox3.SelectedIndex = ListBox1.SelectedIndex
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
        ListBox3.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox3.SelectedIndex
        ListBox2.SelectedIndex = ListBox3.SelectedIndex
    End Sub
End Class