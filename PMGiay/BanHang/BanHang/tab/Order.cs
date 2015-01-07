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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
            this.txtOrderId.Text = DAL.Idetity.IdentityHoaDon();
            girdNhapHang.DataSource = DAL.C_GioHang.tb;

            this.lbTongSL.Text = DAL.C_GioHang._soluong + "";
            this.lbTongTT.Text = String.Format("{0:0,0}", DAL.C_GioHang._tongtien);

        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                HOADON hd = new HOADON();
                hd.MAHD = this.txtOrderId.Text;
                hd.MAKH = "";
                hd.TENKH = this.txtHoTen.Text;
                hd.DIACHI = this.txtDiaChi.Text;
                hd.SODT = this.txtSDT.Text;
                hd.TONGTIEN = DAL.C_GioHang._tongtien;
                hd.TRACHUHANG = DAL.C_GioHang._trachuhang;
                hd.NHAPQUY = DAL.C_GioHang._nhapquy;
                hd.GHICHU = this.txtGhiChu.Text;
                hd.NGAYLAP = DateTime.Now.Date;
                hd.CREATEBY = Environment.UserName;
                hd.CREATEDATE = DateTime.Now.Date;
                string G_G="";
                if (DAL.C_HoaDon.Insert(hd))
                {
                    for (int i = 0; i < girdNhapHang.Rows.Count; i++)
                    {
                        CT_HOADON cthd = new CT_HOADON();
                        cthd.MAHD = this.txtOrderId.Text;
                        cthd.MANHAP = girdNhapHang.Rows[i].Cells["MANHAP"].Value + "";
                        cthd.MAHANG = girdNhapHang.Rows[i].Cells["Mahang"].Value + "";
                        cthd.TENHANG = girdNhapHang.Rows[i].Cells["tenhang"].Value + "";
                        cthd.SIZE = girdNhapHang.Rows[i].Cells["SIZE"].Value + "";
                        cthd.SOLUONG = int.Parse(girdNhapHang.Rows[i].Cells["soluong"].Value + "");
                        cthd.DONGIA = float.Parse(girdNhapHang.Rows[i].Cells["dongia"].Value + "");
                        cthd.TONGTIEN = decimal.Parse(girdNhapHang.Rows[i].Cells["thanhtien"].Value + "");
                        cthd.TRACHUHANG = decimal.Parse(girdNhapHang.Rows[i].Cells["TRACHUHANG"].Value + "");
                        cthd.NHAPQUY = decimal.Parse(girdNhapHang.Rows[i].Cells["NHAPQUY"].Value + "");

                        cthd.CREATEBY = Environment.UserName;
                        cthd.CREATEDATE = DateTime.Now.Date;
                         string v_giamgia = girdNhapHang.Rows[i].Cells["GIAMGIA"].Value + "";
                         if (v_giamgia != "")
                             G_G = "(Sale " + v_giamgia + ")";

                        DAL.C_HoaDon.InsertCT(cthd);
                        string sql = "UPDATE NHAP_HANG SET SLBAN=SLBAN+" + cthd.SOLUONG + ",SLTAMTT=SLTAMTT+" + cthd.SOLUONG + ",STTAMTT=STTAMTT+" + cthd.TRACHUHANG + "  WHERE MANHAP='" + cthd.MANHAP + "'";
                        DAL.LinQConnection.ExecuteCommand_(sql);

                    }

                    if (DAL.C_GioHang._nhapquy != 0)
                    {
                        DAL.C_QLQuy.NhapXuatQuy(DAL.C_GioHang._nhapquy, "Bán Hóa Đơn Hàng [" + this.txtOrderId.Text + " ]" + G_G);
                    }
                    MessageBox.Show(this, "Thanh Toán Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DAL.C_GioHang.tb = null;
                    DAL.C_GioHang._soluong = 0;
                    DAL.C_GioHang._tongtien = 0;
                    DAL.C_GioHang._nhapquy = 0;
                    DAL.C_GioHang._trachuhang = 0;


                }

                else
                    MessageBox.Show(this, "Thanh Toán Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {

                MessageBox.Show(this, "Nhập Hàng Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btInGioHang_Click(object sender, EventArgs e)
        {
            DAL.C_GioHang.tb = null;
            DAL.C_GioHang._soluong = 0;
            DAL.C_GioHang._tongtien = 0;
            DAL.C_GioHang._nhapquy = 0;
            DAL.C_GioHang._trachuhang = 0;
        }

        public void tongthanhtien()
        {
            DAL.C_GioHang._tongtien = 0;
            for (int i = 0; i < girdNhapHang.Rows.Count; i++)
            {

                DAL.C_GioHang._tongtien += decimal.Parse(girdNhapHang.Rows[i].Cells["thanhtien"].Value + "");
               
            }
            this.lbTongTT.Text = String.Format("{0:0,0}", DAL.C_GioHang._tongtien);
        }
        private void girdNhapHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(this, e.ColumnIndex + "");
            if (e.RowIndex < 0) return;
            else if (e.ColumnIndex == 0)
            {
                string v_giamgia = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["GIAMGIA"].Value + "";
                if (v_giamgia != "")
                {

                    string v_manhap = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["MANHAP"].Value + "";
                    string v_soluong = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["soluong"].Value + "";
                    string v_dongia = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["dongia"].Value + "";
                    NHAP_HANG nhap = DAL.C_NhapHang.finByMaNhap(int.Parse(v_manhap));
                    
                    decimal tt = int.Parse(v_soluong) * decimal.Parse(v_dongia);    
                    decimal quy = tt * decimal.Parse(nhap.CHIETKHAU.Value + "");

                    DAL.C_GioHang._tongtien -= tt;

                    DAL.C_GioHang._trachuhang -= (tt - quy);
                    DAL.C_GioHang._nhapquy -= quy;

                    // SAU GIAM GIA


                    decimal G_tt = (int.Parse(v_soluong) * decimal.Parse(v_dongia)) - (int.Parse(v_soluong) * decimal.Parse(v_dongia) * (decimal.Parse(v_giamgia)/100));

                    decimal G_quy = G_tt * decimal.Parse(nhap.CHIETKHAU.Value + "");

                    DAL.C_GioHang._tongtien += G_tt;

                    DAL.C_GioHang._trachuhang += (G_tt - G_quy);
                    DAL.C_GioHang._nhapquy += G_quy;
                    girdNhapHang.Rows[girdNhapHang.CurrentCell.RowIndex].Cells["thanhtien"].Value = G_tt;
                    girdNhapHang.Rows[girdNhapHang.CurrentCell.RowIndex].Cells["TRACHUHANG"].Value = (G_tt - G_quy);
                    girdNhapHang.Rows[girdNhapHang.CurrentCell.RowIndex].Cells["NHAPQUY"].Value = G_quy;

                    tongthanhtien();

                }
            }
        }
    }
}