Public Class frmExit

    'disables close
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            Const CS_NOCLOSE As Integer = &H200
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            frmMarketHoursBrowser.Close()
            frmAdvanced.Close()
            Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("TimeFrame Cicle.exe")
            For Each p As Process In pProcess
                p.Kill()
            Next
            End
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        temp = 0
        Me.Close()
    End Sub
    Private Sub frmExit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        Me.TopMost = True
    End Sub
End Class