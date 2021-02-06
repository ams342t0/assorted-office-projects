VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form main 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "BOOKS"
   ClientHeight    =   6765
   ClientLeft      =   105
   ClientTop       =   105
   ClientWidth     =   9240
   BeginProperty Font 
      Name            =   "Arial Narrow"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "books.frx":0000
   LinkMode        =   1  'Source
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   Moveable        =   0   'False
   NegotiateMenus  =   0   'False
   ScaleHeight     =   6765
   ScaleWidth      =   9240
   StartUpPosition =   2  'CenterScreen
   Begin VB.Frame Frame4 
      Height          =   6180
      Left            =   6660
      TabIndex        =   14
      Top             =   135
      Width           =   2490
      Begin VB.CommandButton cmdOpen 
         Caption         =   "OPEN (F3)"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   465
         Left            =   135
         TabIndex        =   18
         Top             =   945
         Width           =   2220
      End
      Begin VB.CommandButton cmdNew 
         Caption         =   "NEW (F2)"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   465
         Left            =   135
         TabIndex        =   17
         Top             =   360
         Width           =   2220
      End
      Begin VB.CommandButton cmdPrintReceipt 
         Caption         =   "&PRINT (CTRL+P)"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   465
         Left            =   135
         Style           =   1  'Graphical
         TabIndex        =   16
         Top             =   2070
         Width           =   2220
      End
      Begin VB.CommandButton cmdSave 
         Caption         =   "&SAVE"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   465
         Left            =   135
         TabIndex        =   15
         Top             =   1530
         Width           =   2220
      End
   End
   Begin MSComctlLib.StatusBar sbProgramStatus 
      Align           =   2  'Align Bottom
      Height          =   420
      Left            =   0
      TabIndex        =   11
      Top             =   6345
      Width           =   9240
      _ExtentX        =   16298
      _ExtentY        =   741
      _Version        =   393216
      BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
         NumPanels       =   1
         BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
         EndProperty
      EndProperty
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
   End
   Begin VB.Frame Frame2 
      Caption         =   "BOOKS"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   4830
      Left            =   90
      TabIndex        =   8
      Top             =   1395
      Width           =   6450
      Begin MSComctlLib.ListView lvBookList 
         Height          =   3930
         Left            =   45
         TabIndex        =   4
         Top             =   225
         Width           =   6315
         _ExtentX        =   11139
         _ExtentY        =   6932
         LabelWrap       =   -1  'True
         HideSelection   =   -1  'True
         _Version        =   393217
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         NumItems        =   0
      End
      Begin VB.Frame Frame3 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   555
         Left            =   45
         TabIndex        =   9
         Top             =   4185
         Width           =   6315
         Begin VB.Label txtGrandTotal 
            Alignment       =   1  'Right Justify
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   13.5
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H000000FF&
            Height          =   375
            Left            =   2520
            TabIndex        =   12
            Top             =   135
            Width           =   3705
         End
         Begin VB.Label Label4 
            Caption         =   "GRAND TOTAL:"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   13.5
               Charset         =   0
               Weight          =   700
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   375
            Left            =   90
            TabIndex        =   10
            Top             =   135
            Width           =   2310
         End
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "STUDENT INFO"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1230
      Left            =   90
      TabIndex        =   0
      Top             =   135
      Width           =   6450
      Begin VB.TextBox txtName 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   675
         TabIndex        =   1
         Top             =   315
         Width           =   4200
      End
      Begin VB.ComboBox cbSection 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   315
         Left            =   3240
         TabIndex        =   3
         Top             =   765
         Width           =   3075
      End
      Begin VB.ComboBox cbLevel 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   315
         Left            =   675
         TabIndex        =   2
         Top             =   765
         Width           =   1860
      End
      Begin VB.Label txtNumber 
         Alignment       =   2  'Center
         BackColor       =   &H00FFFFFF&
         BorderStyle     =   1  'Fixed Single
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   4995
         TabIndex        =   13
         Top             =   315
         Width           =   1320
      End
      Begin VB.Label Label3 
         Caption         =   "Section"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   2655
         TabIndex        =   7
         Top             =   810
         Width           =   645
      End
      Begin VB.Label Label2 
         Caption         =   "Level"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   180
         TabIndex        =   6
         Top             =   810
         Width           =   510
      End
      Begin VB.Label Label1 
         Caption         =   "Name"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   135
         TabIndex        =   5
         Top             =   405
         Width           =   600
      End
   End
   Begin VB.Menu mnuFile 
      Caption         =   "&File"
      Begin VB.Menu mnuOpenBackEnd 
         Caption         =   "Open Backend..."
      End
      Begin VB.Menu sep3 
         Caption         =   "-"
      End
      Begin VB.Menu mnuPrint 
         Caption         =   "Print"
         Shortcut        =   ^P
      End
      Begin VB.Menu sep 
         Caption         =   "-"
      End
      Begin VB.Menu mnuCloseBackEnd 
         Caption         =   "Close BackEnd"
      End
      Begin VB.Menu sep2 
         Caption         =   "-"
      End
      Begin VB.Menu mnuExit 
         Caption         =   "E&xit"
      End
   End
   Begin VB.Menu mnuRecords 
      Caption         =   "Re&cords"
      Begin VB.Menu mnuNew 
         Caption         =   "&New"
         Shortcut        =   {F2}
      End
      Begin VB.Menu mnuOpenRecord 
         Caption         =   "Open..."
         Shortcut        =   {F3}
      End
   End
   Begin VB.Menu mnuReports 
      Caption         =   "&Reports"
   End
   Begin VB.Menu mnuInventory 
      Caption         =   "&Books"
      Begin VB.Menu mnuNewdatabase 
         Caption         =   "Create New Database"
      End
      Begin VB.Menu mnuBookEntries 
         Caption         =   "Entry..."
      End
      Begin VB.Menu mnuInventorySummary 
         Caption         =   "Inventory..."
         Shortcut        =   ^I
      End
   End
   Begin VB.Menu mnuAbout 
      Caption         =   "About"
      NegotiatePosition=   3  'Right
   End
End
Attribute VB_Name = "main"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Public bSaved As Boolean
Public sAppPath As String



Private Sub cmdNew_Click()
    mnuNew_Click
End Sub

Private Sub cmdOpen_Click()
    mnuOpenRecord_Click
End Sub

Private Sub Form_Activate()
    If bPosted Then
        lCurrentID = tStudPost.id
        txtNumber.Caption = Format(lCurrentID, "00000")
        txtName = tStudPost.name
        cbLevel.ListIndex = tStudPost.level
        cbSection.Text = tStudPost.section
        
        ListBooks
        ClearChecks
        LoadBooksChecked
        
        bEditMode = True
        bSaved = True
        
        DisplayStatus
    End If
    
    If bIDDeleted Then
        mnuNew_Click
    End If
    
End Sub

Private Sub Form_Load()

    sAppPath = App.Path
    
    bConnected = False
    bIDDeleted = False
    
    InitBookList
    
    AllClear
    DisplayStatus
End Sub


Sub AllClear()
    UpdateCommandSave
    bEditMode = False
    bPosted = False
    bSaved = False
    bChangeDate = True
    txtName = ""
    cbLevel.Text = ""
    cbSection.Text = ""
    txtNumber.Caption = ""
    lvBookList.ListItems.Clear
    ComputeGrandTotal
    
    If bConnected Then
        txtName.SetFocus
        UpdateCommandSave
    End If

End Sub


Private Sub Form_Unload(Cancel As Integer)
    If bConnected Then
        CloseBackEnd
    End If
End Sub


Sub DisplayStatus()
    Me.mnuOpenBackEnd.Enabled = Not bConnected
    
    Me.mnuRecords.Enabled = bConnected
    Me.mnuReports.Enabled = bConnected
    Me.mnuInventory.Enabled = bConnected
    Me.mnuCloseBackEnd.Enabled = bConnected
    Me.mnuOpenRecord.Enabled = bConnected
    cmdOpen.Enabled = bConnected
    cmdNew.Enabled = bConnected
    
    Me.txtName.Enabled = bConnected
    Me.cbLevel.Enabled = bConnected
    Me.cbSection.Enabled = bConnected
    Me.lvBookList.Enabled = bConnected
    
    Me.cmdPrintReceipt.Enabled = bSaved And (dGrandTotal > 0)
    Me.mnuPrint.Enabled = cmdPrintReceipt.Enabled
    
    If Not bConnected Then
        lvBookList.ListItems.Clear
    End If
    
    Me.sbProgramStatus.Panels(1).Text = IIf(bConnected, "PROGRAM READY", "BACKEND DISCONNECTED")
    Me.sbProgramStatus.Panels(2).Text = IIf(bSaved, "RECORD OPEN", "NEW BLANK RECORD")
End Sub

Sub OpenBackEnd()
    Set dbConn = CreateObject("ADODB.CONNECTION")
    
    dbConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                              "Data Source=""" & SrcDBPath & """"
    
    dbConn.CursorLocation = adUseClient
    dbConn.Mode = adModeShareDenyNone + adModeReadWrite
    
    dbConn.Open
    
    bConnected = True
    
    LoadLevelandSectionLists
End Sub

Sub CloseBackEnd()
    dbConn.Close
    
    Set dbConn = Nothing
    
    bConnected = False

End Sub

Sub LoadLevelandSectionLists()
    Dim dbRSet As ADODB.Recordset
    
    Set dbRSet = dbConn.Execute("SELECT * FROM tblLevelList")
    
    cbLevel.Clear
    
    While Not dbRSet.EOF
        cbLevel.AddItem dbRSet.Fields("LEVELSTRING"), dbRSet.Fields("LEVELID")
        dbRSet.MoveNext
    Wend
    
    Set dbRSet = Nothing
End Sub


Sub LoadSections()
    Dim dbRSet As ADODB.Recordset
        
    On Error Resume Next
    
    Set dbRSet = dbConn.Execute("SELECT * FROM tblSectionList WHERE LevelID = " & cbLevel.ListIndex)
    
    If Err <> 0 Then
        MsgBox "error"
        CloseBackEnd
        Exit Sub
    End If
    
    cbSection.Clear
    
    cbSection.AddItem "<N.A.>"
    
    While Not dbRSet.EOF
        cbSection.AddItem dbRSet.Fields("SECTIONSTRING")
        dbRSet.MoveNext
    Wend
    
    cbSection.Text = cbSection.List(0)
    
    Set dbRSet = Nothing
End Sub


Sub InitBookList()
    lvBookList.View = lvwReport
    lvBookList.FullRowSelect = True
    lvBookList.GridLines = True
    lvBookList.LabelEdit = lvwManual
    lvBookList.HideSelection = False
    lvBookList.Checkboxes = True
    lvBookList.ColumnHeaders.Add 1, , "", 400
    lvBookList.ColumnHeaders.Add 2, , "TITLE", 3000
    lvBookList.ColumnHeaders.Add 3, , "PRICE", 1000
    lvBookList.ColumnHeaders.Add 4, , "COUNT", 800
    lvBookList.ColumnHeaders.Add 5, , "SOLD", 800
    
    Me.sbProgramStatus.Panels.Add 2
    sbProgramStatus.Panels(1).Width = 4000
    sbProgramStatus.Panels(2).Width = 4000
End Sub


Function Print2ColLine(ByRef col1 As String, ByRef col2 As String, ByVal linelen As Long) As String
    
    Dim nspaces As Long
    
    nspaces = linelen - (Len(col1) + Len(col2))
    
    Print2ColLine = col1 & String(nspaces, " ") & col2
    
End Function

Function CreateReceipt() As Boolean
    Dim il As ListItem
    Dim rctr As Long

    
    CreateReceipt = False
    
    On Error Resume Next
    
    Open sReceipt For Output As #1
    
    If Err <> 0 Then
        MsgBox "ERROR CREATING FILE?"
        Exit Function
    End If
    
    Print #1, comp(0)
    Print #1, "   ZAMBOANGA CHONG HUA HIGH SCHOOL"
    Print #1, "      Gen. V. Alvarez St., Z.C." & vbCrLf & vbCrLf
    Print #1, "            BOOK RECEIPT"
    Print #1, comp(1)
    
    Print #1, Print2ColLine("Receipt No.: " & Format$(lCurrentID, "00000"), Format$(Now, "mm/dd/yyyy") & "   " & Format$(Now, "hh:mm:ss ampm"), 60) & vbCrLf
    Print #1, "Student : " & txtName & "     " & cbLevel.Text & "-" & cbSection.Text & vbCrLf
    Print #1, Print2ColLine("BOOKS", "PRICE", 58)
    Print #1, String(58, "-")

    For Each il In lvBookList.ListItems
        
        If il.Checked Then
            Print #1, Print2ColLine(il.SubItems(1), Format$(il.SubItems(2), "0.00"), 58)
        End If
       
    Next
    Print #1, String(58, "-")
    Print #1, Print2ColLine("TOTAL:", txtGrandTotal.Caption, 58) & vbCrLf
    Print #1, "(" & PrintAmountInWords(dGrandTotal) & ")" & vbCrLf
    Print #1, "Amount Received: ________________________________" & vbCrLf
    Print #1, "      Check No.: ________________________________" & vbCrLf
    Print #1, "    Received by: ________________________________"
    
    Close #1
    
    CreateReceipt = True

End Function

Sub ComputeGrandTotal()
    Dim olitem As ListItem
    
    dGrandTotal = 0
    
    If lvBookList.ListItems.Count > 0 Then
        For Each olitem In lvBookList.ListItems
            If olitem.Checked Then
                dGrandTotal = dGrandTotal + Val(olitem.SubItems(2))
            End If
        Next
    End If
    
    txtGrandTotal.Caption = Format$(dGrandTotal, "P #,0.00")
    
End Sub

Private Sub lvBookList_ItemCheck(ByVal Item As MSComctlLib.ListItem)
    UpdateCommandSave
    ComputeGrandTotal
End Sub

Private Sub mnuAbout_Click()
    frmAbout.Show vbModal, Me
End Sub


Private Sub mnuBookEntries_Click()
    frmBooks.Show vbModal, main
End Sub

Sub ListBooks()
    Dim idx As Long
    Dim dbRSet As Recordset
    
    Set dbRSet = dbConn.Execute("SELECT * FROM tblBooks WHERE LEVEL = " & cbLevel.ListIndex & " ORDER BY ID")
    
    lvBookList.ListItems.Clear
    
    idx = 1
    If dbRSet.RecordCount > 0 Then
        While Not dbRSet.EOF
            
            lvBookList.ListItems.Add idx, , ""
            lvBookList.ListItems(idx).Tag = dbRSet.Fields("ID")
            lvBookList.ListItems(idx).Checked = True
            lvBookList.ListItems(idx).SubItems(1) = dbRSet.Fields("BOOK_TITLE")
            lvBookList.ListItems(idx).SubItems(2) = Format$(dbRSet.Fields("PRICE"), "0.00")
            lvBookList.ListItems(idx).SubItems(3) = dbRSet.Fields("QUANTITY")
            lvBookList.ListItems(idx).SubItems(4) = CountBooksSold(dbRSet.Fields("ID"), cbLevel.ListIndex)
            idx = idx + 1
            dbRSet.MoveNext
        Wend
    End If
    
    ComputeGrandTotal
    
    Set dbRSet = Nothing
End Sub


Function SaveNewStudent() As Boolean
    Dim rsLRSet As Recordset
    Dim tmpDate As Date
    
    SaveNewStudent = False
    
    lCurrentID = GetLastStudID
    tmpDate = Now
    
    On Error Resume Next
    
    Set rsLRSet = CreateObject("ADODB.Recordset")
    
    rsLRSet.Open "tblStudentList", dbConn, adOpenKeyset, adLockOptimistic
    
    If Err <> 0 Then
        MsgBox Err.Description & vbCrLf & Err.Number, vbCritical + vbApplicationModal
        Exit Function
    End If
    
    Err.Clear
    
    rsLRSet.AddNew
    
    dbConn.BeginTrans
    
    rsLRSet.Fields("STUDID") = lCurrentID
    rsLRSet.Fields("STUDNAME") = Me.txtName.Text
    rsLRSet.Fields("STUDLEVEL") = cbLevel.ListIndex
    rsLRSet.Fields("STUDSECTION") = GetSectionID(cbSection.Text)
    rsLRSet.Fields("STUDPAID") = False
    rsLRSet.Fields("RECDATE") = tmpDate
    rsLRSet.Fields("PAYDATE") = tmpDate
    
    rsLRSet.Update
    
    If Err <> 0 Then
        dbConn.RollbackTrans
        MsgBox Err.Description & vbCrLf & Err.Number, vbCritical + vbApplicationModal
        GoTo save_done
    End If
    
    dbConn.CommitTrans
    SaveNewStudent = True
    
save_done:
    
    rsLRSet.Close
        
    Set rsLRSet = Nothing
End Function

Function SaveStudent() As Boolean
    Dim bSaveRes As Boolean
    
    If Not bEditMode Then
        'lCurrentID = GetLastStudID
        'dbConn.Execute "INSERT INTO tblStudentList VALUES(" & lCurrentID & "," & _
        '               """" & txtName & """," & _
        '               cbLevel.ListIndex & "," & GetSectionID(cbSection.Text) & ",FALSE," & StrDate(Now) & "," & StrDate(Now) & ")"
                               
        bSaveRes = SaveNewStudent
        
        If bSaveRes Then
            bEditMode = True
            ClearBooksRecorded lCurrentID
            SaveBooksChecked
        End If
        
        SaveStudent = bSaveRes
    
    Else
    
        If bChangeDate Then
            dbConn.Execute "UPDATE tblStudentList SET tblStudentList.STUDNAME = """ & txtName & """ , " & _
                               "tblStudentList.STUDLEVEL=" & cbLevel.ListIndex & " , tblStudentList.STUDSECTION = " & GetSectionID(cbSection.Text) & _
                               " ,tblStudentList.STUDPaid = FALSE, RecDate = " & StrDate(Now) & " WHERE STUDID = " & lCurrentID
        Else
            dbConn.Execute "UPDATE tblStudentList SET tblStudentList.STUDNAME = """ & txtName & """ , " & _
                               "tblStudentList.STUDLEVEL=" & cbLevel.ListIndex & " , tblStudentList.STUDSECTION = " & GetSectionID(cbSection.Text) & _
                               "  WHERE STUDID = " & lCurrentID
        End If
        ClearBooksRecorded lCurrentID
        SaveBooksChecked
        SaveStudent = True
    End If
End Function

Sub SaveBooksChecked()
    Dim dtime As Date
    Dim olitem As ListItem
    
    dtime = Now
    
    If lvBookList.ListItems.Count > 0 Then
        For Each olitem In lvBookList.ListItems
            If olitem.Checked Then
                SaveBookSold lCurrentID, Val(olitem.Tag), cbLevel.ListIndex, dtime, dtime
            End If
        Next
    End If
    
End Sub

Sub SaveBookSold(ByVal vStudID As Long, ByVal vBookID As Long, ByVal vLevel As Long, ByVal vTime As Date, ByVal vTime2 As Date)
    
    dbConn.Execute "INSERT INTO tblBooksSold VALUES(" & vStudID & "," & vBookID & "," & vLevel & ",#" & vTime & "#,#" & vTime2 & "#,FALSE)"

End Sub

Sub LoadBooksChecked()
    Dim ldbRSet As Recordset
    Dim olitem As ListItem
    Dim lbID As Long
    
    Set ldbRSet = dbConn.Execute("SELECT * FROM tblBooksSold WHERE STUDID = " & lCurrentID & " AND LEVEL = " & cbLevel.ListIndex)
    
    While Not ldbRSet.EOF
        
        lbID = ldbRSet.Fields("ID")
        
        For Each olitem In lvBookList.ListItems
            If Val(olitem.Tag) = lbID Then
                olitem.Checked = True
            End If
        Next
        
        ldbRSet.MoveNext
    Wend
    
    ComputeGrandTotal
    
    Set ldbRSet = Nothing
End Sub

Sub ClearChecks()
    Dim olitem As ListItem
    
    If lvBookList.ListItems.Count > 0 Then
        For Each olitem In lvBookList.ListItems
            olitem.Checked = False
        Next
    End If
    
End Sub

Sub UpdateCommandSave()
    Dim v As Boolean
    
    If bSaved Then
        bSaved = False
    End If
    
    v = (Len(Trim(txtName)) > 0 And Len(cbLevel.Text) > 0 And Len(Me.cbSection.Text) > 0)
    
    cmdSave.Enabled = v
    cmdPrintReceipt.Enabled = bSaved And (dGrandTotal > 0)
End Sub

Private Sub mnuCloseBackEnd_Click()
    CloseBackEnd
    AllClear
    DisplayStatus
End Sub

Private Sub mnuExit_Click()
    Unload Me
End Sub

Private Sub mnuInventorySummary_Click()
    frmBookSaleSummary.Show vbModal, Me
End Sub

Private Sub mnuNew_Click()
    AllClear
    DisplayStatus
End Sub

Private Sub mnuNewdatabase_Click()
    frmCreateNewDatabase.Show vbModal, Me
End Sub

Private Sub mnuOpenBackEnd_Click()
    If OpenUp Then
        OpenBackEnd
        DisplayStatus
        UpdateCommandSave
        mnuNew_Click
    End If
End Sub


Private Sub mnuOpenRecord_Click()
    frmStudentRecord.Show vbModal, main
End Sub

Private Sub mnuPrint_Click()
    cmdPrintReceipt_Click
End Sub

Private Sub mnuReports_Click()
    frmSummary.Show vbModal, Me
End Sub

Private Sub txtName_Change()
    UpdateCommandSave
End Sub


Private Sub cbLevel_Change()
    UpdateCommandSave
End Sub

Private Sub cbLevel_Click()
    LoadSections
    ListBooks
    UpdateCommandSave
End Sub


Private Sub cbSection_Change()
    UpdateCommandSave
End Sub

Private Sub cbSection_Click()
    UpdateCommandSave
End Sub


Private Sub cmdPrintReceipt_Click()
    frmPrintsetup.Show vbModal, Me
    
    If isprint Then
        If Not CreateReceipt Then
            MsgBox "Error creating receipt", vbCritical + vbApplicationModal
        End If
    End If
End Sub

Private Sub cmdSave_Click()
    If SaveStudent Then
        MsgBox "Student saved", vbOKOnly + vbInformation + vbApplicationModal, "RECORD SAVE"
        ListBooks
        ClearChecks
        LoadBooksChecked
        bSaved = True
        Me.cmdPrintReceipt.Enabled = bSaved And (dGrandTotal > 0)
        Me.mnuPrint.Enabled = cmdPrintReceipt.Enabled
        Me.sbProgramStatus.Panels(2).Text = "RECORD OPEN"
        txtNumber.Caption = Format(lCurrentID, "00000")
    Else
        MsgBox "Unable to save. Try again.", vbOKOnly + vbCritical + vbApplicationModal, "RECORD SAVE"
    End If
End Sub





Function PadSpace(ByRef str1 As String, ByVal xCount As Long) As String
    Dim nspaces As Long
    
    If Len(str1) > xCount Then
        PadSpace = Mid$(str1, 1, xCount)
    Else
        nspaces = xCount - Len(str1)
        PadSpace = str1 & String(nspaces, " ")
    End If
    
End Function

