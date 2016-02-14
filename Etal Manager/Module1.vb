Imports System.Runtime.InteropServices

Module Module1

    Public Objects As List(Of Profiles) = New List(Of Profiles)

    Public form2action As String


    Friend Const WM_COPYDATA As Integer = &H4A
    Friend Const D2NT_MGR_LOADING As Integer = 1
    Friend Const D2NT_MGR_READY As Integer = 2
    Friend Const D2NT_MGR_LOGIN As Integer = 3
    Friend Const D2NT_MGR_CREATE_GAME As Integer = 4
    Friend Const D2NT_MGR_INGAME As Integer = 5
    Friend Const D2NT_MGR_RESTART As Integer = 6
    Friend Const D2NT_MGR_CHICKEN As Integer = 7
    Friend Const D2NT_MGR_PRINT_STATUS As Integer = 8
    Friend Const D2NT_MGR_COMMON As Integer = 9
    Friend Const D2NT_MGR_ITEM_LOG As Integer = 10
    Friend Const D2NT_MGR_ERROR_LOG As Integer = 11


    <StructLayout(LayoutKind.Sequential)>
    Friend Structure CopyData
        Public dwData As IntPtr
        Public cbData As Integer
        Public lpData As IntPtr
    End Structure





End Module
