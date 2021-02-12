Attribute VB_Name = "Module1"
Public dbConnection As ADODB.Connection
Public strAppPath As String
Public strSelectedFolder As String
Public IsNewRecord As Boolean
Public strUserPassword As String
Public strCurrentID As String
Public bChanged As Boolean
Public strRootFolder As String
Public bEnableLogging As Boolean
Public wshnet As Object
Public tclass() As ClassType

Type ClassType
    classid As Long
    classindex As Long
End Type

Public Sub GetRootFolder()
    strRootFolder = GetSetting("LISTMANAGER", "SETTINGS", "ROOTFOLDER", App.Path)
End Sub


Public Sub SaveRootFolder()
    SaveSetting "LISTMANAGER", "SETTINGS", "ROOTFOLDER", strRootFolder
End Sub

Public Function GetClassString(ByVal i As Long) As String
    Dim lrset As Recordset
    
    Set lrset = dbConnection.Execute("SELECT CLASSNAME FROM tblClassList WHERE classid = " & i)
    
    GetClassString = lrset.Fields("classname")
    
    Set lrset = Nothing
End Function

Public Function CreateUNCPath(ByRef strUserName As String) As String
    CreateUNCPath = "\\" & wshnet.ComputerName & "\" & strUserName & "$"
End Function

Public Function CreateUserPaths(ByRef strStudName As String) As String
    CreateUserPaths = strRootFolder & "\" & filterstring(strStudName)
End Function

Public Function CreateWorkFolder(ByRef usrroot As String, ByRef sharename As String, ByRef studname As String) As Long
    Dim wsh As Object
    Set wsh = CreateObject("Wscript.shell")
    
    If Not fso.FolderExists(usrroot) Then
        fso.CreateFolder usrroot
    End If
    
    CreateWorkFolder = wsh.Run("net share " & sharename & "$=""" & usrroot & """ /users:2 /remark:""" & studname & """", 0, 1)
    
    Set wsh = Nothing
End Function

Public Function filterstring(ByRef s As String) As String
    Dim i As Long
    Dim n As Long
    Dim o As String
    
    n = Len(s)
    
    o = ""
    For i = 1 To n
        Select Case Mid$(s, i, 1)
            Case ","
                o = o & Mid$(s, i, 1)
                
            Case "a" To "z"
                o = o & Mid$(s, i, 1)
                
            Case "A" To "Z"
                o = o & Mid$(s, i, 1)
                
            Case "0" To "9"
                o = o & Mid$(s, i, 1)
                
        End Select
    Next
    
    filterstring = o
    
End Function

