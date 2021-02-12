VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmIDManager 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "ID NUMBER MANAGER"
   ClientHeight    =   5460
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4005
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5460
   ScaleWidth      =   4005
   StartUpPosition =   1  'CenterOwner
   Begin VB.CommandButton cmdClose 
      Caption         =   "&CLOSE"
      Height          =   465
      Left            =   2700
      TabIndex        =   3
      Top             =   4950
      Width           =   1230
   End
   Begin VB.CommandButton cmdRemove 
      Caption         =   "R&EMOVE"
      Height          =   465
      Left            =   1350
      TabIndex        =   2
      Top             =   4950
      Width           =   1230
   End
   Begin VB.CommandButton cmdADd 
      Caption         =   "&ADD"
      Height          =   465
      Left            =   45
      TabIndex        =   1
      Top             =   4950
      Width           =   1230
   End
   Begin MSComctlLib.ListView lvIDList 
      Height          =   4830
      Left            =   45
      TabIndex        =   0
      Top             =   45
      Width           =   3885
      _ExtentX        =   6853
      _ExtentY        =   8520
      View            =   3
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   0   'False
      Checkboxes      =   -1  'True
      FullRowSelect   =   -1  'True
      GridLines       =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   3
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Text            =   "ACTIVE"
         Object.Width           =   882
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   1
         Text            =   "ID NUMBER"
         Object.Width           =   3528
      EndProperty
      BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   2
         Object.Width           =   2540
      EndProperty
   End
End
Attribute VB_Name = "frmIDManager"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdADd_Click()
    Dim tempstr As String
    
    tempstr = InputBox("TYPE ID NUMBER", "ADD NEW ID NUMBER")
    
    On Error Resume Next
    
    dbConnection.Execute "INSERT INTO TBLVALIDID VALUES(""" & tempstr & ""","""",FALSE)"
    
    If Err <> 0 Then
        MsgBox "Error saving new ID number.", vbExclamation + vbApplicationModal + vbOKOnly, "ERROR ADDING ID NUMBER"
    Else
        LoadList
    End If
    
End Sub

Private Sub cmdClose_Click()
    Unload Me
End Sub

Private Sub cmdRemove_Click()
    dbConnection.Execute "DELETE FROM tblVAlidID WHERE IDNUMBER = """ & lvIDList.SelectedItem.SubItems(1) & """"
    LoadList
End Sub

Private Sub Form_Load()
    LoadList
End Sub


Sub LoadList()
    Dim lrset As Recordset
    Dim li As ListItem
    
    Set lrset = dbConnection.Execute("SELECT * FROM tblValidID ORDER BY IDNUMBER")
    
    lvIDList.ListItems.Clear
    
    With lrset
        While Not .EOF
            Set li = lvIDList.ListItems.Add
            li.SubItems(1) = lrset.Fields("IDNUMBER")
            li.Checked = lrset.Fields("ACTIVE")
            .MoveNext
        Wend
    End With
    
    If lvIDList.ListItems.Count = 0 Then
        cmdRemove.Enabled = False
    End If
    
    Set li = Nothing
    Set lrset = Nothing
    
End Sub


Private Sub lvIDList_ItemCheck(ByVal Item As MSComctlLib.ListItem)
    dbConnection.Execute "UPDATE TBLVALIDID SET ACTIVE=" & Item.Checked
End Sub

Private Sub lvIDList_ItemClick(ByVal Item As MSComctlLib.ListItem)
    cmdRemove.Enabled = True
End Sub
