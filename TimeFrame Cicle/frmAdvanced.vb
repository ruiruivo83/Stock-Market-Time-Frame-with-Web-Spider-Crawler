Public Class frmAdvanced
    Dim RunCicleAdvanced As System.Threading.Thread
    'disables close
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            Const CS_NOCLOSE As Integer = &H200
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

    Private Sub Advanced_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D

        '_________________ 
        dayOfTheWeekSydney = dateTimeInSydney.DayOfWeek.ToString
        dayOfTheWeekTokyo = dateTimeInTokyo.DayOfWeek.ToString
        dayOfTheWeekLondon = dateTimeInLondon.DayOfWeek.ToString
        dayOfTheWeekNewYork = dateTimeInNewYork.DayOfWeek.ToString
        '_________________
        RunCicleAdvanced = New System.Threading.Thread(AddressOf inThreadRunCicleAdvanced)
        RunCicleAdvanced.Start()

        checkBoxForLondon.Checked = True
        checkBoxForNewYork.Checked = True
        checkBoxForSydney.Checked = True
        checkBoxForTokyo.Checked = True

        LoadStuff()
    End Sub
    Private Sub inThreadRunCicleAdvanced()
        appRun = 1
        Do Until appRun = 0
            'Hora Moundial UTC
            txtBoxUTCNow.Text = Now.UtcNow.ToLongTimeString
            'Atribui Hora a variáveis
            dateTimeInSydney = Now.UtcNow.AddHours(10)
            dateTimeInTokyo = Now.UtcNow.AddHours(9)
            dateTimeInLondon = Now.UtcNow.AddHours(1)
            dateTimeInNewYork = Now.UtcNow.AddHours(-4)
            'Coloca a hora nas caixas
            txtBoxTimeinSydney.Text = dateTimeInSydney.ToShortTimeString
            txtBoxTimeinTokyo.Text = dateTimeInTokyo.ToShortTimeString
            txtBoxTimeinLondon.Text = dateTimeInLondon.ToShortTimeString
            txtBoxTimeinNewYork.Text = dateTimeInNewYork.ToShortTimeString
            'ProgressBarDay()
            ApplyPresentData()
            VerifyEmptyBoxes()
            MarketOpenClosed()
            AlertVerification()
            BarAndMarketTimers()
            '___________________________________________________
            System.Threading.Thread.Sleep(3000)
        Loop
        If appRun = 0 Then
            Me.Close()
            End
        End If
    End Sub

    Private Sub LoadStuff()

        'Hora prédefinida para o horário dos mercados______________Falta mais

        txtBoxOpenHourSydney.Text = "7"
        txtBoxCloseHourSydney.Text = (Convert.ToInt32(txtBoxOpenHourSydney.Text) + 9).ToString

        txtBoxOpenHourTokyo.Text = "9"
        txtBoxCloseHourTokyo.Text = (Convert.ToInt32(txtBoxOpenHourTokyo.Text) + 9).ToString

        txtBoxOpenHourLondon.Text = "8"
        txtBoxCloseHourLondon.Text = (Convert.ToInt32(txtBoxOpenHourLondon.Text) + 9).ToString

        txtBoxOpenHourNewYork.Text = "8"
        txtBoxCloseHourNewYork.Text = (Convert.ToInt32(txtBoxOpenHourNewYork.Text) + 9).ToString

        '______________________________________

        'Minutos prédefinidos para alertas
        txtBoxMinutsToAlertSydney.Text = "5"
        txtBoxMinutsToAlertTokyo.Text = "5"
        txtBoxMinutsToAlertLondon.Text = "5"
        txtBoxMinutsToAlertNewYork.Text = "5"
    End Sub
    Private Sub ProgressBarDay()
        'Atribuir valores a ProgressBar
        'barSydney24.Value = dateTimeInSydney.Hour
        ' barTokyo24.Value = dateTimeInTokyo.Hour
        ' barLondon24.Value = dateTimeInLondon.Hour
        'barNewYork24.Value = dateTimeInNewYork.Hour
    End Sub
    Private Sub ApplyPresentData()
        'Verifica se tem texto vazio e guarda em Variáveis
        If txtBoxOpenHourSydney.Text = "" Then
        Else : intOpenHourSydney = Convert.ToInt32(txtBoxOpenHourSydney.Text)
        End If
        If txtBoxCloseHourSydney.Text = "" Then
        Else : intCloseHourSydney = Convert.ToInt32(txtBoxCloseHourSydney.Text)
        End If

        If txtBoxOpenHourTokyo.Text = "" Then
        Else : intOpenHourTokyo = Convert.ToInt32(txtBoxOpenHourTokyo.Text)
        End If
        If txtBoxCloseHourTokyo.Text = "" Then
        Else : intCloseHourTokyo = Convert.ToInt32(txtBoxCloseHourTokyo.Text)
        End If

        If txtBoxOpenHourLondon.Text = "" Then
        Else : intOpenHourLondon = Convert.ToInt32(txtBoxOpenHourLondon.Text)
        End If
        If txtBoxCloseHourLondon.Text = "" Then
        Else : intCloseHourLondon = Convert.ToInt32(txtBoxCloseHourLondon.Text)
        End If

        If txtBoxOpenHourNewYork.Text = "" Then
        Else : intOpenHourNewYork = Convert.ToInt32(txtBoxOpenHourNewYork.Text)
        End If
        If txtBoxCloseHourNewYork.Text = "" Then
        Else : intCloseHourNewYork = Convert.ToInt32(txtBoxCloseHourNewYork.Text)
        End If

    End Sub
    Private Sub VerifyEmptyBoxes()
        '________________
        If txtBoxOpenHourSydney.Text = "" Then
            txtBoxOpenHourSydney.BackColor = Color.DarkSalmon
        Else
            txtBoxOpenHourSydney.BackColor = Color.White
        End If
        If txtBoxOpenHourTokyo.Text = "" Then
            txtBoxOpenHourTokyo.BackColor = Color.DarkSalmon
        Else
            txtBoxOpenHourTokyo.BackColor = Color.White
        End If
        If txtBoxOpenHourLondon.Text = "" Then
            txtBoxOpenHourLondon.BackColor = Color.DarkSalmon
        Else
            txtBoxOpenHourLondon.BackColor = Color.White
        End If
        If txtBoxOpenHourNewYork.Text = "" Then
            txtBoxOpenHourNewYork.BackColor = Color.DarkSalmon
        Else
            txtBoxOpenHourNewYork.BackColor = Color.White
        End If
        '________________
        If txtBoxCloseHourSydney.Text = "" Then
            txtBoxCloseHourSydney.BackColor = Color.DarkSalmon
        Else
            txtBoxCloseHourSydney.BackColor = Color.White
        End If
        If txtBoxCloseHourTokyo.Text = "" Then
            txtBoxCloseHourTokyo.BackColor = Color.DarkSalmon
        Else
            txtBoxCloseHourTokyo.BackColor = Color.White
        End If
        If txtBoxCloseHourLondon.Text = "" Then
            txtBoxCloseHourLondon.BackColor = Color.DarkSalmon
        Else
            txtBoxCloseHourLondon.BackColor = Color.White
        End If
        If txtBoxCloseHourNewYork.Text = "" Then
            txtBoxCloseHourNewYork.BackColor = Color.DarkSalmon
        Else
            txtBoxCloseHourNewYork.BackColor = Color.White
        End If
        '________________
    End Sub
    Private Sub MarketOpenClosed()
        'Atribuir se Mercado Aberto ou fechado_______________Falta mais
        If dayOfTheWeekSydney = "Sunday" Or dayOfTheWeekSydney = "Saturday)then" Then
            txtBoxMarketSydney.Text = "Closed"
        Else
            If dateTimeInSydney.Hour >= intOpenHourSydney And dateTimeInSydney.Hour < intCloseHourSydney Then
                txtBoxMarketSydney.BackColor = Color.SeaGreen
                txtBoxMarketSydney.Text = "Open"
            Else : txtBoxMarketSydney.BackColor = Color.RosyBrown
                txtBoxMarketSydney.Text = "Closed"
            End If
        End If


        If dayOfTheWeekTokyo = "Sunday" Or dayOfTheWeekTokyo = "Saturday)then" Then
            txtBoxMarketTokyo.Text = "Closed"
        Else
            If dateTimeInTokyo.Hour >= intOpenHourTokyo And dateTimeInTokyo.Hour < intCloseHourTokyo Then
                txtBoxMarketTokyo.BackColor = Color.SeaGreen
                txtBoxMarketTokyo.Text = "Open"
            Else : txtBoxMarketTokyo.BackColor = Color.RosyBrown
                txtBoxMarketTokyo.Text = "Closed"
            End If
        End If

        If dayOfTheWeekLondon = "Sunday" Or dayOfTheWeekLondon = "Saturday)then" Then
            txtBoxMarketLondon.Text = "Closed"
        Else
            If dateTimeInLondon.Hour >= intOpenHourLondon And dateTimeInLondon.Hour < intCloseHourLondon Then
                txtBoxMarketLondon.BackColor = Color.SeaGreen
                txtBoxMarketLondon.Text = "Open"
            Else : txtBoxMarketLondon.BackColor = Color.RosyBrown
                txtBoxMarketLondon.Text = "Closed"
            End If
        End If

        If dayOfTheWeekNewYork = "Sunday" Or dayOfTheWeekNewYork = "Saturday)then" Then
            txtBoxMarketNewYork.Text = "Closed"
        Else
            If dateTimeInNewYork.Hour >= intOpenHourNewYork And dateTimeInNewYork.Hour < intCloseHourNewYork Then
                txtBoxMarketNewYork.BackColor = Color.SeaGreen
                txtBoxMarketNewYork.Text = "Open"
            Else : txtBoxMarketNewYork.BackColor = Color.RosyBrown
                txtBoxMarketNewYork.Text = "Closed"
            End If
        End If

    End Sub
    Private Sub AlertVerification()

        'Verifica se tem Alertas activos
        If checkBoxForSydney.Checked = True Then
            checkBoxForSydney.BackColor = Color.LightBlue
        Else : checkBoxForSydney.BackColor = Color.LightGray
        End If

        If checkBoxForTokyo.Checked = True Then
            checkBoxForTokyo.BackColor = Color.LightBlue
        Else : checkBoxForTokyo.BackColor = Color.LightGray
        End If

        If checkBoxForLondon.Checked = True Then
            checkBoxForLondon.BackColor = Color.LightBlue
        Else : checkBoxForLondon.BackColor = Color.LightGray
        End If

        If checkBoxForNewYork.Checked = True Then
            checkBoxForNewYork.BackColor = Color.LightBlue
        Else : checkBoxForNewYork.BackColor = Color.LightGray
        End If


        'Verificar se Alerta e BEEP
        If checkBoxForLondon.Checked = True And dateTimeInLondon.Hour = intOpenHourLondon - 1 And dateTimeInLondon.Minute >= 60 - Convert.ToInt32(txtBoxMinutsToAlertLondon.Text) Then
            Beep()
            checkBoxForLondon.BackColor = Color.Honeydew
            System.Threading.Thread.Sleep(100)
        End If
        If checkBoxForLondon.Checked = True And dateTimeInLondon.Hour = intCloseHourLondon - 1 And dateTimeInLondon.Minute >= 60 - Convert.ToInt32(txtBoxMinutsToAlertLondon.Text) Then
            Beep()
            checkBoxForLondon.BackColor = Color.Honeydew
            System.Threading.Thread.Sleep(100)
        End If

        If checkBoxForNewYork.Checked = True And dateTimeInNewYork.Hour = intOpenHourNewYork - 1 And dateTimeInNewYork.Minute >= 60 - Convert.ToInt32(txtBoxMinutsToAlertNewYork.Text) Then
            Beep()
            checkBoxForNewYork.BackColor = Color.Honeydew
            System.Threading.Thread.Sleep(100)
        End If
        If checkBoxForNewYork.Checked = True And dateTimeInNewYork.Hour = intCloseHourNewYork - 1 And dateTimeInNewYork.Minute >= 60 - Convert.ToInt32(txtBoxMinutsToAlertNewYork.Text) Then
            Beep()
            checkBoxForNewYork.BackColor = Color.Honeydew
            System.Threading.Thread.Sleep(100)
        End If

        If checkBoxForTokyo.Checked = True And dateTimeInTokyo.Hour = intOpenHourTokyo - 1 And dateTimeInTokyo.Minute >= 60 - Convert.ToInt32(txtBoxMinutsToAlertTokyo.Text) Then
            Beep()
            checkBoxForTokyo.BackColor = Color.Honeydew
            System.Threading.Thread.Sleep(100)
        End If
        If checkBoxForTokyo.Checked = True And dateTimeInTokyo.Hour = intCloseHourTokyo - 1 And dateTimeInTokyo.Minute >= 60 - Convert.ToInt32(txtBoxMinutsToAlertTokyo.Text) Then
            Beep()
            checkBoxForTokyo.BackColor = Color.Honeydew
            System.Threading.Thread.Sleep(100)
        End If

        If checkBoxForSydney.Checked = True And dateTimeInSydney.Hour = intOpenHourSydney - 1 And dateTimeInSydney.Minute >= 60 - Convert.ToInt32(txtBoxMinutsToAlertSydney.Text) Then
            Beep()
            checkBoxForSydney.BackColor = Color.Honeydew
            System.Threading.Thread.Sleep(100)
        End If
        If checkBoxForSydney.Checked = True And dateTimeInSydney.Hour = intCloseHourSydney - 1 And dateTimeInSydney.Minute >= 60 - Convert.ToInt32(txtBoxMinutsToAlertSydney.Text) Then
            Beep()
            checkBoxForSydney.BackColor = Color.Honeydew
            System.Threading.Thread.Sleep(100)
        End If
    End Sub
    Private Sub BarAndMarketTimers()
        If txtBoxMarketSydney.Text = "Open" Then
            txtBoxSydneyTimeToOpen.Text = ""
            If 59 - dateTimeInSydney.Minute < 10 Then
                barSydneyMarketProgress.Value = (dateTimeInSydney.Hour - (Convert.ToInt32(txtBoxOpenHourSydney.Text)) + 1)
                GlobalProgressSydney = barSydneyMarketProgress.Value
                txtBoxSydneyTimeToClose.Text = (Convert.ToInt32(txtBoxCloseHourSydney.Text) - dateTimeInSydney.Hour - 1).ToString & ":" & "0" & (59 - dateTimeInSydney.Minute)
            Else
                barSydneyMarketProgress.Value = (dateTimeInSydney.Hour - (Convert.ToInt32(txtBoxOpenHourSydney.Text)) + 1)
                GlobalProgressSydney = barSydneyMarketProgress.Value
                txtBoxSydneyTimeToClose.Text = (Convert.ToInt32(txtBoxCloseHourSydney.Text) - dateTimeInSydney.Hour - 1).ToString & ":" & (59 - dateTimeInSydney.Minute)
            End If
        Else
            barSydneyMarketProgress.Value = 0
            GlobalProgressSydney = barSydneyMarketProgress.Value
            txtBoxSydneyTimeToClose.Text = ""
            If 59 - dateTimeInSydney.Minute < 10 Then
                If dateTimeInSydney.Hour >= Convert.ToInt32(txtBoxCloseHourSydney.Text) Then
                    txtBoxSydneyTimeToOpen.Text = ((24 - dateTimeInSydney.Hour) + Convert.ToInt32(txtBoxOpenHourSydney.Text)) & ":0" & (59 - dateTimeInSydney.Minute).ToString
                Else
                    txtBoxSydneyTimeToOpen.Text = (Convert.ToInt32(txtBoxOpenHourSydney.Text) - dateTimeInSydney.Hour - 1) & ":0" & (59 - dateTimeInSydney.Minute).ToString
                End If
            Else
                If dateTimeInSydney.Hour >= Convert.ToInt32(txtBoxCloseHourSydney.Text) Then
                    txtBoxSydneyTimeToOpen.Text = ((24 - dateTimeInSydney.Hour) + Convert.ToInt32(txtBoxOpenHourSydney.Text)) & ":" & (59 - dateTimeInSydney.Minute).ToString
                Else
                    txtBoxSydneyTimeToOpen.Text = (Convert.ToInt32(txtBoxOpenHourSydney.Text) - dateTimeInSydney.Hour - 1) & ":" & (59 - dateTimeInSydney.Minute).ToString
                End If
            End If
        End If

        If txtBoxMarketTokyo.Text = "Open" Then
            txtBoxTokyoTimeToOpen.Text = ""
            If 59 - dateTimeInTokyo.Minute < 10 Then
                barTokyoMarketProgress.Value = (dateTimeInTokyo.Hour - (Convert.ToInt32(txtBoxOpenHourTokyo.Text)) + 1)
                GlobalProgressTokyo = barTokyoMarketProgress.Value
                txtBoxTokyoTimeToClose.Text = (Convert.ToInt32(txtBoxCloseHourTokyo.Text) - dateTimeInTokyo.Hour - 1).ToString & ":" & "0" & (59 - dateTimeInTokyo.Minute)
            Else
                barTokyoMarketProgress.Value = (dateTimeInTokyo.Hour - (Convert.ToInt32(txtBoxOpenHourTokyo.Text)) + 1)
                GlobalProgressTokyo = barTokyoMarketProgress.Value
                txtBoxTokyoTimeToClose.Text = (Convert.ToInt32(txtBoxCloseHourTokyo.Text) - dateTimeInTokyo.Hour - 1).ToString & ":" & (59 - dateTimeInTokyo.Minute)
            End If
        Else
            barTokyoMarketProgress.Value = 0
            GlobalProgressTokyo = barTokyoMarketProgress.Value
            txtBoxTokyoTimeToClose.Text = ""
            If 59 - dateTimeInTokyo.Minute < 10 Then
                If dateTimeInTokyo.Hour >= Convert.ToInt32(txtBoxCloseHourTokyo.Text) Then
                    txtBoxTokyoTimeToOpen.Text = ((24 - dateTimeInTokyo.Hour) + Convert.ToInt32(txtBoxOpenHourTokyo.Text)) & ":0" & (59 - dateTimeInTokyo.Minute).ToString
                Else
                    txtBoxTokyoTimeToOpen.Text = (Convert.ToInt32(txtBoxOpenHourTokyo.Text) - dateTimeInTokyo.Hour - 1) & ":0" & (59 - dateTimeInTokyo.Minute).ToString
                End If
            Else
                If dateTimeInTokyo.Hour >= Convert.ToInt32(txtBoxCloseHourTokyo.Text) Then
                    txtBoxTokyoTimeToOpen.Text = ((24 - dateTimeInTokyo.Hour) + Convert.ToInt32(txtBoxOpenHourTokyo.Text)) & ":" & (59 - dateTimeInTokyo.Minute).ToString
                Else
                    txtBoxTokyoTimeToOpen.Text = (Convert.ToInt32(txtBoxOpenHourTokyo.Text) - dateTimeInTokyo.Hour - 1) & ":" & (59 - dateTimeInTokyo.Minute).ToString
                End If
            End If
        End If

        If txtBoxMarketLondon.Text = "Open" Then
            txtBoxLondonTimeToOpen.Text = ""
            If 59 - dateTimeInLondon.Minute < 10 Then
                barLondonMarketProgress.Value = (dateTimeInLondon.Hour - (Convert.ToInt32(txtBoxOpenHourLondon.Text)) + 1)
                GlobalProgressLondon = barLondonMarketProgress.Value
                txtBoxLondonTimeToClose.Text = (Convert.ToInt32(txtBoxCloseHourLondon.Text) - dateTimeInLondon.Hour - 1).ToString & ":" & "0" & (59 - dateTimeInLondon.Minute)
            Else
                barLondonMarketProgress.Value = (dateTimeInLondon.Hour - (Convert.ToInt32(txtBoxOpenHourLondon.Text)) + 1)
                GlobalProgressLondon = barLondonMarketProgress.Value
                txtBoxLondonTimeToClose.Text = (Convert.ToInt32(txtBoxCloseHourLondon.Text) - dateTimeInLondon.Hour - 1).ToString & ":" & (59 - dateTimeInLondon.Minute)
            End If
        Else
            barLondonMarketProgress.Value = 0
            GlobalProgressLondon = barLondonMarketProgress.Value
            txtBoxLondonTimeToClose.Text = ""
            If 59 - dateTimeInLondon.Minute < 10 Then
                If dateTimeInLondon.Hour >= Convert.ToInt32(txtBoxCloseHourLondon.Text) Then
                    txtBoxLondonTimeToOpen.Text = ((24 - dateTimeInLondon.Hour) + Convert.ToInt32(txtBoxOpenHourLondon.Text)) & ":0" & (59 - dateTimeInLondon.Minute).ToString
                Else
                    txtBoxLondonTimeToOpen.Text = (Convert.ToInt32(txtBoxOpenHourLondon.Text) - dateTimeInLondon.Hour - 1) & ":0" & (59 - dateTimeInLondon.Minute).ToString
                End If
            Else
                If dateTimeInLondon.Hour >= Convert.ToInt32(txtBoxCloseHourLondon.Text) Then
                    txtBoxLondonTimeToOpen.Text = ((24 - dateTimeInLondon.Hour) + Convert.ToInt32(txtBoxOpenHourLondon.Text)) & ":" & (59 - dateTimeInLondon.Minute).ToString
                Else
                    txtBoxLondonTimeToOpen.Text = (Convert.ToInt32(txtBoxOpenHourLondon.Text) - dateTimeInLondon.Hour - 1) & ":" & (59 - dateTimeInLondon.Minute).ToString
                End If
            End If
        End If

        If txtBoxMarketNewYork.Text = "Open" Then
            txtBoxNewYorkTimeToOpen.Text = ""
            If 59 - dateTimeInNewYork.Minute < 10 Then
                barNewYorkMarketProgress.Value = (dateTimeInNewYork.Hour - (Convert.ToInt32(txtBoxOpenHourNewYork.Text)) + 1)
                GlobalProgressNewYork = barNewYorkMarketProgress.Value
                txtBoxNewYorkTimeToClose.Text = (Convert.ToInt32(txtBoxCloseHourNewYork.Text) - dateTimeInNewYork.Hour - 1).ToString & ":" & "0" & (59 - dateTimeInNewYork.Minute)
            Else
                barNewYorkMarketProgress.Value = (dateTimeInNewYork.Hour - (Convert.ToInt32(txtBoxOpenHourNewYork.Text)) + 1)
                GlobalProgressNewYork = barNewYorkMarketProgress.Value
                txtBoxNewYorkTimeToClose.Text = (Convert.ToInt32(txtBoxCloseHourNewYork.Text) - dateTimeInNewYork.Hour - 1).ToString & ":" & (59 - dateTimeInNewYork.Minute)
            End If
        Else
            barNewYorkMarketProgress.Value = 0
            GlobalProgressNewYork = barNewYorkMarketProgress.Value
            txtBoxNewYorkTimeToClose.Text = ""
            If 59 - dateTimeInNewYork.Minute < 10 Then
                If dateTimeInNewYork.Hour >= Convert.ToInt32(txtBoxCloseHourNewYork.Text) Then
                    txtBoxNewYorkTimeToOpen.Text = ((24 - dateTimeInNewYork.Hour) + Convert.ToInt32(txtBoxOpenHourNewYork.Text)) & ":0" & (59 - dateTimeInNewYork.Minute).ToString
                Else
                    txtBoxNewYorkTimeToOpen.Text = (Convert.ToInt32(txtBoxOpenHourNewYork.Text) - dateTimeInNewYork.Hour - 1) & ":0" & (59 - dateTimeInNewYork.Minute).ToString
                End If
            Else
                If dateTimeInNewYork.Hour >= Convert.ToInt32(txtBoxCloseHourNewYork.Text) Then
                    txtBoxNewYorkTimeToOpen.Text = ((24 - dateTimeInNewYork.Hour) + Convert.ToInt32(txtBoxOpenHourNewYork.Text)) & ":" & (59 - dateTimeInNewYork.Minute).ToString
                Else
                    txtBoxNewYorkTimeToOpen.Text = (Convert.ToInt32(txtBoxOpenHourNewYork.Text) - dateTimeInNewYork.Hour - 1) & ":" & (59 - dateTimeInNewYork.Minute).ToString
                End If
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmMarketHoursBrowser.Show()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MsgBox("If you see the market opens at 9:30, insert 10 in the h box and 35 on the minuts to alert before. :) ")
    End Sub
    Private Sub frmAdvanced_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Hide()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If checkBoxForSydney.Checked = True And checkBoxForTokyo.Checked = True And checkBoxForLondon.Checked = True And checkBoxForNewYork.Checked = True Then
            checkBoxForSydney.Checked = False
            checkBoxForTokyo.Checked = False
            checkBoxForLondon.Checked = False
            checkBoxForNewYork.Checked = False
        Else
            If checkBoxForSydney.Checked = False Then
                checkBoxForSydney.Checked = True
            End If
            If checkBoxForTokyo.Checked = False Then
                checkBoxForTokyo.Checked = True
            End If
            If checkBoxForLondon.Checked = False Then
                checkBoxForLondon.Checked = True
            End If
            If checkBoxForNewYork.Checked = False Then
                checkBoxForNewYork.Checked = True
            End If
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Hide()
        frmMarketHoursBrowser.Hide()
        frmMain.Hide()
        frmMicro.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmStockFundamentals.Show()
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        frmStockFundamentals.Show()
    End Sub
End Class