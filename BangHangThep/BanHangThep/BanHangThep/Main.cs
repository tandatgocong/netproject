using BanHangThep.GUI;
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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            Roles(false);
        }

        public static frm_Login dn = new frm_Login();
        public void dangnhap()
        {
            dn.ShowDialog();
            if (Class.C_USERS._roles != null)
            {
                role(Class.C_USERS._roles);
            }

        }
        public void Roles(bool b)
        {

            btNhapHang.Visible = b;
            btBanHang.Visible = b;
            btBaoCao.Visible = b;
            btThongKe.Visible = b;
        }

        public void role(string role)
        {
            Roles(false);
            if ("AD".Equals(Class.C_USERS._roles.Trim()))
            {
                btNhapHang.Visible = true;
                btBanHang.Visible = true;
                btBaoCao.Visible = true;
                btThongKe.Visible = true;
            }
            else if ("BH".Equals(Class.C_USERS._roles.Trim()))
            {
                btNhapHang.Visible = true;
                btBanHang.Visible = true;
                btBaoCao.Visible = true;
                btThongKe.Visible = true;
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
                dangnhap();
        }

        private void btBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang f = new frmBanHang();
            f.ShowDialog();
        }

        private void btNhapHang_Click(object sender, EventArgs e)
        {
            //PanelContent.Controls.Clear();
            //UCT_NhapHang baothay = new UCT_NhapHang();
            //baothay.Height = PanelContent.Size.Height;
            //baothay.Width = PanelContent.Size.Width;
            //PanelContent.Controls.Add(baothay);
            frmNhapHang f = new frmNhapHang();
            f.ShowDialog();
        }
    }
}
