Imports System.ComponentModel
Imports System.IO
Imports System.IO.MemoryMappedFiles
Imports System.Runtime.InteropServices

Module BinaryRead

    Function MemFile(ByVal mmf, ByVal x)
        Dim prof As Profile

        prof.Account = Objects(x).AccountName
        prof.AccPass = Objects(x).AccPass
        'prof.MpqFile = Manager.ProfilesDataGrid.Rows(x).Cells(1).Value
        prof.Charloc = Objects(x).CharPosition

        'MessageBox.Show(Marshal.SizeOf(prof))



        prof.RandomGameName = Objects(x).randomGame
        prof.RandomGamePass = Objects(x).randompass

        prof.Difficulty = Objects(x).D2Difficulty

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
            Manager.ProfilesDataGrid.Rows(x).Cells(1).Value = totalkeys(ckey).name
        Else
            Manager.ProfilesDataGrid.Rows(x).Cells(1).Value = "Default"
        End If

        'random game needs to be moved to dll later?
        If Objects(x).randomGame = 0 Then
            prof.GameName = Objects(x).GameName
        Else
            prof.GameName = Manager.GenerateRandomString(8)
        End If

        'random password needs to be moved to dll later?
        If Objects(x).randompass = 0 Then
            prof.GamePass = Objects(x).GamePass
        Else
            prof.GamePass = Manager.GenerateRandomString(6)
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
            Manager.AddToMessageLogs("[" & Manager.timesetter() & Objects(x).ProfileName & "]" & ex.Message, Manager.ErrorTextBox)
            Return False
        End Try

        Return True

    End Function
    Function assignkeys(ByVal x)
        Dim xx = 0
        totalkeys.Clear()
        Dim rawkeys As Array

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

        Dim gamecount = Manager.ProfilesDataGrid.Rows(x).Cells(2).Value 'current game count

        If totalkeys.Count = 0 Then Return -1

        If gamesperkey = 0 And totalkeys.Count > 0 Then Return 0

        If gamesperkey > 0 And gamecount > 0 Then
            Dim d = gamecount / gamesperkey
            xx = Int(d Mod totalkeys.Count)
        End If

        Return xx
    End Function

End Module
