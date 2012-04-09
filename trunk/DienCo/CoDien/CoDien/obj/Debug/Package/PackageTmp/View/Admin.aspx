<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="CoDien.View.Admin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 214px;
        }
        .style3
        {
            width: 127px;
        }
        .style4
        {
            width: 130px;
        }
        .style9
        {
            width: 127px;
            height: 31px;
        }
        .style10
        {
            height: 31px;
        }
        .style11
        {
            width: 130px;
            height: 31px;
        }
        .style12
        {
            height: 31px;
        }
        .style13
        {
            width: 127px;
            height: 39px;
        }
        .style14
        {
            width: 214px;
            height: 39px;
        }
        .style15
        {
            width: 130px;
            height: 39px;
        }
        .style16
        {
            height: 39px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="Pages_content_Admin">
		<div class="title_page" style=" margin-top: 15px; font-size:16px; width:99%"> tìm kiếm sản phẩm </div>
		 <div class="pages_admin" style="margin-top:10px; margin-left:20px; font-family:Times New Roman;  font-size: 14px;">
            <table border="0"  style="width:90%; border-bottom: BLUE thick double;">
                 <tr>
                     <td class="style9">
                         LOẠI SẢN PHẦM</td>
                     <td class="style10">
                         <asp:DropDownList ID="DropDownList3" runat="server" Height="30px" Width="180px">
                         </asp:DropDownList>
                         </td>
                     <td class="style11">
                         NHÀ SẢN XUẤT</td>
                     <td class="style12">
                         <asp:DropDownList ID="DropDownList2" runat="server" Height="30px" Width="180px">
                         </asp:DropDownList>
                         </td>
                 </tr>
                 <tr>
                     <td class="style9">
                         TÊN SẢN PHẦM</td>
                     <td class="style10" colspan="2">
                         <asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="327px"></asp:TextBox>
                         </td>
                     <td class="style12">
                         </td>
                 </tr>
                 <tr>
                     <td class="style3">
                         &nbsp;</td>
                     <td class="style2">
                         <asp:Button ID="Button1" runat="server" Font-Bold="True" Text="TÌM KIẾM" 
                             Width="101px" CssClass="button" Height="30px" />
                     </td>
                     <td class="style4">
                         &nbsp;</td>
                     <td style="text-align: right">
                         <asp:Button ID="Button2" runat="server" CssClass="button" Height="30px" 
                             Text="THÊM MỚI" Width="102px" />
                     </td>
                 </tr>
             </table>
             <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                 BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                 Width="894px" AllowPaging="True" AutoGenerateColumns="False">
                 <Columns>
                     <asp:TemplateField HeaderText="STT">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server"></asp:Label>
                         </ItemTemplate>
                         <ItemStyle Width="50px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="ẢNH HIỂN THỊ">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Image ID="Image1" runat="server" />
                         </ItemTemplate>
                         <ItemStyle Width="150px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="MÃ SẢN PHẨM">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label2" runat="server"></asp:Label>
                         </ItemTemplate>
                         <ItemStyle Width="100px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="TÊN SẢN PHẨM">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label3" runat="server"></asp:Label>
                         </ItemTemplate>
                         <ItemStyle Width="200px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="GIÁ">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label4" runat="server"></asp:Label>
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="150px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="SỬA">
                         <ItemTemplate>
                             <asp:ImageButton ID="ImageButton1" runat="server" Height="31px" 
                                 ImageUrl="~/Image/edit.ico" Width="33px" />
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="XÓA">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:ImageButton ID="ImageButton2" runat="server" Height="29px" 
                                 ImageUrl="~/Image/delete2.ico" Width="29px" />
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                     </asp:TemplateField>
                 </Columns>
                 <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                 <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                 <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                 <RowStyle BackColor="White" ForeColor="#330099" />
                 <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                 <SortedAscendingCellStyle BackColor="#FEFCEB" />
                 <SortedAscendingHeaderStyle BackColor="#AF0101" />
                 <SortedDescendingCellStyle BackColor="#F6F0C0" />
                 <SortedDescendingHeaderStyle BackColor="#7E0000" />
             </asp:GridView>
         </div>
    </div>
</asp:Content>
