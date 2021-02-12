VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form frmBookSaleSummary 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "SUMMARY"
   ClientHeight    =   7882
   ClientLeft      =   42
   ClientTop       =   336
   ClientWidth     =   6622
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7882
   ScaleWidth      =   6622
   StartUpPosition =   3  'Windows Default
   Begin MSComctlLib.StatusBar sbSummary 
      Align           =   2  'Align Bottom
      Height          =   336
      Left            =   0
      TabIndex        =   13
      Top             =   7546
      Width           =   6622
      _ExtentX        =   11684
      _ExtentY        =   584
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   1
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
         EndProperty
      EndProperty
   End
   Begin VB.CommandButton cmdReport 
      Caption         =   "&REPORT"
      Height          =   435
      Left            =   5340
      TabIndex        =   12
      Top             =   660
      Width           =   1095
   End
   Begin MSComctlLib.ListView lvList 
      Height          =   5865
      Left            =   45
      TabIndex        =   1
      Top             =   1665
      Width           =   6495
      _ExtentX        =   11455
      _ExtentY        =   10338
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
      Height          =   1665
      Left            =   60
      TabIndex        =   0
      Top             =   -60
      Width           =   6495
      Begin MSComCtl2.DTPicker txtDateTo 
         Height          =   315
         Left            =   750
         TabIndex        =   15
         Top             =   1260
         Width           =   1785
         _ExtentX        =   3226
         _ExtentY        =   584
         _Version        =   393216
         Format          =   20185089
         CurrentDate     =   39209
      End
      Begin MSComCtl2.DTPicker txtDateFrom 
         Height          =   345
         Left            =   750
         TabIndex        =   14
         Top             =   870
         Width           =   1770
         _ExtentX        =   3200
         _ExtentY        =   635
         _Version        =   393216
         Format          =   20185089
         CurrentDate     =   39209
      End
      Begin VB.CommandButton cmdFilter 
         Caption         =   "&FILTER"
         Height          =   375
         Left            =   5280
         TabIndex        =   11
         Top             =   300
         Width           =   1095
      End
      Begin VB.TextBox txtTimeTo 
         Height          =   315
         Left            =   3360
         TabIndex        =   8
         Top             =   960
         Width           =   1455
      End
      Begin VB.TextBox txtTimeFrom 
         Height          =   315
         Left            =   3360
         TabIndex        =   7
         Top             =   600
         Width           =   1455
      End
      Begin VB.CheckBox chkFilterTime 
         Caption         =   "Filter &Time"
         Height          =   255
         Left            =   2880
         TabIndex        =   6
         Top             =   300
         Width           =   1095
      End
      Begin VB.OptionButton opPayDate 
         Caption         =   "&Pay Date"
         Height          =   315
         Left            =   240
         TabIndex        =   3
         Top             =   240
         Width           =   1455
      End
      Begin VB.OptionButton opReceiptDate 
         Caption         =   "Re&ceipt Date"
         Height          =   315
         Left            =   240
         TabIndex        =   2
         Top             =   540
         Width           =   1455
      End
      Begin VB.Label Label4 
         Caption         =   "To"
         Height          =   255
         Left            =   3060
         TabIndex        =   10
         Top             =   1020
         Width           =   375
      End
      Begin VB.Label Label3 
         Caption         =   "From"
         Height          =   255
         Left            =   2940
         TabIndex        =   9
         Top             =   660
         Width           =   495
      End
      Begin VB.Label Label2 
         Caption         =   "To"
         Height          =   255
         Left            =   300
         TabIndex        =   5
         Top             =   1320
         Width           =   435
      End
      Begin VB.Label Label1 
         Caption         =   "From"
         Height          =   255
         Left            =   240
         TabIndex        =   4
         Top             =   960
         Width           =   435
      End
   End
End
Attribute VB_Name = "frmBookSaleSummary"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim FilterString As String
Dim dTimeFrom As Date
Dim dTimeTo As Date
Dim bPaid As Boolean
Dim strFilterHead As String

Dim dTotalAmount As Double
Dim lTotalBooksSold As Long

Sub GetSummary()
    Dim tlvItem As ListItem
    
    dTotalAmount = 0#
    lTotalBooksSold = 0
    
    On Error Resume Next
    
    For Each tlvItem In lvList.ListItems
        If tlvItem.SubItems(1) <> "TOTAL" Then
            lTotalBooksSold = lTotalBooksSold + Val(tlvItem.SubItems(3))
            dTotalAmount = dTotalAmount + (CDbl(tlvItem.SubItems(2)) * CLng(tlvItem.SubItems(3)))
        End If
    Next
    
    Set tlvItem = Nothing
End Sub

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
    
    FilterString = ""
    strFilterHead = ""
    
    If bPaid = True Then
        
        FilterString = " AND PAID"
        
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
            FilterString = FilterString & " AND (TimeValue(PayDate) BETWEEN " & StrDate(dTimeFrom) & " and " & StrDate(dTimeTo) & ")"
        Else
            FilterString = FilterString & " AND (TimeValue(SellDate) BETWEEN " & StrDate(dTimeFrom) & " and " & StrDate(dTimeTo) & ")"
        End If
        
        strFilterHead = Format(dTimeFrom, "HH:MM AMPM") & " to " & Format(dTimeTo, "HH:MM AMPM") & "     "
        
    End If

    If opReceiptDate.Value = True Then
        FilterString = FilterString & " AND (DateValue(SellDate) BETWEEN " & StrDate(txtDateFrom) & " and " & StrDate(txtDateTo) & ")"
    Else
        FilterString = FilterString & " AND (DateValue(PayDate) BETWEEN " & StrDate(txtDateFrom) & " and " & StrDate(txtDateTo) & ")"
    End If
    
    strFilterHead = strFilterHead & Format(txtDateFrom, "MM/DD/YYYY") & " to " & Format(txtDateTo, "MM/DD/YYYY")

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
        .ColumnHeaders.Add 1, , "Level", 1000
        .ColumnHeaders.Add 2, , "Book", 3500
        .ColumnHeaders.Add 3, , "Price", 1000
        .ColumnHeaders.Add 4, , "Sold", 900
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
    
    xlSheet.cells(6, 1) = "Level"
    xlSheet.cells(6, 2) = "Book"
    xlSheet.cells(6, 3) = "Price"
    xlSheet.cells(6, 4) = "Sold"
    
    trow = 7
    
    For Each li In lvList.ListItems
    
        xlSheet.cells(trow, 1) = li.Text
        xlSheet.cells(trow, 2) = li.SubItems(1)
        xlSheet.cells(trow, 3) = li.SubItems(2)
        xlSheet.cells(trow, 4) = li.SubItems(3)
        trow = trow + 1
    Next
    
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
    
    txtDateFrom.Value = Now
    txtDateTo.Value = Now
    
    sbSummary.Panels.Add
    
    sbSummary.Panels(1).Width = 3500
    sbSummary.Panels(2).Width = 3500
    
    InitListView
End Sub

Function CountBooksSold_X(ByVal bookID As Long, ByVal lvlID As Long) As Long
    Dim ldbRSet As Recordset
    Dim tsql As String
    
    tsql = "SELECT COUNT(ID) as BookCount FROM tblBooksSold WHERE ID = " & bookID & " AND LEVEL=" & lvlID & FilterString
    
    Set ldbRSet = dbConn.Execute(tsql)
    
    CountBooksSold_X = ldbRSet.Fields("BookCount")
    
    Set ldbRSet = Nothing
End Function



Sub LoadList()
    Dim ldbRSet As Recordset
    Dim ldbRSet2 As Recordset
    Dim lLevel As Long
    Dim lbID As Long
    Dim tvlItem As ListItem
    Dim tvBooksSold As Long
    Dim stAmount As Double
    Dim stCount As Long
    
    lvList.ListItems.Clear
    lvList.Sorted = False
    
    For lLevel = 0 To 13
        Set ldbRSet2 = dbConn.Execute("SELECT * FROM tblBooks WHERE tblBooks.Level = " & lLevel)
        
        lvList.ListItems.Add , , GetLevelString(lLevel)
        
        stCount = 0
        stAmount = 0#
        
        While Not ldbRSet2.EOF
            lbID = ldbRSet2.Fields("ID")
            
            tvBooksSold = CountBooksSold_X(lbID, lLevel)
            
            If tvBooksSold > 0 Then
                Set tvlItem = lvList.ListItems.Add
                tvlItem.SubItems(1) = ldbRSet2.Fields("BOOK_TITLE")
                tvlItem.SubItems(2) = Format$(ldbRSet2.Fields("PRICE"), "#,0.00")
                tvlItem.SubItems(3) = tvBooksSold
                
                stAmount = stAmount + (CDbl(tvlItem.SubItems(2)) * CLng(tvlItem.SubItems(3)))
                stCount = stCount + tvBooksSold
                
            End If
            
            ldbRSet2.MoveNext
        Wend
        
        Set tvlItem = lvList.ListItems.Add
        tvlItem.SubItems(1) = "TOTAL"
        tvlItem.SubItems(2) = Format$(stAmount, "#,0.00")
        tvlItem.SubItems(3) = stCount
        
    Next
    
    Set tvlItem = Nothing
    
    Set ldbRSet2 = Nothing
    
    GetSummary
    
    sbSummary.Panels(1).Text = "TOTAL BOOKS : " & lTotalBooksSold
    sbSummary.Panels(2).Text = "TOTAL AMOUNT: " & Format$(dTotalAmount, "#,0.00")
End Sub


Private Sub opPayDate_Click()
    bPaid = True
End Sub


Private Sub opReceiptDate_Click()
    bPaid = False
End Sub
