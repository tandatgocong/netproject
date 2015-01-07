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
    public partial class tbChuHang : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public tbChuHang()
        {
            InitializeComponent();

            _Load();
        }

        public void _Load()
        {
            string sql = "SELECT MACHUHANG, TENKH, DIACHI, SODT, SOTK, NGANHANG ";
            sql += " FROM CHUHANG ORDER BY CREATEDATE ASC ";

            girdNhapHang.DataSource = DAL.LinQConnection.getDataTable(sql);

        }
        private void btThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                CHUHANG ch = DAL.C_ChuHang.findbyChuHang(this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["machuhang"].Value + "");
                if (ch != null)
                {
                    
                    ch.MACHUHANG = this.txtChuHang.Text;
                    ch.TENKH = this.txtHoTen.Text;
                    ch.DIACHI = this.txtDiaChi.Text;
                    ch.SODT = this.txtSDT.Text;
                    ch.SOTK = this.txtSoTK.Text;
                    ch.NGANHANG = this.txtNganHang.Text;
                    ch.MODIFYBY = Environment.UserName;
                    ch.MODIFYDATE = DateTime.Now;

                    if (DAL.C_ChuHang.Update())
                        MessageBox.Show(this, "Cập Nhật Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(this, "Cập Nhật Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _Load();
                }

            }
            catch (Exception)
            {

                MessageBox.Show(this, "Nhập Hàng Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btLamLai_Click(object sender, EventArgs e)
        {
            txtChuHang.Text = "";
            txtHoTen.Text = "";
            txtNganHang.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtSoTK.Text = "";
        }

        private void girdNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtChuHang.Text = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["machuhang"].Value + "";
            this.txtHoTen.Text = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["hoten"].Value + "";
            this.txtDiaChi.Text = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["diachi"].Value + "";
            this.txtSDT.Text = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["sodt"].Value + "";
            this.txtSoTK.Text = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["sotk"].Value + "";
            this.txtNganHang.Text = this.girdNhapHang.Rows[girdNhapHang.CurrentRow.Index].Cells["nganhang"].Value + "";
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
               CHUHANG ch = DAL.C_ChuHang.findbyChuHang(this.txtChuHang.Text.Replace(" ", ""));
               if (ch != null)
               {
                   if (MessageBox.Show(this, "Xóa Thông Tin Chủ Hàng ?", "..: Thông Báo :..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                   {
                       DAL.C_ChuHang.Delete(ch);
                       MessageBox.Show(this, "Xóa Thông Tin  Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       _Load();
                   }

               }
        }

        private void buttonX1_Click(object sender, EventArgs e)
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
                if (DAL.C_ChuHang.Insert(ch))
                    MessageBox.Show(this, "Cập Nhật Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(this, "Cập Nhật Không Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Load();
            }
        }
    }
}