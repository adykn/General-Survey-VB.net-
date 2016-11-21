<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form09
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form09))
        Me.llheadtext = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.bbSave = New System.Windows.Forms.Button()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.lldetail = New System.Windows.Forms.RichTextBox()
        Me.llSn = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.UltraButton1 = New System.Windows.Forms.Button()
        Me.ppNav = New System.Windows.Forms.Panel()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'llheadtext
        '
        Me.llheadtext.AutoSize = True
        Me.llheadtext.Font = New System.Drawing.Font("Impact", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llheadtext.Location = New System.Drawing.Point(30, 6)
        Me.llheadtext.Name = "llheadtext"
        Me.llheadtext.Size = New System.Drawing.Size(30, 34)
        Me.llheadtext.TabIndex = 46
        Me.llheadtext.Text = "..."
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel1.Controls.Add(Me.bbSave)
        Me.Panel1.Controls.Add(Me.dg)
        Me.Panel1.Controls.Add(Me.lldetail)
        Me.Panel1.Controls.Add(Me.llSn)
        Me.Panel1.Location = New System.Drawing.Point(70, 85)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(677, 436)
        Me.Panel1.TabIndex = 45
        '
        'bbSave
        '
        Me.bbSave.Enabled = False
        Me.bbSave.Location = New System.Drawing.Point(557, 392)
        Me.bbSave.Name = "bbSave"
        Me.bbSave.Size = New System.Drawing.Size(114, 44)
        Me.bbSave.TabIndex = 45
        Me.bbSave.Text = "Save"
        Me.bbSave.UseVisualStyleBackColor = True
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dg.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dg.Location = New System.Drawing.Point(5, 76)
        Me.dg.Name = "dg"
        Me.dg.RowHeadersVisible = False
        Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg.Size = New System.Drawing.Size(666, 309)
        Me.dg.TabIndex = 44
        '
        'lldetail
        '
        Me.lldetail.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lldetail.Location = New System.Drawing.Point(33, 16)
        Me.lldetail.Name = "lldetail"
        Me.lldetail.ReadOnly = True
        Me.lldetail.Size = New System.Drawing.Size(638, 39)
        Me.lldetail.TabIndex = 43
        Me.lldetail.Text = ""
        '
        'llSn
        '
        Me.llSn.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.llSn.AutoSize = True
        Me.llSn.Font = New System.Drawing.Font("Impact", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llSn.Location = New System.Drawing.Point(1, 16)
        Me.llSn.Name = "llSn"
        Me.llSn.Size = New System.Drawing.Size(27, 20)
        Me.llSn.TabIndex = 41
        Me.llSn.Text = "0.1"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(751, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(102, 533)
        Me.Panel2.TabIndex = 47
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.UltraButton1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(102, 100)
        Me.Panel3.TabIndex = 0
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
        Me.ppNav.Location = New System.Drawing.Point(27, 476)
        Me.ppNav.Name = "ppNav"
        Me.ppNav.Size = New System.Drawing.Size(433, 51)
        Me.ppNav.TabIndex = 64
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.FillWeight = 25.0!
        Me.Column2.HeaderText = "S.N"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.FillWeight = 200.0!
        Me.Column3.HeaderText = "Comments"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Column4"
        Me.Column4.Name = "Column4"
        Me.Column4.Visible = False
        '
        'Form09
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(853, 533)
        Me.Controls.Add(Me.ppNav)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.llheadtext)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form09"
        Me.Text = "09 Comments"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents llheadtext As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents bbSave As System.Windows.Forms.Button
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents lldetail As System.Windows.Forms.RichTextBox
    Friend WithEvents llSn As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents UltraButton1 As System.Windows.Forms.Button
    Friend WithEvents ppNav As System.Windows.Forms.Panel
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
