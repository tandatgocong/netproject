using BanHangThep.Class;
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
    public partial class frm_Login : Form
    {
        static public string username = "";
        static public int result = 0;
        static public string fullName = "";
        public frm_Login()
        {
            InitializeComponent();
        }

        public void DangNhap()
        {
            string udi = this.txtuserName.Text;
            string pass = this.txtPass.Text;


            if (udi == "")
            {
                errorProvider1.SetError(txtuserName, "Nhập Tên Đăng Nhập !");
                return;
            }
            else
            {
                errorProvider1.Clear();
            }
            C_USERS users = new C_USERS();
            if (users.UserLogin(udi, pass))
            {
                this.lbFail.Visible = false;
                this.Close();
            }
            else
            {
                this.lbFail.ForeColor = Color.Red;
                this.lbFail.Visible = true;
            }

        }
        private void bt_Login_Click(object sender, EventArgs e)
        {
            DangNhap();
        }


        private void bt_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtuserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { DangNhap(); }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { DangNhap(); }
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {

        }

    }
}
