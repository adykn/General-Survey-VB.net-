<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HowTo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rt = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'rt
        '
        Me.rt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rt.Font = New System.Drawing.Font("Rockwell", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rt.Location = New System.Drawing.Point(13, 24)
        Me.rt.Name = "rt"
        Me.rt.Size = New System.Drawing.Size(1029, 475)
        Me.rt.TabIndex = 0
        Me.rt.Text = ""
        '
        'HowTo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1054, 529)
        Me.Controls.Add(Me.rt)
        Me.Name = "HowTo"
        Me.Text = "HowTo"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rt As Windows.Forms.RichTextBox
End Class
