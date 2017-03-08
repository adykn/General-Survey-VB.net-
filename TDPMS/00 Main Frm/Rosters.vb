Public Class Rosters

    Public T As String = "Roster"
    Public F As String() = {"Id", "FormNo", "Participants_Name", "Fathers_Name", "Occupation", "Status", "Orgin_Of_IDP", "Contact_No"}
    Public X As String() = {"N", "T", "T", "T", "T", "T", "T", "T"}
    Public V(F.Length - 1) As String

    Private Sub Rosters_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        createTable(T, F, X)

        refresher()
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles tt25.CheckedChanged
        If tt25.Checked = True Then tt25b.Checked = Not tt25.Checked
    End Sub
    Private Sub tt25b_CheckedChanged(sender As Object, e As EventArgs) Handles tt25b.CheckedChanged
        If tt25b.Checked = True Then tt25.Checked = Not tt25b.Checked
    End Sub
    Sub status()



    End Sub
    Sub refresher()
        trapTextboxs(Me.Panel2)
        Clr(ppOF)
        tt27.Clear()
        tt20.Text = FormXmdi.llref.Text
        dg1.DataSource = GDs(T, "FormNo='" & tt20.Text & "'").Tables(T)
        llRsCount.Text = dg1.RowCount
        llHostNo.Text = GDs(T, " Status='Host'").Tables(T).Rows.Count
        llidpNo.Text = GDs(T, " Status='IDP'").Tables(T).Rows.Count
        lltotal.Text = Val(llHostNo.Text) + Val(llidpNo.Text)
        status()

        tt22.Focus()
    End Sub

    Private Sub bbOSave_Click(sender As Object, e As EventArgs) Handles bbOSave.Click
        CheckAllAutoCompletFields(Panel2)
        Dim c As String = ""
        V(1) = tt20.Text.Trim
        V(2) = tt22.Text.Trim
        V(3) = tt23.Text.Trim
        V(4) = tt24.Text.Trim
        V(5) = IIf(tt25.Checked = True, tt25.Text.Trim, tt25b.Text)
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

        refresher()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            '{"Id", "FormNo", "Participants_Name", "Fathers_Name", 
            ' "Occupation", "Status", "Orgin_Of_IDP", "Contact_No"}

            Dim dt1 As New DataTable
            dt1.TableName = "All"

            dt1.Columns.Add("FormNo", GetType(String)) : dt1.Columns.Add("UC", GetType(String))
            dt1.Columns.Add("Village", GetType(String)) : dt1.Columns.Add("Tehsil", GetType(String))
            dt1.Columns.Add("Participants_Name", GetType(String)) : dt1.Columns.Add("Fathers_Name", GetType(String))
            dt1.Columns.Add("Occupation", GetType(String)) : dt1.Columns.Add("Status", GetType(String))
            dt1.Columns.Add("Orgin_Of_IDP", GetType(String)) : dt1.Columns.Add("Contact_No", GetType(String))
            Dim dt2 As New DataTable
            dt2.TableName = "1"
            dt2.Columns.Add("FormNo", GetType(String)) : dt2.Columns.Add("UC", GetType(String))
            dt2.Columns.Add("Village", GetType(String)) : dt2.Columns.Add("Tehsil", GetType(String))
            dt2.Columns.Add("Participants_Name", GetType(String)) : dt2.Columns.Add("Fathers_Name", GetType(String))
            dt2.Columns.Add("Occupation", GetType(String)) : dt2.Columns.Add("Status", GetType(String))
            dt2.Columns.Add("Orgin_Of_IDP", GetType(String)) : dt2.Columns.Add("Contact_No", GetType(String))



            Dim dxx As New DataSet
            Dim dt3 As DataTable
            Dim dt33 As DataTable
            Dim dtx As New DataTable

            dt33 = GDs(T, "").Tables(T)
            For j = 0 To dt33.Rows.Count - 1
                With dt33.Rows(j)
                    dtx = GDs("QuestionGeneralInformation", "FormNo='" & .Item("FormNo") & "'").Tables("QuestionGeneralInformation")
                    dt1.Rows.Add(.Item("FormNo"), dtx.Rows(0).Item("UC"), dtx.Rows(0).Item("Village"), dtx.Rows(0).Item("Tehsil"), .Item("Participants_Name"), .Item("Fathers_Name"),
                                  .Item("Occupation"), .Item("Status"), .Item("Orgin_Of_IDP"),
                                 .Item("Contact_No"))

                End With
            Next



            dt3 = GDs("distinct FormNo", T, "1=1").Tables(T)
            '{"Id", "FormNo", "Participants_Name", "Fathers_Name", 
            ' "Occupation", "Status", "Orgin_Of_IDP", "Contact_No"}
            Dim c As Int16 = dt3.Rows.Count
            Dim formCount(c - 1) As String
            Try
                For i = 0 To dt3.Rows.Count - 1
                    dt33 = GDs(T, "FormNo='" & dt3.Rows(i).Item("FormNo") & "'").Tables(T)
                    formCount(i) = dt3.Rows(i).Item("FormNo") & ":" & dt33.Rows.Count
                    dt2.Rows.Clear()
                    dt2.TableName = dt3.Rows(i).Item("FormNo")
                    For j = 0 To dt33.Rows.Count - 1
                        With dt33.Rows(j)
                            dtx = GDs("QuestionGeneralInformation", "FormNo='" & .Item("FormNo") & "'").Tables("QuestionGeneralInformation")
                            dt2.Rows.Add(.Item("FormNo"), dtx.Rows(0).Item("UC"), dtx.Rows(0).Item("Village"), dtx.Rows(0).Item("Tehsil"), .Item("Participants_Name"), .Item("Fathers_Name"),
                                  .Item("Occupation"), .Item("Status"), .Item("Orgin_Of_IDP"),
                                 .Item("Contact_No"))
                        End With
                    Next
                    Dim dump As New DataTable
                    dump = dt2.Copy()
                    dxx.Tables.Add(dump)
                Next
            Catch ex As Exception

            End Try


            Dim temp() As Int16 = {0, 0, 0, 0, 0}
            temp(0) = GDs(T, " Status='Host'").Tables(T).Rows.Count
            temp(1) = GDs(T, " Status='IDP'").Tables(T).Rows.Count
            temp(2) = temp(0) + temp(1)
            temp(3) = c
            Dim dt4 As New DataTable
            dt4.Columns.Add("Field", GetType(String))
            dt4.Columns.Add("Value", GetType(String))
            dt4.Columns.Add("EntryPForm", GetType(String))
            dt4.Columns.Add("UC", GetType(String))
            dt4.Columns.Add("Village", GetType(String))
            dt4.Columns.Add("Tehsil", GetType(String))
            dt4.Rows.Add("Total Participants:", temp(2))
            dt4.Rows.Add("Total IDPs:", temp(1))
            dt4.Rows.Add("Total HOST:", temp(0))
            dt4.Rows.Add("Total Forms:", temp(3))

            For i = 0 To formCount.Count - 1
                Dim str() As String = formCount(i).Split(":")

                dtx = GDs("QuestionGeneralInformation", "FormNo='" & str(0) & "'").Tables("QuestionGeneralInformation")
                With dtx.Rows(0)
                    dt4.Rows.Add("", str(0), str(1), .Item("UC"), .Item("Village"), .Item("Tehsil"))
                End With
            Next
            dt4.TableName = "Calculations"

            dxx.Tables.Add(dt1)
            dxx.Tables.Add(dt4)


            'http://stackoverflow.com/questions/9813488/excel-vba-create-hyperlink-to-another-sheet
            Dim x As New Excel4d
            x.MakeXslFile(dxx, My.Computer.FileSystem.SpecialDirectories.Desktop & "\", "Roaster.xls", False, True, False)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class