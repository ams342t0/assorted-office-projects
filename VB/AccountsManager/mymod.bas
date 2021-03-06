Attribute VB_Name = "mymod"
Type OPENFILENAME
    lStructSize As Long
    hwndOwner As Long
    hInstance As Long
    lpstrFilter As String
    lpstrCustomFilter As String
    nMaxCustFilter As Long
    nFilterIndex As Long
    lpstrFile As String
    nMaxFile As Long
    lpstrFileTitle As String
    nMaxFileTitle As Long
    lpstrInitialDir As String
    lpstrTitle As String
    Flags As Long
    nFileOffset As Integer
    nFileExtension As Integer
    lpstrDefExt As String
    lCustData As Long
    lpfnHook As Long
    lpTemplateName As String
End Type

Const OFN_EXPLORER = &H80000

Public Declare Function GetOFN Lib "comdlg32" Alias "GetOpenFileNameA" (ByRef ofn As OPENFILENAME) As Long
Public Declare Function GetActWindow Lib "user32" Alias "GetActiveWindow" () As Long

Public ofn As OPENFILENAME
Public fso As FileSystemObject
Public SrcDBPath As String
Public bSuperSave As Boolean


Sub InitOFN()
   With ofn
      .lStructSize = Len(ofn)
      .hwndOwner = GetActWindow
      .hInstance = 0
      .lpstrFilter = "Source List" & Chr(0) & "MasterList.mdb" & Chr(0) & Chr(0)
      .nMaxFile = 255
      .lpstrFile = String(255, 0)
      .Flags = OFN_EXPLORER
   End With
End Sub

Function OpenUp() As Boolean
   Dim spath As String

   Set fso = CreateObject("Scripting.FileSystemObject")
   
      OpenUp = False
      
      InitOFN
      
      If GetOFN(ofn) <> 0 Then
        spath = fso.GetParentFolderName(ofn.lpstrFile)
        SrcDBPath = fso.BuildPath(spath, fso.GetFileName(ofn.lpstrFile))
        OpenUp = True
      End If
End Function


Public Function StrDate(ByVal d As Date) As String
    StrDate = "#" & d & "#"
End Function

Public Function NotBlank(ByRef s As String) As Boolean
    NotBlank = True
    
    If Len(Trim(s)) = 0 Then
        NotBlank = False
    End If
End Function

