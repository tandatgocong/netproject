<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="CoDien.View.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            width: 167px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Pages_content">
<div class="title_page"><asp:Label ID="title" runat="server" Text="CHI TIẾT SẢN PHẨM"></asp:Label>
    </div>
		<div class="pages_contain" style="margin-top:10px; margin-left:10px; margin-right:10px; vertical-align:top;">        
        <table width="95%" style="height:100%;"  style="vertical-align: text-top" >
            <tr>
                <td class="style3" style="vertical-align: top">
                    <asp:Image ID="hinh" runat="server" ImageUrl="~/Image/NEWS/083312093319.jpg"  Height="185px" Width="189px" />
                </td>
                 <td style="vertical-align: top"  >
                    <div class="tensp" 
                         style="color:Blue; font-size:x-large; ">
                      <asp:Label ID="tenSp" runat="server" Text="afdsafd"></asp:Label>
               
                    </div>
                 <div style="margin-left:20px;">
                    <%=Session["detail"]%>
                 </div>
                <br />
                <asp:Button ID="btBack" runat="server" CssClass="button" Text="TRỞ LẠI" 
                Width="92px" onclientclick="javascript:history.back(1);" 
                         PostBackUrl="~/View/Home.aspx" />
                </td>
            </tr>
            </table>
         
        </div>
        </div>
</asp:Content>
