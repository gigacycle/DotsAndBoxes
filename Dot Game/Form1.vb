Public Class frmMain
    Public vMax As Byte
    Public hMax As Byte
    Public VLines(20, 20) As Line, vTmp(20, 20) As Line
    Public HLines(20, 20) As Line, hTmp(20, 20) As Line
    Public Squares(20, 20) As Square, SquaresTmp(20, 20) As Square
    Private LastLine As Line
    Private TreePacer As Integer
    Private DrwCounter As Short
    Private CScore, PScore As Short
    Private Turn As String
    Private Cnt As Integer

    Public Structure MatrixPos
        Dim i As Short, j As Short
        Dim vh As Char
        Dim winner As Char
    End Structure

    Private Sub LineArrayCopy(ByVal A(,) As Line, ByRef B(,) As Line)
        Dim i, j As Short
        For i = 0 To vMax - 1
            For j = 0 To hMax - 1
                B(i, j) = New Line(A(i, j).VH, A(i, j).X1, A(i, j).Y1, A(i, j).X2, A(i, j).Y2, A(i, j).Color, A(i, j).draw)
            Next
        Next
    End Sub

    Private Sub SquareArrayCopy(ByVal A(,) As Square, ByRef B(,) As Square)
        Dim i, j As Short
        For i = 0 To vMax - 1
            For j = 0 To hMax - 1
                B(i, j) = New Square(A(i, j).Symbol, A(i, j).Seis, A(i, j).X, A(i, j).Y)
            Next
        Next
    End Sub

    Private Sub CompleteSquares(ByRef vL(,) As Line, ByRef hL(,) As Line, ByRef SQ(,) As Square, ByVal vMax As Byte, ByVal hMax As Byte, ByRef LinesCount As Short, ByVal Turn As Char, ByVal Img As Image, Optional ByVal Draw As Boolean = False)
        Dim i, j As Short
        Dim LC As Line.LineCost
        For i = 0 To vMax - 1
            For j = 0 To hMax - 1
                If j < hMax - 1 Then 'Complete Horizontal Squares that needs a line
                    If hL(i, j).draw = False Then
                        hL(i, j).Draw = True 'LineEfficiency Method Can Only Return a Valid Result When Line.Draw=True 
                        If Draw = True Then
                            If Turn = "C" Then
                                hL(i, j).Color = Pens.Red
                            ElseIf Turn = "P" Then
                                hL(i, j).Color = Pens.Black
                            End If
                        End If
                        'Test for squarable 
                        LC = hL(i, j).LineEfficiency(vL, hL, vMax, hMax, i, j)
                        If (LC.Value1 <> 0) And (LC.Value2 <> 0) Then
                            hL(i, j).draw = False
                            If Draw = True Then hL(i, j).Color = Pens.White 'This Set Operation Can Draw "Not Drawed" Lines By White Color in ReDraw Sub
                        Else
                            If Draw = True Then hL(i, j).DrawLine(GameZone)
                            If LC.Value1 = 0 Then  'Complete Square that is top of current line
                                If Draw = True Then
                                    Squares(i, j).SetVal(Img, Turn, HLines(i, j).X1, HLines(i - 1, j).Y1, HLines(i, j).X2, HLines(i, j).Y2)
                                    Squares(i, j).DrawSymbol(GameZone)
                                    CScore += 1 : CScores.Text = Str(CScore)
                                Else
                                    Squares(i, j).Seis = Turn
                                End If
                            End If
                            If LC.Value2 = 0 Then  'Complete Square that is down of current line
                                If Draw = True Then
                                    Squares(i, j).SetVal(Img, Turn, HLines(i, j).X1, HLines(i, j).Y1, HLines(i, j).X2, HLines(i + 1, j).Y2)
                                    Squares(i, j).DrawSymbol(GameZone)
                                    CScore += 1 : CScores.Text = Str(CScore)
                                Else
                                    Squares(i, j).Seis = Turn
                                End If
                            End If
                            LinesCount += 1
                            ' Award of complete a square
                            CompleteSquares(vL, hL, SQ, vMax, hMax, LinesCount, Turn, Img, Draw)
                            'i = 0 : j = 0
                        End If
                    End If
                End If
                If i < vMax - 1 Then 'Complete Vertical Squares that needs a line
                    If vL(i, j).draw = False Then
                        vL(i, j).Draw = True 'LineEfficiency Method Can Only Return a Valid Result When Line.Draw=True 
                        If Draw = True Then
                            If Turn = "C" Then
                                vL(i, j).Color = Pens.Red
                            ElseIf Turn = "P" Then
                                vL(i, j).Color = Pens.Black
                            End If
                        End If
                        'Test for squarable
                        LC = vL(i, j).LineEfficiency(vL, hL, vMax, hMax, i, j)
                        If (LC.Value1 <> 0) And (LC.Value2 <> 0) Then
                            vL(i, j).draw = False
                            If Draw = True Then vL(i, j).Color = Pens.White 'This Set Operation Can Draw "Not Drawed" Lines By White Color in ReDraw Sub
                        Else
                            If Draw = True Then vL(i, j).DrawLine(GameZone)
                            If LC.Value1 = 0 Then 'Complete Square that is left of current line
                                If Draw = True Then
                                    Squares(i, j).SetVal(Img, Turn, VLines(i, j - 1).X1, VLines(i, j).Y1, VLines(i, j).X2, VLines(i, j).Y2)
                                    Squares(i, j).DrawSymbol(GameZone)
                                    CScore += 1 : CScores.Text = Str(CScore)
                                Else
                                    Squares(i, j).Seis = Turn
                                End If
                            End If
                            If LC.Value2 = 0 Then 'Complete Square that is right of current line
                                If Draw = True Then
                                    Squares(i, j).SetVal(Img, Turn, VLines(i, j).X1, VLines(i, j).Y1, VLines(i, j + 1).X2, VLines(i, j).Y2)
                                    Squares(i, j).DrawSymbol(GameZone)
                                    CScore += 1 : CScores.Text = Str(CScore)
                                Else
                                    Squares(i, j).Seis = Turn
                                End If
                            End If
                            LinesCount += 1
                            ' Award of complete a square
                            CompleteSquares(vL, hL, SQ, vMax, hMax, LinesCount, Turn, Img, Draw)
                            'i = 0 : j = 0
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Function CheckWinner(ByVal Squares(,) As Square, ByVal hMax As Byte, ByVal vMax As Byte) As Char
        Dim i As Byte, j As Byte
        Dim PScore, CScore As Short
        For i = 0 To vMax - 1
            For j = 0 To hMax - 1
                If Squares(i, j).Seis = "C" Then
                    CScore += 1
                ElseIf Squares(i, j).Seis = "P" Then
                    PScore += 1
                End If
            Next
        Next
        If PScore > CScore Then
            Return "P" 'Player is winner
        ElseIf PScore < CScore Then
            Return "C" 'Computer is winner
        Else
            Return "N" 'No winner exist
        End If
    End Function

    Function GameTree(ByVal vL(,) As Line, ByVal hL(,) As Line, ByVal SQR(,) As Square, ByVal vMax As Byte, ByVal hMax As Byte, ByVal LineCounter As Short, Optional ByVal Turn As Char = "P") As MatrixPos
        Dim i, j As Short, Pos As MatrixPos

        If Cnt <= LineCounter Then
            Pos.winner = CheckWinner(SQR, hMax, vMax)
            Return Pos
        Else
            If Turn = "P" Then
                Turn = "C"
            Else
                Turn = "P"
            End If
            For i = 0 To vMax - 1
                For j = 0 To hMax - 1
                    If j < hMax - 1 Then 'Select a horizontal line that not drawed before
                        If hL(i, j).draw = False Then
                            CompleteSquares(vL, hL, SQR, vMax, hMax, LineCounter, Turn, imgList.Images(2))
                            hL(i, j).draw = True
                            LineCounter += 1
                            Pos = GameTree(vL, hL, SQR, vMax, hMax, LineCounter, Turn)
                            Pos.i = i : Pos.j = j : Pos.vh = "H"
                            If Pos.winner = "C" Then
                                Exit For
                            End If
                            hL(i, j).draw = False
                            LineCounter -= 1
                            Continue For
                        End If
                    End If
                    If i < vMax - 1 Then 'Select a vertical line that not drawed before
                        If vL(i, j).draw = False Then
                            CompleteSquares(vL, hL, SQR, vMax, hMax, LineCounter, Turn, imgList.Images(2))
                            vL(i, j).draw = True
                            LineCounter += 1
                            Pos = GameTree(vL, hL, SQR, vMax, hMax, LineCounter, Turn)
                            Pos.i = i : Pos.j = j : Pos.vh = "V"
                            If Pos.winner = "C" Then
                                Exit For
                            End If
                            vL(i, j).draw = False
                            LineCounter -= 1
                        End If
                    End If
                Next
            Next
            Return Pos
        End If
    End Function

    Function SelectLine(ByVal vL(,) As Line, ByVal hL(,) As Line, ByVal vMax As Byte, ByVal hMax As Byte) As MatrixPos
        Dim i, j, timeOut As Short, Pos As MatrixPos
        Dim LC As Line.LineCost
        timeout = 0
        If (Cnt \ 3) >= DrwCounter Then 'Random select a line until first half of lines drawed
            Randomize()
            i = Int(2 * Rnd())
            If i = 1 Then
                While (1)
                    Randomize()
                    i = Int((vMax - 1) * Rnd())
                    j = Int((hMax - 2) * Rnd())
                    If hL(i, j).Draw = False Then
                        hL(i, j).Draw = True
                        LC = hL(i, j).LineEfficiency(vL, hL, vMax, hMax, i, j)
                        If (LC.Value1 <> 1) And (LC.Value2 <> 1) Then
                            hL(i, j).Draw = False
                            Pos.i = i : Pos.j = j : Pos.vh = "H"
                            Return Pos
                        End If
                        hL(i, j).Draw = False
                    End If
                    timeOut += 1
                    If timeOut >= 200 Then GoTo nextWay
                End While
            Else
                While (1)
                    Randomize()
                    i = Int((vMax - 2) * Rnd())
                    j = Int((hMax - 1) * Rnd())
                    If vL(i, j).Draw = False Then
                        vL(i, j).Draw = True
                        LC = vL(i, j).LineEfficiency(vL, hL, vMax, hMax, i, j)
                        If (LC.Value1 <> 1) And (LC.Value2 <> 1) Then
                            vL(i, j).Draw = False
                            Pos.i = i : Pos.j = j : Pos.vh = "V"
                            Return Pos
                        End If
                        vL(i, j).Draw = False
                    End If
                    timeOut += 1
                    If timeOut >= 200 Then GoTo nextWay
                End While
            End If
        Else
nextWay:
            For i = 0 To vMax - 1
                For j = 0 To hMax - 1
                    If j < hMax - 1 Then 'Select a horizontal line that not drawed before
                        If hL(i, j).Draw = False Then
                            hL(i, j).Draw = True
                            LC = hL(i, j).LineEfficiency(vL, hL, vMax, hMax, i, j)
                            If (LC.Value1 <> 1) And (LC.Value2 <> 1) Then
                                hL(i, j).Draw = False
                                Pos.i = i : Pos.j = j : Pos.vh = "H"
                                Return Pos
                            End If
                            hL(i, j).Draw = False
                        End If
                    End If
                    If i < vMax - 1 Then 'Select a vertical line that not drawed before
                        If vL(i, j).Draw = False Then
                            vL(i, j).Draw = True
                            LC = vL(i, j).LineEfficiency(vL, hL, vMax, hMax, i, j)
                            If (LC.Value1 <> 1) And (LC.Value2 <> 1) Then
                                vL(i, j).Draw = False
                                Pos.i = i : Pos.j = j : Pos.vh = "V"
                                Return Pos
                            End If
                            vL(i, j).Draw = False
                        End If
                    End If
                Next
            Next
            Pos.i = -1 : Pos.j = -1 : Pos.vh = ""
        End If
        Return Pos
    End Function

    Private Sub DrawComputerLine(ByVal L As Line, ByVal I As Short, ByVal J As Short)
        Dim Pos As MatrixPos

        If DrwCounter >= Cnt Then Exit Sub

        CompleteSquares(VLines, HLines, Squares, vMax, hMax, DrwCounter, "C", imgList.Images(1), True)

        LineArrayCopy(HLines, hTmp)
        LineArrayCopy(VLines, vTmp)
        SquareArrayCopy(Squares, SquaresTmp)

        Pos = SelectLine(vTmp, hTmp, vMax, hMax)
        If Pos.i < 0 Then Pos = GameTree(vTmp, hTmp, SquaresTmp, vMax, hMax, DrwCounter)

        If Pos.vh = "H" Then
            HLines(Pos.i, Pos.j).Color = Pens.Red
            HLines(Pos.i, Pos.j).draw = True
            HLines(Pos.i, Pos.j).DrawLine(GameZone)
        ElseIf Pos.vh = "V" Then
            VLines(Pos.i, Pos.j).Color = Pens.Red
            VLines(Pos.i, Pos.j).draw = True
            VLines(Pos.i, Pos.j).DrawLine(GameZone)
        End If
        Turn = "Player"
        If Cnt > DrwCounter Then DrwCounter += 1
    End Sub

    Private Sub DrawPlayerLine(ByVal X As Short, ByVal Y As Short, ByVal Color As Pen)
        Dim i, j As Short
        For i = 0 To vMax - 1
            For j = 0 To hMax - 1
                'if clicked on horizontal lines
                If ((HLines(i, j).draw = False) And (HLines(i, j).Y1 + 7 >= Y) And (HLines(i, j).Y1 - 7 <= Y)) And ((HLines(i, j).X1 <= X) And (HLines(i, j).X2 >= X)) Then
                    If Turn = "Player" Then
                        HLines(i, j).Color = Color
                        HLines(i, j).draw = True
                        HLines(i, j).DrawLine(GameZone)
                        Dim lc As Line.LineCost = HLines(i, j).LineEfficiency(VLines, HLines, vMax, hMax, i, j)
                        If lc.Value1 = 0 Then
                            Squares(i, j).SetVal(imgList.Images(0), "P", HLines(i, j).X1, HLines(i - 1, j).Y1, HLines(i, j).X2, HLines(i, j).Y2)
                            Squares(i, j).DrawSymbol(GameZone)
                            PScore += 1 : PScores.Text = Str(PScore)
                            Turn = "Player"
                        Else
                            Turn = "Computer"
                        End If
                        If lc.Value2 = 0 Then
                            Squares(i, j).SetVal(imgList.Images(0), "P", HLines(i, j).X1, HLines(i, j).Y1, HLines(i, j).X2, HLines(i + 1, j).Y2)
                            Squares(i, j).DrawSymbol(GameZone)
                            PScore += 1 : PScores.Text = Str(PScore)
                            Turn = "Player"
                        End If
                        DrwCounter += 1
                        If Turn = "Computer" Then DrawComputerLine(HLines(i, j), i, j)
                        Label1.Text = "Lines: " + Str(DrwCounter)
                        If Cnt <= DrwCounter Then
                            If CScore > PScore Then
                                MsgBox("Computer is winner", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Here is a winner...")
                            ElseIf CScore < PScore Then
                                MsgBox("You are winner", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Here is a winner...")
                            Else
                                MsgBox("No winner found...", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "No winner found...")
                            End If
                            ResetBoard()
                        End If
                        Exit Sub
                    End If
                End If
                'if clicked on vertical lines
                If ((VLines(i, j).Draw = False) And (VLines(i, j).X1 + 7 >= X) And (VLines(i, j).X1 - 7 <= X)) And ((VLines(i, j).Y1 <= Y) And (VLines(i, j).Y2 >= Y)) Then
                    If Turn = "Player" Then
                        VLines(i, j).Color = Color
                        VLines(i, j).Draw = True
                        VLines(i, j).DrawLine(GameZone)
                        Dim lc As Line.LineCost = VLines(i, j).LineEfficiency(VLines, HLines, vMax, hMax, i, j)
                        If lc.Value1 = 0 Then
                            Squares(i, j).SetVal(imgList.Images(0), "P", VLines(i, j - 1).X1, VLines(i, j).Y1, VLines(i, j).X2, VLines(i, j).Y2)
                            Squares(i, j).DrawSymbol(GameZone)
                            PScore += 1 : PScores.Text = Str(PScore)
                            Turn = "Player"
                        Else
                            Turn = "Computer"
                        End If
                        If lc.Value2 = 0 Then
                            Squares(i, j).SetVal(imgList.Images(0), "P", VLines(i, j).X1, VLines(i, j).Y1, VLines(i, j + 1).X2, VLines(i, j).Y2)
                            Squares(i, j).DrawSymbol(GameZone)
                            PScore += 1 : PScores.Text = Str(PScore)
                            Turn = "Player"
                        End If
                        DrwCounter += 1
                        If Turn = "Computer" Then DrawComputerLine(VLines(i, j), i, j)
                        Label1.Text = "Lines: " + Str(DrwCounter)
                        If Cnt <= DrwCounter Then
                            If CScore > PScore Then
                                MsgBox("Computer is winner", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Here is a winner...")
                            ElseIf CScore < PScore Then
                                MsgBox("You are winner", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Here is a winner...")
                            Else
                                MsgBox("No winner found...", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "No winner found...")
                            End If
                            ResetBoard()
                        End If
                        Exit Sub
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub HighlightLine(ByVal X As Short, ByVal Y As Short, ByVal Color As Pen)
        Dim i, j As Short
        For i = 0 To vMax - 1
            For j = 0 To hMax - 1
                'if clicked on horizontal lines
                If ((HLines(i, j).draw = False) And (HLines(i, j).Y1 + 7 >= Y) And (HLines(i, j).Y1 - 7 <= Y)) And ((HLines(i, j).X1 <= X) And (HLines(i, j).X2 >= X)) Then
                    LastLine.DrawLineFree(Pens.White, GameZone)
                    LastLine = HLines(i, j)
                    HLines(i, j).DrawLineFree(Color, GameZone)
                    Exit Sub
                End If
                'if clicked on vertical lines
                If ((VLines(i, j).draw = False) And (VLines(i, j).X1 + 7 >= X) And (VLines(i, j).X1 - 7 <= X)) And ((VLines(i, j).Y1 <= Y) And (VLines(i, j).Y2 >= Y)) Then
                    LastLine.DrawLineFree(Pens.White, GameZone)
                    LastLine = VLines(i, j)
                    VLines(i, j).DrawLineFree(Color, GameZone)
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Private Sub CreateLine(ByVal index1 As Short, ByVal index2 As Short, ByVal x1 As Short, ByVal y1 As Short, ByVal x2 As Short, ByVal y2 As Short, ByVal VH As Char, ByVal color As Pen, ByVal draw As Boolean)
        If VH = "V" Then 'Vertical Line
            VLines(index1, index2) = New Line("V", x1, y1, x2, y2, color, draw)
        ElseIf VH = "H" Then 'Horaizontarl Line
            HLines(index1, index2) = New Line("H", x1, y1, x2, y2, color, draw)
        End If
    End Sub

    Private Sub ResetBoard()
        GameZone.CreateGraphics.Clear(Color.White)
        Dim i, j As Short, x1, y1, x2, y2 As Single
        For i = 0 To vMax - 1
            y1 = (i * (GameZone.Height - 10) / vMax) + 10
            If (i + 1) <= (vMax - 1) Then y2 = ((i + 1) * (GameZone.Height - 10) / vMax) + 10
            For j = 0 To hMax - 1
                x1 = (j * (GameZone.Width - 10) / hMax) + 10
                If (j + 1) <= (hMax - 1) Then x2 = ((j + 1) * (GameZone.Width - 10) / hMax) + 10
                GameZone.CreateGraphics.FillEllipse(Brushes.Black, x1 - 2, y1 - 2, 4, 4)
                CreateLine(i, j, x1, y1, x2, y1, "H", Pens.White, False) 'Create Horizontal Lines
                CreateLine(i, j, x1, y1, x1, y2, "V", Pens.White, False) 'Create Vertical Lines
                Squares(i, j) = New Square()
            Next
        Next
        'Default Values:
        DrwCounter = 0
        Turn = "Player"
        LastLine = HLines(0, 0)
        Label1.Text = ""
        CScores.Text = ""
        PScores.Text = ""
        CScore = 0 : PScore = 0
        Cnt = ((hMax - 1) * vMax) + (hMax * (vMax - 1))
    End Sub

    Private Sub ReDraw()
        Dim i, j, x, y As Single
        For i = 0 To vMax - 1
            For j = 0 To hMax - 1
                HLines(i, j).DrawLine(GameZone)
                VLines(i, j).DrawLine(GameZone)
                If Squares(i, j).Seis <> Nothing Then Squares(i, j).DrawSymbol(GameZone)
                x = HLines(i, j).X1 - 2 : y = HLines(i, j).Y1 - 2
                GameZone.CreateGraphics.FillEllipse(Brushes.Black, x, y, 4, 4)
            Next
        Next
    End Sub

    Private Sub Tmr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr.Tick
        ReDraw()
    End Sub

    Private Sub GameZone_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GameZone.MouseMove
        HighlightLine(e.X, e.Y, Pens.Silver)
    End Sub

    Private Sub GameZone_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GameZone.MouseUp
        DrawPlayerLine(e.X, e.Y, Pens.Black)
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        While (hMax < 2)
            ftmSettings.ShowDialog()
        End While
        CIcon.Image = imgList.Images(1)
        PIcon.Image = imgList.Images(0)
        ResetBoard()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetBoard()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        About.ShowDialog()
    End Sub

    Private Sub btnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetting.Click
        ftmSettings.ShowDialog()
        ResetBoard()
    End Sub

End Class

Public Class Line

    Public Structure LineCost
        Dim Value1, Value2 As Short
    End Structure

    Public X1, Y1, X2, Y2 As Short
    Public Draw As Boolean
    Public Color As Pen 'Color means who's draw this line
    Public VH As Char

    Public Sub New(ByVal VH As Char, ByVal x1 As Short, ByVal y1 As Short, ByVal x2 As Short, ByVal y2 As Short, ByVal color As Pen, ByVal draw As Boolean)
        Me.X1 = x1 : Me.Y1 = y1
        Me.X2 = x2 : Me.Y2 = y2
        Me.Color = color : Me.Draw = Draw : Me.VH = VH
    End Sub

    'This function return's a value that contain : How many lines remains to Square
    Private Function RemainToSquare(ByVal L1 As Line, ByVal L2 As Line, ByVal L3 As Line, ByVal L4 As Line) As Byte
        Try
            Dim RemainTo As Short = 4
            If (L1.draw = True) Then RemainTo -= 1
            If (L2.draw = True) Then RemainTo -= 1
            If (L3.draw = True) Then RemainTo -= 1
            If (L4.draw = True) Then RemainTo -= 1
            Return RemainTo
        Catch e As NullReferenceException
            Return 4
        End Try
    End Function

    'This function return's a boolean value that contain : is this line captured some squares or not
    Public Function LineEfficiency(ByVal vL(,) As Line, ByVal hL(,) As Line, ByVal vMax As Byte, ByVal hMax As Byte, ByVal Index1 As Byte, ByVal Index2 As Byte) As LineCost
        Dim i(1), j(1) As Short
        If Me.VH = "H" Then
            i(0) = Index1 - 1 : i(1) = Index1
            j(0) = Index2 : j(1) = Index2 + 1
            If i(0) < 0 Then
                i(0) = Index1
                i(1) = Index1 + 1
                LineEfficiency.Value1 = -1
            Else
                LineEfficiency.Value1 = RemainToSquare(hL(i(0), j(0)), hL(i(1), j(0)), vL(i(0), j(0)), vL(i(0), j(1)))
            End If
            i(0) = Index1 : i(1) = Index1 + 1
            j(0) = Index2 : j(1) = Index2 + 1
            If i(1) > hMax - 1 Then
                i(0) = Index1 - 1
                i(1) = Index1
                LineEfficiency.Value2 = -1
            Else
                LineEfficiency.Value2 = RemainToSquare(hL(i(0), j(0)), hL(i(1), j(0)), vL(i(0), j(0)), vL(i(0), j(1)))
            End If
        ElseIf Me.VH = "V" Then
            i(0) = Index1 : i(1) = Index1 + 1
            j(0) = Index2 - 1 : j(1) = Index2
            If j(0) < 0 Then
                j(0) = Index2
                j(1) = Index2 + 1
                LineEfficiency.Value1 = -1
            Else
                LineEfficiency.Value1 = RemainToSquare(hL(i(0), j(0)), hL(i(1), j(0)), vL(i(0), j(0)), vL(i(0), j(1)))
            End If
            i(0) = Index1 : i(1) = Index1 + 1
            j(0) = Index2 : j(1) = Index2 + 1
            If j(1) > vMax - 1 Then
                j(0) = Index2 - 1
                j(1) = Index2
                LineEfficiency.Value2 = -1
            Else
                LineEfficiency.Value2 = RemainToSquare(hL(i(0), j(0)), hL(i(1), j(0)), vL(i(0), j(0)), vL(i(0), j(1)))
            End If
        End If
    End Function

    Public Sub DrawLine(ByVal DrawZone As PictureBox)
        If Me.draw = True Then
            DrawZone.CreateGraphics.DrawLine(Me.Color, Me.X1, Me.Y1, Me.X2, Me.Y2)
        End If
    End Sub

    Public Sub DrawLineFree(ByVal color As Pen, ByVal DrawZone As PictureBox)
        DrawZone.CreateGraphics.DrawLine(color, Me.X1, Me.Y1, Me.X2, Me.Y2)
    End Sub

End Class

Public Class Square
    Public Seis As Char
    Public X As Single, Y As Single
    Public Symbol As Image

    Public Sub New()
        Me.Seis = ""
    End Sub

    Public Sub New(ByVal Symbol As Image, ByVal Seis As Char, ByVal X As Short, ByVal Y As Short)
        Me.Seis = Seis
        Me.Symbol = Symbol
        Me.X = X
        Me.Y = Y
    End Sub

    Public Sub SetVal(ByVal Symbol As Image, ByVal Seis As Char, ByVal x1 As Short, ByVal y1 As Short, ByVal x2 As Short, ByVal y2 As Short)
        Me.Seis = Seis
        Me.Symbol = Symbol
        Me.X = ((x1 + x2) / 2) - (Symbol.Width / 2)
        Me.Y = ((y1 + y2) / 2) - (Symbol.Height / 2)
    End Sub

    Public Sub DrawSymbol(ByVal drawZone As PictureBox)
        If Me.Symbol Is Nothing Then Exit Sub
        drawZone.CreateGraphics.DrawImage(Me.Symbol, Me.X, Me.Y)
    End Sub
End Class