Imports System.IO.MemoryMappedFiles
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Security.Principal




Public Class Form1



    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        'If sendmsg > 0 Then
        '    datasend(sendmsg)
        'End If
        Select Case m.Msg
            Case WM_COPYDATA

                Dim cds As COPYDATASTRUCT
                Dim nOption As Integer = Fix(m.WParam.ToInt32)
                cds = Marshal.PtrToStructure(m.LParam, cds.GetType())
                Dim nLength As Integer = cds.cbData
                Dim temp As String = Marshal.PtrToStringAnsi(cds.lpData, nLength)
                Dim y As Integer = cds.dwData
                Dim a As Integer = m.WParam
                'MessageBox.Show("sending Id = " & a)

                Dim x As Integer = -1
                For i = 0 To Objects.Count - 1
                    If Objects(i).D2PID = a Then
                        x = i
                    End If
                Next
                If x < 0 Then MessageBox.Show("exiting") : Return
                Dim temp1 = timesetter()

                Select Case y
                    Case ETAL_MGR_LOADING
                        dataGridView1.Rows(x).Cells(6).Value = temp
                    Case ETAL_MGR_READY
                        Dim keyfile = assignkeys(x)(0)
                        If keyfile <> dataGridView1.Rows(x).Cells(1).Value Then
                            restart(x)
                        End If
                        dataGridView1.Rows(x).Cells(6).Value = temp
                    Case ETAL_MGR_LOGIN
                        dataGridView1.Rows(x).Cells(6).Value = "Login"
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] Login")
                    Case ETAL_MGR_CREATE_GAME
                        dataGridView1.Rows(x).Cells(6).Value = "Game Create"
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] Game Create")
                    Case ETAL_MGR_INGAME
                        y = Convert.ToInt32(dataGridView1.Rows(x).Cells(2).Value)
                        y = y + 1
                        dataGridView1.Rows(x).Cells(2).Value = y
                        dataGridView1.Rows(x).Cells(6).Value = "In Game"
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] In Game(" & y & ")")
                    Case ETAL_MGR_RESTART
                        dataGridView1.Rows(x).Cells(6).Value = "Restarting"
                    Case ETAL_MGR_CHICKEN
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] " & temp)
                    Case ETAL_MGR_PRINT_STATUS
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] " & temp)
                    Case ETAL_MGR_COMMON
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] " & temp)
                    Case ETAL_MGR_ITEM_LOG
                        ColorSetter2("[" & temp1 + Objects(x).ProfileName & "] " & temp)
                    Case ETAL_MGR_ERROR_LOG
                        ColorSetter3("[" & temp1 + Objects(x).ProfileName & "] " & temp)

                    Case 6153 ' used for dll to check if manager present
                        m.Result = 0
                        ColorSetter3("[" & temp1 + Objects(x).ProfileName & "] Continuing next game")

                    Case Else

                        RichTextBox3.AppendText("Message rcv: int = " & y & " " & temp)
                        RichTextBox3.AppendText("" & vbCrLf)
                End Select
                cds = Nothing

        End Select
        MyBase.WndProc(m)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        dataGridView1.Rows.Add(9)
        LoadProfiles()
        'ReadBinary()' Was used to load d2nt binary.cfg file


        BackgroundWorker1.RunWorkerAsync()

    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'MessageBox.Show("Monitoring clients")
        While True

            For Each proc As Process In Process.GetProcessesByName("Game")
                If proc.Responding = False Then
                    Thread.Sleep(5000)
                    If proc.Responding = False Then
                        For index = 0 To Objects.Count - 1

                            If proc.Id = Objects(index).D2PID Then
                                restart(index)
                            End If

                        Next
                    End If

                End If
            Next

            Thread.Sleep(1000)
        End While
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
        Dim a = dataGridView1.CurrentRow.Index
        If a > Objects.Count - 1 Or a < 0 Or Objects.Count = 0 Then Return
        If Objects(a).D2PID > 0 Then Return
        form2action = "edit"
        Form2.ShowDialog()
    End Sub


    Private Sub button6_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        Dim x As Integer = dataGridView1.CurrentRow.Index
        If x < 0 Or x > Objects.Count-1 Or Objects.Count = 0 Then Return
        For index = 0 To Objects.Count - 1
            If Objects(index).D2PID > 0 Then Return
        Next
        dataGridView1.Rows.RemoveAt(x)
        Objects.RemoveAt(x)
        If dataGridView1.RowCount < 9 Then dataGridView1.Rows.Add(1)

    End Sub

    Private Sub button7_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        'BWrite()
        'Return
        If Objects.Count = 0 Then Return
        Dim myfile = Application.StartupPath & "\Etal Manager.cfg"
        Try

            Dim LogWriter = My.Computer.FileSystem.OpenTextFileWriter(myfile, False)

            For x = 0 To Objects.Count - 1

                LogWriter.Write(Objects(x).ProfileName & ",")
                LogWriter.Write(Objects(x).D2Path & ",")
                LogWriter.Write(Objects(x).WindowMode & ",")
                LogWriter.Write(Objects(x).D2Sound & ",")
                LogWriter.Write(Objects(x).D2Quality & ",")
                LogWriter.Write(Objects(x).D2DirectText & ",")
                LogWriter.Write(Objects(x).D2Minimized & ",")
                LogWriter.Write(Objects(x).CDkeys & ",")
                LogWriter.Write(Objects(x).CDkeySwap & ",")
                LogWriter.Write(Objects(x).AccountName & ",")
                LogWriter.Write(",")
                LogWriter.Write(Objects(x).D2PlayType & ",")
                LogWriter.Write(Objects(x).D2Difficulty & ",")
                LogWriter.Write(Objects(x).Realm & ",")
                LogWriter.Write(Objects(x).GameName & ",")
                LogWriter.Write(Objects(x).GamePass & ",")
                LogWriter.Write(Objects(x).CharPosition & ",")
                LogWriter.Write(Objects(x).D2starter & ",")
                LogWriter.Write(Objects(x).CDkeyOwner & ",")
                LogWriter.Write(Objects(x).CDkeyClassic & ",")
                LogWriter.Write(Objects(x).CDkeyExpansion & vbCrLf)


            Next

            LogWriter.Close()

        Catch ex As Exception
            RichTextBox3.AppendText(ex.Message)
        End Try


    End Sub
    Private Sub LoadProfiles()
        Dim myfile = Application.StartupPath & "\Etal Manager.cfg"

        If My.Computer.FileSystem.FileExists(myfile) = False Then
            Dim LogWriter = My.Computer.FileSystem.OpenTextFileWriter(myfile, False)
            LogWriter.Close()
            Return
        End If
        Try

            Dim CfgReader = My.Computer.FileSystem.OpenTextFileReader(myfile)

            While CfgReader.EndOfStream = False
                Dim temp = CfgReader.ReadLine
                Dim myarray = Split(temp, ",")
                If myarray.Length <> 21 Then
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
                NewObject.CDkeyOwner = myarray(18)
                NewObject.CDkeyClassic = myarray(19)
                NewObject.CDkeyExpansion = myarray(20)
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
            dataGridView1.Rows(x).Cells(5).Value = 0
        Next
    End Sub


    Private Sub button2_Click(sender As Object, e As EventArgs) Handles RunButton.Click

        Dim a As Integer = dataGridView1.CurrentRow.Index
        If a < 0 Or Objects.Count = 0 Then Return
        launchd2(a)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles MoveUp.Click
        Dim x As Integer = dataGridView1.CurrentRow.Index
        If x < 1 Or x > Objects.Count - 1 Or Objects.Count = 0 Then Return

        For index = 0 To Objects.Count - 1
            If Objects(index).D2PID > 0 Then Return
        Next

        Dim NewObject As New Profiles

        NewObject = Objects(x)
        Objects.RemoveAt(x)
        Objects.Insert(x - 1, NewObject)

        For y = 0 To Objects.Count - 1
            dataGridView1.Rows(y).Cells(0).Value = Objects(y).ProfileName
        Next
        dataGridView1.Rows(x - 1).Selected = True
        dataGridView1.CurrentCell = dataGridView1.Item(0, x - 1)
    End Sub

    Private Sub MoveDown_Click(sender As Object, e As EventArgs) Handles MoveDown.Click
        Dim x As Integer = dataGridView1.CurrentRow.Index
        If x < 0 Or x > Objects.Count - 2 Or Objects.Count = 0 Then Return

        For index = 0 To Objects.Count - 1
            If Objects(index).D2PID > 0 Then Return
        Next

        Dim NewObject As New Profiles
        NewObject = Objects(x)
        Objects.RemoveAt(x)
        Objects.Insert(x + 1, NewObject)

        For y = 0 To Objects.Count - 1
            dataGridView1.Rows(y).Cells(0).Value = Objects(y).ProfileName
        Next

        dataGridView1.Rows(x + 1).Selected = True
        dataGridView1.CurrentCell = dataGridView1.Item(0, x + 1)

    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        Dim a As Integer = dataGridView1.CurrentRow.Index

        For Each proc As Process In Process.GetProcessesByName("Game")
            If proc.Id = Objects(a).D2PID Then
                proc.Kill()
            End If
        Next
        Objects(a).D2PID = 0
        dataGridView1.Rows(a).Cells(1).Value = ""
        dataGridView1.Rows(a).Cells(6).Value = ""

    End Sub

    Private Sub CopyButton_Click(sender As Object, e As EventArgs) Handles CopyButton.Click
        Dim a As Integer = dataGridView1.CurrentRow.Index
        If a < 0 Or a > Objects.Count - 1 Then Return
        Dim newobject = New Profiles

        newobject.ProfileName = Objects(a).ProfileName
        newobject.D2Path = Objects(a).D2Path
        newobject.WindowMode = Objects(a).WindowMode
        newobject.D2Sound = Objects(a).D2Sound
        newobject.D2Quality = Objects(a).D2Quality
        newobject.D2DirectText = Objects(a).D2DirectText
        newobject.D2Minimized = Objects(a).D2Minimized
        newobject.CDkeys = Objects(a).CDkeys
        newobject.CDkeySwap = Objects(a).CDkeySwap
        newobject.AccountName = Objects(a).AccountName
        newobject.AccPass = Objects(a).AccPass
        newobject.D2PlayType = Objects(a).D2PlayType
        newobject.D2Difficulty = Objects(a).D2Difficulty
        newobject.Realm = Objects(a).Realm
        newobject.randomGame = Objects(a).randomGame
        newobject.randompass = Objects(a).randompass
        newobject.GameName = Objects(a).GameName
        newobject.GamePass = Objects(a).GamePass
        newobject.CharPosition = Objects(a).CharPosition
        newobject.D2starter = Objects(a).D2starter
        newobject.D2PID = 0
        newobject.Run = 0
        newobject.Chickens = 0
        newobject.Restarts = 0
        newobject.Deaths = 0
        newobject.Flags = Objects(a).Flags
        newobject.CDkeyOwner = Objects(a).CDkeyOwner
        newobject.CDkeyClassic = Objects(a).CDkeyClassic
        newobject.CDkeyExpansion = Objects(a).CDkeyExpansion

        Objects.Add(newobject)
        a = Objects.Count - 1
        dataGridView1.Rows(a).Cells(0).Value = Objects(a).ProfileName
        dataGridView1.Rows(a).Cells(2).Value = Objects(a).Run
        dataGridView1.Rows(a).Cells(3).Value = Objects(a).Restarts
        dataGridView1.Rows(a).Cells(4).Value = Objects(a).Chickens
        If a > 5 Then a = a - 5
        If a < 5 Then a = 0
        dataGridView1.FirstDisplayedScrollingRowIndex = a
        dataGridView1.CurrentCell = dataGridView1.Item(0, Objects.Count - 1)


    End Sub

    Public Function GenerateRandomString(ByRef iLength As Integer) As String
        Dim rdm As New Random()
        Dim allowChrs() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
        Dim sResult As String = ""

        For i As Integer = 0 To iLength - 1
            sResult += allowChrs(rdm.Next(0, allowChrs.Length))
        Next

        Return sResult

    End Function


    Private Sub restart(ByVal a)
        For Each proc As Process In Process.GetProcessesByName("Game")
            If proc.Id = Objects(a).D2PID Then
                proc.Kill()
            End If
        Next
        Objects(a).D2PID = 0
        dataGridView1.Rows(a).Cells(1).Value = ""
        dataGridView1.Rows(a).Cells(6).Value = ""
        Thread.Sleep(2000)
        launchd2(a)

    End Sub

    Private Sub launchd2(ByVal a)

        If Objects(a).D2PID > 0 Then
            Dim d2app = Process.GetProcessesByName("Game")
            For Each process In d2app
                If process.Id = Objects(a).D2PID Then
                    RichTextBox3.AppendText("Profile already running") : Return
                    Return
                End If
            Next
        End If

        'set account password
        If Objects(a).D2PlayType <> 0 And Objects(a).AccPass = Nothing Then
            Dim dr = Enterpassword.ShowDialog()
            If dr = DialogResult.Cancel Then Return
        End If


        Dim d2RelPath = Replace(Objects(a).D2Path, "Game.exe", "")

        If My.Computer.FileSystem.FileExists(Objects(a).D2Path) = False Then
            RichTextBox3.AppendText("Unable to locate Game.exe")
            Return
        End If



        Dim mmf As MemoryMappedFile = MemoryMappedFile.CreateNew("D2NT Profile", 71)
        If MemFile(mmf, a) = False Then Return

        ' mpq setting ?????



        Dim ApArgs As String = ""
        If Objects(a).WindowMode = 1 Then ApArgs = ApArgs & " -w"
        If Objects(a).D2Sound = 1 Then ApArgs = ApArgs & " -ns"
        If Objects(a).D2Quality = 1 Then ApArgs = ApArgs & " -lq"
        If Objects(a).D2DirectText = 1 Then ApArgs = ApArgs & " -direct -txt"


        Dim procstartinfo As ProcessStartInfo = New ProcessStartInfo()
        procstartinfo.Arguments = ApArgs
        procstartinfo.FileName = Objects(0).D2Path
        procstartinfo.UseShellExecute = False
        procstartinfo.WorkingDirectory = d2RelPath

        Dim p As Process = New Process()
        p.EnableRaisingEvents = True
        p.StartInfo = procstartinfo
        p = PInvoke.Extensions.StartSuspended(p, p.StartInfo) 'loads D2 into memory
        Objects(a).D2PID = p.Id

        'If Not PInvoke.Kernel32.LoadRemoteLibrary(p, Application.StartupPath & "\D2M.dll") Then RichTextBox3.AppendText(" Failed to load D2M.dll")

        'blocks 2nd instance check
        Dim oldValue(1) As Byte
        Dim newvalue() As Byte = {&HEB, &H45}
        Dim address As New IntPtr(&H6FA80000 + &HB6B0)
        Try 'a287
            If Not PInvoke.Kernel32.LoadRemoteLibrary(p, d2RelPath & "D2gfx.dll") Then RichTextBox3.AppendText(" Failed to load d2gfx")
            If Not PInvoke.Kernel32.ReadProcessMemory(p, address, oldValue) Then RichTextBox3.AppendText(" failed to read window fix")
            If PInvoke.Kernel32.WriteProcessMemory(p, address, newvalue) = 0 Then RichTextBox3.AppendText(" failed to write window fix")
        Catch
            RichTextBox3.AppendText(" error on window fix " & address.ToString)

        End Try

        'loads/injects dll
        If Not PInvoke.Kernel32.LoadRemoteLibrary(p, Application.StartupPath & "\D2ETAL.dll") Then RichTextBox3.AppendText(" Failed to load D2Etal.dll")

        'resume/start process
        PInvoke.Kernel32.ResumeProcess(p)
        Try
            p.WaitForInputIdle(3000)
        Catch ex As Exception
            If (ex.Message.Contains("exited") = True) Then dataGridView1.Rows(a).Cells(6).Value = "Exited"
            'MessageBox.Show(ex.Message)
        End Try


        mmf.Dispose()
        'removes instance check
        Try
            PInvoke.Kernel32.SuspendProcess(p)
            PInvoke.Kernel32.WriteProcessMemory(p, address, oldValue)
            PInvoke.Kernel32.ResumeProcess(p)
        Catch ex As Exception
            RichTextBox3.AppendText("Error reverting d2gfx patch")
        End Try

        If Objects(a).D2Minimized = 1 Then
            ShowWindow(p.MainWindowHandle, 2)
        End If


    End Sub

    Function timesetter()

        Dim tnow As System.DateTime = System.DateTime.Now
        Dim temp1 As String = tnow.Hour.ToString()
        If temp1.Length = 1 Then temp1 = "0" & temp1
        temp1 = temp1 & "."

        Dim temp2 = tnow.Minute.ToString()
        If temp2.Length = 1 Then temp2 = "0" & temp2
        temp2 = temp2 & "."
        Dim temp3 = tnow.Second.ToString()
        If temp3.Length = 1 Then temp3 = "0" & temp3
        temp3 = temp3 & "."
        temp1 = temp1 & temp2 & temp3 & " "
        Return temp1
    End Function

    Private Sub ColorSetter3(ByVal text As String)

        If text.ToString().Contains("Ã¿c") = False Then
            RichTextBox3.Select(0, 0) : RichTextBox3.SelectedText = vbCrLf
            RichTextBox3.Select(0, 0)
            RichTextBox3.SelectedText = text
            RichTextBox3.SelectionColor = Color.Black
            Return
        End If

        Dim temp1 = Split(text, "Ã¿c")
        RichTextBox3.Select(0, 0) : RichTextBox3.SelectedText = vbCrLf : RichTextBox3.Select(0, 0)
        For index = 0 To temp1.Length - 1
            Dim clr = temp1(index).Substring(0, 1)

            Select Case clr
                Case 0
                    RichTextBox3.SelectionColor = Color.LightGray
                Case 1
                    RichTextBox3.SelectionColor = Color.Red
                Case 2
                    RichTextBox3.SelectionColor = Color.Green
                Case 3
                    RichTextBox3.SelectionColor = Color.Blue
                Case 4
                    RichTextBox3.SelectionColor = Color.Goldenrod
                Case 5
                    RichTextBox3.SelectionColor = Color.Gray
                Case 6
                    RichTextBox3.SelectionColor = Color.Goldenrod
                Case 7
                    RichTextBox3.SelectionColor = Color.Goldenrod
                Case 8
                    RichTextBox3.SelectionColor = Color.DarkGreen
                Case 9
                    RichTextBox3.SelectionColor = Color.Yellow
                Case Else
                    RichTextBox3.SelectionColor = Color.Black
            End Select
            If clr = "[" Then
                RichTextBox3.SelectedText = temp1(index)
            Else
                RichTextBox3.SelectedText = temp1(index).Substring(1, temp1(index).Length - 2)
            End If
        Next

    End Sub

    Private Sub ColorSetter2(ByVal text As String)

        If text.ToString().Contains("Ã¿c") = False Then
            RichTextBox2.Select(0, 0) : RichTextBox2.SelectedText = vbCrLf
            RichTextBox2.Select(0, 0)
            RichTextBox2.SelectedText = text
            RichTextBox2.SelectionColor = Color.Black
            Return
        End If

        Dim temp1 = Split(text, "Ã¿c")
        RichTextBox2.Select(0, 0) : RichTextBox2.SelectedText = vbCrLf : RichTextBox2.Select(0, 0)
        For index = 0 To temp1.Length - 1
            Dim clr = temp1(index).Substring(0, 1)

            Select Case clr
                Case 0
                    RichTextBox2.SelectionColor = Color.LightGray
                Case 1
                    RichTextBox2.SelectionColor = Color.Red
                Case 2
                    RichTextBox2.SelectionColor = Color.Green
                Case 3
                    RichTextBox2.SelectionColor = Color.Blue
                Case 4
                    RichTextBox2.SelectionColor = Color.Goldenrod
                Case 5
                    RichTextBox2.SelectionColor = Color.Gray
                Case 6
                    RichTextBox2.SelectionColor = Color.Goldenrod
                Case 7
                    RichTextBox2.SelectionColor = Color.Goldenrod
                Case 8
                    RichTextBox2.SelectionColor = Color.DarkGreen
                Case 9
                    RichTextBox2.SelectionColor = Color.Yellow
                Case Else
                    RichTextBox2.SelectionColor = Color.Black
            End Select
            If clr = "[" Then
                RichTextBox2.SelectedText = temp1(index)
            Else
                RichTextBox2.SelectedText = temp1(index).Substring(1, temp1(index).Length - 2)
            End If
        Next
    End Sub
    Private Sub ColorSetter1(ByVal text As String)

        If text.ToString().Contains("Ã¿c") = False Then
            richTextBox1.Select(0, 0) : richTextBox1.SelectedText = vbCrLf
            richTextBox1.Select(0, 0)
            richTextBox1.SelectedText = text
            richTextBox1.SelectionColor = Color.Black
            Return
        End If

        Dim temp1 = Split(text, "Ã¿c")
        richTextBox1.Select(0, 0) : richTextBox1.SelectedText = vbCrLf : richTextBox1.Select(0, 0)
        For index = 0 To temp1.Length - 1
            Dim clr = temp1(index).Substring(0, 1)

            Select Case clr
                Case 0
                    richTextBox1.SelectionColor = Color.LightGray
                Case 1
                    richTextBox1.SelectionColor = Color.Red
                Case 2
                    richTextBox1.SelectionColor = Color.Green
                Case 3
                    richTextBox1.SelectionColor = Color.Blue
                Case 4
                    richTextBox1.SelectionColor = Color.Goldenrod
                Case 5
                    richTextBox1.SelectionColor = Color.Gray
                Case 6
                    richTextBox1.SelectionColor = Color.Goldenrod
                Case 7
                    richTextBox1.SelectionColor = Color.Goldenrod
                Case 8
                    richTextBox1.SelectionColor = Color.DarkGreen
                Case 9
                    richTextBox1.SelectionColor = Color.Yellow
                Case Else
                    richTextBox1.SelectionColor = Color.Black
            End Select
            If clr = "[" Then
                richTextBox1.SelectedText = temp1(index)
            Else
                richTextBox1.SelectedText = temp1(index).Substring(1, temp1(index).Length - 2)
            End If
        Next
    End Sub

    Public Sub datasend(ByVal a As Integer)


        Dim hTargetWnd As IntPtr = a
        'SendMessageCallback(hTargetWnd, WM_COPYDATA, Me.Handle, 0, 0, 1)

        'MessageBox.Show("value of Number = " + hTargetWnd)
        ' Prepare the COPYDATASTRUCT struct with the data to be sent.
        Dim myStruct As MyStruct



        myStruct.Number = 2
        myStruct.Message = "Boo"

        ' Marshal the managed struct to a native block of memory.
        Dim myStructSize As Integer = Marshal.SizeOf(myStruct)
        Dim pMyStruct As IntPtr = Marshal.AllocHGlobal(myStructSize)
        Try
            Marshal.StructureToPtr(myStruct, pMyStruct, True)

            Dim cds As New COPYDATASTRUCT
            cds.cbData = myStructSize
            cds.lpData = pMyStruct

            ' Send the COPYDATASTRUCT struct through the WM_COPYDATA message to 
            ' the receiving window. (The application must use SendMessage, 
            ' instead of PostMessage to send WM_COPYDATA because the receiving 
            ' application must accept while it is guaranteed to be valid.)
            NativeMethod.SendMessage(hTargetWnd, WM_COPYDATA, Me.Handle, cds)

            Dim result As Integer = Marshal.GetLastWin32Error
            If (result <> 0) Then
                'SendMessageCallback(hTargetWnd, WM_COPYDATA, Me.Handle, 0, 1, 0)
                MessageBox.Show(String.Format(
                    "SendMessage(WM_COPYDATA) failed w/err 0x{0:X}", result))
            End If
        Finally
            Marshal.FreeHGlobal(pMyStruct)
        End Try


    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) 

        Dim hTargetWnd As IntPtr = NativeMethod.FindWindow(Nothing, "Ned")
        datasend(hTargetWnd)
    End Sub
End Class
