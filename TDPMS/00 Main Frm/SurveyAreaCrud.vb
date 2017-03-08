Imports System.Windows.Forms

Public Class SurveyAreaCrud

    Public T As String = "Surveys"
    Public F As String() = {"Id", "Ref", "Title", "Loc", "Typ", "l1", "l2", "Detail", "Pass"}
    Public X As String() = {"N", "T", "T", "T", "T", "N", "N", "T", "T"}
    Public V(F.Length - 1) As String
    Dim dx As New DataSet
    Dim sec As Integer = 0

    Private Sub SurveyAreaCrud_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MdiParent = FormXmdi
        'Me.MdiParent = SwitchBoard
        createTable(T, F, X)
        refreshEverything()


    End Sub
    Sub refreshEverything()
        Try
            dg.DataSource = GDs(T, "").Tables(T)

            dg.Columns(0).FillWeight = 20 : dg.Columns(1).FillWeight = 55
            dg.Columns(5).FillWeight = 55 : dg.Columns(6).FillWeight = 55
            dg.Columns(0).Visible = False : dg.Columns(8).Visible = True
            If dg.Rows.Count = 0 Then pp1.BringToFront() : ShowMsg("The table is empty ..!")
            If CheckBox1.Checked = False Then If Not dg.Rows.Count = 0 Then pp2.BringToFront()

            Clr(pp1)
            trapTextboxs(Me.pp1)
            ttref.Text = SpDateKey("Ref", T, "")
            ttref.Enabled = False
            bbSave.Text = "Save"
        Catch ex As Exception

        End Try


    End Sub

    Private Sub bbSave_Click(sender As Object, e As EventArgs) Handles bbSave.Click

        Dim s As String = ""
        Dim c As String = ""

        CheckAllAutoCompletFields(pp1)
        '{"Id", "Ref", "Title", "Loc", "Typ", "l1", "l2", "Detail","Pass"}
        V(1) = ttref.Text.Trim
        V(2) = tttitle.Text.Trim
        V(3) = ttloc.Text.Trim
        V(4) = ttType.Text.Trim
        V(5) = ttl1.Text.Trim
        V(6) = ttl2.Text.Trim
        V(7) = ttDetail.Text.Trim
        V(8) = Crypto.Enc(ttPass.Text.Trim, ttref.Text.Trim) ' <-encode ttPass=enc(noPass,ref) & save result here

        If bbSave.Text = "Save" Then
            V(0) = Max(T, "", "Id") + 1
            INS(T, F, CAQ(V, X))
        ElseIf bbSave.Text = "Update" Then
            V(0) = ttid.Text
            c = "Id = " & ttid.Text
            UPD(T, C2A(F, CAQ(V, X)), c)
            bbSave.Text = "Save"
        ElseIf bbSave.Text = "Edit" Then
            ENB(pp1, True)
            bbSave.Text = "Update"
            Exit Sub
        End If

        refreshEverything()
    End Sub
#Region "Right click menu options"
    Sub ShowMsg(txt As String)
        llMsg.Visible = False
        llMsg.Text = txt.Trim
        'llMsg.Visible = True
        Timer1.Start()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        pp2.BringToFront()
        refreshEverything()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pp1.BringToFront()
    End Sub
    Private Sub AddNewRecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewRecordToolStripMenuItem.Click
        pp1.BringToFront()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        setPPPass("Edit", "Pass")
    End Sub

    Private Sub ttid_TextChanged(sender As Object, e As EventArgs) Handles ttid.TextChanged
        ' fill the textboxs with values from ds where id = ttid
        '{"Id","Ref", "Title", "Loc", "Typ", "l1", "l2", "Detail","Pass"}
        If ttid.Text.Length = 0 Then Exit Sub
        If ttid.Text = 0 Then Exit Sub
        dx = GDs(T, "id=" & Val(ttid.Text.Trim))
        If dx.Tables(T).Rows.Count <> 1 Then MsgBox("To many rows retreived") : Exit Sub
        With dx.Tables(T).Rows(0)
            ttref.Text = .Item("Ref").ToString.Trim
            tttitle.Text = .Item("Title").ToString.Trim
            ttloc.Text = .Item("Loc").ToString.Trim
            ttl1.Text = .Item("l1").ToString.Trim
            ttl2.Text = .Item("l2").ToString.Trim
            ttType.Text = .Item("Typ").ToString.Trim
            ttDetail.Text = .Item("Detail").ToString.Trim
            ttPass.Text = .Item("Pass").ToString.Trim ' decode (.Item("Pass").ToString.Trim , ref )
        End With
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        ' show msg if yes pressed then start loop
        setPPPass("Del", "Pass")
    End Sub

    Private Sub StartSurveyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartSurveyToolStripMenuItem.Click
        setPPPass("Questionary", "Pass")
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, bbCancel.Click
        refreshEverything()
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If sec = 8 Then Timer1.Stop() : llMsg.Visible = False : sec = 0
        If sec = 1 Then llMsg.Visible = True
        sec += 1

    End Sub
#End Region



    Sub PassPanelProcess(type_PassChange_Pass_SetPass As String)

        ppPass.Visible = True
        ttPassType.Text = type_PassChange_Pass_SetPass


        If type_PassChange_Pass_SetPass = "PassChange" Then
            ll1.Visible = True : tt1.Visible = True
            ll2.Text = "New Pass" : ll2.Visible = True : tt2.Visible = True
            ll3.Visible = True : tt3.Visible = True
        ElseIf type_PassChange_Pass_SetPass = "Pass" Then
            ll1.Visible = False : tt1.Visible = False
            ll2.Text = "Pass Code" : ll2.Visible = True : tt2.Visible = True
            ll3.Visible = False : tt3.Visible = False
        ElseIf type_PassChange_Pass_SetPass = "SetPass" Then
            ll1.Visible = False : tt1.Visible = False
            ll2.Text = "Pass Code" : ll2.Visible = True : tt2.Visible = True
            ll3.Visible = True : tt3.Visible = True
        Else
            ppPass.Visible = False
        End If

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ppPass.Visible = False
    End Sub
    Sub setPPPass(frm As String, panl As String)
        ttpid.Text = dg.CurrentRow.Cells(0).Value
        ttkey.Text = dg.CurrentRow.Cells("ref").Value
        ttFrm.Text = frm
        If dg.CurrentRow.Cells("Pass").Value.ToString.Length = 0 Then
            ttppass.Text = "NoPass"
        Else
            If dg.CurrentRow.Cells("Pass").Value.ToString.Trim <> "-" Then
                ttppass.Text = dg.CurrentRow.Cells("Pass").Value.ToString
            Else
                ttppass.Text = "NoPass"
            End If
        End If

        PassPanelProcess(panl)
        If ttppass.Text = "NoPass" Then Button3.PerformClick() : Exit Sub
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If ttPassType.Text = "PassChange" Then


            If Crypto.Enc(tt1.Text.Trim, ttkey.Text.Trim) = ttppass.Text.Trim Then
                If tt3.Text.Trim = tt2.Text.Trim Then updateData(T, "Pass='" & Crypto.Enc(tt2.Text.Trim, ttkey.Text.Trim) & "'", "id=" & ttpid.Text.Trim)
            Else
                If tt1.Text.Trim = "NoPass" Then updateData(T, "Pass='" & Crypto.Enc(tt2.Text.Trim, ttkey.Text.Trim) & "'", "id=" & ttpid.Text.Trim)
                MsgBox("current password was invalid.")
            End If
        ElseIf ttPassType.Text = "Pass" Then
            If Not Crypto.Enc(tt2.Text.Trim, ttkey.Text.Trim) = ttppass.Text.Trim Then GoTo h1
            If dg.SelectedRows.Count <> 1 Then MsgBox("Please Select a Single Row.") : Exit Sub

            If ttFrm.Text.Trim = "Questionary" Then
                FormXmdi.llSurveyRef.Text = dg.CurrentRow.Cells(1).Value
                QuestionHeaderInformation.Show()
                Me.Close()
            ElseIf ttFrm.Text.Trim = "Edit" Then
                ttid.Text = dg.CurrentRow.Cells(0).Value
                bbSave.Text = "Update"
                pp1.BringToFront()
                ppPass.Visible = False
                Clr(ppPass)
                Exit Sub
            ElseIf ttFrm.Text.Trim = "Del" Then
                'If MsgBox("Are you Sure", vbYesNo) = MsgBoxResult.Yes Then
                '     for each rows in dg selected rows
                '        If enc(NoPass, ref) = row.item(8).pass Then DEL(T, "Id=" & r.Cells(0).Value)
                '        If enc(functionShowPassBoxWhichReturnVal, ref) = row.item(8).pass Then DEL(T, "Id=" & r.Cells(0).Value)
                '    Next
                'End If
            End If

        ElseIf ttPassType.Text = "SetPass" Then
            If Crypto.Enc("NoPass", ttkey.Text.Trim) = ttppass.Text.Trim Or Crypto.Enc("-", ttkey.Text.Trim) = ttppass.Text.Trim Or "NoPass" = ttppass.Text.Trim Then
                If tt3.Text.Trim = tt2.Text.Trim Then updateData(T, "Pass='" & Crypto.Enc(tt2.Text.Trim, ttkey.Text.Trim) & "'", "id=" & ttpid.Text.Trim)
            Else
                MsgBox("Password already set.")
            End If
        End If
h1:
        ppPass.Visible = False
        Clr(ppPass)
        refreshEverything()
    End Sub

    Private Sub LockSurveyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LockSurveyToolStripMenuItem.Click
        ttpid.Text = dg.CurrentRow.Cells(0).Value
        ttkey.Text = dg.CurrentRow.Cells("ref").Value
        If dg.CurrentRow.Cells("Pass").Value.ToString.Length = 0 Then
            ttppass.Text = "NoPass"
        Else
            If dg.CurrentRow.Cells("Pass").Value.ToString.Trim <> "-" Then
                ttppass.Text = dg.CurrentRow.Cells("Pass").Value.ToString
            Else
                ttppass.Text = "NoPass"
            End If
        End If

        PassPanelProcess("SetPass")
    End Sub

    Private Sub EmailSurveyPassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmailSurveyPassToolStripMenuItem.Click
        ttpid.Text = dg.CurrentRow.Cells(0).Value
        ttkey.Text = dg.CurrentRow.Cells("ref").Value
        If dg.CurrentRow.Cells("Pass").Value.ToString.Length = 0 Then
            ttppass.Text = "NoPass"
        Else
            If dg.CurrentRow.Cells("Pass").Value.ToString.Trim <> "-" Then
                ttppass.Text = dg.CurrentRow.Cells("Pass").Value.ToString
            Else
                ttppass.Text = "NoPass"
            End If
        End If
        MsgBox("i m not done yet ... u forgot to Fix me.")
    End Sub

    Private Sub ChangePassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePassToolStripMenuItem.Click
        ttpid.Text = dg.CurrentRow.Cells(0).Value
        ttkey.Text = dg.CurrentRow.Cells("ref").Value
        If dg.CurrentRow.Cells("Pass").Value.ToString.Length = 0 Then
            ttppass.Text = "NoPass"
        Else
            If dg.CurrentRow.Cells("Pass").Value.ToString.Trim <> "-" Then
                ttppass.Text = dg.CurrentRow.Cells("Pass").Value.ToString
            Else
                ttppass.Text = "NoPass"
            End If
        End If
        PassPanelProcess("PassChange")
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        ttPass.Enabled = CheckBox2.Enabled
        ttPass.Visible = CheckBox2.Enabled
    End Sub



    Private Sub dg_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dg.CellDoubleClick
        setPPPass("Questionary", "Pass")
    End Sub
End Class