<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebDemo.View.Pages.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <script type="text/javascript" src="http://www.vietbando.com/maps/API/VBDMapAPI.js?key=E43pcmZHdUjLbKWs6ZRT37AfM3bjSbjt2Yqk4Yi0HN0="></script>
    <script type="text/javascript">
function loadMap()
{
    if (VBrowserIsCompatible())
    {
       var map = new VMap(document.getElementById('container'));
       var pt = new VLatLng(10.8152328, 106.680505);
       map.setCenter(pt, 4);
       var marker = new VMarker(pt, new VIcon());
       map.addOverlay(marker);

       var pt1 = new VLatLng(10.2, 106.680505);
       map.setCenter(pt1, 4);
       var marker1 = new VMarker(pt1, new VIcon());
       map.addOverlay(marker1);

    }
}
</script>
</head>

<body onload="loadMap()">
<div id="container" style="height:600px; position:relative; margin:10px; border:1px #b1c4d5 solid;"></div>
</body>
</html>
