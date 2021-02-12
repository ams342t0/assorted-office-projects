Module globals
    Public bkend As ADODB.Connection
    Public commrs As ADODB.Recordset
    Public ballotnumber As Long
    Public specialsave As Boolean


    Public Sub initbackend()
        bkend = New ADODB.Connection

        bkend.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Form1.odFile.FileName
        bkend.Mode = ADODB.ConnectModeEnum.adModeReadWrite + ADODB.ConnectModeEnum.adModeShareDenyNone
        bkend.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        bkend.CommandTimeout = 5000

        Try
            bkend.Open()
        Catch e As Exception
            MsgBox("Error opening backend")
            End
        End Try
    End Sub

    Public Sub ClearBallotEntry(ByVal bn As Long)
        bkend.Execute("DELETE * FROM tblVotes WHERE BallotNumber = " & bn)
    End Sub

    Public Sub SaveVote(ByVal bn As Long, ByVal cid As Long)
        bkend.Execute("INSERT INTO tblVotes VALUES(" & bn & "," & cid & ")")
    End Sub


    Public Sub SaveVote2(ByVal bn As Long, ByVal cid As Long)
        commrs = New ADODB.Recordset
        commrs.Open("tblVotes", bkend, CursorType:=ADODB.CursorTypeEnum.adOpenKeyset, LockType:=ADODB.LockTypeEnum.adLockOptimistic)

        bkend.BeginTrans()

        Try
            commrs.AddNew()
            commrs.Fields("ballotnumber").Value = bn
            commrs.Fields("candidateid").Value = cid
            commrs.UpdateBatch()
            bkend.CommitTrans()
        Catch
            bkend.RollbackTrans()
            MsgBox("Unable to save this time. Try again")
        End Try

        commrs = Nothing
    End Sub


    Public Function GetCandidates() As ADODB.Recordset
        GetCandidates = bkend.Execute("SELECT * FROM tblCandidates ORDER BY candidateid")
    End Function

    Public Function BallotExists(ByVal bid As Long) As Boolean
        BallotExists = False

        commrs = bkend.Execute("SELECT * FROM tblVotes where BAllotnumber = " & bid)

        If commrs.RecordCount > 0 Then
            BallotExists = True
        End If

    End Function

    Public Sub getbackendfile()
        With Form1.odFile
            .CheckFileExists = True
            .CheckPathExists = True
            .InitialDirectory = Application.StartupPath
            .Title = "Open Ballot backend"
            .Multiselect = False
            .Filter = "MSACCESS (*.mdb) | *.mdb"
            .ShowDialog()

            If .FileName.Length = 0 Then
                MsgBox("Backend not loaded")
                End
            End If
        End With
    End Sub

End Module
