using BanHang.GUI;
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
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btBanHang_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            UCT_BanHang baothay = new UCT_BanHang();
            baothay.Height = PanelContent.Size.Height;
            baothay.Width = PanelContent.Size.Width;
            PanelContent.Controls.Add(baothay);
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
