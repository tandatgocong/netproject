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
    public partial class A_UpdateSanPham : System.Web.UI.Page
    {
        static log4net.ILog logger = log4net.LogManager.GetLogger("File");
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
            Load();
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

        public void Load()
        {
            try
            {
                string masp = Request.Params["MASP"] != null ? Request.Params["MASP"].ToString() : "";
                SANPHAM sp = Class.C_SanPham.getSanPham(int.Parse(masp));
                if (sp != null)
                {
                    lbSanPham.Text = sp.MASP + "";
                    cbLoaiSP.SelectedValue = sp.MALOAI;
                    cbNhaSanXuat.SelectedValue = sp.MAHIEU;
                    txtTenSanPham.Text = sp.TENSP;
                    txtDescription.Text = sp.MOTA;
                    txtChiTiet.Text = sp.CHITIET;
                    imgFile.ImageUrl = sp.ANH;
                    txtGiaBan.Text = sp.GIA.ToString();
                    spMoi.Checked = bool.Parse("" + sp.SAPMOI);
                    spBanChay.Checked = bool.Parse("" + sp.BANCHAY);

                }


            }
            catch (Exception ex)
            {
                logger.Error("Load Edit Sp " + ex.Message);
            }

        }

        protected void btThemmoi_Click(object sender, EventArgs e)
        {
            SANPHAM sp = Class.C_SanPham.getSanPham(int.Parse(lbSanPham.Text));
            if (sp != null)
            {
                sp.MALOAI = cbLoaiSP.SelectedValue + "";
                sp.MAHIEU = cbNhaSanXuat.SelectedValue + "";
                sp.TENSP = txtTenSanPham.Text;
                sp.GIA = double.Parse(txtGiaBan.Text);
                sp.MOTA = txtDescription.Text;
                sp.CHITIET = txtChiTiet.Text;
                sp.ANH = imagePath.Value;
                if (spMoi.Checked)
                {
                    sp.SAPMOI = true;
                }
                else
                {
                    sp.SAPMOI = false;
                }
                if (spBanChay.Checked)
                {
                    sp.BANCHAY = true;
                }
                else
                {
                    sp.BANCHAY = false;
                }
                sp.CREATEDATE = DateTime.Now;
                if (Class.C_SanPham.UpdateSanPham())
                {
                    lbResult.CssClass = "resultSuccess";
                    lbResult.Text = "Cập Nhật Sản Phẩm Thành Công !";

                }
                else
                {
                    lbResult.CssClass = "resultFaild";
                    lbResult.Text = "Cập Nhật Sản Phẩm Thất Bại !";

                }
            }
        }
    }
}