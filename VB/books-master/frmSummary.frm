VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form frmSummary 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "SUMMARY"
   ClientHeight    =   6240
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   8565
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6240
   ScaleWidth      =   8565
   StartUpPosition =   3  'Windows Default
   Begin MSComctlLib.ProgressBar pbPBar 
      Height          =   330
      Left            =   6120
      TabIndex        =   14
      Top             =   5895
      Width           =   2445
      _ExtentX        =   4313
      _ExtentY        =   582
      _Version        =   393216
      Appearance      =   1
   End
   Begin MSComctlLib.StatusBar sbStatBar 
      Align           =   2  'Align Bottom
      Height          =   375
      Left            =   0
      TabIndex        =   13
      Top             =   5865
      Width           =   8565
      _ExtentX        =   15108
      _ExtentY        =   661
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   1
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
         EndProperty
      EndProperty
   End
   Begin VB.CommandButton cmdReport 
      Caption         =   "&REPORT"
      Height          =   390
      Left            =   7290
      TabIndex        =   12
      Top             =   675
      Width           =   1095
   End
   Begin MSComctlLib.ListView lvList 
      Height          =   4335
      Left            =   60
      TabIndex        =   1
      Top             =   1500
      Width           =   8475
      _ExtentX        =   14949
      _ExtentY        =   7646
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   0
   End
   Begin VB.Frame Frame1 
      Height          =   1350
      Left            =   90
      TabIndex        =   0
      Top             =   45
      Width           =   8430
      Begin MSComCtl2.DTPicker txtDateTo 
         Height          =   315
         Left            =   1050
         TabIndex        =   16
         Top             =   900
         Width           =   1815
         _ExtentX        =   3201
         _ExtentY        =   556
         _Version        =   393216
         Format          =   20709377
         CurrentDate     =   39209
      End
      Begin MSComCtl2.DTPicker txtDateFrom 
         Height          =   345
         Left            =   1050
         TabIndex        =   15
         Top             =   540
         Width           =   1815
         _ExtentX        =   3201
         _ExtentY        =   609
         _Version        =   393216
         Format          =   20709377
         CurrentDate     =   39209
      End
      Begin VB.CommandButton cmdFilter 
         Caption         =   "&FILTER"
         Height          =   375
         Left            =   7200
         TabIndex        =   11
         Top             =   225
         Width           =   1095
      End
      Begin VB.TextBox txtTimeTo 
         Height          =   315
         Left            =   4275
         TabIndex        =   8
         Top             =   855
         Width           =   1455
      End
      Begin VB.TextBox txtTimeFrom 
         Height          =   315
         Left            =   4275
         TabIndex        =   7
         Top             =   495
         Width           =   1455
      End
      Begin VB.CheckBox chkFilterTime 
         Caption         =   "Filter &Time"
         Height          =   255
         Left            =   4005
         TabIndex        =   6
         Top             =   180
         Width           =   1095
      End
      Begin VB.OptionButton opPayDate 
         Caption         =   "&Pay Date"
         Height          =   315
         Left            =   270
         TabIndex        =   3
         Top             =   180
         Width           =   1095
      End
      Begin VB.OptionButton opReceiptDate 
         Caption         =   "Re&ceipt Date"
         Height          =   315
         Left            =   1575
         TabIndex        =   2
         Top             =   180
         Width           =   1455
      End
      Begin VB.Label Label4 
         Caption         =   "To"
         Height          =   255
         Left            =   3915
         TabIndex        =   10
         Top             =   900
         Width           =   375
      End
      Begin VB.Label Label3 
         Caption         =   "From"
         Height          =   255
         Left            =   3825
         TabIndex        =   9
         Top             =   540
         Width           =   495
      End
      Begin VB.Label Label2 
         Caption         =   "To"
         Height          =   255
         Left            =   675
         TabIndex        =   5
         Top             =   900
         Width           =   435
      End
      Begin VB.Label Label1 
         Caption         =   "From"
         Height          =   255
         Left            =   585
         TabIndex        =   4
         Top             =   585
         Width           =   435
      End
   End
End
Attribute VB_Name = "frmSummary"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Public FilterString As String
Dim dTimeFrom As Date
Dim dTimeTo As Date
Dim bPaid As Boolean
Dim strFilterHead As String


Sub SetControlStatus()
    Dim s As Boolean
    
    If chkFilterTime.Value = 0 Then
        s = False
    Else
        s = True
    End If
    
    txtTimeFrom.Enabled = s
    txtTimeTo.Enabled = s
    
End Sub


Private Sub chkFilterTime_Click()
    SetControlStatus
End Sub


Function SetFilterString() As Boolean
    
    On Error Resume Next
    
    SetFilterString = False
    
    
    strFilterHead = ""
    
    
    FilterString = " Where bs.studid = sl.studid And b.level = sl.studlevel "
    
    
    If bPaid = True Then
        
        FilterString = FilterString & " AND studPAID"
        
    End If
    
    If Me.chkFilterTime = 1 Then
        
        dTimeFrom = TimeValue(txtTimeFrom.Text)
        
        If Err <> 0 Then
            Exit Function
        End If
        
        dTimeTo = TimeValue(txtTimeTo.Text)
        
        If Err <> 0 Then
            Exit Function
        End If
        
        If opReceiptDate.Value = False Then
            FilterString = FilterString & " AND (TimeValue(sl.PayDate) BETWEEN " & StrTime(dTimeFrom) & " and " & StrTime(dTimeTo) & ")"
        Else
            FilterString = FilterString & " AND (TimeValue(sl.RecDate) BETWEEN " & StrTime(dTimeFrom) & " and " & StrTime(dTimeTo) & ")"
        End If
        
        strFilterHead = Format(dTimeFrom, "HH:MM AMPM") & " to " & Format(dTimeTo, "HH:MM AMPM") & "     "
        
    End If

    If opReceiptDate.Value = True Then
        FilterString = FilterString & " AND (DateValue(sl.RecDate) BETWEEN " & StrDate(txtDateFrom) & " and " & StrDate(txtDateto) & ")"
    Else
        FilterString = FilterString & " AND (DateValue(sl.PayDate) BETWEEN " & StrDate(txtDateFrom) & " and " & StrDate(txtDateto) & ")"
    End If
    
    FilterString = FilterString & " group by sl.studid,sl.studname,xl.sectionstring,ll.levelstring,sl.studpaid"

    strFilterHead = strFilterHead & Format(txtDateFrom, "MM/DD/YYYY") & " to " & Format(txtDateto, "MM/DD/YYYY")

    SetFilterString = True
    
End Function


Private Sub cmdFilter_Click()
    
    If Not SetFilterString Then
        MsgBox "Error in filter options", vbOKOnly + vbApplicationModal
        Exit Sub
    End If
    
    LoadList
    
End Sub


Sub InitListView()
    With lvList
        .View = lvwReport
        .GridLines = True
        .FullRowSelect = True
        .LabelEdit = lvwManual
        .HideSelection = False
        .Sorted = False
        .ColumnHeaders.Add 1, , "No.", 800
        .ColumnHeaders.Add 2, , "Name", 2000
        .ColumnHeaders.Add 3, , "Class", 1500
        .ColumnHeaders.Add 4, , "Date", 1000
        .ColumnHeaders.Add 5, , "Time", 1000
        .ColumnHeaders.Add 6, , "Amt. Due", 1000
        .ColumnHeaders.Add 7, , "Paid", 1000
    End With
End Sub

Private Sub cmdReport_Click()
    Dim xlApp As Object
    Dim xlSheet As Object
    Dim xlBook As Object
    Dim li As ListItem
    Dim trow As Long
    
    If lvList.ListItems.Count = 0 Then
        Exit Sub
    End If
    
    
    Set xlApp = CreateObject("EXCEL.APPLICATION")
    
    Set xlBook = xlApp.Workbooks.Add
    
    
    
    Set xlSheet = xlBook.Sheets(1)
    
    xlSheet.cells(1, 1) = "ZAMBOANGA CHONG HUA HIGH SCHOOL"
    xlSheet.cells(2, 1) = "S.Y. 2006-2007"
    xlSheet.cells(3, 1) = "BOOK SALE SUMMARY"
    
    xlSheet.cells(4, 1) = strFilterHead
    
    xlSheet.cells(6, 1) = "Receipt No."
    xlSheet.cells(6, 2) = "Name"
    xlSheet.cells(6, 3) = "Class"
    xlSheet.cells(6, 4) = "Amount"
    
    trow = 7
    
    pbPBar.Min = 0
    pbPBar.Max = lvList.ListItems.Count
    pbPBar.Value = 0
    
    For Each li In lvList.ListItems
        xlSheet.cells(trow, 1) = Format(li.Text, "00000")
        xlSheet.cells(trow, 2) = li.SubItems(1)
        xlSheet.cells(trow, 3) = li.SubItems(2)
        xlSheet.cells(trow, 4) = li.SubItems(5)
        trow = trow + 1
        pbPBar.Value = pbPBar.Value + 1
    Next
    
    pbPBar.Value = 0
    
    xlSheet.usedrange.Font.name = "Arial"
    xlSheet.usedrange.Font.Size = 10
    
    xlSheet.Columns("a:z").Autofit
    
    xlApp.Visible = True
    
    Set xlSheet = Nothing
    Set xlBook = Nothing
    Set xlApp = Nothing
    
End Sub


Private Sub Form_Load()
    opPayDate.Value = True
    bPaid = True
    chkFilterTime.Value = 0
    SetControlStatus
    
    txtDateFrom = Now
    txtDateto = Now
    
    sbStatBar.Panels.Add
    
    sbStatBar.Panels(1).Width = 2000
    sbStatBar.Panels(2).Width = 2500
    
    InitListView
End Sub


Sub LoadList()
    Dim ldbRSet As Recordset
    Dim idx As Long
    Dim lLevel As Long
    Dim lSection As Long
    Dim tsql As String
    Dim dTotAmount As Double
    Dim tmpdAmount As Double
    Dim lBarCount As Long
    
    Dim newsql As String
    
    newsql = "SELECT sl.studid, sl.studname, xl.sectionstring, ll.levelstring, sl.studpaid, count(b.book_title), sum(b.price) as xtotal, max(sl.recdate) as xrecdate,max( sl.paydate) as xpaydate From " & _
             "(((tblBooksSold AS bs INNER JOIN tblBooks AS b ON bs.id=b.id) " & _
             " INNER JOIN tblStudentList AS sl ON sl.studid=bs.studid) " & _
             " INNER JOIN tblLevelList AS ll ON sl.studlevel=ll.levelid) " & _
             " INNER JOIN tblsectionlist AS xl ON xl.sectionid = sl.studsection "
    
    'tsql = "SELECT * FROM tblStudentList " & FilterString & " ORDER BY STUDID"
    
    newsql = newsql & FilterString & " order by sl.studid"
    
    
    Set ldbRSet = dbConn.Execute(newsql)
    
    lvList.ListItems.Clear
    
    If ldbRSet.RecordCount = 0 Then
        Set ldbRSet = Nothing
        Exit Sub
    End If
    
    pbPBar.Min = 0
    pbPBar.Max = ldbRSet.RecordCount
    
    
    lvList.Sorted = False
    
    idx = 1
    
    dTotAmount = 0
    pbPBar.Value = 0
    
    While Not ldbRSet.EOF
        lvList.ListItems.Add idx, , Format$(ldbRSet.Fields("STUDID"), "00000")
        lvList.ListItems(idx).SubItems(1) = ldbRSet.Fields("STUDNAME")
        lvList.ListItems(idx).SubItems(2) = ldbRSet.Fields("levelstring") & "-" & ldbRSet.Fields("sectionstring")
        
        If opReceiptDate.Value = True Then
            lvList.ListItems(idx).SubItems(3) = Format(ldbRSet.Fields("xRecDate"), "mm/dd/yy")
            lvList.ListItems(idx).SubItems(4) = Format(ldbRSet.Fields("xRecDate"), "hh:mm:ss ampm")
        Else
            lvList.ListItems(idx).SubItems(3) = Format(ldbRSet.Fields("xPayDate"), "mm/dd/yy")
            lvList.ListItems(idx).SubItems(4) = Format(ldbRSet.Fields("xPayDate"), "hh:mm:ss ampm")
        End If
        
        tmpdAmount = ldbRSet.Fields("xtotal")

        lvList.ListItems(idx).SubItems(5) = Format(tmpdAmount, "0,0.00")
        lvList.ListItems(idx).SubItems(6) = ldbRSet.Fields("STUDPaid")
        
        dTotAmount = dTotAmount + tmpdAmount
        
        idx = idx + 1
        
        ldbRSet.MoveNext
        pbPBar.Value = pbPBar.Value + 1
    Wend
    
    pbPBar.Value = 0
    
    Set ldbRSet = Nothing
    
    sbStatBar.Panels(1).Text = "Total Receipts: " & lvList.ListItems.Count
    sbStatBar.Panels(2).Text = "Total Amount: " & Format(dTotAmount, "0,0.00")
    
End Sub

Private Sub lvList_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)
    lvList.Sorted = True
    lvList.SortKey = ColumnHeader.Index - 1
    
    If lvList.SortOrder = lvwAscending Then
        lvList.SortOrder = lvwDescending
    Else
        lvList.SortOrder = lvwAscending
    End If
End Sub

Sub CopyInfo()
    tStudPost.id = Val(lvList.SelectedItem.Text)
    tStudPost.name = lvList.SelectedItem.SubItems(1)
    tStudPost.level = 600
    tStudPost.section = lvList.SelectedItem.SubItems(2)
End Sub

Private Sub lvList_DblClick()
    CopyInfo
    frmQuickView.Show vbModal, Me
End Sub

Private Sub opPayDate_Click()
    bPaid = True
End Sub


Private Sub opReceiptDate_Click()
    bPaid = False
End Sub

