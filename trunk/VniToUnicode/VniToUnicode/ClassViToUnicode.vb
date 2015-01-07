Public Class ClassViToUnicode
    Public Function VniToKD(str$) As String
        Dim VNI, KD, sKD, arrKD() As String
        Dim i As Integer
        VNI = "aù,aø,aû,aõ,aï,aâ,aê,aá,aà,aå,aã,aä,aé,aè,aú,aü,aë,AÙ,AØ,AÛ,AÕ,AÏ,AÂ,AÊ,AÁ,AÀ,AÅ,AÃ,AÄ,AÉ,AÈ,AÚ,AÜ,AË,eù,eø,eû,eõ,eï,eâ,eá,eà,eå,eã,eä,EÙ,EØ,EÛ,EÕ,EÏ,EÂ,EÁ,EÀ,EÅ,EÃ,EÄ,í ,ì ,æ ,ó ,ò ,Í ,Ì ,Æ ,Ó ,Ò ,où,oø,oû,oõ,oï,oâ,ô ,oá,oà,oå,oã,oä,ôù,ôø,ôû,ôõ,ôï,OÙ,OØ,OÛ,OÕ,OÏ,OÂ,Ô ,OÁ,OÀ,OÅ,OÃ,OÄ,ÔÙ,ÔØ,ÔÛ,ÔÕ,ÔÏ,uù,uø,uû,uõ,uï,ö ,öù,öø,öû,öõ,öï,UÙ,UØ,UÛ,UÕ,UÏ,Ö ,ÖÙ,ÖØ,ÖÛ,ÖÕ,ÖÏ,yù,yø,yû,yõ,î ,YÙ,YØ,YÛ,YÕ,Î ,ñ ,Ñ "
        KD = "a,a,a,a,a,a,a,a,a,a,a,a,a,a,a,a,a,A,A,A,A,A,A,A,A,A,A,A,A,A,A,A,A,A,e,e,e,e,e,e,e,e,e,e,e,E,E,E,E,E,E,E,E,E,E,E,i,i,i,i,i,I,I,I,I,I,o,o,o,o,o,o,o,o,o,o,o,o,o,o,o,o,o,O,O,O,O,O,O,O,O,O,O,O,O,O,O,O,O,O,u,u,u,u,u,u,u,u,u,u,u,U,U,U,U,U,U,U,U,U,U,U,y,y,y,y,y,Y,Y,Y,Y,Y,d,D"
        arrKD = Split(KD, ",")
        For i = 1 To Len(str)
            If InStr(VNI, Mid(str, i, 1) & " ") > 0 Then
                sKD = sKD & arrKD(InStr(VNI, Mid(str, i, 1) & " ") \ 3)
            ElseIf InStr(VNI, Mid(str, i, 2)) > 0 Then
                sKD = sKD & arrKD(InStr(VNI, Mid(str, i, 2)) \ 3)
                i = i + 1
            End If
            If InStr(VNI, Mid(str, i, 1)) = 0 Or InStr("a,A,e,E,o,O,u,U,y,Y, ", Mid(str, i, 1)) > 0 Then sKD = sKD & Mid(str, i, 1)
        Next
        VniToKD = sKD
    End Function
End Class
