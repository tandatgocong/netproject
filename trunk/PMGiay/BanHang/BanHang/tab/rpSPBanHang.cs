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
using Microsoft.Reporting.WinForms;

namespace BanHang.tab
{
    public partial class rpSPBanHang : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public rpSPBanHang()
        {
            InitializeComponent();
            ReportLoad();
            
        }
        public void ReportLoad()
        {
            string tungay = Utilities.DateToString.NgayVN(theodoi_tungay.Value.Date);
            string denngay = Utilities.DateToString.NgayVN(theodoi_denngay.Value.Date);

            string sql = " SELECT  ROW_NUMBER() OVER (ORDER BY ct.CREATEDATE  ASC) [MODIFYBY] , mn.CHUHANG,ct.MAHD, ct.MANHAP, ct.MAHANG, ct.TENHANG, ct.SIZE, ct.SOLUONG, ct.DONGIA, ct.TONGTIEN, ct.TRACHUHANG, ct.NHAPQUY,CONVERT(varchar(10),ct.CREATEDATE,103) as CREATEDATE ";
            sql += " FROM CT_HOADON ct, NHAP_HANG mn ";
            sql += " WHERE mn.MANHAP=ct.MANHAP AND  CONVERT(DATETIME,ct.CREATEDATE,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
            if(!"".Equals(this.txtMaCH.Text.Replace(" ","")))
                sql += " AND CHUHANG='" + this.txtMaCH.Text + "'";
            sql += " ORDER BY ct.CREATEDATE  ASC";

            DataTable bang = DAL.LinQConnection.getDataTable(sql);
            this.reportViewer1.LocalReport.DataSources.Clear();

            ReportParameter p1 = new ReportParameter("tungay", tungay);
            ReportParameter p2 = new ReportParameter("denngay", denngay);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ds_CTHD", bang));

            this.reportViewer1.RefreshReport();
        }


        private void theodoi_denngay_ValueChanged(object sender, EventArgs e)
        {
            ReportLoad();
        }

        private void theodoi_tungay_ValueChanged(object sender, EventArgs e)
        {
            ReportLoad();
        }

        private void txtMaCH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                ReportLoad();
            }
        }
    }
}