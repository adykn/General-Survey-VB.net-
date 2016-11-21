Public Class ShowGivenAns
    Public T9 As String = "GivenAns"
    'Public F9 As String() = {"Id", "Ref", "Hid", "Sn", "Ques", "AnsListid", "TypeAns", "GivenAns"}
    Public TN As String = "QuestionGeneralInformation"
    'Public TF As String() = {"Id", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "c10", "c11"}
    Public T1 As String = "QuestionHead"
    Public T2 As String = "QuestionAns"

    Private Sub ShowGivenAns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        dg.DataSource = GDs("c1,c6,c8", TN, "1=1 order by c1").Tables(TN)

        dg1.DataSource = GDs("Id,c3,c1,c2", T1, " c3<>'A' order by c3").Tables(T1)
        dg1.Columns(0).Visible = False : dg1.Columns(1).FillWeight = 20 : dg1.Columns(3).Visible = False

        filldg(" 1=1 ")

    End Sub

    Sub filldg(condition As String)
        dg2.DataSource = GDs("ref,hid, Sn,Ques,GivenAns", T9, condition & " order by Sn").Tables(T9)
        dg2.Columns(0).Visible = False : dg2.Columns(1).Visible = False : dg2.Columns(2).FillWeight = 10
        dg2.Columns(3).FillWeight = 180
    End Sub

    Private Sub dg_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellClick
        If dg.SelectedRows.Count <> 1 Then Exit Sub
        filldg(" hid='" & dg1.CurrentRow.Cells(0).Value & "' and  ref='" & dg.CurrentRow.Cells(0).Value & "' ")
    End Sub

    Private Sub dg1_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dg1.CellClick
        If dg1.SelectedRows.Count <> 1 Then Exit Sub
        filldg(" hid='" & dg1.CurrentRow.Cells(0).Value & "' and  ref='" & dg.CurrentRow.Cells(0).Value & "' ")
    End Sub

    Private Sub dg_EditingControlShowing(sender As Object, e As Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dg.EditingControlShowing
        MsgBox(dg.CurrentRow.Index)
    End Sub
End Class