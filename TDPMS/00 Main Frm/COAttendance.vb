Public Class COAttendance
    Public T As String = "COAttandance"
    Public F As String() = {"Id", "FormNo", "DT", "Village", "UC", "Name", "Father_Name", "CNIC", "Age", "Occupation", "Status", "Contact_Number", "Stamp"}
    Public X As String() = {"N", "T", "D", "T", "T", "T", "T", "T", "T", "T", "T", "T", "D"}
    Public V(F.Length - 1) As String
    Dim temp() As String = {"", "", "", "", "", ""}
    Private Sub COAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi

        createTable(T, F, X)

        trapTextboxs(Me.ppOF)
        tt20.Text = SpDateKey("FormNo", T, "COAT-")
    End Sub

    Private Sub bbOSave_Click(sender As Object, e As EventArgs) Handles bbOSave.Click
        CheckAllAutoCompletFields(ppOF)
        '{"Id", "FormNo", "DT", "Village", "UC", "Name", "Father_Name", "CNIC", "Age", "Occupation", "Status", "Contact_Number"}
        V(1) = tt20.Text.Trim
        V(2) = tt21.Text.Trim
        V(3) = tt22.Text.Trim
        V(4) = tt23.Text.Trim
        V(5) = tt24.Text.Trim
        V(6) = tt25.Text.Trim
        V(7) = tt26.Text.Trim
        V(8) = tt27.Text.Trim
        V(9) = tt28.Text.Trim
        V(10) = tt29.Text.Trim
        V(11) = tt30.Text.Trim
        V(12) = Now
        Dim c As String

        If bbOSave.Text = "Save" Then
            V(0) = Max(T, "", "Id") + 1
            INS(T, F, CAQ(V, X))
        ElseIf bbOSave.Text = "Update" Then
            V(0) = ttid.Text
            c = "Id=" & V(0)
            UPD(T, C2A(F, CAQ(V, X)), c)
            bbOSave.Text = "Save"
        ElseIf bbOSave.Text = "Edit" Then
            ENB(ppOF, True)

            bbOSave.Text = "Update"
            Exit Sub
        End If

        refresher()
    End Sub
    Sub refresher()
        tt20.Clear()
        tt22.Clear()
        tt23.Clear()
        tt24.Clear()
        tt25.Clear()
        tt26.Clear()
        tt27.Clear()
        tt28.Clear()
        tt29.Clear()
        tt30.Clear()
        bbOSave.Text = "Save"
        tt20.Text = SpDateKey("FormNo", T, "COAT-")
        rememberTake(False)
        dg1.DataSource = GDs(T, "FormNo='" & tt20.Text & "'").Tables(T)
        llRsCount.Text = dg1.RowCount
    End Sub
    Sub rememberTake(Optional take As Boolean = True)
        If CheckBox1.Checked = False Then tt20.Text = ""
        If CheckBox2.Checked = False Then tt21.Text = ""
        If CheckBox3.Checked = False Then tt22.Text = ""
        If CheckBox4.Checked = False Then tt23.Text = ""
        If CheckBox5.Checked = False Then tt28.Text = ""
        If CheckBox6.Checked = False Then tt29.Text = ""


        If take Then
            If CheckBox1.Checked = True Then temp(0) = tt20.Text
            If CheckBox2.Checked = True Then temp(1) = tt21.Text
            If CheckBox3.Checked = True Then temp(2) = tt22.Text
            If CheckBox4.Checked = True Then temp(3) = tt23.Text
            If CheckBox5.Checked = True Then temp(4) = tt28.Text
            If CheckBox6.Checked = True Then temp(5) = tt29.Text
        Else
            If CheckBox1.Checked = True Then tt20.Text = temp(0)
            If CheckBox2.Checked = True Then tt21.Text = temp(1)
            If CheckBox3.Checked = True Then tt22.Text = temp(2)
            If CheckBox4.Checked = True Then tt23.Text = temp(3)
            If CheckBox5.Checked = True Then tt28.Text = temp(4)
            If CheckBox6.Checked = True Then tt29.Text = temp(5)

        End If
    End Sub
    Private Sub tt20_TextChanged(sender As Object, e As EventArgs) Handles tt20.TextChanged
        dg1.DataSource = GDs(T, "FormNo='" & tt20.Text & "'").Tables(T)
        llRsCount.Text = dg1.RowCount
        ENB(ppOF, True)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, CheckBox4.CheckedChanged, CheckBox5.CheckedChanged

        rememberTake()
        If CheckBox1.Checked = False Then tt20.Text = SpDateKey("FormNo", T, "COAT-")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ppPopup.Visible = True
        dg3.DataSource = GDs("Distinct FormNo", T, "1=1 ").Tables(T)
        ENB(ppOF, True)
    End Sub

    Private Sub dg3_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dg3.CellClick
        dt = GDs(T, "FormNo='" & dg3.CurrentRow.Cells("FormNo").Value & "'").Tables(T)
        With dt.Rows(0)
            tt20.Text = .Item("FormNo")
            CheckBox1.Checked = True
            tt21.Text = .Item("DT")
            CheckBox2.Checked = True
            tt22.Text = .Item("Village")
            CheckBox3.Checked = True
            tt23.Text = .Item("UC")
            CheckBox4.Checked = True
            dg1.DataSource = dt
            ppPopup.Visible = False
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dtemp As New DataTable
        dtemp.Columns.Add("SN", GetType(String)) : dtemp.Columns.Add("Name", GetType(String))
        dtemp.Columns.Add("Father_Name", GetType(String)) : dtemp.Columns.Add("CNIC", GetType(String))
        dtemp.Columns.Add("Age", GetType(String)) : dtemp.Columns.Add("Occupation", GetType(String))
        dtemp.Columns.Add("Status", GetType(String)) : dtemp.Columns.Add("ContactNo", GetType(String))
        Dim dtemp1 As New DataTable
        dtemp1.TableName = "All"
        dtemp1.Columns.Add("SN", GetType(String)) : dtemp1.Columns.Add("UC", GetType(String))
        dtemp1.Columns.Add("Village", GetType(String)) : dtemp1.Columns.Add("Name", GetType(String))
        dtemp1.Columns.Add("Father_Name", GetType(String)) : dtemp1.Columns.Add("CNIC", GetType(String))
        dtemp1.Columns.Add("Age", GetType(String)) : dtemp1.Columns.Add("Occupation", GetType(String))
        dtemp1.Columns.Add("Status", GetType(String)) : dtemp1.Columns.Add("ContactNo", GetType(String))
        Dim dtemp2 As New DataTable
        dtemp2.TableName = "GeneralInfo"
        dtemp2.Columns.Add("SN", GetType(String))
        dtemp2.Columns.Add("FormNo", GetType(String))
        dtemp2.Columns.Add("UC", GetType(String))
        dtemp2.Columns.Add("Village", GetType(String))
        dtemp2.Columns.Add("Preview_Entries", GetType(String))
        dtemp2.Columns.Add("Todays_Entries", GetType(String))
        Dim dx As New DataSet

        ' get all distinct forms
        '{"Id", "FormNo", "DT", "Village", "UC", "Name", "Father_Name", "CNIC", "Age", "Occupation", "Status", "Contact_Number"}
        Dim dtq As DataTable = GDs("distinct FormNo", T, "1=1").Tables(T)
        Dim dt2 As DataTable
        Dim ext As String = ""
        For i = 0 To dtq.Rows.Count - 1
            dt2 = GDs(T, "FormNo='" & dtq.Rows(i).Item("FormNo") & "'").Tables(T)
            dtemp.TableName = dt2.Rows(0).Item("FormNo") & "-" & dt2.Rows(0).Item("UC") & "-" & dt2.Rows(0).Item("Village").ToString.Substring(0, 5)
            dtemp2.Rows.Add(i + 1, dt2.Rows(0).Item("FormNo"), dt2.Rows(0).Item("UC"), dt2.Rows(0).Item("Village"), GDs(T, "FormNo='" & dtq.Rows(i).Item("FormNo") & "' AND Stamp<=#" & Now().Date() & "# ").Tables(T).Rows.Count, GDs(T, "FormNo='" & dtq.Rows(i).Item("FormNo") & "' AND Stamp>=#" & Now().Date() & "#  ").Tables(T).Rows.Count)

            For j = 0 To dt2.Rows.Count - 1
                With dt2.Rows(j)
                    dtemp.Rows.Add(j + 1, .Item("Name"), .Item("Father_Name"), .Item("CNIC"), .Item("Age"), .Item("Occupation"), .Item("Status"), .Item("Contact_Number"))
                End With
            Next
            dx.Tables.Add(dtemp)
        Next
        dt2 = GDs(T, "").Tables(T)
        For j = 0 To dt2.Rows.Count - 1
            With dt2.Rows(j)
                dtemp1.Rows.Add(j + 1, dt2.Rows(0).Item("UC"), dt2.Rows(0).Item("Village"), .Item("Name"), .Item("Father_Name"), .Item("CNIC"), .Item("Age"), .Item("Occupation"), .Item("Status"), .Item("Contact_Number"))
            End With
        Next
        dx.Tables.Add(dtemp1)
        dx.Tables.Add(dtemp2)
        Dim x As New Excel4d
        x.MakeXslFile(dx, My.Computer.FileSystem.SpecialDirectories.Desktop & "\", "COAttendance.xls", False, True, False)

    End Sub

    Private Sub bbclose_Click(sender As Object, e As EventArgs) Handles bbclose.Click
        ppPopup.Visible = False
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim dt As DataTable = GDs(T, "Id=" & dg1.CurrentRow.Cells("Id").Value).Tables(T)
        If IsNothing(dt) Then Exit Sub
        If dt.Rows.Count = 0 Then Exit Sub
        '{"Id", "FormNo", "DT", "Village", "UC", "Name", "Father_Name", "CNIC", "Age", "Occupation", "Status", "Contact_Number"}
        With dt.Rows(0)
            tt20.Text = .Item("FormNo")
            tt21.Text = .Item("DT")
            tt22.Text = .Item("Village")
            tt23.Text = .Item("UC")
            tt24.Text = .Item("Name")
            tt25.Text = .Item("Father_Name")
            tt26.Text = .Item("CNIC")
            tt27.Text = .Item("Age")
            tt28.Text = .Item("Occupation")
            tt29.Text = .Item("Status")
            tt30.Text = .Item("Contact_Number")
            ttid.Text = dg1.CurrentRow.Cells("Id").Value
            bbOSave.Text = "Edit"
            ENB(ppOF, False)
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        refresher()
    End Sub
End Class