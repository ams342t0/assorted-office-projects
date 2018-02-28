Attribute VB_Name = "Module1"
Public strPassword As String
Public strUserPassword As String
Public rpHideDrives As String
Public regpaths() As String


Public Function PowOf2(ByVal v As Long) As Long
    Dim prod As Long
    
    If v = 0 Then
        PowOf2 = 1
    Else
        prod = 1
        
        While v > 0
            prod = prod * 2
            v = v - 1
        Wend
    End If
    
    PowOf2 = prod
End Function


Public Function GetDriveLetterValue(driveletter As String) As Long
    GetDriveLetterValue = PowOf2(Asc(UCase(driveletter)) - 65)
End Function


Public Function DriveTypeString(ByVal dt As Integer) As String
    
    Select Case dt
        Case CDRom
           DriveTypeString = "CD-ROM"
           
        Case Fixed
           DriveTypeString = "FIXED DRIVE"
           
        Case RamDisk
           DriveTypeString = "RAM DISK"
        
        Case Remote
           DriveTypeString = "MAPPED NETWORK DRIVE"
        
        Case Removable
           DriveTypeString = "REMOVABLE"
        
        Case UnknownType
           DriveTypeString = "UKNOWN"
    End Select
End Function

Public Function MangledPassword(ByVal orig As String) As String
        Dim outstr As String
        Dim lctr As Long
        
        lctr = Len(orig)
        
        outstr = ""
        While (lctr > 0)
                outstr = outstr & ChrW(Asc(Mid(orig, lctr, 1)) + 17 - 65)
                lctr = lctr - 1
        Wend
        
        MangledPassword = outstr
        
End Function

Public Function UnmanglePassword(ByVal pw As String) As String
     Dim outstr As String
     Dim lctr As Long
     Dim i As Long
     
     lctr = Len(pw)
     
     outstr = ""
     While (lctr > 0)
            outstr = outstr & ChrW(Asc(Mid(pw, lctr, 1)) - 17 + 65)
            lctr = lctr - 1
     Wend
     
     UnmanglePassword = outstr
End Function


Public Function HasPassword() As Boolean
    Dim regPW As String
        
    strPassword = GetSetting("5874013", "4210", "534", "")
    
    HasPassword = False
    
    If Len(strPassword) > 0 Then
        strPassword = UnmanglePassword(strPassword)
        HasPassword = True
    End If
End Function


