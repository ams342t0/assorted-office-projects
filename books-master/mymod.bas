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
Public fso As Object
Public SrcDBPath As String
Public bSuperSave As Boolean


Sub InitOFN()
   With ofn
      .lStructSize = Len(ofn)
      .hwndOwner = GetActWindow
      .hInstance = 0
      .lpstrFilter = "Books database" & Chr(0) & "BOOKS*.MDB" & Chr(0) & Chr(0)
      .nMaxFile = 255
      .lpstrFile = String(255, 0)
      .Flags = OFN_EXPLORER
   End With
End Sub

Function OpenUp() As Boolean
   Set fso = CreateObject("Scripting.FileSystemObject")
   
      OpenUp = False
      
      InitOFN
      
      If GetOFN(ofn) <> 0 Then
        spath = fso.GetParentFolderName(ofn.lpstrFile)
        SrcDBPath = fso.Buildpath(spath, fso.GetFileName(ofn.lpstrFile))
        OpenUp = True
      End If
End Function


Public Function StrDate(ByVal d As Date) As String
    StrDate = "#" & DateValue(d) & "#"
End Function


Public Function StrTime(ByVal d As Date) As String
    StrTime = "#" & TimeValue(d) & "#"
End Function

Public Function SDate(ByVal d As Date) As String
    SDate = "#" & d & "#"
End Function


Public Function GetBookPrice(ByVal v_id As Long, ByVal v_level As Long) As Double
    Dim ldbRSet As Recordset
        
    On Error Resume Next
    Set ldbRSet = dbConn.Execute("SELECT PRICE FROM tblBooks WHERE ID = " & v_id & " AND LEVEL = " & v_level)
    
    GetBookPrice = ldbRSet.Fields("PRICE")
    
    Set ldbRSet = Nothing
End Function

Public Function GetBookName(ByVal v_id As Long, ByVal v_level As Long) As String
    Dim ldbRSet As Recordset
        
    On Error Resume Next
    Set ldbRSet = dbConn.Execute("SELECT BOOK_TITLE FROM tblBooks WHERE ID = " & v_id & " AND LEVEL = " & v_level)
    
    GetBookName = ldbRSet.Fields("BOOK_TITLE")
    
    Set ldbRSet = Nothing
End Function


Public Function GetAmountDue(ByVal v_id As Long, ByVal v_lvl) As Double
    Dim ldbRSet As Recordset
    Dim retval As Double
        
    On Error Resume Next
    
    'Set ldbRSet = dbConn.Execute("SELECT ID from tblBooksSold WHERE STUDID = " & v_id)
    Set ldbRSet = dbConn.Execute("SELECT tblBooks.price FROM (tblBooksSold INNER JOIN tblBooks ON tblBooksSold.ID = tblBooks.ID and tblBooksSold.Level = tblBooks.Level) WHERE STUDID =" & v_id)
    
    retval = 0
    
    While Not ldbRSet.EOF
        'retval = retval + GetBookPrice(ldbRSet.Fields("ID"), v_lvl)
        retval = retval + ldbRSet.Fields("PRICE")
        
        ldbRSet.MoveNext
    Wend

    GetAmountDue = retval
    
    Set ldbRSet = Nothing
End Function


