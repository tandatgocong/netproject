﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CoDien.DB;

namespace CoDien.View
{
    public partial class News : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["style"] = "height:870px;";
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            NewsLoad();
            binding();
        }
        void NewsLoad() {
            try
            {
                DataTable tb = Class.C_News.getNews("");
                if (tb != null)
                {
                    if (!"".Equals(tb.Rows[0]["NEWIMG"] + ""))
                    {
                        Image1.ImageUrl = tb.Rows[0]["NEWIMG"] + "";
                    }
                    else
                    {
                        Image1.ImageUrl = @"~/Image/NEWS/Default.jpg";
                    }
                    lbTitle0.Text = tb.Rows[0]["NEWSTILE"] + "";
                    lbMoTa.Text = tb.Rows[0]["NEWSDICRIPTION"] + "";
                    Session["content"] = tb.Rows[0]["NEWSCONTENT"] + "";
                    if ((tb.Rows[0]["NEWSCONTENT"] + "").Length < 10000)
                    {
                        Session["style"] = " height:870px;";
                    }
                    else
                    {
                        Session["style"] = "";
                    }
                }
            }
            catch (Exception)
            {
                 
            }
            
        }
        void binding() {
            DataTable tb = Class.C_News.getNews("");
            GridView1.DataSource = tb;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binding();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ("SELECTTION".Equals(e.CommandName)) {
                NEW news = Class.C_News.getNewsByID(int.Parse(e.CommandArgument + ""));
                if (news != null)
                {
                    if (!"".Equals(news.NEWIMG))
                    {
                        Image1.ImageUrl = news.NEWIMG;
                    }
                    else
                    {
                        Image1.ImageUrl = @"~/Image/NEWS/Default.jpg";
                    }
                    lbTitle0.Text =news.NEWSTILE;
                    lbMoTa.Text = news.NEWSDICRIPTION; 
                    Session["content"] = news.NEWSCONTENT;
                    if (news.NEWSCONTENT.Length < 10000)
                    {
                        Session["style"] = " height:870px;";
                    }
                    else {
                        Session["style"] = "";
                    }
                }
            }
        }
    }
}