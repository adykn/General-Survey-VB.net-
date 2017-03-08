Imports System.Windows.Forms

Public Class QuestionAnsEntry
    Dim tbH As String = "QuestionHead" '{"Id", "c1", "c2", "c3"}
    Public T As String = "QuestionAns"
    Public F As String() = {"Id", "Hid", "Sn", "Ques", "TypeOfAns", "AnsList", "ref"}
    Public S As String() = {"N", "T", "N", "T", "N", "N", "T"}
    Public V(F.Length - 1) As String
    Public temp As String = "0"
    Public temp2 As String = "0"
    'Public TNa As String = "Answers"
    'Public TFa As String() = {"Id", "AnsTypeRef", "SN", "Answer"}


    Private Sub QuestionAnsEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        createTable(T, F, S)
        createTable(TNa, TFa, TSa)
        refresher()

    End Sub
    Sub refresher()
        Clr(Panel1)

        dg.Rows.Clear()

        Dim cond As String = " ref='" & FormXmdi.llSurveyRef.Text & "'"
        If temp <> "0" Then cond = "Hid='" & temp & "' and ref='" & FormXmdi.llSurveyRef.Text & "'"
        dg1.DataSource = GDs(T, cond & " order by sn desc").Tables(T)
        dg1.Columns("Id").Visible = False : dg1.Columns("ref").Visible = False
        dg2.DataSource = GDs("C3,C1,c4", tbH, " c4='" & FormXmdi.llSurveyRef.Text & "' order by c3").Tables(tbH)
        dg2.Columns(2).Visible = False
        dg2.Columns(0).FillWeight = 20 : dg2.Columns(1).FillWeight = 80
        If dg2.Rows.Count = 0 Then Exit Sub

        RadioButton1.Checked = True
        Try

            If temp = "0" Then TextBox1.Text = dg2.Rows(1).Cells(0).Value
            If Not temp = "0" Then TextBox1.Text = temp

        Catch ex As Exception

        End Try

        If temp2 = "0" Then TextBox2.Text = Max(T, "  ref='" & FormXmdi.llSurveyRef.Text & "' ", "Sn") + 1
        If Not temp2 = "0" Then TextBox2.Text = temp2
        TextBox6.Text = 0
        TextBox5.Text = Max(TNa, "  ref='" & FormXmdi.llSurveyRef.Text & "' ", "AnsTypeRef") + 1


        dg1.Columns(0).FillWeight = 10 : dg1.Columns(1).FillWeight = 10
        dg1.Columns(2).FillWeight = 10 : dg1.Columns(3).FillWeight = 100
        dg1.Columns(4).FillWeight = 10 : dg1.Columns(5).FillWeight = 20

        trapTextboxs(Me.Panel1)
        Try
            fillFullTree()
        Catch ex As Exception

        End Try


    End Sub
    Private Sub dg2_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dg2.CellClick
        TextBox1.Text = dg2.CurrentRow.Cells(0).Value
        dg1.DataSource = GDs(T, " Hid='" & TextBox1.Text & "' and ref='" & FormXmdi.llSurveyRef.Text & "' order by sn desc").Tables(T)
    End Sub

    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
#Region "treeView"
    Sub fillTree(idd As Integer, nod As Integer)
        Dim dattable As DataTable
        dattable = GDs(TNa, "AnsTypeRef=" & idd & "").Tables(TNa)

        Dim n As New TreeNode()
        n.Name = dattable.Rows(0).Item("AnsTypeRef")
        n.Text = dattable.Rows(0).Item("AnsTypeRef")
        n.Tag = dattable.Rows(0).Item("AnsTypeRef")

        TreeView1.Nodes.Add(n)
        For i = 0 To dattable.Rows.Count - 1
            With dattable.Rows(i)
                TreeView1.Nodes(nod).Nodes.Add(New TreeNode(.Item("SN") & " " & .Item("Answer")))
            End With
        Next
    End Sub
    Sub fillFullTree()
        TreeView1.Nodes.Clear()
        dt = GDs("DISTINCT AnsTypeRef", TNa, "").Tables(TNa)
        For i = 0 To dt.Rows.Count - 1
            fillTree(dt.Rows(i).Item(0), i)
        Next
    End Sub
    Private Sub treeView_NodeMouseClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Node.Text.Split(" ").Length = 2 Then Exit Sub
        TextBox5.Text = e.Node.Text
        dt = GDs("AnsTypeRef, SN, Answer", TNa, "AnsTypeRef=" & e.Node.Text & "").Tables(TNa)
        TextBox6.Text = e.Node.Text
        dg.Rows.Clear()
        For i = 0 To dt.Rows.Count - 1
            dg.Rows.Add()
            dg.Rows(i).Cells(0).Value = dt.Rows(i).Item(0)
            dg.Rows(i).Cells(1).Value = dt.Rows(i).Item(1)
            dg.Rows(i).Cells(2).Value = dt.Rows(i).Item(2)
        Next
    End Sub
#End Region
     
    
    
    Private Sub InsertAnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertAnsToolStripMenuItem.Click
        TextBox5.Text = Max(TNa, "ref='" & FormXmdi.llSurveyRef.Text & "'", "AnsTypeRef") + 1
        dg.Rows.Clear()
    End Sub

    Private Sub SaveAnsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAnsToolStripMenuItem.Click
        If dg.Rows.Count <> 0 Then
            '{"Id", "AnsTypeRef", "SN", "Answer"}
            For i = 0 To dg.Rows.Count - 1
                TVa(0) = Max(TNa, "", "Id") + 1
                TVa(1) = dg.Rows(i).Cells(0).Value
                TVa(2) = dg.Rows(i).Cells(1).Value
                TVa(3) = "'" & dg.Rows(i).Cells(2).Value & "'"
                TVa(4) = "'0'"
                'If Not EXV(TNa, "AnsTypeRef=" & dg.Rows(i).Cells(0).Value) Then
                INS(TNa, TFa, TVa)
               ' End If

            Next
            refresher()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem1.Click
        If MsgBox("are you sure", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If dg.Rows.Count = 0 Then Exit Sub
            If EXV(TNa, "AnsTypeRef=" & TextBox5.Text.Trim) Then DEL(TNa, "AnsTypeRef=" & TextBox5.Text.Trim)
            refresher()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox5.Text.Trim.Length = 0 Then Exit Sub
        If EXV(TNa, "AnsTypeRef=" & TextBox5.Text.Trim) Then dg.Rows.Clear() : TextBox5.Text = Max(TNa, "", "AnsTypeRef") + 1
        Dim rw As Int16 = dg.RowCount
        dg.Rows.Add()
        dg.Rows(rw).Cells(0).Value = TextBox5.Text.Trim
        dg.Rows(rw).Cells(1).Value = rw + 1
        dg.Rows(rw).Cells(2).Value = TextBox4.Text.Trim
        TextBox4.Clear()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text.Trim.Length = 0 Then Exit Sub
        If EXV(TNa, "AnsTypeRef=" & TextBox5.Text) Then TextBox6.Text = TextBox5.Text
    End Sub
    Function resetErr() As Boolean
        If err01.Visible = True Then err01.Visible = False : Return False
        If err02.Visible = True Then err02.Visible = False : Return False
        If err03.Visible = True Then err03.Visible = False : Return False
        Return True
    End Function
    Dim Sec As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Sec = Sec + 1
        If Sec = 50 Then
            resetErr()
            Sec = 0
            Timer1.Stop()
        End If
    End Sub

    Private Sub bbSave_Click(sender As Object, e As EventArgs) Handles bbSave.Click
       
        Dim x As String() = s
        Dim c As String = ""
        Dim r As Integer = 0
        Dim typeF As Integer = 0

        If RadioButton1.Checked = True Then r = 1 : TextBox6.Text = 0
        If RadioButton2.Checked = True Then r = 2
        If RadioButton3.Checked = True Then r = 3


        CheckAllAutoCompletFields(Panel1)
        '{"Id", "Hid", "Sn", "Ques", "TypeOfAns", "AnsList", "c1", "c2"}
        v(1) = TextBox1.Text.Trim
        v(2) = TextBox2.Text.Trim
        V(3) = TextBox3.Text.Trim
        V(4) = r
        V(5) = TextBox6.Text.Trim
        V(6) = FormXmdi.llSurveyRef.Text
       

        If bbSave.Text = "Save" Then
            v(0) = Max(t, "", "Id") + 1
            INS(t, f, CAQ(v, x))
        ElseIf bbSave.Text = "Update" Then
            V(0) = ttid.Text
            c = "Id=" & V(0)
            UPD(t, C2A(f, CAQ(v, x)), c)
            bbSave.Text = "Save"
        ElseIf bbSave.Text = "Edit" Then
            ENB(Panel1, True)

            bbSave.Text = "Update"
            Exit Sub
        End If

        refresher()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox6.Text = 0
        TreeView1.Enabled = False
        dg.Rows.Clear()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged, RadioButton3.CheckedChanged
        TreeView1.Enabled = True
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        ttid.Text = dg1.CurrentRow.Cells(0).Value
        '{"Id", "Hid", "Sn", "Ques", "TypeOfAns", "AnsList", "c1", "c2"}
      
        Dim dt As DataTable = GDs(T, " Id= " & ttid.Text).Tables(T)
        TextBox1.Text = dt.Rows(0).Item("Hid").ToString
        TextBox2.Text = dt.Rows(0).Item("Sn").ToString
        TextBox3.Text = dt.Rows(0).Item("Ques").ToString
        TextBox6.Text = dt.Rows(0).Item("AnsList").ToString
        If dt.Rows(0).Item("TypeOfAns") = 1 Then RadioButton1.Checked = True
        If dt.Rows(0).Item("TypeOfAns") = 2 Then RadioButton2.Checked = True
        If dt.Rows(0).Item("TypeOfAns") = 3 Then RadioButton3.Checked = True
        bbSave.Text = "Update"
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MsgBox("Are you Sure", vbYesNo) = MsgBoxResult.Yes Then
            'MsgBox(dg.SelectedRows.Count)
            For Each r In dg1.SelectedRows
                DEL(T, "Id=" & r.Cells(0).Value)
            Next
            refresher()
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then temp = TextBox1.Text
        If CheckBox2.Checked = False Then temp = "0" : TextBox2.Text = Max(T, "", "Sn") + 1
    End Sub

    
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then temp2 = TextBox2.Text
        If CheckBox1.Checked = False Then temp2 = "0"
    End Sub

   
    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        refresher()
    End Sub


End Class