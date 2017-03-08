Imports System.Windows.Forms
Imports System.Text
Imports System.ComponentModel
Public Class FormXmdi
    'Dim x As Integer = 0
    'Dim y As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Me.Text & " -> V" & Me.ProductVersion
        Me.ShowInTaskbar = True
        BackgroundWorker2.RunWorkerAsync()
        'OpenAllForms(Me)
        'FormX2.Show()
        'QuestionHeaderInformation.Show()
        ' SurveyAreaCrud.Show()
        'SurveyAreaCrud.WindowState = FormWindowState.Maximized
        'ppMenu.Size = New Point(31, 508)
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
        'OCFrm(FormX1)

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



    Private Sub Button2_Click(sender As Object, e As EventArgs)
        HowTo.Show()
        HowTo.BringToFront()
        ' HowTo.WindowState = FormWindowState.Maximized

    End Sub
#Region "Menu"
    Dim b As Boolean = True

    Dim x As Int16 = 0
    Dim intrv As Int16 = 1
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

        Const Max As Integer = 172
        If b = True Then
            For i = 31 To Max Step 5
                '' do something
                '' (I put a sleep to simulate time consumed)
                Threading.Thread.Sleep(2)

                '' report progress at regular intervals
                BackgroundWorker1.ReportProgress(i, "Running..." & i.ToString)

                '' check at regular intervals for CancellationPending
                If BackgroundWorker1.CancellationPending Then
                    BackgroundWorker1.ReportProgress(31, "Cancelling...")
                    Exit For
                End If
            Next
        Else
            For i = Max To 31 Step -5

                Threading.Thread.Sleep(2)
                BackgroundWorker1.ReportProgress(i, "Running..." & i.ToString)
            Next
        End If

        '' any cleanup code go here
        '' ensure that you close all open resources before exitting out of this Method.
        '' try to skip off whatever is not desperately necessary if CancellationPending is True

        '' set the e.Cancel to True to indicate to the RunWorkerCompleted that you cancelled out
        If BackgroundWorker1.CancellationPending Then
            e.Cancel = True
            BackgroundWorker1.ReportProgress(172, "Cancelled.")
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            '' if BackgroundWorker terminated due to error
            'MsgBox(e.Error.Message)
            'Me.Text = "Error occurred!"

        ElseIf e.Cancelled Then
            '' otherwise if it was cancelled
            'MsgBox("Task cancelled!")
            'Me.Text = "Task Cancelled!"
        Else
            '' otherwise it completed normally
            'MsgBox("Task completed!")
            'Me.Text = "completed!"
            ppMenu.BackColor = IIf(b = False, Color.FromArgb(0, 0, 0, 0), Color.White)

            b = Not b

        End If

    End Sub



    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ppMenu.Size = New Point(e.ProgressPercentage, 508)
        'Me.Text = CType(e.UserState, String)
        'Me.Text = Me.Text & "-" & e.ProgressPercentage.ToString & "% complete."
    End Sub







#End Region
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Dim f As New COAttendance
        'f.MdiParent = Me
        'f.WindowState = Windows.Forms.FormWindowState.Maximized
        'f.Show()
        COAttendance.Show()
        COAttendance.BringToFront()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SurveyAreaCrud.Show()
        SurveyAreaCrud.BringToFront()
        'SurveyAreaCrud.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        VOCrud.Show()
        VOCrud.BringToFront()
        'VOCrud.WindowState = Windows.Forms.FormWindowState.Maximized

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        UCProfile.Show()
        UCProfile.BringToFront()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Upgrade.Show()
        Upgrade.MdiParent = Me
        Upgrade.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        x = IIf(b = True, 31, 172)
        BackgroundWorker1.CancelAsync()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Rosters.Show()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        QuestionsAnsXlsExport.Show()
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Do
            Control.CheckForIllegalCrossThreadCalls = False
            llTime.Text = TimeOfDay
        Loop
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        Dim dx As DataTable = GDs("GivenAns", "GivenAns like '%Lac%' and sn=57").Tables("GivenAns")
        Dim x = 0
        For i = 0 To dx.Rows.Count - 1
            With dx.Rows(i)
                If .Item("GivenAns").ToString.ToLower.Contains("lac") Then
                    x = Val(.Item("GivenAns").ToString.ToLower.Replace("lac", ""))
                    x = x * 100000
                    UPD("GivenAns", "GivenAns='" & x & "'", "Id=" & .Item("Id"))
                End If

            End With
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Process.Start(Application.StartupPath & "\" & db2007)
    End Sub
End Class
