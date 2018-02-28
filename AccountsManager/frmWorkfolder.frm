VERSION 5.00
Begin VB.Form frmWorkFolder 
   BackColor       =   &H80000004&
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Work Folder"
   ClientHeight    =   3765
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5625
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3765
   ScaleWidth      =   5625
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdExplore 
      Caption         =   "EXPLORE"
      Height          =   435
      Left            =   4140
      TabIndex        =   6
      Top             =   1035
      Width           =   1365
   End
   Begin VB.TextBox Text1 
      Height          =   330
      Left            =   2070
      Locked          =   -1  'True
      TabIndex        =   5
      Top             =   45
      Width           =   3480
   End
   Begin VB.CommandButton Command3 
      Caption         =   "CR&EATE"
      Height          =   435
      Left            =   4140
      TabIndex        =   4
      Top             =   1530
      Width           =   1365
   End
   Begin VB.CommandButton Command2 
      Caption         =   "&CLOSE"
      Height          =   435
      Left            =   4140
      TabIndex        =   3
      Top             =   2025
      Width           =   1365
   End
   Begin VB.CommandButton Command1 
      Caption         =   "&OK"
      Height          =   435
      Left            =   4140
      TabIndex        =   2
      Top             =   540
      Width           =   1365
   End
   Begin VB.DirListBox Dir1 
      Height          =   3240
      Left            =   45
      TabIndex        =   1
      Top             =   450
      Width           =   3930
   End
   Begin VB.DriveListBox Drive1 
      Height          =   315
      Left            =   45
      TabIndex        =   0
      Top             =   45
      Width           =   1995
   End
End
Attribute VB_Name = "frmWorkFolder"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdExplore_Click()
    Shell "explorer " & Dir1.Path, vbNormalFocus
End Sub

Private Sub Command1_Click()
    strSelectedFolder = Dir1.Path
    Unload Me
End Sub

Private Sub Command2_Click()
    strSelectedFolder = ""
    Unload Me
End Sub

Private Sub Command3_Click()
    Dim newfolder As String
    Dim fldr As Folder
    
    
    newfolder = InputBox("Type Folder Name", "Create New Folder")
    
    Set fldr = fso.CreateFolder(fso.BuildPath(Dir1.Path, newfolder))
    
    Dir1.Path = fldr.Path
    
End Sub

Private Sub Dir1_Change()
    Text1.Text = Dir1.Path
End Sub

Private Sub Drive1_Change()
    Me.Dir1.Path = Drive1.Drive
End Sub

Private Sub Form_Load()
    On Error Resume Next
    
    If NotBlank(strSelectedFolder) Then
        Dir1.Path = strSelectedFolder
    Else
        If fso.FolderExists(strRootFolder) Then
            Dir1.Path = strRootFolder
        Else
            Dir1.Path = App.Path
        End If
    End If
    
    Drive1.Drive = fso.GetDriveName(Dir1.Path)
    
    Text1.Text = strSelectedFolder
End Sub
