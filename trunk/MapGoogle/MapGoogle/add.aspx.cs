using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.IO;
using MapGoogle.Databases;
using System.Text.RegularExpressions;
namespace MapGoogle
{
    public partial class add : System.Web.UI.Page
    {
        protected HtmlInputFile filMyFile;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string imgpath="";
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (filMyFile.PostedFile != null)
            {
                try
                {
                    HttpPostedFile myFile = filMyFile.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen > 0)
                    {
                        byte[] myData = new byte[nFileLen];
                        myFile.InputStream.Read(myData, 0, nFileLen);
                        string strFilename = Path.GetFileName(myFile.FileName);
                        WriteToFile(Server.MapPath("Image\\" + strFilename), ref myData);
                        imgpath = @"Image/" + strFilename;
                        imgFile.ImageUrl = imgpath;
                        this.imagePath.Value = imgpath;
                        imgFile.ToolTip = "This file was stored to as file.";
                    }
                }
                catch (Exception)
                {
                    this.upload.Text = "Lỗi Không Upload Ảnh Về Server";
                }
                
            }
        }
        private void WriteToFile(string strPath, ref byte[] Buffer)
        {
            FileStream newFile = new FileStream(strPath, FileMode.Create);
            newFile.Write(Buffer, 0, Buffer.Length);
            newFile.Close();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                 MapDemoDataContext db = new MapDemoDataContext();
                 string local = Request.QueryString["location"];
                //=(10.7523028428119,106.5858256816864)
                 local = local.Replace("(","").Replace(")","");
                 string[] word = Regex.Split(local, ",");
                // this.upload.Text =local+ "---- x=" + word[0] + "-- y=" + word[1];
                 LOCATION location = new LOCATION();
                 location.X = double.Parse(word[0]);
                 location.Y = double.Parse(word[1]);
                 location.MACHINHANH = this.txtMaChiNhanh.Text;
                 location.TENCHINHANH = this.txtTenChiNhanh.Text;
                 location.ADDRESS = this.txtDiaChi.Text;
                 location.LOAICHINHANH = this.txtLoaiCH.Text;
                 location.TRUNGBAY = this.txtTrungBay.Text;
                 location.TANSO = this.txtTanSo.Text;
                 location.DIENTHOAI = this.txtSoCall.Text;
                 location.CHUCHINHANH = this.txtChuCuaHang.Text;
                 location.IMG = this.imagePath.Value;
                 db.LOCATIONs.InsertOnSubmit(location);
                 db.SubmitChanges();
                 Session["x"] = word[0];
                 Session["y"] = word[1];
                 lbThanhCong.ForeColor = Color.Blue;
                 this.lbThanhCong.Text = "Thêm Mới Địa Điểm Thành Công.";
            }
            catch (Exception)
            {
                lbThanhCong.ForeColor = Color.Red;
                this.lbThanhCong.Text = "Thêm Mới Địa Điểm Thất Bại.";

            }
        }

    }
}