Imports System.Windows.Forms

Public Class HowTo
    Private Sub HowTo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        createTable(TN, TF, TS)
        Dim dt As DataTable = GDs(TN, "1=1").Tables(TN)
        If IsNothing(dt) Then Exit Sub
        If dt.Rows.Count = 0 Then insertData(TN, "Id,MemoNote", "1,'" & Enc64("Note Goes HERE..") & "'")
        rt.Text = Dec64(getValue(TN, "MemoNote", "Id=1"))
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F1

            Case Keys.F2

            Case Keys.F3

            Case Keys.F4
                updateData(TN, "MemoNote='" & Enc64(rt.Text.Trim) & "'", "Id=1")
            Case Keys.F5
                rt.Text = Dec64(getValue(TN, "MemoNote", "Id=1"))
            Case Keys.F6
            Case Keys.F7
            Case Keys.F8
            Case Keys.F9
            Case Keys.F10
            Case Keys.F11
            Case Keys.F12
            Case Keys.Escape

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)

        End Select

        Return True
    End Function
End Class