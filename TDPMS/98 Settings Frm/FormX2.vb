Imports System.Windows.Forms

Public Class FormX2
    Dim t As String = TN1
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        createTable(TN1, TF1, TS1)
        ds.Clear()
        ds = GDs(TNq, "")
        ds = GDs(TNa, "")
        ds = GDs(TN2, "")
        'ds.WriteXml("TableBackup_" & SpName().Substring(0, 6) & ".xml")

        Me.MdiParent = FormXmdi
        trapTextboxs(Me.Panel1)
        TextBox1.Text = SpDateKey("Ref", TN1, "Ref-")
        FILLDG()
        TextBox1.Enabled = False
        If FormXmdi.llref.Text <> "..." Then FormFill(FormXmdi.llid.Text)
        createBtn()
        ' FormFill(2)


    End Sub

    Sub FILLDG()
        dg.DataSource = GDs("Id, Ref, District, Village, UC", t, "").Tables(t)
        dg.Columns(0).Visible = False
    End Sub
    Sub checkFrmIfset()

        Dim f As String() = {N3, N4, N5, N6, N7, N8, N9, N10}
        Dim z As String = ""
        Dim p As Object()
        Try
            'DirectCast(Me.Controls(z), Panel).BackColor = Color.GreenYellow
            For i = 0 To f.Length - 1
                ds = GDs(f(i), "Ref='" & FormXmdi.llref.Text & "'")
                z = "pp" & WholeNum(i + 3, 2)
                p = Me.Controls.Find(z, True)
                If FormXmdi.llref.Text = "..." Then p(0).BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
                If ds.Tables.Contains(f(i)) And ds.Tables(f(i)).Rows.Count <> 0 Then
                    p(0).BackColor = Color.LightGreen
                Else
                    p(0).BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub bbSave_Click(sender As Object, e As EventArgs) Handles bbSave.Click

        Dim f As String() = TF1
        Dim v As String() = TV1
        Dim c As String = "Id=" & ttid.Text

        CheckAllAutoCompletFields(Panel1)

        v(1) = TextBox1.Text.Trim
        v(2) = TextBox2.Text.Trim
        v(3) = TextBox3.Text.Trim
        v(4) = TextBox4.Text.Trim
        v(5) = TextBox5.Text.Trim
        v(6) = TextBox6.Text.Trim
        v(7) = Now.Date

        If bbSave.Text = "Save" Then
            v(0) = Max(t, "", "Id") + 1
            INS(t, f, CAQ(v, TS1))
        ElseIf bbSave.Text = "Update" Then
            v(0) = ttid.Text
            UPD(t, C2A(f, CAQ(v, TS1)), c)
            bbSave.Text = "Save"
        ElseIf bbSave.Text = "Edit" Then
            ENB(Panel1, True)
            bbSave.Text = "Update"
            Exit Sub
        End If
        Clr(Panel1)
        TextBox1.Text = SpDateKey("Ref", TN1, "Ref-")
        trapTextboxs(Panel1)
        FILLDG()
    End Sub
    Sub FormFill(iid)
        ttid.Text = iid
        dt = GDs(t, "Id=" & iid).Tables(t)
        With dt.Rows(0)
            TextBox1.Text = .Item("ref")
            TextBox1.Enabled = False
            TextBox2.Text = .Item("District")
            TextBox3.Text = .Item("Village")
            TextBox4.Text = .Item("UC")
            TextBox5.Text = .Item("Interviewer")
            TextBox6.Text = .Item("NoteTaker")
            FormXmdi.llid.Text = .Item("Id")
            FormXmdi.lluc.Text = .Item("UC")
            FormXmdi.llref.Text = .Item("ref")
            FormXmdi.llDist.Text = .Item("District")
            FormXmdi.llvillage.Text = .Item("Village")
        End With
        ENB(Panel1, False)
        bbSave.Text = "Edit"
        checkFrmIfset()
    End Sub
    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Panel2.BringToFront()
        Panel2.Visible = Not Panel2.Visible
        If Panel2.Visible Then
            Timer1.Start()
        Else
            Timer1.Stop()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        UltraButton1_Click(sender, e)
    End Sub

    Private Sub dg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg.CellClick
        Panel2.Visible = Not Panel2.Visible
        FormFill(dg.CurrentRow.Cells(0).Value)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Clr(Panel1)
        FormXmdi.lluc.Text = "..."
        FormXmdi.llref.Text = "..."
        FormXmdi.llDist.Text = "..."
        FormXmdi.llvillage.Text = "..."
        FormXmdi.llid.Text = "..."
        ENB(Panel1, True)
        Panel2.Visible = False
        TextBox1.Text = SpDateKey("Ref", TN1, "Ref-")
        TextBox1.Enabled = False
        bbSave.Text = "Save"
        checkFrmIfset()
    End Sub

    Dim tim = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Panel2.Visible = False Then Timer1.Stop()
        If tim = 100 Then
            Panel2.Visible = False
            tim = 0
            Timer1.Stop()
        End If
        tim += 1
    End Sub

#Region "menu"
    Sub actionOfBtn(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'MsgBox("you have clicked button " & CType(CType(sender, System.Windows.Forms.Button).Name, String))

            'Dim nam As String() = CType(CType(sender, System.Windows.Forms.Button).Name, String).Split(":")
            Dim nm As String = DirectCast(sender, Button).Name
            Dim nam As String() = nm.Split(":")
            Dim objForm As Form
            Dim FullTypeName As String
            Dim FormInstanceType As Type

            FullTypeName = Application.ProductName & "." & nam(1)

            FormInstanceType = Type.GetType(FullTypeName, True, True)

            objForm = CType(Activator.CreateInstance(FormInstanceType), Form)
            objForm.Show()
            checkFrmIfset()
        Catch ex As Exception

        End Try

    End Sub
    Sub createBtn()
        Dim j As Integer = 0, k As Integer = 0, NextColumnAt As Integer = 12
        Dim x As String = ""
        Try

            Dim fmx As Form() = {Form03, Form04, Form05, Form06, Form07, Form08, Form09, Form10}
            For Each t As Form In fmx

                If t.Name = Me.Name Then Continue For
                If t.Name = "FormXmdi" Then Continue For
                If t.Name = "MenuFrm" Then Continue For
                If t.Name = "FormX1" Then Continue For
                If t.Name = "Form31" Then Continue For
                If t.Name = "Upgrade" Then Continue For
                If t.Name = "QuestionNanswers" Then Continue For
                If t.Name = "Form32" Then Exit For
                Menu1(t, Panel4, k, j)
                j += 1
                If j = NextColumnAt Then k += 1 : j = 0


            Next
            'For Each t As Type In Me.GetType().Assembly.GetTypes()
            '    If t.BaseType.Name = "Form" Then
            '        If t.Name = Me.Name Then Continue For
            '        If t.Name = "FormXmdi" Then Continue For
            '        If t.Name = "MenuFrm" Then Continue For
            '        If t.Name = "FormX1" Then Continue For
            '        If t.Name = "Form31" Then Continue For
            '        If t.Name = "Upgrade" Then Continue For
            '        If t.Name = "QuestionNanswers" Then Continue For
            '        If t.Name = "Form32" Then Exit For
            '        Menu1(CType(Activator.CreateInstance(t), Form), Panel4, k, j)
            '        j += 1
            '        If j = NextColumnAt Then k += 1 : j = 0
            '        x = t.Name
            '    End If
            'Next
        Catch ex As Exception
            MsgBox(ex.Message & " : " & x)
        End Try

    End Sub
    Sub Menu1(frm As Form, panl As Panel, k As Integer, j As Integer)
        Try
            Dim w As Integer = 150, h As Integer = 25, x As Integer = 0, y As Integer = 0, remn As Integer = 0
            x = (w + 5) * k
            y = (h + 5) * j
            panl.Width = (w + 10) * (k + 1)
            'panl.Height = (h + 10) * (j + 1)
            'panl.Location = New Point((Me.Width - panl.Width) / 2, (Me.Height - panl.Height) / 2)
            Dim bb As New Button
            With bb
                .Location = New System.Drawing.Point(x, y)
                .Name = "ubtn:" & frm.Name
                .UseVisualStyleBackColor = True
                .FlatStyle = System.Windows.Forms.FlatStyle.Flat
                .Size = New System.Drawing.Size(w, h)
                .TabIndex = 10
                .Text = frm.Text
                .TextAlign = System.Drawing.ContentAlignment.MiddleLeft
                AddHandler bb.Click, AddressOf actionOfBtn
            End With
            'Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            'Dim ubtn = New System.Windows.Forms.Button()
            'With Appearance2
            '    .BackColor = Color.OldLace
            '    .BackColor2 = Color.Wheat

            '    .BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
            '    .BorderAlpha = Infragistics.Win.Alpha.Transparent
            '    .TextHAlign = Infragistics.Win.HAlign.Left
            'End With
            'With ubtn
            '    .Appearance = Appearance2
            '    .ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button
            '    .Location = New System.Drawing.Point(x, y)
            '    .Name = "ubtn:" & frm.Name
            '    .Size = New System.Drawing.Size(w, h)
            '    .TabIndex = 10
            '    .Text = frm.Text
            '    AddHandler .Click, AddressOf actionOfBtn

            'End With
            panl.Controls.Add(bb)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
#End Region


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim a As String() = Now.ToString.Split(" ")
        'Dim b As String() = a(0).Split("/")
        'Dim cc As String() = a(1).Split(":")
        'Dim valu As String = cc(2) & cc(1) & cc(0) 'b(0) & b(1) & b(2) & 
        'Dim temp As String = InputBox("Enter " & valu, "Erase Record", "")
        'Dim condition As String = ""
        'If temp = valu Then
        '    DEL(TNq, condition)
        'Else
        '    MsgBox("Invalid input")
        'End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FormX1.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        QuestionNanswers.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Upgrade.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form32.Show()
    End Sub

    Private Function Version() As String
        Throw New NotImplementedException
    End Function

End Class