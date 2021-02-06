Public Class Form1
    Dim checks As Long

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getbackendfile()
        initbackend()
        InitListBoxes()
        cmdClear_Click(sender, e)
        SHOWRESULTS()
        initmaxchecks()
    End Sub

    Sub initmaxchecks()
        lMaxChecks.Minimum = 0
        lMaxChecks.Maximum = 200
        lMaxChecks.Value = 15
    End Sub

    Sub InitListBoxes()
        Dim li As ListViewItem

        With listCandidates
            .View = View.Details
            .FullRowSelect = True
            .HideSelection = True
            .LabelEdit = False
            .CheckBoxes = True
            .GridLines = True
            .MultiSelect = False
            .Columns.Add("NO.", 50)
            .Columns.Add("Name", 500)
            .Columns.Add("Name", 500)
        End With

        commrs = GetCandidates()

        If commrs.RecordCount > 0 Then
            With commrs
                .MoveFirst()

                While Not .EOF
                    Try
                        li = listCandidates.Items.Add(.Fields("candidateID").Value)
                        li.SubItems.Add(.Fields("candidate").Value)
                        li.SubItems.Add(.Fields("alttext").Value)
                    Catch
                    End Try
                    .MoveNext()
                End While
            End With
        End If


    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        txtBallotNumber.Text = ""
        For Each li In listCandidates.Items
            li.checked = False
        Next
        txtBallotNumber.Focus()
        specialsave = False
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim i As Long

        Try
            i = CLng(txtBallotNumber.Text)
        Catch
            MsgBox("Invalid ballot number")
            Exit Sub
        End Try


        If specialsave Then
            bkend.Execute("DELETE * FROM tblVotes WHERE BALLOTNUMBER = " & i)
        Else
            If BallotExists(i) Then
                MsgBox("ballot number already entered")
                Exit Sub
            End If
        End If

        For Each li In listCandidates.Items
            If li.checked Then
                'SaveVote(i, CLng(li.Text))
                SaveVote2(i, CLng(li.text))
            End If
        Next
        specialsave = False
        SHOWRESULTS()
        MsgBox("Saved")
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        frmChooseBallot.ShowDialog(Me)
    End Sub

    Private Sub txtBallotNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBallotNumber.Leave
        Dim i As Long

        If specialsave Then
            Exit Sub
        End If

        If txtBallotNumber.TextLength > 0 Then
            Try
                i = CLng(txtBallotNumber.Text)
                If BallotExists(i) Then
                    MsgBox("Ballot number already entered.")
                    txtBallotNumber.Focus()
                End If
            Catch ex As Exception
                MsgBox("Invalid ballot number")
                txtBallotNumber.Focus()
            End Try
        End If
    End Sub


    Sub SHOWRESULTS()
        Dim li As ListViewItem
        commrs = bkend.Execute("select tc.candidate,tc.alttext,count(tv.candidateid) as votes from " & _
                               "tblvotes as tv right outer join tblcandidates as tc on tv.candidateid = tc.candidateid " & _
                               "group by tc.candidate,tc.alttext,tv.candidateid order by count(tv.candidateid) desc")


        listResults.Items.Clear()

        With commrs
            .MoveFirst()

            While Not .EOF
                li = listResults.Items.Add(.Fields("candidate").Value)
                Try
                    li.SubItems.Add(.Fields("ALTTEXT").Value)
                Catch
                    li.SubItems.Add("")
                End Try
                li.SubItems.Add(.Fields("votes").Value)
                .MoveNext()
            End While
        End With
    End Sub

    Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
        Dim xl As Object
        Dim xb As Object
        Dim r As Long
        Dim li As ListViewItem
        Dim lBallotsCounted As Long

        xl = CreateObject("excel.application")
        xb = xl.workbooks.add()


        r = 3

        commrs = bkend.Execute("SELECT DISTINCT(ballotnumber) from tblVotes")

        lBallotsCounted = commrs.RecordCount

        commrs = Nothing

        With xb.sheets(1)

            .cells(1, 1) = "Results as of " & Now().ToString
            .cells(2, 1) = "No. of ballots counted :" & lBallotsCounted

            For Each li In listResults.Items
                .cells(r, 1) = li.Text
                .cells(r, 2) = li.SubItems(1).Text
                .cells(r, 3) = li.SubItems(2).Text
                r = r + 1
            Next
        End With

        xl.visible = True
    End Sub


    Sub countchecks()
        Dim li As ListViewItem

        checks = 0
        For Each li In listCandidates.Items
            If li.checked Then
                li.BackColor = Color.Black
                li.ForeColor = Color.White
                checks += 1
            Else
                li.BackColor = Color.White
                li.ForeColor = Color.Black
            End If
        Next
        StatusStrip1.Items(0).Text = "CHECKS : " & checks
    End Sub

    Private Sub listCandidates_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles listCandidates.ItemChecked
        countchecks()

        If checks > lMaxChecks.Value Then
            MsgBox("Number of checked items exceeds allowable maximum.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "MAXIMUM CHECKS EXCEEDED")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SHOWRESULTS()
    End Sub
End Class
