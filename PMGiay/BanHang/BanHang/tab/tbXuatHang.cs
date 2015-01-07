using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BanHang.Database;
using log4net;

namespace BanHang.tab
{
    public partial class tbXuatHang : UserControl
    {
        AutoCompleteStringCollection namesCollection1 = new AutoCompleteStringCollection();
        AutoCompleteStringCollection namesCollection2 = new AutoCompleteStringCollection();
        AutoCompleteStringCollection namesCollection3 = new AutoCompleteStringCollection();
        AutoCompleteStringCollection namesCollection4 = new AutoCompleteStringCollection();
        private static readonly ILog log = LogManager.GetLogger(typeof(tbSanPham).Name);
        public tbXuatHang()
        {
            InitializeComponent();
            LoadDanhMuc();
        }

        public void LoadDanhMuc()
        {
            try
            {
                string sql = " SELECT MANHAP,NGAYNHAP, CHUHANG, MAHANG, TENHANG, SIZE, DONGIA, SLNHAP-SLBAN AS CONLAI,N'Xuất Hàng' as MUA";
                sql += " FROM NHAP_HANG WHERE SLNHAP<>SLBAN ";
                
                if (!"".Equals(this.txtMaHang.Text.Replace(" ","")))
                    sql += " AND MAHANG LIKE N'%" + this.txtMaHang.Text.Replace(" ", "") + "%' ";
                
                if (!"".Equals(this.txtTenSP.Text.Replace(" ", "")))
                    sql += " AND TENHANG LIKE N'%" + this.txtTenSP.Text.Replace(" ", "") + "%' ";
                
                if (!"".Equals(this.txtSize.Text.Replace(" ", "")))
                    sql += " AND SIZE ='" + this.txtSize.Text.Replace(" ", "") + "' ";
                
                if (!"".Equals(this.txtChuHang.Text.Replace(" ", "")))
                    sql += " AND CHUHANG LIKE N'%" + this.txtChuHang.Text.Replace(" ", "") + "%' ";

                sql += " ORDER BY NGAYNHAP ASC";

                girdNhapHang.DataSource = DAL.LinQConnection.getDataTable(sql);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }



        private void girdNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         //       MessageBox.Show(this, e.ColumnIndex + "");
            if (e.RowIndex < 0) return;
            else if (e.ColumnIndex == 0)
            {
                //cbSLmua.Visible = true;
                //cbSLmua.Top = this.girdNhapHang.Top + girdNhapHang.GetRowDisplayRectangle(e.RowIndex, true).Top; ;
                //cbSLmua.Left = girdNhapHang.Left + girdNhapHang.GetColumnDisplayRectangle(e.ColumnIndex, true).Left; ;
                //cbSLmua.Width = girdNhapHang.Columns[e.ColumnIndex].Width;
                //cbSLmua.Height = girdNhapHang.Rows[e.RowIndex].Height;
                //cbSLmua.BringToFront();
                //  cmbTaiKhoanLuoi.SelectedValue = DatagirdThem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            else if (e.ColumnIndex == 10)
            {
                string v_manhap = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["MANHAP"].Value + "";
                string v_masp = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["Mahang"].Value + "";
                string v_GhiChu = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["GhiChu"].Value + "";
                string v_size = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["SIZE"].Value + "";
                string v_soluong = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["slMua"].Value + "";
                string v_dongia = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["dongia"].Value + "";
                string v_conlai = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["soluong"].Value + "";
                if ("".Equals(v_soluong) || int.Parse(v_soluong) <= 0)
                    MessageBox.Show(this, "Số Lượng Xuất >=1 !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else if (int.Parse(v_soluong) > int.Parse(v_conlai))
                    MessageBox.Show(this, "Hàng trong kho không đủ số lượng xuất !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    NHAP_HANG nhap = DAL.C_NhapHang.finByMaNhap(int.Parse(v_manhap));

                    nhap.THANHTIEN = (nhap.SLNHAP - int.Parse(v_soluong)) * nhap.DONGIA;

                    nhap.SLNHAP = (nhap.SLNHAP - int.Parse(v_soluong));
                    
                    nhap.GHICHUXUATHANG = v_GhiChu;
                    if (DAL.C_NhapHang.Update())
                    {
                        MessageBox.Show(this, "Xuất Hàng Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        girdNhapHang.Rows[girdNhapHang.CurrentCell.RowIndex].Cells["soluong"].Value = int.Parse(girdNhapHang.Rows[girdNhapHang.CurrentCell.RowIndex].Cells["soluong"].Value.ToString()) - int.Parse(v_soluong);
                    }

                    


                }
               
            }
        }

        private void cbSLmua_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                girdNhapHang.Rows[girdNhapHang.CurrentCell.RowIndex].Cells[girdNhapHang.CurrentCell.ColumnIndex].Value = this.cbSLmua.SelectedItem.ToString();
                cbSLmua.Visible = false;
            }
            catch (Exception)
            {

            }

        }

        private void gioHang_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMaHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                LoadDanhMuc();
        }

        private void txtTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                LoadDanhMuc();
        }

        private void txtSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                LoadDanhMuc();
        }

        private void txtChuHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
                LoadDanhMuc();

        }
    }
}