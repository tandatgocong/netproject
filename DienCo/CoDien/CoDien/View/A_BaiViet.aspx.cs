using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CoDien.DB;

namespace CoDien.View
{
    public partial class A_BaiViet : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;

            if (Request.Params["page"] != null)
            {
                string mode = Request.Params["page"].ToString();
                PAGE pages = Class.C_Pages.getPage(mode);
                if (pages != null)
                {
                    Session["page"] = pages.MAPAGES;
                    title.Text = pages.PAGESNAME;
                    CKEditorControl1.Text = pages.NOIDUNG;
                }
            }
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            string pageid = Session["page"].ToString();
            if (Session["page"] != null)
            {
                string mode = Session["page"].ToString();
                PAGE pages = Class.C_Pages.getPage(mode);
                if (pages != null)
                {
                    pages.NOIDUNG = CKEditorControl1.Text;
                    if (Class.C_Pages.Update())
                    {
                        lbResult.CssClass = "resultSuccess";
                        lbResult.Text = "Lưu Thông Tin Trang " + pages.PAGESNAME +" Thành Công !";
                      
                    }
                    else {
                        lbResult.CssClass = "resultFaild";
                        lbResult.Text = "Lưu Thông Tin Trang " + pages.PAGESNAME + " Thất Bại !";
                        
                    }
                }
            }
        }
    }
}