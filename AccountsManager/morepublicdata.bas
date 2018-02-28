Attribute VB_Name = "Module2"
Public Declare Function SWPos Lib "user32.dll" Alias "SetWindowPos" (ByVal hwnd As Long, ByVal H As Long, ByVal x As Long, ByVal Y As Long, ByVal W As Long, ByVal H As Long, ByVal FL As Long) As Long
Public Declare Function ShowWin Lib "user32.dll" Alias "ShowWindow" (ByVal hwnd As Long, ByVal cmd As Integer) As Long
Public Declare Function ShutWindows Lib "ShutDownEx.dll" Alias "ShutDownWindows" (ByVal cmd As Long) As Long

Public wshnet As Object
Public strUNCPath As String
Public strStudentName As String
Public strClass As String
Public bFirstLog As Boolean
Public strDBPath As String
Public dbConnection As ADODB.Connection
Public strUserPassword As String
Public strStudID As String
Public bConnected As Boolean

Const SWP_NOSIZE = &H1
Const SWP_NOMOVE = &H2
Const SWP_NOZORDER = &H4
Const SWP_NOREDRAW = &H8
Const SWP_NOACTIVATE = &H10
Const SWP_FRAMECHANGED = &H20
Const SWP_SHOWWINDOW = &H40
Const SWP_HIDEWINDOW = &H80
Const SWP_NOCOPYBITS = &H100
Const SWP_NOOWNERZORDER = &H200
Const SWP_NOSENDCHANGING = &H40
Const TOPMOST = -1

Const SW_HIDE = 1
Const SW_SHOW = 5


