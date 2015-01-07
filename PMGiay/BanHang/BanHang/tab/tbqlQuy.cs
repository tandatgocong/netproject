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
    public partial class tbqlQuy : UserControl
    {
        public tbqlQuy()
        {
            InitializeComponent();
            LoadQuy();
            cbNhapXuat.SelectedIndex = 0;
        }
        public void LoadQuy()
        {
            dataTienQuy.DataSource = DAL.LinQConnection.getDataTable("SELECT TONGSOTIEN, CONVERT(VARCHAR(20),NGAYNHAP,103) as NGAYNHAP FROM TIENQUY");
            string sql = "SELECT TOP(1000)  DUTRUOC,CONVERT(VARCHAR(20),NGAYDU,103) AS NGAYDU, TIENNHAP, QUYNHAP, GHICHU, CONVERT(VARCHAR(20),NGAYNHAP,103) AS NGAYNHAP_ ";
            sql += " FROM NHATKY_TIENQUY ";
            sql += " ORDER BY NGAYNHAP DESC";
            girdNhapHang.DataSource = DAL.LinQConnection.getDataTable(sql);

        }

        private void btThemMoi_Click(object sender, EventArgs e)
        {
            if (cbNhapXuat.SelectedIndex == 0)
                DAL.C_QLQuy.NhapXuatQuy(decimal.Parse(this.txtGiaBan.Text), this.txtGhiChu.Text);
            else
                DAL.C_QLQuy.NhapXuatQuy(-decimal.Parse(this.txtGiaBan.Text), this.txtGhiChu.Text);

            this.txtGhiChu.Text = "";
            this.txtGiaBan.Text = "";
            txtGiaBan.Focus();
            LoadQuy();
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

    }
}