using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using BanHang.Database;

namespace BanHang.tab
{
    public partial class tbNhapHang : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public tbNhapHang()
        {
            InitializeComponent();

             this.txtChietKhau.Text = ConfigurationManager.AppSettings["thuong"].ToString();
             Load();
             loadId();
        }
        public void loadId()
        {
            txtMaHang.Text = DAL.Idetity.IdentityBienNhan();

            txtChuHang.Text = DAL.Idetity.IdentityChuHang();
        }
        public void Load()
        {
            string sql = "SELECT MANHAP, CONVERT(DATETIME,NGAYNHAP,103) as NGAYNHAP, CHUHANG, MAHANG, TENHANG, SIZE, SLNHAP, DONGIA, THANHTIEN, GHICHU ";
            sql += " FROM NHAP_HANG ";
            sql += " WHERE  CONVERT(DATETIME,NGAYNHAP,103) BETWEEN CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(theodoi_tungay.Value.Date) + "',103) AND CONVERT(DATETIME,'" + Utilities.DateToString.NgayVN(theodoi_denngay.Value.Date) + "',103) ";
            sql += " ORDER BY NGAYNHAP ASC, CHUHANG ASC ";

            girdNhapHang.DataSource = DAL.LinQConnection.getDataTable(sql);
            
       }
        private void btThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkThanThiet.Checked)
                {
                    if (DAL.C_ChuHang.findbyChuHang(this.txtChuHang.Text.Replace(" ", "")) == null)
                    {
                        CHUHANG ch = new CHUHANG();
                        ch.MACHUHANG = this.txtChuHang.Text;
                        ch.TENKH = this.txtHoTen.Text;
                        ch.DIACHI = this.txtDiaChi.Text;
                        ch.SODT = this.txtSDT.Text;
                        ch.SOTK = this.txtSoTK.Text;
                        ch.NGANHANG = this.txtNganHang.Text;
                        ch.CREATEBY = Environment.UserName;
                        ch.CREATEDATE = DateTime.Now;
                        DAL.C_ChuHang.Insert(ch);
                    }
                }

                NHAP_HANG nhap = new NHAP_HANG();
                nhap.NGAYNHAP = DateTime.Now.Date;
                nhap.CHUHANG = txtChuHang.Text;
                nhap.HOTEN = txtHoTen.Text;
                nhap.NGANHANG = txtNganHang.Text;
                nhap.SODT = txtSDT.Text;
                nhap.DIACHI = txtDiaChi.Text;
                nhap.SOTK = txtSoTK.Text;
                nhap.MAHANG = txtMaHang.Text;
                nhap.GHICHU = txtGhiChu.Text;
                nhap.TENHANG = txtTenHang.Text;
                nhap.SIZE = txtSize.Text;
                nhap.SLTAMTT = 0;
                nhap.STTAMTT = 0;
                nhap.CHIETKHAU = double.Parse(this.txtChietKhau.Text);
                nhap.SLNHAP = txtSoLuong.Value;
                nhap.DONGIA = decimal.Parse(txtGiaBan.Text);
                decimal tongtien = (txtSoLuong.Value * decimal.Parse(txtGiaBan.Text)) - (decimal.Parse(this.txtChietKhau.Text) * (txtSoLuong.Value * decimal.Parse(txtGiaBan.Text)));
                nhap.THANHTIEN = tongtien;
                
                nhap.LOINHUAN = double.Parse(this.txtChietKhau.Text) * (txtSoLuong.Value * double.Parse(txtGiaBan.Text));
                nhap.SLBAN = 0;
                nhap.CREATEBY = Environment.UserName;
                nhap.CREATEDATE = DateTime.Now.Date;;
                if (DAL.C_NhapHang.Insert(nhap))
                {
                    MessageBox.Show(this, "Nhập Hàng Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTenHang.Text = "";
                    txtMaHang.Text = DAL.Idetity.IdentityBienNhan();
                    txtSize.Text = "";
                    txtSoLuong.Value = 0;
                    txtGiaBan.Text = "0";
                    txtGhiChu.Text = "";

                }
                else
                    MessageBox.Show(this, "Nhập Hàng Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Load();
            }
            catch (Exception)
            {

                MessageBox.Show(this, "Nhập Hàng Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void rs()
        {
            txtChuHang.Text = "";
            txtHoTen.Text = "";
            txtNganHang.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtSoTK.Text = "";
            txtMaHang.Text = "";
            txtGhiChu.Text = "";
            txtTenHang.Text = "";
            txtSize.Text = "";
            this.txtChietKhau.Text = ConfigurationManager.AppSettings["thuong"].ToString();
            txtSoLuong.Value = 0;
            txtGiaBan.Text = "0";
            loadId();        
        }
        private void btLamLai_Click(object sender, EventArgs e)
        {
            rs();

        }

        private void checkThanThiet_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkThanThiet.Checked)
            {
                this.txtChietKhau.Text = ConfigurationManager.AppSettings["thanthiet"].ToString();
                this.txtChuHang.Text = "";
                List<CHUHANG> list = DAL.C_ChuHang.getList();
                foreach (var item in list)
                {
                    namesCollection.Add(item.MACHUHANG);
                }
                txtChuHang.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtChuHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtChuHang.AutoCompleteCustomSource = namesCollection;
                this.txtChuHang.ReadOnly = false;
            }
            else
            {
                this.txtChietKhau.Text = ConfigurationManager.AppSettings["thuong"].ToString();
                txtChuHang.Text = DAL.Idetity.IdentityChuHang();
                this.txtChuHang.ReadOnly = true; 
            }
        }

        private void theodoi_tungay_ValueChanged(object sender, EventArgs e)
        {
            Load();
        }

        private void theodoi_denngay_ValueChanged(object sender, EventArgs e)
        {
            Load();
        }

        private void menuCapNhatKetQua_Click(object sender, EventArgs e)
        {
            string ID_NHAPHANG = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["MANHAP"].Value + "";
            fromDieuChinhNhapHang frm = new fromDieuChinhNhapHang(ID_NHAPHANG);
            frm.ShowDialog();

        }

        private void girdNhapHang_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(girdNhapHang, new Point(e.X, e.Y));
            }
        }

        private void txtChuHang_Leave(object sender, EventArgs e)
        {
            if (checkThanThiet.Checked)
            {
                CHUHANG ch = DAL.C_ChuHang.findbyChuHang(this.txtChuHang.Text.Replace(" ", ""));
                if (ch != null)
                {
                    this.txtHoTen.Text = ch.TENKH;
                    this.txtDiaChi.Text = ch.DIACHI;
                    this.txtSDT.Text = ch.SODT;
                    this.txtSoTK.Text = ch.SOTK;
                    this.txtNganHang.Text = ch.NGANHANG;
                }
            }
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtGiaBan.Text = String.Format("{0:0,0}", decimal.Parse(txtGiaBan.Text));
                txtGiaBan.SelectionStart = txtGiaBan.Text.Length;
            }
            catch (Exception)
            {
            }
        }

        private void tbNhapHang_Load(object sender, EventArgs e)
        {
            
        }
    }
}
