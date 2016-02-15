﻿Imports System.ComponentModel
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
            Form1.dataGridView1.Rows(x).Cells(0).Value = Objects(x).ProfileName
            Form1.dataGridView1.Rows(x).Cells(2).Value = Objects(x).Run
            Form1.dataGridView1.Rows(x).Cells(3).Value = Objects(x).Restarts
            Form1.dataGridView1.Rows(x).Cells(4).Value = Objects(x).Chickens
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
        'MessageBox.Show("size = " & Marshal.SizeOf(prof), "Debug")

        prof.Account = Objects(x).AccountName
        prof.AccPass = Objects(x).AccPass
        prof.Charloc = Chr(Objects(x).CharPosition)
        prof.Difficulty = Chr(0)
        prof.Realm = Chr(Objects(x).Realm + 1)
        prof.ScriptFile = Objects(x).D2starter
        If Objects(x).D2PlayType = 0 Then
            prof.Realm = Chr(0)
        End If

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


End Module
