Imports System.Windows.Forms

Public Class QuestionNanswers
    Dim t As String = TNq
    Dim section As Double
    Dim temp As String
    Private Sub QuestionNanswers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        createTable(TNq, TFq, TSq)
        createTable(TNa, TFa, TSa)
        trapTextboxs(Me.Panel1)
        dg.Columns(0).FillWeight = 20
        dg2.DataSource = GDs("sn,FormRef,Question", t, " 1=1 order by FormRef,sn").Tables(t)
        dg2.Columns(0).FillWeight = 20 : dg2.Columns(1).FillWeight = 20
        fillFullTree()
        'fixId()
    End Sub
    Sub fixId()
        dt = GDs("sn,FormRef,Question", t, " 1=1 order by FormRef,sn").Tables(t)
        Dim x As Integer = 0
        For i = 0 To dt.Rows.Count - 1
            updateData(TNq, "Id=" & i + 1, "sn='" & dt.Rows(i).Item("sn") & "', FormRef='" & dt.Rows(i).Item("FormRef") & "'")
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rw As Int16 = dg.RowCount
        dg.Rows.Add()
        dg.Rows(rw).Cells(0).Value = rw + 1
        dg.Rows(rw).Cells(1).Value = TextBox4.Text.Trim
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If Not CheckBox2.Checked = True Then section = 0 : Exit Sub
        If TextBox1.Text.Trim.Length = 0 Then Exit Sub
        section = TextBox1.Text.Trim
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Val(TextBox1.Text) = 0 Then TextBox2.Text = "" : Exit Sub
        dt = GDs(t, "FormRef=" & TextBox1.Text.Trim & " order by Sn").Tables(TNq)
        'If dt.Rows.Count = 0 Then Exit Sub
        Dim rw As Integer = dt.Rows.Count
        TextBox2.Text = Chr(97 + rw)
        dg2.DataSource = GDs("sn,Question", t, "FormRef=" & TextBox1.Text.Trim & " order by Sn").Tables(t)
        dg2.Columns(0).FillWeight = 20
        CheckBox2.Checked = True
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        'DigitTextBox_KeyPress(sender, e)
    End Sub
    Private Sub bbSave_Click(sender As Object, e As EventArgs) Handles bbSave.Click

        Dim f As String() = TFq
        Dim v As String() = TVq
        Dim c As String = "Id=" & ttid.Text
        Dim ref As Integer = IIf(TextBox5.Text.Length = 0, Max(t, "", "AnsTypeRef") + 1, TextBox5.Text)
        CheckAllAutoCompletFields(Panel1)

        v(1) = TextBox1.Text.Trim
        v(2) = TextBox2.Text.Trim
        v(3) = TextBox3.Text.Trim
        v(4) = IIf(TextBox5.Text.Length <> 0, ref, IIf(EXV(TNa, "AnsTypeRef='" & ref & "'"), ref, 0))

        If CheckBox1.Checked = True Then If dg.Rows.Count = 0 Then MsgBox("Please add the pre answers") : Exit Sub

        If bbSave.Text = "Save" Then
            v(0) = Max(t, "", "Id") + 1
            If INS(t, f, CAQ(v, TSq)) Then
                If CheckBox1.Checked = True Then
                    For i = 0 To dg.Rows.Count - 1
                        TVa(0) = Max(TNa, "", "Id") + 1
                        TVa(1) = ref
                        TVa(2) = dg.Rows(i).Cells(0).Value
                        TVa(3) = dg.Rows(i).Cells(1).Value
                        INS(TNa, TFa, CAQ(TVa, TSa))
                    Next
                End If
            End If
        ElseIf bbSave.Text = "Update" Then
            v(0) = ttid.Text
            If UPD(t, C2A(f, v), c) Then
                'uupdate the answer
            End If
        ElseIf bbSave.Text = "Edit" Then
            ENB(Panel1, True)
            bbSave.Text = "Update"
            Exit Sub
        End If
        Clr(Panel1)
        trapTextboxs(Panel1)
        TextBox1.Text = section
        CheckBox1.Checked = False
        If CheckBox3.Checked = True Then dg.Rows.Clear()
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            TextBox3.Text = "[empty:" & TextBox6.Text.Trim & "]"
            TextBox3.Enabled = False
            CheckBox1.Checked = True
        Else
            TextBox3.Text = ""
            TextBox3.Enabled = True
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox5.Checked = True Then
            If TextBox5.Text.Trim.Length = 0 Then
                TextBox5.Text = Max(t, "", "AnsTypeRef") + 1
            Else
                TextBox5.Text = temp
            End If
        Else
            TextBox5.Text = Max(t, "", "AnsTypeRef") + 1
        End If

    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        temp = Val(TextBox5.Text.Trim)
        CheckBox1.Checked = True
        CheckBox1_CheckedChanged(sender, e)
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        dg2.DataSource = Nothing
        dg2.DataSource = GDs("sn,FormRef,Question", t, " 1=1 order by Sn").Tables(t)
        dg2.Columns(0).FillWeight = 20 : dg2.Columns(1).FillWeight = 20
        CheckBox6.Checked = False
    End Sub


    Private Sub TextBox6_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        DigitTextBox_KeyPress(sender, e)
    End Sub
    Sub fillTree(idd As String, nod As Integer)
        Dim dattable As DataTable
        dattable = GDs(TNa, "AnsTypeRef='" & idd & "'").Tables(TNa)

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
        dt = GDs("DISTINCT AnsTypeRef", TNa, "1=1 order by AnsTypeRef").Tables(TNa)
        For i = 0 To dt.Rows.Count - 1
            fillTree(dt.Rows(i).Item(0), i)
        Next
    End Sub
    Private Sub treeView_NodeMouseClick(ByVal sender As Object, ByVal e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Node.Text.Split(" ").Length = 2 Then Exit Sub
        TextBox5.Text = e.Node.Text
    End Sub
   
End Class