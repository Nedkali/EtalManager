Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.IO
Imports System.Reflection

Namespace PInvoke
    Public Enum ThreadAccessFlags As UInteger
        Terminate = &H1
        SuspendResume = &H2
        GetContext = &H8
        SetContext = &H10
        SetInformation = &H20
        QueryInformation = &H40
        SetThreadToken = &H80
        Impersonate = &H100
        DirectImpersonate = &H200
        SetLimitedInformation = &H400
        QueryLimitedInformation = &H800
    End Enum
    <Flags()>
    Public Enum ProcessAccessFlags As UInteger
        All = &H1F0FFF
        Terminate = &H1
        CreateThread = &H2
        VMOperation = &H8
        VMRead = &H10
        VMWrite = &H20
        DupHandle = &H40
        SetInformation = &H200
        QueryInformation = &H400
        Synchronize = &H100000
    End Enum
    <Flags()>
    Public Enum ProcessCreationFlags As UInteger
        BreakawayFromJob = &H1000000
        DefaultErrorMode = &H4000000
        NewConsole = &H10
        NewProcessGroup = &H200
        NoWindow = &H8000000
        ProtectedProcess = &H40000
        PreserveCodeAuthzLevel = &H2000000
        SeparateWowVdm = &H800
        SharedWowVdm = &H1000
        Suspended = &H4
        UnicodeEnvironment = &H400
        DebugOnlyThisProcess = &H2
        DebugProcess = &H1
        DetachedProcess = &H8
        ExtendedStartupInfo = &H80000
        InheritParentAffinity = &H10000
    End Enum
    <Flags()>
    Public Enum LoadLibraryFlags As UInteger
        LoadAsDataFile = &H2
        DontResolveReferences = &H1
        LoadWithAlteredSeachPath = &H8
        IgnoreCodeAuthzLevel = &H10
        LoadAsExclusiveDataFile = &H40
    End Enum
    <Flags()>
    Public Enum CreateThreadFlags As UInteger
        RunImmediately = &H0
        CreateSuspended = &H4
        StackSizeParamIsAReservation = &H10000
    End Enum
    <Flags()>
    Public Enum AllocationType As UInteger
        WriteMatchFlagReset = &H1
        ' Win98 only
        Commit = &H1000
        Reserve = &H2000
        CommitOrReserve = &H3000
        Decommit = &H4000
        Release = &H8000
        Free = &H10000
        [Public] = &H20000
        Mapped = &H40000
        Reset = &H80000
        ' Win2K only
        TopDown = &H100000
        WriteWatch = &H200000
        ' Win98 only
        Physical = &H400000
        ' Win2K only
        '4MBPages    = 0x80000000, // ??
        SecImage = &H1000000
        Image = SecImage
    End Enum
    <Flags()>
    Public Enum PageAccessProtectionFlags As UInteger
        NoAccess = &H1
        [ReadOnly] = &H2
        ReadWrite = &H4
        WriteCopy = &H8
        Execute = &H10
        ExecuteRead = &H20
        ExecuteReadWrite = &H40
        ExecuteWriteCopy = &H80
        Guard = &H100
        NoCache = &H200
        WriteCombine = &H400
    End Enum

    <StructLayout(LayoutKind.Sequential)>
    Public Structure PROCESS_BASIC_INFORMATION
        Public ExitStatus As Integer
        Public PebBaseAddress As Integer
        Public AffinityMask As Integer
        Public BasePriority As Integer
        Public UniqueProcessId As UInteger
        Public InheritedFromUniqueProcessId As UInteger
    End Structure

    Public NotInheritable Class NTDll
        Private Sub New()
        End Sub
        <DllImport("ntdll.dll")>
        Private Shared Function NtQueryInformationProcess(ByVal hProcess As IntPtr, ByVal processInformationClass As Integer, ByRef processBasicInformation As PROCESS_BASIC_INFORMATION, ByVal processInformationLength As UInteger, ByRef returnLength As UInteger) As Integer
        End Function
        Public Shared Function ProcessIsChildOf(ByVal parent As Process, ByVal child As Process) As Boolean
            Dim pbi As New PROCESS_BASIC_INFORMATION()
            Try
                Dim bytesWritten As UInteger
                NtQueryInformationProcess(child.Handle, 0, pbi, CUInt(Marshal.SizeOf(pbi)), bytesWritten)
                If pbi.InheritedFromUniqueProcessId = parent.Id Then
                    Return True
                End If
            Catch
                Return False
            End Try
            Return False
        End Function
    End Class

    Public NotInheritable Class Kernel32
        Private Sub New()
        End Sub
        Private Structure ProcessInformation
            Public Process As IntPtr
            Public Thread As IntPtr
            Public ProcessId As UInteger
            Public ThreadId As UInteger
        End Structure

        Private Structure StartupInfo
            Public CB As UInteger
            Public Reserved As String
            Public Desktop As String
            Public Title As String
            Public X As UInteger
            Public Y As UInteger
            Public XSize As UInteger
            Public YSize As UInteger
            Public XCountChars As UInteger
            Public YCountChars As UInteger
            Public FillAttribute As UInteger
            Public Flags As UInteger
            Public ShowWindow As Short
            Public Reserved2 As Short
            Public lpReserved2 As IntPtr
            Public StdInput As IntPtr
            Public StdOutput As IntPtr
            Public StdError As IntPtr
        End Structure

        <DllImport("kernel32.dll", SetLastError:=True)>
        Private Shared Function CreateProcess(ByVal Application As String, ByVal CommandLine As String, ByVal ProcessAttributes As IntPtr, ByVal ThreadAttributes As IntPtr, ByVal InheritHandles As Boolean, ByVal CreationFlags As UInteger,
         ByVal Environment As IntPtr, ByVal CurrentDirectory As String, ByRef StartupInfo As StartupInfo, ByRef ProcessInformation As ProcessInformation) As Boolean
        End Function

        Private Declare Auto Function ReadProcessMemory Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal baseAddress As IntPtr, <Out()> ByVal buffer As Byte(), ByVal size As UInteger, ByRef numBytesRead As UInteger) As Boolean

        Private Declare Auto Function OpenProcess Lib "kernel32.dll" (ByVal dwDesiredAccess As ProcessAccessFlags, <MarshalAs(UnmanagedType.Bool)> ByVal bInheritHandle As Boolean, ByVal dwProcessId As UInteger) As IntPtr

        Private Declare Auto Function WaitForSingleObject Lib "kernel32.dll" (ByVal hHandle As IntPtr, ByVal dwMilliseconds As UInt32) As UInt32

        <DllImport("kernel32.dll", SetLastError:=True)>
        Private Shared Function LoadLibraryEx(ByVal lpFileName As String, ByVal hFile As IntPtr, ByVal dwFlags As LoadLibraryFlags) As IntPtr
        End Function

        Private Declare Auto Function CreateRemoteThread Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal lpThreadAttributes As IntPtr, ByVal dwStackSize As UInteger, ByVal lpStartAddress As IntPtr, ByVal lpParameter As IntPtr, ByVal dwCreationFlags As UInteger,
         ByVal lpThreadId As IntPtr) As IntPtr

        Private Declare Auto Function VirtualProtectEx Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As UInteger, ByVal flags As PageAccessProtectionFlags, ByRef oldFlags As PageAccessProtectionFlags) As <MarshalAs(UnmanagedType.Bool)> Boolean

        Private Declare Auto Function VirtualAllocEx Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As UInteger, ByVal flAllocationType As AllocationType, ByVal flProtect As PageAccessProtectionFlags) As IntPtr

        Private Declare Auto Function VirtualFreeEx Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal lpAddress As IntPtr, ByVal dwSize As Integer, ByVal dwFreeType As AllocationType) As <MarshalAs(UnmanagedType.Bool)> Boolean

        Private Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean

        Private Declare Auto Function FreeLibrary Lib "kernel32.dll" (ByVal hHandle As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean

        Private Declare Auto Function WriteProcessMemory Lib "kernel32.dll" (ByVal hProcess As IntPtr, ByVal lpBaseAddress As IntPtr, ByVal lpBuffer As Byte(), ByVal nSize As UInteger, ByRef lpNumberOfBytesWritten As Integer) As Boolean

        <DllImport("kernel32.dll", SetLastError:=True)>
        Private Shared Function GetProcAddress(ByVal hModule As IntPtr, ByVal procName As String) As IntPtr
        End Function

        Private Declare Auto Function SuspendThread Lib "kernel32.dll" (ByVal hThread As IntPtr) As UInteger

        Private Declare Auto Function ResumeThread Lib "kernel32.dll" (ByVal hThread As IntPtr) As UInteger

        Private Declare Auto Function OpenThread Lib "kernel32.dll" (ByVal flags As ThreadAccessFlags, ByVal bInheritHandle As Boolean, ByVal threadId As UInteger) As IntPtr

        Public Shared Function CallRemoteFunction(ByVal p As Process, ByVal [module] As String, ByVal [function] As String, ByVal param As IntPtr) As Boolean
            Return CallRemoteFunction(p.Id, [module], [function], param)
        End Function
        Public Shared Function CallRemoteFunction(ByVal pid As Integer, ByVal [module] As String, ByVal [function] As String, ByVal param As IntPtr) As Boolean
            Dim moduleHandle As IntPtr = LoadLibraryEx([module], LoadLibraryFlags.LoadAsDataFile)
            Dim address As IntPtr = GetProcAddress(moduleHandle, [function])
            If moduleHandle = IntPtr.Zero OrElse address = IntPtr.Zero Then
                Return False
            End If

            Dim result As IntPtr = CreateRemoteThread(pid, address, param, CreateThreadFlags.RunImmediately)
            If result <> IntPtr.Zero Then
                WaitForSingleObject(result, UInt32.MaxValue)
            End If

            Return result <> IntPtr.Zero
        End Function

        Public Shared Function LoadRemoteLibrary(ByVal p As Process, ByVal [module] As String) As Boolean
            Return LoadRemoteLibrary(p.Id, [module])
        End Function
        Public Shared Function LoadRemoteLibrary(ByVal pid As Integer, ByVal [module] As String) As Boolean
            Dim moduleName As IntPtr = WriteObject(pid, [module])
            Dim result As Boolean = CallRemoteFunction(pid, "kernel32.dll", "LoadLibraryA", moduleName)
            FreeObject(pid, moduleName)
            Return result
        End Function

        Public Shared Function WriteObject(ByVal p As Process, ByVal data As Object) As IntPtr
            Return WriteObject(p.Id, data)
        End Function
        Public Shared Function WriteObject(ByVal pid As Integer, ByVal data As Object) As IntPtr
            Dim bytes As Byte() = GetRawBytes(data)
            Dim address As IntPtr = VirtualAlloc(pid, IntPtr.Zero, CUInt(bytes.Length), AllocationType.Commit Or AllocationType.Reserve, PageAccessProtectionFlags.ReadWrite)
            WriteProcessMemory(pid, address, bytes)
            Return address
        End Function

        Public Shared Sub FreeObject(ByVal p As Process, ByVal address As IntPtr)
            FreeObject(p.Id, address)
        End Sub
        Public Shared Sub FreeObject(ByVal pid As Integer, ByVal address As IntPtr)
            VirtualFree(pid, address)
        End Sub

        Public Shared Function FindModuleHandle(ByVal pid As Integer, ByVal [module] As String) As IntPtr
            Return FindModuleHandle(Process.GetProcessById(pid), [module])
        End Function
        Public Shared Function FindModuleHandle(ByVal p As Process, ByVal [module] As String) As IntPtr
            If p Is Nothing Then
                Return IntPtr.Zero
            End If
            If Not p.WaitForInputIdle(50) Then Return IntPtr.Zero
            p.Refresh()
            For Each m As ProcessModule In p.Modules
                If Path.GetFileName(m.FileName).ToLowerInvariant() = Path.GetFileName([module]).ToLowerInvariant() Then
                    Return m.BaseAddress
                End If
            Next
            Return IntPtr.Zero
        End Function
        Public Shared Function FindOffset(ByVal moduleName As String, ByVal [function] As String) As IntPtr
            Dim localHandle As IntPtr = LoadLibraryEx(moduleName, LoadLibraryFlags.LoadAsDataFile)
            If localHandle <> IntPtr.Zero Then
                Dim address As IntPtr = GetProcAddress(localHandle, [function])
                FreeLibrary(localHandle)
                Return CType(address.ToInt32() - localHandle.ToInt32(), IntPtr)
            End If
            Return IntPtr.Zero
        End Function

        Public Shared Function ReadProcessMemory(ByVal p As Process, ByVal address As IntPtr, ByRef buffer As Byte()) As Boolean
            Return ReadProcessMemory(p.Id, address, buffer)
        End Function
        Public Shared Function ReadProcessMemory(ByVal pid As Integer, ByVal address As IntPtr, ByRef buffer As Byte()) As Boolean
            Dim handle As IntPtr = PInvoke.Kernel32.GetProcessHandle(pid, PInvoke.ProcessAccessFlags.VMRead)
            Dim length As UInteger = 0
            If address = IntPtr.Zero Then
                Return False
            End If
            Dim flags As PageAccessProtectionFlags, oldFlags As PageAccessProtectionFlags
            If Not VirtualProtect(pid, address, CUInt(buffer.Length), PageAccessProtectionFlags.ExecuteReadWrite, flags) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            If Not ReadProcessMemory(handle, address, buffer, CUInt(buffer.Length), length) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            If Not VirtualProtect(pid, address, CUInt(buffer.Length), flags, oldFlags) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            CloseProcessHandle(handle)
            Return (length = buffer.Length)
        End Function

        Public Shared Function StartProcess(ByVal directory As String, ByVal application As String, ByVal flags As ProcessCreationFlags, ByVal ParamArray parameters As String()) As UInteger
            Dim si As New StartupInfo()
            Dim pi As New ProcessInformation()
            If CreateProcess(application, [String].Concat(application, [String].Concat(parameters)), IntPtr.Zero, IntPtr.Zero, False, CUInt(flags),
             IntPtr.Zero, directory, si, pi) Then
                Return pi.ProcessId
            End If
            Return UInteger.MaxValue
        End Function
        <DebuggerHidden()>
        Public Shared Sub ResumeProcess(ByVal p As Process)
            For Each t As ProcessThread In p.Threads
                PInvoke.Kernel32.ResumeThread(t)
            Next
        End Sub
        <DebuggerHidden()>
        Public Shared Sub SuspendThread(ByVal thread As ProcessThread)
            SuspendThread(thread.Id)
        End Sub
        <DebuggerHidden()>
        Public Shared Sub ResumeThread(ByVal thread As ProcessThread)
            ResumeThread(thread.Id)
        End Sub
        <DebuggerHidden()>
        Public Shared Sub SuspendProcess(ByVal process As Process)
            For Each t As ProcessThread In process.Threads
                PInvoke.Kernel32.SuspendThread(t)
            Next
        End Sub
        <DebuggerHidden()>
        Public Shared Sub ResumeThread(ByVal process As Process)
            For Each t As ProcessThread In process.Threads
                PInvoke.Kernel32.ResumeThread(t)
            Next
        End Sub
        <DebuggerHidden()>
        Public Shared Sub SuspendThread(ByVal tid As Integer)
            Dim handle As IntPtr = OpenThread(ThreadAccessFlags.SuspendResume, False, CUInt(tid))
            SuspendThread(handle)
            CloseHandle(handle)
        End Sub
        <DebuggerHidden()>
        Public Shared Sub ResumeThread(ByVal tid As Integer)
            Dim handle As IntPtr = OpenThread(ThreadAccessFlags.SuspendResume, False, CUInt(tid))
            ResumeThread(handle)
            CloseHandle(handle)
        End Sub
        <DebuggerHidden()>
        Public Shared Function CreateRemoteThread(ByVal p As Process, ByVal address As IntPtr, ByVal param As IntPtr, ByVal flags As CreateThreadFlags) As IntPtr
            Return CreateRemoteThread(p.Id, address, param, flags)
        End Function
        <DebuggerHidden()>
        Public Shared Function CreateRemoteThread(ByVal pid As Integer, ByVal address As IntPtr, ByVal param As IntPtr, ByVal flags As CreateThreadFlags) As IntPtr
            Dim handle As IntPtr = GetProcessHandle(pid, ProcessAccessFlags.CreateThread Or ProcessAccessFlags.QueryInformation Or ProcessAccessFlags.VMOperation Or ProcessAccessFlags.VMRead Or ProcessAccessFlags.VMWrite)
            Dim thread As IntPtr = CreateRemoteThread(handle, IntPtr.Zero, CUInt(0), address, param, CUInt(flags),
             IntPtr.Zero)
            If thread = IntPtr.Zero Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            CloseProcessHandle(handle)
            Return thread
        End Function
        <DebuggerHidden()>
        Public Shared Function GetProcessHandle(ByVal p As Process, ByVal flags As ProcessAccessFlags) As IntPtr
            Return GetProcessHandle(p.Id, flags)
        End Function
        <DebuggerHidden()>
        Public Shared Function GetProcessHandle(ByVal pid As Integer, ByVal flags As ProcessAccessFlags) As IntPtr
            Dim handle As IntPtr = OpenProcess(flags, False, CUInt(pid))
            If handle = IntPtr.Zero Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            Return handle
        End Function
        <DebuggerHidden()>
        Public Shared Sub CloseProcessHandle(ByVal handle As IntPtr)
            If Not CloseHandle(handle) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
        End Sub
        <DebuggerHidden()>
        Public Shared Function VirtualProtect(ByVal p As Process, ByVal address As IntPtr, ByVal size As UInteger, ByVal flags As PageAccessProtectionFlags, ByRef oldFlags As PageAccessProtectionFlags) As Boolean
            Return VirtualProtect(p.Id, address, size, flags, oldFlags)
        End Function
        <DebuggerHidden()>
        Public Shared Function VirtualProtect(ByVal pid As Integer, ByVal address As IntPtr, ByVal size As UInteger, ByVal flags As PageAccessProtectionFlags, ByRef oldFlags As PageAccessProtectionFlags) As Boolean
            Dim handle As IntPtr = GetProcessHandle(pid, ProcessAccessFlags.VMOperation)
            Dim result As Boolean = VirtualProtectEx(handle, address, size, flags, oldFlags)
            CloseHandle(handle)
            Return result
        End Function
        <DebuggerHidden()>
        Public Shared Function VirtualAlloc(ByVal p As Process, ByVal address As IntPtr, ByVal size As UInteger, ByVal type As AllocationType, ByVal flags As PageAccessProtectionFlags) As IntPtr
            Return VirtualAlloc(p.Id, address, size, type, flags)
        End Function
        <DebuggerHidden()>
        Public Shared Function VirtualAlloc(ByVal pid As Integer, ByVal address As IntPtr, ByVal size As UInteger, ByVal type As AllocationType, ByVal flags As PageAccessProtectionFlags) As IntPtr
            Dim handle As IntPtr = GetProcessHandle(pid, ProcessAccessFlags.VMOperation)
            Dim newaddress As IntPtr = VirtualAllocEx(handle, address, size, type, flags)
            If newaddress = IntPtr.Zero Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            CloseProcessHandle(handle)
            Return newaddress
        End Function
        <DebuggerHidden()>
        Public Shared Sub VirtualFree(ByVal p As Process, ByVal address As IntPtr)
            VirtualFree(p.Id, address)
        End Sub
        <DebuggerHidden()>
        Public Shared Sub VirtualFree(ByVal pid As Integer, ByVal address As IntPtr)
            Dim handle As IntPtr = GetProcessHandle(pid, ProcessAccessFlags.VMOperation)
            Dim success As Boolean = VirtualFreeEx(handle, address, 0, AllocationType.Release)
            CloseProcessHandle(handle)
            If Not success Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
        End Sub
        <DebuggerHidden()>
        Public Shared Function WriteProcessMemory(ByVal p As Process, ByVal address As IntPtr, ByVal buffer As Byte()) As Integer
            Return WriteProcessMemory(p.Id, address, buffer)
        End Function
        <DebuggerHidden()>
        Public Shared Function WriteProcessMemory(ByVal pid As Integer, ByVal address As IntPtr, ByVal buffer As Byte()) As Integer
            Dim handle As IntPtr = GetProcessHandle(pid, ProcessAccessFlags.VMWrite Or ProcessAccessFlags.VMOperation)
            Dim bytes As Integer
            Dim flags As PageAccessProtectionFlags, oldFlags As PageAccessProtectionFlags
            If Not VirtualProtect(pid, address, CUInt(buffer.Length), PageAccessProtectionFlags.ExecuteReadWrite, flags) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            If Not WriteProcessMemory(handle, address, buffer, CUInt(buffer.Length), bytes) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            If Not VirtualProtect(pid, address, CUInt(buffer.Length), flags, oldFlags) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            CloseProcessHandle(handle)
            Return bytes
        End Function
        <DebuggerHidden()>
        Public Shared Function LoadLibraryEx(ByVal [module] As String, ByVal flags As LoadLibraryFlags) As IntPtr
            Return LoadLibraryEx([module], IntPtr.Zero, flags)
        End Function
        <DebuggerHidden()>
        Public Shared Function GetRawBytes(ByVal anything As Object) As Byte()
            If anything.[GetType]().Equals(GetType(String)) Then
                Return System.Text.ASCIIEncoding.ASCII.GetBytes(DirectCast(anything, String))
            Else
                Dim structsize As Integer = Marshal.SizeOf(anything)
                Dim buffer As IntPtr = Marshal.AllocHGlobal(structsize)
                Marshal.StructureToPtr(anything, buffer, False)
                Dim streamdatas As Byte() = New Byte(structsize - 1) {}
                Marshal.Copy(buffer, streamdatas, 0, structsize)
                Marshal.FreeHGlobal(buffer)
                Return streamdatas
            End If
        End Function
    End Class
    Public Module Extensions
        ' Public NotInheritable Class Extensions

        <System.Runtime.CompilerServices.Extension()>
        Public Function StartSuspended(ByVal process__1 As Process, ByVal startInfo As ProcessStartInfo) As Process
            Dim id As UInteger = Kernel32.StartProcess(startInfo.WorkingDirectory, startInfo.FileName, ProcessCreationFlags.Suspended, startInfo.Arguments)
            Return Process.GetProcessById(CInt(id))
        End Function
        <System.Runtime.CompilerServices.Extension()>
        Public Sub Suspend(ByVal process As Process)
            For Each t As ProcessThread In process.Threads
                t.Suspend()
            Next
        End Sub

        <System.Runtime.CompilerServices.Extension()>
        Public Sub [Resume](ByVal process As Process)
            For Each t As ProcessThread In process.Threads
                t.[Resume]()
            Next
        End Sub

        <System.Runtime.CompilerServices.Extension()>
        Public Sub Suspend(ByVal thread As ProcessThread)
            PInvoke.Kernel32.SuspendThread(thread)
        End Sub
        <System.Runtime.CompilerServices.Extension()>
        Public Sub [Resume](ByVal thread As ProcessThread)
            PInvoke.Kernel32.ResumeThread(thread)
        End Sub

        <System.Runtime.CompilerServices.Extension()>
        Public Function GetChildProcesses(ByVal process__1 As Process) As Process()
            Dim children As New List(Of Process)()
            Dim processes As Process() = Process.GetProcesses()
            For Each p As Process In processes
                If PInvoke.NTDll.ProcessIsChildOf(process__1, p) Then
                    children.Add(p)
                End If
            Next
            Return children.ToArray()
        End Function

        ''' <summary>
        ''' Test for the presence of an attribute on a specified Type
        ''' </summary>
        ''' <param name="t">The Type to test</param>
        ''' <param name="attr">The type of the attribute to test for</param>
        ''' <returns>True if the attribute is present, otherwise false</returns>
        <System.Runtime.CompilerServices.Extension()>
        Public Function HasAttribute(ByVal t As ICustomAttributeProvider, ByVal attr As Type) As Boolean
            Return t.HasAttribute(attr, False)
        End Function

        ''' <summary>
        ''' Test for the presence of an attribute on a specified Type
        ''' </summary>
        ''' <param name="t">The Type to test</param>
        ''' <param name="attr">The type of the attribute to test for</param>
        ''' <param name="inherit">Whether or not to examine the inherited attributes for the specified attribute</param>
        ''' <returns>True if the attribute is present, otherwise false</returns>
        <System.Runtime.CompilerServices.Extension()>
        Public Function HasAttribute(ByVal t As ICustomAttributeProvider, ByVal attr As Type, ByVal inherit As Boolean) As Boolean
            Dim result = t.GetCustomAttributes(attr, inherit)
            Return result IsNot Nothing AndAlso result.Length > 0
        End Function

        '''' <summary>
        '''' Test for and return the first attribute of the specified type
        '''' </summary>
        '''' <typeparam name="T">The Attribute to test for</typeparam>
        '''' <param name="t">The Type to test</param>
        '''' <returns>The first Attribute matching the specified type, if one exists, otherwise null</returns>
        <System.Runtime.CompilerServices.Extension()>
        Public Function GetCustomAttribute(Of T As Attribute)(ByVal b As ICustomAttributeProvider) As T
            Return b.GetCustomAttribute(Of T)(False)
        End Function

        '''' <summary>
        '''' Test for and return the first attribute of the specified type
        '''' </summary>
        '''' <typeparam name="T">The Attribute to test for</typeparam>
        '''' <param name="t">The Type to test</param>
        '''' <param name="inherit">Whether or not to examine the inherited attributes for the specified type</param>
        '''' <returns>The first Attribute matching the specified type, if one exists, otherwise null</returns>
        <System.Runtime.CompilerServices.Extension()>
        Public Function GetCustomAttribute(Of T As Attribute)(ByVal b As ICustomAttributeProvider, ByVal inherit As Boolean) As T
            Return If(b.HasAttribute(GetType(T), inherit), TryCast(b.GetCustomAttributes(GetType(T), inherit)(0), T), DirectCast(Nothing, T))
        End Function


        ''' <summary>
        ''' Calls String.Format with the current string as the formatting string
        ''' </summary>
        ''' <returns>The formatted string</returns>
        <System.Runtime.CompilerServices.Extension()>
        Public Function Compose(ByVal format As String, ByVal ParamArray args As Object()) As String
            Return [String].Format(format, args)
        End Function
    End Module
End Namespace
