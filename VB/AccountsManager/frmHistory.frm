VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomct2.ocx"
Begin VB.Form frmHistory 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "History"
   ClientHeight    =   6285
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   7740
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6285
   ScaleWidth      =   7740
   StartUpPosition =   1  'CenterOwner
   Begin VB.Frame Frame2 
      Caption         =   "Filter"
      Height          =   780
      Left            =   45
      TabIndex        =   10
      Top             =   0
      Width           =   5055
      Begin VB.ComboBox cbComputers 
         Height          =   315
         Left            =   3780
         TabIndex        =   3
         Text            =   "Combo2"
         Top             =   315
         Width           =   1185
      End
      Begin VB.OptionButton opComputer 
         Caption         =   "Computer"
         Height          =   330
         Left            =   2745
         TabIndex        =   2
         Top             =   315
         Width           =   1050
      End
      Begin VB.ComboBox cbIDNumbers 
         Height          =   315
         Left            =   900
         TabIndex        =   1
         Text            =   "Combo1"
         Top             =   315
         Width           =   1635
      End
      Begin VB.OptionButton opID 
         Caption         =   "ID No."
         Height          =   285
         Left            =   90
         TabIndex        =   0
         Top             =   315
         Width           =   915
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Date Range"
      Height          =   825
      Left            =   45
      TabIndex        =   6
      Top             =   810
      Width           =   5055
      Begin MSComCtl2.DTPicker dateTo 
         Height          =   330
         Left            =   3150
         TabIndex        =   5
         Top             =   315
         Width           =   1680
         _ExtentX        =   2963
         _ExtentY        =   582
         _Version        =   393216
         Format          =   20316161
         CurrentDate     =   38905
      End
      Begin MSComCtl2.DTPicker dateFrom 
         Height          =   330
         Left            =   675
         TabIndex        =   4
         Top             =   315
         Width           =   1680
         _ExtentX        =   2963
         _ExtentY        =   582
         _Version        =   393216
         Format          =   20316161
         CurrentDate     =   38905
      End
      Begin VB.Label Label2 
         Caption         =   "To"
         Height          =   240
         Left            =   2835
         TabIndex        =   9
         Top             =   360
         Width           =   420
      End
      Begin VB.Label Label1 
         Caption         =   "From"
         Height          =   285
         Left            =   135
         TabIndex        =   8
         Top             =   360
         Width           =   1545
      End
   End
   Begin MSComctlLib.ListView lvHistoryList 
      Height          =   4560
      Left            =   45
      TabIndex        =   7
      Top             =   1665
      Width           =   7620
      _ExtentX        =   13441
      _ExtentY        =   8043
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
      NumItems        =   6
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Text            =   "Date"
         Object.Width           =   1764
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   1
         Text            =   "Time"
         Object.Width           =   1764
      EndProperty
      BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   2
         Text            =   "Computer"
         Object.Width           =   1411
      EndProperty
      BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   3
         Text            =   "Status"
         Object.Width           =   1411
      EndProperty
      BeginProperty ColumnHeader(5) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   4
         Text            =   "Name"
         Object.Width           =   3528
      EndProperty
      BeginProperty ColumnHeader(6) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   5
         Text            =   "Class"
         Object.Width           =   2540
      EndProperty
   End
End
Attribute VB_Name = "frmHistory"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim strDateQuery As String

Private Sub cbComputers_click()
    LoadList
End Sub

Private Sub cbIDNumbers_click()
    LoadList
End Sub

Private Sub cmdClose_Click()
    Unload Me
End Sub

Private Sub dateFrom_Change()
    LoadList
End Sub

Private Sub dateTo_Change()
    LoadList
End Sub


Sub LoadList()
    Dim li As ListItem
    Dim lrset As Recordset
    
    lvHistoryList.ListItems.Clear
    
    strDateQuery = " between #" & DateValue(dateFrom.Value) & "# and #" & DateValue(dateTo.Value) & "#"
    
    If opID Then
        Set lrset = dbConnection.Execute("SELECT * FROM tblHistory WHERE DateValue(DateTime) " & strDateQuery & " AND IDNUMBER=""" & Me.cbIDNumbers.Text & """ ORDER BY DateTime DESC")
        lvHistoryList.ColumnHeaders(3).Text = "Computer"
    Else
        Set lrset = dbConnection.Execute("SELECT * FROM tblHistory WHERE DateValue(DateTime) " & strDateQuery & " AND COMPUTERNAME=""" & cbComputers.Text & """ ORDER BY DateTime DESC")
        lvHistoryList.ColumnHeaders(3).Text = "User ID"
    End If
    
    While Not lrset.EOF
        Set li = lvHistoryList.ListItems.Add(, , Format$(lrset.Fields("DATETIME"), "mm/dd/yy"))
        
        li.SubItems(1) = Format$(lrset.Fields("DATETIME"), "h:m ampm")
        
        If opID Then
            li.SubItems(2) = lrset.Fields("COMPUTERNAME")
        Else
            li.SubItems(2) = lrset.Fields("IDNUMBER")
        End If
        
        li.SubItems(3) = IIf(lrset.Fields("LOGTYPE") = 0, "LOG-ON", "LOG-OFF")
        li.SubItems(4) = lrset.Fields("STUDNAME")
        li.SubItems(5) = lrset.Fields("LEVELSECTION")
        
        lrset.MoveNext
    Wend
    
    Set lrset = Nothing
    Set li = Nothing
    
End Sub


Sub FillIDNumbers()
    Dim lrset As Recordset
    
    Set lrset = dbConnection.Execute("SELECT IDNUMBER from tblAccount ORDER BY IDNUMBER")
    
    cbIDNumbers.Clear
    With lrset
        While Not .EOF
            cbIDNumbers.AddItem lrset.Fields("IDNUMBER")
            .MoveNext
        Wend
    End With
    
    Set lrset = Nothing
End Sub

Sub FillComputers()
    Dim i As Long
    
    cbComputers.Clear
    For i = 1 To 50
            cbComputers.AddItem "U" & Format(i, "00")
    Next

End Sub

Private Sub Form_Load()
    FillComputers
    FillIDNumbers
    dateFrom.Value = Now
    dateTo.Value = Now
    
End Sub

Private Sub lvHistoryList_DblClick()
    If lvHistoryList.ListItems.Count = 0 Then
        Exit Sub
    End If
    
    If opComputer Then
        MsgBox lvHistoryList.SelectedItem.SubItems(2)
    End If
End Sub

Private Sub opComputer_Click()
    LoadList
End Sub

Private Sub opID_Click()
    LoadList
End Sub
