Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

' Made this nice and easy using some object oriented paradigms
Public Class BitBlt

    ' Byte buffer
    Private ByteBuffer As Byte()

    ' Size of image (in terms of x-y coordinates)
    Private ImgSize As New Size(0, 0)

    ' Constructor (from an image - "decompiling")
    Public Sub New(ByVal Image As Bitmap)

        ' Lock the desired bitmap area into memory (Thanks MrPolite @ VBForums!)
        Dim ImgRect As Rectangle = New Rectangle(New Point(0, 0), Image.Size)
        Dim BMPData As BitmapData = Image.LockBits(ImgRect, Imaging.ImageLockMode.ReadOnly, Imaging.PixelFormat.Format32bppArgb)

        ' Convert the desired bitmap area from BitmapData to bytes
        Dim NumBytes As Integer = (Image.Width * 3) * Image.Height
        Dim ImgAsByteBuffer(NumBytes) As Byte
        Marshal.Copy(BMPData.Scan0, ImgAsByteBuffer, 0, NumBytes)

        ' Unlock the bitmap
        Image.UnlockBits(BMPData)

        ' Store image locally
        ImgSize = Image.Size
        ByteBuffer = ImgAsByteBuffer

    End Sub

    ' Constructor (from a BitBlt array)
    Public Sub New(ByVal ImageAsByteBuffer As Byte(), ByVal ImageSize As Size)

        ByteBuffer = ImageAsByteBuffer
        ImgSize = ImageSize

    End Sub

    ' GetPixel (as a color)
    '   NOTE: The reason there is no GetPixel that returns pure numbers is because returning number arrays is prone to errors (which one is R? G? B? etc...)
    Public Function GetPixel(ByVal x As Integer, ByVal y As Integer)

        ' Check to make sure values are within range
        If (x < 0 OrElse y < 0) OrElse (x >= ImgSize.Width OrElse y >= ImgSize.Height) Then
            Throw New ArgumentOutOfRangeException() ' Values are out of range
        End If

        ' Get pixel
        Dim Offset As Integer = (x * 4) + (y * ImgSize.Width * 4)
        Dim PixClr As Color = Color.FromArgb(ByteBuffer.GetValue(Offset + 1), ByteBuffer.GetValue(Offset + 2), ByteBuffer.GetValue(Offset + 3))

        ' Return result
        Return PixClr

    End Function
    Public Function GetPixel(ByVal Point As Point)
        Return GetPixel(Point.X, Point.Y)
    End Function

    ' SetPixel (as a color)
    Public Sub SetPixel(ByVal x As Integer, ByVal y As Integer, ByVal Color As Color)

        ' Base offset
        Dim Offset As Integer = (x * 4) + (y * ImgSize.Width * 4)

        ' Check to make sure that pixels being referred to are valid
        If Offset > ByteBuffer.Length - 4 Then
            Throw New ArgumentOutOfRangeException()
        End If

        ' Update main byte array
        ByteBuffer.SetValue(Color.R, Offset + 1)
        ByteBuffer.SetValue(Color.G, Offset + 2)
        ByteBuffer.SetValue(Color.B, Offset + 3)

    End Sub

    ' SetPixel (as integers)
    Public Sub SetPixel(ByVal x As Integer, ByVal y As Integer, ByVal r As Integer, ByVal g As Integer, ByVal b As Integer)

        ' Verify that color is valid
        If r < 0 OrElse r > 255 OrElse _
         g < 0 OrElse g > 255 OrElse _
         b < 0 OrElse g > 255 Then
            Throw New ArgumentOutOfRangeException("Invalid color conversion. Color values must be 0-255 inclusive.")
        End If

        ' Perform set-pixel operation
        SetPixel(x, y, Color.FromArgb(r, g, b))

    End Sub

End Class
