<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form03
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form03))
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lldetail = New System.Windows.Forms.RichTextBox()
        Me.llheadtext = New System.Windows.Forms.Label()
        Me.llSn = New System.Windows.Forms.Label()
        Me.bbsave = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraButton1 = New System.Windows.Forms.Button
        Me.ppNav = New System.Windows.Forms.Panel()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4, Me.Column1, Me.Column2})
        Me.dg.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dg.Location = New System.Drawing.Point(94, 152)
        Me.dg.Name = "dg"
        Me.dg.RowHeadersVisible = False
        Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg.Size = New System.Drawing.Size(642, 220)
        Me.dg.TabIndex = 21
        '
        'Column3
        '
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        Me.Column3.Visible = False
        '
        'Column4
        '
        Me.Column4.FillWeight = 20.0!
        Me.Column4.HeaderText = "S.N"
        Me.Column4.Name = "Column4"
        '
        'Column1
        '
        Me.Column1.FillWeight = 150.0!
        Me.Column1.HeaderText = "Question"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.FillWeight = 80.0!
        Me.Column2.HeaderText = "Answer"
        Me.Column2.Name = "Column2"
        '
        'lldetail
        '
        Me.lldetail.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lldetail.Location = New System.Drawing.Point(122, 107)
        Me.lldetail.Name = "lldetail"
        Me.lldetail.ReadOnly = True
        Me.lldetail.Size = New System.Drawing.Size(614, 39)
        Me.lldetail.TabIndex = 43
        Me.lldetail.Text = ""
        '
        'llheadtext
        '
        Me.llheadtext.AutoSize = True
        Me.llheadtext.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llheadtext.Location = New System.Drawing.Point(6, 6)
        Me.llheadtext.Name = "llheadtext"
        Me.llheadtext.Size = New System.Drawing.Size(30, 34)
        Me.llheadtext.TabIndex = 42
        Me.llheadtext.Text = "..."
        '
        'llSn
        '
        Me.llSn.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.llSn.AutoSize = True
        Me.llSn.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llSn.Location = New System.Drawing.Point(90, 107)
        Me.llSn.Name = "llSn"
        Me.llSn.Size = New System.Drawing.Size(31, 20)
        Me.llSn.TabIndex = 41
        Me.llSn.Text = "X . 1"
        '
        'bbsave
        '
        Me.bbsave.Location = New System.Drawing.Point(677, 378)
        Me.bbsave.Name = "bbsave"
        Me.bbsave.Size = New System.Drawing.Size(59, 23)
        Me.bbsave.TabIndex = 44
        Me.bbsave.Text = "Save"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(742, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(102, 524)
        Me.Panel1.TabIndex = 45
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraButton1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(102, 100)
        Me.Panel2.TabIndex = 0
        '
        'UltraButton1
        '
        Me.UltraButton1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UltraButton1.Location = New System.Drawing.Point(7, 3)
        Me.UltraButton1.Name = "UltraButton1"
        Me.UltraButton1.Size = New System.Drawing.Size(92, 85)
        Me.UltraButton1.TabIndex = 22
        Me.UltraButton1.Text = "Erase Record"
        '
        'ppNav
        '
        Me.ppNav.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ppNav.Location = New System.Drawing.Point(219, 423)
        Me.ppNav.Name = "ppNav"
        Me.ppNav.Size = New System.Drawing.Size(433, 51)
        Me.ppNav.TabIndex = 64
        '
        'Form03
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(844, 524)
        Me.Controls.Add(Me.ppNav)
        Me.Controls.Add(Me.bbsave)
        Me.Controls.Add(Me.lldetail)
        Me.Controls.Add(Me.llheadtext)
        Me.Controls.Add(Me.llSn)
        Me.Controls.Add(Me.dg)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form03"
        Me.Text = "03 Basic Village Information"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents lldetail As System.Windows.Forms.RichTextBox
    Friend WithEvents llheadtext As System.Windows.Forms.Label
    Friend WithEvents llSn As System.Windows.Forms.Label
    Friend WithEvents bbsave As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents UltraButton1 As System.Windows.Forms.Button
    Friend WithEvents ppNav As System.Windows.Forms.Panel
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
