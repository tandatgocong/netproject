<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin.Master" AutoEventWireup="true" CodeBehind="A_BaiViet.aspx.cs" Inherits="CoDien.View.A_BaiViet" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
     window.document.getElementById("sp").className = "top_link";
     window.document.getElementById("bv").className = "current_link";
</script>
    <div class="Pages_content_Admin">
		<div class="title_page" style=" margin-top: 15px; font-size:16px; width:99%">
            <asp:Label ID="title" runat="server" Text="Label"></asp:Label>
        </div>
		 <div class="pages_admin" style="margin-top:10px; margin-left:20px; font-family:Times New Roman;  font-size: 14px;">
             <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" Height="619px" 
                 Width="978px">
             </CKEditor:CKEditorControl>

             <br />
                         <asp:Button ID="btSave" runat="server" Font-Bold="True" Text="SAVE" 
                             Width="101px" CssClass="button" Height="30px" 
                 onclick="btSave_Click" />
                     &nbsp;<asp:Button ID="Button2" runat="server" Font-Bold="True" Text="CANCEL" 
                             Width="101px" CssClass="button" Height="30px" />

         &nbsp;&nbsp;
             <asp:Label ID="lbResult" runat="server"></asp:Label>
             <br />

         </div>
</div>
</asp:Content>
