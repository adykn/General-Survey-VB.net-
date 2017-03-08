Public Class VillageVisRoster
    Public T As String = "VillageVisRoster"
    Public F As String() = {"Id", "FormNo", "Village_Name", "Total_Popul", "Host", "TDPs", "Focal_Per_Name", "Contact_No"}
    Public X As String() = {"N", "T", "T", "T", "T", "T", "T", "T"}
    Public V(F.Length - 1) As String
    Private Sub VillageVisRoster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        createTable(T, F, X)

        refresher()
    End Sub
    Sub refresher()

        trapTextboxs(Me.Panel2)
        tt20.Text = FormXmdi.llref.Text
        dg1.DataSource = GDs(T, "FormNo='" & tt20.Text & "'").Tables(T)
        llRsCount.Text = GDs("sum(Total_Popul)", T, "FormNo='" & tt20.Text & "'").Tables(T).Rows(0).Item(0)
        llHostNo.Text = GDs("sum(host)", T, "FormNo='" & tt20.Text & "'").Tables(T).Rows(0).Item(0)
        llidpNo.Text = GDs("sum(TDPs)", T, "FormNo='" & tt20.Text & "'").Tables(T).Rows(0).Item(0)
        lltotal.Text = llHostNo.Text + llidpNo.Text

        tt22.Focus()
    End Sub

    Private Sub bbOSave_Click(sender As Object, e As EventArgs) Handles bbOSave.Click
        CheckAllAutoCompletFields(Panel1)
        Dim c As String = ""
        V(1) = tt20.Text.Trim
        V(2) = tt22.Text.Trim
        V(3) = tt23.Text.Trim
        V(4) = tt24.Text.Trim
        V(5) = tt25.Text.Trim
        V(6) = tt26.Text.Trim
        V(7) = tt27.Text.Trim




        If bbOSave.Text = "Save" Then
            V(0) = Max(T, "", "Id") + 1
            INS(T, F, CAQ(V, X))
        ElseIf bbOSave.Text = "Update" Then
            V(0) = ttid.Text
            c = "Id = " & ttid.Text
            UPD(T, C2A(F, CAQ(V, X)), c)
            bbOSave.Text = "Save"
        ElseIf bbOSave.Text = "Edit" Then
            ENB(Panel2, True)
            bbOSave.Text = "Update"
            Exit Sub
        End If
        Clr(ppOF)
        refresher()
    End Sub
End Class