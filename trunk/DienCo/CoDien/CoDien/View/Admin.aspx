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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="javascript" type="text/javascript">
     window.document.getElementById("sp").className = "current_link";
     window.document.getElementById("bv").className = "top_link";
</script>
 <div  style="height:1250px; margin-top:0px;">
		<div class="title_page" style="font-size:16px; width:99%"> tìm kiếm sản phẩm </div>
		 <div class="pages_admin" style="margin-top:10px; margin-left:20px; font-family:Times New Roman;  font-size: 14px;">
            <table border="0"  style="width:90%; border-bottom: BLUE thick double;">
                 <tr>
                     <td class="style9">
                         LOẠI SẢN PHẦM</td>
                     <td class="style10">
                         <asp:DropDownList ID="cbLoaiSP" runat="server" Height="30px" Width="180px">
                         </asp:DropDownList>
                         </td>
                     <td class="style11">
                         NHÀ SẢN XUẤT</td>
                     <td class="style12">
                         <asp:DropDownList ID="cbNhaSanXuat" runat="server" Height="30px" Width="180px">
                         </asp:DropDownList>
                         </td>
                 </tr>
                 <tr>
                     <td class="style9">
                         TÊN SẢN PHẦM</td>
                     <td class="style10" colspan="2">
                         <asp:TextBox ID="txtSearch" runat="server" Height="25px" Width="327px"></asp:TextBox>
                         </td>
                     <td class="style12">
                         </td>
                 </tr>
                 <tr>
                     <td class="style3">
                         &nbsp;</td>
                     <td class="style2">
                         <asp:Button ID="btSearch" runat="server" Font-Bold="True" Text="TÌM KIẾM" 
                             Width="101px" CssClass="button" Height="30px" onclick="btSearch_Click" />
                     </td>
                     <td class="style4">
                         &nbsp;</td>
                     <td style="text-align: right">
                         <asp:Button ID="btCapNhat" runat="server" CssClass="button" Height="30px" 
                             Text="CẬP NHẬT" Width="102px" onclick="btCapNhat_Click" /> &nbsp;&nbsp;
                         <asp:Button ID="btThamSP" runat="server" CssClass="button" Height="30px" 
                             Text="THÊM MỚI" Width="102px" PostBackUrl="~/View/A_AddSanPham.aspx" />
                     </td>
                 </tr>
             </table>
             <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                 BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                 Width="894px" AllowPaging="True" AutoGenerateColumns="False" 
                 onpageindexchanging="GridView1_PageIndexChanging" 
                 onrowcommand="GridView1_RowCommand">
                 <Columns>
                     <asp:TemplateField HeaderText="STT">
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server" Text='<%# Bind("STT") %>'></asp:Label>
                         </ItemTemplate>
                         <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="ẢNH HIỂN THỊ">
                         <ItemTemplate>
                             <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("ANH") %>' 
                                 Height="90px" Width="116px" />
                         </ItemTemplate>
                         <ItemStyle Width="150px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="MÃ SẢN PHẨM">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="MASP" runat="server" Text='<%# Bind("MASP") %>'></asp:Label>
                         </ItemTemplate>
                         <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="TÊN SẢN PHẨM">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label3" runat="server" Text='<%# Bind("TENSP") %>'></asp:Label>
                         </ItemTemplate>
                         <ItemStyle Width="200px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="GIÁ">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:Label ID="Label4" runat="server" Text='<%# Bind("GIA","{0:0,0}") %>'></asp:Label>
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="150px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="MỚI">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:CheckBox ID="spMoi" runat="server" Checked='<%# Bind("SAPMOI") %>' 
                                 oncheckedchanged="CheckBox1_CheckedChanged" />
                         </ItemTemplate>
                         <ItemStyle Height="15px" HorizontalAlign="Center" VerticalAlign="Middle" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="BÁN CHẠY">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:CheckBox ID="spBanChay" runat="server" Checked='<%# Bind("BANCHAY") %>' />
                         </ItemTemplate>
                         <ItemStyle Width="20px" HorizontalAlign="Center" VerticalAlign="Middle" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="SỬA">
                         <ItemTemplate>
                             <asp:ImageButton ID="ImageButton1" runat="server" Height="31px" ImageUrl="~/Image/edit.ico"
                                 PostBackUrl='<%# Eval("MASP","A_UpdateSanPham.aspx?MASP={0}") %>' 
                                 Width="35px" />
                         </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="XÓA">
                         <EditItemTemplate>
                             <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                         </EditItemTemplate>
                         <ItemTemplate>
                             <asp:ImageButton ID="ImageButton2" runat="server" Height="29px" 
                                 ImageUrl="~/Image/delete2.ico" Width="29px" 
                                 CommandArgument='<%# Bind("MASP") %>' CommandName="DeleteSP" 
                                 onclientclick="if(confirm('Bạn có muốn xóa ?') == false)return false;" />
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
