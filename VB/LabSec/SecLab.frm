VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Begin VB.Form LabSec 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "LabSecure 1.0"
   ClientHeight    =   4215
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   5085
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4215
   ScaleWidth      =   5085
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'CenterScreen
   Begin TabDlg.SSTab MainTab 
      Height          =   3315
      Left            =   60
      TabIndex        =   3
      Top             =   840
      Width           =   4995
      _ExtentX        =   8811
      _ExtentY        =   5847
      _Version        =   393216
      TabHeight       =   520
      TabCaption(0)   =   "&Security"
      TabPicture(0)   =   "SecLab.frx":0000
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "lvTweakList"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).ControlCount=   1
      TabCaption(1)   =   "&Restricted"
      TabPicture(1)   =   "SecLab.frx":001C
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "chkRestrict"
      Tab(1).Control(1)=   "cmdDelete"
      Tab(1).Control(2)=   "cmdAdd"
      Tab(1).Control(3)=   "lvRestrictList"
      Tab(1).ControlCount=   4
      TabCaption(2)   =   "Hide &Drives"
      TabPicture(2)   =   "SecLab.frx":0038
      Tab(2).ControlEnabled=   0   'False
      Tab(2).Control(0)=   "lvDriveList"
      Tab(2).ControlCount=   1
      Begin VB.CheckBox chkRestrict 
         Caption         =   "R&estrict Programs"
         Height          =   255
         Left            =   -74760
         TabIndex        =   9
         Top             =   420
         Width           =   1815
      End
      Begin MSComctlLib.ListView lvDriveList 
         Height          =   2475
         Left            =   -74820
         TabIndex        =   8
         Top             =   600
         Width           =   4635
         _ExtentX        =   8176
         _ExtentY        =   4366
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   -1  'True
         Checkboxes      =   -1  'True
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         HotTracking     =   -1  'True
         _Version        =   393217
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   2
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Object.Width           =   882
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   1
            Object.Width           =   7056
         EndProperty
      End
      Begin VB.CommandButton cmdDelete 
         Caption         =   "DE&LETE"
         Height          =   375
         Left            =   -73680
         TabIndex        =   7
         Top             =   2820
         Width           =   975
      End
      Begin VB.CommandButton cmdAdd 
         Caption         =   "&ADD"
         Height          =   375
         Left            =   -74820
         TabIndex        =   6
         Top             =   2820
         Width           =   1035
      End
      Begin MSComctlLib.ListView lvRestrictList 
         Height          =   2055
         Left            =   -74820
         TabIndex        =   5
         Top             =   720
         Width           =   4635
         _ExtentX        =   8176
         _ExtentY        =   3625
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         HotTracking     =   -1  'True
         _Version        =   393217
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   1
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Object.Width           =   7937
         EndProperty
      End
      Begin MSComctlLib.ListView lvTweakList 
         Height          =   2775
         Left            =   120
         TabIndex        =   4
         Top             =   420
         Width           =   4755
         _ExtentX        =   8387
         _ExtentY        =   4895
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   0   'False
         HideColumnHeaders=   -1  'True
         Checkboxes      =   -1  'True
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         HotTracking     =   -1  'True
         _Version        =   393217
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   2
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Object.Width           =   882
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   1
            Object.Width           =   7056
         EndProperty
      End
   End
   Begin VB.Frame Frame1 
      Height          =   615
      Left            =   60
      TabIndex        =   0
      Top             =   60
      Width           =   4995
      Begin VB.CommandButton cmdPassword 
         Caption         =   "&PASSWORD"
         Height          =   375
         Left            =   3840
         TabIndex        =   2
         Top             =   180
         Width           =   1095
      End
      Begin VB.CommandButton cmdApply 
         Caption         =   "&APPLY"
         Height          =   375
         Left            =   60
         TabIndex        =   1
         Top             =   180
         Width           =   1035
      End
   End
End
Attribute VB_Name = "LabSec"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim li As ListItem
Dim wsh As IWshShell
Dim fso As FileSystemObject


Sub InitRegPaths()

  ReDim regpaths(lvTweakList.ListItems.Count)

  regpaths(1) = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoRun"
  regpaths(2) = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoTrayContextMenu"
  regpaths(3) = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoControlPanel"
  regpaths(4) = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Network\NoNetSetup"
  regpaths(5) = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System\NoDevMgrPage"
  regpaths(6) = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Network\NoNetSetupIDPage"
  regpaths(7) = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoNetHood"
  regpaths(8) = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Network\NoEntireNetwork"
  regpaths(9) = "HKLM\Software\Microsoft\Windows\CurrentVersion\Policies\Network\NoFileSharing"
  regpaths(10) = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoNetConnectDisconnect"
  regpaths(11) = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoComputersNearMe"
  regpaths(12) = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Network\NoWorkgroupContents"
  rpHideDrives = "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\NoDrives"
End Sub


'*************************************************
'SECURITY TWEAKS SECTION
'*************************************************

Sub InitTweakList()
    With lvTweakList
        Set li = .ListItems.Add
        li.SubItems(1) = "No Run"
        
        Set li = .ListItems.Add
        li.SubItems(1) = "No Taskbar Context Menu"
        
        Set li = .ListItems.Add
        li.SubItems(1) = "No Control Panel"
        
        Set li = .ListItems.Add
        li.SubItems(1) = "No Network Properties"
        
        Set li = .ListItems.Add
        li.SubItems(1) = "No Device Manager"
        
        Set li = .ListItems.Add
        li.SubItems(1) = "No Setup ID Page"
        
        Set li = .ListItems.Add
        li.SubItems(1) = "No Network Neighborhood"
        
        Set li = .ListItems.Add
        li.SubItems(1) = "No Entire Network"
        
        Set li = .ListItems.Add
        li.SubItems(1) = "No File Sharing"
        
        Set li = .ListItems.Add
        li.SubItems(1) = "No Drive Mapping"
        
        Set li = .ListItems.Add
        li.SubItems(1) = "No Computers Near Me"
    
        Set li = .ListItems.Add
        li.SubItems(1) = "No Workgroup Contents"
    End With
    
    Set li = Nothing
    
    InitRegPaths
End Sub


Sub ReadCurrentTweakSettings()
    Dim v As Long
    
    On Error Resume Next
    
    For Each li In lvTweakList.ListItems
        li.Checked = False
        
        v = 0
        v = wsh.RegRead(regpaths(li.Index))
        
        If v <> 0 Then
            li.Checked = True
        End If
    Next
End Sub


Sub SaveCurrentTweakSettings()
    Dim v As Long
    
    On Error Resume Next
    
    For Each li In lvTweakList.ListItems
        If li.Checked Then
            wsh.RegWrite regpaths(li.Index), 1, "REG_DWORD"
        Else
            wsh.RegDelete regpaths(li.Index)
        End If
    Next

End Sub


Private Sub cmdPassword_Click()
    Form1.Show vbModal, Me
End Sub


Private Sub lvTweakList_ItemCheck(ByVal Item As MSComctlLib.ListItem)
    cmdApply.Enabled = True
End Sub



'*************************************************
'HIDDEN DRIVES SECTION
'*************************************************

Sub ReadHideDriveSettings()
    Dim v As Long
    
    v = 0
    
    On Error Resume Next
    
    v = wsh.RegRead(rpHideDrives)
            
    For Each li In lvDriveList.ListItems
        
        If v = 0 Then
            li.Checked = False
        End If
        
        If (v And GetDriveLetterValue(li.Tag)) <> 0 Then
            li.Checked = True
        Else
            li.Checked = False
        End If
        
    Next
            
End Sub


Sub SaveHideDriveSettings()
    Dim p As Long
    
    p = 0
    
    For Each li In lvDriveList.ListItems
        If li.Checked Then
            p = p + GetDriveLetterValue(li.Tag)
        End If
    Next
    
    wsh.RegWrite rpHideDrives, p, "REG_DWORD"
    
End Sub


Sub EnumDrives()
    Dim c_drive As Drive
    
    lvDriveList.ListItems.Clear
    
    On Error Resume Next
    
    For Each c_drive In fso.Drives
         
         Set li = lvDriveList.ListItems.Add
         
         If c_drive.IsReady Then
            li.SubItems(1) = "(" & c_drive.driveletter & ":) " & c_drive.VolumeName
         Else
            li.SubItems(1) = "(" & c_drive.driveletter & ":) " & DriveTypeString(c_drive.DriveType)
         End If
         
         li.Tag = c_drive.driveletter

    Next
    
    Set li = Nothing
    
    ReadHideDriveSettings
End Sub



'*************************************************
'RESTRICTED PROGRAMS SECTION
'*************************************************

Private Sub chkRestrict_Click()
    cmdApply.Enabled = True
End Sub


Private Sub lvDriveList_ItemCheck(ByVal Item As MSComctlLib.ListItem)
    cmdApply.Enabled = True
End Sub


'*****************************************************
'MAIN SECTION
'*****************************************************

Private Sub MainTab_Click(PreviousTab As Integer)
    cmdApply.Enabled = False
    
    Select Case MainTab.Tab
        Case 0
           ReadCurrentTweakSettings
           
        Case 2
           EnumDrives
    End Select
End Sub


Private Sub cmdApply_Click()
    Select Case MainTab.Tab
        Case 0
            SaveCurrentTweakSettings
            
        Case 2
            SaveHideDriveSettings
            
    End Select
    
    cmdApply.Enabled = False
End Sub


Private Sub Form_load()
    If HasPassword Then
        Form2.Show vbModal, Me
        
        If StrComp(strPassword, strUserPassword, vbBinaryCompare) <> 0 Then
            MsgBox "Invalid Password!", vbExclamation + vbApplicationModal + vbOKOnly, "LabSec"
            Unload Me
            Exit Sub
        End If
    End If

    Set fso = CreateObject("Scripting.FileSystemObject")
    Set wsh = CreateObject("WScript.Shell")
    
    InitTweakList
    cmdApply.Enabled = False
End Sub

