Public Class QuestionHeads
    Public TN As String = "QuestionHead"
    Public TF As String() = {"Id", "c1", "c2", "c3", "c4"}
    Public TV As String() = {"", "", "", "", ""}
    Public TS As String() = {"N", "T", "T", "T", "T"}
    Private Sub QuestionHeads_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        createTable(TN, TF, TS)
        refreshEverything()
    End Sub
    Sub dgfill()
        dg.DataSource = GDs(TN, " c4 = '" & FormXmdi.llSurveyRef.Text & "'  order by c3").Tables(TN)
        dg.Columns(0).FillWeight = 20
        dg.Columns(1).FillWeight = 100
        dg.Columns(2).FillWeight = 100
        dg.Columns(3).FillWeight = 20
        dg.Columns(4).Visible = False
    End Sub
    Sub refreshEverything()
        dgfill()
        bbSave.Text = "Save"
        Clr(Panel1)
        ttref.Text = FormXmdi.llSurveyRef.Text
    End Sub
    Sub fillFrm()
        Dim dt As DataTable = GDs(TN, " Id= " & ttid.Text & " order by c3").Tables(TN)
        TextBox1.Text = dt.Rows(0).Item("c3")
        TextBox2.Text = dt.Rows(0).Item("c1")
        RichTextBox1.Text = dt.Rows(0).Item("c2")
        ttref.Text = dt.Rows(0).Item("c4")
        bbSave.Text = "Update"
    End Sub
    Private Sub bbSave_Click(sender As Object, e As EventArgs) Handles bbSave.Click
        Dim t As String = TN
        Dim f As String() = TF
        Dim v As String() = TV
        Dim x As String() = TS
        Dim s As String = ""
        Dim c As String = ""

        v(1) = "'" & TextBox2.Text.Trim & "'"
        v(2) = "'" & RichTextBox1.Text.Trim & "'"
        v(3) = "'" & TextBox1.Text.Trim & "'"

        If bbSave.Text = "Save" Then
            v(4) = FormXmdi.llSurveyRef.Text
            v(0) = Max(t, "", "Id") + 1
            INS(t, f, v)
        ElseIf bbSave.Text = "Update" Then
            v(0) = ttid.Text
            v(4) = ttref.Text.Trim
            c = "Id=" & ttid.Text
            UPD(t, C2A(f, CAQ(v, x)), c)
        End If
        CheckAllAutoCompletFields(Panel1)
        refreshEverything()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MsgBox("Are you Sure", vbYesNo) = MsgBoxResult.Yes Then
            For Each r In dg.SelectedRows
                DEL(TN, "Id=" & r.Cells(0).Value)
            Next
            refreshEverything()
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        ttid.Text = dg.CurrentRow.Cells(0).Value
        fillFrm()
    End Sub

    Private Sub Question_Click(sender As Object, e As EventArgs) Handles Question.Click
        QuestionEntry.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        QuestionAnsEntry.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        QuestionHeaderInformation.Show()
    End Sub
End Class