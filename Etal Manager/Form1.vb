Imports System.Runtime.InteropServices
Imports System.Threading

Public Class Form1
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        Select Case m.Msg
            Case WM_COPYDATA

                Dim cds As CopyData
                Dim nOption As Integer = Fix(m.WParam.ToInt32)
                cds = Marshal.PtrToStructure(m.LParam, cds.GetType())
                Dim nLength As Integer = cds.cbData
                Dim temp As String = Marshal.PtrToStringAnsi(cds.lpData, nLength)
                Dim y As Integer = cds.dwData
                Dim a As Integer = m.WParam
                'MessageBox.Show(a)
                'RichTextBox3.AppendText("int = " & y & " " & temp & vbCrLf)
                Dim x As Integer = -1
                For i As Integer = 0 To Objects.Count - 1
                    If Objects(i).D2PID = a Then
                        x = i
                    End If
                Next i
                If x < 0 Then MessageBox.Show("exiting") : Return
                Dim tnow As System.DateTime = System.DateTime.Now
                Dim temp1 As String = tnow.Hour.ToString() & "."
                temp1 = temp1 & tnow.Minute.ToString() & "."
                temp1 = temp1 & tnow.Second.ToString() & " "

                Select Case y
                    Case D2NT_MGR_LOADING
                        dataGridView1.Rows(x).Cells(5).Value = temp
                    Case D2NT_MGR_READY
                        dataGridView1.Rows(x).Cells(5).Value = temp
                    Case D2NT_MGR_LOGIN
                        dataGridView1.Rows(x).Cells(5).Value = "Login"
                        richTextBox1.AppendText("[" & temp1 + Objects(x).ProfileName & "] Login" & vbCrLf)
                    Case D2NT_MGR_CREATE_GAME
                        dataGridView1.Rows(x).Cells(5).Value = "Game Create"
                        richTextBox1.AppendText("[" & temp1 + Objects(x).ProfileName & "] Game Create" & vbCrLf)
                    Case D2NT_MGR_INGAME
                        y = Convert.ToInt32(dataGridView1.Rows(x).Cells(1).Value)
                        y = y + 1
                        dataGridView1.Rows(x).Cells(1).Value = y
                        dataGridView1.Rows(x).Cells(4).Value = "In Game"
                        richTextBox1.AppendText("[" & temp1 + Objects(x).ProfileName & "] In Game(" & y & ")" & vbCrLf)
                    Case D2NT_MGR_RESTART
                        dataGridView1.Rows(x).Cells(4).Value = "Restarting"
                    Case D2NT_MGR_CHICKEN
                        richTextBox1.AppendText("[" & temp1 + Objects(x).ProfileName & "] " & temp & vbCrLf)
                    Case D2NT_MGR_PRINT_STATUS
                        richTextBox1.AppendText("[" & temp1 + Objects(x).ProfileName & "] " & temp & vbCrLf)
                    Case D2NT_MGR_COMMON
                        richTextBox1.AppendText("[" & temp1 + Objects(x).ProfileName & "] " & temp & vbCrLf)
                    Case D2NT_MGR_ITEM_LOG
                        RichTextBox2.AppendText("[" & temp1 + Objects(x).ProfileName & "] " & temp & vbCrLf)

                    Case D2NT_MGR_ERROR_LOG
                        RichTextBox3.AppendText("[" & temp1 + Objects(x).ProfileName & "] " & temp + vbCrLf)
                        RichTextBox3.AppendText(vbCrLf)
                End Select
                cds = Nothing

        End Select
        MyBase.WndProc(m)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        dataGridView1.Rows.Add(9)
        'LoadProfiles()
        ReadBinary()
    End Sub

    Private Sub button4_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        form2action = ""
        Form2.ShowDialog()
    End Sub

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles Exitbutton.Click
        Application.Exit()
    End Sub

    Private Sub wwwetalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles wwwetalToolStripMenuItem.Click
        Process.Start("www.projectetal.com")
    End Sub

    Private Sub button5_Click(sender As Object, e As EventArgs) Handles Editbutton.Click
        If dataGridView1.CurrentRow.Index > Objects.Count - 1 Then Return
        If dataGridView1.CurrentRow.Index < 0 Then Return
        If Objects.Count = 0 Then Return
        form2action = "edit"
        Form2.ShowDialog()
    End Sub


    Private Sub button6_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        Dim x As Integer = dataGridView1.CurrentRow.Index
        If x < 0 Or x > Objects.Count - 1 Or Objects.Count = 0 Then Return
        dataGridView1.Rows.RemoveAt(x)
        If dataGridView1.RowCount < 9 Then dataGridView1.Rows.Add(1)
        Objects.RemoveAt(x)
    End Sub

    Private Sub button7_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        BWrite()
        Return
        If Objects.Count = 0 Then Return
        Dim myfile = Application.StartupPath & "\D2NT Manager.cfg"
        Try

            Dim LogWriter = My.Computer.FileSystem.OpenTextFileWriter(myfile, False)

            For x = 0 To Objects.Count - 1

                LogWriter.Write(Objects(x).ProfileName + ",")
                LogWriter.Write(Objects(x).D2Path + ",")
                LogWriter.Write(Objects(x).WindowMode + ",")
                LogWriter.Write(Objects(x).D2Sound + ",")
                LogWriter.Write(Objects(x).D2Quality + ",")
                LogWriter.Write(Objects(x).D2DirectText + ",")
                LogWriter.Write(Objects(x).D2Minimized + ",")
                LogWriter.Write(Objects(x).CDkeys + ",")
                LogWriter.Write(Objects(x).CDkeySwap + ",")
                LogWriter.Write(Objects(x).AccountName + ",")
                LogWriter.Write(",")
                LogWriter.Write(Objects(x).D2PlayType + ",")
                LogWriter.Write(Objects(x).D2Difficulty + ",")
                LogWriter.Write(Objects(x).Realm + ",")
                LogWriter.Write(Objects(x).GameName + ",")
                LogWriter.Write(Objects(x).GamePass + ",")
                LogWriter.Write(Objects(x).CharPosition + ",")
                LogWriter.Write(Objects(x).D2starter & vbCrLf)

            Next

            LogWriter.Close()

        Catch ex As Exception
            richTextBox1.AppendText("File Write Error")
        End Try


    End Sub
    Private Sub LoadProfiles()
        Dim myfile = Application.StartupPath & "\D2NT Manager.cfg"

        If My.Computer.FileSystem.FileExists(myfile) = False Then
            Dim LogWriter = My.Computer.FileSystem.OpenTextFileWriter(myfile, False)
            LogWriter.Close()
        End If
        Try

            Dim CfgReader = My.Computer.FileSystem.OpenTextFileReader(myfile)

            While CfgReader.EndOfStream = False
                Dim temp = CfgReader.ReadLine
                Dim myarray = Split(temp, ",")
                If myarray.Length <> 18 Then
                    CfgReader.Close()
                    Exit Try
                End If
                Dim NewObject As New Profiles

                NewObject.ProfileName = myarray(0)
                NewObject.D2Path = myarray(1)
                NewObject.WindowMode = myarray(2)
                NewObject.D2Sound = myarray(3)
                NewObject.D2Quality = myarray(4)
                NewObject.D2DirectText = myarray(5)
                NewObject.D2Minimized = myarray(6)
                NewObject.CDkeys = myarray(7)
                NewObject.CDkeySwap = myarray(8)
                NewObject.AccountName = myarray(9)
                NewObject.AccPass = myarray(10)
                NewObject.D2PlayType = myarray(11)
                NewObject.D2Difficulty = myarray(12)
                NewObject.Realm = myarray(13)
                NewObject.GameName = myarray(14)
                NewObject.GamePass = myarray(15)
                NewObject.CharPosition = myarray(16)
                NewObject.D2starter = myarray(17)

                Objects.Add(NewObject)
            End While

            CfgReader.Close()

        Catch ex As Exception
            richTextBox1.AppendText("File Read Error")

        End Try
        For x = 0 To Objects.Count - 1
            If dataGridView1.RowCount < Objects.Count Then dataGridView1.Rows.Add(1)
            dataGridView1.Rows(x).Cells(0).Value = Objects(x).ProfileName
            dataGridView1.Rows(x).Cells(2).Value = 0
            dataGridView1.Rows(x).Cells(3).Value = 0
            dataGridView1.Rows(x).Cells(4).Value = 0
        Next
    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles RunButton.Click

        Dim a As Integer = dataGridView1.CurrentRow.Index
        If a < 0 Then Return
        If Objects(a).Running = True Then
            For Each proc As Process In Process.GetProcesses
                If proc.Id = Objects(a).D2PID Then Return
            Next
            Objects(a).Running = False
        End If

        If MemFile(a) = False Then Return

        Dim objArray = New Object() {" -mpq ", dataGridView1.Rows(a).Cells(1).Value}
        Dim str2 = String.Concat(objArray)

        Dim ApArgs As String = str2

        'MessageBox.Show(ApArgs) : Return
        If Objects(a).WindowMode = 1 Then ApArgs = ApArgs & " -w"
        If Objects(a).D2Sound = 1 Then ApArgs = ApArgs & " -ns"


        Dim d2RelPath = Replace(Objects(a).D2Path, "Game.exe", "")
        'MessageBox.Show(d2RelPath)

        Dim p As Process = New Process()
        p.StartInfo.WorkingDirectory = d2RelPath
        p.EnableRaisingEvents = True
        p.StartInfo.Arguments = ApArgs
        p.StartInfo.FileName = Objects(0).D2Path
        p.StartInfo.UseShellExecute = False

        p = PInvoke.Extensions.StartSuspended(p, p.StartInfo) 'loads D2 into memory

        Objects(a).D2PID = p.Id

        If Not PInvoke.Kernel32.LoadRemoteLibrary(p, Application.StartupPath & "\D2M.dll") Then RichTextBox3.AppendText(" Failed to load D2M.dll")
        'blocks 2nd instance check
        Dim oldValue(1) As Byte
        Dim newvalue() As Byte = {&HEB, &H45}
        Dim address As New IntPtr(&H6FA80000 + &HB6B0)
        Try 'a287
            If Not PInvoke.Kernel32.LoadRemoteLibrary(p, d2RelPath & "D2Gfx.dll") Then RichTextBox3.AppendText(" Failed to load d2gfx")
            If Not PInvoke.Kernel32.ReadProcessMemory(p, address, oldValue) Then RichTextBox3.AppendText(" failed to read window fix")
            If PInvoke.Kernel32.WriteProcessMemory(p, address, newvalue) = 0 Then RichTextBox3.AppendText(" failed to write window fix")
        Catch
            RichTextBox3.AppendText(" error on window fix " & address.ToString)

        End Try

        'loads/injects dll
        If Not PInvoke.Kernel32.LoadRemoteLibrary(p, Application.StartupPath & "\D2ETAL.dll") Then RichTextBox3.AppendText(" Failed to load D2Etal.dll")

        'resume/start process
        PInvoke.Kernel32.ResumeProcess(p)
        p.WaitForInputIdle()

        Objects(a).Running = True
        ' dataGridView1.Rows(a).Cells(5).Value = "Running"
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles MoveUp.Click
        Dim x As Integer = dataGridView1.CurrentRow.Index
        If x < 1 Or x > Objects.Count - 1 Or Objects.Count = 0 Then Return
        Dim NewObject As New Profiles


        NewObject.ProfileName = Objects(x).ProfileName
        NewObject.D2Path = Objects(x).D2Path
        NewObject.WindowMode = Objects(x).WindowMode
        NewObject.D2Sound = Objects(x).D2Sound
        NewObject.D2Quality = Objects(x).D2Quality
        NewObject.D2DirectText = Objects(x).D2DirectText
        NewObject.D2Minimized = Objects(x).D2Minimized
        NewObject.CDkeys = Objects(x).CDkeys
        NewObject.CDkeySwap = Objects(x).CDkeySwap
        NewObject.AccountName = Objects(x).AccountName
        NewObject.AccPass = Objects(x).AccPass
        NewObject.D2PlayType = Objects(x).D2PlayType
        NewObject.D2Difficulty = Objects(x).D2Difficulty
        NewObject.Realm = Objects(x).Realm
        NewObject.GameName = Objects(x).GameName
        NewObject.GamePass = Objects(x).GamePass
        NewObject.CharPosition = Objects(x).CharPosition
        NewObject.D2starter = Objects(x).D2starter

        Objects.RemoveAt(x)
        Objects.Insert(x - 1, NewObject)

        For y = 0 To Objects.Count - 1
            dataGridView1.Rows(y).Cells(0).Value = Objects(y).ProfileName
        Next
        dataGridView1.Rows(x).Selected = True
    End Sub

    Private Sub MoveDown_Click(sender As Object, e As EventArgs) Handles MoveDown.Click
        Dim x As Integer = dataGridView1.CurrentRow.Index
        If x < 0 Or x > Objects.Count - 2 Or Objects.Count = 0 Then Return
        Dim NewObject As New Profiles


        NewObject.ProfileName = Objects(x).ProfileName
        NewObject.D2Path = Objects(x).D2Path
        NewObject.WindowMode = Objects(x).WindowMode
        NewObject.D2Sound = Objects(x).D2Sound
        NewObject.D2Quality = Objects(x).D2Quality
        NewObject.D2DirectText = Objects(x).D2DirectText
        NewObject.D2Minimized = Objects(x).D2Minimized
        NewObject.CDkeys = Objects(x).CDkeys
        NewObject.CDkeySwap = Objects(x).CDkeySwap
        NewObject.AccountName = Objects(x).AccountName
        NewObject.AccPass = Objects(x).AccPass
        NewObject.D2PlayType = Objects(x).D2PlayType
        NewObject.D2Difficulty = Objects(x).D2Difficulty
        NewObject.Realm = Objects(x).Realm
        NewObject.GameName = Objects(x).GameName
        NewObject.GamePass = Objects(x).GamePass
        NewObject.CharPosition = Objects(x).CharPosition
        NewObject.D2starter = Objects(x).D2starter

        Objects.RemoveAt(x)
        Objects.Insert(x + 1, NewObject)

        For y = 0 To Objects.Count - 1
            dataGridView1.Rows(y).Cells(0).Value = Objects(y).ProfileName
        Next

        dataGridView1.Rows(x).Selected = True
    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        Dim processIsRunning = Process.GetProcessesByName("Game").Length > 0
        Dim a As Integer = dataGridView1.CurrentRow.Index

        For Each proc As Process In Process.GetProcesses
            If proc.Id = Objects(a).D2PID Then
                proc.CloseMainWindow()
                Objects(a).Running = False
                dataGridView1.Rows(a).Cells(5).Value = ""
            End If
        Next


    End Sub

    Private Sub CopyButton_Click(sender As Object, e As EventArgs) Handles CopyButton.Click
        Dim a As Integer = dataGridView1.CurrentRow.Index
        If a < 0 Then Return
        Objects.Add(Objects(a))
        a = Objects.Count - 1
        dataGridView1.Rows(a).Cells(0).Value = Objects(a).ProfileName
        dataGridView1.Rows(a).Cells(2).Value = Objects(a).Run
        dataGridView1.Rows(a).Cells(3).Value = Objects(a).Restarts
        dataGridView1.Rows(a).Cells(4).Value = Objects(a).Chickens
        If a > 5 Then a = a - 5
        If a < 5 Then a = 0
        dataGridView1.FirstDisplayedScrollingRowIndex = a
    End Sub
End Class
