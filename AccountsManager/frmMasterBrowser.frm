VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmMasterBrowser 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Master Browser"
   ClientHeight    =   8955
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   12150
   LinkTopic       =   "Form1"
   MDIChild        =   -1  'True
   ScaleHeight     =   8955
   ScaleWidth      =   12150
   Begin VB.CheckBox chkLogOffAll 
      Caption         =   "&All"
      Height          =   240
      Left            =   4200
      TabIndex        =   16
      Top             =   690
      Width           =   570
   End
   Begin VB.Frame Frame4 
      Height          =   7425
      Left            =   10140
      TabIndex        =   10
      Top             =   1185
      Width           =   4815
      Begin VB.DirListBox lstStudDir 
         Height          =   2790
         Left            =   90
         TabIndex        =   14
         Top             =   225
         Width           =   4650
      End
      Begin VB.FileListBox lstStudFile 
         Height          =   3210
         Left            =   90
         TabIndex        =   13
         Top             =   3060
         Width           =   4635
      End
      Begin VB.CommandButton cmdCopyToFolder 
         Caption         =   "COPY TO..."
         Height          =   375
         Left            =   135
         TabIndex        =   12
         Top             =   6315
         Width           =   1185
      End
      Begin VB.CommandButton cmdCopyTo 
         Caption         =   "COPY"
         Height          =   375
         Left            =   120
         TabIndex        =   11
         Top             =   6795
         Width           =   1185
      End
      Begin VB.Label txtCopyToFolder 
         BackColor       =   &H8000000E&
         BorderStyle     =   1  'Fixed Single
         Height          =   375
         Left            =   1395
         TabIndex        =   15
         Top             =   6345
         Width           =   3285
      End
   End
   Begin VB.CommandButton cmdAudit 
      Caption         =   "&AUDIT"
      Height          =   645
      Left            =   8055
      TabIndex        =   9
      Top             =   135
      Width           =   960
   End
   Begin MSComctlLib.StatusBar sbStatBar 
      Align           =   2  'Align Bottom
      Height          =   420
      Left            =   0
      TabIndex        =   8
      Top             =   8535
      Width           =   12150
      _ExtentX        =   21431
      _ExtentY        =   741
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   3
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Alignment       =   1
            Object.Width           =   5292
            MinWidth        =   5292
         EndProperty
         BeginProperty Panel2 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Alignment       =   1
            Object.Width           =   5292
            MinWidth        =   5292
         EndProperty
         BeginProperty Panel3 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            Object.Width           =   3528
            MinWidth        =   3528
         EndProperty
      EndProperty
   End
   Begin VB.CommandButton cmdRefresh 
      Caption         =   "&REFRESH"
      Height          =   645
      Left            =   7020
      TabIndex        =   6
      Top             =   135
      Width           =   960
   End
   Begin VB.CommandButton cmdOpenFolder 
      Caption         =   "OPEN FOL&DER"
      Height          =   645
      Left            =   5970
      TabIndex        =   5
      Top             =   135
      Width           =   960
   End
   Begin VB.CommandButton cmdLogOffAll 
      Caption         =   "&LOG OFF"
      Height          =   645
      Left            =   4935
      TabIndex        =   4
      Top             =   135
      Width           =   960
   End
   Begin VB.Frame Frame2 
      Height          =   9540
      Left            =   45
      TabIndex        =   7
      Top             =   1170
      Width           =   10005
      Begin MSComctlLib.ListView lvUserList 
         Height          =   9330
         Left            =   75
         TabIndex        =   1
         Top             =   165
         Width           =   9870
         _ExtentX        =   17410
         _ExtentY        =   16457
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         NumItems        =   8
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Text            =   "Computer No."
            Object.Width           =   1058
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   1
            Text            =   "User Name"
            Object.Width           =   2117
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Text            =   "Student Name"
            Object.Width           =   4410
         EndProperty
         BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   3
            Text            =   "Chinese Name"
            Object.Width           =   1764
         EndProperty
         BeginProperty ColumnHeader(5) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   4
            Text            =   "Logged"
            Object.Width           =   1411
         EndProperty
         BeginProperty ColumnHeader(6) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   5
            Text            =   "Time Started"
            Object.Width           =   1764
         EndProperty
         BeginProperty ColumnHeader(7) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   6
            Text            =   "Working Folder"
            Object.Width           =   7056
         EndProperty
         BeginProperty ColumnHeader(8) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   7
            Text            =   "Engclass"
            Object.Width           =   0
         EndProperty
      End
   End
   Begin VB.Frame Frame1 
      Height          =   1005
      Left            =   45
      TabIndex        =   0
      Top             =   45
      Width           =   4830
      Begin VB.OptionButton Op2 
         Caption         =   "Chinese"
         Height          =   255
         Left            =   240
         TabIndex        =   18
         Top             =   600
         Width           =   1095
      End
      Begin VB.OptionButton Op1 
         Caption         =   "English"
         Height          =   255
         Left            =   240
         TabIndex        =   17
         Top             =   240
         Width           =   975
      End
      Begin VB.CheckBox chkShowLogged 
         Caption         =   "&Show Only Logged Users"
         Height          =   285
         Left            =   1845
         TabIndex        =   3
         Top             =   630
         Width           =   2220
      End
      Begin VB.ComboBox cbClass 
         Height          =   315
         Left            =   1485
         TabIndex        =   2
         Top             =   270
         Width           =   3255
      End
   End
End
Attribute VB_Name = "frmMasterBrowser"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public strSQLString As String
Dim mbutton As Long
Dim nclassid As Long

Private Sub cmdAudit_Click()
    Dim li As ListItem
    
    
    For Each li In lvUserList.ListItems
        If Not fso.FolderExists(li.SubItems(6)) Then
            If MsgBox("Work folder of " & li.SubItems(2) & " is invalid. Fix?", vbOKCancel + vbApplicationModal, "INVALID FOLDER") = vbOK Then
                FixWorkFolder li
            End If
        End If
    Next
    
    LoadStudentList
    
End Sub

Sub FixWorkFolder(ByRef li As ListItem)
    Dim strClassRootPath As String
    Dim strUserRootPath As String

    strUserRootPath = CreateUserPaths(li.SubItems(2))
                
    If CreateWorkFolder(strUserRootPath, li.Tag, li.SubItems(2)) <> 0 Then
        MsgBox "Error in sharing command", vbInformation + vbOKOnly + vbApplicationModal, "SHARING FOLDER"
    Else
        MsgBox li.SubItems(2) & " folder fixed.", vbInformation + vbOKOnly + vbApplicationModal, "SHARING FOLDER"
    End If
                
    dbConnection.Execute "UPDATE tblAccount SET WORKFOLDER= """ & strUserRootPath & """, UNCPATH = """ & CreateUNCPath(li.Tag) & """  WHERE IDNUMBER=""" & li.Tag & """"
End Sub

Private Sub cmdCopyTo_Click()
    Dim strDestPath As String
    Dim strSourcePath As String
    Dim chiname As String
    
    chiname = Trim(lvUserList.SelectedItem.SubItems(3))
    
    strDestPath = fso.BuildPath(Me.txtCopyToFolder.Caption, lvUserList.SelectedItem.SubItems(2)) & IIf(Len(chiname) > 0, "-" & chiname, "") & "\"
    strSourcePath = fso.BuildPath(lstStudFile.Path, lstStudFile.List(lstStudFile.ListIndex))
    
    If Not fso.FolderExists(strDestPath) Then
        fso.CreateFolder strDestPath
    End If
    
    fso.CopyFile strSourcePath, strDestPath
    
    MsgBox "File copied.", vbOKOnly + vbApplicationModal, "FILE COPY"
End Sub

Private Sub cmdCopyToFolder_Click()
    strSelectedFolder = txtCopyToFolder.Caption
    
    frmWorkFolder.Show vbModal
    
    txtCopyToFolder.Caption = strSelectedFolder
End Sub



'**************************************************
'MAIN SECTION
'**************************************************

Private Sub Form_Load()
    LoadClassList
    Op1.Value = True
    sbStatBar.Panels(2) = Format$(Now, "mm/dd/yyyy")
    frmMasterBrowser.sbStatBar.Panels(3).Text = IIf(bEnableLogging, "Logging enabled", "Logging disabled")
    cmdLogOffAll.Enabled = False
    cmdAudit.Enabled = False
    
    lstStudDir.Path = strRootFolder
    lstStudDir.Enabled = False
    lstStudFile.Enabled = False
    cmdCopyToFolder.Enabled = False
    cmdCopyTo.Enabled = False
    
End Sub



'**************************************************
'CONTROL EVENTS
'**************************************************
Private Sub chkLogOffAll_Click()
    If Not Me.cmdLogOffAll.Enabled Then
        Me.cmdLogOffAll.Enabled = True
    End If
End Sub

Private Sub cmdLogOffAll_Click()
    Dim li As ListItem
    
    If Me.chkLogOffAll.Value = 1 Then
        If MsgBox("Log everybody", vbYesNo + vbApplicationModal + vbQuestion, "LOG OFF") = vbYes Then
            For Each li In lvUserList.ListItems
                WriteHistory li
                LogOff li
            Next
            MsgBox "Done", vbOKOnly + vbApplicationModal + vbInformation, "LOG OFF"
        End If
    Else
        If MsgBox("Log off this student?", vbYesNo + vbApplicationModal + vbQuestion, "LOG OFF") = vbYes Then
            WriteHistory Me.lvUserList.SelectedItem
            LogOff lvUserList.SelectedItem
            MsgBox "Done", vbOKOnly + vbApplicationModal + vbInformation, "LOG OFF"
        End If
    End If
End Sub


Private Sub cmdRefresh_Click()
    CreateSQLString
    LoadStudentList
End Sub

Private Sub cbClass_Click()
    nclassid = cbClass.ListIndex
    On Error Resume Next
    CreateSQLString
    LoadStudentList
End Sub


Private Sub Form_Resize()

    If Me.Width < 10000 Then
        Exit Sub
    End If
    
    Frame4.Left = Me.Width - Frame4.Width - 200
    
    Frame2.Width = Me.Width - Frame4.Width - 400
    lvUserList.Width = Frame2.Width - 200
    Frame2.Height = Me.Height - 2000
    lvUserList.Height = Frame2.Height - 200
    
End Sub


Private Sub lstStudDir_Change()
    lstStudFile.Path = lstStudDir.Path
    
    If lstStudFile.ListCount = 0 Then
        cmdCopyTo.Enabled = False
    End If
End Sub

Private Sub lstStudFile_Click()
    If lstStudFile.ListCount > 0 And NotBlank(Me.txtCopyToFolder) Then
        cmdCopyTo.Enabled = True
    Else
        cmdCopyTo.Enabled = False
    End If
End Sub

Private Sub lvUserList_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)
    lvUserList.Sorted = True
    lvUserList.SortKey = ColumnHeader.Index - 1
    
    If lvUserList.SortOrder = lvwAscending Then
        lvUserList.SortOrder = lvwDescending
    Else
        lvUserList.SortOrder = lvwAscending
    End If
End Sub

Private Sub lvUserList_ItemClick(ByVal Item As MSComctlLib.ListItem)
    Dim fso As Object
    
    strCurrentID = Item.Tag
    cmdLogOffAll.Enabled = True
    
    On Error Resume Next
    
    Set fso = CreateObject("Scripting.Filesystemobject")
    
    Me.lstStudDir.Path = Item.SubItems(6)
    Me.lstStudFile.Path = Item.SubItems(6)
    
    If Err = 0 Then
        lstStudDir.Enabled = True
        lstStudFile.Enabled = True
        cmdCopyToFolder.Enabled = True
    Else
        lstStudDir.Enabled = False
        lstStudFile.Enabled = False
        cmdCopyToFolder.Enabled = False
        cmdCopyTo.Enabled = False
    End If
    
    If mbutton = 2 Then
        MainWindow.PopupMenu MainWindow.mnuPopup
    End If
            
End Sub

Private Sub lvUserList_DblClick()
    If lvUserList.ListItems.Count = 0 Then
        Exit Sub
    End If
    
    bChanged = False
    IsNewRecord = False
    
    frmUserAccounts.Show vbModal, MainWindow
    
    If bChanged Then
        LoadStudentList
    End If
    
End Sub


'**************************************************
'USER-DEFINED
'**************************************************
Sub LoadClassList()
    Dim lrset As Recordset
    Dim n As Long
    
    Set lrset = dbConnection.Execute("SELECT classid,ClassName FROM tblClassList ORDER BY ClassID")
    
    ReDim tclass(lrset.RecordCount)
    
    cbClass.Clear
    
    n = 0
    While Not lrset.EOF
        tclass(n).classid = n
        tclass(n).classindex = lrset.Fields("CLASSID")
        cbClass.AddItem lrset.Fields("ClassName"), n
        n = n + 1
        lrset.MoveNext
    Wend
    
    cbClass.ListIndex = 1
    
    Set lrset = Nothing
End Sub

Sub CreateSQLString()
    If Op1 Then
        strSQLString = "SELECT * FROM (tblAccount as ta INNER JOIN tblClasslist as cl on ta.engclass=cl.classid) WHERE ENGCLASS = " & tclass(cbClass.ListIndex).classindex
    Else
        strSQLString = "SELECT * FROM (tblAccount as ta INNER JOIN tblClasslist as cl on ta.engclass=cl.classid) WHERE CHNCLASS = " & tclass(cbClass.ListIndex).classindex
    End If
End Sub


Sub LoadStudentList()
    Dim lrset As Recordset
    Dim li As ListItem
    
    Set lrset = dbConnection.Execute(strSQLString)
    
    Me.lvUserList.ListItems.Clear
    Me.lvUserList.Sorted = False
    
    On Error Resume Next
    
    While Not lrset.EOF
        Set li = lvUserList.ListItems.Add(, , IIf(Len(lrset.Fields("COMPUTERNAME")) > 0, lrset.Fields("COMPUTERNAME"), ""))
        li.SubItems(1) = lrset.Fields("USERNAME")
        li.SubItems(2) = lrset.Fields("STUDNAME")
        li.SubItems(3) = lrset.Fields("CHINAME")
        li.SubItems(4) = lrset.Fields("LOGGED")
        li.SubItems(5) = Format$(lrset.Fields("LOGINDATE"), "h:m:s ampm")
        li.SubItems(6) = lrset.Fields("WORKFOLDER")
        li.SubItems(7) = lrset.Fields("CLASSNAME")
        li.Tag = lrset.Fields("IDNUMBER")
        lrset.MoveNext
    Wend
    
    sbStatBar.Panels(1).Text = "Users : " & lvUserList.ListItems.Count
        
    If lvUserList.ListItems.Count > 0 Then
        cmdAudit.Enabled = True
    Else
        cmdAudit.Enabled = False
    End If
        
    Set lrset = Nothing
    
End Sub

Private Sub lvUserList_MouseDown(Button As Integer, Shift As Integer, x As Single, y As Single)
    mbutton = Button
End Sub

Private Sub Op1_Click()
    CreateSQLString
    LoadStudentList
End Sub

Private Sub Op2_Click()
    CreateSQLString
    LoadStudentList
End Sub

Sub LogOff(ByRef vli As ListItem)
    dbConnection.Execute "UPDATE tblAccount SET LOGOUTDATE = #" & Now & "#, LOGGED=FALSE WHERE IDNUMBER = """ & vli.Tag & """"
    'vli.SubItems(3) = False
End Sub


Sub WriteHistory(ByRef li As ListItem)
    Dim lrset As Recordset
    
    'If Not CBool(li.SubItems(3)) Then
    '    Exit Sub
    'End If
    
    Set lrset = CreateObject("adodb.recordset")
    
    lrset.Open "tblHistory", dbConnection, adOpenKeyset, adLockOptimistic
    
    lrset.AddNew
    lrset.Fields("IDNUMBER") = li.Tag
    lrset.Fields("COMPUTERNAME") = li.Text
    lrset.Fields("DATETIME") = Now
    lrset.Fields("LOGTYPE") = 1
    lrset.Fields("STUDNAME") = li.SubItems(2)
    lrset.Fields("LEVELSECTION") = cbClass.Text
    
    lrset.Update
    
    Set lrset = Nothing
End Sub
