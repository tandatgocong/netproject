<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MapGoogle.Default" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml">
  <head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title>Google Maps API Sample</title>
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=false&amp;key=ABQIAAAAuPsJpk3MBtDpJ4G8cqBnjRRaGTYH6UMl8mADNa0YKuWNNa8VNxQCzVBXTx2DYyXGsTOxpWhvIG7Djw" type="text/javascript"></script>
    <script type="text/javascript">

        function initialize() {
            if (GBrowserIsCompatible()) {
                var map = new GMap2(document.getElementById("map_canvas"));
                map.setCenter(new GLatLng(10.7546172, 106.588651), 17);

                map.setUIToDefault();
                // Create a base icon for all of our markers that specifies the
                // shadow, icon dimensions, etc.
                var baseIcon = new GIcon(G_DEFAULT_ICON);
                baseIcon.shadow = "http://www.google.com/mapfiles/shadow50.png";
                baseIcon.iconSize = new GSize(20, 34);
                baseIcon.shadowSize = new GSize(37, 34);
                baseIcon.iconAnchor = new GPoint(9, 34);
                baseIcon.infoWindowAnchor = new GPoint(9, 2);

                // Creates a marker whose info window displays the letter corresponding
                // to the given index.
                function createMarker(point, index, title) {
                    // Create a lettered icon for this point using our icon class
                    var letter = String.fromCharCode("A".charCodeAt(0) + index);
                    var letteredIcon = new GIcon(baseIcon);
                    letteredIcon.image = "http://www.google.com/mapfiles/marker" + letter + ".png";

                    // Set up our GMarkerOptions object
                    markerOptions = { icon: letteredIcon };
                    var marker = new GMarker(point, markerOptions);

                    GEvent.addListener(marker, "click", function () {
                        marker.openInfoWindowHtml(title);
                    });
                    return marker;
                }

                // Add 10 markers to the map at random locations
                var bounds = map.getBounds();
                var southWest = bounds.getSouthWest();
                var northEast = bounds.getNorthEast();
                var lngSpan = northEast.lng() - southWest.lng();
                var latSpan = northEast.lat() - southWest.lat();
                <% DataTable table = (DataTable)Session["Authenticate"];
                   for(int i=0;i<table.Rows.Count;i++)
                   {
                      %>
                      var x = parseFloat(<%=table.Rows[i][0]%>);
                      var y = parseFloat(<%=table.Rows[i][1]%>);
                      var title="<table style='height:200px;' colspan='2' align='center'><tr><td style='height:200px;' colspan='2' align='center'> <img src='<%=table.Rows[i][7]%>' width='300' height='200'</td></tr> <tr>";
                      title+="<td style='border-bottom:1px; border-bottom-style:dotted; width:10px;'>Mã Chi Nhánh:</td> <td style='border-bottom:1px; border-bottom-style:dotted; width:400px' ><%=table.Rows[i][3]%> &nbsp;</td></tr>";
                      title+="<tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>Tên Chi Nhánh</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' ><%=table.Rows[i][4]%>&nbsp;</td></tr>";
                      title+="<tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'> Địa Chỉ</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' ><%=table.Rows[i][5]%>&nbsp;</td></tr>";
                      title+=" <tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>Chủ Cửa Hàng</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' ><%=table.Rows[i][6]%>&nbsp;</td></tr>";
                      title+="</table>";
                    var latlng = new GLatLng(x,y);
                    map.addOverlay(createMarker(latlng,<%=i%>, title));
                    <%
                   }
              %>
            }
        }

    </script>
  </head>
  <body onload="initialize()" onunload="GUnload()" style="font-family: Arial;border: 0 none;">
    <div id="map_canvas" style="width: 100%; height: 600px"></div>
  </body>
</html>