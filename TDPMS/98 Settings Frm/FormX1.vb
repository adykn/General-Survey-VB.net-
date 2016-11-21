Public Class FormX1

    Private Sub Form0_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        filldg()
        setForm(0)
    End Sub
    Sub filldg()
        dg.DataSource = GDs("Labels", " 1=1 order by Id").Tables("Labels")
        dg.Columns(0).FillWeight = 20
        dg.Columns(1).FillWeight = 20
        dg.Columns(2).FillWeight = 140
    End Sub
    Sub setForm(idd As String)
        Try
            dt = GDs("Labels", "Id=" & idd).Tables("Labels")
            llheadtext.Text = dt.Rows(0).Item("Title")
            llheadtext.Location = New Point(10, 10)
            llSn.Text = idd & ".1"
            'llSn.Location = New Point(110, 105)
            lldetail.Text = dt.Rows(0).Item("Detail")
            'lldetail.Location = New Point(140, 105)
            Me.Text = dt.Rows(0).Item("Title")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub bbSave_Click(sender As Object, e As EventArgs) Handles bbSave.Click
        Dim t As String = TN2
        Dim f As String() = TF2
        Dim v As String() = TV2
        Dim s As String = ""
        Dim c As String = ""

        v(0) = TextBox1.Text.Trim
        v(1) = "'" & TextBox2.Text.Trim & "'"
        v(2) = "'" & RichTextBox1.Text.Trim & "'"

        If bbSave.Text = "Save" Then
            INS(t, f, v)
        ElseIf bbSave.Text = "Update" Then
            UPD(t, s, c)
        End If
        Clr(Panel1)
        filldg()
    End Sub

End Class