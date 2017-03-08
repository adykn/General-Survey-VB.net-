Imports System.Windows.Forms

Public Class VOCrud
    Public T As String = "CW"
    Public F As String() = {"Id", "FormNo", "Organization_Name", "UC", "Village", "Tehsil", "District", "Contact_Person", "Contact_Person_Number", "DT"}
    Public X As String() = {"N", "T", "T", "T", "T", "T", "T", "T", "T", "D"}
    Public V(F.Length - 1) As String
    Public T2 As String = "CWM"
    Public F2 As String() = {"Id", "SN", "Ref", "Name", "Designation", "Village", "Status", "CNIC", "Contact"}
    Public X2 As String() = {"N", "N", "N", "T", "T", "T", "T", "T", "T"}
    Public V2(F2.Length - 1) As String

    Private Sub VOCrud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        createTable(T, F, X) : createTable(T2, F2, X2) : createTable(TbAutoCompName, TbAutoCompFeilds, TbAutoCompSyntax)
        trapTextboxs(Me.ppMF) : trapTextboxs(Me.ppOF)
        refresher()
    End Sub
    Sub refresher()
        Dim dt As DataTable
        dt = GDs("Id,FormNo, Organization_Name, UC, Village, Tehsil, District", T, "").Tables(T)
        dt.Columns.Add("Participants", GetType(String))
        For i = 0 To dt.Rows.Count - 1
            With dt.Rows(i)
                .Item("Participants") = GDs(T2, "ref=" & .Item("Id")).Tables(T2).Rows.Count
            End With
        Next

        dg1.DataSource = dt
        dg1.Columns(0).Visible = False

        dt = GDs("Id,Name,Designation,Village,Status,CNIC,Contact", T2, "ref=" & Val(ttref.Text)).Tables(T2)
        '{"Id", "SN", "Ref", "Name", "Designation", "Village", "Status", "CNIC", "Contact"}
        dg2.DataSource = dt
        dg2.Columns(0).Visible = False
        tt20.Text = SpDateKey("FormNo", T, "VOF-")
    End Sub

#Region "Organization Formation"
    Private Sub bbOSave_Click(sender As Object, e As EventArgs) Handles bbOSave.Click
        CheckAllAutoCompletFields(ppOF)
        '{"Id", "FormNo", "Organization_Name", "UC", "Village", "Tehsil", "District", "Contact_Person", "Contact_Person_Number", "DT"}
        V(1) = tt20.Text.Trim
        V(2) = tt21.Text.Trim
        V(3) = tt22.Text.Trim
        V(4) = tt23.Text.Trim
        V(5) = tt24.Text.Trim
        V(6) = tt25.Text.Trim
        V(7) = tt26.Text.Trim
        V(8) = tt27.Text.Trim
        V(9) = tt28.Text.Trim
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
        Clr(ppOF)
        refresher()


    End Sub
    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        ppOF.BringToFront()
        tt20.Focus()
    End Sub
    Private Sub AddMembersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddMembersToolStripMenuItem.Click
        ppMF.BringToFront()
        ENB(ppMF, False)
        tt38.Enabled = True
        tt38.Focus()
        ttref.Text = dg1.CurrentRow.Cells("Id").Value
        tt38.Text = dg1.CurrentRow.Cells("FormNo").Value
        bbFetch.PerformClick()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        MsgBox("This Function is disabled")
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        '{"Id", "FormNo", "Organization_Name", "UC", "Village", "Tehsil", "District", "Contact_Person", "Contact_Person_Number", "DT"}
        Dim dt As DataTable = GDs(T, "Id=" & dg1.CurrentRow.Cells(0).Value).Tables(T)
        With dt.Rows(0)
            ttid.Text = .Item("Id")
            tt20.Text = .Item("FormNo")
            tt21.Text = .Item("Organization_Name")
            tt22.Text = .Item("UC")
            tt23.Text = .Item("Village")
            tt24.Text = .Item("Tehsil")
            tt25.Text = .Item("District")
            tt26.Text = .Item("Contact_Person")
            tt27.Text = .Item("Contact_Person_Number")
            tt28.Text = .Item("Dt")
        End With
        bbOSave.Text = "Edit"
    End Sub
#End Region
#Region "Member Formation"
    Private Sub bbMSave_Click(sender As Object, e As EventArgs) Handles bbMSave.Click

        CheckAllAutoCompletFields(ppMF)
        If ttref.Text.Length = 0 Then ENB(ppMF, False) : Exit Sub
        '{"Id", "SN", "Ref", "Name", "Designation", "Village", "Status", "CNIC", "Contact"}
        V2(1) = Max(T2, "Ref=" & ttref.Text, "SN") + 1
        V2(2) = ttref.Text.Trim
        V2(3) = tt30.Text.Trim
        V2(4) = tt31.Text.Trim
        V2(5) = tt32.Text.Trim
        V2(6) = tt33.Text.Trim
        V2(7) = tt34.Text.Trim
        V2(8) = tt35.Text.Trim
        Dim c As String

        If bbMSave.Text = "Save" Then
            V2(0) = Max(T2, "", "Id") + 1
            INS(T2, F2, CAQ(V2, X2))
        ElseIf bbMSave.Text = "Update" Then
            V2(0) = ttid2.Text
            c = "Id=" & V2(0)
            UPD(T2, C2A(F2, CAQ(V2, X2)), c)
            bbMSave.Text = "Save"
        ElseIf bbMSave.Text = "Edit" Then
            ENB(ppMF, True)

            bbMSave.Text = "Update"
            Exit Sub
        End If
        Clr(ppMF)
        refresher()
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        ppMF.BringToFront()
        ENB(ppMF, False)
        tt38.Enabled = True
        tt38.Focus()
    End Sub

    Private Sub bbclose_Click(sender As Object, e As EventArgs) Handles bbclose.Click
        ppPopup.Visible = Not ppPopup.Visible
    End Sub

    Private Sub bbFetch_Click(sender As Object, e As EventArgs) Handles bbFetch.Click
h1:
        If tt38.Text.Length = 0 Then ppPopup.Visible = True : dg3.DataSource = GDs("Id,FormNo,Organization_Name", T, "").Tables(T) : Exit Sub
        'get data if not exist then tt38.text = "" : goto h1
        Dim dt As DataTable = GDs(T, "FormNo='" & tt38.Text & "'").Tables(T)
        If dt.Rows.Count = 0 Then tt38.Text = "" : GoTo h1
        ttref.Text = dt.Rows(0).Item("Id")
        refresher()
    End Sub

    Private Sub ttref_TextChanged(sender As Object, e As EventArgs) Handles ttref.TextChanged
        ENB(ppMF, True)
    End Sub

    Private Sub dg3_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs) Handles dg3.CellClick
        ttref.Text = dg3.CurrentRow.Cells("Id").Value
        tt38.Text = dg3.CurrentRow.Cells("FormNo").Value
        refresher()
        ppPopup.Visible = False
    End Sub

    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem1.Click
        '{"Id", "SN", "Ref", "Name", "Designation", "Village", "Status", "CNIC", "Contact"}
        Dim dt As DataTable = GDs(T2, "id=" & dg2.CurrentRow.Cells(0).Value).Tables(T2)
        With dt.Rows(0)
            ttid2.Text = .Item("Id")
            ttref.Text = .Item("Ref")
            tt30.Text = .Item("Name")
            tt31.Text = .Item("Designation")
            tt32.Text = .Item("Village")
            tt33.Text = .Item("Status")
            tt34.Text = .Item("CNIC")
            tt35.Text = .Item("Contact")
        End With
        bbMSave.Text = "Edit"
    End Sub

    Private Sub AsdfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsdfToolStripMenuItem.Click

    End Sub





#End Region
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F1

            Case Keys.F2

            Case Keys.F3

            Case Keys.F4

            Case Keys.F5

            Case Keys.F6
            Case Keys.F7
            Case Keys.F8
                tt20.Focus()
            Case Keys.F9
                tt30.Focus()
            Case Keys.F10
            Case Keys.F11
            Case Keys.F12
            Case Keys.Escape

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)

        End Select

        Return True
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        COAttendance.Show()

    End Sub
End Class
