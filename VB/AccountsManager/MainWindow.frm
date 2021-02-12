VERSION 5.00
Begin VB.MDIForm MainWindow 
   BackColor       =   &H8000000C&
   Caption         =   "Accounts Manager"
   ClientHeight    =   7995
   ClientLeft      =   60
   ClientTop       =   630
   ClientWidth     =   9180
   Icon            =   "MainWindow.frx":0000
   LinkTopic       =   "MDIForm1"
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   Begin VB.Menu mnuFile 
      Caption         =   "&File"
      Begin VB.Menu mnuCreateAccount 
         Caption         =   "&Create Account"
      End
      Begin VB.Menu mnuImportList 
         Caption         =   "&Import List"
      End
      Begin VB.Menu mnusep 
         Caption         =   "-"
      End
      Begin VB.Menu mnuReset 
         Caption         =   "Reset Database"
      End
      Begin VB.Menu mns2 
         Caption         =   "-"
      End
      Begin VB.Menu mnuExit 
         Caption         =   "E&xit"
      End
   End
   Begin VB.Menu mnuTools 
      Caption         =   "&Tools"
      Begin VB.Menu mnuMasterBrowser 
         Caption         =   "&Master Browser"
      End
      Begin VB.Menu mnuHistory 
         Caption         =   "&History"
      End
      Begin VB.Menu sep3 
         Caption         =   "-"
      End
      Begin VB.Menu mnuRootFolder 
         Caption         =   "Set &Root User Folder"
      End
      Begin VB.Menu sep4 
         Caption         =   "-"
      End
      Begin VB.Menu mnuIDManager 
         Caption         =   "ID Manager"
      End
      Begin VB.Menu sep 
         Caption         =   "-"
      End
      Begin VB.Menu mnuEnableLogon 
         Caption         =   "Enable &Logon"
         Checked         =   -1  'True
      End
   End
   Begin VB.Menu mnuAbout 
      Caption         =   "A&bout"
   End
   Begin VB.Menu mnuPopup 
      Caption         =   "mnuPopup"
      Visible         =   0   'False
      Begin VB.Menu mnuCopyToSave 
         Caption         =   "COPY TO SAVE FOLDER"
      End
   End
End
Attribute VB_Name = "MainWindow"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub MDIForm_Initialize()
    Dim connstr As String
    
    strAppPath = App.Path
    
    On Error Resume Next
    
    Set wshnet = CreateObject("WScript.Network")
    Set dbConnection = CreateObject("ADODB.CONNECTION")
    
                               
    connstr = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                "User ID=Admin;" & _
              "Data Source=" & strAppPath & "\LABACCOUNTS.mdb" & ";" & _
              "Jet OLEDB:Database Password=""klatuberataniktu"";"

    dbConnection.Mode = adModeReadWrite + adModeShareDenyNone
    dbConnection.CursorLocation = adUseClient
    dbConnection.ConnectionString = connstr
    dbConnection.Open
    
    If Err <> 0 Then
        MsgBox "Error connecting to database" & vbCrLf & Err.Description, vbCritical + vbApplicationModal + vbOKOnly, "Lab Sec Error"
        Unload Me
    End If
    
    Set fso = CreateObject("Scripting.FileSystemObject")
    
    GetRootFolder
    
End Sub

Sub SetEnableLog(ByVal vb As Boolean)
    dbConnection.Execute "UPDATE tblSettings SET EnableLogon = " & vb
End Sub

Function EnableLogonStatus() As Boolean
    Dim lrset As Recordset
    
    Set lrset = dbConnection.Execute("SELECT ENABLELOGON FROM tblSettings")
    
    EnableLogonStatus = lrset.Fields("ENABLELOGON")
    
    Set lrset = Nothing
End Function

Private Sub MDIForm_Load()
    mnuEnableLogon.Checked = EnableLogonStatus
    bEnableLogging = mnuEnableLogon.Checked
    mnuHistory.Enabled = True
End Sub

Private Sub MDIForm_Terminate()
    dbConnection.Close
    Set dbConnection = Nothing
End Sub


Private Sub mnuAbout_Click()
    frmAbout.Show vbModal, Me
End Sub

Private Sub mnuCreateAccount_Click()
    IsNewRecord = True
    frmUserAccounts.Show vbModal, Me
End Sub

Private Sub mnuEnableLogon_Click()
    SetEnableLog Not mnuEnableLogon.Checked
    mnuEnableLogon.Checked = Not mnuEnableLogon.Checked
    bEnableLogging = mnuEnableLogon.Checked
    
    If frmMasterBrowser.Visible Then
        frmMasterBrowser.sbStatBar.Panels(3).Text = IIf(bEnableLogging, "Logging enabled", "Logging disabled")
    End If
End Sub

Private Sub mnuExit_Click()
    Unload Me
    End
End Sub

Private Sub mnuHistory_Click()
    With frmHistory
        .opID = True
        .opID.Enabled = True
        .opComputer.Enabled = True
        .cbComputers.Enabled = True
        .cbIDNumbers.Enabled = True
        .Caption = "HISTORY DATA"
        .Show vbModal, Me
    End With
End Sub

Private Sub mnuIDManager_Click()
    frmIDManager.Show , Me
  
End Sub

Private Sub mnuImportList_Click()
    InitOFN
    
    If GetOFN(ofn) > 0 Then
       frmImportStatus.Show
    End If
End Sub

Private Sub mnuMasterBrowser_Click()
    frmMasterBrowser.Show
End Sub

Private Sub mnuReset_Click()
    If MsgBox("Confirm reset", vbExclamation + vbOKCancel + vbApplicationModal, "RESET ACCOUNTS DATABASE") = vbOK Then
        dbConnection.Execute "DELETE * FROM tblAccount"
        dbConnection.Execute "DELETE * FROM tblHistory"
        
        MsgBox "User accounts and history cleared", vbinformationn + vbOKOnly + vbApplicationModal, "RESET ACCOUNTS DATABASE"
    End If
End Sub

Private Sub mnuRootFolder_Click()
    frmWorkFolder.Show vbModal, Me
    
    If NotBlank(strSelectedFolder) Then
        strRootFolder = Replace(strSelectedFolder, " ", "_")
        SaveRootFolder
    End If
    
End Sub
