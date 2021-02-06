Attribute VB_Name = "Modulexxx"

Function NumToString(ByVal n As Long) As String
    
    Dim lrem As Long
    Dim fdigit As Long
    
    Select Case n
        Case 0
            NumToString = ""
            
        Case 1
            NumToString = "one "
                
        Case 2
            NumToString = "two "
        
        Case 3
            NumToString = "three "
        
        Case 4
            NumToString = "four "
            
        Case 5
            NumToString = "five "
            
        Case 6
            NumToString = "six "
            
        Case 7
            NumToString = "seven "
            
        Case 8
            NumToString = "eight "
            
        Case 9
            NumToString = "nine "
            
        Case 10
            NumToString = "ten "
            
        Case 11
            NumToString = "eleven "
            
        Case 12
            NumToString = "twelve "
            
        Case 13
            NumToString = "thirteen "
        
        Case 14
            NumToString = "fourteen "
            
        Case 15
            NumToString = "fifteen "
            
        Case 16 To 19
            lrem = n Mod 10
            
            NumToString = NumToString(lrem) & "teen "
        
        Case 20 To 29
            lrem = n Mod 20
            NumToString = "twenty " & NumToString(lrem)
            
        Case 30 To 39
            lrem = n Mod 30
            NumToString = "thirty " & NumToString(lrem)
            
        Case 40 To 49
            lrem = n Mod 40
            NumToString = "forty " & NumToString(lrem)
            
        Case 50 To 59
            lrem = n Mod 50
            NumToString = "fifty " & NumToString(lrem)
            
        Case 60 To 69
            lrem = n Mod 60
            NumToString = "sixty " & NumToString(lrem)
            
        Case 70 To 79
            lrem = n Mod 70
            NumToString = "seventy " & NumToString(lrem)
            
        Case 80 To 89
            lrem = n Mod 80
            NumToString = "eighty " & NumToString(lrem)
            
        Case 90 To 99
            lrem = n Mod 90
            NumToString = "ninety " & NumToString(lrem)
        
        Case 100 To 999
            lrem = n Mod 100
            fdigit = Val(Mid(Trim(Str(n)), 1, 1))
            NumToString = NumToString(fdigit) & "hundred " & NumToString(lrem)
            
        Case 1000 To 9999
            lrem = n Mod 1000
            fdigit = Val(Mid(Trim(Str(n)), 1, 1))
            NumToString = NumToString(fdigit) & "thousand " & NumToString(lrem)
            
            
    End Select
    
    
End Function


Function RoundDown(ByVal n As Double) As Long
    Dim tmpvar As Long
    
    tmpvar = Round(n, 0)
    
    If tmpvar > n Then
        tmpvar = tmpvar - 1
    End If
    
    RoundDown = tmpvar
    
End Function

Function GetFractionPart(ByVal n As Double) As String
    Dim s As String
    Dim npos As Long
    
    
    GetFractionPart = ""
    
    npos = Round((n - RoundDown(n)) * 100, 0)
    
    GetFractionPart = Str(npos)
    
End Function

Public Function PrintAmountInWords(ByVal d As Double) As String
    PrintAmountInWords = NumToString(RoundDown(d)) & " & " & GetFractionPart(d) & "/100 pesos"
End Function

