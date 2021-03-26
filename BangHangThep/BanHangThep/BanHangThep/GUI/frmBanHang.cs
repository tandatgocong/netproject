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
using System.Configuration;

namespace BanHangThep
{
    public partial class frmBanHang : Form
    {
        NHAP_HANG nh = null;

        public frmBanHang()
        {
            InitializeComponent();


            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            List<NHAP_HANG> list = Class.C_NhapHang.getListBan();
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
          //  gridList.DataSource = Class.LinQConnection.getDataTable("SELECT  ROW_NUMBER() OVER (ORDER  BY [NGAYCNGIA] DESC) AS 'STT'   ,[MAHANG] ,[TENHANG] ,[DVT] ,[SOLUONG] ,[GIANHAP] ,[GIABAN] ,[NGAYCNGIA] ,[TRONGLUONG] ,[GHICHU] FROM NHAP_HANG ORDER BY [NGAYCNGIA]  DESC ");
            txtMaHoaDon.Text = Class.C_GioHang.IdentityHoaDon();
            formatSo(txtTongTien);
        }

        private void cbMaHang_Leave(object sender, EventArgs e)
        {
            try
            {
                loadNhapHang(cbMaHang.Text);
             
            }
            catch (Exception)
            {

            }
        }
        void loadNhapHang(string mahang)
        {
            nh = Class.C_NhapHang.findbyMaHang(mahang);
            if (nh != null)
            {
                cbMaHang.Text = nh.MAHANG;
                txtTenHang.Text = nh.TENHANG;
                txtDVT.Text = nh.DVT;
              //  txtTrongluong.Text = nh.TRONGLUONG + "";
               txtGiaNhap.Text = nh.GIANHAP + "";
              //  txtGia.Text = nh.GIANHAP + "";
              //  txtGiaNhapMoi.Text = nh.GIANHAP + "";
                txtGiaBan.Text = nh.GIABAN + "";
                txtSLTon.Text = nh.SOLUONG + "";
                txtThanhTien.Text = nh.GIABAN + "";
             //   dateNgayCapNhat.Value = nh.NGAYCNGIA.Value;
            }
        }

        private void btNhapHang_Click(object sender, EventArgs e)
        {

            string v_masp = this.cbMaHang.Text;
            string v_tenhang = this.txtTenHang.Text;
            string v_dvt = this.txtDVT.Text;
            double v_gianhap = double.Parse(this.txtGiaNhap.Text);
            double v_giaban = double.Parse(this.txtGiaBan.Text);
            double v_soluong = double.Parse(this.txtSLMua.Value+"");
            double v_conlai = double.Parse(this.txtSLTon.Text + "");
            if (v_soluong <= 0)
                MessageBox.Show(this, "Số Lượng Mua >=0.1 !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else if (v_soluong > v_conlai)
                MessageBox.Show(this, "Hàng trong kho không đủ số lượng bán !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                if (Class.C_GioHang.tb == null)
                    Class.C_GioHang.loadGH();
                DataRow myDataRow = Class.C_GioHang.tb.NewRow();
                myDataRow["STT"] = Class.C_GioHang.stt++;
                myDataRow["MAHANG"] = v_masp;
                myDataRow["TENHANG"] = v_tenhang;
                myDataRow["DVT"] = v_dvt;
                myDataRow["SOLUONG"] = v_soluong;
                myDataRow["DGNHAP"] = v_gianhap;
                myDataRow["DGBAN"] = v_giaban;

                double s_gianhap = v_soluong * v_gianhap;
                myDataRow["TONGTIENNHAP"] = s_gianhap;

                double s_giaban = v_soluong * v_giaban;
                myDataRow["TONGTIENBAN"] = s_giaban;

                Class.C_GioHang.tb.Rows.Add(myDataRow);
                Class.C_GioHang._tongtien_ban += s_giaban;
                Class.C_GioHang._tongtien_hang += s_gianhap;

                gridList.DataSource = Class.C_GioHang.tb;
                for (int i = 0; i < gridList.Rows.Count; i++)
                {
                    gridList.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }

                this.txtTongTien.Text = Class.C_GioHang._tongtien_ban + "";
                CLEAR();

            }

        }

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
           // formatSo(txtGia);
        }
      

        private void txtGiaBanMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            NhapSo(sender, e);
        }


        void CLEARHoaDon()
        {
            txtMaHoaDon.Text = Class.C_GioHang.IdentityHoaDon();
            this.txtKhachHang.Text = "";
            this.txtDiaChi.Text = "";
            this.txtDienThoai.Text = "";
            this.txtGhiChu.Text = "";
            this.gridList.DataSource = Class.C_GioHang.tb;

        }
        void CLEAR()
        {
            cbMaHang.Text = "";
            txtTenHang.Text = "";
            txtDVT.Text = "";
            //    txtTrongluong.Text = "";
            //    txtGiaNhap.Text = "";
            //     txtGia.Text = "";
            //    txtGiaNhapMoi.Text = "";
            txtGiaBan.Text = "0";
            txtThanhTien.Text = "0";
            this.txtSLMua.Value = 1;
            this.txtSLTon.Text = "0";
            this.cbMaHang.Focus();
        }
        private void btLammoi_Click(object sender, EventArgs e)
        {
            CLEAR();
        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            
                 string sql = "INSERT INTO HOADON (MAHD, TENKH, DIACHI, SODT, TIENHANG, TIENBAN, GHICHU, NGAYLAP, CREATEBY, CREATEDATE )   VALUES ";
            sql += " ( N'" + txtMaHoaDon.Text + "'";
            sql += " , N'" + txtKhachHang.Text + "'";
            sql += ", N'" + txtDiaChi.Text + "'";
            sql += ", N'" + txtDienThoai.Text + "'";
            sql += "," + Class.C_GioHang._tongtien_hang;
            sql += ", " + Class.C_GioHang._tongtien_ban;
            sql += ", N'" + txtGhiChu.Text + "'";
            sql += ", GETDATE()";
            sql += ", N'aa'";
            sql += ", GETDATE()) ";
            if (Class.LinQConnection.ExecuteCommand_(sql) > 0)
            {

                for (int i = 0; i < gridList.Rows.Count; i++)
                {


                    string g_mahd = txtMaHoaDon.Text;
                    string g_mahang = this.gridList.Rows[i].Cells["gMaHang"].Value + "";
                    string g_tenhang = this.gridList.Rows[i].Cells["hc_tenhang"].Value + "";
                    string g_dvt = this.gridList.Rows[i].Cells["hc_dvt"].Value + "";
                    string g_soluong = this.gridList.Rows[i].Cells["hc_Soluong"].Value + "";

                    double g_gianhap = double.Parse(this.gridList.Rows[i].Cells["hc_gianhap"].Value + "");
                    double g_giaban = double.Parse(this.gridList.Rows[i].Cells["gr_giaban"].Value + "");

                    double s_gianhap = double.Parse(this.gridList.Rows[i].Cells["hc_tongtienban"].Value + "");
                    double s_giaban = double.Parse(this.gridList.Rows[i].Cells["hc_Tongtiennhap"].Value + "");

                    string sql2 = "INSERT INTO CT_HOADON (MAHD, MAHANG, TENHANG, DVT, SOLUONG, DGNHAP, DGBAN, TONGTIENNHAP, TONGTIENBAN, CREATEBY, CREATEDATE)   VALUES ";
                    sql2 += " ( N'" + g_mahd + "'";
                    sql2 += " , N'" + g_mahang + "'";
                    sql2 += ", N'" + g_tenhang + "'";
                    sql2 += ", N'" + g_dvt + "'";
                    sql2 += "," + g_soluong;
                    sql2 += ", " + g_gianhap;
                    sql2 += ", " + g_giaban;
                    sql2 += ", " + s_gianhap;
                    sql2 += ", " + s_giaban;
                    sql2 += ", N'aa'";
                    sql2 += ", GETDATE()) ";

                    Class.LinQConnection.ExecuteCommand_(sql2);
                }

                Class.C_GioHang._tongtien_ban = 0;
                Class.C_GioHang._tongtien_hang = 0;
                this.txtTongTien.Text = "0";
                MessageBox.Show(this, "Thêm mới thông tin thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                Class.C_GioHang.tb = null;
                CLEAR();
                CLEARHoaDon();
                this.txtKhachHang.Focus();
            }
            else
            { MessageBox.Show(this, "Mã hàng đã tồn tại, Vui lòng nhập mã hàng mới ?", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //ADD Chi Tiết
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

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            formatSo(txtTongTien);
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            formatSo(txtGiaBan);
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            NhapSo(sender,e);
        }

        private void txtSLMua_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double slmu = (double)txtSLMua.Value;
                double gia = double.Parse(txtGiaBan.Text.Replace(",", ""));
                this.txtThanhTien.Text = (gia * slmu) + "";
            }
            catch (Exception)
            {

              
            }
           
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            formatSo(txtThanhTien);
        }

     

        private void gridList_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                Class.C_GioHang._tongtien_ban = 0;
                Class.C_GioHang._tongtien_hang = 0;
                for (int i = 0; i < gridList.Rows.Count; i++)
                {
                    gridList.Rows[i].HeaderCell.Value = (i + 1).ToString();

                    double s_giaban = double.Parse(this.gridList.Rows[i].Cells["hc_tongtienban"].Value + "");
                    double s_gianhap = double.Parse(this.gridList.Rows[i].Cells["hc_Tongtiennhap"].Value + "");

                    Class.C_GioHang._tongtien_ban += s_giaban;
                    Class.C_GioHang._tongtien_hang += s_gianhap;

                    this.txtTongTien.Text = Class.C_GioHang._tongtien_ban + "";
                }

            }
            catch (Exception)
            {

            }
        }

        private void txtSLTon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double slDef = double.Parse(ConfigurationManager.AppSettings["mazTon"].ToString());
                double slTOn = double.Parse(this.txtSLTon.Text);
                if (slTOn < slDef)
                {
                    this.txtSLTon.ForeColor = Color.Yellow;
                    this.txtSLTon.BackColor = Color.Red;
                }
                else
                {
                    this.txtSLTon.ForeColor = Color.Blue;
                    this.txtSLTon.BackColor = Color.LightSkyBlue;
                }
            }
            catch (Exception)
            {

            }

        }

    }
}
