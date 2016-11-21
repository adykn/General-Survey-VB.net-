Imports System.Windows.Forms
Imports Microsoft
Imports System.IO
Imports Microsoft.Office.Interop
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Form32
    Dim t As String = TN1
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        TextBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\"
        TextBox2.Text = t & ".xls"
        dt = GDs("Distinct District ", TN1, "").Tables(TN1)
        ComboBox1.DataSource = dt
        ComboBox1.DisplayMember = "District"
        ComboBox1.ValueMember = "District"
        If Not dt.Rows.Count = 0 Then ComboBox1.SelectedIndex = 0
        ComboBox5.DataSource = {"Question / UC", "UC / Question"}
        ComboBox2.DataSource = {"03: " & N3, "04: " & N4, "05: " & N5, "06: " & N6, "07: " & N7, "08: " & N8, "10: " & N10}
    End Sub

    Function makeQry(t As String, f As String(), condition As String) As String
        Dim str As String = "select "
        'For i = 0 To TF1.Length - 1
        '    str += "a." & TF1(i) & ","
        '    'If i = TN1.Length - 1 Then str += ","
        'Next
        For i = 4 To f.Length - 1
            str += "b." & f(i)
            If Not i = f.Length - 1 Then str += ","
        Next
        str += " from " & TN1 & " as a , " & t & " as b"
        str += " Where a.ref=b.ref and " & cCk(condition)

        Return str
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    'Private Sub Button3_Click(sender As Object, e As EventArgs)
    '    dgw.DataSource = GDsFQ(makeQry(TN31, TF31, "a.ref = '" & ComboBox1.SelectedValue & "'"), "v").Tables("v")
    'End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        ComboBox3.Enabled = CheckBox2.Checked
        If CheckBox2.Checked = False Then CheckBox3.Checked = False : ComboBox4.Enabled = False
    End Sub
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox2.Checked = False Then CheckBox3.Checked = False : ComboBox4.Enabled = False : Exit Sub
        ComboBox4.Enabled = CheckBox3.Checked
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        dt = GDs("Distinct Village ", TN1, " District like '%" & ComboBox1.Text & "%' ").Tables(TN1)
        ComboBox3.DataSource = dt
        ComboBox3.DisplayMember = "Village"
        ComboBox3.ValueMember = "Village"
        If Not dt.Rows.Count = 0 Then ComboBox3.SelectedIndex = 0
        ComboBox3.Enabled = CheckBox2.Checked
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        dt = GDs("Distinct UC ", TN1, " Village like '%" & ComboBox3.Text & "%'").Tables(TN1)
        ComboBox4.DataSource = dt
        ComboBox4.DisplayMember = "UC"
        ComboBox4.ValueMember = "UC"
        If Not dt.Rows.Count = 0 Then ComboBox4.SelectedIndex = 0
        ComboBox4.Enabled = CheckBox3.Checked
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim x As New Excel4d
      
        For i = 0 To ComboBox2.Items.Count - 1
            ds = GDs(ComboBox2.Items(i), "")
        Next

        x.MakeXslFile(ds, TextBox1.Text, TextBox2.Text, False, True, False)
    End Sub
    'Ref-15180401

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        For i = 0 To ComboBox2.Items.Count - 1
            Try
                DEL(ComboBox2.Items(i), "Ref='Ref-15180401'")
            Catch ex As Exception

            End Try

        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim x As New Excel4d
        If ComboBox5.Text = "Question / UC" Then
            x.MakeXslFileWithHeadersB(ComboBox2.Text.Split(":")(1).ToString.Trim, TextBox1.Text, TextBox2.Text)
        ElseIf ComboBox5.Text = "UC / Question" Then
            x.MakeXslFileWithHeaders(ComboBox2.Text.Split(":")(1).ToString.Trim, TextBox1.Text, TextBox2.Text)
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox2.Text = ComboBox2.Text.Replace(": ", "-") & ".xls"
    End Sub

    
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Report As New Rpt00
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Object
        Dim crtableLogoninfo As New TableLogOnInfo
        ' Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"


        With crConnectionInfo
            .ServerName = My.Application.Info.DirectoryPath.ToString() & "\data.mdb"
            '.DatabaseName = ""
            '.UserID = ""
            '.Password = "password"
        End With
        CrTables = Report.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
        ' Report.RecordSelectionFormula = strSelectionfrm

        Report.Refresh()
        Form31.Show()
        Form31.CrystalReportViewer1.ReportSource = Report
        Report.SummaryInfo.ReportTitle = "Report.pdf"
        Form31.CrystalReportViewer1.RefreshReport()


    End Sub
End Class