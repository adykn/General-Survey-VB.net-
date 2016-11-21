Imports System.Windows.Forms

Public Class MenuFrm

    Private Sub MenuFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        createBtn()
    End Sub
    Sub createBtn()
        Dim j As Integer = 0, k As Integer = 0, NextColumnAt As Integer = 10

        For Each t As Type In Me.GetType().Assembly.GetTypes()
            If t.BaseType.Name = "Form" Then
                If t.Name = Me.Name Then Continue For
                If t.Name = "Form1" Then Continue For
                Menu1(CType(Activator.CreateInstance(t), Form), Panel1, k, j)
                j += 1
                If j = NextColumnAt Then k += 1 : j = 0
            End If
        Next
    End Sub
    Sub Menu1(frm As Form, panl As Panel, k As Integer, j As Integer)
        Dim w As Integer = 150, h As Integer = 25, x As Integer = 0, y As Integer = 0, remn As Integer = 0
        x = (w + 5) * k
        y = (h + 5) * j
        panl.Width = (w + 10) * (k + 1)
        panl.Location = New Point((Me.Width - panl.Width) / 2, (Me.Height - panl.Height) / 2)

        Dim ubtn = New System.Windows.Forms.Button()
        With ubtn
              .Location = New System.Drawing.Point(x, y)
            .Name = "ubtn:" & frm.Name
            .Size = New System.Drawing.Size(w, h)
            .TabIndex = 14
            .Text = frm.Text
            AddHandler .Click, AddressOf actionOfBtn

        End With
        panl.Controls.Add(ubtn)
    End Sub
    Sub actionOfBtn(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'MsgBox("you have clicked button " & CType(CType(sender, System.Windows.Forms.Button).Name, String))
        Dim nam As String() = CType(CType(sender, System.Windows.Forms.Button).Name, String).Split(":")

        Dim objForm As Form
        Dim FullTypeName As String
        Dim FormInstanceType As Type

        FullTypeName = Application.ProductName & "." & nam(1)

        FormInstanceType = Type.GetType(FullTypeName, True, True)

        objForm = CType(Activator.CreateInstance(FormInstanceType), Form)
        objForm.Show()

    End Sub
End Class