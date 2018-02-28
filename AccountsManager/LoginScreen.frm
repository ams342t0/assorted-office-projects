VERSION 5.00
Begin VB.Form frmBackground 
   Appearance      =   0  'Flat
   BackColor       =   &H00000000&
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   3195
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   Icon            =   "LoginScreen.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   3195
   ScaleWidth      =   4680
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
End
Attribute VB_Name = "frmBackground"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Form_Load()
    Dim wshnet As WshNetwork
    
    Set wshnet = CreateObject("WScript.Network")
    
    If StrComp(UCase(wshnet.UserName), "ADMINISTRATOR", vbTextCompare) = 0 Then
        End
    End If
    
    Set wshnet = Nothing

    SWPos Me.hwnd, TOPMOST, 0, 0, 0, 0, SWP_NOACTIVATE
    SetHook
    Me.Show
    frmLogin.Show vbModal, Me
End Sub

Private Sub Form_Unload(Cancel As Integer)
    UnSetHook
End Sub

