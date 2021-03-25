using BanHangThep.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanHangThep
{
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();

            dateNgayCapNhat.Value = DateTime.Now.Date;

            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<NHAP_HANG> list = Class.C_NhapHang.getListNhapHang();
            foreach (var item in list)
            {
                namesCollection.Add(item.MAHANG);
            }
            cbMaHang.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbMaHang.AutoCompleteCustomSource = namesCollection;

            formload();
        }
        void formload()
        {
            gridList.DataSource = Class.LinQConnection.getDataTable("SELECT  ROW_NUMBER() OVER (ORDER  BY [NGAYCNGIA] DESC) AS 'STT'   ,[MAHANG] ,[TENHANG] ,[DVT] ,[SOLUONG] ,[GIANHAP] ,[GIABAN] ,[NGAYCNGIA] ,[TRONGLUONG] ,[GHICHU] FROM NHAP_HANG ORDER BY [NGAYCNGIA]  DESC ");
        }


        //private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (Convert.ToInt32(e.KeyChar) == 13)
        //    {
        //        MessageBox.Show(this, "dafdsa");
        //    }
        //}

        private void cbMaHang_Leave(object sender, EventArgs e)
        {
            try
            {
                loadNhapHang(cbMaHang.Text);
                txtSoLuongNhap.Focus();
            }
            catch (Exception)
            {

            }
        }
        void loadNhapHang(string mahang)
        {
            NHAP_HANG nh = Class.C_NhapHang.findbyMaHang(mahang);
            if (nh != null)
            {
                cbMaHang.Text = nh.MAHANG;
                txtTenHang.Text = nh.TENHANG;
                txtDVT.Text = nh.DVT;
                txtTrongluong.Text = nh.TRONGLUONG + "";
                txtGiaNhap.Text = nh.GIANHAP + "";
                txtGia.Text = nh.GIANHAP + "";
                txtGiaNhapMoi.Text = nh.GIANHAP + "";
                txtGiaBan.Text = nh.GIABAN + "";
                txtSLTon.Text = nh.SOLUONG + "";
                txtGiaBanMoi.Text = nh.GIABAN + "";
                dateNgayCapNhat.Value = nh.NGAYCNGIA.Value;
            }
        }

        private void gridList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string mahang = this.gridList.Rows[e.RowIndex].Cells["gMaHang"].Value + "";
                loadNhapHang(mahang);
                txtSoLuongNhap.Value = 0;
                txtSoLuongNhap.Focus();
            }
            catch (Exception)
            {

            }

        }

        //private void txtGiaMoi_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        txtGiaBan.Text = String.Format("{0:0,0}", decimal.Parse(txtGiaBan.Text));
        //       // txtGiaBan.SelectionStart = txtGiaBan.Text.Length;
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    if (Convert.ToInt32(e.KeyChar) == 13)
        //    {
        //        decimal giamoi =  (txtGiaNhap.Value+ txtGiaMoi.Value)/2 ;
        //        this.txtGiaNhapMoi.Value = giamoi;
        //        this.txtGiaBanMoi.Focus();
        //    }
        //}

        private void btNhapHang_Click(object sender, EventArgs e)
        {
            string mahang = this.cbMaHang.Text;

            if (MessageBox.Show(this, "Xác nhận nhập hàng ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Lưu Nhập Hàng củ
                string sql = "INSERT INTO NHAP_HANG_HIS SELECT * FROM NHAP_HANG WHERE MAHANG='" + mahang + "'";
                Class.LinQConnection.ExecuteCommand_(sql);
                // Nhập hàng mới
                decimal sumNhap = (txtSLTon.Value + txtSoLuongNhap.Value);
                sql = "UPDATE NHAP_HANG SET ";
                sql += " TENHANG=N'" + txtTenHang.Text + "'";
                sql += ", DVT=N'" + txtDVT.Text + "'";
                sql += ", SOLUONG=" + sumNhap;
                sql += ", GIANHAP=" + txtGiaNhapMoi.Text.Replace(",", "");
                sql += ", GIABAN=" + txtGiaBanMoi.Text.Replace(",", "");
                sql += ", NGAYCNGIA=GETDATE()";
                sql += ", TRONGLUONG=" + txtTrongluong.Text;
                sql += ", GHICHU=N'" + txtGhiChu.Text + "'";
                sql += ", MODIFYBY=N'aa',MODIFYDATE=GETDATE()";
                sql += " WHERE MAHANG='" + mahang + "'";
                Class.LinQConnection.ExecuteCommand_(sql);
            }
            // 

            formload();
        }

        //private void textBoxX1_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        textBoxX1.Text = String.Format("{0:0,0}", decimal.Parse(textBoxX1.Text));
        //        textBoxX1.SelectionStart = textBoxX1.Text.Length;
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        void formatSo(TextBox tbx)
        {
            try
            {
                tbx.Text = String.Format("{0:0,0}", decimal.Parse(tbx.Text));
                tbx.SelectionStart = tbx.Text.Length;
            }
            catch (Exception)
            {
            }
        }

        void NhapSo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            formatSo(txtGia);
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            NhapSo(sender, e);

            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                double giamoi = (double.Parse(txtGiaNhap.Text) + double.Parse(txtGia.Text)) / 2;
                this.txtGiaNhapMoi.Text = String.Format("{0:0,0}", giamoi); ;
                this.txtGiaBanMoi.Focus();
            }

        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            formatSo(txtGiaNhap);
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            NhapSo(sender, e);
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            formatSo(txtGiaBan);
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            NhapSo(sender, e);
        }

        private void txtGiaNhapMoi_TextChanged(object sender, EventArgs e)
        {
            formatSo(txtGiaNhapMoi);
        }

        private void txtGiaNhapMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            NhapSo(sender, e);
        }

        private void txtGiaBanMoi_TextChanged(object sender, EventArgs e)
        {
            formatSo(txtGiaBanMoi);
        }

        private void txtGiaBanMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            NhapSo(sender, e);
        }

        void CLEAR()
        {
            cbMaHang.Text = "";
            txtTenHang.Text = "";
            txtDVT.Text = "";
            txtTrongluong.Text = "";
            txtGiaNhap.Text = "";
            txtGia.Text = "";
            txtGiaNhapMoi.Text = "";
            txtGiaBan.Text = "";
            txtSLTon.Text = "";
            txtGiaBanMoi.Text = "";
            this.cbMaHang.Focus();
        }
        private void btLammoi_Click(object sender, EventArgs e)
        {
            CLEAR();
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            // Nhập hàng mới
            string mahang = this.cbMaHang.Text;
            NHAP_HANG nh = Class.C_NhapHang.findbyMaHang(mahang);
            if (nh == null)
            {
                if (MessageBox.Show(this, "Xác nhận Thêm mới nhập hàng ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    decimal sumNhap = (txtSLTon.Value + txtSoLuongNhap.Value);
                    string sql = "INSERT INTO [QLHANGTHEP].[dbo].[NHAP_HANG] ([MAHANG],[TENHANG],[DVT],[SOLUONG],[GIANHAP],[GIABAN],[NGAYCNGIA],[TRONGLUONG],[GHICHU],[CREATEBY],[CREATEDATE]  )   VALUES ";
                    sql += " ( N'" + cbMaHang.Text + "'";
                    sql += " , N'" + txtTenHang.Text + "'";
                    sql += ", N'" + txtDVT.Text + "'";
                    sql += "," + sumNhap;
                    sql += "," + txtGiaNhap.Text.Replace(",", "");
                    sql += ", " + txtGiaBan.Text.Replace(",", "");
                    sql += ", GETDATE()";
                    sql += ", " + txtTrongluong.Text;
                    sql += ", N'" + txtGhiChu.Text + "'";
                    sql += ", N'aa'";
                    sql += ", GETDATE()) ";

                    Class.LinQConnection.ExecuteCommand_(sql);
                    formload();
                }
            }
            else
            {
                MessageBox.Show(this, "Mã hàng đã tồn tại, Vui lòng nhập mã hàng mới ?", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string mahang = this.cbMaHang.Text;

            if (MessageBox.Show(this, "Xác nhận xóa mặt hàng ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Lưu Nhập Hàng củ
                string sql = "DELETE FROM NHAP_HANG  WHERE MAHANG='" + mahang + "'";
                Class.LinQConnection.ExecuteCommand_(sql);
                CLEAR();
            }
            // 

            formload();
        }
    }
}
