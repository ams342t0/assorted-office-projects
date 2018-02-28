VERSION 5.00
Begin VB.Form Form2 
   Caption         =   "LabSec Authentication"
   ClientHeight    =   1395
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   3555
   ControlBox      =   0   'False
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1395
   ScaleWidth      =   3555
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdOk 
      Caption         =   "&OK"
      Height          =   420
      Left            =   990
      TabIndex        =   2
      Top             =   900
      Width           =   1545
   End
   Begin VB.TextBox txtPassword 
      Height          =   375
      IMEMode         =   3  'DISABLE
      Left            =   90
      PasswordChar    =   "*"
      TabIndex        =   0
      Top             =   360
      Width           =   3345
   End
   Begin VB.Label Label1 
      Caption         =   "Enter Password:"
      Height          =   285
      Left            =   135
      TabIndex        =   1
      Top             =   90
      Width           =   1320
   End
End
Attribute VB_Name = "Form2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdOk_Click()
    strUserPassword = txtPassword
    Unload Me
End Sub

Private Sub txtPassword_KeyPress(KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then
        cmdOk_Click
    End If
End Sub
