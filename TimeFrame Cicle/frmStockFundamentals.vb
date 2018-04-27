Public Class frmStockFundamentals

    'disables close
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            Const CS_NOCLOSE As Integer = &H200
            cp.ClassStyle = cp.ClassStyle Or CS_NOCLOSE
            Return cp
        End Get
    End Property

    Dim thread01 As System.Threading.Thread
    Private Sub frmStockFundamentals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.TopMost = True
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        thread01 = New System.Threading.Thread(AddressOf inThreadMainCodeExtraction)
        thread01.Start()
    End Sub

    Private Sub inThreadMainCodeExtraction()

        Dim SourceCode As String = ""
        Dim Request As System.Net.HttpWebRequest = CType(System.Net.HttpWebRequest.Create("http://finviz.com/quote.ashx?t=" & txtBoxSymbol.Text), Net.HttpWebRequest)
        Dim Response As System.Net.HttpWebResponse = CType(Request.GetResponse(), Net.HttpWebResponse)
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(Response.GetResponseStream())
        SourceCode = sr.ReadToEnd()
        Dim strStart As String
        Dim strFinish As String
        Dim posStart As Integer
        Dim TamDesconhecido As Integer
        Dim Result As String
        Dim Run As Boolean
        'REMOVE caracter especial "
        Dim tempString As String
        tempString = SourceCode.Replace(Chr(34), "")
        SourceCode = tempString
        'REMOVE(Styles(Small))
        tempString = SourceCode.Replace("<small>", "")
        SourceCode = tempString
        tempString = SourceCode.Replace("</small>", "")
        SourceCode = tempString
        'REMOVE Styles (<Span ************* >)
        strStart = "<span"
        strFinish = ">"
        Run = True
        Do Until Run = False
            If InStr(SourceCode, strStart) = 0 Then
                Run = False
            Else
                posStart = InStr(SourceCode, strStart) + Len(strStart)
                TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
                Result = Mid(SourceCode, posStart, TamDesconhecido)
                If Len(Result) = 0 Then
                    tempString = SourceCode.Replace("<span>", "")
                    SourceCode = tempString
                Else
                    tempString = SourceCode.Replace(Result, "")
                    SourceCode = tempString
                End If
            End If
        Loop
        'REMOVE Styles (</Span>)
        tempString = SourceCode.Replace("</span>", "")
        SourceCode = tempString
        '___________________________________________
        'REMOVE Styles (<td width= ************* >)
        strStart = "<td width="
        strFinish = ">"
        Run = True
        Do Until Run = False
            If InStr(SourceCode, strStart) = 0 Then
                Run = False
            Else
                posStart = InStr(SourceCode, strStart) + Len(strStart)
                TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
                Result = Mid(SourceCode, posStart, TamDesconhecido)
                If Len(Result) = 0 Then
                    tempString = SourceCode.Replace("<td width=>", "")
                    SourceCode = tempString
                Else
                    tempString = SourceCode.Replace(Result, "")
                    SourceCode = tempString
                End If
            End If
        Loop
        'REMOVE Styles (</Td>)
        tempString = SourceCode.Replace("</td>", "")
        SourceCode = tempString
        '___________________________________________
        'REMOVE all before data
        'Find Index to remove all before
        Dim varRemoveTo As Integer
        Dim StringtoDelete As String
        varRemoveTo = InStr(SourceCode, "Index<b>")
        StringtoDelete = Mid(SourceCode, 10, varRemoveTo - 20)
        tempString = SourceCode.Replace(StringtoDelete, "")
        SourceCode = tempString
        '1- Find Index
        strStart = ("Index<b>")
        strFinish = ("</b>")
        posStart = InStr(SourceCode, strStart) + Len(strStart)
        TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
        Result = Mid(SourceCode, posStart, TamDesconhecido)
        txt01.Text = Result
        '_________________________________________
        'Save SourceCode
        'Dim FILE_NAME As String = "C:\Users\Home\Desktop\temp.txt"
        'If System.IO.File.Exists(FILE_NAME) = True Then
        'Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
        ' objWriter.Write(SourceCode)
        ' objWriter.Close()
        ' Else
        ' MsgBox("File does not exist")
        'End If
        '_________________________________________

        'Extract Values from SourceCode and post them to TextBox
        'test for ERROR
        If InStr(SourceCode, "Index<b>") = 0 Then
            MsgBox("No Symbol Found")
        Else
            Dim ContinueFrom As Integer = 1
            '1- Find Index
            strStart = ("Index<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt01.Text = Result
            '2- Find P/E
            strStart = ("P/E<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt02.Text = Result
            '3- Find EPS (ttm)
            strStart = ("EPS (ttm)<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt03.Text = Result
            '4- Insider Own
            strStart = ("Insider Own<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt04.Text = Result
            '5- Shs Outstand
            strStart = ("Shs Outstand<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt05.Text = Result
            '6- Perf Week
            strStart = ("Perf Week<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt06.Text = Result
            '7- Market Cap
            strStart = ("Market Cap<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt07.Text = Result
            '8- Forward P/E
            strStart = ("Forward P/E<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt08.Text = Result
            '9- EPS next Y
            strStart = ("EPS next Y<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt09.Text = Result
            '10- Insider Trans
            strStart = ("Insider Trans<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt10.Text = Result
            '11- Shs Float
            strStart = ("Shs Float<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt11.Text = Result
            '12- Perf Month
            strStart = ("Perf Month<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt12.Text = Result
            '13- Income
            strStart = ("Income<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt13.Text = Result
            '14- PEG
            strStart = ("PEG<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt14.Text = Result
            '15- EPS next Q
            strStart = ("EPS next Q<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt15.Text = Result
            '16- Inst Own
            strStart = ("Inst Own<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt16.Text = Result
            '17- Short Float
            strStart = ("Short Float<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt17.Text = Result
            '18- Perf Quarter
            strStart = ("Perf Quarter<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt18.Text = Result
            '19- Sales
            strStart = ("Sales<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt19.Text = Result
            '20- P/S
            strStart = ("P/S<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt20.Text = Result
            '21- EPS this Y
            strStart = ("EPS this Y<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt21.Text = Result
            '22- Inst Trans
            strStart = ("Inst Trans<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt22.Text = Result
            '23- Short Ratio
            strStart = ("Short Ratio<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt23.Text = Result
            '24- Perf Half Y
            strStart = ("Perf Half Y<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt24.Text = Result
            '25- Book/sh
            strStart = ("Book/sh<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt25.Text = Result
            '26- P/B
            strStart = ("P/B<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt26.Text = Result
            '27- EPS next Y
            strStart = ("EPS next Y<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt27.Text = Result
            '28- ROA
            strStart = ("ROA<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt28.Text = Result
            '29- Target Price
            strStart = ("Target Price<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt29.Text = Result
            '30- Perf Year
            strStart = ("Perf Year<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt30.Text = Result
            '31- Cash/sh
            strStart = ("Cash/sh<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt31.Text = Result
            '32- P/C
            strStart = ("P/C<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt32.Text = Result
            '33- EPS next 5Y
            strStart = ("EPS next 5Y<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt33.Text = Result
            '34- ROE
            strStart = ("ROE<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt34.Text = Result
            '35- 52W Range
            strStart = ("52W Range<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt35.Text = Result
            '36- Perf YTD
            strStart = ("Perf YTD<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt36.Text = Result
            '37- Dividend
            strStart = ("Dividend<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt37.Text = Result
            '38- P/FCF
            strStart = ("P/FCF<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt38.Text = Result
            '39- EPS past 5Y
            strStart = ("EPS past 5Y<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt39.Text = Result
            '40- ROI
            strStart = ("ROI<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt40.Text = Result
            '41- 52W High
            strStart = ("52W High<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt41.Text = Result
            '42- Beta
            strStart = ("Beta<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt42.Text = Result
            '43- Dividend %
            strStart = ("Dividend %<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt43.Text = Result
            '44- Quick Ratio
            strStart = ("Quick Ratio<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt44.Text = Result
            '45- Sales past 5Y
            strStart = ("Sales past 5Y<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt45.Text = Result
            '46- Gross Margin
            strStart = ("Gross Margin<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt46.Text = Result
            '47- 52W Low
            strStart = ("52W Low<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt47.Text = Result
            '48- ATR
            strStart = ("ATR<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt48.Text = Result
            '49- Employees
            strStart = ("Employees<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt49.Text = Result
            '50- Current Ratio
            strStart = ("Current Ratio<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt50.Text = Result
            '51- Sales Q/Q
            strStart = ("Sales Q/Q<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt51.Text = Result
            '52- Oper. Margin
            strStart = ("Oper. Margin<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt52.Text = Result
            '53- RSI (14)
            strStart = ("RSI (14)<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt53.Text = Result
            '54- Volatility
            strStart = ("Volatility<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt54.Text = Result
            '55- Optionable
            strStart = ("Optionable<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt55.Text = Result
            '56- Debt/Eq
            strStart = ("Debt/Eq<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt56.Text = Result
            '57- EPS Q/Q
            strStart = ("EPS Q/Q<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt57.Text = Result
            '58- Profit Margin
            strStart = ("Profit Margin<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt58.Text = Result
            '59- Rel Volume
            strStart = ("Rel Volume<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt59.Text = Result
            '60- Prev Close
            strStart = ("Prev Close<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt60.Text = Result
            '61- Shortable
            strStart = ("Shortable<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt61.Text = Result
            '62- LT Debt/Eq
            strStart = ("LT Debt/Eq<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt62.Text = Result
            '63- Earnings
            strStart = ("Earnings<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt63.Text = Result
            '64- Payout
            strStart = ("Payout<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt64.Text = Result
            '65- Avg Volume
            strStart = ("Avg Volume<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt65.Text = Result
            '66- Price
            strStart = ("Price<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt66.Text = Result
            '67- Recom
            strStart = ("Recom<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt67.Text = Result
            '68- SMA20
            strStart = ("SMA20<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt68.Text = Result
            '69- SMA50
            strStart = ("SMA50<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt69.Text = Result
            '70- SMA200
            strStart = ("SMA200<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt70.Text = Result
            '71- Volume
            strStart = ("Volume<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt71.Text = Result
            '72- Change
            strStart = ("Change<b>")
            strFinish = ("</b>")
            posStart = InStr(ContinueFrom, SourceCode, strStart) + Len(strStart)
            ContinueFrom = posStart
            TamDesconhecido = InStr(posStart, SourceCode, strFinish) - posStart
            Result = Mid(SourceCode, posStart, TamDesconhecido)
            txt72.Text = Result
            '___________________________________________________________________
            ReplaceDots()
            VerifyForColors()
        End If
    End Sub

    Private Sub VerifyForColors()
        Dim temp As String
        temp = txt01.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt01.Text) < 0 Then txt01.ForeColor = Color.Brown
        temp = txt02.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt02.Text) < 0 Then txt02.ForeColor = Color.Brown
        temp = txt03.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt03.Text) < 0 Then txt03.ForeColor = Color.Brown
        temp = txt04.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt04.Text) < 0 Then txt04.ForeColor = Color.Brown
        temp = txt05.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt05.Text) < 0 Then txt05.ForeColor = Color.Brown
        temp = txt06.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt06.Text) < 0 Then txt06.ForeColor = Color.Brown
        temp = txt07.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt07.Text) < 0 Then txt07.ForeColor = Color.Brown
        temp = txt08.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt08.Text) < 0 Then txt08.ForeColor = Color.Brown
        temp = txt09.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt09.Text) < 0 Then txt09.ForeColor = Color.Brown
        temp = txt10.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt10.Text) < 0 Then txt10.ForeColor = Color.Brown


        temp = txt11.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt11.Text) < 0 Then txt11.ForeColor = Color.Brown
        temp = txt12.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt12.Text) < 0 Then txt12.ForeColor = Color.Brown
        temp = txt13.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt13.Text) < 0 Then txt13.ForeColor = Color.Brown
        temp = txt14.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt14.Text) < 0 Then txt14.ForeColor = Color.Brown
        temp = txt15.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt15.Text) < 0 Then txt15.ForeColor = Color.Brown
        temp = txt16.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt16.Text) < 0 Then txt16.ForeColor = Color.Brown
        temp = txt17.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt17.Text) < 0 Then txt17.ForeColor = Color.Brown
        temp = txt18.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt18.Text) < 0 Then txt18.ForeColor = Color.Brown
        temp = txt19.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt19.Text) < 0 Then txt19.ForeColor = Color.Brown
        temp = txt20.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt20.Text) < 0 Then txt20.ForeColor = Color.Brown

        temp = txt21.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt21.Text) < 0 Then txt21.ForeColor = Color.Brown
        temp = txt22.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt22.Text) < 0 Then txt22.ForeColor = Color.Brown
        temp = txt23.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt23.Text) < 0 Then txt23.ForeColor = Color.Brown
        temp = txt24.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt24.Text) < 0 Then txt24.ForeColor = Color.Brown
        temp = txt25.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt25.Text) < 0 Then txt25.ForeColor = Color.Brown
        temp = txt26.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt26.Text) < 0 Then txt26.ForeColor = Color.Brown
        temp = txt27.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt27.Text) < 0 Then txt27.ForeColor = Color.Brown
        temp = txt28.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt28.Text) < 0 Then txt28.ForeColor = Color.Brown
        temp = txt29.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt29.Text) < 0 Then txt29.ForeColor = Color.Brown
        temp = txt30.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt30.Text) < 0 Then txt30.ForeColor = Color.Brown

        temp = txt31.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt31.Text) < 0 Then txt31.ForeColor = Color.Brown
        temp = txt32.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt32.Text) < 0 Then txt32.ForeColor = Color.Brown
        temp = txt33.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt33.Text) < 0 Then txt33.ForeColor = Color.Brown
        temp = txt34.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt34.Text) < 0 Then txt34.ForeColor = Color.Brown
        temp = txt35.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt35.Text) < 0 Then txt35.ForeColor = Color.Brown
        temp = txt36.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt36.Text) < 0 Then txt36.ForeColor = Color.Brown
        temp = txt37.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt37.Text) < 0 Then txt37.ForeColor = Color.Brown
        temp = txt38.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt38.Text) < 0 Then txt38.ForeColor = Color.Brown
        temp = txt39.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt39.Text) < 0 Then txt39.ForeColor = Color.Brown
        temp = txt40.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt40.Text) < 0 Then txt40.ForeColor = Color.Brown

        temp = txt41.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt41.Text) < 0 Then txt41.ForeColor = Color.Brown
        temp = txt42.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt42.Text) < 0 Then txt42.ForeColor = Color.Brown
        temp = txt43.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt43.Text) < 0 Then txt43.ForeColor = Color.Brown
        temp = txt44.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt44.Text) < 0 Then txt44.ForeColor = Color.Brown
        temp = txt45.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt45.Text) < 0 Then txt45.ForeColor = Color.Brown
        temp = txt46.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt46.Text) < 0 Then txt46.ForeColor = Color.Brown
        temp = txt47.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt47.Text) < 0 Then txt47.ForeColor = Color.Brown
        temp = txt48.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt48.Text) < 0 Then txt48.ForeColor = Color.Brown
        temp = txt49.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt49.Text) < 0 Then txt49.ForeColor = Color.Brown
        temp = txt50.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt50.Text) < 0 Then txt50.ForeColor = Color.Brown

        temp = txt51.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt51.Text) < 0 Then txt51.ForeColor = Color.Brown
        temp = txt52.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt52.Text) < 0 Then txt52.ForeColor = Color.Brown
        temp = txt53.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt53.Text) < 0 Then txt53.ForeColor = Color.Brown
        temp = txt54.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt54.Text) < 0 Then txt54.ForeColor = Color.Brown
        temp = txt55.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt55.Text) < 0 Then txt55.ForeColor = Color.Brown
        temp = txt56.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt56.Text) < 0 Then txt56.ForeColor = Color.Brown
        temp = txt57.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt57.Text) < 0 Then txt57.ForeColor = Color.Brown
        temp = txt58.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt58.Text) < 0 Then txt58.ForeColor = Color.Brown
        temp = txt59.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt59.Text) < 0 Then txt59.ForeColor = Color.Brown
        temp = txt60.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt60.Text) < 0 Then txt60.ForeColor = Color.Brown

        temp = txt61.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt61.Text) < 0 Then txt61.ForeColor = Color.Brown
        temp = txt62.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt62.Text) < 0 Then txt62.ForeColor = Color.Brown
        temp = txt63.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt63.Text) < 0 Then txt63.ForeColor = Color.Brown
        temp = txt64.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt64.Text) < 0 Then txt64.ForeColor = Color.Brown
        temp = txt65.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt65.Text) < 0 Then txt65.ForeColor = Color.Brown
        temp = txt66.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt66.Text) < 0 Then txt66.ForeColor = Color.Brown
        temp = txt67.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt67.Text) < 0 Then txt67.ForeColor = Color.Brown
        temp = txt68.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt68.Text) < 0 Then txt68.ForeColor = Color.Brown
        temp = txt69.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt69.Text) < 0 Then txt69.ForeColor = Color.Brown
        temp = txt70.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt70.Text) < 0 Then txt70.ForeColor = Color.Brown

        temp = txt71.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt71.Text) < 0 Then txt71.ForeColor = Color.Brown
        temp = txt72.Text.Replace("%", "")
        If Val(temp) < 0 Or Val(txt72.Text) < 0 Then txt72.ForeColor = Color.Brown

    End Sub
    Private Sub ReplaceDots()

        Dim temp As String
        temp = txt01.Text.Replace(".", ",")
        txt01.Text = temp.ToString
        temp = txt02.Text.Replace(".", ",")
        txt02.Text = temp.ToString
        temp = txt03.Text.Replace(".", ",")
        txt03.Text = temp.ToString
        temp = txt04.Text.Replace(".", ",")
        txt04.Text = temp.ToString
        temp = txt05.Text.Replace(".", ",")
        txt05.Text = temp.ToString
        temp = txt06.Text.Replace(".", ",")
        txt06.Text = temp.ToString
        temp = txt07.Text.Replace(".", ",")
        txt07.Text = temp.ToString
        temp = txt08.Text.Replace(".", ",")
        txt08.Text = temp.ToString
        temp = txt09.Text.Replace(".", ",")
        txt09.Text = temp.ToString
        temp = txt10.Text.Replace(".", ",")
        txt10.Text = temp.ToString
        temp = txt11.Text.Replace(".", ",")
        txt11.Text = temp.ToString
        temp = txt12.Text.Replace(".", ",")
        txt12.Text = temp.ToString
        temp = txt13.Text.Replace(".", ",")
        txt13.Text = temp.ToString
        temp = txt14.Text.Replace(".", ",")
        txt14.Text = temp.ToString
        temp = txt15.Text.Replace(".", ",")
        txt15.Text = temp.ToString
        temp = txt16.Text.Replace(".", ",")
        txt16.Text = temp.ToString
        temp = txt17.Text.Replace(".", ",")
        txt17.Text = temp.ToString
        temp = txt18.Text.Replace(".", ",")
        txt18.Text = temp.ToString
        temp = txt19.Text.Replace(".", ",")
        txt19.Text = temp.ToString
        temp = txt20.Text.Replace(".", ",")
        txt20.Text = temp.ToString
        temp = txt21.Text.Replace(".", ",")
        txt21.Text = temp.ToString
        temp = txt22.Text.Replace(".", ",")
        txt22.Text = temp.ToString
        temp = txt23.Text.Replace(".", ",")
        txt23.Text = temp.ToString
        temp = txt24.Text.Replace(".", ",")
        txt24.Text = temp.ToString
        temp = txt25.Text.Replace(".", ",")
        txt25.Text = temp.ToString
        temp = txt26.Text.Replace(".", ",")
        txt26.Text = temp.ToString
        temp = txt27.Text.Replace(".", ",")
        txt27.Text = temp.ToString
        temp = txt28.Text.Replace(".", ",")
        txt28.Text = temp.ToString
        temp = txt29.Text.Replace(".", ",")
        txt29.Text = temp.ToString
        temp = txt30.Text.Replace(".", ",")
        txt30.Text = temp.ToString
        temp = txt31.Text.Replace(".", ",")
        txt31.Text = temp.ToString
        temp = txt32.Text.Replace(".", ",")
        txt32.Text = temp.ToString
        temp = txt33.Text.Replace(".", ",")
        txt33.Text = temp.ToString
        temp = txt34.Text.Replace(".", ",")
        txt34.Text = temp.ToString
        temp = txt35.Text.Replace(".", ",")
        txt35.Text = temp.ToString
        temp = txt36.Text.Replace(".", ",")
        txt36.Text = temp.ToString
        temp = txt37.Text.Replace(".", ",")
        txt37.Text = temp.ToString
        temp = txt38.Text.Replace(".", ",")
        txt38.Text = temp.ToString
        temp = txt39.Text.Replace(".", ",")
        txt39.Text = temp.ToString
        temp = txt40.Text.Replace(".", ",")
        txt40.Text = temp.ToString
        temp = txt41.Text.Replace(".", ",")
        txt41.Text = temp.ToString
        temp = txt42.Text.Replace(".", ",")
        txt42.Text = temp.ToString
        temp = txt43.Text.Replace(".", ",")
        txt43.Text = temp.ToString
        temp = txt44.Text.Replace(".", ",")
        txt44.Text = temp.ToString
        temp = txt45.Text.Replace(".", ",")
        txt45.Text = temp.ToString
        temp = txt46.Text.Replace(".", ",")
        txt46.Text = temp.ToString
        temp = txt47.Text.Replace(".", ",")
        txt47.Text = temp.ToString
        temp = txt48.Text.Replace(".", ",")
        txt48.Text = temp.ToString
        temp = txt49.Text.Replace(".", ",")
        txt49.Text = temp.ToString
        temp = txt50.Text.Replace(".", ",")
        txt50.Text = temp.ToString
        temp = txt51.Text.Replace(".", ",")
        txt51.Text = temp.ToString
        temp = txt52.Text.Replace(".", ",")
        txt52.Text = temp.ToString
        temp = txt53.Text.Replace(".", ",")
        txt53.Text = temp.ToString
        temp = txt54.Text.Replace(".", ",")
        txt54.Text = temp.ToString
        temp = txt55.Text.Replace(".", ",")
        txt55.Text = temp.ToString
        temp = txt56.Text.Replace(".", ",")
        txt56.Text = temp.ToString
        temp = txt57.Text.Replace(".", ",")
        txt57.Text = temp.ToString
        temp = txt58.Text.Replace(".", ",")
        txt58.Text = temp.ToString
        temp = txt59.Text.Replace(".", ",")
        txt59.Text = temp.ToString
        temp = txt60.Text.Replace(".", ",")
        txt60.Text = temp.ToString
        temp = txt61.Text.Replace(".", ",")
        txt61.Text = temp.ToString
        temp = txt62.Text.Replace(".", ",")
        txt62.Text = temp.ToString
        temp = txt63.Text.Replace(".", ",")
        txt63.Text = temp.ToString
        temp = txt64.Text.Replace(".", ",")
        txt64.Text = temp.ToString
        temp = txt65.Text.Replace(".", ",")
        txt65.Text = temp.ToString
        temp = txt66.Text.Replace(".", ",")
        txt66.Text = temp.ToString
        temp = txt67.Text.Replace(".", ",")
        txt67.Text = temp.ToString
        temp = txt68.Text.Replace(".", ",")
        txt68.Text = temp.ToString
        temp = txt69.Text.Replace(".", ",")
        txt69.Text = temp.ToString
        temp = txt70.Text.Replace(".", ",")
        txt70.Text = temp.ToString
        temp = txt71.Text.Replace(".", ",")
        txt71.Text = temp.ToString
        temp = txt72.Text.Replace(".", ",")
        txt72.Text = temp.ToString

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmMain.Show()
        Me.Close()
    End Sub
    
End Class