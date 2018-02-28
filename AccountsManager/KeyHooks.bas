Attribute VB_Name = "Module1"
'Place the following in a .BAS module

Option Explicit

'equired Win32 API

Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" _
       (ByVal idHook As Long, ByVal lpfn As Long, ByVal hmod As Long, _
        ByVal dwThreadId As Long) As Long

Private Declare Function UnhookWindowsHookEx Lib "user32" _
    (ByVal hHook As Long) As Long

Private Declare Function CallNextHookEx Lib "user32" _
       (ByVal hHook As Long, ByVal nCode As Long, ByVal wParam As Long, _
        ByVal lParam As Long) As Long

Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" _
       (pDest As Any, pSource As Any, ByVal cb As Long)

Private Declare Function GetAsyncKeyState Lib "user32" _
        (ByVal vKey As Long) As Integer
        
        
Private Const WH_KEYBOARD_LL = 13&  ' Tells Windows what we want to hook
Private Const HC_ACTION = 0&        ' Message received by our hook function

Private Const VK_ESCAPE = &H1B      ' The Escape key
Private Const VK_LCTRL = &HA2       ' The Left CTRL key
Private Const VK_RCTRL = &HA3       ' Thr Right CTRL key
Public Const VK_TAB = &H9
Public Const VK_LWINKEY = &H5B      ' The Window's key on the left of the keyboard
Public Const VK_RWINKEY = &H5C      ' The Window's key on the right of the keyboard
Public Const VK_DELETE = &H2E
Const VK_MENU = &H12  'Any ALT key
Const VK_LALT = &HA4 'Left ALT key
Const VK_RALT = &HA5 'Right ALT key



Private lKBDhook As Long            ' Handle to the hook
Private bHookEnabled As Boolean     ' Flag

Private Type KBDHOOKSTRUCT          ' The hook structure
    vkCode As Long
    scanCode As Long
    flags As Long
    Time As Long
    dwExtraInfo As Long
End Type

Private o_KBDhook As KBDHOOKSTRUCT  ' The hook object

Public Function KBDhookProc(ByVal nCode As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
' Notes:
' When the Windows key is pressed, o_KBDhook.flags = 1
' When the Windows key is released, o_KBDhook.flags = 129

' *** The flags are different from key to key
' Some keys fire their event on the release and not the press. In the case of the Window's key,
' it fires on the press so we can trap it by checking the flag.
' Check if the code passed in is the one we're concerned about (means a key was pressed)


   If nCode = HC_ACTION Then
        ' Copy the information into our hook object
        Call CopyMemory(o_KBDhook, ByVal lParam, Len(o_KBDhook))
        
        ' Intercept the left Window's key

        If (o_KBDhook.vkCode = VK_LWINKEY) And (o_KBDhook.flags = 1) Then
            KBDhookProc = 1
            Exit Function
        End If

        ' Intercept the right Window's key
        If (o_KBDhook.vkCode = VK_RWINKEY) And (o_KBDhook.flags = 1) Then
            KBDhookProc = 1
            Exit Function
        End If
        
        If (o_KBDhook.vkCode = VK_ESCAPE) And (o_KBDhook.flags = 0) And CBool((GetAsyncKeyState(VK_LCTRL) And &H8000)) Then
            KBDhookProc = 1
            Exit Function
        End If
    
        If (o_KBDhook.vkCode = VK_ESCAPE) And (o_KBDhook.flags = 0) And CBool((GetAsyncKeyState(VK_RCTRL) And &H8000)) Then
            KBDhookProc = 1
            Exit Function
        End If
    
        If (o_KBDhook.vkCode = VK_TAB) And CBool((GetAsyncKeyState(VK_LALT) And &H8000)) _
            Or CBool((GetAsyncKeyState(VK_RALT) And &H8000)) Then
                KBDhookProc = 1
                Exit Function
        End If
        
   End If

   ' Handle any other messages as usual

   KBDhookProc = CallNextHookEx(lKBDhook, nCode, wParam, lParam)

End Function

Public Function SetHook()

   ' Hook into the keyboard process
    
    If lKBDhook = 0 Then
        lKBDhook = SetWindowsHookEx(WH_KEYBOARD_LL, AddressOf KBDhookProc, App.hInstance, 0&)
    End If

    If lKBDhook = 0 Then
        MsgBox "Failed to install Keyboard Hook"
        bHookEnabled = False
        Exit Function
    Else
        bHookEnabled = True
    End If
End Function

Public Function UnSetHook()

' Unhook from the keyboard process so we don't crash when we try to
' exit our program

    If bHookEnabled Then
        Call UnhookWindowsHookEx(lKBDhook)
    End If

    bHookEnabled = False
End Function
