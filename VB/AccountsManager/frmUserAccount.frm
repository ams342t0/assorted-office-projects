VERSION 5.00
Begin VB.Form frmUserAccounts 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "User Accounts"
   ClientHeight    =   4260
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   7260
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   4260
   ScaleWidth      =   7260
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton cmdNew 
      Caption         =   "&NEW"
      Height          =   465
      Left            =   2565
      TabIndex        =   16
      Top             =   3735
      Width           =   1095
   End
   Begin VB.CommandButton cmdClose 
      Caption         =   "&CLOSE"
      Height          =   465
      Left            =   6075
      TabIndex        =   19
      Top             =   3735
      Width           =   1095
   End
   Begin VB.CommandButton cmdDelete 
      Caption         =   "&DELETE"
      Height          =   465
      Left            =   4905
      TabIndex        =   18
      Top             =   3735
      Width           =   1095
   End
   Begin VB.CommandButton cmdSave 
      Caption         =   "&SAVE"
      Height          =   465
      Left            =   3735
      TabIndex        =   17
      Top             =   3735
      Width           =   1095
   End
   Begin VB.Frame Frame2 
      Height          =   1500
      Left            =   90
      TabIndex        =   20
      Top             =   2055
      Width           =   7080
      Begin VB.CommandButton cmdHistory 
         Caption         =   "HISTOR&Y"
         Height          =   510
         Left            =   5400
         TabIndex        =   15
         Top             =   840
         Width           =   1230
      End
      Begin VB.CommandButton cmdPassword 
         Caption         =   "&PASSWORD"
         Height          =   510
         Left            =   5400
         TabIndex        =   14
         Top             =   240
         Width           =   1230
      End
      Begin VB.TextBox txtEnglishWorkFolder 
         Height          =   330
         Left            =   1755
         Locked          =   -1  'True
         TabIndex        =   22
         Top             =   675
         Width           =   2715
      End
      Begin VB.TextBox txtUserName 
         Height          =   330
         Left            =   1755
         TabIndex        =   13
         Top             =   270
         Width           =   2715
      End
      Begin VB.Label Label11 
         Caption         =   "Work Folder"
         Height          =   285
         Left            =   135
         TabIndex        =   21
         Top             =   765
         Width           =   1635
      End
      Begin VB.Label Label8 
         Caption         =   "&Username"
         Height          =   285
         Left            =   135
         TabIndex        =   12
         Top             =   360
         Width           =   1050
      End
   End
   Begin VB.Frame Frame1 
      Height          =   1950
      Left            =   90
      TabIndex        =   0
      Top             =   90
      Width           =   7080
      Begin VB.CheckBox chkFirstLog 
         Caption         =   "&First Log"
         Height          =   330
         Left            =   3645
         TabIndex        =   11
         Top             =   1485
         Width           =   1050
      End
      Begin VB.ComboBox cbChineseClass 
         Height          =   315
         Left            =   4710
         TabIndex        =   10
         Top             =   1065
         Width           =   2175
      End
      Begin VB.ComboBox cbEnglishClass 
         Height          =   315
         Left            =   4725
         TabIndex        =   8
         Top             =   690
         Width           =   2175
      End
      Begin VB.TextBox txtChineseName 
         Height          =   330
         Left            =   1200
         TabIndex        =   6
         Top             =   630
         Width           =   2145
      End
      Begin VB.TextBox txtFirstName 
         Height          =   330
         Left            =   1200
         TabIndex        =   4
         Top             =   255
         Width           =   5655
      End
      Begin VB.TextBox txtIDNumber 
         Height          =   330
         Left            =   1200
         TabIndex        =   2
         Top             =   1020
         Width           =   2130
      End
      Begin VB.Label Label7 
         Caption         =   "C&hinese Class"
         Height          =   285
         Left            =   3600
         TabIndex        =   9
         Top             =   1125
         Width           =   1185
      End
      Begin VB.Label Label6 
         Caption         =   "En&glish Class"
         Height          =   285
         Left            =   3630
         TabIndex        =   7
         Top             =   765
         Width           =   1095
      End
      Begin VB.Label Label5 
         Caption         =   "Chin&ese Name"
         Height          =   270
         Left            =   75
         TabIndex        =   5
         Top             =   705
         Width           =   1110
      End
      Begin VB.Label Label1 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BackStyle       =   0  'Transparent
         Caption         =   "ID Num&ber"
         ForeColor       =   &H80000008&
         Height          =   240
         Left            =   360
         TabIndex        =   1
         Top             =   1080
         Width           =   825
      End
      Begin VB.Label Label2 
         Caption         =   "&Name"
         Height          =   240
         Left            =   660
         TabIndex        =   3
         Top             =   315
         Width           =   480
      End
   End
End
Attribute VB_Name = "frmUserAccounts"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public strUNCpath As String

Dim strUserRootPath As String
Dim strDefRootPath As String
Dim strStudName As String

'****************************************************
'INPUT CONTROL EVENTS
'****************************************************
Private Sub cbChineseClass_Click()
    UpdateControlStatus
End Sub

Sub UpdateUserPaths()
    
    strStudName = txtFirstName
    
    strUserRootPath = CreateUserPaths(strStudName)
    
    txtEnglishWorkFolder = strUserRootPath

End Sub

Private Sub cbENGLISHClass_Click()
    UpdateUserPaths
    UpdateControlStatus
End Sub


'****************************************************
'COMMAND CONTROL EVENTS
'****************************************************

Private Sub cmdClose_Click()
    Unload Me
End Sub

Private Sub cmdDelete_Click()
    If MsgBox("Delete current account?", vbQuestion + vbApplicationModal + vbYesNo, "Delete Account") = vbNo Then
        Exit Sub
    End If
    
    cmdDelete.Enabled = False
    bChanged = True
    cmdNew_Click
End Sub

Private Sub cmdHistory_Click()
    With frmHistory
        .cbIDNumbers.Text = strCurrentID
        .opID = True
        .opID.Enabled = False
        .opComputer.Enabled = False
        .cbComputers.Enabled = False
        .cbIDNumbers.Enabled = False
        .Caption = "History data of " & txtFirstName
        .Show vbModal, Me
    End With
End Sub

Private Sub cmdNew_Click()
    IsNewRecord = True
    InitForm
    strUserPassword = ""
    cmdHistory.Enabled = False
    chkFirstLog = 1
End Sub

Private Sub cmdPassword_Click()
    Form1.Show vbModal, MainWindow
    UpdateControlStatus
End Sub

Private Sub cmdSave_Click()
    
    If SaveAccount = True Then
        cmdSave.Enabled = False
        cmdDelete.Enabled = True
        cmdHistory.Enabled = True
        IsNewRecord = False
        bChanged = True
        strCurrentID = txtIDNumber
        MsgBox "Save successful"
    Else
        MsgBox "Error saving"
    End If

End Sub



Private Sub txtEnglishWorkFolder_Change()
    UpdateControlStatus
End Sub

Private Sub txtFirstName_Change()
    UpdateUserPaths
    UpdateControlStatus
End Sub

Private Sub txtIDNumber_Change()
    UpdateControlStatus
End Sub


Private Sub txtUserName_Change()
    UpdateControlStatus
End Sub


'****************************************************
'MAIN FORM SECTION
'****************************************************
Private Sub Form_Load()
    LoadClassList
    InitForm
End Sub



'****************************************************
'USER-DEFINED SECTION
'****************************************************
Sub UpdateControlStatus()
    Dim R As Boolean
    
    R = NotBlank(txtIDNumber) And NotBlank(txtFirstName) And _
                      NotBlank(cbEnglishClass) And NotBlank(txtUserName) And _
                      NotBlank(txtEnglishWorkFolder) And NotBlank(strUserPassword)
    
    cmdSave.Enabled = R
    cmdPassword.Enabled = NotBlank(txtUserName)
End Sub


Sub EmptyForm()
    txtIDNumber = ""
    txtFirstName = ""
    txtChineseName = ""
    cbChineseClass = ""
    cbEnglishClass = ""
    txtUserName = ""
    txtEnglishWorkFolder = ""
    txtChineseWorkFolder = ""
End Sub


Sub FillUpForm()
    Dim lrset As Recordset
    
    On Error Resume Next
    
    Set lrset = dbConnection.Execute("SELECT * FROM tblAccount WHERE IDNUMBER = """ & strCurrentID & """")
    
    txtIDNumber = strCurrentID
    txtFirstName = lrset.Fields("STUDNAME")
    txtChineseName = lrset.Fields("CHINAME")
    cbChineseClass.ListIndex = lrset.Fields("CHNCLASS") - 1
    cbEnglishClass.ListIndex = lrset.Fields("ENGCLASS") - 1
    txtUserName = lrset.Fields("USERNAME")
    txtEnglishWorkFolder = lrset.Fields("WORKFOLDER")
    strUserPassword = lrset.Fields("PASSWORD")
    strDefRootPath = lrset.Fields("WORKFOLDER")
    
    Set lrset = Nothing
End Sub


Sub InitForm()
    If IsNewRecord Then
        EmptyForm
        UpdateControlStatus
        cmdDelete.Enabled = False
        cmdHistory.Enabled = False
        strCurrentID = ""
        chkFirstLog = 1
    Else
        cmdSave.Enabled = False
        cmdDelete.Enabled = True
        cmdPassword.Enabled = True
        cmdHistory.Enabled = True
        FillUpForm
    End If
End Sub


Sub LoadClassList()
    Dim lrset As Recordset
    
    Set lrset = dbConnection.Execute("SELECT ClassName FROM tblClassList ORDER BY ClassID")
    
    cbEnglishClass.Clear
    cbChineseClass.Clear
    
    While Not lrset.EOF
        cbEnglishClass.AddItem lrset.Fields("ClassName")
        cbChineseClass.AddItem lrset.Fields("ClassName")
        lrset.MoveNext
    Wend
    
    Set lrset = Nothing
End Sub


Function SaveAccount() As Boolean
    Dim lrset As Recordset
    Dim wsh As Object
    
    Set lrset = CreateObject("ADODB.RECORDSET")
    
    On Error Resume Next
    
    lrset.Open "SELECT * FROM tblAccount WHERE IDNUMBER = """ & strCurrentID & """", dbConnection, adOpenKeyset, adLockOptimistic
    
    dbConnection.BeginTrans
    
    If IsNewRecord Then
        lrset.AddNew
    End If
    
    lrset.Fields("idnumber") = txtIDNumber
    lrset.Fields("STUDNAME") = txtFirstName
    lrset.Fields("chiname") = txtChineseName
    lrset.Fields("ENGCLASS") = cbEnglishClass.ListIndex + 1
    lrset.Fields("CHNCLASS") = cbChineseClass.ListIndex + 1
    lrset.Fields("UserName") = txtUserName
    lrset.Fields("password") = strUserPassword
    lrset.Fields("firstlog") = CBool(chkFirstLog)
    lrset.Fields("WORKFOLDER") = txtEnglishWorkFolder.Text
    lrset.Fields("UNCPATH") = CreateUNCPath(txtIDNumber)
    
    lrset.Update
    
    If Err <> 0 Then
        MsgBox Err.Description
        dbConnection.RollbackTrans
        SaveAccount = False
    Else
        dbConnection.CommitTrans
        
        If IsNewRecord Then
        
            If CreateWorkFolder(strUserRootPath, txtIDNumber, strStudName) <> 0 Then
                MsgBox "Error in sharing command", vbInformation + vbOKOnly + vbApplicationModal, "SHARING FOLDER"
            End If
        
        Else
            Set wsh = CreateObject("Wscript.shell")
                
            If StrComp(strDefRootPath, strUserRootPath, vbTextCompare) <> 0 Then
                    
                    If Not fso.FolderExists(strClassRootPath) Then
                        fso.CreateFolder strClassRootPath
                    End If
                    
                    fso.MoveFolder strDefRootPath, strUserRootPath
                    
                    If wsh.Run("net share " & txtIDNumber & "$=""" & strUserRootPath & """ /unlimited /remark:""" & strStudName & """", 0, 1) <> 0 Then
                        MsgBox "Error in sharing command", vbInformation + vbOKOnly + vbApplicationModal, "SHARING FOLDER"
                    End If
            End If
            
            Set wsh = Nothing
        End If
        
        SaveAccount = True
    End If
    
    Set lrset = Nothing
End Function


