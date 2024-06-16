Imports System
Imports System.Text

Public Class Kernel

    Private Shared abc As Char() = {"µ", "¸", "¶", "·", "¹", "¨", "»", "¾", "¼", "½",
   "Æ", "©", "Ç", "Ê", "È", "É", "Ë", "®", "Ì", "Ð", "Î", "Ï", "Ñ", "ª", "Ò", "Õ", "Ó",
   "Ô", "Ö", "×", "Ý", "Ø", "Ü", "Þ", "ß", "ã", "á", "â", "ä", "«", "å", "è", "æ", "ç",
   "é", "¬", "ê", "í", "ë", "ì", "î", "ï", "ó", "ñ", "ò", "ô", "", "õ", "ø", "ö", "÷", "ù",
   "ú", "ý", "û", "ü", "þ", "¡", "¢", "§", "£", "¤", "¥", "¦"}
    Private Shared uni As Char() = {"à", "á", "ả", "ã", "ạ", "ă", "ằ", "ắ", "ẳ", "ẵ",
   "ặ", "â", "ầ", "ấ", "ẩ", "ẫ", "ậ", "đ", "è", "é", "ẻ", "ẽ", "ẹ", "ê", "ề", "ế", "ể",
   "ễ", "ệ", "ì", "í", "ỉ", "ĩ", "ị", "ò", "ó", "ỏ", "õ", "ọ", "ô", "ồ", "ố", "ổ", "ỗ",
   "ộ", "ơ", "ờ", "ớ", "ở", "ỡ", "ợ", "ù", "ú", "ủ", "ũ", "ụ", "ư", "ừ", "ứ", "ử", "ữ", "ự",
   "ỳ", "ý", "ỷ", "ỹ", "ỵ", "Ă", "Â", "Đ", "Ê", "Ô", "Ơ", "Ư"}
    Private Shared convertTable As Char()
    Shared Sub New()
        convertTable = New Char(255) {}
        For i As Integer = 0 To 255
            convertTable(i) = CChar(ChrW(i))
        Next
        For i As Integer = 0 To abc.Length - 1
            convertTable(AscW(abc(i))) = uni(i)
        Next
    End Sub
    Public Function abc2uni(value As String) As String
        Dim chars As Char() = value.ToCharArray()
        For i As Integer = 0 To chars.Length - 1
            If chars(i) < CChar(ChrW(256)) Then
                chars(i) = convertTable(AscW(chars(i)))
            End If
        Next
        Return New String(chars)
    End Function
End Class
