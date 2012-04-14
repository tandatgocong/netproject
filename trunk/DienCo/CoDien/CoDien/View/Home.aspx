<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CoDien.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Pages_content">
<div class="title_page"><asp:Label ID="title" runat="server" Text="SẢN PHẨM"></asp:Label>
    </div>
		<div class="pages_contain" style="margin-top:10px; margin-left:10px; margin-right:10px;">        
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                &nbsp;<asp:Image ID="Image1" runat="server" Height="185px" Width="189px" 
                                    ImageUrl='<%# BIND("ANH") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="tensp">
                                    <a href="#" title="Xem Chi Tiết">
                                    <asp:Label ID="Label1" runat="server" Text='<%# BIND("TENSP") %>'></asp:Label>
                                    </a>
                                </div>
                                <div class="gia">
                                    Giá Bán: <span style="color:Red">&nbsp;<asp:Label ID="Label2" runat="server" 
                                        Text='<%# Bind("GIA","{0:0,0}")  %>'></asp:Label>
                                    &nbsp;đ</span>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
       
       <center><div style="background-color: #E6E6FA; width:100%; height:25px; vertical-align:middle;"  class="pading">
       <table cellpadding="0" border="0" >
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="lbtnFirst" runat="server" CausesValidation="false" 
                                    OnClick="lbtnFirst_Click" ForeColor="#006600">&lt;&lt;</asp:LinkButton>
                                &nbsp;</td>
                            <td align="right">
                                <asp:LinkButton ID="lbtnPrevious" runat="server" CausesValidation="false" 
                                    OnClick="lbtnPrevious_Click" ForeColor="#006600">Trang trước</asp:LinkButton>&nbsp;&nbsp;</td>
                            <td align="center" valign="middle">
                                <asp:DataList ID="dlPaging" runat="server" RepeatDirection="Horizontal" OnItemCommand="dlPaging_ItemCommand"
                                    OnItemDataBound="dlPaging_ItemDataBound">
                                    <ItemStyle ForeColor="Blue" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                                            CommandName="Paging" Text='<%# Eval("PageText") %>' ForeColor="#006600"></asp:LinkButton>&nbsp;
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                            <td align="left">
                                &nbsp;&nbsp;<asp:LinkButton ID="lbtnNext" runat="server" CausesValidation="false"
                                    OnClick="lbtnNext_Click" ForeColor="#006600">Trang sau</asp:LinkButton></td>
                            <td align="left">
                                &nbsp;
                                <asp:LinkButton ID="lbtnLast" runat="server" CausesValidation="false" 
                                    OnClick="lbtnLast_Click" ForeColor="#006600">&gt;&gt;</asp:LinkButton></td>
                        </tr>
                        
                    </table>
        </div>
       
       </center>
         
        </div>
        </div>
</asp:Content>
