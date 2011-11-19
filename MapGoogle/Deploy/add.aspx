<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="MapGoogle.add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml">
  <head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title>Demo</title>
    <link rel="stylesheet" type="text/css" href="Scripts/headmenu.css" />
    <script src="Scripts/headmenu.js" type="text/javascript"></script>
    <link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" />    
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=false&amp;key=ABQIAAAAuPsJpk3MBtDpJ4G8cqBnjRRaGTYH6UMl8mADNa0YKuWNNa8VNxQCzVBXTx2DYyXGsTOxpWhvIG7Djw" type="text/javascript"></script>
      <style type="text/css">
          .style3
          {
              width: 90px;
              height: 33px;
          }
          .style4
          {
              width: 93px;
              height: 33px;
          }
          .style5
          {
              height: 33px;
          }
          .style9
          {
              width: 90px;
              height: 35px;
          }
          .style10
          {
              width: 93px;
              height: 35px;
          }
          .style11
          {
              height: 35px;
          }
          #Reset1
          {
              height: 30px;
              width: 94px;
             font :normal 18px Times New Roman;
             font-weight :bold;
             color:#663300;
          }
          .style12
          {
              width: 90px;
              height: 208px;
          }
          .style13
          {
              width: 93px;
              height: 208px;
          }
          .style14
          {
              height: 208px;
          }
          .style15
          {
              width: 90px;
              height: 32px;
          }
          .style16
          {
              width: 93px;
              height: 32px;
          }
          .style17
          {
              height: 32px;
          }
          .style18
          {
              height: 208px;
              width: 349px;
          }
          .style19
          {
              height: 32px;
              width: 349px;
          }
          .style20
          {
              height: 33px;
              width: 349px;
          }
          .style21
          {
              height: 35px;
              }
      </style>
  </head>
 <form id="Form1" method="post" runat="server" enctype="multipart/form-data">
  <div id="Home">
       <!-- <div class="Header"> -->
            <!-- <img src="/portal/Image/logo.png" style=" margin-top:4px;" /> -->
        <!-- </div> -->
        <div class="menu"> 
            <ul id="mnIntro">			
                <li><a href="#" ><a href="Default.aspx">TRANG CHỦ</a></a></li>
                <li><a href="#" class="act">THÊM MỚI CHI NHÁNH</a></li>
                                
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
    <div  id="map_canvas" class="map_canvas" style="width: 100%; height:580px;">
        <br />
        <table style="width:100%;">
            <tr>
                <td class="style12">
                </td>
                <td class="style13">
                    </td>
                <td class="style18">&nbsp;<asp:Image ID="imgFile" runat="server" Height="200px" 
                        Width="300px" />
                </td>
                <td class="style14">
                    </td>
            </tr>
            <tr>
                <td class="style15">
                </td>
                <td class="style16">
                    Chọn Hình</td>
                <td class="style19">
                   <input id="filMyFile" type="file" runat="server"><br />
                    <asp:Button ID="Button1" runat="server" 
                        Text="Upload" onclick="Button1_Click" ValidationGroup="adsfdsafd"   />
                    <asp:HiddenField ID="imagePath" runat="server" />
                </td>
                <td class="style17">
                    <asp:Label ID="upload" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style4">
                    Mã Chi Nhánh :</td>
                <td class="style20">
                    <asp:TextBox ID="txtMaChiNhanh" runat="server" Height="27px" Width="343px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtMaChiNhanh" ErrorMessage="Mã Chi Nhánh Không Được Trống" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style4">
                    Tên Chi Nhánh :</td>
                <td class="style20">
                    <asp:TextBox ID="txtTenChiNhanh" runat="server" Height="27px" Width="343px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtTenChiNhanh" 
                        ErrorMessage="Tên Chi Nhánh Không Được Trống" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style4">
                    Địa Chỉ :</td>
                <td class="style20">
                    <asp:TextBox ID="txtDiaChi" runat="server" Height="27px" Width="343px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtDiaChi" ErrorMessage="Địa Chỉ Chi Nhánh Không Được Trống" 
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style9">
                </td>
                <td class="style10">
                    Chủ Cửa Hàng:</td>
                <td class="style21">
                    <asp:TextBox ID="txtChuCuaHang" runat="server" Height="27px" Width="343px"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtChuCuaHang" 
                        ErrorMessage="Tên Chủ Cửa Hàng Không Được Trống" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td class="style21">
                    <asp:Button ID="btSearch" runat="server" Height="30px"  Text="Thêm Mới" 
                        Width="115px" Font-Bold="True" Font-Names="Times New Roman" 
                        Font-Size="12pt" ForeColor="#663300" onclick="btSearch_Click"  />
                    <input id="Reset1" type="reset" value="Làm Lại" />
                    </td>
                <td class="style11">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td class="style21" colspan="2">
                    <asp:Label ID="lbThanhCong" runat="server" ForeColor="Blue" Font-Bold="True" 
                        Font-Size="13pt"></asp:Label>
                    </td>
            </tr>
        </table>
      </div>
    
    <div class="footer"  style="background-color:White; height:32px;width: 100%;"> Hệ Thống Quản Lý Phân Phối Kinh Doanh</div>
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
        function Button3_onclick() {

        }

        function Button3_onclick() {
            alert(document.getElementById("File1").value);
        }

    </script>

      </form>

  </body>
</html>