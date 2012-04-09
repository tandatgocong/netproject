using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CoDien.DB;

namespace CoDien.View
{
    public partial class Pages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (Request.Params["page"] != null)
            {
                string mode = Request.Params["page"].ToString();
                PAGE pages = Class.C_Pages.getPage(mode);
                if (pages != null)
                {
                    Session["page"] = pages.MAPAGES;
                    title.Text = pages.PAGESNAME;
                    Session["pages"] = pages.NOIDUNG + " ";
                   
                }
            }
        }
    }
}