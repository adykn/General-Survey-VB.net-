Imports System.Windows.Forms

Public Class QuestionsAnsXlsExport
    Dim loc As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"
    Dim ext As String = ".xls"
    Public T9 As String = "GivenAns"
    'Public F9 As String() = {"Id", "Ref", "Hid", "Sn", "Ques", "AnsListid", "TypeAns", "GivenAns"}
    Public TN As String = "QuestionGeneralInformation"
    'Public TF As String() = {"Id", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "c10", "c11"}
    Public T1 As String = "QuestionHead"
    Public T2 As String = "QuestionAns"
    'Public F As String() = {"Id", "Hid", "Sn", "Ques", "TypeOfAns", "AnsList"}
    Dim rowsCount As Integer = 0
    Private Sub QuestionsAnsXlsExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        TextBox1.Text = loc
        rowsCount = GDs("Id,c1 as Ref,c8 as Village", TN, " 1=1 order by Id").Tables(TN).Rows.Count
        refreshEveryThing()
        If dg.Rows.Count <> 0 Then dg.Rows(0).Selected = False
    End Sub
    Sub refreshEveryThing()
        TextBox1.Text = loc
        dg.DataSource = GDs("Id,c1 as Ref,c8 as Village", TN, " 1=1 order by Id").Tables(TN)
        dg.Columns(0).Visible = False
        If dg.Rows.Count <> 0 Then dg.Rows(0).Selected = False
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath & "\"
        Else
            TextBox1.Text = loc
        End If
    End Sub
    Private Sub SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dg.SelectionChanged
        If dg.Rows.Count <> rowsCount Then Exit Sub
        If dg.SelectedRows.Count <> 1 Then Exit Sub
        'dg1.DataSource = GDs("Id,ref,Hid,sn,Ques,GivenAns", T9, " ref='" & dg.CurrentRow.Cells(1).Value & "' order by Sn").Tables(T9)
        'dg1.Columns(0).Visible = False : dg1.Columns(1).Visible = False : dg1.Columns(2).Visible = False
        'dg1.Columns(3).FillWeight = 15
        filldg1("")
    End Sub
    Sub filldg1(condition As String)
        'If dg1.Columns.Count <> 0 Then dg1.Columns.Remove("Id") : dg1.Columns.Remove("ref") : dg1.Columns.Remove("Hid") : dg1.Columns.Remove("sn") : dg1.Columns.Remove("Ques") : dg1.Columns.Remove("GivenAns")
        condition = conditionCheck(condition)
        If dg1.Columns.Count = 0 Then
            dg1.Columns.Add("Id", "Id") ': dg1.Columns.Add("ref", "ref"):dg1.Columns.Add("Hid", "Hid") 
            dg1.Columns.Add("sn", "sn")
            dg1.Columns.Add("Ques", "Ques")
            dg1.Columns.Add("GivenAns", "GivenAns")
            dg1.Columns(0).Visible = False 'dg1.Columns(1).Visible = False : dg1.Columns(2).Visible = False
            dg1.Columns(1).FillWeight = 25
            dg1.Columns(2).FillWeight = 280
        End If
        dg1.Rows.Clear()
        Dim temp As String = ""
        Dim tHid As String = ""
        Dim r As Integer = 0

        Dim h1 As String() = {"ref #", "Enumerator Name", "Recording Agency", "Date of Recording", "District", "Tehsil / Taluka", "Union Council", "Village ", "Province", "Obstruction to Access", "Type of Settlement"}
        dt = GDs(TN, "c1='" & dg.CurrentRow.Cells(1).Value & "' order by Id").Tables(TN)
        dg1.Rows.Add()
        dg1.Rows(0).Cells(0).Value = ""
        dg1.Rows(0).Cells(1).Value = "A"
        dg1.Rows(0).Cells(2).Value = "General Information"
        dg1.Rows(0).DefaultCellStyle.BackColor = Color.Black : dg1.Rows(0).DefaultCellStyle.ForeColor = Color.White
        For i = 1 To dt.Columns.Count - 2
            dg1.Rows.Add()
            r = dg1.Rows.Count - 1
            With dg1.Rows(r)
                .Cells(0).Value = 0
                .Cells(1).Value = "-"
                .Cells(2).Value = h1(i)
                .Cells(3).Value = dt.Rows(0).Item(i)
            End With
        Next

        dt = GDs(T2, "1=1 order by Sn").Tables(T2)
        '{"Id", "Hid", "Sn", "Ques", "TypeOfAns", "AnsList"}
        For I = 0 To dt.Rows.Count - 1
            dg1.Rows.Add()

h2:
            r = dg1.Rows.Count - 1
            With dg1.Rows(r)

                If Not tHid.Trim.Length = 0 Then
                    If tHid <> dt.Rows(I).Item("Hid") Then GoTo H1
                    .Cells(0).Value = dt.Rows(I).Item("Id")
                    .Cells(1).Value = dt.Rows(I).Item("Sn")
                    .Cells(2).Value = dt.Rows(I).Item("Ques")
                    temp = GVa(T9, "GivenAns", "Sn=" & dt.Rows(I).Item("Sn"))
                    If temp = Nothing Then temp = "-" : .DefaultCellStyle.BackColor = Color.Gray : .DefaultCellStyle.ForeColor = Color.White
                    .Cells(3).Value = temp
                Else
H1:
                    tHid = dt.Rows(I).Item("Hid")
                    .Cells(0).Value = 0
                    .Cells(1).Value = dt.Rows(I).Item("Hid")
                    temp = GVa(T1, "c1", "c3='" & dt.Rows(I).Item("Hid") & "'")
                    If temp = Nothing Then temp = "-" : .DefaultCellStyle.BackColor = Color.Blue : .DefaultCellStyle.ForeColor = Color.Wheat
                    .Cells(2).Value = temp
                    .DefaultCellStyle.BackColor = Color.Black : .DefaultCellStyle.ForeColor = Color.White
                    dg1.Rows.Add()
                    GoTo h2
                End If

            End With
        Next
        If dg1.Rows.Count <> 0 Then dg1.Rows(0).Selected = False
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim x As New Excel4d
        If dg1.RowCount = 0 Then Exit Sub
        x.MakeXslFile(dgridViewTods(dg1), TextBox1.Text, "Survey" & ext, False, True, False)
    End Sub
    Dim dx As New DataSet
    Private Function dgridViewTods(ByVal dgv As DataGridView) As DataSet

        Try
            ' Add Table
            If dx.Tables.Contains("AllSurveyQuestion") Then dx.Tables.Remove("AllSurveyQuestion")

            dx.Tables.Add("AllSurveyQuestion")

            ' Add Columns
            Dim col As DataColumn
            For Each dgvCol In dgv.Columns
                col = New DataColumn(dgvCol.Name)
                dx.Tables("AllSurveyQuestion").Columns.Add(col)
            Next

            'Add Rows from the datagridview
            Dim row As DataRow
            Dim colcount As Integer = dgv.Columns.Count - 1
            For i As Integer = 0 To dgv.Rows.Count - 1
                row = dx.Tables("AllSurveyQuestion").Rows.Add
                For Each column In dgv.Columns
                    row.Item(column.Index) = dgv.Rows.Item(i).Cells(column.Index).Value
                Next
            Next

            Return dx

        Catch ex As Exception

            MsgBox("CRITICAL ERROR : Exception caught while converting dataGridView to DataSet (dgvtods).. " & Chr(10) & ex.Message)
            Return Nothing
        End Try
    End Function
    Sub clrDg()
        If dg1.Rows.Count <> 0 Then dg1.Rows.Clear()
        If dg1.ColumnCount <> 0 Then dg1.Columns.Clear()

    End Sub
    'Dim loc As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"
    'Dim ext As String = ".xls"
    'Public T9 As String = "GivenAns"
    ''Public F9 As String() = {"Id", "Ref", "Hid", "Sn", "Ques", "AnsListid", "TypeAns", "GivenAns"}
    'Public TN As String = "QuestionGeneralInformation"
    ''Public TF As String() = {"Id", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "c10", "c11"}
    'Public T1 As String = "QuestionHead"
    'Public T2 As String = "QuestionAns"
    ''Public F As String() = {"Id", "Hid", "Sn", "Ques", "TypeOfAns", "AnsList"}
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        clrDg()
        Dim dt2 As DataTable
        dt = GDs("c1,c8 ", TN, " 1=1 order by c1").Tables(TN)
        dg1.Columns.Add("Sn", "Sn")
        dg1.Columns.Add("Question", "Question")
        For i = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                dg1.Columns.Add(.Item("c1"), .Item("c1"))
            End With
        Next


        dg1.Rows.Add()
        dt = GDs("c1,c8 ", TN, " 1=1 order by c1").Tables(TN)
        With dg1.Rows(dg1.Rows.Count - 1)
            For j = 0 To dt.Rows.Count - 1
                .Cells(dt.Rows(j).Item("c1")).Value = dt.Rows(j).Item("c8")
            Next
        End With


        dt = GDs(T2, " TypeOfAns<>3 order by Sn").Tables(T2)
        For i = 0 To dt.Rows.Count - 1
            dg1.Rows.Add()
            With dg1.Rows(dg1.Rows.Count - 1)
                .Cells(0).Value = dt.Rows(i).Item("Sn")
                .Cells(1).Value = dt.Rows(i).Item("Ques")
                dt2 = GDs(T9, " Sn = " & dt.Rows(i).Item("Sn") & "  order by Sn").Tables(T9)
                For j = 0 To dt2.Rows.Count - 1
                    .Cells(dt2.Rows(j).Item("ref")).Value = dt2.Rows(j).Item("GivenAns")
                Next
            End With
        Next


    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        clrDg()
        CheckBox2_CheckedChanged(sender, e)
        Try
            Dim tbname As String = ""
            Dim row As DataRow
            Dim colcount As Integer = dg1.Columns.Count - 1

            For rowIndex = 0 To dg1.Rows.Count - 2

                tbname = dg1.Rows(rowIndex + 1).Cells(0).Value.ToString
                ' Add Table
                If dx.Tables.Contains(tbname) Then dx.Tables.Remove(tbname)

                dx.Tables.Add(tbname)


                ' Add Columns
                Dim col As DataColumn
                For Each dgvCol In dg1.Columns
                    col = New DataColumn(dgvCol.Name)
                    If dx.Tables(tbname).Columns.Contains(dgvCol.Name) Then dx.Tables(tbname).Columns.Remove(dgvCol.name)
                    dx.Tables(tbname).Columns.Add(col)
                Next

                'Add Rows Header Text

                'row = dx.Tables(tbname).Rows.Add
                'For c = 0 To dg1.Columns.Count - 1
                '    row.Item(c) = dg1.Columns(c).HeaderText
                'Next

                'row = dx.Tables(tbname).Rows.Add
                row = dx.Tables(tbname).Rows.Add
                For c = 1 To dg1.Rows(0).Cells.Count - 1
                    row.Item(c) = dg1.Rows(0).Cells(c).Value
                Next

                'Add Rows from the datagridview
                row = dx.Tables(tbname).Rows.Add
                For c = 0 To dg1.Rows(rowIndex + 1).Cells.Count - 1
                    row.Item(c) = dg1.Rows(rowIndex + 1).Cells(c).Value
                Next


            Next
        Catch ex As Exception



        End Try
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try

            'dt = select all questionAnsGiven that have type 3
            'dt2 = select all preAns that have preAnslist = dt.value

            '                 Prority	Ref-15241101	Ref-15241102	Ref-15241103
            'Borrowing/Credits	1		Yes	
            'Food Aid	        2		Yes	
            'Own Stock	        2	    Yes	               Yes	
            'Purchase	        3	    Yes	               Yes	            Yes
            'Don't know	        1		Yes
            Dim tbname As String = ""
            Dim row As DataRow
            Dim dz As New DataSet

            dz = GDs(T2, " TypeOfAns = 3 order by Sn")

            For j = 0 To dz.Tables(T2).Rows.Count - 1
                tbname = dz.Tables(T2).Rows(j).Item("Sn").ToString
                ' Add Table
                If dx.Tables.Contains(tbname) Then dx.Tables.Remove(tbname)
                dx.Tables.Add(tbname)

                ' Add Columns

                Dim col As DataColumn
                dx.Tables(tbname).Columns.Add("PreAns")
                dx.Tables(tbname).Columns.Add("Priority")
                dz = GDs(T9, " Sn=" & dz.Tables(T2).Rows(j).Item("Sn") & "")
                Dim tempName As String = ""
                For i = 0 To dz.Tables(T9).Rows.Count - 1
                    tempName = dz.Tables(T9).Rows(i).Item("Ref").ToString
                    col = New DataColumn(tempName)
                    If dx.Tables(tbname).Columns.Contains(tempName) Then dx.Tables(tbname).Columns.Remove(tempName)
                    dx.Tables(tbname).Columns.Add(tempName)
                Next
                ' Add Row
                row = dx.Tables(tbname).Rows.Add
                row.Item(0) = dz.Tables(T2).Rows(j).Item("Ques")
                For c = 0 To dz.Tables(T9).Rows.Count - 1
                    row.Item(c + 2) = GVa(TN, "c8", "c1='" & dz.Tables(T9).Rows(c).Item("ref") & "'")
                Next
                '' Add pre Ans
                dz = GDs("Answers", " AnsTypeRef=" & dz.Tables(T2).Rows(j).Item("AnsList") & " order by Sn")
                For i = 0 To dz.Tables("Answers").Rows.Count - 1
                    row = dx.Tables(tbname).Rows.Add
                    row.Item(0) = "   - " & dz.Tables("Answers").Rows(i).Item("Answer")
                    row.Item(1) = GDs(T9, "GivenAns like '%" & dz.Tables("Answers").Rows(i).Item("Answer") & "%' and sn=" & tbname & "").Tables(T9).Rows.Count
                Next
                '' Add Given ans
                Dim tempVal As String() = {"", "", "", ""}
                dz = GDs(T9, " Sn=" & dz.Tables(T2).Rows(j).Item("Sn") & "")
                For i = 0 To dz.Tables(T9).Rows.Count - 1
                    tempName = dz.Tables(T9).Rows(i).Item("Ref")
                    For k = 1 To dx.Tables(tbname).Rows.Count - 1
                        tempVal(0) = dx.Tables(tbname).Rows(k).Item(0).ToString
                        tempVal(0) = tempVal(0).Substring(5, tempVal(0).Length - 5)
                        tempVal(1) = tempName
                        tempVal(2) = GDx(T9, "GivenAns like '%" & tempVal(0) & "%' and Ref='" & tempVal(1) & "'").Tables(T9).Rows.Count
                        tempVal(3) = IIf(tempVal(2) <> 0, "Yes", "-")
                        dx.Tables(tbname).Rows(k).Item(tempName) = tempVal(3).ToString
                    Next
                Next
            Next


            Dim x As New Excel4d

            x.MakeXslFile(dx, TextBox1.Text, "Survey" & ext, False, True, False)


        Catch ex As Exception

        End Try
    End Sub

End Class
