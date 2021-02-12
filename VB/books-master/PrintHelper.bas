Attribute VB_Name = "PrintHelper"
Option Explicit

Public Function emp(ByVal v As Long) As String
    If v = 1 Then
        emp = Chr(27) & Chr(69)
    Else
        emp = Chr(27) & Chr(70)
    End If
End Function

Public Function dblwidth(ByVal v As Long) As String
    If v = 1 Then
        dblwidth = Chr(14)
    Else
        dblwidth = Chr(20)
    End If
End Function

Public Function uline(ByVal v As Long) As String
    If v = 1 Then
        uline = Chr(27) & Chr(45) & Chr(1)
    Else
        uline = Chr(27) & Chr(45) & Chr(0)
    End If
End Function

Public Function comp(ByVal v As Long) As String
    If v = 1 Then
        comp = Chr(15)
    Else
        comp = Chr(18)
    End If
End Function


Public Function deflinespace() As String
    deflinespace = Chr(27) & Chr(50)
End Function


Public Function formatcolumn(ByRef s1 As String, ByRef s2 As String, ByVal nwidth As Long) As String
    Dim l1 As Long, l2 As Long
    
        
    If Len(s1) > nwidth Then
        s1 = Mid(s1, 1, nwidth - 2)
    End If
        
    formatcolumn = s1 & String(nwidth - Len(s1) - Len(s2), " ") & s2
    
End Function

Public Function joincolumns(ByRef s1 As String, ByRef s2 As String, ByVal nwidth As Long) As String
    Dim l1 As Long, l2 As Long
    
    If Len(s1) > nwidth Then
        s1 = Mid(s1, 1, nwidth - 2)
    End If
    
    joincolumns = s1 & String(nwidth - Len(s1), " ") & s2
    
End Function

Public Function centertext(ByRef s As String) As String
    centertext = String(Round(((80 - Len(s)) / 2) + 0.5, 0), " ") & s
End Function

Public Function centertextwide(ByRef s As String) As String
    centertextwide = String(Round(((40 - Len(s)) / 2) + 0.5, 0), " ") & s
End Function


