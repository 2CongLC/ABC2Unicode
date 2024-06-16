Imports System
Imports System.IO
Imports System.Text
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK AndAlso SaveFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                Dim src As Byte() = File.ReadAllBytes(OpenFileDialog1.FileName)
                Dim s1 = Encoding.Default.GetString(src)
                Dim c As New Kernel()
                Dim s2 = c.abc2uni(s1)
                Dim s3 = Encoding.Unicode.GetBytes(s2)
                Dim ext = Path.GetExtension(OpenFileDialog1.FileName)
                File.WriteAllBytes(SaveFileDialog1.FileName & ext, s3)
                MessageBox.Show("Đã chuyển đổi xong")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim args() As String = Environment.GetCommandLineArgs()
        Dim cmd As String = ""
        Dim input As String = ""
        Dim output As String = ""

        If args.Length <> 0 Then
            If args.Length > 1 Then cmd = args(1)
            If args.Length > 2 Then input = args(2)
            If args.Length > 3 Then output = args(3)
            If input <> "" AndAlso output <> "" Then
                If cmd.Contains("-c") Then
                    Dim src() As Byte = File.ReadAllBytes(input)
                    Dim k As Kernel = New Kernel()
                    Dim s1 As String = Encoding.Default.GetString(src)
                    Dim s2 As String = k.abc2uni(s1)
                    Dim data() As Byte = Encoding.Unicode.GetBytes(s2)
                    File.WriteAllBytes(output, data)
                    If MessageBox.Show("Đã chuyển đổi xong") = DialogResult.OK Then Me.Close()
                End If
            End If
        End If
    End Sub
End Class
