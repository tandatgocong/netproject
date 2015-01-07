using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BanHang.Database;
using System.Configuration;

namespace BanHang.tab
{
    public partial class fromDieuChinhNhapHang : Form
    {
        NHAP_HANG nhap;
        public fromDieuChinhNhapHang(string ID_NHAPHANG)
        {
            InitializeComponent();
            nhap = DAL.C_NhapHang.finByMaNhap(int.Parse(ID_NHAPHANG));
            if (nhap != null)
            {
                if (ConfigurationManager.AppSettings["thanthiet"].ToString().Equals(nhap.CHIETKHAU))
                    this.checkThanThiet.Checked = true;
                txtChuHang.Text = nhap.CHUHANG;
                txtHoTen.Text =nhap.HOTEN ;
                txtNganHang.Text = nhap.NGANHANG;
                txtSDT.Text = nhap.SODT;
                txtDiaChi.Text = nhap.DIACHI;
                txtSoTK.Text = nhap.SOTK;
                txtMaHang.Text = nhap.MAHANG;
                txtGhiChu.Text = nhap.GHICHU;
                txtTenHang.Text = nhap.TENHANG;
                txtSize.Text = nhap.SIZE;
                this.txtChietKhau.Text = nhap.CHIETKHAU+"";
                txtSoLuong.Text =nhap.SLNHAP+"";
                txtGiaBan.Text = nhap.DONGIA + "";
                txtGhiChu.Text = nhap.GHICHU;

            }

        }

       

        private void btLamLai_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkThanThiet_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkThanThiet.Checked)
                this.txtChietKhau.Text = ConfigurationManager.AppSettings["thanthiet"].ToString();
            else
                this.txtChietKhau.Text = ConfigurationManager.AppSettings["thuong"].ToString();
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {

        }
    }
}
