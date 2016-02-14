Module Injector


    Private TargetProcessHandle As Integer
    Private pfnStartAddr As Integer
    Private pszLibFileRemote As String
    Private TargetBufferSize As Integer

    Public Const PROCESS_VM_READ = &H10
    Public Const TH32CS_SNAPPROCESS = &H2
    Public Const MEM_COMMIT = 4096
    Public Const PAGE_READWRITE = 4
    Public Const PROCESS_CREATE_THREAD = (&H2)
    Public Const PROCESS_VM_OPERATION = (&H8)
    Public Const PROCESS_VM_WRITE = (&H20)
    Dim DLLFileName As String
    Public Declare Function ReadProcessMemory Lib "kernel32" ( _
    ByVal hProcess As Integer, _
    ByVal lpBaseAddress As Integer, _
    ByVal lpBuffer As String, _
    ByVal nSize As Integer, _
    ByRef lpNumberOfBytesWritten As Integer) As Integer

    Public Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" ( _
    ByVal lpLibFileName As String) As Integer

    Public Declare Function VirtualAllocEx Lib "kernel32" ( _
    ByVal hProcess As Integer, _
    ByVal lpAddress As Integer, _
    ByVal dwSize As Integer, _
    ByVal flAllocationType As Integer, _
    ByVal flProtect As Integer) As Integer

    Public Declare Function WriteProcessMemory Lib "kernel32" ( _
    ByVal hProcess As Integer, _
    ByVal lpBaseAddress As Integer, _
    ByVal lpBuffer As String, _
    ByVal nSize As Integer, _
    ByRef lpNumberOfBytesWritten As Integer) As Integer

    Public Declare Function GetProcAddress Lib "kernel32" ( _
    ByVal hModule As Integer, ByVal lpProcName As String) As Integer

    Private Declare Function GetModuleHandle Lib "Kernel32" Alias "GetModuleHandleA" ( _
    ByVal lpModuleName As String) As Integer

    Public Declare Function CreateRemoteThread Lib "kernel32" ( _
    ByVal hProcess As Integer, _
    ByVal lpThreadAttributes As Integer, _
    ByVal dwStackSize As Integer, _
    ByVal lpStartAddress As Integer, _
    ByVal lpParameter As Integer, _
    ByVal dwCreationFlags As Integer, _
    ByRef lpThreadId As Integer) As Integer

    Public Declare Function OpenProcess Lib "kernel32" ( _
    ByVal dwDesiredAccess As Integer, _
    ByVal bInheritHandle As Integer, _
    ByVal dwProcessId As Integer) As Integer

    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" ( _
    ByVal lpClassName As String, _
    ByVal lpWindowName As String) As Integer

    Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" (ByVal hObject As Integer) As Integer

    Dim ExeName As String = IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath)

    Public Sub Inject(ByVal x)

        TargetProcessHandle = OpenProcess(PROCESS_CREATE_THREAD Or PROCESS_VM_OPERATION Or PROCESS_VM_WRITE, False, x)
        pszLibFileRemote = "D2ETAL.dll"
        pfnStartAddr = GetProcAddress(GetModuleHandle("Kernel32"), "LoadLibraryA")
        TargetBufferSize = 1 + Len(pszLibFileRemote)
        Dim Rtn As Integer
        Dim LoadLibParamAdr As Integer
        LoadLibParamAdr = VirtualAllocEx(TargetProcessHandle, 0, TargetBufferSize, MEM_COMMIT, PAGE_READWRITE)
        Rtn = WriteProcessMemory(TargetProcessHandle, LoadLibParamAdr, pszLibFileRemote, TargetBufferSize, 0)
        CreateRemoteThread(TargetProcessHandle, 0, 0, pfnStartAddr, LoadLibParamAdr, 0, 0) 'lparameter ? mmf pointer to pass to dll
        CloseHandle(TargetProcessHandle)

    End Sub
End Module