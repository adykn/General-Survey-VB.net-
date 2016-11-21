<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SurveyAreaCrud
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SurveyAreaCrud))
        Me.pp2 = New System.Windows.Forms.Panel()
        Me.ppPass = New System.Windows.Forms.Panel()
        Me.tt3 = New System.Windows.Forms.TextBox()
        Me.ll3 = New System.Windows.Forms.Label()
        Me.tt2 = New System.Windows.Forms.TextBox()
        Me.ll2 = New System.Windows.Forms.Label()
        Me.tt1 = New System.Windows.Forms.TextBox()
        Me.ll1 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ttFrm = New System.Windows.Forms.TextBox()
        Me.ttkey = New System.Windows.Forms.TextBox()
        Me.ttppass = New System.Windows.Forms.TextBox()
        Me.ttpid = New System.Windows.Forms.TextBox()
        Me.ttPassType = New System.Windows.Forms.TextBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.llPass = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddNewRecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DdToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.StartSurveyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.LockSurveyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailSurveyPassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.llSurveyTitle = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.pp1 = New System.Windows.Forms.Panel()
        Me.ttPass = New System.Windows.Forms.TextBox()
        Me.llMsg = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.bbCancel = New System.Windows.Forms.Button()
        Me.ttType = New System.Windows.Forms.TextBox()
        Me.ttDetail = New System.Windows.Forms.TextBox()
        Me.ttl1 = New System.Windows.Forms.TextBox()
        Me.ttl2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ttloc = New System.Windows.Forms.TextBox()
        Me.ttid = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tttitle = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ttref = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.bbSave = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pp2.SuspendLayout()
        Me.ppPass.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pp1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pp2
        '
        Me.pp2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pp2.BackColor = System.Drawing.Color.White
        Me.pp2.Controls.Add(Me.ppPass)
        Me.pp2.Controls.Add(Me.Button2)
        Me.pp2.Controls.Add(Me.dg)
        Me.pp2.Controls.Add(Me.Button4)
        Me.pp2.Location = New System.Drawing.Point(19, 79)
        Me.pp2.Name = "pp2"
        Me.pp2.Size = New System.Drawing.Size(854, 380)
        Me.pp2.TabIndex = 3
        '
        'ppPass
        '
        Me.ppPass.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ppPass.Controls.Add(Me.tt3)
        Me.ppPass.Controls.Add(Me.ll3)
        Me.ppPass.Controls.Add(Me.tt2)
        Me.ppPass.Controls.Add(Me.ll2)
        Me.ppPass.Controls.Add(Me.tt1)
        Me.ppPass.Controls.Add(Me.ll1)
        Me.ppPass.Controls.Add(Me.Panel7)
        Me.ppPass.Controls.Add(Me.Panel1)
        Me.ppPass.Location = New System.Drawing.Point(223, 77)
        Me.ppPass.Name = "ppPass"
        Me.ppPass.Size = New System.Drawing.Size(436, 227)
        Me.ppPass.TabIndex = 91
        Me.ppPass.Visible = False
        '
        'tt3
        '
        Me.tt3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tt3.Location = New System.Drawing.Point(166, 134)
        Me.tt3.Name = "tt3"
        Me.tt3.Size = New System.Drawing.Size(194, 20)
        Me.tt3.TabIndex = 54
        Me.tt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'll3
        '
        Me.ll3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ll3.AutoSize = True
        Me.ll3.Location = New System.Drawing.Point(71, 138)
        Me.ll3.Name = "ll3"
        Me.ll3.Size = New System.Drawing.Size(93, 13)
        Me.ll3.TabIndex = 55
        Me.ll3.Text = "Confirm New Pass"
        '
        'tt2
        '
        Me.tt2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tt2.Location = New System.Drawing.Point(166, 99)
        Me.tt2.Name = "tt2"
        Me.tt2.Size = New System.Drawing.Size(194, 20)
        Me.tt2.TabIndex = 52
        Me.tt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'll2
        '
        Me.ll2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ll2.AutoSize = True
        Me.ll2.Location = New System.Drawing.Point(71, 104)
        Me.ll2.Name = "ll2"
        Me.ll2.Size = New System.Drawing.Size(55, 13)
        Me.ll2.TabIndex = 53
        Me.ll2.Text = "New Pass"
        '
        'tt1
        '
        Me.tt1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tt1.Location = New System.Drawing.Point(166, 63)
        Me.tt1.Name = "tt1"
        Me.tt1.Size = New System.Drawing.Size(194, 20)
        Me.tt1.TabIndex = 49
        Me.tt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'll1
        '
        Me.ll1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ll1.AutoSize = True
        Me.ll1.Location = New System.Drawing.Point(71, 68)
        Me.ll1.Name = "ll1"
        Me.ll1.Size = New System.Drawing.Size(49, 13)
        Me.ll1.TabIndex = 51
        Me.ll1.Text = "Old Pass"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.ttFrm)
        Me.Panel7.Controls.Add(Me.ttkey)
        Me.Panel7.Controls.Add(Me.ttppass)
        Me.Panel7.Controls.Add(Me.ttpid)
        Me.Panel7.Controls.Add(Me.ttPassType)
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Controls.Add(Me.Button3)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 185)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(436, 42)
        Me.Panel7.TabIndex = 6
        '
        'ttFrm
        '
        Me.ttFrm.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttFrm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttFrm.Enabled = False
        Me.ttFrm.Location = New System.Drawing.Point(211, 11)
        Me.ttFrm.Name = "ttFrm"
        Me.ttFrm.Size = New System.Drawing.Size(72, 20)
        Me.ttFrm.TabIndex = 60
        Me.ttFrm.Text = "0"
        Me.ttFrm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ttkey
        '
        Me.ttkey.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttkey.Enabled = False
        Me.ttkey.Location = New System.Drawing.Point(72, 11)
        Me.ttkey.Name = "ttkey"
        Me.ttkey.Size = New System.Drawing.Size(72, 20)
        Me.ttkey.TabIndex = 59
        Me.ttkey.Text = "0"
        Me.ttkey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ttppass
        '
        Me.ttppass.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttppass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttppass.Enabled = False
        Me.ttppass.Location = New System.Drawing.Point(32, 11)
        Me.ttppass.Name = "ttppass"
        Me.ttppass.Size = New System.Drawing.Size(34, 20)
        Me.ttppass.TabIndex = 58
        Me.ttppass.Text = "0"
        Me.ttppass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ttpid
        '
        Me.ttpid.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttpid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttpid.Enabled = False
        Me.ttpid.Location = New System.Drawing.Point(11, 11)
        Me.ttpid.Name = "ttpid"
        Me.ttpid.Size = New System.Drawing.Size(19, 20)
        Me.ttpid.TabIndex = 57
        Me.ttpid.Text = "0"
        Me.ttpid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ttPassType
        '
        Me.ttPassType.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttPassType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttPassType.Enabled = False
        Me.ttPassType.Location = New System.Drawing.Point(150, 11)
        Me.ttPassType.Name = "ttPassType"
        Me.ttPassType.Size = New System.Drawing.Size(55, 20)
        Me.ttPassType.TabIndex = 56
        Me.ttPassType.Text = "Pass"
        Me.ttPassType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Red
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(436, 5)
        Me.Panel8.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(334, 9)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 28)
        Me.Button3.TabIndex = 50
        Me.Button3.Text = "Process"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.llPass)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(436, 42)
        Me.Panel1.TabIndex = 5
        '
        'Button5
        '
        Me.Button5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button5.Location = New System.Drawing.Point(398, 5)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(32, 28)
        Me.Button5.TabIndex = 90
        Me.Button5.Text = "X"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'llPass
        '
        Me.llPass.AutoSize = True
        Me.llPass.BackColor = System.Drawing.Color.Transparent
        Me.llPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llPass.ForeColor = System.Drawing.Color.Red
        Me.llPass.Location = New System.Drawing.Point(7, 6)
        Me.llPass.Name = "llPass"
        Me.llPass.Size = New System.Drawing.Size(61, 26)
        Me.llPass.TabIndex = 89
        Me.llPass.Text = "Pass"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Red
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 37)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(436, 5)
        Me.Panel6.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Lime
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(48, 42)
        Me.Button2.TabIndex = 90
        Me.Button2.Text = "+"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.AllowUserToDeleteRows = False
        Me.dg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dg.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg.DefaultCellStyle = DataGridViewCellStyle1
        Me.dg.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dg.Location = New System.Drawing.Point(4, 51)
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dg.RowHeadersVisible = False
        Me.dg.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dg.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dg.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dg.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg.Size = New System.Drawing.Size(846, 325)
        Me.dg.TabIndex = 44
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewRecordToolStripMenuItem, Me.DdToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripMenuItem2, Me.StartSurveyToolStripMenuItem, Me.SToolStripMenuItem, Me.LockSurveyToolStripMenuItem, Me.EmailSurveyPassToolStripMenuItem, Me.ChangePassToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(168, 176)
        '
        'AddNewRecordToolStripMenuItem
        '
        Me.AddNewRecordToolStripMenuItem.Name = "AddNewRecordToolStripMenuItem"
        Me.AddNewRecordToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.AddNewRecordToolStripMenuItem.Text = "Add New Record"
        '
        'DdToolStripMenuItem
        '
        Me.DdToolStripMenuItem.Name = "DdToolStripMenuItem"
        Me.DdToolStripMenuItem.Size = New System.Drawing.Size(164, 6)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(164, 6)
        '
        'StartSurveyToolStripMenuItem
        '
        Me.StartSurveyToolStripMenuItem.Name = "StartSurveyToolStripMenuItem"
        Me.StartSurveyToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.StartSurveyToolStripMenuItem.Text = "Start Survey"
        '
        'SToolStripMenuItem
        '
        Me.SToolStripMenuItem.Name = "SToolStripMenuItem"
        Me.SToolStripMenuItem.Size = New System.Drawing.Size(164, 6)
        '
        'LockSurveyToolStripMenuItem
        '
        Me.LockSurveyToolStripMenuItem.Name = "LockSurveyToolStripMenuItem"
        Me.LockSurveyToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.LockSurveyToolStripMenuItem.Text = "Lock Survey"
        '
        'EmailSurveyPassToolStripMenuItem
        '
        Me.EmailSurveyPassToolStripMenuItem.Name = "EmailSurveyPassToolStripMenuItem"
        Me.EmailSurveyPassToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.EmailSurveyPassToolStripMenuItem.Text = "Email Survey Pass"
        '
        'ChangePassToolStripMenuItem
        '
        Me.ChangePassToolStripMenuItem.Name = "ChangePassToolStripMenuItem"
        Me.ChangePassToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ChangePassToolStripMenuItem.Text = "Change Pass"
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackgroundImage = Global.TDPMS.My.Resources.Resources.download
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(803, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(48, 42)
        Me.Button4.TabIndex = 82
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.llSurveyTitle)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(896, 73)
        Me.Panel2.TabIndex = 4
        '
        'llSurveyTitle
        '
        Me.llSurveyTitle.AutoSize = True
        Me.llSurveyTitle.BackColor = System.Drawing.Color.Transparent
        Me.llSurveyTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llSurveyTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.llSurveyTitle.Location = New System.Drawing.Point(12, 18)
        Me.llSurveyTitle.Name = "llSurveyTitle"
        Me.llSurveyTitle.Size = New System.Drawing.Size(502, 37)
        Me.llSurveyTitle.TabIndex = 89
        Me.llSurveyTitle.Text = "Please Select a Survey to Process"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 68)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(896, 5)
        Me.Panel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 465)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(896, 48)
        Me.Panel4.TabIndex = 5
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(896, 5)
        Me.Panel5.TabIndex = 0
        '
        'pp1
        '
        Me.pp1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pp1.BackColor = System.Drawing.Color.White
        Me.pp1.Controls.Add(Me.Label1)
        Me.pp1.Controls.Add(Me.CheckBox2)
        Me.pp1.Controls.Add(Me.ttPass)
        Me.pp1.Controls.Add(Me.llMsg)
        Me.pp1.Controls.Add(Me.Button1)
        Me.pp1.Controls.Add(Me.CheckBox1)
        Me.pp1.Controls.Add(Me.bbCancel)
        Me.pp1.Controls.Add(Me.ttType)
        Me.pp1.Controls.Add(Me.ttDetail)
        Me.pp1.Controls.Add(Me.ttl1)
        Me.pp1.Controls.Add(Me.ttl2)
        Me.pp1.Controls.Add(Me.Label5)
        Me.pp1.Controls.Add(Me.Label7)
        Me.pp1.Controls.Add(Me.Label8)
        Me.pp1.Controls.Add(Me.ttloc)
        Me.pp1.Controls.Add(Me.ttid)
        Me.pp1.Controls.Add(Me.Label9)
        Me.pp1.Controls.Add(Me.tttitle)
        Me.pp1.Controls.Add(Me.Label11)
        Me.pp1.Controls.Add(Me.ttref)
        Me.pp1.Controls.Add(Me.Label12)
        Me.pp1.Controls.Add(Me.bbSave)
        Me.pp1.Location = New System.Drawing.Point(19, 79)
        Me.pp1.Name = "pp1"
        Me.pp1.Size = New System.Drawing.Size(854, 380)
        Me.pp1.TabIndex = 6
        '
        'ttPass
        '
        Me.ttPass.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttPass.Location = New System.Drawing.Point(374, 166)
        Me.ttPass.Name = "ttPass"
        Me.ttPass.ReadOnly = True
        Me.ttPass.Size = New System.Drawing.Size(194, 20)
        Me.ttPass.TabIndex = 91
        Me.ttPass.Text = "NoPass"
        Me.ttPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ttPass.Visible = False
        '
        'llMsg
        '
        Me.llMsg.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.llMsg.AutoSize = True
        Me.llMsg.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.llMsg.Font = New System.Drawing.Font("Kristen ITC", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llMsg.ForeColor = System.Drawing.Color.Red
        Me.llMsg.Location = New System.Drawing.Point(303, 10)
        Me.llMsg.Name = "llMsg"
        Me.llMsg.Size = New System.Drawing.Size(34, 29)
        Me.llMsg.TabIndex = 90
        Me.llMsg.Text = "..."
        Me.llMsg.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 42)
        Me.Button1.TabIndex = 89
        Me.Button1.Text = "-"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(252, 223)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox1.Size = New System.Drawing.Size(115, 17)
        Me.CheckBox1.TabIndex = 85
        Me.CheckBox1.Text = "Leave Panel Open"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'bbCancel
        '
        Me.bbCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bbCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bbCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bbCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bbCancel.Location = New System.Drawing.Point(374, 293)
        Me.bbCancel.Name = "bbCancel"
        Me.bbCancel.Size = New System.Drawing.Size(93, 35)
        Me.bbCancel.TabIndex = 84
        Me.bbCancel.Text = "Cancel"
        Me.bbCancel.UseVisualStyleBackColor = True
        '
        'ttType
        '
        Me.ttType.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttType.Location = New System.Drawing.Point(374, 142)
        Me.ttType.Name = "ttType"
        Me.ttType.Size = New System.Drawing.Size(194, 20)
        Me.ttType.TabIndex = 5
        '
        'ttDetail
        '
        Me.ttDetail.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttDetail.Location = New System.Drawing.Point(374, 191)
        Me.ttDetail.Multiline = True
        Me.ttDetail.Name = "ttDetail"
        Me.ttDetail.Size = New System.Drawing.Size(194, 94)
        Me.ttDetail.TabIndex = 6
        '
        'ttl1
        '
        Me.ttl1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttl1.Enabled = False
        Me.ttl1.Location = New System.Drawing.Point(374, 118)
        Me.ttl1.Name = "ttl1"
        Me.ttl1.Size = New System.Drawing.Size(96, 20)
        Me.ttl1.TabIndex = 3
        '
        'ttl2
        '
        Me.ttl2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttl2.Enabled = False
        Me.ttl2.Location = New System.Drawing.Point(475, 118)
        Me.ttl2.Name = "ttl2"
        Me.ttl2.Size = New System.Drawing.Size(93, 20)
        Me.ttl2.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(252, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "Detail"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(252, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "Type of Dist"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(252, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 13)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Latitude / Longitude"
        '
        'ttloc
        '
        Me.ttloc.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttloc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttloc.Location = New System.Drawing.Point(374, 95)
        Me.ttloc.Name = "ttloc"
        Me.ttloc.Size = New System.Drawing.Size(194, 20)
        Me.ttloc.TabIndex = 2
        '
        'ttid
        '
        Me.ttid.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttid.Location = New System.Drawing.Point(537, 49)
        Me.ttid.Name = "ttid"
        Me.ttid.ReadOnly = True
        Me.ttid.Size = New System.Drawing.Size(31, 20)
        Me.ttid.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(252, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Location"
        '
        'tttitle
        '
        Me.tttitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tttitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tttitle.Location = New System.Drawing.Point(374, 72)
        Me.tttitle.Name = "tttitle"
        Me.tttitle.Size = New System.Drawing.Size(194, 20)
        Me.tttitle.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(252, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Survey Title"
        '
        'ttref
        '
        Me.ttref.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ttref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ttref.Location = New System.Drawing.Point(374, 49)
        Me.ttref.Name = "ttref"
        Me.ttref.Size = New System.Drawing.Size(157, 20)
        Me.ttref.TabIndex = 47
        Me.ttref.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(252, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Ref #"
        '
        'bbSave
        '
        Me.bbSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bbSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bbSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bbSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bbSave.Location = New System.Drawing.Point(471, 293)
        Me.bbSave.Name = "bbSave"
        Me.bbSave.Size = New System.Drawing.Size(96, 35)
        Me.bbSave.TabIndex = 11
        Me.bbSave.Text = "Save"
        Me.bbSave.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'CheckBox2
        '
        Me.CheckBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(252, 168)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox2.Size = New System.Drawing.Size(108, 17)
        Me.CheckBox2.TabIndex = 92
        Me.CheckBox2.Text = "Enable Password"
        Me.CheckBox2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(574, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = ".:. Defualt: NoPass"
        '
        'SurveyAreaCrud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(896, 513)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pp2)
        Me.Controls.Add(Me.pp1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SurveyAreaCrud"
        Me.Text = "Survey Crud Area"
        Me.pp2.ResumeLayout(False)
        Me.ppPass.ResumeLayout(False)
        Me.ppPass.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.pp1.ResumeLayout(False)
        Me.pp1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pp2 As System.Windows.Forms.Panel
    Friend WithEvents dg As System.Windows.Forms.DataGridView
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents llSurveyTitle As System.Windows.Forms.Label
    Friend WithEvents pp1 As System.Windows.Forms.Panel
    Friend WithEvents bbCancel As System.Windows.Forms.Button
    Friend WithEvents ttType As System.Windows.Forms.TextBox
    Friend WithEvents ttDetail As System.Windows.Forms.TextBox
    Friend WithEvents ttl1 As System.Windows.Forms.TextBox
    Friend WithEvents ttl2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ttloc As System.Windows.Forms.TextBox
    Friend WithEvents ttid As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tttitle As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ttref As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents bbSave As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewRecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DdToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StartSurveyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents llMsg As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ttPass As System.Windows.Forms.TextBox
    Friend WithEvents LockSurveyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmailSurveyPassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ChangePassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ppPass As System.Windows.Forms.Panel
    Friend WithEvents tt3 As System.Windows.Forms.TextBox
    Friend WithEvents ll3 As System.Windows.Forms.Label
    Friend WithEvents tt2 As System.Windows.Forms.TextBox
    Friend WithEvents ll2 As System.Windows.Forms.Label
    Friend WithEvents tt1 As System.Windows.Forms.TextBox
    Friend WithEvents ll1 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents llPass As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents ttPassType As System.Windows.Forms.TextBox
    Friend WithEvents ttpid As System.Windows.Forms.TextBox
    Friend WithEvents ttppass As System.Windows.Forms.TextBox
    Friend WithEvents ttkey As System.Windows.Forms.TextBox
    Friend WithEvents ttFrm As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents CheckBox2 As Windows.Forms.CheckBox
End Class
