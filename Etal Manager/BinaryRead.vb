Imports System.ComponentModel
Imports System.IO
Imports System.IO.MemoryMappedFiles
Imports System.Runtime.InteropServices

Module BinaryRead
    'reads binary file and copy to profile class
    Public Sub ReadBinary()
        Dim fileName = Application.StartupPath & "\D2NT Manager.cfg"
        'Form1.dataGridView1.Rows.Clear()

        Dim temp As String = ""
        Dim bite As Byte = Nothing
        Dim count As Integer = 0
        Dim x As Integer = 0


        Dim reader = New BinaryReader(File.Open(fileName, FileMode.Open))
        Dim a = reader.BaseStream.Length
        If a < 1010 Then Return

        For x = 0 To (a / 1010) - 1

            Dim NewObject As New Profiles
            'MessageBox.Show("File Length = " & x, "Debug Keys")
            For index = 0 To 64 Step 2 'Profile name
                bite = reader.ReadByte()
                If bite <> Nothing Then temp = temp + Chr(bite)
                If bite = Nothing Then reader.BaseStream.Position = 64 + (x * 1010) : Exit For
                bite = reader.ReadByte() 'handles null spaces
            Next
            NewObject.ProfileName = temp : temp = ""
            'MessageBox.Show(NewObject.ProfileName, "Debug Keys")


            ' d2path
            For index = 64 To 584 Step 2
                bite = reader.ReadByte()
                If bite <> Nothing Then temp = temp + Chr(bite)
                If bite = Nothing Then reader.BaseStream.Position = 584 + (x * 1010) : Exit For
                bite = reader.ReadByte() 'handles null spaces
            Next
            NewObject.D2Path = temp : temp = ""

            'option flags
            NewObject.WindowMode = reader.ReadByte()
            NewObject.D2Sound = reader.ReadByte()
            NewObject.D2Quality = reader.ReadByte()
            NewObject.D2DirectText = reader.ReadByte()
            NewObject.D2Minimized = reader.ReadByte()
            reader.ReadByte()

            ' cdkeys
            For index = 590 To 846 Step 2
                bite = reader.ReadByte()
                If bite <> Nothing Then temp = temp + Chr(bite)
                If bite = Nothing Then reader.BaseStream.Position = 846 + (x * 1010) : Exit For
                bite = reader.ReadByte() 'handles null spaces
            Next
            NewObject.CDkeys = temp : temp = ""
            'MessageBox.Show(NewObject.CDkeys, "Debug Keys")


            'games per key
            temp = Chr(reader.ReadByte()) : reader.ReadByte()
            temp = temp + Chr(reader.ReadByte())
            NewObject.CDkeySwap = temp : temp = ""
            'MessageBox.Show(NewObject.CDkeys, "Debug games/key")

            reader.ReadBytes(3)

            ' account name
            For index = 852 To 898 Step 2
                bite = reader.ReadByte()
                If bite <> Nothing Then temp = temp + Chr(bite)
                If bite = Nothing Then reader.BaseStream.Position = 900 + (x * 1010) : Exit For
                bite = reader.ReadByte() 'handles null spaces
            Next
            NewObject.AccountName = temp : temp = ""
            ' MessageBox.Show(NewObject.AccountName, "Debug Account name")


            For index = 900 To 922 Step 2 ' game name
                bite = reader.ReadByte()
                If bite <> Nothing Then temp = temp + Chr(bite)
                If bite = Nothing Then reader.BaseStream.Position = 924 + (x * 1010) : Exit For
                bite = reader.ReadByte() 'handles null spaces
            Next
            NewObject.GameName = temp : temp = ""
            'MessageBox.Show(NewObject.GameName, "Debug Binary")


            reader.BaseStream.Position = 924 : temp = ""
            For index = 924 To 940 Step 2 ' game pass
                bite = reader.ReadByte()
                If bite <> Nothing Then temp = temp + Chr(bite)
                If bite = Nothing Then reader.BaseStream.Position = 940 + (x * 1010) : Exit For
                bite = reader.ReadByte() 'handles null spaces
            Next
            NewObject.GamePass = temp : temp = ""
            'MessageBox.Show(NewObject.GamePass, "Debug Game Pass")

            NewObject.D2PlayType = reader.ReadByte()
            NewObject.Realm = reader.ReadByte()
            NewObject.D2Difficulty = reader.ReadByte()
            NewObject.CharPosition = reader.ReadByte()
            NewObject.randomGame = reader.ReadByte()
            NewObject.randompass = reader.ReadByte()

            'reader.ReadByte()
            For index = 946 To 1010 Step 2 ' entry point
                bite = reader.ReadByte()
                If bite <> Nothing Then temp = temp + Chr(bite)
                If bite = Nothing Then Exit For
                bite = reader.ReadByte() 'handles null spaces
            Next

            NewObject.D2starter = temp : temp = ""
            'MessageBox.Show(NewObject.D2starter, "Debug Loader")

            reader.BaseStream.Position = 1010 + (x * 1010)
            Objects.Add(NewObject)


            Form1.dataGridView1.Rows.Add(1)
        Next
        reader.Close()

        For x = 0 To Objects.Count - 1
            Form1.dataGridView1.Rows(x).SetValues(Objects(x).ProfileName, "", Objects(x).Run, Objects(x).Restarts, Objects(x).Deaths, Objects(x).Chickens, "")
        Next


    End Sub

    Public Sub BWrite()

        Dim fileName = Application.StartupPath & "\D2NT Manager.cfg"
        Try
            Dim bwriter = New BinaryWriter(File.Open(fileName, FileMode.Create))


            Dim temp As String
            Dim y As Integer = 0
            Dim a As Integer = 0
            Dim bite As Byte = Nothing
            For i = 0 To Objects.Count - 1

                temp = Objects(i).ProfileName
                For y = 0 To temp.Length - 1 : bwriter.Write(temp(y)) : bwriter.Write("") : Next
                For a = temp.Length * 2 To 63 : bwriter.Write("") : Next

                temp = Objects(i).D2Path
                For y = 0 To temp.Length - 1 : bwriter.Write(temp(y)) : bwriter.Write("") : Next
                For a = temp.Length * 2 To 519 : bwriter.Write("") : Next

                bite = Objects(i).WindowMode : bwriter.Write(bite)
                bite = Objects(i).D2Sound : bwriter.Write(bite)
                bite = Objects(i).D2Quality : bwriter.Write(bite)
                bite = Objects(i).D2DirectText : bwriter.Write(bite)
                bite = Objects(i).D2Minimized : bwriter.Write(bite)
                bwriter.Write("")

                temp = Objects(i).CDkeys
                For y = 0 To temp.Length - 1 : bwriter.Write(temp(y)) : bwriter.Write("") : Next
                For a = temp.Length * 2 To 255 : bwriter.Write("") : Next

                temp = Objects(i).CDkeySwap
                For y = 0 To temp.Length - 1 : bwriter.Write(temp(y)) : bwriter.Write("") : Next
                For a = temp.Length * 2 To 5 : bwriter.Write("") : Next

                temp = Objects(i).AccountName
                For y = 0 To temp.Length - 1 : bwriter.Write(temp(y)) : bwriter.Write("") : Next
                For a = temp.Length * 2 To 47 : bwriter.Write("") : Next

                temp = Objects(i).GameName
                For y = 0 To temp.Length - 1 : bwriter.Write(temp(y)) : bwriter.Write("") : Next
                For a = temp.Length * 2 To 23 : bwriter.Write("") : Next

                temp = Objects(i).GamePass
                For y = 0 To temp.Length - 1 : bwriter.Write(temp(y)) : bwriter.Write("") : Next
                For a = temp.Length * 2 To 15 : bwriter.Write("") : Next

                bite = Objects(i).D2PlayType : bwriter.Write(bite)
                bite = Objects(i).Realm : bwriter.Write(bite)
                bite = Objects(i).D2Difficulty : bwriter.Write(bite)
                bite = Objects(i).CharPosition : bwriter.Write(bite)
                bite = Objects(i).randomGame : bwriter.Write(bite)
                bite = Objects(i).randompass : bwriter.Write(bite)

                temp = Objects(i).D2starter
                For y = 0 To temp.Length - 1 : bwriter.Write(temp(y)) : bwriter.Write("") : Next
                For a = temp.Length * 2 To 63 : bwriter.Write("") : Next

            Next


            bwriter.Close()
        Catch ex As Exception
            Return
        End Try

    End Sub


    Function MemFile(ByVal mmf, ByVal x)
        Dim prof As Profile

        prof.Account = Objects(x).AccountName
        prof.AccPass = Objects(x).AccPass
        'prof.MpqFile = Form1.dataGridView1.Rows(x).Cells(1).Value
        prof.Charloc = Objects(x).CharPosition

        'MessageBox.Show(Marshal.SizeOf(prof))



        prof.RandomGameName = Objects(x).randomGame
        prof.RandomGamePass = Objects(x).randompass

        prof.Difficulty = 0
        If Objects(x).D2starter <> "Loader only" Then
            prof.ScriptFile = Objects(x).D2starter
        End If

        If Objects(x).D2PlayType = 0 Then
            prof.Realm = 0
        Else
            prof.Realm = Objects(x).Realm
        End If

        Dim ckey = assignkeys(x)

        If ckey >= 0 Then
            prof.KeyOwner = totalkeys(ckey).name
            prof.Classic = totalkeys(ckey).classic
            prof.Lod = totalkeys(ckey).lod
            Form1.dataGridView1.Rows(x).Cells(1).Value = totalkeys(ckey).name
        End If

        'random game needs to be moved to dll later?
        If Objects(x).randomGame = 0 Then
            prof.GameName = Objects(x).GameName
        Else
            prof.GameName = Form1.GenerateRandomString(8)
        End If

        'random password needs to be moved to dll later?
        If Objects(x).randompass = 0 Then
            prof.GamePass = Objects(x).GamePass
        Else
            prof.GamePass = Form1.GenerateRandomString(6)
        End If
        'MessageBox.Show(prof.MpqFile, "mpq Debug 2")

        Dim Ptr As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(prof))
        Dim ByteArray(Marshal.SizeOf(prof) - 1) As Byte
        Marshal.StructureToPtr(prof, Ptr, False)
        Marshal.Copy(Ptr, ByteArray, 0, Marshal.SizeOf(prof))
        Marshal.FreeHGlobal(Ptr)

        Try
            Dim Stream As MemoryMappedViewStream = mmf.CreateViewStream()
            Dim writer As BinaryWriter = New BinaryWriter(Stream)
            For index = 0 To ByteArray.Count - 1
                writer.Write(Chr(ByteArray(index)))
            Next

            writer.Close()
        Catch ex As Exception
            Form1.RichTextBox3.AppendText(ex.Message & vbCrLf)
            Return False
        End Try

        Return True

    End Function
    Function assignkeys(ByVal x)
        Dim xx = 0
        totalkeys.Clear()
        Dim mpqkeys As Array
        Dim rawkeys As Array
        Dim usekey As String = ""
        If Objects(x).CDkeys <> Nothing Then
            mpqkeys = Objects(x).CDkeys.Split(";")
            'MessageBox.Show("here checking mpq's")
            For index = 0 To mpqkeys.Length - 1
                Dim newkeys As New keyholder
                If mpqkeys(index) = Nothing Then Continue For
                newkeys.name = mpqkeys(index)
                newkeys.classic = ""
                newkeys.lod = ""
                totalkeys.Add(newkeys)
            Next
        End If
        'MessageBox.Show("here checking totalkeys" & totalkeys.Count)

        If Objects(x).CDkeyOwner <> Nothing Then
            rawkeys = Objects(x).CDkeyOwner.Split(";")
            For index = 0 To rawkeys.Length - 1
                Dim newkeys As New keyholder
                If Objects(x).CDkeyOwner.Split(";")(index) = Nothing Then Continue For
                newkeys.name = Objects(x).CDkeyOwner.Split(";")(index)
                newkeys.classic = Objects(x).CDkeyClassic.Split(";")(index)
                newkeys.lod = Objects(x).CDkeyExpansion.Split(";")(index)
                totalkeys.Add(newkeys)
            Next
        End If


        Dim gamesperkey = 0  ' games per key
        If Objects(x).CDkeySwap <> Nothing Then
            gamesperkey = Convert.ToInt32(Objects(x).CDkeySwap)
        End If

        Dim gamecount = Convert.ToInt32(Form1.dataGridView1.Rows(x).Cells(2).Value) 'current game count

        If totalkeys.Count = 0 Then Return -1

        If gamesperkey > 0 And gamecount > 0 Then
            Dim d = gamecount / gamesperkey
            xx = Int(d Mod totalkeys.Count)
        End If

        Return xx
    End Function

End Module
