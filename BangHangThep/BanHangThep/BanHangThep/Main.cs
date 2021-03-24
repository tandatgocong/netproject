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
            // frm_LayDuLieuGanMoi_Ky baothay = new frm_LayDuLieuGanMoi_Ky();
            UCT_BanHang baothay = new UCT_BanHang();
            baothay.Height = PanelContent.Size.Height - 300;
            baothay.Width = PanelContent.Size.Width - 300;
            //baothay.Height = PanelContent.Size.Height - 5;
            //baothay.Width = PanelContent.Size.Width - 5;
            PanelContent.Controls.Add(baothay);
        }
    }
}
