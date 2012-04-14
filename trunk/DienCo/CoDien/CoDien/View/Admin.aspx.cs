using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoDien.View
{
    public partial class Admin1 : System.Web.UI.Page
    {
        bool search = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;

            cbLoaiSP.DataSource = Class.C_SanPham.GetLoaiSanPham();
            cbLoaiSP.DataTextField = "TENLOAI";
            cbLoaiSP.DataValueField = "MALOAI";
            cbLoaiSP.DataBind();

            cbNhaSanXuat.DataSource = Class.C_SanPham.GetHieuSanPham();
            cbNhaSanXuat.DataTextField = "TENHIEU";
            cbNhaSanXuat.DataValueField = "MAHIEU";
            cbNhaSanXuat.DataBind();

            Binddata();
        }

        public void Binddata()
        {
            GridView1.AllowPaging = true;
            GridView1.DataSource = Class.C_SanPham.getSANPHAM();
            GridView1.DataBind();
        }

        
        public void BinddataSearch()
        {
            GridView1.AllowPaging = true;
            GridView1.DataSource = Class.C_SanPham.search(cbLoaiSP.SelectedValue+"", cbNhaSanXuat.SelectedValue+"", this.txtSearch.Text);
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (search == false)
            {
                GridView1.PageIndex = e.NewPageIndex;
                Binddata();
            }
            else { 
                GridView1.PageIndex = e.NewPageIndex;
                BinddataSearch();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditTin")
            {

            }
            else if (e.CommandName == "DeleteSP")
            {
                string id = e.CommandArgument.ToString();
                Class.C_SanPham.DeleteSP(id);
                Binddata();
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btCapNhat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count ; i++)
            {
                GridViewRow row = GridView1.Rows[i];
                CheckBox spMoi = (CheckBox)(row.FindControl("spMoi"));
                CheckBox spBanChay = (CheckBox)(row.FindControl("spBanChay"));
                Label MASP = (Label)(row.FindControl("MASP"));
                Class.C_SanPham.UpdateSanPham(MASP.Text, spMoi.Checked.ToString(), spBanChay.Checked.ToString());               
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            search = true;
            BinddataSearch();
        }
    }
}