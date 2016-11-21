Imports System.Windows.Forms
Public Class Form31
     
    Private Sub Form31_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
    End Sub
    Sub GenRpt()

        Dim Report As New Rpt01
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GenRpt()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Report As New Rpt01
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Report As New Rpt02
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Report As New Rpt03
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim Report As New Rpt04
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim Report As New Rpt05
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim Report As New Rpt06
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim Report As New Rpt07
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim Report As New Rpt08
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim Report As New Rpt09
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim Report As New Rpt10
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim Report As New Rpt11
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub
    
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim Report As New Rpt12
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim Report As New Rpt13
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim Report As New Rpt14
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim Report As New Rpt15
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim Report As New Rpt16
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim Report As New Rpt17
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim Report As New Rpt18
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim Report As New Rpt19
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim Report As New Rpt20
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Dim Report As New Rpt21
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Dim Report As New Rpt22
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        Dim Report As New Rpt23
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        Dim Report As New Rpt24
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub
    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        Dim Report As New Rpt25
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub
    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        Dim Report As New Rpt26
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Dim Report As New Rpt27
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        Dim Report As New Rpt28
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        Dim Report As New Rpt29
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        Dim Report As New Rpt30
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        Dim Report As New Rpt31
        'Dim strSelectionfrm = "{Issuesance.Id} = '" & dg1.CurrentRow.Cells(0).Value & "'"
        'Report.RecordSelectionFormula = strSelectionfrm
        Report.Refresh()
        CrystalReportViewer1.ReportSource = Report
        CrystalReportViewer1.RefreshReport()
    End Sub

   
End Class