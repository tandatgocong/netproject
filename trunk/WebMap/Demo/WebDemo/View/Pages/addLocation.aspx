<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addLocation.aspx.cs" Inherits="WebDemo.View.Pages.addLocation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head" runat="server">
    <title>Master Details Example</title>
    <script runat="server">
  
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnViewDetails_Click(object sender, EventArgs e)
    {
        //  get the gridviewrow from the sender so we can get the datakey we need
        Button btnDetails = sender as Button;
        GridViewRow row = (GridViewRow)btnDetails.NamingContainer;
        
        //  extract the customerid from the row whose details button originated the postback.
        //  grab the customerid and feed it to the customer details datasource
        //  finally, rebind the detailview
        this.sqldsCustomerDetails.SelectParameters.Clear();
        this.sqldsCustomerDetails.SelectParameters.Add("customerid", Convert.ToString(this.gvCustomers.DataKeys[row.RowIndex].Value));
        this.dvCustomerDetail.DataSource = this.sqldsCustomerDetails;
        this.dvCustomerDetail.DataBind();

        //  update the contents in the detail panel
        this.updPnlCustomerDetail.Update();
        //  show the modal popup
        this.mdlPopup.Show();
        
        
    }   
    
    </script>
    <style>
        .modalBackground {
            background-color:Gray;
            filter:alpha(opacity=70);
            opacity:0.7;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
       
        <div>
            <asp:SqlDataSource ID="sqldsCustomers" runat="server" 
                
                SelectCommand="SELECT [customerid], [companyname], [contacttitle], [contactname] FROM [customers]" 
                ConnectionString="<%$ ConnectionStrings:demoConnectionString %>" />
            <asp:SqlDataSource ID="sqldsCustomerDetails" runat="server" 
                
                SelectCommand="SELECT * FROM [customers] WHERE ([customerid] = @customerid)" 
                ConnectionString="<%$ ConnectionStrings:demoConnectionString %>">
                <SelectParameters>
                    <asp:Parameter Name="customerid" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            
            <p style="background-color:AliceBlue; width:95%">
                Example of using a ModalPopupExtender to edit the indivdual rows of a GridView.<br />
                To test out the functionality, click the Details button of any of the rows and watch what happens.<br />
            </p>
            
            <br />
            <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>            
                    <asp:Label ID="lblTitle" runat="server" Text="Customers" BackColor="lightblue" Width="95%" />
                    <asp:GridView 
                        ID="gvCustomers" runat="server" DataKeyNames="customerid" AutoGenerateColumns="false" 
                        AllowPaging="true" AllowSorting="true" PageSize="10" DataSourceID="sqldsCustomers" Width="95%">
                        <AlternatingRowStyle BackColor="aliceBlue" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField ControlStyle-Width="50px" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                  <asp:Button ID="btnViewDetails" runat="server" Text="Details" OnClick="BtnViewDetails_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="customerid" HeaderText="ID" SortExpression="customerid" ReadOnly="true" />
                            <asp:BoundField DataField="companyname" HeaderText="Company" SortExpression="companyname" ReadOnly="true" />
                            <asp:BoundField DataField="contactname" HeaderText="Name" SortExpression="contactname" ReadOnly="true" />
                            <asp:BoundField DataField="contacttitle" HeaderText="Title" SortExpression="contacttitle" ReadOnly="true" />                
                        </Columns>                    
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>                    
            
            <asp:Button id="btnShowPopup" runat="server" style="display:none" />
            <ajaxToolKit:ModalPopupExtender 
                ID="mdlPopup" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlPopup" 
                CancelControlID="btnClose" BackgroundCssClass="modalBackground" />
            <asp:Panel ID="pnlPopup" runat="server" Width="500px" style="display:none">
                <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblCustomerDetail" runat="server" Text="Customer Detail" BackColor="lightblue" Width="95%" />
                        <asp:DetailsView ID="dvCustomerDetail" runat="server" DefaultMode="Edit" Width="95%" BackColor="white" />
                    </ContentTemplate>                
                </asp:UpdatePanel>
                <div align="right" style="width:95%">
                    <asp:Button 
                        ID="btnSave" runat="server" Text="Save" 
                        OnClientClick="alert('Sorry, but I didnt implement save because I dont want my northwind database getting messed up.'); return false;" 
                        Width="50px" />
                    <asp:Button ID="btnClose" runat="server" Text="Close" Width="50px" />
                </div>             
            </asp:Panel>
        </div>
    </form>
</body>
</html>