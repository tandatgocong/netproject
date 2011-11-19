using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MapGoogle.Databases;
using System.Data;
using System.Data.SqlClient;

namespace MapGoogle
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Authenticate"] = null;
            MapDemoDataContext db = new MapDemoDataContext();
            DataSet ds = new DataSet();
            db.Connection.Open();
            string sql = "SELECT * FROM LOCATION ";

            SqlDataAdapter dond = new SqlDataAdapter(sql, db.Connection.ConnectionString);
            dond.Fill(ds, "TABLE");


            Session["Authenticate"] = ds.Tables["TABLE"];
        }
    }
}