﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="Pages.aspx.cs" Inherits="CoDien.View.Pages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Pages_content">
<div class="title_page"><asp:Label ID="title" runat="server" Text="Label"></asp:Label>
    </div>
		<div class="pages_contain" style="margin-top:10px; margin-left:10px; margin-right:10px;">
        <%=Session["pages"].ToString()%>
        </div>
        </div>
</asp:Content>
