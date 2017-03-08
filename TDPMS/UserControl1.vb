Imports System.Windows.Forms

Public Class UserControl1

    Public frmNum As String
    Dim start As String = "03"
    Dim ending As String = "30"
    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = WholeNum(frmNum + 2, 2)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Val(TextBox1.Text) > Val(start) Then TextBox1.Text -= 1 : TextBox1.Text = WholeNum(TextBox1.Text, 2) : openFrm(TextBox1.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Val(TextBox1.Text) < Val(ending) Then TextBox1.Text += 1 : TextBox1.Text = WholeNum(TextBox1.Text, 2) : openFrm(TextBox1.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = WholeNum(start, 2) : openFrm(TextBox1.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = WholeNum(ending, 2) : openFrm(TextBox1.Text)
    End Sub
    Sub openFrm(nameParsal As String)
        Try
            Dim objForm As Form
            Dim FullTypeName As String
            Dim FormInstanceType As Type
            FullTypeName = Application.ProductName & ".Form" & nameParsal
            FormInstanceType = Type.GetType(FullTypeName, True, True)
            objForm = CType(Activator.CreateInstance(FormInstanceType), Form)
            objForm.Show()
        Catch ex As Exception

        End Try
        'If Val(nameParsal) > start Or Val(nameParsal) < ending Then Exit Sub

    End Sub

     
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' FormXmdi.OCFrm(FormX2)
    End Sub
End Class
