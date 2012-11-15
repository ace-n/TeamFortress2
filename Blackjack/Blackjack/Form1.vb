Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1

    Dim ShiftKeyDown As Boolean

    Declare Function Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer) As Integer

    Declare Function CreateCompatibleDC Lib "gdi32" (ByVal hWnd As Int32) As Int32

    ' Functions
    Declare Function FindWindow Lib "user32" (Optional ByVal lpClassName As String = "",
                                              Optional ByVal lpWindowName As String = "") As Int32

    Declare Function GetDC Lib "user32" (ByVal hWnd As Int32) As Int32
    Declare Function ReleaseDC Lib "user32" (ByVal hWnd As Int32, ByVal hDC As Int32) As Int32
    Declare Function GetDesktopWindow Lib "user32" () As Int32
    Declare Function BitBlt Lib "gdi32" (ByVal hdcDest As Int32,
                                             ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer,
                                             ByVal hdcSrc As Int32, ByVal nXSrc As Integer, ByVal nYSrc As Integer,
                                             ByVal dwRop As String) As Boolean

    Declare Function GetAsyncKeyState Lib "user32" (ByVal nVirtKey As Integer) As Short

    ' For throttling
    Public T_TotalTime As Integer = 0
    Public T_StartTime As Integer = 0
    Public T_AvgTime As Double = 0
    Public T_Iterations As Integer = 0

    ' For auto-shoot
    Public Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Int32, ByVal dX As Int32, ByVal dY As Int32, ByVal cButtons As Int32, ByVal dwExtraInfo As Int32)

    ' For game title matching
    Declare Function GetForegroundWindow Lib "user32" () As Integer
    Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hWnd As Integer, ByVal lpString As String, ByVal nMaxCount As Integer) As Integer
    Declare Function GetWindowRect Lib "user32" (ByVal hWnd As Integer, ByRef lpRect As Rectangle) As Boolean

    ' Note: an HDC of 0 = desktop (use this!)
    Declare Function CreateCompatibleBitmap Lib "gdi32" (ByVal hDC As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer) As Int32


    ' See here: http://www.cs.rit.edu/~ncs/color/t_convert.html
    Private Function RGB2HSV(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Integer()

        Dim H, S, V As Double

        Dim max As Integer = Math.Max(R, Math.Max(G, B))
        Dim min As Integer = Math.Min(R, Math.Min(G, B))
        V = max

        If min = max Then
            Return {CInt(H), CInt(max / 2.55), 0}
        End If

        Dim delta As Integer = max - min

        If max <> 0 Then
            S = 100 * delta / max
        Else
            S = 0
            H = -1
        End If

        If R = max Then
            H = (G - B) / delta
        ElseIf G = max Then
            H = 2 + (B - R) / delta
        Else
            H = 4 + (R - G) / delta
        End If

        H *= 60
        If H < 0 Then
            H += 360
        End If

        Return {CInt(H), CInt(S), CInt(V)}

    End Function

    Private Function GetDesktop()

        ' Get capture sizes
        Dim CapX, CapY As Integer
        CapX = CInt(txtCapX.Text)
        CapY = CInt(txtCapY.Text)

        Dim DeskWin As Int32 = GetDesktopWindow ' FindWindow(, "Garry's Mod")
        Dim DeskDC As Int32 = CreateCompatibleDC(GetDC(DeskWin))
        Dim DeskImg As Bitmap = New Bitmap(CapX, CapY)
        Dim Graphic As Graphics

        Graphic = Graphics.FromImage(DeskImg)
        Dim GraphHDC As IntPtr = Graphic.GetHdc

        ' Get some screen data
        Dim ScreenSize As Point = New Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        Dim ScrPt As Point = New Point(Math.Round((ScreenSize.X - CapX) / 2), Math.Round((ScreenSize.Y - CapY) / 2))


        ' Copy desktop image to Graphic
        BitBlt(GraphHDC, 0, 0, ScreenSize.X, ScreenSize.Y, DeskDC, 0, 0, "SRCCOPY")
        'StretchBlt(GraphHDC, 0, 0, 50, 50, DeskDC, (ScreenSize.X - CapX) / 2, (ScreenSize.Y - CapY) / 2, CapX * 2, CapY * 2, "SRCCOPY")

        ' Release DC's

        Graphic.ReleaseHdc(GraphHDC)
        ReleaseDC(DeskWin, DeskDC)

        Return DeskImg

    End Function

    ' HAS CAPTURE PROBLEMS -  SEE: http://social.msdn.microsoft.com/Forums/en-MY/vcmfcatl/thread/95ff878d-17c0-449f-bca8-0ee00d9de962
    Private Function GetDeskAndAimAtTarget()

        Process.GetCurrentProcess.PriorityClass = ProcessPriorityClass.RealTime

        ' Misc variables
        Dim CapX As Integer = CInt(txtCapX.Text)
        Dim CapY As Integer = CInt(txtCapY.Text)

        ' List of green points
        'Dim ValidPoints As List(Of Point)

        Dim DeskImg As Bitmap = New Bitmap(CapX, CapY)

        ' Method 3 - (IN USE) - Bit-block transfer pixel data from desktop
        Dim ScreenSize As Point = New Point(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)

        ' STEP 1: Set up variables
        Dim DeskDC As Int32 = GetDC(0)
        Dim DeskBMP As Bitmap = New Bitmap(CapX, CapY)
        Dim DeskGR As Graphics = Graphics.FromImage(DeskBMP)
        Dim Scale As Integer = CInt(txtCapSize.Text)
        Dim ColorTolerance As Integer = CInt(txtClrRng.Text)
        Dim HeadSearchRange As Integer = CInt(txtHeadRng.Text)
        Dim MinMovementLen As Double = CDbl(txtMinMouseMovementLen.Text)

        ' Stretched variables
        Dim StretchedBMP As Bitmap = New Bitmap(Scale, Scale)
        Dim StretchedGR As Graphics = Graphics.FromImage(StretchedBMP)

        ' Variables used in while loop
        Dim CaptBound, TargetScreen, TargetScreenNew, TargetScreenLead, TargetBmp, TargetRel, WinUpperLeft, CaptBMPCntr, CaptBestXY, TargetScreenVelocity, PastMoved As Point
        Dim TargetScreenAcceleration As New PointF
        Dim TargetIsHostile, Detected, DetectedBefore As Boolean
        Dim CaptRect As Rectangle
        Dim CaptBMPData As BitmapData
        Dim CaptNumBytes, MinX, MinY, MaxX, MaxY, PixR, PixB, PixG, CurDist, BestDist, IterateDir As Integer
        Dim Mul As Double = CDbl(txtSenseMul.Text) * CInt(txtEffCnt.Text) / 10.5
        Dim CapScale As PointF = New PointF(CapX / Scale, CapY / Scale)
        Dim ActiveWinRect As Rectangle
        Dim IsBlueTeam As Boolean = rbnBlu.Checked

        ' Auto-shoot
        Const MOUSEEVENTF_LEFTDOWN = &H2 ' left button down
        Const MOUSEEVENTF_LEFTUP = &H4   ' left button up
        Const VK_SHIFT = &H10
        Const VK_CTRL = &H11

        ' Enhanced game response
        Const VK_W = &H41
        Const VK_A = &H41
        Const VK_S = &H53
        Const VK_D = &H57

        ' Throttling
        Dim ScanRate As Integer = 60
        Try
            ScanRate = CInt(txtScanRate.Text)
            If ScanRate < 1 Then
                ScanRate = 1
            End If
        Catch ex As Exception
            txtScanRate.Text = "60"
        End Try
        Dim T_TargTime As Double = 1000 / ScanRate

        ' Efficiency
        Dim Efficiency As Integer = 2
        Try
            Efficiency = CInt(txtEffCnt.Text)
            If Efficiency < 2 Then
                Efficiency = 2
            End If
        Catch ex As Exception
            txtEffCnt.Text = "1"
            Efficiency = 2
        End Try

        While True

            ' Start timer
            T_StartTime = My.Computer.Clock.TickCount

            ' If the user has since exited out of the game, exit the loop (so the user can edit the controls)
            Dim ActiveWindowDataInt As Integer = ActiveWindowData()
            If ActiveWindowDataInt = 2 Then

                Exit While

            ElseIf ActiveWindowDataInt = 0 Then

                Sleep(40)
                TargetScreen = New Point(0, 0)
                TargetScreenNew = New Point(0, 0)

                Continue While

            End If

            Dim ShiftDown As Integer = GetAsyncKeyState(VK_SHIFT)
            If ShiftDown <> 0 Then
                Continue While
            End If

            ' Get rectangle representing the area of the active window (if the "relative to window" box is checked)
            If cbxRelWin.Checked Then
                ActiveWinRect = GetActiveWindowRect()
                WinUpperLeft = New Point(ActiveWinRect.Left, ActiveWinRect.Top)
            Else
                WinUpperLeft = New Point(0, 0)
            End If

            ' This variable is TRUE if a possible target pixel is found
            Detected = False

            ' STEP 2: Capture Desktop in a bitmap through Graphics.CopyFromScreen (this is a BitBlt operation)
            CaptBound = Point.Subtract(ScreenSize, New Point(CapX, CapY))
            DeskGR.CopyFromScreen(New Point(CaptBound.X / 2, CaptBound.Y / 2), New Point(0, 0), New Size(CapX, CapY))

            ' STEP 3: Reduce the captured desktop area to the proper size
            StretchedGR.DrawImage(DeskBMP, New Rectangle(New Point(0, 0), New Point(Scale, Scale)))

            ' STEP 4: Lock the desired bitmap area into memory (Steps 4-6: Thanks MrPolite @ VBForums!)
            CaptRect = New Rectangle(New Point(0, 0), New Size(Scale, Scale))
            'CaptRect = New Rectangle(New Point(0, 0), New Size(CapX, CapY))
            CaptBMPData = StretchedBMP.LockBits(CaptRect, Imaging.ImageLockMode.ReadOnly, Imaging.PixelFormat.Format24bppRgb)

            ' STEP 5: Convert the desired bitmap area from BitmapData to bytes
            CaptNumBytes = CaptBMPData.Stride * CaptBMPData.Height
            Dim StretchedByteBuffer(CaptNumBytes) As Byte
            Marshal.Copy(CaptBMPData.Scan0, StretchedByteBuffer, 0, CaptNumBytes)

            ' STEP 6: Unlock the bitmap
            StretchedBMP.UnlockBits(CaptBMPData)

            ' STEP 7: Parse through the color data (NOTE: This works in an (B,G,R,B,G,R...) format)
            '       : Find the pixel that matches the ideal coordinates that is closest to the player's crosshair

            ' Misc variables
            BestDist = 9999
            MinX = 4500
            MinY = 4500
            MaxX = 0
            MaxY = 0

            ' Color parse loop that classifies targets
            CaptBMPCntr = New Point(CaptBMPData.Stride / 6, CaptBMPData.Height / 2)
            For y = 0 To CaptBMPData.Height - 1 Step (Efficiency - 1)

                ' Offsets
                Dim XOff As Integer = 0
                Dim YOff As Integer = y * CaptBMPData.Stride

                For x = 0 To CInt(CaptBMPData.Stride / 3) - 1 Step (Efficiency - 1)

                    ' Offsets
                    XOff = x * 3
                    Dim TOff As Integer = XOff + YOff

                    PixR = StretchedByteBuffer.GetValue(TOff + 2)
                    PixG = StretchedByteBuffer.GetValue(TOff + 1)
                    PixB = StretchedByteBuffer.GetValue(TOff)

                    ' Get HSV color
                    Dim PixHSV As Integer() = RGB2HSV(PixR, PixG, PixB)

                    ' Check for colors from hostile team (if target isn't hostile, continue loop)
                    '   NOTE: 120 is target HSV
                    TargetIsHostile = IsHostile(PixHSV, ColorTolerance)

                    If Not TargetIsHostile Then
                        Continue For
                    End If

                    ' Check green pixel color / Find target closest to player's crosshair
                    If TargetIsHostile Then

                        Detected = True
                        CurDist = GetDistance(CaptBMPCntr, New Point(x, y))
                        If CurDist < BestDist Then
                            BestDist = CurDist
                            CaptBestXY = New Point(x, y)
                        End If


                        If HeadSearchRange <> 0 Then

                            ' Find X min
                            Dim PixRA, PixGA, PixBA As Integer
                            Dim IsHostileA As Boolean
                            For a = x To Clamp(0, x - HeadSearchRange, x + HeadSearchRange) Step -1

                                ' Offsets
                                TOff = YOff + a * 3

                                ' Get data
                                PixRA = StretchedByteBuffer.GetValue(TOff + 2)
                                PixGA = StretchedByteBuffer.GetValue(TOff + 1)
                                PixBA = StretchedByteBuffer.GetValue(TOff)

                                ' Check if valid
                                IsHostileA = IsHostile(RGB2HSV(PixRA, PixBA, PixGA), ColorTolerance)

                                ' If invalid, exit loop and output X
                                If Not IsHostileA Then
                                    MinX = a
                                    Exit For
                                End If

                            Next

                            ' Find X max
                            For a = x To Clamp(StretchedBMP.Width - 1, x - HeadSearchRange, x + HeadSearchRange)

                                ' Offsets
                                TOff = YOff + a * 3

                                ' Get data
                                PixRA = StretchedByteBuffer.GetValue(TOff + 2)
                                PixGA = StretchedByteBuffer.GetValue(TOff + 1)
                                PixBA = StretchedByteBuffer.GetValue(TOff)

                                ' Check if valid
                                IsHostileA = IsHostile(RGB2HSV(PixRA, PixBA, PixGA), ColorTolerance)

                                ' If invalid, exit loop and output X
                                If Not IsHostileA Then
                                    MaxX = a
                                    Exit For
                                End If
                            Next

                            ' Find Y min
                            XOff = x * 3
                            For a = y To Clamp(0, y - HeadSearchRange, y + HeadSearchRange) Step -1

                                ' Offsets
                                TOff = XOff + a * CaptBMPData.Stride

                                ' Get data
                                PixRA = StretchedByteBuffer.GetValue(TOff + 2)
                                PixGA = StretchedByteBuffer.GetValue(TOff + 1)
                                PixBA = StretchedByteBuffer.GetValue(TOff)

                                ' Check if valid
                                IsHostileA = IsHostile(RGB2HSV(PixRA, PixBA, PixGA), ColorTolerance)

                                ' If invalid, exit loop and output X
                                If Not IsHostileA Then
                                    MinY = a
                                    Exit For
                                End If

                            Next

                            ' Find Y max
                            For a = y To Clamp(StretchedBMP.Height - 1, y - HeadSearchRange, y + HeadSearchRange)

                                ' Offsets
                                TOff = XOff + a * CaptBMPData.Stride

                                ' Get data
                                PixRA = StretchedByteBuffer.GetValue(TOff + 2)
                                PixGA = StretchedByteBuffer.GetValue(TOff + 1)
                                PixBA = StretchedByteBuffer.GetValue(TOff)

                                ' Check if valid
                                IsHostileA = IsHostile(RGB2HSV(PixRA, PixBA, PixGA), ColorTolerance)

                                ' If invalid, exit loop and output X
                                If Not IsHostileA Then
                                    MaxY = a
                                    Exit For
                                End If

                            Next

                            ' Check if max has been found - if so, exit loop
                            If MaxX <> 0 And MaxY <> 0 Then
                                Exit For
                            End If
                        Else

                            ' Don't conduct min-mas search
                            MinX = x - 1
                            MaxX = x + 1
                            MinY = y - 1
                            MaxY = y + 1

                        End If
                    End If
                Next

                ' Check if max has been found - if so, exit loop
                If MaxX <> 0 And MaxY <> 0 Then
                    Exit For
                End If

            Next

            ' STEP 8: Using a line-scanning algorithm, approximate the dimensions of the selected ideal target

            ' Find Height
            If CaptBMPCntr.Y > CaptBestXY.Y Then
                IterateDir = -1
            Else
                IterateDir = 1
            End If

            ' STEP 9: Find the center point and aim at it
            If Detected Then
                If (MinX + MinY) <> 9000 And MaxX <> 0 And MaxY <> 0 Then

                    ' TargetScreenAcceleration will make adjustments if the relative aimpoint on the target is off balance
                    ' Get TargetScreenAcceleration
                    If DetectedBefore Then
                        TargetScreenAcceleration = New PointF(Math.Round((MinX + MaxX - Scale) / 10) * 5, Math.Round((MinY + MaxY - Scale) / 10) * 5)
                        TargetScreenVelocity = TargetScreenVelocity + New Point(TargetScreenAcceleration.X, TargetScreenAcceleration.Y)
                    End If

                    ' DBG
                    'Console.WriteLine("ACC: (" & TargetScreenAcceleration.X & "," & TargetScreenAcceleration.Y & ")")

                    ' Get BMP target data (since it is stretched)
                    TargetBmp = New Point(((MinX + MaxX) / 2) * CapScale.X, ((MinY + MaxY) / 2) * CapScale.Y)

                    ' Get Target screen data
                    TargetScreenNew = TargetBmp + New Point((Screen.PrimaryScreen.Bounds.X - CapX) / 2, (Screen.PrimaryScreen.Bounds.Y - CapY) / 2) '+ WinUpperLeft
                    TargetScreenLead = TargetScreenNew - TargetScreen

                    ' Turn on lead if player isn't moving
                    ' Dim MoveInt As Integer = (GetAsyncKeyState(VK_W) + GetAsyncKeyState(VK_A) + GetAsyncKeyState(VK_S) + GetAsyncKeyState(VK_D))

                    ' TargetScreenLead will keep the player's aimpoint in the same spot relative to the target


                    If cbxLeadTargs.Checked Then
                        Dim TRMul As Double = 0.23
                        TargetScreen = TargetScreenNew + New Point(TargetScreenAcceleration.X * TRMul, TargetScreenAcceleration.Y * TRMul)
                    Else
                        TargetScreen = TargetScreenNew
                    End If

                    TargetRel = Point.Subtract(TargetScreen, New Point(Screen.PrimaryScreen.Bounds.X / 2, Screen.PrimaryScreen.Bounds.Y / 2))

                    ' Reset TargetScreen (so it doesn't "lead the lead")
                    TargetScreen = TargetScreenNew

                    ' Move the cursor if the desired move is long enough
                    '    Note that cursor position resets to the center after the move
                    Dim MovePt As New Point(Math.Round(TargetRel.X * Mul), Math.Round(TargetRel.Y * Mul))
                    If (MovePt.X ^ 2 + MovePt.Y ^ 2) >= MinMovementLen ^ 2 Then

                        Windows.Forms.Cursor.Position = Windows.Forms.Cursor.Position + New Point(Math.Round(TargetRel.X * Mul), Math.Round(TargetRel.Y * Mul))
                        'Else
                        '    MsgBox("Error!")
                        '    Return 0
                        'End If
                        PastMoved = New Point(Math.Round(TargetRel.X * Mul), Math.Round(TargetRel.Y * Mul))

                    End If
                End If
            Else
                TargetScreenAcceleration = New PointF
                TargetScreenVelocity = New Point
                TargetScreen = New Point(0, 0)
                TargetScreenNew = New Point(0, 0)
            End If

            DetectedBefore = Detected

            ' STEP 10: If autoshoot is on and the target is valid, fire the weapon
            If cbxAutoShoot.Checked And BestDist < 3 And Detected And (Math.Sqrt(TargetRel.X ^ 2 + TargetRel.Y ^ 2) < 5) Then
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 1)
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 1)
            End If

            ' End time (throttling)
            T_TotalTime += (My.Computer.Clock.TickCount - T_StartTime)
            T_Iterations += 1
            T_AvgTime = T_TotalTime / T_Iterations

            ' Throttle
            Dim T_SleepTime As Double = T_TargTime - T_AvgTime
            If T_SleepTime > 0 Then
                Sleep(Math.Round(T_SleepTime))
            End If

        End While

        ' Return the result.
        Return 0

    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        If rbnBlu.Checked Or rbnRed.Checked Then

            ' Wait until active window title matches game title specified by user
            While True

                If ActiveWindowData() = 1 Then
                    Exit While
                Else
                    Sleep(300)
                End If
            End While

            ' For testing purposes
            Beep()

            ' Search for GREEN squares
            GetDeskAndAimAtTarget()
        Else
            MsgBox("You haven't selected a team!")
        End If

    End Sub

    Private Function ActiveWindowData() As Integer
        Dim ActiveHWnd As Integer = GetForegroundWindow()
        Dim ActiveTitle As String = New String(" ", txtGameTitle.Text.Length + 2)
        GetWindowText(ActiveHWnd, ActiveTitle, txtGameTitle.Text.Length + 2)

        If ActiveTitle.Contains(txtGameTitle.Text) Then
            Return 1
        ElseIf ActiveTitle.Contains(Me.Text) Then
            Return 2
        Else
            Return 0
        End If

    End Function


    Private Function GetActiveWindowRect() As Rectangle
        Dim WinRect As Rectangle
        GetWindowRect(GetForegroundWindow(), WinRect)
        Return WinRect
    End Function

    ' Get distance between two points
    Public Function GetDistance(ByVal PA As Point, ByVal PB As Point) As Double
        Return Math.Sqrt((PA.X - PB.X) ^ 2 + (PA.Y - PB.Y) ^ 2)
    End Function

    ' Check if pixel is hostile
    Public Function IsHostile(ByVal HSV As Integer(), ByVal ColorTolerance As Integer) As Boolean

        ' Get team
        Dim IsBlueTeam As Boolean = rbnBlu.Checked

        ' Return hostility boolean
        If HSV.GetValue(1) > 55 And HSV.GetValue(2) * 2.55 > 20 Then
            If IsBlueTeam Then
                Return Math.Abs(HSV.GetValue(0) - 120) < ColorTolerance
            Else
                Return Math.Abs(HSV.GetValue(0) - 310) < ColorTolerance
            End If
        Else
            Return False
        End If

    End Function

    Public Function WithinRange(Val As Double, Min As Double, Max As Double) As Boolean
        If Val > Min And Val < Max Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Clamp(Val As Double, Min As Double, Max As Double)
        If Val > Max Then
            Return Max
        ElseIf Val < Min Then
            Return Min
        Else
            Return Val
        End If
    End Function

    Private Sub rbnBlu_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbnBlu.CheckedChanged
        If rbnBlu.Checked Then
            rbnRed.Checked = False
        End If
    End Sub

    Private Sub rbnRed_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbnRed.CheckedChanged
        If rbnRed.Checked Then
            rbnBlu.Checked = False
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

' Target class
'   Each target found gets an element of this class
Public Class Target

    ' Property Guide
    '   x.UpLeft    -   Get global upper-left corner
    '   x.Center    -   Get global center
    '   x.DownRight -   Get global bottom-right corner
    '   x.Height    -   Get height
    '   x.Width     -   Get width
    '   x.Team      -   Get target team
    '       TEAM GUIDE: 00 = Blue head, 10 = Red head, 01 = Blue body, 11 = Red body

End Class