using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMap.Database;
using System.Data;
using System.Data.SqlClient;

namespace WebMap.Pages
{
    public partial class Pages : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Authenticate"] = null;
            //DeMoDataContext db = new DeMoDataContext();
            //DataSet ds = new DataSet();
            //db.Connection.Open();
            //string sql = "SELECT * FROM LOCATION ";

            //SqlDataAdapter dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            //dond.Fill(ds, "TABLE");


            //Session["Authenticate"] = ds.Tables["TABLE"];
        }
    }
}