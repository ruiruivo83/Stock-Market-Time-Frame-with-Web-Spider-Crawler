<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer_Clock = New System.Windows.Forms.Timer(Me.components)
        Me.lblClock = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.checkBoxAlert = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.barGlobalSydney = New System.Windows.Forms.ProgressBar()
        Me.barGlobalTokyo = New System.Windows.Forms.ProgressBar()
        Me.barGlobalLondon = New System.Windows.Forms.ProgressBar()
        Me.barGlobalNewYork = New System.Windows.Forms.ProgressBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.bar60Min = New System.Windows.Forms.ProgressBar()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer_Clock
        '
        '
        'lblClock
        '
        Me.lblClock.AutoSize = True
        Me.lblClock.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lblClock.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClock.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.lblClock.Location = New System.Drawing.Point(281, 2)
        Me.lblClock.Name = "lblClock"
        Me.lblClock.Size = New System.Drawing.Size(41, 18)
        Me.lblClock.TabIndex = 15
        Me.lblClock.Text = "Clock"
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(315, 2)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(46, 19)
        Me.Button8.TabIndex = 16
        Me.Button8.Text = "EXIT"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'checkBoxAlert
        '
        Me.checkBoxAlert.AutoSize = True
        Me.checkBoxAlert.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.checkBoxAlert.Location = New System.Drawing.Point(110, 4)
        Me.checkBoxAlert.Name = "checkBoxAlert"
        Me.checkBoxAlert.Size = New System.Drawing.Size(141, 17)
        Me.checkBoxAlert.TabIndex = 19
        Me.checkBoxAlert.Text = "Activate last minute alert"
        Me.checkBoxAlert.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(243, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Minute"
        '
        'barGlobalSydney
        '
        Me.barGlobalSydney.Location = New System.Drawing.Point(283, 55)
        Me.barGlobalSydney.Maximum = 10
        Me.barGlobalSydney.Name = "barGlobalSydney"
        Me.barGlobalSydney.Size = New System.Drawing.Size(77, 14)
        Me.barGlobalSydney.TabIndex = 34
        '
        'barGlobalTokyo
        '
        Me.barGlobalTokyo.Location = New System.Drawing.Point(205, 55)
        Me.barGlobalTokyo.Maximum = 10
        Me.barGlobalTokyo.Name = "barGlobalTokyo"
        Me.barGlobalTokyo.Size = New System.Drawing.Size(77, 14)
        Me.barGlobalTokyo.TabIndex = 35
        '
        'barGlobalLondon
        '
        Me.barGlobalLondon.Location = New System.Drawing.Point(127, 55)
        Me.barGlobalLondon.Maximum = 10
        Me.barGlobalLondon.Name = "barGlobalLondon"
        Me.barGlobalLondon.Size = New System.Drawing.Size(77, 14)
        Me.barGlobalLondon.TabIndex = 36
        '
        'barGlobalNewYork
        '
        Me.barGlobalNewYork.Location = New System.Drawing.Point(49, 55)
        Me.barGlobalNewYork.Maximum = 10
        Me.barGlobalNewYork.Name = "barGlobalNewYork"
        Me.barGlobalNewYork.Size = New System.Drawing.Size(77, 14)
        Me.barGlobalNewYork.TabIndex = 37
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 12)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Markets"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(95, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(15, 19)
        Me.Button3.TabIndex = 41
        Me.Button3.UseVisualStyleBackColor = True
        '
        'bar60Min
        '
        Me.bar60Min.Location = New System.Drawing.Point(4, 21)
        Me.bar60Min.Maximum = 60
        Me.bar60Min.Name = "bar60Min"
        Me.bar60Min.Size = New System.Drawing.Size(356, 33)
        Me.bar60Min.TabIndex = 42
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.DarkGreen
        Me.PictureBox3.Location = New System.Drawing.Point(90, 42)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(2, 11)
        Me.PictureBox3.TabIndex = 45
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.DarkGreen
        Me.PictureBox1.Location = New System.Drawing.Point(179, 42)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(2, 11)
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.DarkGreen
        Me.PictureBox2.Location = New System.Drawing.Point(267, 42)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(2, 11)
        Me.PictureBox2.TabIndex = 47
        Me.PictureBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button1.Location = New System.Drawing.Point(4, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 19)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "Advanced"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(361, 72)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.bar60Min)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.barGlobalNewYork)
        Me.Controls.Add(Me.barGlobalLondon)
        Me.Controls.Add(Me.barGlobalTokyo)
        Me.Controls.Add(Me.barGlobalSydney)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.checkBoxAlert)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.lblClock)
        Me.Name = "frmMain"
        Me.Text = "Market TimeFrame - One Hour"
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer_Clock As System.Windows.Forms.Timer
    Friend WithEvents lblClock As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents checkBoxAlert As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents barGlobalSydney As System.Windows.Forms.ProgressBar
    Friend WithEvents barGlobalTokyo As System.Windows.Forms.ProgressBar
    Friend WithEvents barGlobalLondon As System.Windows.Forms.ProgressBar
    Friend WithEvents barGlobalNewYork As System.Windows.Forms.ProgressBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents bar60Min As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
