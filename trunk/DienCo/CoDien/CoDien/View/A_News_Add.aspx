<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin.Master" AutoEventWireup="true" CodeBehind="A_News_Add.aspx.cs" Inherits="CoDien.View.A_News_Add" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript">
    window.document.getElementById("sp").className = "top_link";
    window.document.getElementById("bv").className = "current_link";
    </script>
<form id="AA" method="post">

    <div class="Pages_content_Admin">
		<div class="title_page" style=" margin-top: 15px; font-size:16px; width:99%">
            <asp:Label ID="title" runat="server" Text="THÊM MỚI TIN TỨC"></asp:Label>
        </div>
		 <div class="pages_admin" style="margin-top:10px; margin-left:20px; font-family:Times New Roman;  font-size: 14px;">
         <table style="width:100%;">
    <tr>
        <td class="style3">
        </td>
        <td class="style4" colspan="3">
            <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="Blue" 
                Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style5">
        </td>
        <td class="style6">
            Tiêu Đề</td>
        <td class="style11">
            <asp:TextBox ID="txtTitle" runat="server" Width="360px"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtTitle" ErrorMessage="Tiêu Đề Không Được Bỏ Trống !"></asp:RequiredFieldValidator>
        </td>
        <td class="style7">
        </td>
    </tr>
    <tr>
        <td class="style5">
        </td>
        <td class="style6">
            Mô Tả</td>
        <td class="style11">
            <asp:TextBox ID="txtDescription" runat="server" Height="50px" TextMode="MultiLine" 
                Width="396px">   </asp:TextBox>
        </td>
        <td class="style7">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style8">
        </td>
        <td class="style9" style="vertical-align: top">
            &nbsp;Nội Dung&nbsp;</td>
        <td class="style12">
            <CKEditor:CKEditorControl ID="noidung" runat="server" Height="352px" 
                Width="572px"></CKEditor:CKEditorControl>
        </td>
        <td class="style10">
        </td>
    </tr>
    <tr>
        <td class="style8" style="vertical-align: top">
        </td>
        <td class="style9" >
            Hình Hiển Thị</td>
        <td class="style12">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button3" runat="server" onclick="Button1_Click" Text="Upload" 
                ValidationGroup="adsfdsafd" />
            <asp:HiddenField ID="imagePath" runat="server" />
            <asp:Label ID="upload" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Image ID="imgFile" runat="server" Height="125px" Width="188px" />
        </td>
        <td class="style10">
        </td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            &nbsp;</td>
        <td class="style13">
            <asp:Button ID="btThemmoi" runat="server" CssClass="button" Text="THÊM MỚI" 
                Width="105px" onclick="btThemmoi_Click" />
&nbsp;&nbsp;
            <input id="Reset1" type="reset" value="LÀM LẠI" class="button" />&nbsp;
            <asp:Button ID="btBack" runat="server" CssClass="button" Text="TRỞ LẠI" 
                Width="92px" PostBackUrl="~/View/A_News.aspx" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="lbResult" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            &nbsp;</td>
        <td class="style2">
            &nbsp;</td>
        <td class="style13">
             <br />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
         
         </div>
    </div></form>
</asp:Content>
