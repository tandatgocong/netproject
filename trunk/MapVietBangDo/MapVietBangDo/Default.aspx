<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MapVietBangDo.Default" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://www.vietbando.com/maps/API/VBDMapAPI.js?key=e7vjH+pgQHuSyV75dwG6humI2IiGAfka"></script>
     <script type="text/javascript">
         function loadMap() {
             if (VBrowserIsCompatible()) {
                 var map = new VMap(document.getElementById('container'));
                <% DataTable table = (DataTable)Session["Authenticate"];
                   for(int i=0;i<table.Rows.Count;i++)
                   {
                      %>
                      var alert="--";
                            alert="<table style='height:200px;' colspan='2' align='center'><tr><td style='height:200px;' colspan='2' align='center'> <img src='<%=table.Rows[i][7]%>' width='300' height='200'</td></tr> <tr>";
                            alert+="<td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>Mã Chi Nhánh:</td> <td style='border-bottom:1px; border-bottom-style:dotted; width:400px' ><%=table.Rows[i][3]%> &nbsp;</td></tr>";
                            alert+="<tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>Tên Chính</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' ><%=table.Rows[i][4]%>&nbsp;</td></tr>";
                            alert+="<tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>Địa Chỉ</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' ><%=table.Rows[i][5]%>&nbsp;</td></tr>";
                            alert+=" <tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>Chủ Cửa Hàng</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' ><%=table.Rows[i][6]%>&nbsp;</td></tr>";
                            alert+="</table>";
                            var x = parseFloat(<%=table.Rows[i][0]%>);
                            var y = parseFloat(<%=table.Rows[i][1]%>);

                           map.setCenter(new VLatLng(x, y), 17);
                           var marker = new VMarker(map.getCenter(), new VIcon("http://www.vietbando.com/images/mymap_icon/point_7.gif", new VSize(32, 32)),false);
                         
                           map.addOverlay(marker);
                          
                           VEvent.addListener(marker, 'click', function(obj, latlng) { 
                                   obj.openInfoWindow(alert); 
                               });

                           VEvent.addListener(marker, 'mouseover', function(obj){
                               var icon = new VIcon("http://www.vietbando.com/images/mymap_icon/point_6.gif", new VSize(32, 32));
                               obj.setIcon(icon);
                           });

                           VEvent.addListener(marker, 'mouseout', function(obj){
                               var icon = new VIcon("http://www.vietbando.com/images/mymap_icon/point_7.gif", new VSize(32, 32));
                               obj.setIcon(icon);
                           });


//                            var pt = new VLatLng(x,y);
//                            map.setCenter(pt, 17);
//                            var marker = new VMarker(pt, new VIcon());
//                            map.addOverlay(marker);
                      <%
                   }
                     %>
                   map.addControl(new VLargeMapControl(), new VControlPosition(V_ANCHOR_TOP_LEFT, new VSize(5, 5)));

            }
         }
   
    </script>
</head>
<body onload="loadMap()">
    <div id="container" title="fdasfds" style="height:600px; width:98%; position:relative; margin:10px; border:1px #b1c4d5 solid;"></div>
</body>
</html>
