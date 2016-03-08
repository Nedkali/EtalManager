<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.wwwetalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Exitbutton = New System.Windows.Forms.Button()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.CommonLog = New System.Windows.Forms.TabPage()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.linksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.RemoveButton = New System.Windows.Forms.Button()
        Me.Editbutton = New System.Windows.Forms.Button()
        Me.AddButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.RunButton = New System.Windows.Forms.Button()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
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
        Me.tabPage2.SuspendLayout()
        Me.CommonLog.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuStrip1.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wwwetalToolStripMenuItem
        '
        Me.wwwetalToolStripMenuItem.Name = "wwwetalToolStripMenuItem"
        Me.wwwetalToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.wwwetalToolStripMenuItem.Text = "projectetal.com"
        '
        'Exitbutton
        '
        Me.Exitbutton.Location = New System.Drawing.Point(206, 632)
        Me.Exitbutton.Name = "Exitbutton"
        Me.Exitbutton.Size = New System.Drawing.Size(205, 27)
        Me.Exitbutton.TabIndex = 61
        Me.Exitbutton.Text = "Exit"
        Me.Exitbutton.UseVisualStyleBackColor = True
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.RichTextBox2)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(585, 243)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Item Log"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox2.Location = New System.Drawing.Point(3, 3)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(579, 237)
        Me.RichTextBox2.TabIndex = 0
        Me.RichTextBox2.Text = ""
        '
        'richTextBox1
        '
        Me.richTextBox1.Location = New System.Drawing.Point(3, 3)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New System.Drawing.Size(579, 237)
        Me.richTextBox1.TabIndex = 0
        Me.richTextBox1.Text = ""
        '
        'CommonLog
        '
        Me.CommonLog.Controls.Add(Me.richTextBox1)
        Me.CommonLog.Location = New System.Drawing.Point(4, 22)
        Me.CommonLog.Name = "CommonLog"
        Me.CommonLog.Padding = New System.Windows.Forms.Padding(3)
        Me.CommonLog.Size = New System.Drawing.Size(585, 243)
        Me.CommonLog.TabIndex = 0
        Me.CommonLog.Text = "Common Log"
        Me.CommonLog.UseVisualStyleBackColor = True
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.CommonLog)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.TabPage1)
        Me.tabControl1.Location = New System.Drawing.Point(12, 357)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(593, 269)
        Me.tabControl1.TabIndex = 60
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.RichTextBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(585, 243)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Error Reports"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox3.Location = New System.Drawing.Point(3, 3)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(579, 237)
        Me.RichTextBox3.TabIndex = 0
        Me.RichTextBox3.Text = ""
        '
        'linksToolStripMenuItem
        '
        Me.linksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.wwwetalToolStripMenuItem})
        Me.linksToolStripMenuItem.Name = "linksToolStripMenuItem"
        Me.linksToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.linksToolStripMenuItem.Text = "Links"
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(541, 321)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SaveButton.Size = New System.Drawing.Size(61, 25)
        Me.SaveButton.TabIndex = 59
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'RemoveButton
        '
        Me.RemoveButton.Location = New System.Drawing.Point(397, 321)
        Me.RemoveButton.Name = "RemoveButton"
        Me.RemoveButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RemoveButton.Size = New System.Drawing.Size(60, 25)
        Me.RemoveButton.TabIndex = 58
        Me.RemoveButton.Text = "Remove"
        Me.RemoveButton.UseVisualStyleBackColor = True
        '
        'Editbutton
        '
        Me.Editbutton.Location = New System.Drawing.Point(325, 321)
        Me.Editbutton.Name = "Editbutton"
        Me.Editbutton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Editbutton.Size = New System.Drawing.Size(62, 25)
        Me.Editbutton.TabIndex = 57
        Me.Editbutton.Text = "Edit"
        Me.Editbutton.UseVisualStyleBackColor = True
        '
        'AddButton
        '
        Me.AddButton.Location = New System.Drawing.Point(252, 321)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AddButton.Size = New System.Drawing.Size(61, 25)
        Me.AddButton.TabIndex = 56
        Me.AddButton.Text = "Add"
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(173, 321)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StopButton.Size = New System.Drawing.Size(65, 25)
        Me.StopButton.TabIndex = 55
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'RunButton
        '
        Me.RunButton.Location = New System.Drawing.Point(94, 321)
        Me.RunButton.Name = "RunButton"
        Me.RunButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RunButton.Size = New System.Drawing.Size(65, 25)
        Me.RunButton.TabIndex = 54
        Me.RunButton.Text = "Run"
        Me.RunButton.UseVisualStyleBackColor = True
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.AllowUserToResizeColumns = False
        Me.dataGridView1.AllowUserToResizeRows = False
        Me.dataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.KeyFile, Me.Column2, Me.Column3, Me.Deaths, Me.Column4, Me.Column5})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight
        Me.dataGridView1.Location = New System.Drawing.Point(12, 121)
        Me.dataGridView1.MultiSelect = False
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.RowHeadersVisible = False
        Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView1.Size = New System.Drawing.Size(590, 188)
        Me.dataGridView1.TabIndex = 53
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
        Me.KeyFile.HeaderText = "Raw/Key Name"
        Me.KeyFile.Name = "KeyFile"
        Me.KeyFile.ReadOnly = True
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
        Me.menuStrip1.TabIndex = 62
        Me.menuStrip1.Text = "menuStrip1"
        '
        'MoveDown
        '
        Me.MoveDown.BackgroundImage = Global.Etal_Manager.My.Resources.Resources.ArrowDown
        Me.MoveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MoveDown.Location = New System.Drawing.Point(50, 321)
        Me.MoveDown.Name = "MoveDown"
        Me.MoveDown.Size = New System.Drawing.Size(28, 25)
        Me.MoveDown.TabIndex = 64
        Me.MoveDown.UseVisualStyleBackColor = True
        '
        'MoveUp
        '
        Me.MoveUp.BackgroundImage = Global.Etal_Manager.My.Resources.Resources.ArrowUp
        Me.MoveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.MoveUp.Location = New System.Drawing.Point(14, 321)
        Me.MoveUp.Name = "MoveUp"
        Me.MoveUp.Size = New System.Drawing.Size(28, 25)
        Me.MoveUp.TabIndex = 63
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
        Me.CopyButton.TabIndex = 65
        Me.CopyButton.Text = "Copy"
        Me.CopyButton.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 664)
        Me.Controls.Add(Me.CopyButton)
        Me.Controls.Add(Me.MoveDown)
        Me.Controls.Add(Me.MoveUp)
        Me.Controls.Add(Me.Exitbutton)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.RemoveButton)
        Me.Controls.Add(Me.Editbutton)
        Me.Controls.Add(Me.AddButton)
        Me.Controls.Add(Me.StopButton)
        Me.Controls.Add(Me.RunButton)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.pictureBox1)
        Me.MaximumSize = New System.Drawing.Size(633, 703)
        Me.MinimumSize = New System.Drawing.Size(561, 703)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Etal Manager"
        Me.tabPage2.ResumeLayout(False)
        Me.CommonLog.ResumeLayout(False)
        Me.tabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents wwwetalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents Exitbutton As System.Windows.Forms.Button
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents CommonLog As System.Windows.Forms.TabPage
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents linksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents SaveButton As System.Windows.Forms.Button
    Private WithEvents RemoveButton As System.Windows.Forms.Button
    Private WithEvents Editbutton As System.Windows.Forms.Button
    Private WithEvents AddButton As System.Windows.Forms.Button
    Private WithEvents StopButton As System.Windows.Forms.Button
    Private WithEvents RunButton As System.Windows.Forms.Button
    Public WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Public WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents MoveUp As System.Windows.Forms.Button
    Friend WithEvents MoveDown As System.Windows.Forms.Button
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents RichTextBox3 As RichTextBox
    Private WithEvents CopyButton As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents KeyFile As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Deaths As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
