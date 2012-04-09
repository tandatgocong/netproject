using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoDien.View
{
    public partial class A_News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            Binddata();
        }
        private void Binddata()
        {
            if ("".Equals(txtTextSearch.Text))
            {
                GridView1.AllowPaging = true;
                GridView1.DataSource = Class.C_News.getNews("");
                GridView1.DataBind();
            }
            else {
                GridView1.AllowPaging = true;
                GridView1.DataSource = Class.C_News.getNews(txtTextSearch.Text);
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Control control = LoadControl("A_NewAdd.ascx");
            this.Panel1.Controls.Add(control);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Binddata();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            Binddata();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditTin") {

            }
            else if (e.CommandName == "delteTin")
            {
                string id = e.CommandArgument.ToString();
                Class.C_News.DeleteNews(id);
                Binddata();
            }
        }
    }
}