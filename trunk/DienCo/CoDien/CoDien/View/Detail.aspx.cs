using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CoDien.DB;

namespace CoDien.View
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["SP"] != null) {
                int spID = int.Parse(Request.Params["SP"].ToString());
                SANPHAM sp = Class.C_SanPham.findSanPhamById(spID);
                if (sp != null) {
                    hinh.ImageUrl = sp.ANH;
                    tenSp.Text = sp.TENSP;
                    Session["detail"] = sp.CHITIET;
                }
            }
        }
    }
}