<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Pages.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebMap.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style media="screen" type="text/css">
 
	#add1,#add2{width:950px;height:600px;}
</style>
<script type="text/javascript" src="http://code.jquery.com/jquery-1.5.1.min.js"></script>
<script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true_or_false&amp;key=ABQIAAAAQA_fkZUrN2eacKxkLNtVohSr9hpgAmuH1SesszYLVm3NFIURGhQqFdBd6SO-w_HLc6adrgAGqjOCCg" type="text/javascript"></script>

<script type="text/javascript">
    function initialize() {
        if (GBrowserIsCompatible()) {
            var map = new GMap2(document.getElementById("add1"));
            map.setCenter(new GLatLng(21.025329, 105.857355), 16);
            map.openInfoWindow(map.getCenter(), document.createTextNode("Thẩm mỹ viện Bác sỹ Vân Anh 1"));
            map.setUIToDefault();
        }
    }
    $(document).ready(function () {
        $('#toggle1').click(function () {
            $('#Intro1').toggle(0);
            return false;
        });
        $('#toggle2').click(function () {
            $('#Intro2').toggle(600);
            return false;
        });
    });
</script>
 
<body onload="initialize()" onunload="GUnload()">
    <div id="Intro1">
        <div class="top-content"></div>
        <div class="center-content" >
		    <div id="add1"></div>
        </div>
        <div class="bottom-content"></div>
</div>

<p> </p>
    <div id="Intro2" style="text-align:center">
        <div class="top-content"></div>
        <div class="center-content">
		    <div id="add2"></div>
        </div>
        <div class="bottom-content"></div>
</div>
</body>
 
</asp:Content>
