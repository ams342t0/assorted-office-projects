VERSION 5.00
Begin VB.Form frmLogin 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "LOGIN TO COMPUTER LAB"
   ClientHeight    =   1995
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4890
   Icon            =   "frmLoginForm.frx":0000
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1995
   ScaleWidth      =   4890
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame Frame1 
      Height          =   1935
      Left            =   45
      TabIndex        =   0
      Top             =   0
      Width           =   4785
      Begin VB.CommandButton cmdAccept 
         Caption         =   "&ACCEPT"
         Height          =   510
         Left            =   1530
         TabIndex        =   5
         Top             =   1305
         Width           =   1725
      End
      Begin VB.TextBox txtPassword 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   420
         IMEMode         =   3  'DISABLE
         Left            =   1530
         PasswordChar    =   "*"
         TabIndex        =   4
         Top             =   720
         Width           =   3120
      End
      Begin VB.TextBox txtUserName 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   420
         Left            =   1530
         TabIndex        =   2
         Top             =   225
         Width           =   3120
      End
      Begin VB.Label Label2 
         Caption         =   "&Password"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   135
         TabIndex        =   3
         Top             =   765
         Width           =   1275
      End
      Begin VB.Label Label1 
         Caption         =   "&Username"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   135
         TabIndex        =   1
         Top             =   270
         Width           =   1275
      End
   End
End
Attribute VB_Name = "frmLogin"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'***************************************************
'MAIN SECTION
'***************************************************
Private Sub Form_Load()
    ConnectDatabase
    
    bConnected = EnableLogonStatus
    
    If Not bConnected Then
        MsgBox "Logging is disabled at this moment.", vbInformation + vbApplicationModal, "Computer Lab"
        Unload Me
        End
    End If
    
    cmdAccept.Enabled = Not bConnected
    Set wshnet = CreateObject("WScript.Network")
End Sub


Private Sub Form_Unload(Cancel As Integer)
    On Error Resume Next
    
    dbConnection.Close
    
    Set dbConnection = Nothing
End Sub



'***************************************************
'CONTROL EVENTS
'***************************************************
Private Sub cmdAccept_Click()
    Dim errtype As Integer
    
    If Not AuthenticateUser(errtype) Then
        Select Case errtype
            Case 1
                MsgBox "Invalid user name", vbExclamation + vbOKOnly + vbApplicationModal, "LOG IN USERNAME"
                txtPassword.Text = ""
                txtUserName.SetFocus
                
            Case 2
                MsgBox "Invalid password", vbExclamation + vbOKOnly + vbApplicationModal, "LOG IN PASSWORD"
                txtPassword.Text = ""
                txtPassword.SetFocus
        End Select
        Exit Sub
    
    Else
        If bFirstLog = True Then
            MsgBox "This is your first time to log in. You must now change your current password", vbInformation + vbOKOnly + vbApplicationModal, "LOGGED IN"
            Form1.Show vbModal, Me
            UpdatePassword
            ClearFirstLog
        End If
        
        UpdateLogonInfo
        WriteLoginHistory
        
        If MapDrive Then
            MsgBox strStudentName & " logged." & vbCrLf & "Your work folder is now available as drive z:", vbInformation + vbApplicationModal + vbOKOnly, "LOG IN"
            Shell "explorer z:", vbNormalFocus
        End If
    End If
    
endofsub:
    Unload Me
    End
    
End Sub

Private Sub txtPassword_Change()
    SetAcceptState
End Sub

Private Sub txtUserName_Change()
    SetAcceptState
End Sub

Private Sub txtPassword_KeyPress(KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then
        cmdAccept_Click
    End If
End Sub

Private Sub txtUserName_KeyPress(KeyAscii As Integer)
    If KeyAscii = vbKeyReturn Then
        txtPassword = ""
        txtPassword.SetFocus
    End If
End Sub



'***************************************************
'USER DEFINED
'***************************************************

Sub UpdateLogonInfo()
    Dim lrset As Recordset
    
    Set lrset = CreateObject("adodb.recordset")
    
    lrset.Open "SELECT IDNUMBER,COMPUTERNAME,LOGINDATE,logged FROM tblAccount WHERE IDNUMBER = """ & strStudID & """", dbConnection, adOpenKeyset, adLockOptimistic
    
    lrset.Fields("IDNUMBER") = strStudID
    lrset.Fields("COMPUTERNAME") = wshnet.ComputerName
    lrset.Fields("LOGINDATE") = Now
    lrset.Fields("LOGGED") = True
    
    lrset.Update
    
    Set lrset = Nothing
End Sub


Function EnableLogonStatus() As Boolean
    Dim lrset As Recordset
    
    Set lrset = dbConnection.Execute("SELECT ENABLELOGON FROM TBLSETTINGS")
    
    EnableLogonStatus = lrset.Fields("ENABLELOGON")
    
    Set lrset = Nothing
End Function


Private Sub ConnectDatabase()
    Dim connstr As String
    
    On Error Resume Next
    
    Set dbConnection = CreateObject("ADODB.CONNECTION")
    
    ReadDataBaseSource
    
    connstr = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
              "Data Source=" & strDBPath & ";" & _
              "Jet OLEDB:Database Password=""klatuberataniktu"";"
    
    dbConnection.Mode = adModeReadWrite + adModeShareDenyNone
    dbConnection.CursorLocation = adUseClient
    dbConnection.ConnectionString = connstr
    dbConnection.Open
    
    If Err <> 0 Then
        MsgBox "Unable to connect to server at this time.", vbInformation + vbApplicationModal + vbOKOnly, "LOGIN ERROR"
        Unload Me
        End
    End If

End Sub


Sub ReadDataBaseSource()
    Dim i As Integer
    
    i = FreeFile
    
    Open App.Path & "\dbpath.dat" For Input As i
    
    Input #i, strDBPath
    
    Close i
End Sub


Function AuthenticateUser(ByRef errtype As Integer) As Boolean
    Dim lrset As Recordset
    
    Set lrset = dbConnection.Execute("SELECT * FROM tblAccount WHERE USERNAME = """ & txtUserName & """")
    
    AuthenticateUser = True
    errtype = 0
    
    If lrset.RecordCount = 0 Then
        AuthenticateUser = False
        errtype = 1
    Else
        If StrComp(LCase(txtPassword), lrset.Fields("password"), vbTextCompare) <> 0 Then
            AuthenticateUser = False
            errtype = 2
        End If
        strStudID = lrset.Fields("IDNUMBER")
        strUNCPath = lrset.Fields("UNCPATH")
        strStudentName = lrset.Fields("STUDNAME")
        strClass = GetClassString(lrset.Fields("ENGCLASS"))
        bFirstLog = lrset.Fields("FIRSTLOG")
    End If
    
    Set lrset = Nothing
End Function


Public Function GetClassString(ByVal i As Long) As String
    Dim lrset As Recordset
    
    On Error Resume Next
    
    Set lrset = dbConnection.Execute("SELECT CLASSNAME FROM tblClassList WHERE classid = " & i)
    
    GetClassString = lrset.Fields("classname")
    
    Set lrset = Nothing
End Function


Sub UpdatePassword()
    Dim lrset As Recordset
    
    On Error Resume Next
    
    Set lrset = CreateObject("adodb.recordset")
    
    lrset.Open "SELECT * FROM tblAccount WHERE IDNUMBER = """ & strStudID & """", dbConnection, adOpenKeyset, adLockOptimistic
        
    lrset.Fields("PASSWORD") = strUserPassword
    
    lrset.Update
    
    Set lrset = Nothing
End Sub

Sub ClearFirstLog()
    
    dbConnection.Execute "UPDATE tblAccount SET FIRSTLOG = FALSE WHERE IDNUMBER = """ & strStudID & """", , adExecuteNoRecords
    
End Sub

Function MapDrive() As Boolean
    Dim fso As Object
    
    On Error Resume Next
    
    Set fso = CreateObject("scripting.filesystemobject")
    
    If fso.DriveExists("z") Then
        wshnet.RemoveNetworkDrive "z:", True, True
    End If
    
    MapDrive = True
    
    wshnet.MapNetworkDrive "z:", strUNCPath
    
    If Err <> 0 Then
        MsgBox Err.Description & vbCrLf & "Report immediately to your teacher.", vbCritical + vbOKOnly, "ERROR"
        MapDrive = False
    End If
    
End Function


Sub RemoveMappedDrives()
    Dim wsc As Object
    Dim i As Long
    
    On Error Resume Next
    
    Set wshnet = CreateObject("WSCript.Network")
    
    Set wsc = wshnet.EnumNetworkDrives
    
    If wsc.Count > 0 Then
        For i = 0 To wsc.Count - 1 Step 2
            wshnet.RemoveNetworkDrive wsc(i)
        Next
    End If
    
End Sub


Sub WriteLoginHistory()
    Dim lrset As Recordset
    
    Set lrset = CreateObject("adodb.recordset")
    
    
    On Error Resume Next
    
    lrset.Open "tblHistory", dbConnection, adOpenKeyset, adLockOptimistic
    
    lrset.AddNew
    lrset.Fields("IDNUMBER") = strStudID
    lrset.Fields("COMPUTERNAME") = wshnet.ComputerName
    lrset.Fields("DATETIME") = Now
    lrset.Fields("LOGTYPE") = 0
    lrset.Fields("STUDNAME") = strStudentName
    lrset.Fields("LEVELSECTION") = strClass
    
    lrset.Update
    
    Set lrset = Nothing
End Sub

Sub SetAcceptState()
    cmdAccept.Enabled = ((Len(txtUserName)) > 0 And (Len(txtPassword) > 0)) Or (Not bConnected)
End Sub
