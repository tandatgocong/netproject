<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="CoDien.View.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 207px;
        }
        .style2
        {
            width: 15px;
            height: 15px;
        }
        .style3
        {
            width: 22px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Pages_content_Admin" >
    <div class="title_page"><asp:Label ID="title" runat="server" Text="tin tức"></asp:Label></div>
		<div class="pages_contain_news" style="margin-top:10px; margin-left:10px; margin-right:10px;">
        <h3>
            <asp:Label ID="lbTitle0" runat="server"></asp:Label>
            </h3>
          
                <table style="width:100%;">
                    <tr>
                        <td class="style1">
                            <asp:Image ID="Image1" runat="server" Height="150px" Width="211px" />
                        </td>
                        <td style="text-align: left; vertical-align: top;">
                            <asp:Label ID="lbMoTa" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <%=Session["content"].ToString()%>
                 
          <div class="title_page_orther"><b><i> Các Tin Khác</i></b> 
          </div>
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                BackColor="White" BorderColor="White" BorderStyle="None" BorderWidth="0px" 
                CellPadding="4" GridLines="Horizontal"  ShowHeader="False" Width="100%" 
                AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging" 
                onrowcommand="GridView1_RowCommand" PageSize="5">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td class="style3">
                                        <img alt="" class="style2" 
    src="../Image/bullet0_over.png" />
                                    </td>
                                    <td>
                                        <i>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                CommandArgument='<%# Bind("NEWSID") %>' CommandName="SELECTTION" 
                                                CssClass="item" Text='<%# Bind("NEWSTILE") %>'></asp:LinkButton>
                                            &nbsp;(<asp:Label ID="Label1" runat="server" Text='<%# Bind("CREATEDATE") %>'></asp:Label>
                                            )</i>&nbsp;</td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
          
          
</div>
    </div>
</asp:Content>
