VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "USER PASSWORD"
   ClientHeight    =   2235
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   2520
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2235
   ScaleWidth      =   2520
   ShowInTaskbar   =   0   'False
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton cmdCancel 
      Caption         =   "&CANCEL"
      Height          =   420
      Left            =   1305
      TabIndex        =   5
      Top             =   1665
      Width           =   1095
   End
   Begin VB.CommandButton cmdOk 
      Caption         =   "&OK"
      Height          =   420
      Left            =   135
      TabIndex        =   4
      Top             =   1665
      Width           =   1095
   End
   Begin VB.TextBox Pass2 
      Height          =   375
      IMEMode         =   3  'DISABLE
      Left            =   135
      PasswordChar    =   "*"
      TabIndex        =   2
      Top             =   1125
      Width           =   2265
   End
   Begin VB.TextBox Pass1 
      Height          =   375
      IMEMode         =   3  'DISABLE
      Left            =   135
      PasswordChar    =   "*"
      TabIndex        =   0
      Top             =   360
      Width           =   2265
   End
   Begin VB.Label Label2 
      Caption         =   "Confirm Password:"
      Height          =   240
      Left            =   135
      TabIndex        =   3
      Top             =   855
      Width           =   1725
   End
   Begin VB.Label Label1 
      Caption         =   "Enter Password:"
      Height          =   240
      Left            =   135
      TabIndex        =   1
      Top             =   90
      Width           =   1725
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Function PasswordOK() As Boolean
    PasswordOK = False
    
    If StrComp(Pass1, Pass2, vbBinaryCompare) = 0 Then
        PasswordOK = True
    End If
End Function

Function ClearPassword() As Long
    ClearPassword = Trim(Len(Pass1)) + Trim(Len(Pass2))
End Function

Private Sub cmdCancel_Click()
    Unload Me
End Sub

Private Sub cmdOk_Click()
    If ClearPassword = 0 Or Not PasswordOK Then
        MsgBox "Password is blank or not confirmed.", vbExclamation + vbApplicationModal + vbOKOnly, "User Password"
        Pass1.Text = ""
        Pass2.Text = ""
        Pass1.SetFocus
    Else
        strUserPassword = LCase(Pass1)
        Unload Me
    End If
End Sub


Private Sub Pass1_KeyPress(KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then
        Pass2.SetFocus
    End If
End Sub

Private Sub Pass2_KeyPress(KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then
        cmdOk_Click
    End If
End Sub
