Public Class frmChooseBallot

    Private Sub frmChooseBallot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        commrs = bkend.Execute("SELECT DISTINCT(BallotNumber) FROM tblVotes ORDER BY BallotNumber")

        listBallots.Items.Clear()

        With commrs

            If .EOF And .BOF Then
                Me.Text = "NO BALLOTS"
                Exit Sub
            End If

            .MoveFirst()

            While Not .EOF
                listBallots.Items.Add(Format$(.Fields("ballotnumber").Value, "0000"))
                .MoveNext()
            End While
        End With
        Me.Text = "COUNT: " & listBallots.Items.Count
        commrs = Nothing
    End Sub

    Private Sub listBallots_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBallots.Click
        ballotnumber = CLng(listBallots.SelectedItem)
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        If MsgBox("Load this item?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, listBallots.SelectedItem) = vbNo Then
            specialsave = False
            Exit Sub
            Close()
        End If

        With Form1
            .txtBallotNumber.Text = ballotnumber

            For Each li In .listCandidates.Items
                li.checked = False
            Next

            commrs = bkend.Execute("SELECT * FROM tblVotes WHERE BallotNumber = " & ballotnumber)

            If commrs.BOF And commrs.EOF Then
                Me.Close()
                Exit Sub
            End If

            commrs.MoveFirst()

            While Not commrs.EOF
                .listCandidates.Items(commrs.Fields("candidateid").Value - 1).checked = True
                commrs.MoveNext()
            End While

            .countchecks()

        End With

        specialsave = True

        Me.Close()

    End Sub
End Class