using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoDien.View
{
    public partial class HomePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["spMoi"] = Class.C_Home.getSANPHAM_MOI() ;
            Session["spBanChay"] = Class.C_Home.getSANPHAM_BANCHAY();
             
        }
    }
}