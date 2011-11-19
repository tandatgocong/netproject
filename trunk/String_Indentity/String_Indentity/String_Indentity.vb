Imports Microsoft.VisualBasic
Imports System
Imports System.Diagnostics
Public Class String_Indentity
    Public Function ID(kytumacdinh As String, chuoibd As String, chuoidinhdang As String)
        Return kytumacdinh + Strings.Format(Conversion.Val(Strings.Right(chuoibd, (chuoibd.Length - kytumacdinh.Length))) + 1.0, chuoidinhdang)
    End Function
    Public Function ID(kytumacdinh As String, chuoibd As String, chuoidinhdang As String, sotang As Integer)
        Return kytumacdinh + Strings.Format(Conversion.Val(Strings.Right(chuoibd, (chuoibd.Length - kytumacdinh.Length))) + sotang, chuoidinhdang)
    End Function
End Class
