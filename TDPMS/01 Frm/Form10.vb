Imports System.Windows.Forms

Public Class Form10
    Dim t As String = N10
    Dim f As String() = F10
    Dim x As String() = S10
    Dim frmNum As Double = "10"
    Dim cnd As String = "Ref='" & FormXmdi.llref.Text & "'"
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        createTable(t, f, x)
        Me.MdiParent = FormXmdi
        bbSave.Enabled = False
        setForm(frmNum)
        If Not FormXmdi.llref.Text = "..." Then bbSave.Enabled = True
        GetSavedData()
        CreateNav(frmNum, ppNav)
    End Sub
    Sub GetSavedData()

        If EXV(t, cnd) Then
            filldg1(dg, frmNum, GDs(t, cnd & " order by num ").Tables(t))
            bbSave.Text = "Edit"
        Else
            filldg(dg, frmNum)
            bbSave.Text = "Save"
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
    Sub filldg1(dgg As DataGridView, FormVal As String, dtt As DataTable)

        dt = dtt
        Dim dt2 As New DataTable
        dt2 = GDs(TNq, "FormRef=" & FormVal & " order by sn").Tables(TNq)
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
                    .Rows(i).Cells(3).Value = dt.Rows(i).Item("Valu")
                End With

            Next
        Catch ex As Exception

        End Try

    End Sub
    Private Sub bbSave_Click(sender As Object, e As EventArgs) Handles bbSave.Click
        If FormXmdi.llref.Text = "..." Then Exit Sub

        Dim v As String() = V10
        Dim c As String
        DgAutoCompletInserter(dg, frmNum)

        If bbSave.Text = "Save" Then

            For i = 0 To dg.Rows.Count - 1
                With dg.Rows(i)

                    Try
                        If .Cells(3).Value.ToString.Length = 0 Then Continue For
                    Catch ex As Exception
                        Continue For
                    End Try
                    '{"Id", "Ref", "Num", "Date_", "Title", "Valu"}
                    v(0) = Max(t, "", "Id") + 1
                    v(1) = FormXmdi.llref.Text
                    v(2) = .Cells(1).Value
                    v(3) = Now.Date
                    v(4) = .Cells(2).Value
                    v(5) = .Cells(3).Value

                End With

                INS(t, f, CAQ(v, x))
            Next

            bbSave.Text = "Edit"
        ElseIf bbSave.Text = "Update" Then

            For i = 0 To dg.Rows.Count - 1
                With dg.Rows(i)
                    Try
                        If .Cells(3).Value.ToString.Length = 0 Then Continue For
                    Catch ex As Exception
                        Continue For
                    End Try
                    '{"Id", "Ref", "Num", "Date_", "Title", "Valu"}
                    v(0) = .Cells(0).Value
                    v(1) = FormXmdi.llref.Text
                    v(2) = .Cells(1).Value
                    v(3) = Now.Date
                    v(4) = .Cells(2).Value
                    v(5) = .Cells(3).Value

                    c = "Id=" & .Cells(0).Value & ""
                End With
                UPD(t, C2A(f, CAQ(v, x)), c)
            Next
            bbSave.Text = "Edit"
        ElseIf bbSave.Text = "Edit" Then

            bbSave.Text = "Update"
            Exit Sub
        End If
        GetSavedData()
    End Sub

    Private Sub UltraButton1_Click(sender As Object, e As EventArgs) Handles UltraButton1.Click
          ClearRecord(t, cnd, dg, frmNum)
        GetSavedData()
        bbSave.Text = "Save"
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