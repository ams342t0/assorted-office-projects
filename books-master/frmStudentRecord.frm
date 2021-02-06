VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form frmStudentRecord 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "STUDENT RECORD"
   ClientHeight    =   8880
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   6780
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   8880
   ScaleWidth      =   6780
   StartUpPosition =   1  'CenterOwner
   Begin VB.Frame Frame2 
      Height          =   690
      Left            =   45
      TabIndex        =   9
      Top             =   7695
      Width           =   6675
      Begin MSComCtl2.DTPicker dtCustomTime 
         Height          =   330
         Left            =   4725
         TabIndex        =   13
         Top             =   225
         Width           =   1635
         _ExtentX        =   2884
         _ExtentY        =   582
         _Version        =   393216
         Format          =   20643842
         CurrentDate     =   40695
      End
      Begin VB.CheckBox chkCustomTime 
         Caption         =   "CUSTOM TIME"
         Height          =   330
         Left            =   3240
         TabIndex        =   12
         Top             =   225
         Width           =   1545
      End
      Begin MSComCtl2.DTPicker dtCustomDate 
         Height          =   375
         Left            =   1755
         TabIndex        =   11
         Top             =   225
         Width           =   1365
         _ExtentX        =   2408
         _ExtentY        =   661
         _Version        =   393216
         Format          =   20643841
         CurrentDate     =   40695
      End
      Begin VB.CheckBox chkCustomDate 
         Caption         =   "CUSTOM DATE"
         Height          =   240
         Left            =   180
         TabIndex        =   10
         Top             =   270
         Width           =   1545
      End
   End
   Begin MSComctlLib.ProgressBar sbPBar 
      Height          =   375
      Left            =   45
      TabIndex        =   6
      Top             =   7245
      Width           =   6690
      _ExtentX        =   11800
      _ExtentY        =   661
      _Version        =   393216
      Appearance      =   1
   End
   Begin MSComctlLib.StatusBar sbStatBar 
      Align           =   2  'Align Bottom
      Height          =   420
      Left            =   0
      TabIndex        =   5
      Top             =   8460
      Width           =   6780
      _ExtentX        =   11959
      _ExtentY        =   741
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   1
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
         EndProperty
      EndProperty
   End
   Begin VB.Frame Frame1 
      Height          =   1005
      Left            =   90
      TabIndex        =   3
      Top             =   120
      Width           =   6630
      Begin MSComCtl2.DTPicker txtDateto 
         Height          =   345
         Left            =   3450
         TabIndex        =   8
         Top             =   630
         Width           =   1965
         _ExtentX        =   3466
         _ExtentY        =   609
         _Version        =   393216
         Format          =   20643841
         CurrentDate     =   39209
      End
      Begin MSComCtl2.DTPicker txtDateFrom 
         Height          =   345
         Left            =   3450
         TabIndex        =   7
         Top             =   240
         Width           =   1965
         _ExtentX        =   3466
         _ExtentY        =   609
         _Version        =   393216
         Format          =   20643841
         CurrentDate     =   39209
      End
      Begin VB.CommandButton cmdGo 
         Caption         =   "&GO"
         Height          =   645
         Left            =   5535
         TabIndex        =   4
         Top             =   270
         Width           =   1005
      End
      Begin VB.CommandButton cmdDelete 
         Caption         =   "DELETE"
         Height          =   645
         Left            =   1620
         TabIndex        =   2
         Top             =   225
         Width           =   1500
      End
      Begin VB.CommandButton cmdPost 
         Caption         =   "&POST"
         Height          =   645
         Left            =   135
         TabIndex        =   0
         Top             =   225
         Width           =   1365
      End
   End
   Begin MSComctlLib.ListView lvStudentList 
      Height          =   5970
      Left            =   60
      TabIndex        =   1
      Top             =   1215
      Width           =   6630
      _ExtentX        =   11695
      _ExtentY        =   10530
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   0
   End
End
Attribute VB_Name = "frmStudentRecord"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim FilterString As String

Dim customdate As Date
Dim customtime As Date

Sub InitListView()
    With lvStudentList
        .View = lvwReport
        .GridLines = True
        .FullRowSelect = True
        .LabelEdit = lvwManual
        .HideSelection = False
        .Sorted = False
        .Checkboxes = True
        .ColumnHeaders.Add 1, , "Paid", 500
        .ColumnHeaders.Add 2, , "ID", 1000
        .ColumnHeaders.Add 3, , "Name", 3000
        .ColumnHeaders.Add 4, , "Level", 1000
        .ColumnHeaders.Add 5, , "Section", 1000
    End With
End Sub

Sub LoadList()
    Dim ldbRSet As Recordset
    Dim idx As Long
    
    Dim sqlstring As String
    
    On Error Resume Next
    
    sqlstring = "SELECT a.studid,a.studname,a.studpaid,b.sectionstring,c.levelstring from (tblStudentList as A inner join tblSectionList as B on A.StudSection=B.SectionID) " & _
    " inner join tbllevelList as C on A.studlevel = c.levelid"
   
    sqlstring = sqlstring & FilterString & " order by studid"
    
    Set ldbRSet = dbConn.Execute(sqlstring)


    lvStudentList.ListItems.Clear
    lvStudentList.Sorted = False
    
    idx = 1
    
    sbPBar.Value = 0
    sbPBar.Min = 0
    
    sbPBar.Max = ldbRSet.RecordCount
    
    While Not ldbRSet.EOF
        
        lvStudentList.ListItems.Add idx
        lvStudentList.ListItems(idx).Checked = ldbRSet.Fields("STUDPaid")
        lvStudentList.ListItems(idx).SubItems(1) = Format$(ldbRSet.Fields("STUDID"), "00000")
        lvStudentList.ListItems(idx).SubItems(2) = ldbRSet.Fields("STUDNAME")
        lvStudentList.ListItems(idx).SubItems(3) = ldbRSet.Fields("levelstring")
        lvStudentList.ListItems(idx).SubItems(4) = ldbRSet.Fields("sectionstring")
        idx = idx + 1
        ldbRSet.MoveNext
        sbPBar.Value = sbPBar.Value + 1
    Wend
    
    sbPBar.Value = 0
    
    Set ldbRSet = Nothing
    
    sbStatBar.Panels(1).Text = "Total Receipts : " & lvStudentList.ListItems.Count
    
End Sub

Sub DeleteStudent()
    dbConn.Execute "DELETE FROM tblStudentList WHERE STUDID = " & Val(lvStudentList.SelectedItem.SubItems(1))
End Sub

Private Sub chkCustomDate_Click()
    dtCustomDate.Enabled = chkCustomDate
End Sub

Private Sub chkCustomTime_Click()
    dtCustomTime.Enabled = chkCustomTime
End Sub

Private Sub cmdDelete_Click()
    If MsgBox("Delete record?", vbYesNo + vbExclamation + vbApplicationModal, "DELETE RECORD") = vbYes Then
        ClearBooksRecorded Val(lvStudentList.SelectedItem.SubItems(1))
        DeleteStudent
        
        If lCurrentID = Val(lvStudentList.SelectedItem.SubItems(1)) Then
            bIDDeleted = True
        End If
        
        lvStudentList.ListItems.Remove lvStudentList.SelectedItem.Index
               
        cmdPost.Enabled = False
        cmdDelete.Enabled = False
                
        MsgBox "Record Removed", vbOKOnly + vbApplicationModal, "RECORD DELETE"
    End If
End Sub


Private Sub cmdGo_Click()
    If SetFilterString Then
        LoadList
    Else
        MsgBox "Check dates"
    End If
    
End Sub

Sub CopyInfo()
    tStudPost.id = Val(lvStudentList.SelectedItem.SubItems(1))
    tStudPost.name = lvStudentList.SelectedItem.SubItems(2)
    tStudPost.level = GetLevelID(lvStudentList.SelectedItem.SubItems(3))
    tStudPost.section = lvStudentList.SelectedItem.SubItems(4)
End Sub

Private Sub cmdPost_Click()
    bPosted = True
    bChangeDate = False
    
    CopyInfo
    
    Unload Me
End Sub

Private Sub Form_Load()
    InitListView
    
    txtDateFrom.Value = Now
    txtDateTo.Value = Now
    
    cmdPost.Enabled = False
    cmdDelete.Enabled = False
    bPosted = False
    bIDDeleted = False
    
    sbStatBar.Panels.Add
    
    sbStatBar.Panels(1).Width = 2000
    sbStatBar.Panels(2).Width = 2000
    
    chkCustomDate = False
    dtCustomDate.Enabled = chkCustomDate
    
    chkCustomTime = False
    dtCustomTime.Enabled = chkCustomTime
    
End Sub


Private Sub lvStudentList_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)
    lvStudentList.Sorted = True
    lvStudentList.SortKey = ColumnHeader.Index - 1
    
    If lvStudentList.SortOrder = lvwAscending Then
        lvStudentList.SortOrder = lvwDescending
    Else
        lvStudentList.SortOrder = lvwAscending
    End If
    
End Sub

Private Sub lvStudentList_DblClick()
    CopyInfo
    frmQuickView.Show vbModal, Me
End Sub

Private Sub lvStudentList_ItemCheck(ByVal Item As MSComctlLib.ListItem)
    Dim xdate As Date
    
    If MsgBox("Change status of student?", vbYesNo + vbApplicationModal, "VERIFY STATUS") = vbNo Then
        Item.Checked = Not Item.Checked
        Exit Sub
    End If
    
    If chkCustomDate And chkCustomTime Then
        xdate = DateValue(dtCustomDate) & " " & TimeValue(dtCustomTime)
    End If
    
    If (chkCustomDate) And (Not chkCustomTime) Then
        xdate = DateValue(dtCustomDate) & " " & TimeValue(Now)
    End If
    
    If Not chkCustomDate And chkCustomTime Then
        xdate = DateValue(Now) & " " & TimeValue(dtCustomTime)
    End If
    
    If (chkCustomDate Or chkCustomTime) = False Then
        xdate = Now
    End If
    
    dbConn.Execute "UPDATE tblStudentList SET studPaid = " & Item.Checked & ",PAYDATE = " & sdate(xdate) & " WHERE STUDID = " & Val(Item.SubItems(1))
    
    UpdateBookStatus Val(Item.SubItems(1)), Item.Checked
End Sub

Sub UpdateBookStatus(ByVal lStudId As Long, ByVal bPaid As Boolean)
    dbConn.Execute "UPDATE tblBooksSold SET Paid = " & bPaid & ",PayDate = #" & Now & "# WHERE STUDID = " & lStudId
End Sub

Private Sub lvStudentList_ItemClick(ByVal Item As MSComctlLib.ListItem)
    cmdPost.Enabled = True
    cmdDelete.Enabled = True
End Sub


Function SetFilterString() As Boolean
    
    On Error Resume Next
    
    SetFilterString = False
    
    FilterString = " WHERE (DateValue(RecDate) BETWEEN " & StrDate(txtDateFrom) & " and " & StrDate(txtDateTo) & ")"

    SetFilterString = True
    
End Function

