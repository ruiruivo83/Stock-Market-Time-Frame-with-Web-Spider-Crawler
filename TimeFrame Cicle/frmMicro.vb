Public Class frmMicro
    Dim RunCicle As System.Threading.Thread

    'disables close
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            Const CS_NOCLOSE As Integer = &H200
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        Me.TopMost = True
        RunCicle = New System.Threading.Thread(AddressOf inthreadRunCicle)
        RunCicle.Start()
    End Sub

    Private Sub inthreadRunCicle()
        Dim temp As Boolean = False
        Do Until temp = True
            barMicro60Min.Value = Now.Minute
            barMicroLondon.Value = GlobalProgressLondon
            If GlobalProgressLondon = 0 Then
                lblText.Text = "Trade Only EMA 55/233"
                lblText.BackColor = Color.Red
            Else
                lblText.Text = "Trade Only EMA 55/233"
                lblText.BackColor = Color.LightBlue
            End If
        Loop
    End Sub

    Private Sub btnMicro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMicro.Click
        Me.Hide()
        frmMain.Show()
    End Sub
End Class