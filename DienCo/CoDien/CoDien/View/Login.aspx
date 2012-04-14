<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CoDien.View.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>...: ĐĂNG NHẬP HỆ THỐNG :...</title>
    <link href="../StyleSheet/Menu.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../JavaScript/transmenu.js" type="text/javascript"></script>
   
    <style type="text/css">
        .style1
        {
            width: 310px;
            height: 40px;
        }
        .style2
        {
            width: 1366px;
            height: 40px;
        }
        .style3
        {
            width: 310px;
            height: 45px;
        }
        .style4
        {
            width: 1366px;
            height: 45px;
        }
        .style5
        {
            height: 65px;
        }
        .style6
        {
            width: 310px;
            height: 33px;
        }
        .style7
        {
            width: 1366px;
            height: 33px;
        }
        .button
        {}
    </style>
   
</head>
<body st>
    <form id="form1" runat="server">
    <br />
    <br />
    <center>
    <table border="0"  style="width:48%; ">
        <tr>
            <td colspan="2" class="style5">
                <table class="dangkytop" border="0" cellpadding="0" cellspacing="0" id="TABLE1">
                    <tr>
                        <td class="dkt1" style="height: 32px">
                        </td>
                        <td class="dkt2" style="width: 524px; height: 32px"><div class="title_page" style=" margin-top: 15px; font-size:16px; width:99%"> 
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" 
                                Text="THÔNG TIN ĐĂNG NHẬP"></asp:Label></div>
                           </td>
                        <td  class="dkt3" style="height: 32px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: right;" valign="top" 
                class="style1">
                <asp:Label ID="Label2" runat="server" Text="Tên đăng nhập :" Width="151px" 
                    style="text-align: right" Font-Bold="True" Font-Size="Large"></asp:Label></td>
            <td style="text-align: left;" valign="top" class="style2">
                <asp:TextBox ID="txtusername" runat="server" Width="177px" Height="25px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="(*)" ControlToValidate="txtusername" ForeColor="Red"></asp:RequiredFieldValidator>&nbsp; </td>
        </tr>
        <tr>
            <td style="text-align: right; vertical-align: text-top;" valign="top" 
                class="style6">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Mật Khẩu :"></asp:Label>
            </td>
            <td style="text-align: left;" valign="top" class="style7">
                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"
                    Width="178px" Height="25px"></asp:TextBox>  
                </td>
        </tr>
        <tr>
            <td style="text-align: right; vertical-align: text-top;" valign="top" 
                class="style3">
            </td>
            <td style="text-align: left;" valign="top" class="style4">
                 <asp:Button ID="Button1" runat="server"  Text="Đăng Nhập" Width="122px" 
                    onclick="Button1_Click" CssClass="button" Height="29px" />&nbsp;&nbsp;&nbsp;
                <input id="Reset1" style="width: 110px; height: 29px;" type="reset" value="Hủy bỏ" 
                    class="button" /><br />
                <br />
                <asp:Label ID="mess" runat="server" ForeColor="Red" 
                    Text="(*) Đăng Nhập Thất Bại" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" 
                style="height: 35px; vertical-align: bottom; text-align: center;">
               
            </td>
        </tr>
    </table>
   </center>
    </form>
</body>
</html>
