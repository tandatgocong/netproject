<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MapGoogle.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml">
  <head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title>Demo</title>
    <link rel="stylesheet" type="text/css" href="Scripts/headmenu.css" />
    <script src="Scripts/headmenu.js" type="text/javascript"></script>
    <link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" />  
    <link href="Styles/DialogModel.css" rel="stylesheet" type="text/css" />    
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=false&amp;key=ABQIAAAA1rQGElPxuPCGQfDh4lpWBhS3nu3yB_afl-p-5uIRtWNtWiAy8BRw5TQQfI1RNaVugEAFrfkgju8IHQ" type="text/javascript"></script>
     <style type="text/css">
         @import url("http://www.google.com/uds/css/gsearch.css");
      @import url("http://www.google.com/uds/solutions/localsearch/gmlocalsearch.css");
         </style>

    <script src="http://www.google.com/uds/api?file=uds.js&amp;v=1.0" type="text/javascript"></script>
    <script src="http://www.google.com/uds/solutions/localsearch/gmlocalsearch.js" type="text/javascript"></script>
    <script type="text/javascript">

        function TextualZoomControl() {}
            TextualZoomControl.prototype = new GControl();
            TextualZoomControl.prototype.initialize = function(map) {
              var container = document.createElement("div");
                var zoomInDiv = document.createElement("div");
              this.setButtonStyle_(zoomInDiv);
              container.appendChild(zoomInDiv);
              zoomInDiv.appendChild(document.createTextNode("Hệ Thống Quản Lý Phân Phối Kinh Doanh"));
              map.getContainer().appendChild(container);
              return container;
            }

            TextualZoomControl.prototype.getDefaultPosition = function() {
              return new GControlPosition(G_ANCHOR_BOTTOM_LEFT, new GSize(0, 0));
        }
        // Sets the proper CSS for the given button element.
        TextualZoomControl.prototype.setButtonStyle_ = function(button) {
          button.style.color = "#663300";
          button.style.backgroundColor = "white";
          button.style.font = "normal 15px Arial, Tahoma, Helvetica, sans-serif";
          button.style.fontWeight = "bold";
          button.style.border = "0px solid black";
          button.style.padding = "0px";
          button.style.verticalAlign= "middle";
          button.style.width = "1354px";
          button.style.height = "32px";
          button.style.marginBottom = "0px";
          button.style.textAlign = "center";
        }

        function initialize() {
            if (GBrowserIsCompatible()) {
                var map = new GMap2(document.getElementById("map_canvas"));
                
                 map.addControl(new TextualZoomControl());
                 
                 map.setUIToDefault();
                var baseIcon = new GIcon(G_DEFAULT_ICON);
                baseIcon.iconSize = new GSize(20, 34);
                baseIcon.shadowSize = new GSize(37, 34);
                baseIcon.iconAnchor = new GPoint(9, 34);
                baseIcon.infoWindowAnchor = new GPoint(9, 2);

                function createMarker(point, index, title) {
                    var letter = String.fromCharCode("A".charCodeAt(0) + index);
                    var letteredIcon = new GIcon(baseIcon);
                    letteredIcon.image = "Image/orange.png";
                    markerOptions = { icon: letteredIcon };
                    var marker = new GMarker(point, markerOptions);

                    GEvent.addListener(marker, "click", function () {
                        marker.openInfoWindowHtml(title);
                    });
                    return marker;
                }

                var bounds = map.getBounds();
                var southWest = bounds.getSouthWest();
                var northEast = bounds.getNorthEast();
                var lngSpan = northEast.lng() - southWest.lng();
                var latSpan = northEast.lat() - southWest.lat();
                <% 
                       DataTable table = new DataTable();
                       if(Session["Authenticate"]!=null)
                       {
                        table = (DataTable)Session["Authenticate"];
                       }else{
                       %>
                        alert("Không Tìm Thấy Địa Chi");
                       <%
                       table = (DataTable)Session["tmp"];
                       }
                       for(int i=0;i<table.Rows.Count;i++)
                       {
                        string filelis ="";
                        string[] words = Regex.Split(table.Rows[i][11].ToString(), ",");
                        for (int j= 0; j < words.Length; j++)
                        {
                            if (!words[j].Equals("")) {
                               filelis+=" <img  src='" + words[j] + "' width='300' height='200' />  ";
                            }
                         
                        }
                          %>
                          var x = parseFloat(<%=table.Rows[i][0]%>);
                          var y = parseFloat(<%=table.Rows[i][1]%>);
                           map.setCenter(new GLatLng(x,y), 17);
                          var title="<div class='title_page'><%=table.Rows[i][4]%> </div> <br/><table style='height:200px; colspan='2' align='center'><tr><td colspan='2' align='center'> </td></tr> <tr>";
                          title+="<td style='border-bottom:1px; border-bottom-style:dotted; width:10px;'>&nbsp; &nbsp; Mã Chi Nhánh</td> <td style='border-bottom:1px; border-bottom-style:dotted; width:400px' >: <%=table.Rows[i][3]%> &nbsp;</td></tr>";
                          title+="<tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>&nbsp; &nbsp; Địa Chỉ</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' >: <%=table.Rows[i][5]%>&nbsp;</td></tr>";
                          title+="<tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>&nbsp; &nbsp; Loại Cửa Hàng</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' >: <%=table.Rows[i][6]%>&nbsp;</td></tr>";
                          title+="<tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>&nbsp; &nbsp; Trưng Bày</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' >: <%=table.Rows[i][7]%>&nbsp;</td></tr>";
                          title+="<tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>&nbsp; &nbsp;T ần Số</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' >: <%=table.Rows[i][8]%>&nbsp;</td></tr>";
                          title+="<tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>&nbsp; &nbsp; Số Call</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' >: <%=table.Rows[i][9]%>&nbsp;</td></tr>";
                          title+=" <tr><td style='border-bottom:1px; border-bottom-style:dotted; width:100px;'>&nbsp; &nbsp;  Chủ Cửa Hàng</td><td style='border-bottom:1px; border-bottom-style:dotted; width:400px' >: <%=table.Rows[i][10]%>&nbsp;</td></tr>";
                          title+=" <tr><td colspan='2' align='center' style='border-bottom:1px; border-bottom-style:dotted; height:200px; width:100px;'> <marquee behavior='scroll' direction='left' onmouseover='this.stop();' onmouseout='this.start();'> <%=filelis%> </marquee></td></tr>";
                          title+="</table>";
                        var latlng = new GLatLng(x,y);
                        map.addOverlay(createMarker(latlng,<%=i%>, title));
                        <%
                     }
              %>
             map.addControl(new google.maps.LocalSearch(), new GControlPosition(G_ANCHOR_BOTTOM_RIGHT, new GSize(0, 0)));
             GEvent.addListener(map,"click", function(overlay,latlng) {     
              if (latlng) {   
                var location =latlng.toString().replace(" ","");
                var myHtml = "Địa Chỉ Chưa Có Chi Nhánh. Click <a href='add.aspx?location="+location+"'>Thêm Mới Chi Nhánh</a> để thêm mới Chi Nhánh.";
                map.openInfoWindow(latlng, myHtml);
              }
            });
            }
             GSearch.setOnLoadCallback(initialize);
     }

    </script>
  </head>
  <body onload="initialize()" onunload="GUnload()" >
      <form id="form1" runat="server">
      

  <div id="Home">
       <!-- <div class="Header"> -->
            <!-- <img src="/portal/Image/logo.png" style=" margin-top:4px;" /> -->
        <!-- </div> -->
        <div class="menu"> 
            <ul id="mnIntro">			
                <li><a href="#" class="act">TRANG CHỦ</a></li>
                
                <li > &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp;
&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;   &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  
&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  
                    <%--<ul style="overflow: hidden; display: block; height: 0px; z-index: 59; opacity: 0.0119048;">
                        <li><a href="#">SUB MENU 1</a></li>
                        <li><a href="#">SUB MENU 2</a></li>
                        <li><a href="#">SUB MENU 3</a></li>
                    </ul>    --%>                    
                </li>
                
                <li>  &nbsp;&nbsp; 
                    <asp:TextBox ID="textSearchDiaChi" runat="server" Height="25px" Width="296px" 
                        Font-Size="12pt"></asp:TextBox>
&nbsp;
                    <asp:Button ID="btSearch" runat="server" Height="30px"  Text="Tìm Địa Chỉ" 
                        Width="115px" Font-Bold="True" Font-Names="Times New Roman" 
                        Font-Size="12pt" ForeColor="#663300" onclick="btSearch_Click" />
&nbsp;&nbsp;&nbsp;  
                    <%-- <ul style="overflow: hidden; display: block; height: 0px; z-index: 60; opacity: 0.00714286;">                            
                         <li><a href="#">SUB MENU 2</a></li>                 
                         <li><a href="#">SUB NENU 3</a></li>                        
                         <li><a href="#">SUB NENU 3</a></li> 
                         <li><a href="#">SUB NENU 3</a></li> 
                         <li><a href="#">SUB NENU 3</a></li>                         
                    </ul>      --%>              
                </li>
                
              <!--  <li><a class="   " href="#">MENU 3</a>
                    <ul style="overflow: hidden; display: block; height: 0px; z-index: 61; opacity: 0.00510204;">
                        <li><a href="#">SUB MENU 3</a></li>
                        <li><a href="#">SUB MENU 3</a></li>
                        <li><a href="#">SUB MENU 3</a></li>
                        <li><a href="#">SUB MENU 3</a></li>
                        <li><a href="#">SUB MENU 3</a></li>
                        <li><a href="#">SUB MENU 3</a></li>
                        <li><a href="#">SUB MENU 3</a></li>
                    </ul>
                    
                </li>
                
                <li><a class="  " id="lnk_tinABB" href="#">MENU 4</a>
                        <ul style="overflow: hidden; display: block; height: 0px; z-index: 62; opacity: 0.00892857;">                              
                                <li><a href="#">SUB MENU 4</a></li>
                                <li><a href="#">SUB MENU 4</a></li>
                                <li><a href="#">SUB MENU 4</a></li>
                                <li><a href="#">SUB MENU 4</a></li>
                            </ul>
                </li>
                
                <li><a class="  " href="#">MENU 5</a>
                    <ul style="overflow: hidden; display: block; height: 0px; z-index: 63; opacity: 0.0119048;">
                        <li><a href="#">SUB MENU 5</a></li>
                        <li><a href="#">SUB MENU 5</a></li>
                        <li><a href="#">SUB MENU 5</a></li>
                    </ul>
                </li>-->
                                
                </ul>
                
            <script type="text/javascript">
                var menu1 = new menu.dd("menu1");
                menu1.init("mnIntro");
            </script>  
            
            <div class="date_time">
                 <span style="width:130px;" id="clock"></span>        	 
            </div>      
        </div>    
        </div>
    <div  id="map_canvas" class="map_canvas" style="width: 100%; height:612px;"></div>
    

    <script language="javascript">
        function HamThoiGian() {
            var ThoiGian = new Date();
            var Gio = ThoiGian.getHours();
            var Phut = ThoiGian.getMinutes();
            var Giay = ThoiGian.getSeconds();
            if (Gio < 10) {
                Gio = "0" + Gio;
            }
            if (Phut < 10) {
                Phut = "0" + Phut;
            }
            if (Giay < 10) {
                Giay = "0" + Giay;
            }
            var ngay = ThoiGian.getDay();
            var thang = ThoiGian.getMonth() + 1;
            var nam = ThoiGian.getFullYear();
            if (ngay < 10)
                ngay = "0" + ngay;
            if (thang < 10)
                thang = "0" + thang;
            document.getElementById("clock").innerHTML = ngay + "/" + thang + "/" + nam + "  " + Gio + ":" + Phut + ":" + Giay;
        }
        setInterval("HamThoiGian()", 1000);
</script>

      </form>

  </body>
</html>