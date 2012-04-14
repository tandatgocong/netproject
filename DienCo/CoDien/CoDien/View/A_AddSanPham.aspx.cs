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
    public partial class A_AddSanPham : System.Web.UI.Page
    {
        protected HtmlInputFile filMyFile;
        string imgpath = "";
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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
                try
                {
                    string fileName = DateTime.Now.ToString("ddmmyyhhmmss") + FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf("."));
                    string SaveLocation = Server.MapPath("~") + @"Image\\SanPham\\" + fileName;
                    FileUpload1.SaveAs(SaveLocation);
                    upload.Visible = true;
                    imgpath = @"~/Image/SanPham/" + fileName;
                    imgFile.ImageUrl = imgpath;
                    this.imagePath.Value = this.imagePath.Value + imgpath;
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
            SANPHAM sp = new SANPHAM();
            sp.MALOAI= cbLoaiSP.SelectedValue+"";
	        sp.MAHIEU= cbNhaSanXuat.SelectedValue+"";
	        sp.TENSP	=txtTenSanPham.Text;
	        sp.GIA = double.Parse(txtGiaBan.Text);
	        sp.MOTA = txtDescription.Text;
	        sp.CHITIET = txtChiTiet.Text;
	        sp.ANH = imagePath.Value;
            if(spMoi.Checked){
                sp.SAPMOI=true;
            }else{
	            sp.SAPMOI=false;
            }
            if(spBanChay.Checked){
                 sp.BANCHAY=true;
            }else{
                 sp.BANCHAY=false;
            }
            sp.CREATEDATE = DateTime.Now;
            if (Class.C_SanPham.InsertSanPham(sp))
            {
                lbResult.CssClass = "resultSuccess";
                lbResult.Text = "Thêm Mới Sản Phẩm Thành Công !";

            }
            else
            {
                lbResult.CssClass = "resultFaild";
                lbResult.Text = "Thêm Mới Sản Phẩm Thất Bại !";

            }
        }
    }
}