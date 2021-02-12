VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmImportStatus 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Import List"
   ClientHeight    =   7605
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   6000
   ControlBox      =   0   'False
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MDIChild        =   -1  'True
   MinButton       =   0   'False
   ScaleHeight     =   7605
   ScaleWidth      =   6000
   ShowInTaskbar   =   0   'False
   Begin VB.ComboBox cbSchoolYear 
      Height          =   315
      Left            =   600
      TabIndex        =   4
      Text            =   "Combo1"
      Top             =   120
      Width           =   2415
   End
   Begin VB.CommandButton cmdImport 
      Caption         =   "IMPORT"
      Height          =   465
      Left            =   3120
      TabIndex        =   3
      Top             =   120
      Width           =   1365
   End
   Begin VB.ListBox listStatus 
      Height          =   6300
      Left            =   90
      TabIndex        =   2
      Top             =   720
      Width           =   5850
   End
   Begin VB.CommandButton Command1 
      Caption         =   "CLOSE"
      Height          =   465
      Left            =   4560
      TabIndex        =   1
      Top             =   120
      Width           =   1365
   End
   Begin MSComctlLib.ProgressBar pbStatus 
      Height          =   375
      Left            =   45
      TabIndex        =   0
      Top             =   7200
      Width           =   5895
      _ExtentX        =   10398
      _ExtentY        =   661
      _Version        =   393216
      Appearance      =   1
   End
   Begin VB.Label Label1 
      Caption         =   "S.Y."
      Height          =   255
      Left            =   90
      TabIndex        =   5
      Top             =   180
      Width           =   435
   End
End
Attribute VB_Name = "frmImportStatus"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdImport_Click()
    FastCreateRecord ofn.lpstrFile
End Sub


Private Sub Form_Load()
    Dim rs As ADODB.Recordset
    
    Set rs = dbConnection.Execute("SELECT * from tblSYList ORDER BY SYREFNUMBER")
    
    Me.cbSchoolYear.Clear
    
    With rs
        While Not .EOF
            cbSchoolYear.AddItem .Fields("SYTEXT"), .Fields("SYREFNUMBER") - 1
            .MoveNext
        Wend
    End With
    
    cbSchoolYear.ListIndex = 66
    
    Set rs = Nothing
    
    Me.Show
    Command1.Enabled = False
End Sub

Private Sub Command1_Click()
    Unload Me
End Sub

Private Sub listStatus_DblClick()
    MsgBox listStatus.Text, vbInformation + vbOKOnly, ""
End Sub

Sub FastCreateRecord(ByRef sourcefile As String)
    Dim cnsource As ADODB.Connection
    Dim rs_source As ADODB.Recordset
    Dim lrset As Recordset
    Dim reccount As Long
    Dim strClassRootPath As String
    Dim strUserRootPath As String
    Dim strChiRootPath As String
    Dim strUserName As String
    Dim strStudName As String
    Dim qrystring As String
    
    Set lrset = CreateObject("ADODB.RECORDSET")
    Set cnsource = CreateObject("ADODB.CONNECTION")
    
    
   ' On Error Resume Next
    
    cnsource.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & sourcefile
    cnsource.CursorLocation = adUseClient
    cnsource.Mode = adModeRead
    cnsource.Open
    
    qrystring = "select ml.idnum,ml.engname,ml.chiname,cl.engclass,cl.chiclass,count(ml.idnum) " & _
               "from tblmasterlist as ml inner join tblclassifiedlist as cl on ml.studrefnumber=cl.studrefnumber " & _
               "where cl.enrolled and cl.syrefnumber = " & cbSchoolYear.ListIndex + 1 & _
               " group by ml.idnum,ml.engname,ml.chiname,cl.engclass,cl.chiclass " & _
               "order by ml.idnum"
    
    Set rs_source = cnsource.Execute(qrystring)
    
    lrset.Open "tblAccount", dbConnection, adOpenKeyset, adLockOptimistic
    
    reccount = 0
    
    pbStatus.Min = 0
    pbStatus.Max = rs_source.RecordCount
    pbStatus.Value = 0
    listStatus.Clear
    
    While Not rs_source.EOF
        DoEvents

        strUserRootPath = CreateUserPaths(rs_source.Fields("engname"))

        dbConnection.BeginTrans
        
        lrset.AddNew
        lrset.Fields("idnumber") = rs_source.Fields("idnum")
        lrset.Fields("STUDNAME") = rs_source.Fields("engname")
        lrset.Fields("chiname") = rs_source.Fields("chiname")
        lrset.Fields("ENGCLASS") = rs_source.Fields("engclass")
        lrset.Fields("CHNCLASS") = rs_source.Fields("chiclass")
        lrset.Fields("UserName") = rs_source.Fields("idnum")
        lrset.Fields("PASSWORD") = rs_source.Fields("idnum")
        lrset.Fields("firstlog") = True
        lrset.Fields("workfolder") = strUserRootPath
        lrset.Fields("UNCPATH") = CreateUNCPath(rs_source.Fields("idnum"))
        lrset.Update
        
        If Err <> 0 Then
            dbConnection.RollbackTrans
            listStatus.AddItem Err.Number & " - " & Err.Description & " - (" & rowctr & ") ID: " & rs_source.Fields("idnum")
        Else
            dbConnection.CommitTrans
            retval = CreateWorkFolder(strUserRootPath, rs_source.Fields("idnum"), rs_source.Fields("engname"))
            listStatus.AddItem "(" & rowctr & ") " & rs_source.Fields("idnum") & "-" & IIf(retval = 0, "Shared", "Sharing failed") & " " & strUserRootPath
            reccount = reccount + 1
        End If
        
        rs_source.MoveNext
        
        pbStatus.Value = pbStatus + 1
        
    Wend
    
    lrset.Close
    
    listStatus.AddItem reccount & " added"
    
    
    dbConnection.Execute "DELETE FROM tblClassList"
    Set rs_source = cnsource.Execute("SELECT CLASSID,CLASSTEXT FROM TBLCLASSLIST WHERE SYID = " & cbSchoolYear.ListIndex + 1)
    lrset.Open "tblClassList", dbConnection, adOpenKeyset, adLockOptimistic
    
    While Not rs_source.EOF
        lrset.AddNew
        lrset.Fields("CLASSID") = rs_source.Fields("CLASSID")
        lrset.Fields("CLASSNAME") = rs_source.Fields("CLASSTEXT")
        lrset.Update
        rs_source.MoveNext
    Wend
    
    lrset.Close
    
    Set lrset = Nothing
    
    cnsource.Close
    Set cnsource = Nothing
    Set rs_source = Nothing
    
    Command1.Enabled = True
End Sub


