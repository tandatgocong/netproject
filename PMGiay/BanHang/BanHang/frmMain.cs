using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BanHang.tab;

namespace BanHang
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            DAL.C_GioHang.loadGH();
            Roles(false);
        }

        public static frm_Login dn = new frm_Login();
        public void dangnhap()
        {
            dn.ShowDialog();
            if (DAL.C_USERS._roles != null)
            {
                role(DAL.C_USERS._roles);
            }

        }
        public void Roles(bool b)
        {

            ribbonBanHang.Visible = b;
            ribbonThuChi.Visible = b;
            ribbonBar6.Visible = b;

        }

        public void role(string role)
        {
            Roles(false);
            if ("AD".Equals(DAL.C_USERS._roles.Trim()))
            {
                ribbonBanHang.Visible = true;
                ribbonThuChi.Visible = true;
                ribbonBar6.Visible = true;
            }
            else if ("BH".Equals(DAL.C_USERS._roles.Trim()))
            {
                ribbonThuChi.Visible = false;
                ribbonBar6.Visible = false;
                ribbonBanHang.Visible = true;
            }

        }

        private void btNhapHang_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(new tbNhapHang());

        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(new tbChuHang());
        }

        private void btSanPham_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(new tbSanPham());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Show();
            dangnhap();
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            Roles(false);

        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            dangnhap();
        }

        private void buttonItem19_Click_1(object sender, EventArgs e)
        {
            frm_ChangePassword chang = new frm_ChangePassword();
            chang.ShowDialog();
        }

        private void btTienQuy_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(new tbqlQuy());
        }

        private void btThuChi_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(new tbqlQuyThuChi());
        }

        private void btQuanLyBH_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(new tbqlQuyNhapHang1());
        }

        private void btBanHang_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(new rpBaoCaoBanHang());
        }

        

        private void btBCNhapHang_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(new rpBaoCaoNhapHang());
        }

        private void btXuatHang_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(new tbXuatHang());
            
        }

        private void btspban_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(new rpSPBanHang());
            
        }

        private void ribbonControl2_Click(object sender, EventArgs e)
        {

        }

        //private void panelMain_Paint(object sender, PaintEventArgs e)
        //{
        //    this.panelMain.Controls.Clear();
        //    this.panelMain.Controls.Add(new tbXuatHang());
        //}
    }
}