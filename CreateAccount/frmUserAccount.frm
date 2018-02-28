VERSION 5.00
Begin VB.Form frmUserAccounts 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "CREATE ACCOUNT"
   ClientHeight    =   5160
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   7260
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5160
   ScaleWidth      =   7260
   StartUpPosition =   1  'CenterOwner
   Begin VB.Frame Frame3 
      Caption         =   "NOTES:"
      Height          =   1410
      Left            =   90
      TabIndex        =   24
      Top             =   3645
      Width           =   7125
      Begin VB.Label Label14 
         Caption         =   "- All ID numbers are validated. If you don't have a valid ID number, ask one from your teacher."
         Height          =   240
         Left            =   180
         TabIndex        =   28
         Top             =   540
         Width           =   6855
      End
      Begin VB.Label Label13 
         Caption         =   "- If an English or Chinese class does not apply to you, select NOCLASS"
         Height          =   240
         Left            =   180
         TabIndex        =   27
         Top             =   1080
         Width           =   6540
      End
      Begin VB.Label Label10 
         Caption         =   "- Always remember your username and password."
         Height          =   285
         Left            =   180
         TabIndex        =   26
         Top             =   810
         Width           =   5055
      End
      Begin VB.Label Label9 
         Caption         =   "- Items marked with (*) are REQUIRED. You cannot leave them blank."
         Height          =   330
         Left            =   180
         TabIndex        =   25
         Top             =   270
         Width           =   6630
      End
   End
   Begin VB.CommandButton cmdClose 
      Caption         =   "&CLOSE"
      Height          =   465
      Left            =   5520
      TabIndex        =   20
      Top             =   2880
      Width           =   1095
   End
   Begin VB.CommandButton cmdSave 
      Caption         =   "&SAVE"
      Height          =   465
      Left            =   5520
      TabIndex        =   19
      Top             =   2280
      Width           =   1095
   End
   Begin VB.Frame Frame2 
      Height          =   1500
      Left            =   90
      TabIndex        =   21
      Top             =   2070
      Width           =   4560
      Begin VB.TextBox Pass2 
         Height          =   330
         IMEMode         =   3  'DISABLE
         Left            =   1620
         PasswordChar    =   "*"
         TabIndex        =   18
         Top             =   1080
         Width           =   2715
      End
      Begin VB.TextBox Pass1 
         Height          =   330
         IMEMode         =   3  'DISABLE
         Left            =   1620
         PasswordChar    =   "*"
         TabIndex        =   17
         Top             =   675
         Width           =   2715
      End
      Begin VB.TextBox txtUserName 
         Height          =   330
         Left            =   1620
         TabIndex        =   16
         Top             =   300
         Width           =   2715
      End
      Begin VB.Label Label12 
         Caption         =   "Confirm Password *"
         Height          =   285
         Left            =   135
         TabIndex        =   23
         Top             =   1125
         Width           =   1680
      End
      Begin VB.Label Label11 
         Caption         =   "Password *"
         Height          =   285
         Left            =   135
         TabIndex        =   22
         Top             =   765
         Width           =   1635
      End
      Begin VB.Label Label8 
         Caption         =   "&Username *"
         Height          =   285
         Left            =   135
         TabIndex        =   15
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
      Begin VB.ComboBox cbChineseClass 
         Height          =   315
         Left            =   4725
         TabIndex        =   14
         Top             =   1080
         Width           =   2175
      End
      Begin VB.ComboBox cbEnglishClass 
         Height          =   315
         Left            =   4725
         TabIndex        =   12
         Top             =   675
         Width           =   2175
      End
      Begin VB.TextBox txtChineseName 
         Height          =   330
         Left            =   4725
         TabIndex        =   10
         Top             =   270
         Width           =   2175
      End
      Begin VB.TextBox txtLastName 
         Height          =   330
         Left            =   1215
         TabIndex        =   8
         Top             =   1485
         Width           =   2130
      End
      Begin VB.TextBox txtMiddleName 
         Height          =   330
         Left            =   1215
         TabIndex        =   6
         Top             =   1080
         Width           =   2130
      End
      Begin VB.TextBox txtFirstName 
         Height          =   330
         Left            =   1215
         TabIndex        =   4
         Top             =   675
         Width           =   2130
      End
      Begin VB.TextBox txtIDNumber 
         Height          =   330
         Left            =   1215
         TabIndex        =   2
         Top             =   270
         Width           =   2130
      End
      Begin VB.Label Label7 
         Caption         =   "C&hinese Class *"
         Height          =   285
         Left            =   3600
         TabIndex        =   13
         Top             =   1125
         Width           =   1185
      End
      Begin VB.Label Label6 
         Caption         =   "En&glish Class *"
         Height          =   285
         Left            =   3600
         TabIndex        =   11
         Top             =   720
         Width           =   1095
      End
      Begin VB.Label Label5 
         Caption         =   "Chin&ese Name"
         Height          =   285
         Left            =   3600
         TabIndex        =   9
         Top             =   360
         Width           =   1410
      End
      Begin VB.Label Label4 
         Caption         =   "&Last Name *"
         Height          =   285
         Left            =   135
         TabIndex        =   7
         Top             =   1575
         Width           =   960
      End
      Begin VB.Label Label3 
         BackStyle       =   0  'Transparent
         Caption         =   "M&iddle Name"
         Height          =   285
         Left            =   135
         TabIndex        =   5
         Top             =   1170
         Width           =   1140
      End
      Begin VB.Label Label1 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BackStyle       =   0  'Transparent
         Caption         =   "ID Num&ber *"
         ForeColor       =   &H80000008&
         Height          =   240
         Left            =   135
         TabIndex        =   1
         Top             =   315
         Width           =   915
      End
      Begin VB.Label Label2 
         Caption         =   "&First Name *"
         Height          =   240
         Left            =   135
         TabIndex        =   3
         Top             =   765
         Width           =   870
      End
   End
End
Attribute VB_Name = "frmUserAccounts"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public strUNCpath As String


'****************************************************
'INPUT CONTROL EVENTS
'****************************************************


Private Sub cbENGLISHClass_Click()
    UpdateControlStatus
End Sub


'****************************************************
'COMMAND CONTROL EVENTS
'****************************************************

Private Sub cmdClose_Click()
    Unload Me
    End
End Sub


Private Sub cmdSave_Click()
    
    If SaveAccount = True Then
        cmdSave.Enabled = False
        IsNewRecord = False
        bChanged = True
        strCurrentID = txtIDNumber
        MsgBox "Save successful"
    Else
        MsgBox "Error saving"
    End If

End Sub


Private Sub Pass1_Change()
    UpdateControlStatus
End Sub

Private Sub Pass2_Change()
    UpdateControlStatus
End Sub

Private Sub txtFirstName_Change()
    UpdateControlStatus
End Sub

Private Sub txtIDNumber_Change()
    UpdateControlStatus
End Sub

Private Sub txtLastName_Change()
    UpdateControlStatus
End Sub

Private Sub txtUserName_Change()
    UpdateControlStatus
End Sub


'****************************************************
'MAIN FORM SECTION
'****************************************************
Private Sub Form_Load()
    InitDBConnection
    LoadClassList
    InitForm
End Sub



'****************************************************
'USER-DEFINED SECTION
'****************************************************

Function NotBlank(ByRef s As String) As Boolean
    
    NotBlank = CBool(Len(RTrim(Trim(s))))
    
End Function

Sub UpdateControlStatus()
    Dim R As Boolean
    
    R = NotBlank(txtIDNumber) And NotBlank(txtFirstName) And NotBlank(txtLastName) And _
        NotBlank(cbChineseClass) And (cbEnglishClass.ListIndex > 0) And NotBlank(txtUserName) And PasswordOK
    
    cmdSave.Enabled = R
End Sub


Sub EmptyForm()
    txtIDNumber = ""
    txtFirstName = ""
    txtMiddleName = ""
    txtLastName = ""
    txtChineseName = ""
    cbChineseClass = ""
    cbEnglishClass = ""
    txtUserName = ""
    Pass1 = ""
    Pass2 = ""
End Sub


Sub InitForm()
    EmptyForm
    UpdateControlStatus
    IsNewRecord = True
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
    
    If Not ValidID(txtIDNumber) Then
        MsgBox "Check that you typed your correct student ID number.", vbExclamation + vbApplicationModal + vbOKOnly, "INVALID ID NUMBER"
        SaveAccount = False
        Exit Function
    End If
    
    Set lrset = CreateObject("ADODB.RECORDSET")
    
    On Error Resume Next
    
    lrset.Open "SELECT * FROM tblAccount WHERE IDNUMBER = """ & strCurrentID & """", dbConnection, adOpenKeyset, adLockOptimistic
    
    dbConnection.BeginTrans
    
    If IsNewRecord Then
        lrset.AddNew
    End If
    
    lrset.Fields("idnumber") = txtIDNumber
    lrset.Fields("firstname") = txtFirstName
    lrset.Fields("middlename") = txtMiddleName
    lrset.Fields("lastname") = txtLastName
    lrset.Fields("chiname") = txtChineseName
    lrset.Fields("ENGCLASS") = cbEnglishClass.ListIndex + 1
    lrset.Fields("CHNCLASS") = cbChineseClass.ListIndex + 1
    lrset.Fields("haschinese") = True
    lrset.Fields("UserName") = txtUserName
    lrset.Fields("password") = Pass1
    lrset.Fields("firstlog") = True
    lrset.Fields("WORKFOLDER") = txtIDNumber
    lrset.Fields("CHNWORKFOLDER") = txtIDNumber
    
    lrset.Update
    
    If Err <> 0 Then
        MsgBox Err.Description
        dbConnection.RollbackTrans
        SaveAccount = False
    Else
        dbConnection.CommitTrans
        ActivateID txtIDNumber
        SaveAccount = True
    End If
    
    Set lrset = Nothing
End Function


Function PasswordOK() As Boolean
    PasswordOK = False
    
    If Len(Pass1) > 0 Then
        If StrComp(Pass1, Pass2, vbBinaryCompare) = 0 Then
            PasswordOK = True
        End If
    End If
End Function

Function ValidID(ByRef sid As String) As Boolean
    Dim lrset As Recordset
    
    ValidID = False
    
    On Error Resume Next
    
    Set lrset = dbConnection.Execute("SELECT * FROM tblValidID WHERE IDNUMBER=""" & sid & """")
    
    If lrset.RecordCount > 0 Then
        If lrset.Fields("ACTIVE") Then
            MsgBox "The ID number you entered is already in use.", vbExclamation + vbApplicationModal + vbOKOnly, "INVALID ID NUMBER"
        Else
            ValidID = True
        End If
    End If
    
    Set lrset = Nothing
End Function

Sub ActivateID(ByRef sid As String)
    
    dbConnection.Execute "UPDATE tblVAlidID SET ACTIVE=TRUE WHERE IDNUMBER = """ & sid & """"
    
End Sub
