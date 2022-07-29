Imports System.IO
Imports AForge
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing
Public Class Form1
    Dim CAMERA As VideoCaptureDevice
    Dim bmp As Bitmap
    Private Sub addbtn_Click(sender As Object, e As EventArgs) Handles addbtn.Click
        lb1.Items.Add(tb1.Text)


    End Sub

    Private Sub savebtn_Click(sender As Object, e As EventArgs) Handles savebtn.Click

        Dim file As System.IO.StreamWriter
        Dim x As Integer
        file = New IO.StreamWriter("C:\Users\Lim\OneDrive\Desktop\vbassignment3\" & FullName.Text & ".txt")
        For x = 0 To lb1.Items.Count - 1
            file.WriteLine(lb1.Items.Item(x))
        Next

        file.Close()

    End Sub

    Private Sub clearbtn_Click(sender As Object, e As EventArgs) Handles clearbtn.Click


        lb1.Items.Clear()

    End Sub

    Private Sub getfilebtn_Click(sender As Object, e As EventArgs) Handles getfilebtn.Click

        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Lim\OneDrive\Desktop\vbassignment3\" & FullName.Text & ".txt")
        Dim stringReader As String

        While Not fileReader.EndOfStream
            stringReader = fileReader.ReadLine()
            stringReader &= vbCrLf & fileReader.ReadLine()
            stringReader &= vbCrLf & fileReader.ReadLine()
            stringReader &= vbCrLf & fileReader.ReadLine()
            stringReader &= vbCrLf & fileReader.ReadLine()
            MsgBox(stringReader)
        End While
        fileReader.Close()

    End Sub

    Private Sub startbtn_Click(sender As Object, e As EventArgs) Handles startbtn.Click
        Dim cameras As VideoCaptureDeviceForm = New VideoCaptureDeviceForm
        If cameras.ShowDialog() = Windows.Forms.DialogResult.OK Then
            CAMERA = cameras.VideoDevice
            AddHandler CAMERA.NewFrame, New NewFrameEventHandler(AddressOf Captured)
            CAMERA.Start()
        End If
    End Sub

    Private Sub Captured(sender As Object, eventArgs As NewFrameEventArgs)
        bmp = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        PictureBox1.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)
    End Sub

End Class
