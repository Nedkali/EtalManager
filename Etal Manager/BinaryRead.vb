Imports System.ComponentModel
Imports System.IO
Imports System.IO.MemoryMappedFiles

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


    Function MemFile(ByVal x)
        Dim charval As Int32 = 0
        Dim temp1 = Split(Objects(x).CDkeys, ";")
        Dim currentcdkey = temp1(0) 'need to add a formula to determine key on swap
        Dim temp As String = ""
        Try
            Dim mmf As MemoryMappedFile = MemoryMappedFile.CreateOrOpen("D2NT Profile", 1010)
            Dim Stream As MemoryMappedViewStream = mmf.CreateViewStream()
            Dim writer As BinaryWriter = New BinaryWriter(Stream)


            For y = 0 To Objects(x).ProfileName.Length - 1 : writer.Write(Objects(x).ProfileName(y)) : writer.Write("") : Next
            For a = writer.BaseStream.Position To 63 : writer.Write("") : Next

            For y = 0 To Objects(x).D2Path.Length - 1 : writer.Write(Objects(x).D2Path(y)) : writer.Write("") : Next
            For a = writer.BaseStream.Position To 583 : writer.Write("") : Next

            writer.Write(Chr(Objects(x).WindowMode))
            writer.Write(Chr(Objects(x).D2Sound))
            writer.Write(Chr(Objects(x).D2Quality))
            writer.Write(Chr(Objects(x).D2DirectText))
            writer.Write(Chr(Objects(x).D2Minimized))
            writer.Write("")

            For y = 0 To currentcdkey.Length - 1 : writer.Write(currentcdkey(y)) : writer.Write("") : Next
            For a = writer.BaseStream.Position To 845 : writer.Write("") : Next

            For y = 0 To Objects(x).CDkeySwap.Length - 1 : writer.Write(Objects(x).CDkeySwap(y)) : writer.Write("") : Next
            For a = writer.BaseStream.Position To 851 : writer.Write("") : Next

            For y = 0 To Objects(x).AccountName.Length - 1 : writer.Write(Objects(x).AccountName(y)) : writer.Write("") : Next
            For a = writer.BaseStream.Position To 899 : writer.Write("") : Next

            For y = 0 To Objects(x).GameName.Length - 1 : writer.Write(Objects(x).GameName(y)) : writer.Write("") : Next
            For a = writer.BaseStream.Position To 923 : writer.Write("") : Next
            'MessageBox.Show("Current file position = " & writer.BaseStream.Position)

            For y = 0 To Objects(x).GamePass.Length - 1 : writer.Write(Objects(x).GamePass(y)) : writer.Write("") : Next
            For a = writer.BaseStream.Position To 939 : writer.Write("") : Next
            'MessageBox.Show("Current file position = " & writer.BaseStream.Position)

            writer.Write(Chr(Objects(x).D2PlayType))
            writer.Write(Chr(Objects(x).Realm))
            writer.Write(Chr(Objects(x).D2Difficulty))
            writer.Write(Chr(Objects(x).CharPosition))
            writer.Write(Chr(Objects(x).randomGame))
            writer.Write(Chr(Objects(x).randompass))

            writer.BaseStream.Position = 946
            For y = 0 To Objects(x).D2starter.Length - 1 : writer.Write(Objects(x).D2starter(y)) : writer.Write("") : Next
            For a = writer.BaseStream.Position To 1010 : writer.Write("") : Next

            writer.Close()
        Catch ex As Exception
            MessageBox.Show("Error mmf - ?mmf still open")
            Return False

        End Try
        Form1.dataGridView1.Rows(x).Cells(1).Value = currentcdkey
        Return True


    End Function

    Function MemFile2(ByVal x)
        Try
            Dim mmf As MemoryMappedFile = MemoryMappedFile.CreateOrOpen("D2NT Profile", 1010)
            Dim Stream As MemoryMappedViewStream = mmf.CreateViewStream()
            Dim writer As BinaryWriter = New BinaryWriter(Stream)

            For y = 0 To Objects(x).AccountName.Length - 1 : writer.Write(Objects(x).AccountName(y)) : Next
            For a = writer.BaseStream.Position To 25 : writer.Write("") : Next

            For y = 0 To Objects(x).AccPass.Length - 1 : writer.Write(Objects(x).AccPass(y)) : Next
            For a = writer.BaseStream.Position To 13 : writer.Write("") : Next

            For y = 0 To Objects(x).ProfileName.Length - 1 : writer.Write(Objects(x).AccPass(y)) : Next
            For a = writer.BaseStream.Position To 13 : writer.Write("") : Next

            writer.Write(Chr(Objects(x).Realm))
            writer.Write(Chr(0))

            Dim temp = "Mulelogger.ntj"
            For y = 0 To temp.Length - 1 : writer.Write(temp(y)) : Next
            For a = writer.BaseStream.Position To 33 : writer.Write("") : Next

            writer.Close()
        Catch ex As Exception
            MessageBox.Show("Error mmf - ?mmf still open")
        Return False

        End Try

        Return True

    End Function
End Module
