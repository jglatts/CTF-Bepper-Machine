<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ffc_pin_count = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.start_test_btn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.check_continuity = New System.Windows.Forms.CheckBox()
        Me.check_shorts = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(160, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 35)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CTF Tester"
        '
        'ffc_pin_count
        '
        Me.ffc_pin_count.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.ffc_pin_count.Location = New System.Drawing.Point(262, 144)
        Me.ffc_pin_count.Name = "ffc_pin_count"
        Me.ffc_pin_count.Size = New System.Drawing.Size(48, 20)
        Me.ffc_pin_count.TabIndex = 1
        Me.ffc_pin_count.Text = "1-50"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(82, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Enter FFC Pin Count: "
        '
        'start_test_btn
        '
        Me.start_test_btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.start_test_btn.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.start_test_btn.Location = New System.Drawing.Point(128, 287)
        Me.start_test_btn.Name = "start_test_btn"
        Me.start_test_btn.Size = New System.Drawing.Size(98, 41)
        Me.start_test_btn.TabIndex = 3
        Me.start_test_btn.Text = "Start Test"
        Me.start_test_btn.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label3.Location = New System.Drawing.Point(82, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(164, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Test For Continuity: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(82, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 21)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Test For Shorts: "
        '
        'check_continuity
        '
        Me.check_continuity.AutoSize = True
        Me.check_continuity.Location = New System.Drawing.Point(252, 190)
        Me.check_continuity.Name = "check_continuity"
        Me.check_continuity.Size = New System.Drawing.Size(15, 14)
        Me.check_continuity.TabIndex = 6
        Me.check_continuity.UseVisualStyleBackColor = True
        '
        'check_shorts
        '
        Me.check_shorts.AutoSize = True
        Me.check_shorts.Location = New System.Drawing.Point(211, 237)
        Me.check_shorts.Name = "check_shorts"
        Me.check_shorts.Size = New System.Drawing.Size(15, 14)
        Me.check_shorts.TabIndex = 7
        Me.check_shorts.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(21, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(133, 84)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 411)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.check_shorts)
        Me.Controls.Add(Me.check_continuity)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.start_test_btn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ffc_pin_count)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "CTF Tester"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ffc_pin_count As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents start_test_btn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents check_continuity As CheckBox
    Friend WithEvents check_shorts As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
