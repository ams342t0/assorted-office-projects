VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmCreateNewDatabase 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "CREATE NEW DATABASE"
   ClientHeight    =   1425
   ClientLeft      =   45
   ClientTop       =   345
   ClientWidth     =   4755
   LinkTopic       =   "Form3"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1425
   ScaleWidth      =   4755
   StartUpPosition =   1  'CenterOwner
   Begin MSComDlg.CommonDialog commdlg 
      Left            =   3840
      Top             =   1440
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton cmdCreate 
      Caption         =   "CREATE"
      Height          =   735
      Left            =   135
      TabIndex        =   2
      Top             =   585
      Width           =   4470
   End
   Begin VB.TextBox txtSchoolyear 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   360
      Left            =   1680
      TabIndex        =   1
      Text            =   "txtSchoolyear"
      Top             =   90
      Width           =   2895
   End
   Begin VB.Label Label1 
      Caption         =   "SCHOOL YEAR"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   135
      TabIndex        =   0
      Top             =   135
      Width           =   1815
   End
End
Attribute VB_Name = "frmCreateNewDatabase"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim fso As Object
Dim txttemplatepath As String

Private Sub cmdCreate_Click()
    commdlg.FileName = "BOOKS-" & txtSchoolyear.Text
    commdlg.InitDir = fso.Buildpath(App.Path, "BOOKS")
    commdlg.Filter = "BOOKS BACKEND|*.mdb"
    commdlg.CancelError = True
    
    On Error Resume Next
    
    commdlg.ShowSave
    
    If Err.Number <> 0 Then
        MsgBox Err.Description, vbCritical + vbOKOnly, "ERROR CREATING DATABASE"
    Else
        Err.Clear
        
        CopyTemplate
        
        If Err.Number <> 0 Then
            MsgBox Err.Description, vbCritical + vbOKOnly, "ERROR CREATING DATABASE"
        End If
        
        Err.Clear
        
        If Err.Number <> 0 Then
            MsgBox Err.Description, vbCritical + vbOKOnly, "ERROR CREATING DATABASE"
        End If
        
    End If
End Sub

Private Sub Form_Load()
    Set fso = CreateObject("Scripting.Filesystemobject")
    txtSchoolyear.Text = "2011-2012"
End Sub

Sub CopyTemplate()
    txttemplate = fso.Buildpath(App.Path, "BooksBlank.mdb")
    
    If fso.fileexists(commdlg.FileName) Then
        If MsgBox("A file with the same name already exists. Continue and overwrite existing file?", vbExclamation + vbYesNo, "CREATE DATABASE") = vbNo Then
            Exit Sub
        End If
    End If
    
    fso.CopyFile txttemplate, commdlg.FileName, True
    
    MsgBox "Template copied", vbOKOnly, "CREATE DATABASE"
End Sub

