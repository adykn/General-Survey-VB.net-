Imports System.ComponentModel

Public Class SwitchBoard
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            FormXmdi.Show()
            FormXmdi.MdiParent = Me
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New VOCrud
        f.MdiParent = Me
        f.WindowState = Windows.Forms.FormWindowState.Maximized
        f.Show()

    End Sub
#Region "Menu"
    Dim b As Boolean = True
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        x = IIf(b = True, 31, 172)
        BackgroundWorker1.CancelAsync()
        BackgroundWorker1.RunWorkerAsync()

    End Sub
    Dim x As Int16 = 0
    Dim intrv As Int16 = 1
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
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

    Private Sub SwitchBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ppMenu.Size = New Point(31, 508)
    End Sub





#End Region
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Dim f As New COAttendance
        'f.MdiParent = Me
        'f.WindowState = Windows.Forms.FormWindowState.Maximized
        'f.Show()
        COAttendance.Show()
    End Sub
End Class