Imports System.Runtime.InteropServices
Imports System.Security

Module Module1

    Public Objects As List(Of Profiles) = New List(Of Profiles)
    Public totalkeys As List(Of keyholder) = New List(Of keyholder)

    Public form2action As String


    ''' <summary>
    ''' An application sends the WM_COPYDATA message to pass data to another 
    ''' application.
    ''' </summary>
    Friend Const WM_COPYDATA As Integer = &H4A
    Friend Const ETAL_MGR_LOADING As Integer = 1
    Friend Const ETAL_MGR_READY As Integer = 2
    Friend Const ETAL_MGR_LOGIN As Integer = 3
    Friend Const ETAL_MGR_CREATE_GAME As Integer = 4
    Friend Const ETAL_MGR_INGAME As Integer = 5
    Friend Const ETAL_MGR_RESTART As Integer = 6
    Friend Const ETAL_MGR_CHICKEN As Integer = 7
    Friend Const ETAL_MGR_PRINT_STATUS As Integer = 8
    Friend Const ETAL_MGR_COMMON As Integer = 9
    Friend Const ETAL_MGR_ITEM_LOG As Integer = 10
    Friend Const ETAL_MGR_ERROR_LOG As Integer = 11


    <StructLayout(LayoutKind.Sequential)>
    Friend Structure CopyData
        Public dwData As IntPtr
        Public cbData As Integer
        Public lpData As IntPtr
    End Structure


    Const SW_HIDE As Integer = 0
    Const SW_RESTORE As Integer = 1
    Const SW_MINIMIZE As Integer = 2
    Const SW_MAXIMIZE As Integer = 3

    <DllImport("User32")>
    Public Function ShowWindow(ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Friend Structure Profile
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=24)>
        Public Account As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=12)>
        Public AccPass As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Public MpqFile As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Public KeyOwner As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Public Classic As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Public Lod As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=8)>
        Public GameName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=6)>
        Public GamePass As String
        Public Charloc As Char
        Public Realm As Char
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=8)>
        Public RandomGameName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=6)>
        Public RandomGamePass As String
        Public Difficulty As Char
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Public ScriptFile As String
    End Structure



End Module
