VERSION 5.00
Begin VB.Form frmPrintsetup 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Print Setup"
   ClientHeight    =   1365
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   3315
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1365
   ScaleWidth      =   3315
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdClosePrint 
      Caption         =   "&OK"
      Height          =   510
      Left            =   120
      TabIndex        =   2
      Top             =   735
      Width           =   3060
   End
   Begin VB.ComboBox cbPrinter 
      Height          =   315
      Left            =   105
      TabIndex        =   0
      Text            =   "Combo1"
      Top             =   300
      Width           =   3120
   End
   Begin VB.Label Label1 
      Caption         =   "Printer name"
      Height          =   285
      Left            =   120
      TabIndex        =   1
      Top             =   75
      Width           =   1455
   End
End
Attribute VB_Name = "frmPrintsetup"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub cbPrinter_Click()
    sReceipt = cbPrinter.Text
    SaveSetting "VBBOOKS", "SETTING", "TARGETPRINTER", cbPrinter.ListIndex
End Sub

Private Sub LoadPrinters()
    Dim pvrset As ADODB.Recordset
    Dim pcount As Long
    Dim i As Long
    
    cbPrinter.Clear
    
    pcount = Printers.Count - 1
    
    cbPrinter.AddItem "LPT1"
    
    For i = 0 To pcount
        cbPrinter.AddItem Printers(i).DeviceName
    Next
    
    cbPrinter.ListIndex = CLng(GetSetting("VBBOOKS", "SETTING", "TARGETPRINTER", 0))
    
    Set pvrset = Nothing
End Sub


Private Sub cmdClosePrint_Click()
    isprint = True
    Unload Me
End Sub

Private Sub Form_Load()
    LoadPrinters
    isprint = False
End Sub
