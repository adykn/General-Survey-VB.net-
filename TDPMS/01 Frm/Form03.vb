Imports System.Windows.Forms

Public Class Form03
    Dim t As String = N3
    Dim frmNum As Double = "3"
    Dim c As String = "Ref='" & FormXmdi.llref.Text & "'"
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        createTable(N3, F3, S3)
        Me.MdiParent = FormXmdi
        bbsave.Enabled = False
        setForm(frmNum)
        If Not FormXmdi.llref.Text = "..." Then bbsave.Enabled = True
        GetSavedData()
        CreateNav(frmNum, ppNav)
    End Sub
    Sub GetSavedData()

        If EXV(t, c) Then
            filldg1(dg, frmNum, GDs(t, c & " order by num").Tables(t))
            bbsave.Text = "Edit"
        Else
            filldg(dg, frmNum)
            bbsave.Text = "Save"
        End If
    End Sub
    Sub setForm(idd As String)
        dt = GDs("Labels", "Id=" & idd).Tables("Labels")
        llheadtext.Text = dt.Rows(0).Item("Title")
        llheadtext.Location = New Point(10, 10)
        llSn.Text = idd & ".1"
        'llSn.Location = New Point(110, 105)
        lldetail.Text = dt.Rows(0).Item("Detail")
        'lldetail.Location = New Point(140, 105)
        Me.Text = dt.Rows(0).Item("Title")
    End Sub
    Private Sub bbSave_Click(sender As Object, e As EventArgs) Handles bbsave.Click
        If FormXmdi.llref.Text = "..." Then Exit Sub
        DgAutoCompletInserter(dg, frmNum)
        Dim f As String() = F3
        Dim v As String() = V3
        Dim c As String
        Dim cnd As String = "Ref='" & FormXmdi.llref.Text & "'"

        If bbsave.Text = "Save" Then

            For i = 0 To dg.Rows.Count - 1
                With dg.Rows(i)
                    If .Cells(2).Value.ToString.Length = 0 Then Continue For
                    '{"Id", "Ref", "Num", "Date_", "Title", "Value"}
                    v(0) = Max(t, "", "Id") + 1
                    v(1) = FormXmdi.llref.Text
                    v(2) = .Cells(1).Value
                    v(3) = Now.Date
                    v(4) = .Cells(2).Value
                    v(5) = .Cells(3).Value

                End With

                INS(t, f, CAQ(v, S3))
            Next

            bbsave.Text = "Edit"
        ElseIf bbsave.Text = "Update" Then

            For i = 0 To dg.Rows.Count - 1
                With dg.Rows(i)
                    If .Cells(2).Value.ToString.Length = 0 Then Continue For
                    '{"Id", "Ref", "Num", "Date_", "Title", "Value"}
                    v(0) = .Cells(0).Value
                    v(1) = FormXmdi.llref.Text
                    v(2) = .Cells(1).Value
                    v(3) = Now.Date
                    v(4) = .Cells(2).Value
                    v(5) = .Cells(3).Value

                    c = "Id=" & .Cells(0).Value & ""
                End With
                UPD(t, C2A(f, CAQ(v, S3)), c)
            Next
            bbsave.Text = "Edit"
        ElseIf bbsave.Text = "Edit" Then

            bbsave.Text = "Update"
            Exit Sub
        End If
        GetSavedData()
    End Sub
    Sub filldg1(dgg As DataGridView, FormVal As String, dtt As DataTable)

        dt = dtt

        Dim dt2 As New DataTable
        dt2 = GDs(TNq, "FormRef=" & FormVal & "").Tables(TNq)
        dgsetting(dgg)
        Try
            For i = 0 To dt.Rows.Count - 1
                With dgg
                    .Rows.Add()
                    '{"Id", "Ref", "Num", "Date_", "Title", "Valu"}
                    .Rows(i).Cells(0).Value = dt.Rows(i).Item("Id")
                    .Rows(i).Cells(1).Value = dt.Rows(i).Item("Num")
                    .Rows(i).Cells(2).Value = dt.Rows(i).Item("Title")
                    .Rows(i).Cells(2).ReadOnly = IIf(dt2.Rows(i).Item("Question").ToString.Length = 0, False, True)
                    If Not dt2.Rows(i).Item("AnsTypeRef") = 0 Then dgTextboxToCombo(dgg, i, 3, GDs("Answer", TNa, "AnsTypeRef='" & dt2.Rows(i).Item("AnsTypeRef") & "'").Tables(TNa))
                    .Rows(i).Cells(3).Value = dt.Rows(i).Item("valu")

                End With
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
        Dim c As String = "Ref='" & FormXmdi.llref.Text.Trim & "'"
        ClearRecord(t, c, dg, frmNum)
        GetSavedData()
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dg.EditingControlShowing
        'declare for a new textbox
        Dim txt As New TextBox
        dt = GDs(TbAutoCompName, "Field='dg'").Tables(TbAutoCompName)
        If dt.Rows.Count = 0 Or IsNothing(dt) Then Exit Sub

        For Each r As DataRow In dt.Rows 'get a collection of rows that belongs to this table
            'the control shown to the user for editing the selected cell value
            If TypeOf e.Control Is TextBox Then
                txt = e.Control
                'adding the specific row of the table in the AutoCompleteCustomSource of the textbox
                txt.AutoCompleteCustomSource.Add(r.Item("Txt").ToString)
                txt.AutoCompleteMode = AutoCompleteMode.Suggest
                txt.AutoCompleteSource = AutoCompleteSource.CustomSource
            End If
        Next

    End Sub
End Class