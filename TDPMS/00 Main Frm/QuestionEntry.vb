Imports System.ComponentModel
Imports System.Windows.Forms

Public Class QuestionEntry
    Public T1 As String = "QuestionHead"
    Public T2 As String = "QuestionAns"
    Public T9 As String = "GivenAns"
    Public F9 As String() = {"Id", "Ref", "Hid", "Sn", "Ques", "AnsListid", "TypeAns", "GivenAns"}
    Public X9 As String() = {"N", "T", "T", "N", "T", "N", "N", "T"}
    Public V9(F9.Length - 1) As String

    Dim formRef As String
    Private Sub QuestionEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        If FormXmdi.llref.Text = "..." Then Me.Close() : Exit Sub
        If FormXmdi.llref.Text.Trim.Count = 0 Then MsgBox("There is 9 ref Code.") : Me.Close()
        formRef = FormXmdi.llref.Text
        createTable(T9, F9, X9)
        dg.DataSource = GDs("Id,c3,c1,c2", T1, " c4 ='" & FormXmdi.llSurveyRef.Text & "' order by c3").Tables(T1)
        dg.Columns(0).Visible = False : dg.Columns(1).FillWeight = 20 : dg.Columns(3).Visible = False
        If Not dg.RowCount = 0 Then getQuestion(0)


    End Sub
    Private Sub dg_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellClick
        getQuestion(dg.CurrentRow.Index)

    End Sub
    Sub getQuestion(CurrentRowIndx As Integer)
        llRindex.Text = CurrentRowIndx
        If CurrentRowIndx > dg.RowCount Then Exit Sub
        With dg.Rows(CurrentRowIndx)
            ll3.Text = .Cells("c3").Value & "."
            ll1.Text = .Cells("c1").Value
            ll2.Text = IIf(.Cells("c2").Value.ToString.Length = 0, "...", .Cells("c2").Value)
            llhid.Text = .Cells("Id").Value
        End With

        dg1.DataSource = GDs("Id,Hid,Sn,Ques,TypeOfAns,AnsList", T2, "Hid='" & ll3.Text.Substring(0, 1) & "' and ref='" & FormXmdi.llSurveyRef.Text & "' order by Sn").Tables(T2)
        dg1.Columns(0).Visible = False : dg1.Columns(1).Visible = False
        dg1.Columns(4).Visible = False : dg1.Columns(5).Visible = False
        dg1.Columns(2).FillWeight = 20
        Dim dtx = GDs("Sn,Ques,TypeOfAns,AnsList", T2, "Hid='" & ll3.Text.Substring(0, 1) & "'and ref='" & FormXmdi.llSurveyRef.Text & "' order by Sn").Tables(T2) 'Hid='" & ll3.Text.Substring(0, 1) & "' and  TypeOfAns<>3 
        Try
            Filldg2(dtx)
            llStatus.Text = IIf(Not GDs(T9, "Hid='" & llhid.Text & "'and ref='" & formRef & "'").Tables(T9).Rows.Count = 0, "Answered", "Not Answered")
            llStatus.ForeColor = IIf(llStatus.Text = "Answered", Color.Green, Color.LightPink)
        Catch ex As Exception

        End Try
    End Sub
#Region "Question dg filler"

    Sub Filldg2(datable As DataTable)
        If formRef = "..." Then Me.Close() : Exit Sub
        Try
            If dg2.Columns.Count <> 0 Then dg2.Columns.Remove("Sn") : dg2.Columns.Remove("Question") : dg2.Columns.Remove("ids")
        Catch ex As Exception

        End Try



        dg2.Columns.Add("Sn", "Sn") : dg2.Columns.Add("Question", "Question") : dg2.Columns.Add("ids", "ids")
        dg2.Columns(2).Visible = False
        Dim r As Integer = 0
        For i = 0 To datable.Rows.Count - 1
            dg2.Rows.Add()
            r = dg2.Rows.Count - 1
            dg2.Rows(r).DefaultCellStyle.BackColor = Color.LightGray
            With dg2.Rows(r)
                .Cells(0).Value = datable.Rows(i).Item("Sn")
                .Cells(0).ReadOnly = True
                .Cells(1).Value = datable.Rows(i).Item("Ques")
                .Cells(1).ReadOnly = True
                .Cells(2).Value = datable.Rows(i).Item("AnsList")
            End With

            dg2.Rows.Add()
            r = dg2.Rows.Count - 1
            dg2.Rows(r).DefaultCellStyle.BackColor = Color.LightYellow
            With dg2.Rows(r)
                .Cells(0).Value = "Ans"
                .Cells(0).ReadOnly = True
                .Cells(2).Value = datable.Rows(i).Item("TypeOfAns")
                If datable.Rows(i).Item("TypeOfAns") = 1 Then
                ElseIf datable.Rows(i).Item("TypeOfAns") = 2 Then
                    dgTextboxToCombo(dg2, r, 1, GDs("Answer", TNa, "AnsTypeRef=" & dt.Rows(i).Item("AnsList") & "").Tables(TNa))
                ElseIf datable.Rows(i).Item("TypeOfAns") = 3 Then
                    dgTextboxToButton(dg2, r, 1, GDs("Answer", TNa, "AnsTypeRef=" & dt.Rows(i).Item("AnsList") & "").Tables(TNa))
                End If
            End With

        Next
        dg2.Columns(0).FillWeight = 10 ': dg2.Columns(2).Visible = False : dg2.Columns(3).Visible = False
        'dg2.Rows(0).Selected = False
        'dg2.Rows(1).Selected = True
        dg2.ClearSelection()
        dg2.Rows(1).Cells(1).Selected = True


    End Sub

    Sub dgTextboxToButton(d As DataGridView, row As Integer, column As Integer, datble As DataTable)
        Try
            Dim gridbtn As New DataGridViewButtonCell

            With d
                If .Rows.Count = 0 Then Exit Sub
                gridbtn.Value = "Click to Select Ans | ..."
                .Item(column, row) = gridbtn
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dg1_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellClick
        dt = GDs("Sn,Ques,TypeOfAns,AnsList", T2, "Id=" & dg1.CurrentRow.Cells(0).Value & " ").Tables(T2) 'Hid='" & ll3.Text.Substring(0, 1) & "' and  TypeOfAns<>3 
        Filldg2(dt)

    End Sub
    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllToolStripMenuItem.Click
        dt = GDs("Sn,Ques,TypeOfAns,AnsList", T2, " Hid='" & ll3.Text.Substring(0, 1) & "'  order by Sn").Tables(T2)
        Filldg2(dt)

    End Sub

    Private Sub SelectedQuestionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectedQuestionToolStripMenuItem.Click
        Dim condition As String = ""
        Dim cnt As Integer = 0
        For Each r In dg1.SelectedRows
            condition = condition & " Id = " & r.Cells(0).Value
            If dg1.SelectedRows.Count <> 1 And cnt <> dg1.SelectedRows.Count - 1 Then condition = condition & " Or "
            cnt += 1
        Next
        dt = GDs("Sn,Ques,TypeOfAns,AnsList", T2, " Hid='" & ll3.Text.Substring(0, 1) & "' and ( " & condition & " ) order by Sn").Tables(T2)
        Filldg2(dt)
    End Sub
#End Region


    Sub dg2_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dg2.CurrentCellDirtyStateChanged

        If dg2.IsCurrentCellDirty = False Then
            Return
        End If
        dg2.CommitEdit(DataGridViewDataErrorContexts.Commit)

        If dg2.CurrentCell.ColumnIndex = 1 Then
            'MsgBox(dg2.CurrentRow.Index)
        End If

    End Sub
    Private Sub dg2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellEnter

        If (e.RowIndex = -1) Then Exit Sub

        dg2.BeginEdit(True)

        If TypeOf dg2.EditingControl Is DataGridViewComboBoxEditingControl Then
            Dim control As DataGridViewComboBoxEditingControl = dg2.EditingControl

            If Not IsNothing(control) Then control.DroppedDown = True

        End If
    End Sub
    Private Sub dg2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg2.CellClick
        Try
            Dim tempval As String = dg2.CurrentRow.Cells(1).Value
            If e.ColumnIndex = 1 Then

                If Not dg2.Rows(e.RowIndex).Cells(2).Value = 3 Then Exit Sub
                If tempval.Substring(0, 5) = "Click" Then
                    Panel2.Visible = True
                    ttRowIndex.Text = dg2.CurrentRow.Index

                    dt = GDs("Answer", TNa, "AnsTypeRef=" & dg2.Rows(e.RowIndex - 1).Cells(2).Value).Tables(TNa)
                    For i = 0 To dt.Rows.Count - 1
                        dg3.Rows.Add()
                        dg3.Rows(i).Cells(1).Value = dt.Rows(i).Item("Answer")
                    Next
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dg3.Rows.Clear()
        Panel2.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' dg3.DataSource = GDs("Answer", TNa, "AnsTypeRef=10").Tables(TNa)
        Dim str As String = ""

        For i = 0 To dg3.Rows.Count - 1
            If dg3.Rows(i).Cells(0).Value = True Then str += dg3.Rows(i).Cells(1).Value & " : "
        Next
        If str.Length = 0 Then Button3_Click(sender, e) : Exit Sub
        str = str.Substring(0, str.Length - 3)
        dg2.Rows(ttRowIndex.Text).Cells(1).Value = "Click to Select Ans | -> " & str
        Button3_Click(sender, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If formRef = "..." Then Me.Close() : Exit Sub

            Dim str As String = ""
            Dim s As String() = {"", ""}

            For i = 0 To dg2.Rows.Count - 1 Step 2
                If Not EXV(T9, "ref = '" & formRef & "' and Sn = " & dg2.Rows(i).Cells(0).Value & " ") Then

                    str = dg2.Rows(i + 1).Cells(1).Value

                    With dg2.Rows(i)
                        If str = Nothing Then Continue For
                        If str.Length = 0 Then Continue For
                        If str = "Click to Select Ans | ..." Then Continue For
                        If dg2.Rows(i + 1).Cells(2).Value = 3 Then s = dg2.Rows(i + 1).Cells(1).Value.ToString.Split(">")
                        V9(0) = Max(T9, "", "Id") + 1
                        V9(1) = formRef
                        V9(2) = llhid.Text
                        V9(3) = .Cells(0).Value.ToString
                        V9(4) = .Cells(1).Value.ToString
                        V9(5) = IIf(.Cells(2).Value.ToString.Length = 0, "-", .Cells(2).Value.ToString)
                        V9(6) = dg2.Rows(i + 1).Cells(2).Value
                        If dg2.Rows(i + 1).Cells(2).Value = 3 Then V9(7) = s(1)
                        If Not dg2.Rows(i + 1).Cells(2).Value = 3 Then V9(7) = dg2.Rows(i + 1).Cells(1).Value
                    End With
                    INS(T9, F9, CAQ(V9, X9))
                    AutoCompletInserter(V9(7), "SurveyValues")

                End If
            Next
            dg2.Rows.Clear()
            NextChapter()

        Catch ex As Exception

        End Try


    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False


        Dim str As String = ""
        Dim s As String() = {"", ""}
        Try
            For i = 0 To dg2.Rows.Count - 1 Step 2
                If Not EXV(T9, "ref = '" & formRef & "' and Sn = " & dg2.Rows(i).Cells(0).Value & " ") Then

                    str = dg2.Rows(i + 1).Cells(1).Value

                    With dg2.Rows(i)
                        If str = Nothing Then Continue For
                        If str.Length = 0 Then Continue For
                        If str = "Click to Select Ans | ..." Then Continue For
                        If dg2.Rows(i + 1).Cells(2).Value = 3 Then s = dg2.Rows(i + 1).Cells(1).Value.ToString.Split(">")
                        V9(0) = Max(T9, "", "Id") + 1
                        V9(1) = formRef
                        V9(2) = llhid.Text
                        V9(3) = .Cells(0).Value.ToString
                        V9(4) = .Cells(1).Value.ToString
                        V9(5) = IIf(.Cells(2).Value.ToString.Length = 0, "-", .Cells(2).Value.ToString)
                        V9(6) = dg2.Rows(i + 1).Cells(2).Value
                        If dg2.Rows(i + 1).Cells(2).Value = 3 Then V9(7) = s(1)
                        If Not dg2.Rows(i + 1).Cells(2).Value = 3 Then V9(7) = dg2.Rows(i + 1).Cells(1).Value
                    End With
                    INS(T9, F9, CAQ(V9, X9))
                    AutoCompletInserter(V9(7), "SurveyValues")

                End If
            Next

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        QuestionHeaderInformation.Button8.Text = "Close"
        QuestionHeaderInformation.refreshEverything()
        Try
            With FormXmdi
                .llStopWatchEnd.Text = .llTime.Text
                .llStopWatchDiff.Text = DateDiff(DateInterval.Minute, DateTime.Parse(.llStopWatchStart.Text), DateTime.Parse(.llStopWatchEnd.Text))
                .llStopWatchDiffSec.Text = DateDiff(DateInterval.Second, DateTime.Parse(.llStopWatchStart.Text), DateTime.Parse(.llStopWatchEnd.Text))
            End With
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Rosters.Show()
        Rosters.MdiParent = FormXmdi

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        VillageVisRoster.Show()
        VillageVisRoster.MdiParent = FormXmdi
    End Sub

    Private Sub llhid_Click(sender As Object, e As EventArgs) Handles llhid.Click
        dg2.Rows.Clear()
        dg2.Refresh()

    End Sub



    Sub NextChapter()
        Try

            If dg.RowCount = 0 Or IsNothing(dg.CurrentRow) Then Exit Sub
            Dim i = llRindex.Text
            dg.ClearSelection()
            If Not i < dg.RowCount - 1 Then Button5.Focus() : Exit Sub
            dg.Rows(i + 1).Selected = True
            getQuestion(i + 1)

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dg2_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dg2.EditingControlShowing
        'If dg2.CurrentCell.ColumnIndex = 1 AndAlso TypeOf e.Control Is TextBox Then
        '    With DirectCast(e.Control, TextBox)
        '        .AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '        .AutoCompleteSource = AutoCompleteSource.CustomSource
        '        .AutoCompleteCustomSource = scAutoComplete
        '    End With
        'End If
        Dim titleText As String = dg2.Columns(1).HeaderText
        If titleText.Equals("Question") Then
            Dim autoText As TextBox = TryCast(e.Control, TextBox)
            If autoText IsNot Nothing Then
                autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                autoText.AutoCompleteCustomSource = AutoCompleteFiller(autoText.Text)
            End If
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        ' MsgBox(keyData)
        Select Case keyData
           
            Case Keys.F1
                Button4.PerformClick()
            Case Keys.Pause
                Button1.PerformClick()
            Case Keys.Scroll
                NextChapter()
            Case Keys.F12
                Button1.PerformClick()
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)

        End Select

        Return True
    End Function


End Class