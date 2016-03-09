<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProfileEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProfileEditor))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.button4 = New System.Windows.Forms.Button()
        Me.OkAcceptButton = New System.Windows.Forms.Button()
        Me.label14 = New System.Windows.Forms.Label()
        Me.RandomGamePasswordCBox = New System.Windows.Forms.CheckBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.RandomGameNameCBox = New System.Windows.Forms.CheckBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.GamePasswordTBox = New System.Windows.Forms.TextBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.GameNameTBox = New System.Windows.Forms.TextBox()
        Me.EntryPointDBox = New System.Windows.Forms.ComboBox()
        Me.radioButton1 = New System.Windows.Forms.RadioButton()
        Me.radioButton3 = New System.Windows.Forms.RadioButton()
        Me.radioButton5 = New System.Windows.Forms.RadioButton()
        Me.radioButton8 = New System.Windows.Forms.RadioButton()
        Me.radioButton2 = New System.Windows.Forms.RadioButton()
        Me.radioButton7 = New System.Windows.Forms.RadioButton()
        Me.radioButton4 = New System.Windows.Forms.RadioButton()
        Me.radioButton6 = New System.Windows.Forms.RadioButton()
        Me.ServerDBox = New System.Windows.Forms.ComboBox()
        Me.DifficultyDBox = New System.Windows.Forms.ComboBox()
        Me.PlayTypeDBox = New System.Windows.Forms.ComboBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.AccountNameTBox = New System.Windows.Forms.TextBox()
        Me.WindowedCBox = New System.Windows.Forms.CheckBox()
        Me.AutoDetedPathButton = New System.Windows.Forms.Button()
        Me.ManualSeekPathButton = New System.Windows.Forms.Button()
        Me.labelD2Path = New System.Windows.Forms.Label()
        Me.D2PathTBox = New System.Windows.Forms.TextBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.NoSoundCBox = New System.Windows.Forms.CheckBox()
        Me.LabelProfileName = New System.Windows.Forms.Label()
        Me.ProfileNameTBox = New System.Windows.Forms.TextBox()
        Me.LowQualityCBox = New System.Windows.Forms.CheckBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.MinimizedCBox = New System.Windows.Forms.CheckBox()
        Me.DirectTextCBox = New System.Windows.Forms.CheckBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.GamesPerKeyTBox = New System.Windows.Forms.TextBox()
        Me.RemoveKeyButton = New System.Windows.Forms.Button()
        Me.AddKeyButton = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClassicKeys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpansionKeys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.groupBox2.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(389, 585)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(85, 28)
        Me.button4.TabIndex = 32
        Me.button4.Text = "Cancel"
        Me.ToolTip1.SetToolTip(Me.button4, "Discard changes and close this window")
        Me.button4.UseVisualStyleBackColor = True
        '
        'OkAcceptButton
        '
        Me.OkAcceptButton.Location = New System.Drawing.Point(22, 585)
        Me.OkAcceptButton.Name = "OkAcceptButton"
        Me.OkAcceptButton.Size = New System.Drawing.Size(85, 28)
        Me.OkAcceptButton.TabIndex = 31
        Me.OkAcceptButton.Text = "OK"
        Me.ToolTip1.SetToolTip(Me.OkAcceptButton, "Accept changes to this profiles setings")
        Me.OkAcceptButton.UseVisualStyleBackColor = True
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(16, 82)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(113, 13)
        Me.label14.TabIndex = 47
        Me.label14.Text = "Entry Point/Starter File"
        '
        'RandomGamePasswordCBox
        '
        Me.RandomGamePasswordCBox.AutoSize = True
        Me.RandomGamePasswordCBox.Location = New System.Drawing.Point(337, 111)
        Me.RandomGamePasswordCBox.Name = "RandomGamePasswordCBox"
        Me.RandomGamePasswordCBox.Size = New System.Drawing.Size(66, 17)
        Me.RandomGamePasswordCBox.TabIndex = 19
        Me.RandomGamePasswordCBox.Text = "Random"
        Me.ToolTip1.SetToolTip(Me.RandomGamePasswordCBox, "A random password will be created for games")
        Me.RandomGamePasswordCBox.UseVisualStyleBackColor = True
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(159, 113)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(56, 13)
        Me.label12.TabIndex = 46
        Me.label12.Text = "Game PW"
        '
        'RandomGameNameCBox
        '
        Me.RandomGameNameCBox.AutoSize = True
        Me.RandomGameNameCBox.Location = New System.Drawing.Point(337, 80)
        Me.RandomGameNameCBox.Name = "RandomGameNameCBox"
        Me.RandomGameNameCBox.Size = New System.Drawing.Size(66, 17)
        Me.RandomGameNameCBox.TabIndex = 18
        Me.RandomGameNameCBox.Text = "Random"
        Me.ToolTip1.SetToolTip(Me.RandomGameNameCBox, "A random game name will be created for you")
        Me.RandomGameNameCBox.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label14)
        Me.groupBox2.Controls.Add(Me.RandomGamePasswordCBox)
        Me.groupBox2.Controls.Add(Me.label12)
        Me.groupBox2.Controls.Add(Me.RandomGameNameCBox)
        Me.groupBox2.Controls.Add(Me.GamePasswordTBox)
        Me.groupBox2.Controls.Add(Me.label13)
        Me.groupBox2.Controls.Add(Me.GameNameTBox)
        Me.groupBox2.Controls.Add(Me.EntryPointDBox)
        Me.groupBox2.Controls.Add(Me.radioButton1)
        Me.groupBox2.Controls.Add(Me.radioButton3)
        Me.groupBox2.Controls.Add(Me.radioButton5)
        Me.groupBox2.Controls.Add(Me.radioButton8)
        Me.groupBox2.Controls.Add(Me.radioButton2)
        Me.groupBox2.Controls.Add(Me.radioButton7)
        Me.groupBox2.Controls.Add(Me.radioButton4)
        Me.groupBox2.Controls.Add(Me.radioButton6)
        Me.groupBox2.Controls.Add(Me.ServerDBox)
        Me.groupBox2.Controls.Add(Me.DifficultyDBox)
        Me.groupBox2.Controls.Add(Me.PlayTypeDBox)
        Me.groupBox2.Controls.Add(Me.label11)
        Me.groupBox2.Controls.Add(Me.label10)
        Me.groupBox2.Controls.Add(Me.label9)
        Me.groupBox2.Controls.Add(Me.label8)
        Me.groupBox2.Controls.Add(Me.label7)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.AccountNameTBox)
        Me.groupBox2.Location = New System.Drawing.Point(12, 231)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(480, 146)
        Me.groupBox2.TabIndex = 25
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Game Settings"
        '
        'GamePasswordTBox
        '
        Me.GamePasswordTBox.Location = New System.Drawing.Point(221, 109)
        Me.GamePasswordTBox.MaxLength = 7
        Me.GamePasswordTBox.Name = "GamePasswordTBox"
        Me.GamePasswordTBox.Size = New System.Drawing.Size(100, 20)
        Me.GamePasswordTBox.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.GamePasswordTBox, "Enter a password to play privately online")
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(149, 82)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(66, 13)
        Me.label13.TabIndex = 45
        Me.label13.Text = "Game Name"
        '
        'GameNameTBox
        '
        Me.GameNameTBox.Location = New System.Drawing.Point(221, 78)
        Me.GameNameTBox.Name = "GameNameTBox"
        Me.GameNameTBox.Size = New System.Drawing.Size(100, 20)
        Me.GameNameTBox.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.GameNameTBox, "Enter a name for games")
        '
        'EntryPointDBox
        '
        Me.EntryPointDBox.BackColor = System.Drawing.SystemColors.Control
        Me.EntryPointDBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EntryPointDBox.FormattingEnabled = True
        Me.EntryPointDBox.Location = New System.Drawing.Point(16, 109)
        Me.EntryPointDBox.Name = "EntryPointDBox"
        Me.EntryPointDBox.Size = New System.Drawing.Size(121, 21)
        Me.EntryPointDBox.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.EntryPointDBox, resources.GetString("EntryPointDBox.ToolTip"))
        '
        'radioButton1
        '
        Me.radioButton1.AutoSize = True
        Me.radioButton1.Checked = True
        Me.radioButton1.Location = New System.Drawing.Point(412, 48)
        Me.radioButton1.Name = "radioButton1"
        Me.radioButton1.Size = New System.Drawing.Size(31, 17)
        Me.radioButton1.TabIndex = 20
        Me.radioButton1.TabStop = True
        Me.radioButton1.Text = "1"
        Me.radioButton1.UseVisualStyleBackColor = True
        '
        'radioButton3
        '
        Me.radioButton3.AutoSize = True
        Me.radioButton3.Location = New System.Drawing.Point(412, 71)
        Me.radioButton3.Name = "radioButton3"
        Me.radioButton3.Size = New System.Drawing.Size(31, 17)
        Me.radioButton3.TabIndex = 22
        Me.radioButton3.Text = "3"
        Me.radioButton3.UseVisualStyleBackColor = True
        '
        'radioButton5
        '
        Me.radioButton5.AutoSize = True
        Me.radioButton5.Location = New System.Drawing.Point(412, 94)
        Me.radioButton5.Name = "radioButton5"
        Me.radioButton5.Size = New System.Drawing.Size(31, 17)
        Me.radioButton5.TabIndex = 24
        Me.radioButton5.Text = "5"
        Me.radioButton5.UseVisualStyleBackColor = True
        '
        'radioButton8
        '
        Me.radioButton8.AutoSize = True
        Me.radioButton8.Location = New System.Drawing.Point(443, 117)
        Me.radioButton8.Name = "radioButton8"
        Me.radioButton8.Size = New System.Drawing.Size(31, 17)
        Me.radioButton8.TabIndex = 27
        Me.radioButton8.Text = "8"
        Me.radioButton8.UseVisualStyleBackColor = True
        '
        'radioButton2
        '
        Me.radioButton2.AutoSize = True
        Me.radioButton2.Location = New System.Drawing.Point(443, 48)
        Me.radioButton2.Name = "radioButton2"
        Me.radioButton2.Size = New System.Drawing.Size(31, 17)
        Me.radioButton2.TabIndex = 21
        Me.radioButton2.Text = "2"
        Me.radioButton2.UseVisualStyleBackColor = True
        '
        'radioButton7
        '
        Me.radioButton7.AutoSize = True
        Me.radioButton7.Location = New System.Drawing.Point(412, 117)
        Me.radioButton7.Name = "radioButton7"
        Me.radioButton7.Size = New System.Drawing.Size(31, 17)
        Me.radioButton7.TabIndex = 26
        Me.radioButton7.Text = "7"
        Me.radioButton7.UseVisualStyleBackColor = True
        '
        'radioButton4
        '
        Me.radioButton4.AutoSize = True
        Me.radioButton4.Location = New System.Drawing.Point(443, 71)
        Me.radioButton4.Name = "radioButton4"
        Me.radioButton4.Size = New System.Drawing.Size(31, 17)
        Me.radioButton4.TabIndex = 23
        Me.radioButton4.Text = "4"
        Me.radioButton4.UseVisualStyleBackColor = True
        '
        'radioButton6
        '
        Me.radioButton6.AutoSize = True
        Me.radioButton6.Location = New System.Drawing.Point(443, 94)
        Me.radioButton6.Name = "radioButton6"
        Me.radioButton6.Size = New System.Drawing.Size(31, 17)
        Me.radioButton6.TabIndex = 25
        Me.radioButton6.Text = "6"
        Me.radioButton6.UseVisualStyleBackColor = True
        '
        'ServerDBox
        '
        Me.ServerDBox.BackColor = System.Drawing.SystemColors.Control
        Me.ServerDBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ServerDBox.FormattingEnabled = True
        Me.ServerDBox.Items.AddRange(New Object() {"U.S. West", "U.S. East", "Asia", "Europe"})
        Me.ServerDBox.Location = New System.Drawing.Point(307, 48)
        Me.ServerDBox.Name = "ServerDBox"
        Me.ServerDBox.Size = New System.Drawing.Size(76, 21)
        Me.ServerDBox.TabIndex = 17
        Me.ToolTip1.SetToolTip(Me.ServerDBox, "Select what realm on battle.net you wish to play")
        '
        'DifficultyDBox
        '
        Me.DifficultyDBox.BackColor = System.Drawing.SystemColors.Control
        Me.DifficultyDBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DifficultyDBox.FormattingEnabled = True
        Me.DifficultyDBox.Items.AddRange(New Object() {"Normal", "Nightmare", "Hell"})
        Me.DifficultyDBox.Location = New System.Drawing.Point(307, 19)
        Me.DifficultyDBox.Name = "DifficultyDBox"
        Me.DifficultyDBox.Size = New System.Drawing.Size(76, 21)
        Me.DifficultyDBox.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.DifficultyDBox, "Select a difficulty your char can handle")
        '
        'PlayTypeDBox
        '
        Me.PlayTypeDBox.BackColor = System.Drawing.SystemColors.Control
        Me.PlayTypeDBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PlayTypeDBox.FormattingEnabled = True
        Me.PlayTypeDBox.Items.AddRange(New Object() {"Single Player", "Battle.Net"})
        Me.PlayTypeDBox.Location = New System.Drawing.Point(131, 48)
        Me.PlayTypeDBox.Name = "PlayTypeDBox"
        Me.PlayTypeDBox.Size = New System.Drawing.Size(101, 21)
        Me.PlayTypeDBox.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.PlayTypeDBox, "Select single player for offline games" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Select Battle.net for online games")
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(419, 29)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(44, 13)
        Me.label11.TabIndex = 24
        Me.label11.Text = "Position"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(415, 10)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(53, 13)
        Me.label10.TabIndex = 23
        Me.label10.Text = "Character"
        Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(254, 52)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(38, 13)
        Me.label9.TabIndex = 21
        Me.label9.Text = "Server"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(254, 21)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(47, 13)
        Me.label8.TabIndex = 22
        Me.label8.Text = "Difficulty"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(131, 21)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(54, 13)
        Me.label7.TabIndex = 21
        Me.label7.Text = "Play Type"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(16, 21)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(78, 13)
        Me.label6.TabIndex = 20
        Me.label6.Text = "Account Name"
        '
        'AccountNameTBox
        '
        Me.AccountNameTBox.Location = New System.Drawing.Point(16, 48)
        Me.AccountNameTBox.Name = "AccountNameTBox"
        Me.AccountNameTBox.Size = New System.Drawing.Size(100, 20)
        Me.AccountNameTBox.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.AccountNameTBox, "This must be the name used to login into your Battle Net account")
        '
        'WindowedCBox
        '
        Me.WindowedCBox.AutoSize = True
        Me.WindowedCBox.Location = New System.Drawing.Point(19, 48)
        Me.WindowedCBox.Name = "WindowedCBox"
        Me.WindowedCBox.Size = New System.Drawing.Size(95, 17)
        Me.WindowedCBox.TabIndex = 4
        Me.WindowedCBox.Text = "Window Mode"
        Me.WindowedCBox.UseVisualStyleBackColor = True
        '
        'AutoDetedPathButton
        '
        Me.AutoDetedPathButton.Location = New System.Drawing.Point(359, 17)
        Me.AutoDetedPathButton.Name = "AutoDetedPathButton"
        Me.AutoDetedPathButton.Size = New System.Drawing.Size(111, 23)
        Me.AutoDetedPathButton.TabIndex = 3
        Me.AutoDetedPathButton.Text = "Auto Detection"
        Me.ToolTip1.SetToolTip(Me.AutoDetedPathButton, "Tries to locate Diablo II installation folder" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If path doesn't appear you will ne" &
        "ed to use the beside this one")
        Me.AutoDetedPathButton.UseVisualStyleBackColor = True
        '
        'ManualSeekPathButton
        '
        Me.ManualSeekPathButton.Location = New System.Drawing.Point(313, 17)
        Me.ManualSeekPathButton.Name = "ManualSeekPathButton"
        Me.ManualSeekPathButton.Size = New System.Drawing.Size(42, 23)
        Me.ManualSeekPathButton.TabIndex = 2
        Me.ManualSeekPathButton.Text = "..."
        Me.ToolTip1.SetToolTip(Me.ManualSeekPathButton, "Search for Diablo II folder if Auto Detection fails")
        Me.ManualSeekPathButton.UseVisualStyleBackColor = True
        '
        'labelD2Path
        '
        Me.labelD2Path.AutoSize = True
        Me.labelD2Path.Location = New System.Drawing.Point(15, 22)
        Me.labelD2Path.Name = "labelD2Path"
        Me.labelD2Path.Size = New System.Drawing.Size(43, 13)
        Me.labelD2Path.TabIndex = 5
        Me.labelD2Path.Text = "D2Path"
        '
        'D2PathTBox
        '
        Me.D2PathTBox.BackColor = System.Drawing.SystemColors.Control
        Me.D2PathTBox.Location = New System.Drawing.Point(62, 18)
        Me.D2PathTBox.Name = "D2PathTBox"
        Me.D2PathTBox.Size = New System.Drawing.Size(247, 20)
        Me.D2PathTBox.TabIndex = 44
        Me.D2PathTBox.TabStop = False
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(505, 105)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox1.TabIndex = 21
        Me.pictureBox1.TabStop = False
        '
        'NoSoundCBox
        '
        Me.NoSoundCBox.AutoSize = True
        Me.NoSoundCBox.Location = New System.Drawing.Point(124, 48)
        Me.NoSoundCBox.Name = "NoSoundCBox"
        Me.NoSoundCBox.Size = New System.Drawing.Size(74, 17)
        Me.NoSoundCBox.TabIndex = 5
        Me.NoSoundCBox.Text = "No Sound"
        Me.NoSoundCBox.UseVisualStyleBackColor = True
        '
        'LabelProfileName
        '
        Me.LabelProfileName.AutoSize = True
        Me.LabelProfileName.Location = New System.Drawing.Point(18, 116)
        Me.LabelProfileName.Name = "LabelProfileName"
        Me.LabelProfileName.Size = New System.Drawing.Size(67, 13)
        Me.LabelProfileName.TabIndex = 23
        Me.LabelProfileName.Text = "Profile Name"
        '
        'ProfileNameTBox
        '
        Me.ProfileNameTBox.Location = New System.Drawing.Point(101, 113)
        Me.ProfileNameTBox.Name = "ProfileNameTBox"
        Me.ProfileNameTBox.Size = New System.Drawing.Size(205, 20)
        Me.ProfileNameTBox.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.ProfileNameTBox, "Name for your profile " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "this can be anything you wish," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "use a word or name that h" &
        "elps distinguis from other profiles" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'LowQualityCBox
        '
        Me.LowQualityCBox.AutoSize = True
        Me.LowQualityCBox.Location = New System.Drawing.Point(208, 48)
        Me.LowQualityCBox.Name = "LowQualityCBox"
        Me.LowQualityCBox.Size = New System.Drawing.Size(81, 17)
        Me.LowQualityCBox.TabIndex = 6
        Me.LowQualityCBox.Text = "Low Quality"
        Me.LowQualityCBox.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.MinimizedCBox)
        Me.groupBox1.Controls.Add(Me.DirectTextCBox)
        Me.groupBox1.Controls.Add(Me.LowQualityCBox)
        Me.groupBox1.Controls.Add(Me.NoSoundCBox)
        Me.groupBox1.Controls.Add(Me.WindowedCBox)
        Me.groupBox1.Controls.Add(Me.AutoDetedPathButton)
        Me.groupBox1.Controls.Add(Me.ManualSeekPathButton)
        Me.groupBox1.Controls.Add(Me.labelD2Path)
        Me.groupBox1.Controls.Add(Me.D2PathTBox)
        Me.groupBox1.Location = New System.Drawing.Point(12, 140)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(480, 85)
        Me.groupBox1.TabIndex = 24
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Loader Settings"
        '
        'MinimizedCBox
        '
        Me.MinimizedCBox.AutoSize = True
        Me.MinimizedCBox.Location = New System.Drawing.Point(381, 48)
        Me.MinimizedCBox.Name = "MinimizedCBox"
        Me.MinimizedCBox.Size = New System.Drawing.Size(89, 17)
        Me.MinimizedCBox.TabIndex = 8
        Me.MinimizedCBox.Text = "Minimized D2"
        Me.MinimizedCBox.UseVisualStyleBackColor = True
        '
        'DirectTextCBox
        '
        Me.DirectTextCBox.AutoSize = True
        Me.DirectTextCBox.Location = New System.Drawing.Point(299, 48)
        Me.DirectTextCBox.Name = "DirectTextCBox"
        Me.DirectTextCBox.Size = New System.Drawing.Size(72, 17)
        Me.DirectTextCBox.TabIndex = 7
        Me.DirectTextCBox.Text = "Direct Txt"
        Me.DirectTextCBox.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(171, 388)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(89, 13)
        Me.label5.TabIndex = 52
        Me.label5.Text = "Game # / CDKey"
        '
        'GamesPerKeyTBox
        '
        Me.GamesPerKeyTBox.Location = New System.Drawing.Point(264, 384)
        Me.GamesPerKeyTBox.Name = "GamesPerKeyTBox"
        Me.GamesPerKeyTBox.Size = New System.Drawing.Size(30, 20)
        Me.GamesPerKeyTBox.TabIndex = 29
        Me.GamesPerKeyTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RemoveKeyButton
        '
        Me.RemoveKeyButton.Location = New System.Drawing.Point(25, 381)
        Me.RemoveKeyButton.Name = "RemoveKeyButton"
        Me.RemoveKeyButton.Size = New System.Drawing.Size(101, 23)
        Me.RemoveKeyButton.TabIndex = 28
        Me.RemoveKeyButton.Text = "Remove Key Set"
        Me.ToolTip1.SetToolTip(Me.RemoveKeyButton, "Deletes the selected Key set or mpq file")
        Me.RemoveKeyButton.UseVisualStyleBackColor = True
        '
        'AddKeyButton
        '
        Me.AddKeyButton.Location = New System.Drawing.Point(380, 381)
        Me.AddKeyButton.Name = "AddKeyButton"
        Me.AddKeyButton.Size = New System.Drawing.Size(100, 23)
        Me.AddKeyButton.TabIndex = 30
        Me.AddKeyButton.Text = "Add Key Set"
        Me.ToolTip1.SetToolTip(Me.AddKeyButton, "Click here to add CdKey sets or mpq files")
        Me.AddKeyButton.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.ClassicKeys, Me.ExpansionKeys})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(12, 415)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(480, 156)
        Me.DataGridView1.TabIndex = 33
        Me.DataGridView1.TabStop = False
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "Mpq/owner"
        Me.Column1.MaxInputLength = 32
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ClassicKeys
        '
        Me.ClassicKeys.FillWeight = 210.0!
        Me.ClassicKeys.Frozen = True
        Me.ClassicKeys.HeaderText = "Classic"
        Me.ClassicKeys.MaxInputLength = 26
        Me.ClassicKeys.Name = "ClassicKeys"
        Me.ClassicKeys.ReadOnly = True
        Me.ClassicKeys.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ClassicKeys.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.ClassicKeys.Width = 210
        '
        'ExpansionKeys
        '
        Me.ExpansionKeys.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ExpansionKeys.FillWeight = 210.0!
        Me.ExpansionKeys.Frozen = True
        Me.ExpansionKeys.HeaderText = "Expansion"
        Me.ExpansionKeys.MaxInputLength = 26
        Me.ExpansionKeys.Name = "ExpansionKeys"
        Me.ExpansionKeys.ReadOnly = True
        Me.ExpansionKeys.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ExpansionKeys.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.ExpansionKeys.Width = 210
        '
        'ProfileEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 622)
        Me.ControlBox = False
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.GamesPerKeyTBox)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.AddKeyButton)
        Me.Controls.Add(Me.button4)
        Me.Controls.Add(Me.OkAcceptButton)
        Me.Controls.Add(Me.RemoveKeyButton)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.LabelProfileName)
        Me.Controls.Add(Me.ProfileNameTBox)
        Me.Controls.Add(Me.groupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(520, 661)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(520, 661)
        Me.Name = "ProfileEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Profile Settings"
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents button4 As System.Windows.Forms.Button
    Private WithEvents OkAcceptButton As System.Windows.Forms.Button
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents RandomGamePasswordCBox As System.Windows.Forms.CheckBox
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents RandomGameNameCBox As System.Windows.Forms.CheckBox
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents GamePasswordTBox As System.Windows.Forms.TextBox
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents GameNameTBox As System.Windows.Forms.TextBox
    Private WithEvents EntryPointDBox As System.Windows.Forms.ComboBox
    Private WithEvents radioButton1 As System.Windows.Forms.RadioButton
    Private WithEvents radioButton3 As System.Windows.Forms.RadioButton
    Private WithEvents radioButton5 As System.Windows.Forms.RadioButton
    Private WithEvents radioButton8 As System.Windows.Forms.RadioButton
    Private WithEvents radioButton2 As System.Windows.Forms.RadioButton
    Private WithEvents radioButton7 As System.Windows.Forms.RadioButton
    Private WithEvents radioButton4 As System.Windows.Forms.RadioButton
    Private WithEvents radioButton6 As System.Windows.Forms.RadioButton
    Private WithEvents ServerDBox As System.Windows.Forms.ComboBox
    Private WithEvents DifficultyDBox As System.Windows.Forms.ComboBox
    Private WithEvents PlayTypeDBox As System.Windows.Forms.ComboBox
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents AccountNameTBox As System.Windows.Forms.TextBox
    Private WithEvents WindowedCBox As System.Windows.Forms.CheckBox
    Private WithEvents AutoDetedPathButton As System.Windows.Forms.Button
    Private WithEvents ManualSeekPathButton As System.Windows.Forms.Button
    Private WithEvents labelD2Path As System.Windows.Forms.Label
    Private WithEvents D2PathTBox As System.Windows.Forms.TextBox
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents NoSoundCBox As System.Windows.Forms.CheckBox
    Private WithEvents LabelProfileName As System.Windows.Forms.Label
    Private WithEvents ProfileNameTBox As System.Windows.Forms.TextBox
    Private WithEvents LowQualityCBox As System.Windows.Forms.CheckBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents GamesPerKeyTBox As System.Windows.Forms.TextBox
    Private WithEvents MinimizedCBox As System.Windows.Forms.CheckBox
    Private WithEvents DirectTextCBox As System.Windows.Forms.CheckBox
    Friend WithEvents RemoveKeyButton As Button
    Friend WithEvents AddKeyButton As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents ClassicKeys As DataGridViewTextBoxColumn
    Friend WithEvents ExpansionKeys As DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As ToolTip
End Class
