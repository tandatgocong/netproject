<%@ Page Title="" Language="C#" MasterPageFile="~/View/HomePage.Master" AutoEventWireup="true" CodeBehind="Pages.aspx.cs" Inherits="CoDien.View.Pages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="Pages_content">
<% if ("GT".Equals(Session["page"] + ""))
   { 
   %>
       <script language="javascript" type="text/javascript">
           window.document.getElementById("TC").className = "top_link";
           window.document.getElementById("GT").className = "current_link";
           window.document.getElementById("LH").className = "top_link";
           window.document.getElementById("TD").className = "top_link";           
           window.document.getElementById("TT").className = "top_link";
    </script>
   <%
   }
   if ("LH".Equals(Session["page"] + ""))
   {
    %>
          <script language="javascript" type="text/javascript">
              window.document.getElementById("TC").className = "top_link";
              window.document.getElementById("GT").className = "top_link";
              window.document.getElementById("LH").className = "current_link";
              window.document.getElementById("TD").className = "top_link";
              window.document.getElementById("TT").className = "top_link";
    </script>
   <%
   }
   if ("TD".Equals(Session["page"] + ""))
   {
    %>
          <script language="javascript" type="text/javascript">
              window.document.getElementById("TC").className = "top_link";
              window.document.getElementById("GT").className = "top_link";
              window.document.getElementById("LH").className = "top_link";
              window.document.getElementById("TD").className = "current_link";
              window.document.getElementById("TT").className = "top_link";
    </script>
   <%
   }
    
   
%>
<div class="title_page"><asp:Label ID="title" runat="server" Text="Label"></asp:Label>
    </div>
		<div class="pages_contain" style="margin-top:10px; margin-left:10px; margin-right:10px;">
        <%=Session["pages"].ToString()%>
        </div>
        </div>
</asp:Content>
