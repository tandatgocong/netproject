using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using CoDien.DB;

namespace CoDien.View
{
    public partial class A_News_Add : System.Web.UI.Page
    {
        protected HtmlInputFile filMyFile;
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
        }
        string imgpath = "";
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
                try
                {
                    string fileName = DateTime.Now.ToString("ddmmyyhhmmss") + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf("."));
                    string SaveLocation = Server.MapPath("~") + @"Image\\NEWS\\" + fileName;
                    FileUpload1.SaveAs(SaveLocation);
                    upload.Visible = true;
                    imgpath = @"~/Image/NEWS/" + fileName;
                    imgFile.ImageUrl = imgpath;
                    this.imagePath.Value = this.imagePath.Value + imgpath ;
                    Session["imgfile"] = this.imagePath.Value;
                    imgFile.ToolTip = "This file was stored to as file.";
                }
                catch (Exception)
                {
                    this.upload.Text = "Lỗi Không Upload Ảnh Về Server";
                }
        }
        private void WriteToFile(string strPath, ref byte[] Buffer)
        {
            FileStream newFile = new FileStream(strPath, FileMode.Create);
            newFile.Write(Buffer, 0, Buffer.Length);
            newFile.Close();
        }

        protected void btThemmoi_Click(object sender, EventArgs e)
        {
            NEW news = new NEW();
            news.NEWSTILE = this.txtTitle.Text;
            news.NEWSDICRIPTION = this.txtDescription.Text;
            news.NEWSCONTENT = this.noidung.Text;
            news.NEWIMG = imagePath.Value;
            news.CREATEDATE = DateTime.Now;
            if (Class.C_News.InsertNews(news))
            {
                lbResult.CssClass = "resultSuccess";
                lbResult.Text = "Thêm Mới Tin Tức Thành Công !";

            }
            else
            {
                lbResult.CssClass = "resultFaild";
                lbResult.Text = "Thêm Mới Tin Tức Thất Bại !";

            }
        }
    }
}