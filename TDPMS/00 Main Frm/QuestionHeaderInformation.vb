Imports System.Windows.Forms

Public Class QuestionHeaderInformation

    Public TN As String = "QuestionGeneralInformation"
    Public TF As String() = {"Id", "FormNo", "Mobilizer_Name", "Dt", "Province", "District", "Tehsil", "UC", "Village", "Sub_Village"}
    Public TV(TF.Length - 1) As String
    Public TS As String() = {"N", "T", "T", "T", "T", "T", "T", "T", "T", "T"}
    Public temp(8) As String
    Dim point1 As Point, point2 As Point
    Private Sub QuestionHeads_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dg.Columns.Add("Tracker", "Tracker")
        point1 = dg.Location
        point2 = dg.Size
        temp = {"0", "0", "0", "0", "0", "0", "0", "0"}
        Me.MdiParent = FormXmdi
        createTable(TN, TF, TS)
        refreshEverything()
        If My.Settings.condition.Length = 0 Then
            My.Settings.condition = "1=1"
        Else
            ttCondition.Text = My.Settings.condition
        End If

    End Sub
    Sub dgfill()
        Try

            Try
                dg.DataSource = GDs(TN, "FormNo like '" & FormXmdi.llSurveyRef.Text & "%' and " & ttCondition.Text & " order by Id Desc").Tables(TN)
                dg.Columns(1).Visible = False
                'dg.Columns(1).FillWeight = 20
                'dg.Columns(1).FillWeight = 100
                dg.Columns(2).FillWeight = 150
                lltotal.Text = dg.RowCount
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try


    End Sub
    Sub refreshEverything()
        CheckAllAutoCompletFields(Panel1)
        dgfill()
        If CheckBox1.Checked = True Then
            dg.ClearSelection()
            dg.Rows(dg.RowCount - 1).Selected = True
            'OpenSurveyToolStripMenuItem.PerformClick()
        End If


        bbSave.Text = "Save"

        'TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()

        trapTextboxs(Panel1)
        TextBox1.Text = SpDateKey2("FormNo", TN, FormXmdi.llSurveyRef.Text)
        TextBox1.Enabled = False

        TextBox2.Focus()
        '{"Id", "FormNo", "Mobilizer_Name", "Dt", "Province", "District", "Tehsil", "UC", "Village", "Sub_Village"}
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
        '{"Id", "FormNo", "Mobilizer_Name", "Dt", "Province", "District", "Tehsil", "UC", "Village", "Sub_Village"}
        TextBox1.Text = dt.Rows(0).Item("FormNo")
        TextBox2.Text = dt.Rows(0).Item("Mobilizer_Name")
        TextBox3.Text = dt.Rows(0).Item("Dt")
        TextBox4.Text = dt.Rows(0).Item("Province")
        TextBox5.Text = dt.Rows(0).Item("District")
        TextBox6.Text = dt.Rows(0).Item("Tehsil")
        TextBox7.Text = dt.Rows(0).Item("UC")
        TextBox8.Text = dt.Rows(0).Item("Village")
        TextBox9.Text = dt.Rows(0).Item("Sub_Village")


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

        ' CheckAllAutoCompletFields(Panel1)

        v(1) = TextBox1.Text.Trim
        v(2) = TextBox2.Text.Trim
        v(3) = TextBox3.Text.Trim
        v(4) = TextBox4.Text.Trim
        v(5) = TextBox5.Text.Trim
        v(6) = TextBox6.Text.Trim
        v(7) = TextBox7.Text.Trim
        v(8) = TextBox8.Text.Trim
        v(9) = TextBox9.Text.Trim

        If bbSave.Text = "Save" Then
            GoTo h2
h1:
            v(1) = SpDateKey2("FormNo", TN, FormXmdi.llSurveyRef.Text)
h2:
            If EXV(t, "FormNo='" & v(1) & "'") Then GoTo h1
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
                DEL(TN, "Id=" & r.Cells("Id").Value)
            Next
            refreshEverything()
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        ttid.Text = dg.CurrentRow.Cells("Id").Value
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
        If dg.RowCount = 0 Then Exit Sub
        If dg.SelectedRows.Count <> 1 Then MsgBox("Please select a single Record") : Exit Sub
        ' '{"Id", "FormNo", "Mobilizer_Name", "Dt", "Province", "District", "Tehsil", "UC", "Village", "Sub_Village"}
        With dg.CurrentRow()
            FormXmdi.llid.Text = .Cells("Id").Value
            FormXmdi.lluc.Text = .Cells(8).Value
            FormXmdi.llref.Text = .Cells("FormNo").Value
            FormXmdi.llDist.Text = .Cells(6).Value
            FormXmdi.llvillage.Text = .Cells(9).Value
            Button3.Enabled = True
        End With
        QuestionEntry.Show()
        Button5.Enabled = False
        Try
            FormXmdi.llStopWatchStart.Text = FormXmdi.llTime.Text
            FormXmdi.llStopWatchEnd.Text = 0
            FormXmdi.llStopWatchDiffSec.Text = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If dg.SelectedRows.Count <> 1 Then MsgBox("Please select a single Record") : Exit Sub
        If dg.RowCount = 0 Then Exit Sub
        With dg.CurrentRow()
            FormXmdi.llid.Text = .Cells("Id").Value
            FormXmdi.lluc.Text = .Cells(8).Value
            FormXmdi.llref.Text = .Cells("FormNo").Value
            FormXmdi.llDist.Text = .Cells(6).Value
            FormXmdi.llvillage.Text = .Cells(9).Value
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

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            If dg.Rows.Count = 0 Then Exit Sub
            Dim dtx As DataTable
            Dim str As String = ""
            dtx = GDs("Id,c3,c1,c2", "QuestionHead", " c4 ='" & FormXmdi.llSurveyRef.Text & "' order by c3").Tables("QuestionHead")
            For i = 0 To dg.Rows.Count - 1
                With dg.Rows(i)
                    str = ""
                    For j = 0 To dtx.Rows.Count - 1
                        If Not EXV("GivenAns", "Hid='" & dtx.Rows(j).Item("Id") & "' and ref='" & .Cells("FormNo").Value & "'") Then
                            str = str & dtx.Rows(j).Item("Id") & "|"
                        End If
                    Next
                    .Cells("Tracker").Value = str
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Button8.Text = "Close"
        refreshEverything()
        QuestionsAnsXlsExport.Show()
    End Sub


    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            My.Settings.condition = ttCondition.Text
            My.Settings.Save()
            dgfill()
        Catch ex As Exception

        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        'MsgBox(keyData)
        Select Case keyData
            Case Keys.F1
            Case Keys.Enter
                'SendKeys.Send("{Tab}")
                Dim x = Me.ActiveControl.GetType()
                If x.Name.Equals("TextBox") Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
            Case Keys.Pause
                bbSave.PerformClick()
            Case Keys.Scroll
                OpenSurveyToolStripMenuItem.PerformClick()
            Case Keys.F12
                bbSave.PerformClick()
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)

        End Select

        Return True
    End Function

End Class