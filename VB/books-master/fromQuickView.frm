VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmQuickView 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "QUICK VIEW"
   ClientHeight    =   3600
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4365
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3600
   ScaleWidth      =   4365
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "&CLOSE"
      Height          =   375
      Left            =   1305
      TabIndex        =   2
      Top             =   3195
      Width           =   1695
   End
   Begin MSComctlLib.ListView lvBookList 
      Height          =   2685
      Left            =   0
      TabIndex        =   0
      Top             =   450
      Width           =   4335
      _ExtentX        =   7646
      _ExtentY        =   4736
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   0
   End
   Begin VB.Label txtStudInfo 
      Caption         =   "Label1"
      Height          =   300
      Left            =   90
      TabIndex        =   1
      Top             =   120
      Width           =   4200
   End
End
Attribute VB_Name = "frmQuickView"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim vBookInfo As tBookInfo

Sub InitList()
    With Me.lvBookList
        .View = lvwReport
        .GridLines = True
        .FullRowSelect = True
        .HideSelection = False
        .LabelEdit = lvwManual
        .ColumnHeaders.Add 1, , "TITLE", 3000
        .ColumnHeaders.Add 2, , "PRICE", 1000
    End With
End Sub

Private Sub Command1_Click()
    Unload Me
End Sub

Private Sub Form_Activate()
        Command1.SetFocus
End Sub

Private Sub Form_Load()
    InitList
    
    txtStudInfo.Caption = tStudPost.name & " " & GetLevelString(tStudPost.level) & "-" & tStudPost.section
    LoadList
End Sub


Sub LoadList()
    Dim tvrs As Recordset
    Dim tvl As ListItem
    Dim dtotal As Double
    Dim dtprice As Double
    
    Set tvrs = dbConn.Execute("SELECT tblbooks.BOOK_TITLE,tblBooks.price  FROM (tblBooksSold INNER JOIN tblBooks ON tblBooksSold.ID = tblBooks.ID and tblBooksSold.Level = tblBooks.Level) WHERE STUDID =" & tStudPost.id)
    
    lvBookList.ListItems.Clear
    
    dtotal = 0
    
    While Not tvrs.EOF
        'GetBookInfo tvrs.Fields("ID")
        dtprice = tvrs.Fields("PRICE")
        
        Set tvl = lvBookList.ListItems.Add(, , tvrs.Fields("BOOK_TITLE"))
        dtprice = tvrs.Fields("pRICE")
        tvl.SubItems(1) = Format(dtprice, "0.00")
        dtotal = dtotal + dtprice
        tvrs.MoveNext
    Wend
    lvBookList.ListItems.Add
    Set tvl = lvBookList.ListItems.Add(, , "TOTAL")
    tvl.SubItems(1) = Format(dtotal, "0,0.00")
    
    tvl.Selected = True
    
    Set tvl = Nothing
    
    Set tvrs = Nothing
    
End Sub

