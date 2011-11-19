<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPages/Home.master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebDemo.View.Pages.HomePage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">  
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js" ></script>
        <!--<script type="text/javascript" src="jquery.js" ></script>-->
        <script type="text/javascript" src="jquery.mousewheel.min.js" ></script>
        <script type="text/javascript" src="../jquery.iviewer.js" ></script>
        <script type="text/javascript" src="../jquery.loc.js" ></script>        
        <script type="text/javascript">
            var $ = jQuery;
            $(document).ready(function () {
                $("#viewer").iviewer(
                       {
                           src: "/Image/map.jpg",
                          /* update_on_resize: false,
                           initCallback: function () {
                               var object = this;
                               $("#in").click(function () { object.zoom_by(1); });
                               $("#out").click(function () { object.zoom_by(-1); });
                               $("#fit").click(function () { object.fit(); });
                               $("#orig").click(function () { object.set_zoom(100); });
                               $("#update").click(function () { object.update_container_info(); });
                           },
                           onMouseMove: function (object, coords) { },
                           onStartDrag: function (object, coords) { return false; }, //this image will not be dragged
                           onDrag: function (object, coords) { }*/
                       });
                   });
        </script>
        <link rel="stylesheet" type="text/css" href="../jquery.iviewer.css" />
        <style>
            .viewer
            {
                width: 100%;
                height: 600px; 
                border: 0px solid black;
                position: relative;
            }
            
            .wrapper
            {
                overflow: hidden;
            }
        </style>   
    <script type="text/javascript" >
    $(document).ready(function () {
        $('#rightclickarea').bind('contextmenu', function (e) {
            var $cmenu = $(this).next();
            $('<div class="overlay"></div>').css({ left: '0px', top: '0px', position: 'absolute', width: '100%', height: '100%', zIndex: '100' }).click(function () {
                $(this).remove();
                $cmenu.hide();
            }).bind('contextmenu', function () { return false; }).appendTo(document.body);
            $(this).next().css({ left: e.pageX, top: e.pageY, zIndex: '101' }).show();

            return false;
        });

        $('.vmenu .first_li').live('click', function () {
            if ($(this).children().size() == 1) {
                alert($(this).children().text());
                $('.vmenu').hide();
                $('.overlay').hide();
            }
        });

        $('.vmenu .inner_li span').live('click', function () {
            alert($(this).text());
            $('.vmenu').hide();
            $('.overlay').hide();
        });


        $(".first_li , .sec_li, .inner_li span").hover(function () {
            $(this).css({ backgroundColor: '#E0EDFE', cursor: 'pointer' });
            if ($(this).children().size() > 0)
                $(this).find('.inner_li').show();
            $(this).css({ cursor: 'default' });
        },
			function () {
			    $(this).css('background-color', '#fff');
			    $(this).find('.inner_li').hide();
			});


    });
		</script>
      <br /> 
      <script runat="server">
  
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnViewDetails_Click(object sender, CommandEventArgs e)
    {
        //  get the gridviewrow from the sender so we can get the datakey we need
        Button btnDetails = sender as Button;
               
        //  extract the customerid from the row whose details button originated the postback.
        //  grab the customerid and feed it to the customer details datasource
        //  finally, rebind the detailview
        this.sqldsCustomerDetails.SelectParameters.Clear();
        this.sqldsCustomerDetails.SelectParameters.Add("LOCATIONID", e.CommandArgument.ToString());
        this.DetailsView1.DataSource = this.sqldsCustomerDetails;
        this.DetailsView1.DataBind();

        //  update the contents in the detail panel
      
        //  show the modal popup
        this.ModalPopupExtender1.Show();
    }   
    
    </script>
     <form id="form1" runat="server">
     <asp:SqlDataSource ID="sqldsCustomerDetails" runat="server" 
                
                SelectCommand="SELECT * FROM [LOCATION] WHERE ([LOCATIONID] = @LOCATIONID)" 
                ConnectionString="<%$ ConnectionStrings:testConnectionString %>">
                 <SelectParameters>
                    <asp:Parameter Name="LOCATIONID" Type="String" DefaultValue="LOCATIONID" />
                </SelectParameters>
      </asp:SqlDataSource>
     <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
           <asp:Panel ID="data" runat="server" CssClass="modalPopup" Width="513px" 
         Height="401px">
             <div class="title_page">THÔNG TIN CHI NHÁNH </div>  
             &nbsp;&nbsp;&nbsp;<asp:DetailsView ID="DetailsView1" runat="server" BackColor="White" 
                   BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
                   CellPadding="3" GridLines="Horizontal" 
                   Height="76px" Width="500px" style="margin-left:5px;font-size: 12px;" 
                   AutoGenerateRows="False">
                   <AlternatingRowStyle BackColor="#F7F7F7" />
                   <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                   <Fields>
                       <asp:ImageField DataImageUrlField="IMG">
                           <ItemStyle Height="100px" Width="100px" />
                       </asp:ImageField>
                       <asp:BoundField DataField="LOCATIONID" HeaderText="Mã Chi Nhánh:" />
                       <asp:BoundField DataField="LOCATIONNAME" HeaderText="Tên Chi Nhánh:" />
                       <asp:BoundField DataField="ADDRESS" HeaderText="Địa Chỉ:" />
                       <asp:BoundField DataField="EMLOYEENAME" HeaderText="Chủ Cửa Hàng:" />
                   </Fields>
                   <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                   <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                   <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                   <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
               </asp:DetailsView>
               <div align="center">            
                  <asp:Button ID="CancelButton" runat="server" Text="Đóng" />
                   
               </div>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
             TargetControlID="btnShowPopup"
             PopupControlID="data"
             BackgroundCssClass="modalBackground"             
             CancelControlID="CancelButton" /> 
              
     <!--   <span>
                <a id="in" href="#">+</a>
                <a id="out" href="#">-</a>
                <a id="fit" href="#">fit</a>
                <a id="orig" href="#">orig</a>
                <a id="update" href="#">update</a>
            </span> -->
            <asp:Button id="btnShowPopup" Text="Ví Dụ" runat="server" style="display:none"/>
           <div class="wrapper" id="rightclickarea">         
            <div style="background-image: url(/Image/map.jpg)" class="viewer">                 
                    <div class="l1"><asp:ImageButton ID="btnViewDetails" runat="server" width="47px" heigh="47px"  ImageUrl="~/Image/location.png" OnCommand="BtnViewDetails_Click" CommandArgument="CH1" /></div>
                    <div class="l2"><asp:ImageButton ID="btnViewDetails1" runat="server" width="47px" heigh="47px"  ImageUrl="~/Image/location.png" OnCommand="BtnViewDetails_Click" CommandArgument="CH2" /></div> 
                    <div class="l3"><asp:ImageButton ID="btnViewDetails2" runat="server" width="47px" heigh="47px"  ImageUrl="~/Image/location.png" OnCommand="BtnViewDetails_Click" CommandArgument="CH3" /></div> 
                    <div class="l4"><asp:ImageButton ID="btnViewDetails3" runat="server" width="47px" heigh="47px"  ImageUrl="~/Image/location.png" OnCommand="BtnViewDetails_Click" CommandArgument="CH4" /></div>
                    <div class="l5"><asp:ImageButton ID="btnViewDetails4" runat="server" width="47px" heigh="47px"  ImageUrl="~/Image/location.png" OnCommand="BtnViewDetails_Click" CommandArgument="CH5" /></div> 
                    <div class="l6"><asp:ImageButton ID="ImageButton1" runat="server" width="47px" heigh="47px"  ImageUrl="~/Image/location.png" OnCommand="BtnViewDetails_Click" CommandArgument="CH6" /></div> 
                    <div class="l7"><asp:ImageButton ID="ImageButton2" runat="server" width="47px" heigh="47px"  ImageUrl="~/Image/location.png" OnCommand="BtnViewDetails_Click" CommandArgument="CH7" /></div>
                    <div class="l8"><asp:ImageButton ID="ImageButton3" runat="server" width="47px" heigh="47px"  ImageUrl="~/Image/location.png" OnCommand="BtnViewDetails_Click" CommandArgument="CH8" /></div> 
     
                    </div>  
            </div>         
          
	<div class="vmenu">
 	       <div class="first_li"><span style="font-size:14px;">Thêm Mới Địa Điểm</span></div>
	</div>
    
   </form>
</asp:Content>
