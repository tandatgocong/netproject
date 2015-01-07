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
    public partial class tbqlQuyNhapHang1 : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public tbqlQuyNhapHang1()
        {
            InitializeComponent();

            this.txtChietKhau.Text = ConfigurationManager.AppSettings["thuong"].ToString();
            Load();
        }
        public void loadId()
        {
            //txtMaHang.Text = DAL.Idetity.IdentityBienNhan();

            //txtChuHang.Text = DAL.Idetity.IdentityChuHang();
        }
        public void Load()
        {

            try
            {
                string sql = "SELECT TOP(100) MANHAP, SLTAMTT,STTAMTT, CONVERT(VARCHAR(50),NGAYNHAP,103) as NGAYNHAP,CHUHANG,HOTEN,SODT, MAHANG, TENHANG, SIZE, SLNHAP, DONGIA, THANHTIEN,THANHTOAN, CONVERT(VARCHAR(50),NGAYTHANHTOAN,103) as NGAYTHANHTOAN, (THANHTIEN-THANHTOAN) AS TIENCL,GHICHUTT, GHICHU ";
                sql += " FROM NHAP_HANG WHERE MANHAP IS NOT NULL ";

                if (!"".Equals(this.txtMaCH.Text.Replace(" ", "")))
                    sql += " AND CHUHANG = N'" + this.txtMaCH.Text.Replace(" ", "") + "' ";

                if (!"".Equals(this.txtHoTenCH.Text.Replace(" ", "")))
                    sql += " AND HOTEN LIKE N'%" + this.txtHoTenCH.Text.Replace(" ", "") + "%' ";

                if (!"".Equals(this.txtSODTCH.Text.Replace(" ", "")))
                    sql += " AND SODT LIKE N'%" + this.txtSODTCH.Text.Replace(" ", "") + "%' ";

                sql += " ORDER BY SLTAMTT DESC";

                girdNhapHang.DataSource = DAL.LinQConnection.getDataTable(sql);
            }
            catch (Exception ex)
            {
            }

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
            }
            else
            {
                this.txtChietKhau.Text = ConfigurationManager.AppSettings["thuong"].ToString();
                txtChuHang.Text = DAL.Idetity.IdentityChuHang();
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
        NHAP_HANG nhap;
        private void girdNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btThanhToan.Enabled = true;
            string ID_NHAPHANG = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["MANHAP"].Value + "";
            string STTAMTT_ = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["STTAMTT"].Value + "";
            nhap = DAL.C_NhapHang.finByMaNhap(int.Parse(ID_NHAPHANG));
            if (nhap != null)
            {
                if (ConfigurationManager.AppSettings["thanthiet"].ToString().Equals(nhap.CHIETKHAU))
                    this.checkThanThiet.Checked = true;
                txtChuHang.Text = nhap.CHUHANG;
                txtHoTen.Text = nhap.HOTEN;
                txtNganHang.Text = nhap.NGANHANG;
                txtSDT.Text = nhap.SODT;
                txtDiaChi.Text = nhap.DIACHI;
                txtSoTK.Text = nhap.SOTK;
                this.txtChietKhau.Text = nhap.CHIETKHAU + "";

                ////////////
                txtTongTien.Text = String.Format("{0:0,0}", nhap.THANHTIEN);
                txtThanhToan.Text = String.Format("{0:0,0}", decimal.Parse(STTAMTT_));

                try
                {
                    double tiencl = double.Parse(this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["STTAMTT"].Value + "");
                    if (tiencl > 0)
                        txtThanhToan.Text = String.Format("{0:0,0}", tiencl);
                    else
                    {
                        txtThanhToan.Text = "0";
                        btThanhToan.Enabled = false;

                    }

                }
                catch (Exception)
                {

                }

                //if( this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["MANHAP"].Value + ""

                txtGhiChuTT.Text = nhap.GHICHUTT;
                this.txtThanhToan.Focus();


            }
        }

        private void btXoaHD_Click(object sender, EventArgs e)
        {
            string ID_NHAPHANG = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["MANHAP"].Value + "";

            nhap = DAL.C_NhapHang.finByMaNhap(int.Parse(ID_NHAPHANG));
            if (nhap != null)
            {
                if (MessageBox.Show(this, "Xóa Thông Tin Đơn Hàng ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DAL.C_NhapHang.Delete(nhap);
                    MessageBox.Show(this, "Xóa Thông Tin Đơn Hàng Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load();
                }

            }

        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(this.txtThanhToan.Text) <= decimal.Parse(this.txtTongTien.Text) && decimal.Parse(this.txtThanhToan.Text) > 0)
            {
                string ID_NHAPHANG = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["MANHAP"].Value + "";
                nhap = DAL.C_NhapHang.finByMaNhap(int.Parse(ID_NHAPHANG));
                if (nhap != null)
                {
                    nhap.THANHTOAN = decimal.Parse(this.txtThanhToan.Text);
                    nhap.SLTAMTT = 0;
                    nhap.STTAMTT = 0;
                    nhap.GHICHUTT = txtGhiChuTT.Text;
                    nhap.NGAYTHANHTOAN = DateTime.Now;
                    if (DAL.C_NhapHang.Update())
                        MessageBox.Show(this, "Cập Nhật Thanh Toán Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(this, "Cập Nhật Thanh Toán Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                Load();
            }
            else
            {
                MessageBox.Show(this, "Tiền Thanh Toán <= Tiền Phải Trả  !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtThanhToan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtThanhToan.Text = String.Format("{0:0,0}", decimal.Parse(txtThanhToan.Text));
                txtThanhToan.SelectionStart = txtThanhToan.Text.Length;
            }
            catch (Exception)
            {
            }
        }

        private void txtMaCH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                Load();
                int count = 0;
                decimal sum = 0;
                for (int i = 0; i < girdNhapHang.Rows.Count; i++)
                {

                    if (!"0".Equals(girdNhapHang.Rows[i].Cells["SLTAMTT"].Value + "") && !"0".Equals(girdNhapHang.Rows[i].Cells["STTAMTT"].Value + ""))
                    {
                        count++;
                        sum += decimal.Parse((girdNhapHang.Rows[i].Cells["STTAMTT"].Value + ""));
                    }
                }
                txtTongDH.Text = count + "";
                txtTongTienTT.Text = String.Format("{0:0,0}", sum);
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < girdNhapHang.Rows.Count; i++)
            {

                if (!"0".Equals(girdNhapHang.Rows[i].Cells["SLTAMTT"].Value + "") && !"00".Equals(girdNhapHang.Rows[i].Cells["STTAMTT"].Value + ""))
                {

                    string ID_NHAPHANG = this.girdNhapHang.Rows[i].Cells["MANHAP"].Value + "";
                    nhap = DAL.C_NhapHang.finByMaNhap(int.Parse(ID_NHAPHANG));
                    if (nhap != null)
                    {
                        nhap.THANHTOAN = decimal.Parse(girdNhapHang.Rows[i].Cells["STTAMTT"].Value + "");
                        nhap.SLTAMTT = 0;
                        nhap.STTAMTT = 0;
                        nhap.GHICHUTT = chGhjChu.Text;
                        nhap.NGAYTHANHTOAN = DateTime.Now;
                        if (DAL.C_NhapHang.Update())
                            count++;
                    }
                }
            }
            Load();
            MessageBox.Show(this, "Thánh Toán Thành Công " + count + " Đơn Hàng !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
