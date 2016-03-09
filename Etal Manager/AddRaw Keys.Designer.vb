<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddRawKeys
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.KeyMpqNameTBox = New System.Windows.Forms.TextBox()
        Me.ClassicKeyTBox = New System.Windows.Forms.TextBox()
        Me.ExpansionKeyTBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AddButton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Key Owner/Mpq"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(160, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Classic Key"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(313, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Expansion Key"
        '
        'KeyMpqNameTBox
        '
        Me.KeyMpqNameTBox.Location = New System.Drawing.Point(8, 37)
        Me.KeyMpqNameTBox.Name = "KeyMpqNameTBox"
        Me.KeyMpqNameTBox.Size = New System.Drawing.Size(89, 20)
        Me.KeyMpqNameTBox.TabIndex = 9
        '
        'ClassicKeyTBox
        '
        Me.ClassicKeyTBox.Location = New System.Drawing.Point(111, 37)
        Me.ClassicKeyTBox.MaxLength = 26
        Me.ClassicKeyTBox.Name = "ClassicKeyTBox"
        Me.ClassicKeyTBox.Size = New System.Drawing.Size(155, 20)
        Me.ClassicKeyTBox.TabIndex = 10
        '
        'ExpansionKeyTBox
        '
        Me.ExpansionKeyTBox.Location = New System.Drawing.Point(276, 37)
        Me.ExpansionKeyTBox.MaxLength = 26
        Me.ExpansionKeyTBox.Name = "ExpansionKeyTBox"
        Me.ExpansionKeyTBox.Size = New System.Drawing.Size(155, 20)
        Me.ExpansionKeyTBox.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AddButton)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ClassicKeyTBox)
        Me.GroupBox1.Controls.Add(Me.ExpansionKeyTBox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.KeyMpqNameTBox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 118)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'AddButton
        '
        Me.AddButton.Location = New System.Drawing.Point(255, 80)
        Me.AddButton.Name = "AddButton"
        Me.AddButton.Size = New System.Drawing.Size(75, 23)
        Me.AddButton.TabIndex = 13
        Me.AddButton.Text = "Add Key"
        Me.AddButton.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(87, 80)
        Me.Button1.MaximumSize = New System.Drawing.Size(75, 23)
        Me.Button1.MinimumSize = New System.Drawing.Size(75, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Crimson
        Me.Label4.Location = New System.Drawing.Point(135, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = " "
        '
        'AddRawKeys
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 172)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(485, 210)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(485, 210)
        Me.Name = "AddRawKeys"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Raw Keys"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents KeyMpqNameTBox As TextBox
    Friend WithEvents ClassicKeyTBox As TextBox
    Friend WithEvents ExpansionKeyTBox As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents AddButton As Button
    Friend WithEvents Label4 As Label
End Class
