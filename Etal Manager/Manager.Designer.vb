<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Manager
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Manager))
        Me.wwwetalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.ItemLog = New System.Windows.Forms.TabPage()
        Me.ItemTextBox = New System.Windows.Forms.RichTextBox()
        Me.CommonLogRTB = New System.Windows.Forms.RichTextBox()
        Me.CommonLog = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.ErrorReports = New System.Windows.Forms.TabPage()
        Me.ErrorTextBox = New System.Windows.Forms.RichTextBox()
        Me.linksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WikiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.EditButton = New System.Windows.Forms.Button()
        Me.AddButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.RunButton = New System.Windows.Forms.Button()
        Me.ProfilesDataGrid = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KeyFile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Deaths = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MoveDown = New System.Windows.Forms.Button()
        Me.MoveUp = New System.Windows.Forms.Button()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CopyButton = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ItemLog.SuspendLayout()
        Me.CommonLog.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.ErrorReports.SuspendLayout()
        CType(Me.ProfilesDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip1.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wwwetalToolStripMenuItem
        '
        Me.wwwetalToolStripMenuItem.Name = "wwwetalToolStripMenuItem"
        Me.wwwetalToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.wwwetalToolStripMenuItem.Text = "Web &Site"
        '
        'ExitButton
        '
        Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExitButton.Location = New System.Drawing.Point(206, 632)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(205, 27)
        Me.ExitButton.TabIndex = 8
        Me.ExitButton.Text = "E&xit"
        Me.ToolTip1.SetToolTip(Me.Exitbutton, "Closes Etal Manager")
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'ItemLog
        '
        Me.ItemLog.Controls.Add(Me.ItemTextBox)
        Me.ItemLog.Location = New System.Drawing.Point(4, 22)
        Me.ItemLog.Name = "ItemLog"
        Me.ItemLog.Padding = New System.Windows.Forms.Padding(3)
        Me.ItemLog.Size = New System.Drawing.Size(585, 243)
        Me.ItemLog.TabIndex = 1
        Me.ItemLog.Text = "Item Log"
        Me.ItemLog.UseVisualStyleBackColor = True
        '
        'ItemTextBox
        '
        Me.ItemTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemTextBox.Location = New System.Drawing.Point(3, 3)
        Me.ItemTextBox.Name = "ItemTextBox"
        Me.ItemTextBox.Size = New System.Drawing.Size(579, 237)
        Me.ItemTextBox.TabIndex = 0
        Me.ItemTextBox.Text = ""
        '
        'CommonLogRTB
        '
        Me.CommonLogRTB.Location = New System.Drawing.Point(3, 3)
        Me.CommonLogRTB.Name = "CommonLogRTB"
        Me.CommonLogRTB.Size = New System.Drawing.Size(579, 237)
        Me.CommonLogRTB.TabIndex = 0
        Me.CommonLogRTB.Text = ""
        '
        'CommonLog
        '
        Me.CommonLog.Controls.Add(Me.CommonLogRTB)
        Me.CommonLog.Location = New System.Drawing.Point(4, 22)
        Me.CommonLog.Name = "CommonLog"
        Me.CommonLog.Padding = New System.Windows.Forms.Padding(3)
        Me.CommonLog.Size = New System.Drawing.Size(585, 243)
        Me.CommonLog.TabIndex = 0
        Me.CommonLog.Text = "Common Log"
        Me.CommonLog.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.CommonLog)
        Me.TabControl1.Controls.Add(Me.ItemLog)
        Me.TabControl1.Controls.Add(Me.ErrorReports)
        Me.TabControl1.Location = New System.Drawing.Point(12, 357)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(593, 269)
        Me.TabControl1.TabIndex = 7
        Me.TabControl1.TabStop = False
        '
        'ErrorReports
        '
        Me.ErrorReports.Controls.Add(Me.ErrorTextBox)
        Me.ErrorReports.Location = New System.Drawing.Point(4, 22)
        Me.ErrorReports.Name = "ErrorReports"
        Me.ErrorReports.Padding = New System.Windows.Forms.Padding(3)
        Me.ErrorReports.Size = New System.Drawing.Size(585, 243)
        Me.ErrorReports.TabIndex = 2
        Me.ErrorReports.Text = "Error Reports"
        Me.ErrorReports.UseVisualStyleBackColor = True
        '
        'ErrorTextBox
        '
        Me.ErrorTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ErrorTextBox.Location = New System.Drawing.Point(3, 3)
        Me.ErrorTextBox.Name = "ErrorTextBox"
        Me.ErrorTextBox.Size = New System.Drawing.Size(579, 237)
        Me.ErrorTextBox.TabIndex = 0
        Me.ErrorTextBox.Text = ""
        '
        'linksToolStripMenuItem
        '
        Me.linksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.wwwetalToolStripMenuItem, Me.WikiToolStripMenuItem})
        Me.linksToolStripMenuItem.Name = "linksToolStripMenuItem"
        Me.linksToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.linksToolStripMenuItem.Text = "&Links"
        '
        'WikiToolStripMenuItem
        '
        Me.WikiToolStripMenuItem.Name = "WikiToolStripMenuItem"
        Me.WikiToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.WikiToolStripMenuItem.Text = "&Wiki"
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(541, 321)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SaveButton.Size = New System.Drawing.Size(61, 25)
        Me.SaveButton.TabIndex = 6
        Me.SaveButton.Text = "&Save"
        Me.ToolTip1.SetToolTip(Me.SaveButton, "Saves all profile settings")
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(397, 321)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RemoveButton.Size = New System.Drawing.Size(60, 25)
        Me.RemoveButton.TabIndex = 4
        Me.RemoveButton.Text = "&Remove"
        Me.ToolTip1.SetToolTip(Me.RemoveButton, "Deletes a profile")
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'EditButton
        '
        Me.EditButton.Location = New System.Drawing.Point(325, 321)
        Me.EditButton.Name = "EditButton"
        Me.EditButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EditButton.Size = New System.Drawing.Size(62, 25)
        Me.EditButton.TabIndex = 3
        Me.EditButton.Text = "&Edit"
        Me.ToolTip1.SetToolTip(Me.Editbutton, "Edit settings on selected profile" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This will reset selected profiles account pass" &
        "word")
        Me.EditButton.UseVisualStyleBackColor = True
        '
        'AddButton
        '
        Me.AddButton.Location = New System.Drawing.Point(252, 321)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AddButton.Size = New System.Drawing.Size(61, 25)
        Me.AddButton.TabIndex = 2
        Me.AddButton.Text = "A&dd"
        Me.ToolTip1.SetToolTip(Me.AddButton, "Adds a new Profile to list")
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(173, 321)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StopButton.Size = New System.Drawing.Size(65, 25)
        Me.StopButton.TabIndex = 1
        Me.StopButton.Text = "S&top"
        Me.ToolTip1.SetToolTip(Me.StopButton, "Stop d2 based on selected profile")
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'RunButton
        '
        Me.RunButton.Location = New System.Drawing.Point(95, 321)
        Me.RunButton.Name = "RunButton"
        Me.RunButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RunButton.Size = New System.Drawing.Size(65, 25)
        Me.RunButton.TabIndex = 0
        Me.RunButton.Text = "&Run"
        Me.ToolTip1.SetToolTip(Me.RunButton, "Launch D2 based on selected profile")
        Me.RunButton.UseVisualStyleBackColor = True
        '
        'ProfilesDataGrid
        '
        Me.ProfilesDataGrid.AllowUserToAddRows = False
        Me.ProfilesDataGrid.AllowUserToDeleteRows = False
        Me.ProfilesDataGrid.AllowUserToResizeColumns = False
        Me.ProfilesDataGrid.AllowUserToResizeRows = False
        Me.ProfilesDataGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProfilesDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ProfilesDataGrid.BackgroundColor = System.Drawing.SystemColors.Control
        Me.ProfilesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.ProfilesDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.KeyFile, Me.Column2, Me.Column3, Me.Deaths, Me.Column4, Me.Column5})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProfilesDataGrid.DefaultCellStyle = DataGridViewCellStyle1
        Me.ProfilesDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.ProfilesDataGrid.GridColor = System.Drawing.SystemColors.ControlLight
        Me.ProfilesDataGrid.Location = New System.Drawing.Point(12, 121)
        Me.ProfilesDataGrid.MultiSelect = False
        Me.ProfilesDataGrid.Name = "ProfilesDataGrid"
        Me.ProfilesDataGrid.RowHeadersVisible = False
        Me.ProfilesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProfilesDataGrid.Size = New System.Drawing.Size(590, 188)
        Me.ProfilesDataGrid.TabIndex = 10
        Me.ProfilesDataGrid.TabStop = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Profile Name"
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 120
        '
        'KeyFile
        '
        Me.KeyFile.FillWeight = 90.0!
        Me.KeyFile.HeaderText = "Mpq/Raw key"
        Me.KeyFile.Name = "KeyFile"
        Me.KeyFile.ReadOnly = True
        Me.KeyFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.KeyFile.Width = 90
        '
        'Column2
        '
        Me.Column2.FillWeight = 60.0!
        Me.Column2.HeaderText = "Runs"
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 60
        '
        'Column3
        '
        Me.Column3.FillWeight = 50.0!
        Me.Column3.HeaderText = "Restarts"
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 50
        '
        'Deaths
        '
        Me.Deaths.FillWeight = 50.0!
        Me.Deaths.HeaderText = "Deaths"
        Me.Deaths.Name = "Deaths"
        Me.Deaths.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Deaths.Width = 50
        '
        'Column4
        '
        Me.Column4.FillWeight = 60.0!
        Me.Column4.HeaderText = "Chickens"
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column4.Width = 60
        '
        'Column5
        '
        Me.Column5.HeaderText = "Status"
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column5.Width = 175
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.linksToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(617, 24)
        Me.menuStrip1.TabIndex = 9
        Me.menuStrip1.Text = "menuStrip1"
        '
        'MoveDown
        '
        Me.MoveDown.BackgroundImage = Global.Etal_Manager.My.Resources.Resources.ArrowDown
        Me.MoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MoveDown.Location = New System.Drawing.Point(50, 321)
        Me.MoveDown.Name = "MoveDown"
        Me.MoveDown.Size = New System.Drawing.Size(28, 25)
        Me.MoveDown.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.MoveDown, "Move a profile lower in list")
        Me.MoveDown.UseVisualStyleBackColor = True
        '
        'MoveUp
        '
        Me.MoveUp.BackgroundImage = Global.Etal_Manager.My.Resources.Resources.ArrowUp
        Me.MoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MoveUp.Location = New System.Drawing.Point(14, 321)
        Me.MoveUp.Name = "MoveUp"
        Me.MoveUp.Size = New System.Drawing.Size(28, 25)
        Me.MoveUp.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.MoveUp, "Move a profile higher in list")
        Me.MoveUp.UseVisualStyleBackColor = True
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(1, 30)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(616, 85)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox1.TabIndex = 52
        Me.pictureBox1.TabStop = False
        '
        'CopyButton
        '
        Me.CopyButton.Location = New System.Drawing.Point(469, 321)
        Me.CopyButton.Name = "CopyButton"
        Me.CopyButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CopyButton.Size = New System.Drawing.Size(61, 25)
        Me.CopyButton.TabIndex = 5
        Me.CopyButton.Text = "&Copy"
        Me.ToolTip1.SetToolTip(Me.CopyButton, "Copies selected to a new profile")
        Me.CopyButton.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'Manager
        '
        Me.AcceptButton = Me.RunButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ExitButton
        Me.ClientSize = New System.Drawing.Size(617, 664)
        Me.Controls.Add(Me.CopyButton)
        Me.Controls.Add(Me.MoveDown)
        Me.Controls.Add(Me.MoveUp)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.EditButton)
        Me.Controls.Add(Me.AddButton)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.RunButton)
        Me.Controls.Add(Me.ProfilesDataGrid)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.pictureBox1)
        Me.MainMenuStrip = Me.menuStrip1
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(633, 703)
        Me.MinimumSize = New System.Drawing.Size(561, 703)
        Me.Name = "Manager"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Etal Manager"
        Me.ItemLog.ResumeLayout(False)
        Me.CommonLog.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.ErrorReports.ResumeLayout(False)
        CType(Me.ProfilesDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents wwwetalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ExitButton As System.Windows.Forms.Button
    Private WithEvents ItemLog As System.Windows.Forms.TabPage
    Private WithEvents CommonLog As System.Windows.Forms.TabPage
    Private WithEvents TabControl1 As System.Windows.Forms.TabControl
    Private WithEvents linksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents SaveButton As System.Windows.Forms.Button
    Private WithEvents RemoveButton As System.Windows.Forms.Button
    Private WithEvents EditButton As System.Windows.Forms.Button
    Private WithEvents AddButton As System.Windows.Forms.Button
    Private WithEvents StopButton As System.Windows.Forms.Button
    Private WithEvents RunButton As System.Windows.Forms.Button
    Public WithEvents ProfilesDataGrid As System.Windows.Forms.DataGridView
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents CommonLogRTB As System.Windows.Forms.RichTextBox
    Friend WithEvents MoveUp As System.Windows.Forms.Button
    Friend WithEvents MoveDown As System.Windows.Forms.Button
    Friend WithEvents ItemTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents ErrorReports As TabPage
    Friend WithEvents ErrorTextBox As RichTextBox
    Private WithEvents CopyButton As Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents KeyFile As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Deaths As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents WikiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
End Class
