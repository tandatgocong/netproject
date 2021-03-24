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
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
            formload();
        }
        void formload()
        {
            gridList.DataSource = Class.LinQConnection.getDataTable("SELECT [STT] ,[MAHANG] ,[TENHANG] ,[DVT] ,[SOLUONG] ,[GIANHAP] ,[GIABAN] ,[NGAYCNGIA] ,[TRONGLUONG] ,[GHICHU] FROM NHAP_HANG");
        }
    }
}
