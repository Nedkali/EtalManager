Imports System.IO.MemoryMappedFiles
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Security.Principal




Public Class Manager



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
                        ProfilesDataGrid.Rows(x).Cells(6).Value = temp
                    Case ETAL_MGR_READY
                        ProfilesDataGrid.Rows(x).Cells(6).Value = temp
                    Case ETAL_MGR_LOGIN
                        ProfilesDataGrid.Rows(x).Cells(6).Value = "Login"
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] Login")
                    Case ETAL_MGR_CREATE_GAME
                        ProfilesDataGrid.Rows(x).Cells(6).Value = "Game Create"
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] Game Create")
                    Case ETAL_MGR_INGAME
                        y = Convert.ToInt32(ProfilesDataGrid.Rows(x).Cells(2).Value)
                        y = y + 1
                        ProfilesDataGrid.Rows(x).Cells(2).Value = y
                        ProfilesDataGrid.Rows(x).Cells(6).Value = "In Game"
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] In Game(" & y & ")")
                    Case ETAL_MGR_RESTART
                        ProfilesDataGrid.Rows(x).Cells(6).Value = "Restarting"
                    Case ETAL_MGR_CHICKEN
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] " & temp)
                    Case ETAL_MGR_PRINT_STATUS
                        ProfilesDataGrid.Rows(x).Cells(6).Value = temp
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] " & temp)
                    Case ETAL_MGR_COMMON
                        ColorSetter1("[" & temp1 + Objects(x).ProfileName & "] " & temp)
                    Case ETAL_MGR_ITEM_LOG
                        ColorSetter2("[" & temp1 + Objects(x).ProfileName & "] " & temp)
                    Case ETAL_MGR_ERROR_LOG
                        ColorSetter3("[" & temp1 + Objects(x).ProfileName & "] " & temp)
                    Case 555
                        Dim ckey = assignkeys(x)
                        If ckey >= 0 And totalkeys(ckey).name <> ProfilesDataGrid.Rows(x).Cells(1).Value Then
                            restart(x)
                        End If

                    Case 6153 ' used for dll to check if manager present
                        m.Result = 0
                        ColorSetter3("[" & temp1 + Objects(x).ProfileName & "] Continuing next game")

                    Case Else
                        ColorSetter3("[" & temp1 + "Unknown]" & temp)
                End Select
                cds = Nothing

        End Select
        MyBase.WndProc(m)
    End Sub

    Private Sub Manager_Load(sender As Object, e As EventArgs) Handles Me.Load
        ProfilesDataGrid.Rows.Add(9)
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



    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Application.Exit()
    End Sub

    Private Sub wwwetalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles wwwetalToolStripMenuItem.Click
        Process.Start("www.projectetal.com")
    End Sub

    Private Sub WikiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WikiToolStripMenuItem.Click
        Process.Start("www.projectetal.com/wiki/index.php/Main_Page")
    End Sub

    Private Sub RemoveButton_Click(sender As Object, e As EventArgs) Handles RemoveButton.Click
        Dim x As Integer = ProfilesDataGrid.CurrentRow.Index
        If x < 0 Or x > Objects.Count - 1 Or Objects.Count = 0 Then Return
        For index = 0 To Objects.Count - 1
            If Objects(index).D2PID > 0 Then Return
        Next
        ProfilesDataGrid.Rows.RemoveAt(x)
        Objects.RemoveAt(x)
        If ProfilesDataGrid.RowCount < 9 Then ProfilesDataGrid.Rows.Add(1)

    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
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
                'LogWriter.Write(Objects(x).CDkeys & ",")
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
            ColorSetter3("[" & timesetter() + "Error] " & ex.Message)
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
                If myarray.Length <> 20 Then
                    MessageBox.Show(myarray.Length)
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
                'NewObject.CDkeys = myarray(7)
                NewObject.CDkeySwap = myarray(7)
                NewObject.AccountName = myarray(8)
                NewObject.AccPass = myarray(9)
                NewObject.D2PlayType = myarray(10)
                NewObject.D2Difficulty = myarray(11)
                NewObject.Realm = myarray(12)
                NewObject.GameName = myarray(13)
                NewObject.GamePass = myarray(14)
                NewObject.CharPosition = myarray(15)
                NewObject.D2starter = myarray(16)
                NewObject.CDkeyOwner = myarray(17)
                NewObject.CDkeyClassic = myarray(18)
                NewObject.CDkeyExpansion = myarray(19)
                Objects.Add(NewObject)
            End While

            CfgReader.Close()

        Catch ex As Exception
            ColorSetter3("[" & timesetter() & "Error] File Read Error")

        End Try
        For x = 0 To Objects.Count - 1
            If ProfilesDataGrid.RowCount < Objects.Count Then ProfilesDataGrid.Rows.Add(1)
            ProfilesDataGrid.Rows(x).Cells(0).Value = Objects(x).ProfileName
            ProfilesDataGrid.Rows(x).Cells(2).Value = 0
            ProfilesDataGrid.Rows(x).Cells(3).Value = 0
            ProfilesDataGrid.Rows(x).Cells(4).Value = 0
            ProfilesDataGrid.Rows(x).Cells(5).Value = 0
        Next
    End Sub


    Private Sub RunButton_Click(sender As Object, e As EventArgs) Handles RunButton.Click

        Dim a As Integer = ProfilesDataGrid.CurrentRow.Index
        If a < 0 Or a > Objects.Count - 1 Then Return
        launchd2(a)

    End Sub

    Private Sub MoveUp_Click(sender As Object, e As EventArgs) Handles MoveUp.Click
        Dim x As Integer = ProfilesDataGrid.CurrentRow.Index
        If x < 1 Or x > Objects.Count - 1 Or Objects.Count = 0 Then Return

        For index = 0 To Objects.Count - 1
            If Objects(index).D2PID > 0 Then Return
        Next

        Dim NewObject As New Profiles

        NewObject = Objects(x)
        Objects.RemoveAt(x)
        Objects.Insert(x - 1, NewObject)

        For y = 0 To Objects.Count - 1
            ProfilesDataGrid.Rows(y).Cells(0).Value = Objects(y).ProfileName
        Next
        ProfilesDataGrid.Rows(x - 1).Selected = True
        ProfilesDataGrid.CurrentCell = ProfilesDataGrid.Item(0, x - 1)
    End Sub

    Private Sub MoveDown_Click(sender As Object, e As EventArgs) Handles MoveDown.Click
        Dim x As Integer = ProfilesDataGrid.CurrentRow.Index
        If x < 0 Or x > Objects.Count - 2 Or Objects.Count = 0 Then Return

        For index = 0 To Objects.Count - 1
            If Objects(index).D2PID > 0 Then Return
        Next

        Dim NewObject As New Profiles
        NewObject = Objects(x)
        Objects.RemoveAt(x)
        Objects.Insert(x + 1, NewObject)

        For y = 0 To Objects.Count - 1
            ProfilesDataGrid.Rows(y).Cells(0).Value = Objects(y).ProfileName
        Next

        ProfilesDataGrid.Rows(x + 1).Selected = True
        ProfilesDataGrid.CurrentCell = ProfilesDataGrid.Item(0, x + 1)

    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        Dim a As Integer = ProfilesDataGrid.CurrentRow.Index
        If a > Objects.Count - 1 Then Return

        For Each proc As Process In Process.GetProcessesByName("Game")
            If proc.Id = Objects(a).D2PID Then
                proc.Kill()
            End If
        Next
        Objects(a).D2PID = 0
        ProfilesDataGrid.Rows(a).Cells(1).Value = ""
        ProfilesDataGrid.Rows(a).Cells(6).Value = ""

    End Sub

    Private Sub CopyButton_Click(sender As Object, e As EventArgs) Handles CopyButton.Click
        Dim a As Integer = ProfilesDataGrid.CurrentRow.Index
        If a < 0 Or a > Objects.Count - 1 Then Return
        Dim newobject = New Profiles

        newobject.ProfileName = Objects(a).ProfileName
        newobject.D2Path = Objects(a).D2Path
        newobject.WindowMode = Objects(a).WindowMode
        newobject.D2Sound = Objects(a).D2Sound
        newobject.D2Quality = Objects(a).D2Quality
        newobject.D2DirectText = Objects(a).D2DirectText
        newobject.D2Minimized = Objects(a).D2Minimized
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
        ProfilesDataGrid.Rows(a).Cells(0).Value = Objects(a).ProfileName
        ProfilesDataGrid.Rows(a).Cells(2).Value = Objects(a).Run
        ProfilesDataGrid.Rows(a).Cells(3).Value = Objects(a).Restarts
        ProfilesDataGrid.Rows(a).Cells(4).Value = Objects(a).Chickens
        If a > 5 Then a = a - 5
        If a < 5 Then a = 0
        ProfilesDataGrid.FirstDisplayedScrollingRowIndex = a
        ProfilesDataGrid.CurrentCell = ProfilesDataGrid.Item(0, Objects.Count - 1)


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
        ProfilesDataGrid.Rows(a).Cells(1).Value = ""
        ProfilesDataGrid.Rows(a).Cells(6).Value = ""
        Thread.Sleep(2000)
        launchd2(a)

    End Sub

    Private Sub launchd2(ByVal a)

        If Objects(a).D2PID > 0 Then
            Dim d2app = Process.GetProcessesByName("Game")
            For Each process In d2app
                If process.Id = Objects(a).D2PID Then
                    'ColorSetter1("[" & timesetter() + Objects(a).ProfileName & "]" & "Ã¿c1Profile already running")
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
            ColorSetter1("[" & timesetter() + "Error] Unable to locate Game.exe")
            Return
        End If



        Dim mmf As MemoryMappedFile = MemoryMappedFile.CreateNew("D2NT Profile", 71)
        If MemFile(mmf, a) = False Then Return


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

        'blocks 2nd instance check
        Dim address As New IntPtr(&H400000 + &H57C8)
        Dim oldValue(1) As Byte
        Dim newvalue() As Byte = {&HEB, &H46}
        Try 'a287
            If Not PInvoke.Kernel32.ReadProcessMemory(p, address, oldValue) Then ColorSetter3("[" & timesetter() + Objects(a).ProfileName & "] Ã¿c1failed to read window fix")
            If PInvoke.Kernel32.WriteProcessMemory(p, address, newvalue) = 0 Then ColorSetter3("[" & timesetter() + Objects(a).ProfileName & "] Ã¿c1failed to write window fix")
        Catch
            ColorSetter3("[" & timesetter() + "Error] error on window fix " & address.ToString)

        End Try

        'loads/injects dll
        If Not PInvoke.Kernel32.LoadRemoteLibrary(p, Application.StartupPath & "\D2ETAL.dll") Then ColorSetter3("[" & timesetter() + "Error]  Ã¿c1Failed to load D2Etal.dll")

        'resume/start process
        PInvoke.Kernel32.ResumeProcess(p)
        Try
            p.WaitForInputIdle(3000)
        Catch ex As Exception
            If (ex.Message.Contains("exited") = True) Then ProfilesDataGrid.Rows(a).Cells(6).Value = "Exited"
            'MessageBox.Show(ex.Message)
        End Try


        mmf.Dispose()
        'removes instance check
        Try
            PInvoke.Kernel32.SuspendProcess(p)
            PInvoke.Kernel32.WriteProcessMemory(p, address, oldValue)
            PInvoke.Kernel32.ResumeProcess(p)
        Catch ex As Exception
            ColorSetter3("[" & timesetter() + Objects(a).ProfileName & "] Ã¿c1Error reverting d2gfx patch")
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

    Public Sub ColorSetter3(ByVal text As String)

        If text.ToString().Contains("Ã¿c") = False Then
            ErrorTextBox.Select(0, 0) : ErrorTextBox.SelectedText = vbCrLf
            ErrorTextBox.Select(0, 0)
            ErrorTextBox.SelectedText = text
            ErrorTextBox.SelectionColor = Color.Black
            Return
        End If

        Dim temp1 = Split(text, "Ã¿c")
        ErrorTextBox.Select(0, 0) : ErrorTextBox.SelectedText = vbCrLf : ErrorTextBox.Select(0, 0)
        For index = 0 To temp1.Length - 1
            Dim clr = temp1(index).Substring(0, 1)

            Select Case clr
                Case 0
                    ErrorTextBox.SelectionColor = Color.LightGray
                Case 1
                    ErrorTextBox.SelectionColor = Color.Red
                Case 2
                    ErrorTextBox.SelectionColor = Color.Green
                Case 3
                    ErrorTextBox.SelectionColor = Color.Blue
                Case 4
                    ErrorTextBox.SelectionColor = Color.Goldenrod
                Case 5
                    ErrorTextBox.SelectionColor = Color.Gray
                Case 6
                    ErrorTextBox.SelectionColor = Color.Goldenrod
                Case 7
                    ErrorTextBox.SelectionColor = Color.Goldenrod
                Case 8
                    ErrorTextBox.SelectionColor = Color.DarkGreen
                Case 9
                    ErrorTextBox.SelectionColor = Color.Yellow
                Case Else
                    ErrorTextBox.SelectionColor = Color.Black
            End Select
            If clr = "[" Then
                ErrorTextBox.SelectedText = temp1(index)
            Else
                ErrorTextBox.SelectedText = temp1(index).Substring(1, temp1(index).Length - 2)
            End If
        Next

    End Sub

    Public Sub ColorSetter2(ByVal text As String)

        If text.ToString().Contains("Ã¿c") = False Then
            ItemTextBox.Select(0, 0) : ItemTextBox.SelectedText = vbCrLf
            ItemTextBox.Select(0, 0)
            ItemTextBox.SelectedText = text
            ItemTextBox.SelectionColor = Color.Black
            Return
        End If

        Dim temp1 = Split(text, "Ã¿c")
        ItemTextBox.Select(0, 0) : ItemTextBox.SelectedText = vbCrLf : ItemTextBox.Select(0, 0)
        For index = 0 To temp1.Length - 1
            Dim clr = temp1(index).Substring(0, 1)

            Select Case clr
                Case 0
                    ItemTextBox.SelectionColor = Color.LightGray
                Case 1
                    ItemTextBox.SelectionColor = Color.Red
                Case 2
                    ItemTextBox.SelectionColor = Color.Green
                Case 3
                    ItemTextBox.SelectionColor = Color.Blue
                Case 4
                    ItemTextBox.SelectionColor = Color.Goldenrod
                Case 5
                    ItemTextBox.SelectionColor = Color.Gray
                Case 6
                    ItemTextBox.SelectionColor = Color.Goldenrod
                Case 7
                    ItemTextBox.SelectionColor = Color.Goldenrod
                Case 8
                    ItemTextBox.SelectionColor = Color.DarkGreen
                Case 9
                    ItemTextBox.SelectionColor = Color.Yellow
                Case Else
                    ItemTextBox.SelectionColor = Color.Black
            End Select
            If clr = "[" Then
                ItemTextBox.SelectedText = temp1(index)
            Else
                ItemTextBox.SelectedText = temp1(index).Substring(1, temp1(index).Length - 2)
            End If
        Next
    End Sub
    Public Sub ColorSetter1(ByVal text As String)

        If text.ToString().Contains("Ã¿c") = False Then
            CommonLogRTB.Select(0, 0) : CommonLogRTB.SelectedText = vbCrLf
            CommonLogRTB.Select(0, 0)
            CommonLogRTB.SelectedText = text
            CommonLogRTB.SelectionColor = Color.Black
            Return
        End If

        Dim temp1 = Split(text, "Ã¿c")
        CommonLogRTB.Select(0, 0) : CommonLogRTB.SelectedText = vbCrLf : CommonLogRTB.Select(0, 0)
        For index = 0 To temp1.Length - 1
            Dim clr = temp1(index).Substring(0, 1)

            Select Case clr
                Case 0
                    CommonLogRTB.SelectionColor = Color.LightGray
                Case 1
                    CommonLogRTB.SelectionColor = Color.Red
                Case 2
                    CommonLogRTB.SelectionColor = Color.Green
                Case 3
                    CommonLogRTB.SelectionColor = Color.Blue
                Case 4
                    CommonLogRTB.SelectionColor = Color.Goldenrod
                Case 5
                    CommonLogRTB.SelectionColor = Color.Gray
                Case 6
                    CommonLogRTB.SelectionColor = Color.Goldenrod
                Case 7
                    CommonLogRTB.SelectionColor = Color.Goldenrod
                Case 8
                    CommonLogRTB.SelectionColor = Color.DarkGreen
                Case 9
                    CommonLogRTB.SelectionColor = Color.Yellow
                Case Else
                    CommonLogRTB.SelectionColor = Color.Black
            End Select
            If clr = "[" Then
                CommonLogRTB.SelectedText = temp1(index)
            Else
                CommonLogRTB.SelectedText = temp1(index).Substring(1, temp1(index).Length - 2)
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

    Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
        ProfileEditoraction = ""
        editposition = -1
        ProfileEditor.ShowDialog()
    End Sub

    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click

        Dim x As Integer = ProfilesDataGrid.CurrentRow.Index
        If x < 0 Or x > Objects.Count - 1 Or Objects.Count = 0 Then Return ' out of range handling
        If Objects(x).D2PID > 0 Then Return ' profile already running
        ProfileEditoraction = "edit"
        editposition = x
        Objects(x).AccPass = ""
        ProfileEditor.ShowDialog()
    End Sub

End Class
