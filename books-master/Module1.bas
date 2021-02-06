Attribute VB_Name = "Module1"
Public dbConn As ADODB.Connection
Public bPosted As Boolean
Public lCurrentID As Long

Public dGrandTotal As Double
Public bConnected As Boolean
Public bEditMode As Boolean
Public bIDDeleted As Boolean
Public bChangeDate As Boolean

Public xlApp   As Object
Public xlSheet As Object
Public xlBook  As Object
Public sReceipt As String
Public isprint As Boolean

Type tStudent
    id As Long
    name As String
    level As Long
    section As String
End Type

Type tBookInfo
    sTitle As String
    dPrice As Double
End Type

Type tSectionStruct
    lID As Long
    strString As String
End Type

Type tLevelStruct
    lID As Long
    strString As String
End Type

Public tSections() As tSectionStruct
Public tLevels() As tLevelStruct

Public tStudPost As tStudent


Public Sub InitXLApp()
    Set xlApp = CreateObject("EXCEL.APPLICATION")
    
    Set xlBook = xlApp.Workbooks.Add
    
    xlApp.DisplayAlerts = False
    xlApp.Windows(1).WindowState = &HFFFFEFD4
        
    xlBook.Sheets(3).Delete
    xlBook.Sheets(2).Delete
    
    Set xlSheet = xlBook.Sheets(1)
    
    xlSheet.Columns("A:A").ColumnWidth = 30
    xlSheet.Columns("B:B").ColumnWidth = 15
    
    xlBook.saved = True
End Sub

Public Sub CloseXLApp()
    xlApp.Quit
    
    Set xlSheet = Nothing
    Set xlBook = Nothing
    Set xlApp = Nothing
End Sub

Public Function CountBooksSold(ByVal bookID As Long, ByVal lvlID As Long) As Long
    Dim ldbRSet As Recordset
    
    Set ldbRSet = dbConn.Execute("SELECT COUNT(ID) as BookCount FROM tblBooksSold WHERE ID = " & bookID & " AND PAID AND LEVEL=" & lvlID)
    
    CountBooksSold = ldbRSet.Fields("BookCount")
    
    Set ldbRSet = Nothing
End Function


Public Function GetLastBookID() As Long
    Dim ldbRSet As Recordset
        
    Set ldbRSet = dbConn.Execute("SELECT ID FROM tblBooks WHERE LEVEL = " & cbLevel.ListIndex & " ORDER BY ID DESC")
    
    If ldbRSet.RecordCount = 0 Then
        GetLastBookID = 0
    Else
        GetLastBookID = ldbRSet.Fields("ID") + 1
    End If
    
    Set ldbRSet = Nothing
        
End Function


Function GetLastStudID() As Long
    Dim ldbRSet As Recordset
        
    Set ldbRSet = dbConn.Execute("SELECT STUDID FROM tblStudentList ORDER BY STUDID DESC")
    
    On Error Resume Next
    
    Set ldbRSet = CreateObject("ADODB.RECORDSET")
    
    ldbRSet.Open "SELECT STUDID FROM tblStudentList ORDER BY STUDID DESC", dbConn, adOpenStatic, adLockOptimistic
    
    ldbRSet.Update
    
    If ldbRSet.RecordCount = 0 Then
        GetLastStudID = 1
    Else
        GetLastStudID = ldbRSet.Fields("STUDID") + 1
    End If
    
    ldbRSet.Close
    Set ldbRSet = Nothing
End Function


Function GetSectionString(ByVal lSectionID As Long) As String
    Dim ldbRSet As Recordset
        
    On Error Resume Next
    Set ldbRSet = dbConn.Execute("SELECT SECTIONSTRING FROM tblSectionList WHERE SECTIONID = " & lSectionID)
    
    GetSectionString = ldbRSet.Fields("SECTIONSTRING")
    
    Set ldbRSet = Nothing
End Function


Function GetSectionID(ByRef lSectionString As String) As String
    Dim ldbRSet As Recordset
            
    On Error Resume Next
    Set ldbRSet = dbConn.Execute("SELECT SECTIONID FROM tblSectionList WHERE SECTIONSTRING = """ & lSectionString & """")
    
    GetSectionID = ldbRSet.Fields("SECTIONID")
    
    Set ldbRSet = Nothing
End Function

Public Sub GetLevelSectionData()
    Dim ldbRSet As Recordset
    Dim lRecCount As Long
    Dim lIndex As Long
    
    Set ldbRSet = dbConn.Execute("SELECT * FROM tblLevelList")
    
    lRecCount = ldbRSet.RecordCount
    
    ReDim tLevels(lRecCount)
    
    lIndex = 1
    While Not ldbRSet.EOF
        tLevels(lIndex).lID = ldbRSet.Fields("LEVELID")
        tLevels(lIndex).strString = ldbRSet.Fields("LEVELSTRING")
        lIndex = lIndex + 1
        ldbRSet.MoveNext
    Wend
    
    
    Set ldbRSet = dbConn.Execute("SELECT * FROM tblSectionList")
    
    lRecCount = ldbRSet.RecordCount
    
    ReDim tSections(lRecCount)
    
    lIndex = 1
    While Not ldbRSet.EOF
        tSections(lIndex).lID = ldbRSet.Fields("SECTIONID")
        tSections(lIndex).strString = ldbRSet.Fields("SECTIONSTRING")
        lIndex = lIndex + 1
        ldbRSet.MoveNext
    Wend
    
    
    Set ldbRSet = Nothing
End Sub

Function GetLevelString(ByVal lLevelID As Long) As String
    Dim ldbRSet As Recordset
        
    GetLevelString = ""
    
    On Error Resume Next
    
    Set ldbRSet = dbConn.Execute("SELECT LEVELSTRING FROM tblLevelList WHERE LEVELID = " & lLevelID)
    
    GetLevelString = ldbRSet.Fields("LEVELSTRING")
    
    Set ldbRSet = Nothing
End Function


Function GetLevelID(ByRef lLevelString As String) As Long
    Dim ldbRSet As Recordset
        
    On Error Resume Next
    Set ldbRSet = dbConn.Execute("SELECT LEVELID FROM tblLevelList WHERE LEVELSTRING = """ & lLevelString & """")
    
    GetLevelID = ldbRSet.Fields("LEVELID")
    
    Set ldbRSet = Nothing
End Function

Sub ClearBooksRecorded(ByVal lStudId As Long)
    
    dbConn.Execute "DELETE from tblBooksSold WHERE STUDID = " & lStudId

End Sub

