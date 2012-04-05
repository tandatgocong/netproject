<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="MapGoogle.add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml">
  <head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8"/>
    <title>Demo</title>
    <link rel="stylesheet" type="text/css" href="Scripts/headmenu.css" />
    <script src="Scripts/headmenu.js" type="text/javascript"></script>
    <link href="Styles/StyleSheet.css" rel="stylesheet" type="text/css" />    
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=false&amp;key=ABQIAAAA1rQGElPxuPCGQfDh4lpWBhS3nu3yB_afl-p-5uIRtWNtWiAy8BRw5TQQfI1RNaVugEAFrfkgju8IHQ" type="text/javascript"></script>
      <script type="text/javascript">
          function removeElement(divNum) {
              var d = document.getElementById('attach_file');
              var olddiv = document.getElementById(divNum);
              d.removeChild(olddiv);
          }

          var fileFieldCount = 0;
          function addFileField() {
              if (fileFieldCount >= 9) return false
              fileFieldCount++;
              var f = document.createElement("input");
              f.id = "theFile" + fileFieldCount;
              f.type = "file";
              f.size = 120;
              f.name = "theFile" + fileFieldCount;
              p = document.getElementById("attachments_fields");
              p.appendChild(document.createElement("br"));
              p.appendChild(f);
          }
      </script>
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
    <div  id="map_canvas" class="map_canvas" style="width: 100%; height:680px;">
        <br />
        <table style="width:100%;">            

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
                    Tên Cửa Hàng :</td>
                <td class="style20">
                    <asp:TextBox ID="txtTenChiNhanh" runat="server" Height="27px" Width="343px"></asp:TextBox>
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtTenChiNhanh" 
                        ErrorMessage="Tên Cửa Hàng Không Được Trống" ForeColor="Red"></asp:RequiredFieldValidator>
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
                    &nbsp;</td>
                <td class="style10">
                    Loại CH :</td>
                <td class="style21">
                    <asp:TextBox ID="txtLoaiCH" runat="server" Height="27px" Width="343px"></asp:TextBox>
                </td>
                <td class="style11">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    Trưng Bày</td>
                <td class="style21">
                    <asp:TextBox ID="txtTrungBay" runat="server" Height="27px" Width="343px"></asp:TextBox>
                </td>
                <td class="style11">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    Tần Số</td>
                <td class="style21">
                    <asp:TextBox ID="txtTanSo" runat="server" Height="27px" Width="343px"></asp:TextBox>
                </td>
                <td class="style11">
                     
</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    Số Call</td>
                <td class="style21">
                    <asp:TextBox ID="txtSoCall" runat="server" Height="27px" Width="343px"></asp:TextBox>
                </td>
                <td class="style11">
                    &nbsp;</td>
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style12">
                </td>
                <td class="style13">
                    </td>
                <td class="style18"><asp:Image ID="imgFile" runat="server" Height="208px" 
                        Width="349px" />
                </td>
                <td class="style14" valign="bottom"><div class="criteria_scroll">
                <%
                    string filelis = Session["imgfile"].ToString();
                    string[] words = Regex.Split(filelis, ",");
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!words[i].Equals("")) {
                            Response.Write("<img  src=" + words[i] + " Height='100px' Width='200px' /> ");
                        }
                         
                    }
                  %>
                    </div>
                    </td>
            </tr>
            <tr>
                <td class="style15">
                </td>
                <td class="style16">
                    Chọn Hình</td>
                <td class="style19">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                    <asp:Button ID="Button1" runat="server" 
                        Text="Upload" onclick="Button1_Click" ValidationGroup="adsfdsafd" />
                    <asp:HiddenField ID="imagePath" runat="server" />
                </td>
                <td class="style17">
                    <asp:Label ID="upload" runat="server" ForeColor="Red"></asp:Label>
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