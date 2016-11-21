Imports System.Windows.Forms

Public Class QuestionHeaderInformation

    Public TN As String = "QuestionGeneralInformation"
    Public TF As String() = {"Id", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "c10", "c11"}
    Public TV As String() = {"", "", "", "", "", "", "", "", "", "", "", ""}
    Public TS As String() = {"N", "T", "T", "T", "T", "T", "T", "T", "T", "T", "T", "T"}
    Public temp(8) As String
    Dim point1 As Point, point2 As Point
    Private Sub QuestionHeads_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        point1 = dg.Location
        point2 = dg.Size
        temp = {"0", "0", "0", "0", "0", "0", "0", "0"}
        Me.MdiParent = FormXmdi
        createTable(TN, TF, TS)
        refreshEverything()

    End Sub
    Sub dgfill()
        dg.DataSource = GDs(TN, "c1 like '" & FormXmdi.llSurveyRef.Text & "%'").Tables(TN)
        dg.Columns(0).FillWeight = 20
        dg.Columns(1).FillWeight = 100
        dg.Columns(2).FillWeight = 100

    End Sub
    Sub refreshEverything()
        CheckAllAutoCompletFields(Panel1)
        dgfill()
        bbSave.Text = "Save"
        Clr(Panel1)
        TextBox1.Text = SpDateKey2("C1", TN, FormXmdi.llSurveyRef.Text)
        TextBox1.Enabled = False
        trapTextboxs(Panel1)
        TextBox2.Focus()
        getRememberedVal(TextBox2, cc1)
        getRememberedVal(TextBox3, cc2)
        getRememberedVal(TextBox4, cc3)
        getRememberedVal(TextBox5, cc4)

        getRememberedVal(TextBox6, cc5)
        getRememberedVal(TextBox7, cc6)
        getRememberedVal(TextBox8, cc7)
        getRememberedVal(TextBox9, cc8)


        FormXmdi.llid.Text = "..."
        FormXmdi.lluc.Text = "..."
        FormXmdi.llref.Text = "..."
        FormXmdi.llDist.Text = "..."
        FormXmdi.llvillage.Text = "..."
        Button5.Enabled = True

        QuestionEntry.Close()
        Button3.Enabled = False
        'If Not Button8.Text = "Close" Then
        '    dg.Size = New Point(point2.X - 350, point2.Y - 205)
        '    dg.Location = New Point(point1.X + 348, point1.Y)
        '    Button8.Text = "Close"
        '    Button8.BackColor = Color.LightGreen
        'Else
        '    dg.Size = New Point(point2.X - 3, point2.Y - 205)
        '    dg.Location = New Point(point1.X, point1.Y)
        '    Button8.Text = "New"
        '    Button8.BackColor = Color.Red
        'End If

    End Sub
    Sub getRememberedVal(txt As TextBox, chk As CheckBox)
        If temp(Val(chk.Name.Substring(2, 1) - 1)) = "0" Then Exit Sub
        If chk.Checked = True Then txt.Text = temp(Val(chk.Name.Substring(2, 1) - 1))
        If txt.Text.Length = 0 Then chk.Checked = False
    End Sub
    Sub fillFrm()
        Dim dt As DataTable = GDs(TN, " Id= " & ttid.Text & " order by Id").Tables(TN)
        TextBox1.Text = dt.Rows(0).Item("c1")
        TextBox2.Text = dt.Rows(0).Item("c2")
        TextBox3.Text = dt.Rows(0).Item("c3")
        TextBox4.Text = dt.Rows(0).Item("c4")
        TextBox5.Text = dt.Rows(0).Item("c5")
        TextBox6.Text = dt.Rows(0).Item("c6")
        TextBox7.Text = dt.Rows(0).Item("c7")
        TextBox8.Text = dt.Rows(0).Item("c8")
        TextBox9.Text = dt.Rows(0).Item("c9")
        ComboBox2.Text = dt.Rows(0).Item("c10")
        ComboBox3.Text = dt.Rows(0).Item("c11")

        ENB(Panel1, False)
        bbSave.Text = "Edit"
    End Sub
    Private Sub bbSave_Click(sender As Object, e As EventArgs) Handles bbSave.Click
        Dim t As String = TN
        Dim f As String() = TF
        Dim v As String() = TV
        Dim x As String() = TS
        Dim s As String = ""
        Dim c As String = ""

        CheckAllAutoCompletFields(Panel1)

        v(1) = TextBox1.Text.Trim
        v(2) = TextBox2.Text.Trim
        v(3) = TextBox3.Text.Trim
        v(4) = TextBox4.Text.Trim
        v(5) = TextBox5.Text.Trim
        v(6) = TextBox6.Text.Trim
        v(7) = TextBox7.Text.Trim
        v(8) = TextBox8.Text.Trim
        v(9) = TextBox9.Text.Trim
        v(10) = ComboBox2.Text.Trim
        v(11) = ComboBox3.Text.Trim

        If bbSave.Text = "Save" Then
            v(0) = Max(t, "", "Id") + 1
            INS(t, f, CAQ(v, x))
        ElseIf bbSave.Text = "Update" Then
            v(0) = ttid.Text
            c = "Id = " & ttid.Text
            UPD(t, C2A(f, CAQ(v, x)), c)
            bbSave.Text = "Save"
        ElseIf bbSave.Text = "Edit" Then
            ENB(Panel1, True)
            bbSave.Text = "Update"
            Exit Sub
        End If

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

    Private Sub Question_Click(sender As Object, e As EventArgs)
        Button8.Text = "Close"
        refreshEverything()
        QuestionEntry.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button8.Text = "Close"
        refreshEverything()
        QuestionAnsEntry.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button8.Text = "Close"
        refreshEverything()
        QuestionHeads.Show()
    End Sub

    Sub rememberVal(txt As TextBox, chk As CheckBox)
        If chk.Checked = False Then temp(Val(chk.Name.Substring(2, 1) - 1)) = "0" : txt.Text = ""
        If txt.Text.Length = 0 Then chk.Checked = False
        temp(Val(chk.Name.Substring(2, 1) - 1)) = txt.Text
    End Sub

    Private Sub cc1_CheckedChanged(sender As Object, e As EventArgs) Handles cc1.CheckedChanged
        rememberVal(TextBox2, cc1)
    End Sub

    Private Sub cc2_CheckedChanged(sender As Object, e As EventArgs) Handles cc2.CheckedChanged
        rememberVal(TextBox3, cc2)
    End Sub

    Private Sub cc3_CheckedChanged(sender As Object, e As EventArgs) Handles cc3.CheckedChanged
        rememberVal(TextBox4, cc3)
    End Sub

    Private Sub cc4_CheckedChanged(sender As Object, e As EventArgs) Handles cc4.CheckedChanged
        rememberVal(TextBox5, cc4)
    End Sub

    Private Sub cc5_CheckedChanged(sender As Object, e As EventArgs) Handles cc5.CheckedChanged
        rememberVal(TextBox6, cc5)
    End Sub

    Private Sub cc6_CheckedChanged(sender As Object, e As EventArgs) Handles cc6.CheckedChanged
        rememberVal(TextBox7, cc6)
    End Sub

    Private Sub cc7_CheckedChanged(sender As Object, e As EventArgs) Handles cc7.CheckedChanged
        rememberVal(TextBox8, cc7)
    End Sub

    Private Sub cc8_CheckedChanged(sender As Object, e As EventArgs) Handles cc8.CheckedChanged
        rememberVal(TextBox9, cc8)
    End Sub

    Private Sub OpenSurveyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSurveyToolStripMenuItem.Click
        With dg.CurrentRow()
            FormXmdi.llid.Text = .Cells(0).Value
            FormXmdi.lluc.Text = .Cells(7).Value
            FormXmdi.llref.Text = .Cells(1).Value
            FormXmdi.llDist.Text = .Cells(5).Value
            FormXmdi.llvillage.Text = .Cells(8).Value
            Button3.Enabled = True
        End With
        QuestionEntry.Show()
        Button5.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button8.Text = "Close"
        refreshEverything()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button8.Text = "Close"
        refreshEverything()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button8.Text = "Close"
        refreshEverything()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
       
        If dg.SelectedRows.Count <> 1 Then MsgBox("Please select a single Recorde") : Exit Sub
        With dg.CurrentRow()
            FormXmdi.llid.Text = .Cells(0).Value
            FormXmdi.lluc.Text = .Cells(7).Value
            FormXmdi.llref.Text = .Cells(1).Value
            FormXmdi.llDist.Text = .Cells(5).Value
            FormXmdi.llvillage.Text = .Cells(8).Value
            Button3.Enabled = True
        End With
        QuestionEntry.Show()
        Button5.Enabled = False
        
    End Sub

    Private Sub NewEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewEntryToolStripMenuItem.Click


        refreshEverything()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Button8.Text = "Close"
        refreshEverything()
   
    End Sub
 
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        refreshEverything()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ShowGivenAns.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Button8.Text = "Close"
        refreshEverything()
        QuestionsAnsXlsExport.Show()
    End Sub

     
End Class