<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMicro
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
        Me.btnMicro = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.barMicroLondon = New System.Windows.Forms.ProgressBar
        Me.barMicro60Min = New System.Windows.Forms.ProgressBar
        Me.lblText = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnMicro
        '
        Me.btnMicro.Location = New System.Drawing.Point(115, 16)
        Me.btnMicro.Name = "btnMicro"
        Me.btnMicro.Size = New System.Drawing.Size(14, 23)
        Me.btnMicro.TabIndex = 1
        Me.btnMicro.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-3, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Lon"
        '
        'barMicroLondon
        '
        Me.barMicroLondon.Location = New System.Drawing.Point(19, 39)
        Me.barMicroLondon.Maximum = 10
        Me.barMicroLondon.Name = "barMicroLondon"
        Me.barMicroLondon.Size = New System.Drawing.Size(109, 10)
        Me.barMicroLondon.Step = 1
        Me.barMicroLondon.TabIndex = 3
        '
        'barMicro60Min
        '
        Me.barMicro60Min.Location = New System.Drawing.Point(0, 16)
        Me.barMicro60Min.Maximum = 60
        Me.barMicro60Min.Name = "barMicro60Min"
        Me.barMicro60Min.Size = New System.Drawing.Size(116, 22)
        Me.barMicro60Min.Step = 1
        Me.barMicro60Min.TabIndex = 4
        '
        'lblText
        '
        Me.lblText.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblText.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblText.Location = New System.Drawing.Point(0, 0)
        Me.lblText.Name = "lblText"
        Me.lblText.Size = New System.Drawing.Size(129, 16)
        Me.lblText.TabIndex = 5
        Me.lblText.Text = "test"
        Me.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMicro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(129, 50)
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.barMicro60Min)
        Me.Controls.Add(Me.barMicroLondon)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnMicro)
        Me.Name = "frmMicro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMicro As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents barMicroLondon As System.Windows.Forms.ProgressBar
    Friend WithEvents barMicro60Min As System.Windows.Forms.ProgressBar
    Friend WithEvents lblText As System.Windows.Forms.Label
End Class
