Imports System.Windows.Forms
Imports System.Text

Public Class FormXmdi
    'Dim x As Integer = 0
    'Dim y As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'OpenAllForms(Me)
        'FormX2.Show()
        'QuestionHeaderInformation.Show()
        SurveyAreaCrud.Show()
        SurveyAreaCrud.WindowState = FormWindowState.Maximized
    End Sub


    Sub OCFrm(frm As Form)
        Try
            'UltraTabbedMdiManager1.TabFromForm(frm).Close()

        Catch ex As Exception
        End Try
        frm.Show()
    End Sub




    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Try
            OCFrm(SurveyAreaCrud)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Try
            Dim p As New Process()
            p.StartInfo.FileName = GetDefaultBrowser()
            p.StartInfo.Arguments = "http://www.idea.org.pk/"
            p.Start()
        Catch ex As Exception

        End Try

    End Sub




    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        OCFrm(Upgrade)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OCFrm(FormX1)
       
    End Sub
    
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Try
            Dim p As New Process()
            p.StartInfo.FileName = GetDefaultBrowser()
            p.StartInfo.Arguments = "http://www.idea.org.pk/contact/"
            p.Start()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SurveyAreaCrud.Show()
        SurveyAreaCrud.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripStatusLabel9_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel9.Click
        Try
            If SurveyAreaCrud.dg.RowCount = 0 Then Exit Sub
            With SurveyAreaCrud.dg
                Dim str() As String = { .CurrentRow.Cells("Id").Value, .CurrentRow.Cells("Ref").Value}
                MsgBox(str(1) & "-" & str(0))
                updateData("Surveys", "Pass='" & Crypto.Enc("", str(1)) & "'", "Id=" & str(0))
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        HowTo.Show()
        HowTo.WindowState = FormWindowState.Maximized
    End Sub
End Class
