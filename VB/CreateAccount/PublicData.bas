Attribute VB_Name = "Module1"
Public IsNewRecord As Boolean
Public dbConnection As ADODB.Connection
Public strAppPath As String
Public strDBPath As String
Public strCurrentID As String

Public Function GetClassString(ByVal i As Long) As String
    Dim lrset As Recordset
    
    Set lrset = dbConnection.Execute("SELECT CLASSNAME FROM tblClassList WHERE classid = " & i)
    
    GetClassString = lrset.Fields("classname")
    
    Set lrset = Nothing
End Function


Public Function CreateUNCPath(ByRef strUserName As String) As String
    
    CreateUNCPath = "\\u47\" & strUserName
    
End Function


Public Function FullName(ByRef fname As String, ByRef mname As String, ByRef lname As String) As String
    FullName = lname & ", " & fname & " " & RTrim(Trim(mname))
End Function


Public Sub CreateUserPaths(ByRef strStudName As String, ByRef strUserName As String, ByRef clsname As String, ByVal haschinese As Boolean, _
                    ByRef classroot As String, _
                    ByRef userroot As String, _
                    ByRef chipath As String)
    
    classroot = strRootFolder & "\" & clsname
    userroot = classroot & "\" & strStudName
       
    chipath = ""
    
    If haschinese Then
        chipath = userroot & "\" & strStudName & " (Chinese Lab)"
    End If
    
End Sub


Public Sub InitDBConnection()
    Dim connstr As String
    
    On Error Resume Next
    
    Set dbConnection = CreateObject("ADODB.CONNECTION")
    
    ReadDataBaseSource
    
    connstr = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
              "User ID=Admin;" & _
              "Data Source=" & strDBPath & ";" & _
              "Jet OLEDB:Database Password=""klatuberataniktu"";"
    
    dbConnection.Mode = adModeReadWrite + adModeShareDenyNone
    dbConnection.CursorLocation = adUseClient
    dbConnection.ConnectionString = connstr
    dbConnection.Open
    
    If Err <> 0 Then
        MsgBox "Server not available." & vbCrLf & Err.Description, vbCritical + vbApplicationModal + vbOKOnly, "LOGIN ERROR"
        End
    End If
    
End Sub


Public Sub ReadDataBaseSource()
    Dim i As Integer
    
    i = FreeFile
    
    Open App.Path & "\databasepath.txt" For Input As i
    
    Input #i, strDBPath
    
    Close i
End Sub

