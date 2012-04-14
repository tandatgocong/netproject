<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin.Master" AutoEventWireup="true" CodeBehind="A_UpdateSanPham.aspx.cs" Inherits="CoDien.View.A_UpdateSanPham" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
.world_table{
	margin: 2px 10px;
	#width: 97%;
}

.world_table tr.row td{
	border-bottom: 1px #AAA dotted;
	padding-top: 3px; padding-bottom: 3px;
}

.world_table tr.row_nobor td{
	border-bottom:0;
	padding-top: 2px; padding-bottom: 2px;
}

.world_table .name{
	font-size: 13px;
	font-weight: bold;
	color: #18479b;
}
        .style1
        {
            width: 130px;
        }
        .style2
        {
            width: 43px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script language="javascript" type="text/javascript">
     window.document.getElementById("sp").className = "current_link";
     window.document.getElementById("bv").className = "top_link";
     function confirmdelete() {
         if (confirm("Are you sure you want to delete?")) {
             return true;
         }
         return false;
     }
     function IsNumeric(sText) {
         var ValidChars = "0123456789.";
         var IsNumber = true;
         var Char;

         for (i = 0; i < sText.length && IsNumber == true; i++) {
             Char = sText.charAt(i);
             if (ValidChars.indexOf(Char) == -1) {
                 alert('Giá tiền ko hợp lệ');
                 IsNumber = false;
             }
         }
         return IsNumber;
     }
</script>
    <div class="">
		<div class="title_page" style=" margin-top: 15px; font-size:16px; width:99%">
            <asp:Label ID="title" runat="server" Text="CẬP NHẬT SẢN PHẨM"></asp:Label>
        </div>
        <form id="AA" method="post">
		<table style="width:95%;" class="world_table" >
    <tr class="row">
        <td class="style2">
        </td>
        <td class="style4" colspan="2">
            
             <asp:Label ID="lbSanPham" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr class="row">
        <td class="style2">
            &nbsp;</td>
        <td class="style1" >
            LOẠI SẢN PHẨM</td>
        <td class="style11">
                         <asp:DropDownList ID="cbLoaiSP" runat="server" Height="30px" Width="180px">
                         </asp:DropDownList>
        </td>
    </tr>
    <tr class="row">
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            NHÀ SẢN XUẤT</td>
        <td class="style11">
                         <asp:DropDownList ID="cbNhaSanXuat" runat="server" Height="30px" 
                Width="180px">
                         </asp:DropDownList>
        </td>
    </tr>
    <tr class="row">
        <td class="style2">
        </td>
        <td class="style1">
            TÊN SẢN PHẨM</td>
        <td class="style11">
            <asp:TextBox ID="txtTenSanPham" runat="server" Width="360px" Height="30px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtTenSanPham" ErrorMessage="Tên Sản Phẩm Không Được Trống"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="row">
        <td class="style2">
        </td>
        <td class="style1">
            MÔ TẢ</td>
        <td class="style11">
            <asp:TextBox ID="txtDescription" runat="server" Height="71px" TextMode="MultiLine" 
                Width="396px"></asp:TextBox>
        </td>
    </tr>
    <tr class="row">
        <td class="style2">
        </td>
        <td class="style1" style="vertical-align: middle">
            GIÁ BẢN</td>
        <td class="style11">
            <asp:TextBox ID="txtGiaBan" runat="server" Width="360px" Height="30px" >0</asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                ControlToValidate="txtGiaBan" ErrorMessage="Nhập Số" Type="Double" 
                MaximumValue="9999999999999999" MinimumValue="0"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="row">
        <td class="style2" style="vertical-align: top">
        </td>
        <td class="style1" style="vertical-align: text-top" >
            ẢNH HIỆN THỊ</td>
        <td class="style11">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button3" runat="server" onclick="Button1_Click" Text="Upload" 
                ValidationGroup="adsfdsafd" />
            <asp:HiddenField ID="imagePath" runat="server" />
            <asp:Label ID="upload" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Image ID="imgFile" runat="server" Height="125px" Width="188px" />
        </td>
    </tr>
    <tr class="row">
        <td class="style2">
            </td>
        <td class="style1" style="vertical-align: text-top">
            CHI TIẾT SẢN PHẨM</td>
        <td class="style17">
            <CKEditor:CKEditorControl ID="txtChiTiet" runat="server" Height="308px" 
                Width="722px"></CKEditor:CKEditorControl>
        </td>
    </tr>
    <tr class="row">
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            SẢN PHẨM MỚI</td>
        <td class="style17">
            <asp:CheckBox ID="spMoi" runat="server" />
        </td>
    </tr>
    <tr class="row">
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            SẢN PHẨM BÁN CHẠY</td>
        <td class="style17">
            <asp:CheckBox ID="spBanChay" runat="server" />
        </td>
    </tr>
    <tr class="row">
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td class="style13">
            <asp:Button ID="btThemmoi" runat="server" CssClass="button" Text="CẬP NHẬT" 
                Width="105px" onclick="btThemmoi_Click" />
&nbsp;
            &nbsp;
            <asp:Button ID="btBack" runat="server" CssClass="button" Text="TRỞ LẠI" 
                Width="92px" PostBackUrl="~/View/Admin.aspx" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="lbResult" runat="server"></asp:Label>
        </td>
    </tr>
    <tr >
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
        <td class="style13">
             <br />
        </td>
    </tr>
</table>
        </form>
     </div>
</asp:Content>
