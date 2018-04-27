Public Class frmMain

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
        Control.CheckForIllegalCrossThreadCalls = False
        Me.Timer_Clock.Interval = 1 * 1000
        Me.Timer_Clock.Enabled = True
        Me.TopMost = True
        frmAdvanced.Show()
        frmAdvanced.Hide()
        checkBoxAlert.Checked = True
        RunCicle = New System.Threading.Thread(AddressOf inThreadRunCicle)
        RunCicle.Start()

    End Sub
    Private Sub inThreadRunCicle()
        appRun = 1
        Do Until appRun = 0
            System.Threading.Thread.Sleep(2000)
            bar60Min.Value = Now.Minute
            '________________________________________
            barGlobalSydney.Value = GlobalProgressSydney
            barGlobalTokyo.Value = GlobalProgressTokyo
            barGlobalLondon.Value = GlobalProgressLondon
            barGlobalNewYork.Value = GlobalProgressNewYork
            '________________________________________
            If checkBoxAlert.Checked = True And Now.Minute > 58 Then
                Beep()
            End If
        Loop
    End Sub
    Private Sub Timer_Clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Clock.Tick
        ' Update clock label Format (HH:MM:SS)
        Me.lblClock.Text = Now.Minute.ToString
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        frmExit.Show()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        frmMarketHoursBrowser.Hide()
        frmAdvanced.Hide()
        frmMicro.Show()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmAdvanced.Show()
    End Sub
End Class
