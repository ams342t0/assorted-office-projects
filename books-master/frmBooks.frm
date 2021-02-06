VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "mscomctl.ocx"
Begin VB.Form frmBooks 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "BOOK ENTRIES"
   ClientHeight    =   5520
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   6675
   BeginProperty Font 
      Name            =   "Arial Narrow"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5520
   ScaleWidth      =   6675
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
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
      Height          =   555
      Left            =   4455
      TabIndex        =   6
      Top             =   720
      Width           =   1320
   End
   Begin VB.CommandButton cmdRemove 
      Caption         =   "&REMOVE"
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
      Left            =   4455
      TabIndex        =   7
      Top             =   1350
      Width           =   1320
   End
   Begin VB.CommandButton cmdAdd 
      Caption         =   "&ADD"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   510
      Left            =   4455
      TabIndex        =   5
      Top             =   135
      Width           =   1320
   End
   Begin VB.Frame Frame2 
      Caption         =   "Books"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3480
      Left            =   45
      TabIndex        =   9
      Top             =   2025
      Width           =   6585
      Begin MSComctlLib.ListView lvBooks 
         Height          =   3165
         Left            =   90
         TabIndex        =   8
         Top             =   225
         Width           =   6405
         _ExtentX        =   11298
         _ExtentY        =   5583
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
   End
   Begin VB.Frame Frame1 
      Caption         =   "Book Info"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1905
      Left            =   45
      TabIndex        =   0
      Top             =   45
      Width           =   3840
      Begin VB.TextBox txtQuantity 
         Alignment       =   1  'Right Justify
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Left            =   810
         TabIndex        =   4
         Top             =   1350
         Width           =   1410
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
         Left            =   810
         TabIndex        =   1
         Top             =   225
         Width           =   1950
      End
      Begin VB.TextBox txtPrice 
         Alignment       =   1  'Right Justify
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Left            =   810
         TabIndex        =   3
         Top             =   945
         Width           =   1410
      End
      Begin VB.TextBox txtTitle 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   330
         Left            =   810
         TabIndex        =   2
         Top             =   585
         Width           =   2760
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
         Left            =   360
         TabIndex        =   13
         Top             =   315
         Width           =   465
      End
      Begin VB.Label Label5 
         Caption         =   "Quantity"
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
         TabIndex        =   12
         Top             =   1395
         Width           =   600
      End
      Begin VB.Label Label4 
         Caption         =   "Price"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   360
         TabIndex        =   11
         Top             =   990
         Width           =   465
      End
      Begin VB.Label Label1 
         Caption         =   "Title"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   450
         TabIndex        =   10
         Top             =   630
         Width           =   375
      End
   End
End
Attribute VB_Name = "frmBooks"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim dbRSet As Object
Dim bItemSelect As Boolean
Dim bDirty As Boolean

Sub UpdateButtons()
    Dim v As Boolean
    
    v = (Len(cbLevel.Text) > 0 And Len(txtTitle.Text) > 0 And Len(txtPrice.Text) > 0 And Len(txtQuantity.Text) > 0)
    cmdAdd.Enabled = v
    cmdSave.Enabled = v And bItemSelect And bDirty
    cmdRemove.Enabled = v And bItemSelect

End Sub

Sub LoadLevelList()
    Dim dbRSet As ADODB.Recordset
    
    Set dbRSet = dbConn.Execute("SELECT * FROM tblLevelList")
    
    cbLevel.Clear
    
    While Not dbRSet.EOF
        cbLevel.AddItem dbRSet.Fields("LEVELSTRING"), dbRSet.Fields("LEVELID")
        dbRSet.MoveNext
    Wend
    
    Set dbRSet = Nothing
    
End Sub

Sub InitBookList()
    lvBooks.View = lvwReport
    lvBooks.FullRowSelect = True
    lvBooks.GridLines = True
    lvBooks.LabelEdit = lvwManual
    lvBooks.HideSelection = False
    lvBooks.ColumnHeaders.Add 1, , "TITLE", 3000
    lvBooks.ColumnHeaders.Add 2, , "PRICE", 800
    lvBooks.ColumnHeaders.Add 3, , "COUNT", 800
    lvBooks.ColumnHeaders.Add 4, , "SOLD", 800
End Sub

Private Sub cbLevel_Change()
    UpdateButtons
    bDirty = True
End Sub

Sub ClearFields()
    txtTitle = ""
    txtPrice = ""
    txtQuantity = ""
End Sub

Private Sub cbLevel_Click()
    UpdateButtons
    ListBooks
    ClearFields
    bItemSelect = False
End Sub

Private Sub cmdAdd_Click()
    AddBook
    ListBooks
    MsgBox "Book added", vbOKOnly + vbApplicationModal, "BOOK ADD"
    bDirty = False
    ClearFields
    UpdateButtons
End Sub

Private Sub cmdRemove_Click()
    If MsgBox("Delete this book entry?", vbYesNo + vbExclamation + vbApplicationModal, "DELETE BOOK") = vbYes Then
        RemoveBook
        ListBooks
        MsgBox "Book Removed", vbOKOnly + vbApplicationModal, "BOOK DELETE"
        ClearFields
        UpdateButtons
    End If
End Sub

Private Sub cmdSave_Click()
    If MsgBox("Save changes?", vbYesNo + vbExclamation + vbApplicationModal, "SAVE BOOK") = vbYes Then
        SaveBook
        ListBooks
        MsgBox "Saved", vbOKOnly + vbApplicationModal, "BOOK SAVE"
        bDirty = False
        UpdateButtons
    End If
End Sub

Private Sub Form_Load()
    LoadLevelList
    InitBookList
    
    cmdAdd.Enabled = False
    cmdSave.Enabled = False
    cmdRemove.Enabled = False
    bItemSelect = False
    bDirty = False
End Sub

Private Sub lvBooks_ItemClick(ByVal Item As MSComctlLib.ListItem)
    cmdSave.Enabled = True
    cmdRemove.Enabled = True
    
    txtTitle.Text = Item.Text
    txtPrice.Text = Item.SubItems(1)
    txtQuantity.Text = Item.SubItems(2)
    bItemSelect = True
    bDirty = False
    UpdateButtons
End Sub

Private Sub txtPrice_Change()
    UpdateButtons
    bDirty = True
End Sub

Private Sub txtQuantity_Change()
    UpdateButtons
    bDirty = True
End Sub

Private Sub txtTitle_Change()
    UpdateButtons
    bDirty = True
End Sub


Sub AddBook()
        
    dbConn.Execute "INSERT INTO tblBooks VALUES (" & _
                    GetLastBookID & ",""" & txtTitle.Text & """," & _
                    cbLevel.ListIndex & "," & Val(txtPrice.Text) & "," & Val(txtQuantity.Text) & ")"
                    
End Sub

Sub SaveBook()
    dbConn.Execute "UPDATE tblBooks SET " & _
                   "BOOK_TITLE = """ & txtTitle & """," & _
                   "PRICE = " & Val(txtPrice) & "," & _
                   "QUANTITY = " & Val(txtQuantity) & " WHERE ID = " & Val(lvBooks.SelectedItem.Tag) & " and LEVEL = " & cbLevel.ListIndex
                                            
End Sub

Sub RemoveBook()
    dbConn.Execute "DELETE FROM tblBooks WHERE ID = " & Val(lvBooks.SelectedItem.Tag) & " AND LEVEL = " & cbLevel.ListIndex
End Sub

Function GetLastBookID() As Long
        
    Set dbRSet = dbConn.Execute("SELECT ID FROM tblBooks WHERE LEVEL = " & cbLevel.ListIndex & " ORDER BY ID DESC")
    
    If dbRSet.RecordCount = 0 Then
        GetLastBookID = 0
    Else
        GetLastBookID = dbRSet.Fields("ID") + 1
    End If
    
    Set dbRSet = Nothing
        
End Function

Sub ListBooks()
    Dim idx As Long
    
    Set dbRSet = dbConn.Execute("SELECT * FROM tblBooks WHERE LEVEL = " & cbLevel.ListIndex & " ORDER BY ID")
    
    lvBooks.ListItems.Clear
    
    idx = 1
    If dbRSet.RecordCount > 0 Then
        While Not dbRSet.EOF
            lvBooks.ListItems.Add idx, , dbRSet.Fields("BOOK_TITLE")
            lvBooks.ListItems(idx).SubItems(1) = Format$(dbRSet.Fields("PRICE"), "0.00")
            lvBooks.ListItems(idx).SubItems(2) = dbRSet.Fields("QUANTITY")
            lvBooks.ListItems(idx).SubItems(3) = CountBooksSold(dbRSet.Fields("ID"), cbLevel.ListIndex)
            lvBooks.ListItems(idx).Tag = dbRSet.Fields("ID")
            idx = idx + 1
            dbRSet.MoveNext
        Wend
    End If
    
    Set dbRSet = Nothing
End Sub

