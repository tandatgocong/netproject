<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin.Master" AutoEventWireup="true" CodeBehind="A_News.aspx.cs" Inherits="CoDien.View.A_News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 607px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
     window.document.getElementById("sp").className = "top_link";
     window.document.getElementById("bv").className = "current_link";
     function confirmdelete() {
         if (confirm("Are you sure you want to delete?")) {
             return true;
         }
         return false;
     }
</script>
    <div class="Pages_content_Admin">
		<div class="title_page" style=" margin-top: 15px; font-size:16px; width:99%">
            <asp:Label ID="title" runat="server" Text="QUẢN TRỊ TIN TỨC"></asp:Label>
        </div>
		 <div class="pages_admin" style="margin-top:10px; margin-left:20px; font-family:Times New Roman;  font-size: 14px;">
             <table border="0"  style="width:90%; border-bottom: BLUE thick double;">
                 <tr>
                     <td class="style9">
                         TIÊU ĐỀ TIN</td>
                     <td class="style10" colspan="2">
                         <asp:TextBox ID="txtTextSearch" runat="server" Height="25px" Width="498px"></asp:TextBox>
                         </td>
                     <td class="style12">
                         </td>
                 </tr>
                 <tr>
                     <td class="style3">
                         &nbsp;</td>
                     <td class="style1">
                         <asp:Button ID="btSearch" runat="server" Font-Bold="True" Text="TÌM KIẾM" 
                             Width="101px" CssClass="button" Height="30px" onclick="btSearch_Click" />
                     </td>
                     <td class="style4">
                         &nbsp;</td>
                     <td style="text-align: right">
                         <asp:Button ID="addNews" runat="server" CssClass="button" Height="30px" 
                             Text="THÊM MỚI" Width="102px" PostBackUrl="~/View/A_News_Add.aspx"  />
                     </td>
                 </tr>
             </table>
             <asp:Panel ID="Panel1" runat="server">
                 <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                 BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                 Width="894px" AllowPaging="True" AutoGenerateColumns="False" 
                     onpageindexchanging="GridView1_PageIndexChanging" 
                     onrowcommand="GridView1_RowCommand" PageSize="15">
                     <Columns>
                         <asp:TemplateField HeaderText="STT">
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Bind("STT") %>'></asp:Label>
                             </ItemTemplate>
                             <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                             <ItemStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="ID">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label2" runat="server" Text='<%# Bind("NEWSID") %>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="TIÊU ĐỀ TIN TỨC">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label3" runat="server" Text='<%# Bind("NEWSTILE") %>' 
                                     ToolTip='<%# Bind("NEWSDICRIPTION") %>'></asp:Label>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="SỬA">
                             <ItemTemplate>
                                 <asp:ImageButton ID="ImageButton1" runat="server" Height="31px" 
                                 ImageUrl="~/Image/edit.ico" Width="33px" 
                                     CommandArgument='<%# Bind("NEWSID") %>' CommandName="EditTin" />
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
                                     CommandArgument='<%# Bind("NEWSID") %>' CommandName="delteTin" 
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
             </asp:Panel>
         </div>
     </div>
</asp:Content>
