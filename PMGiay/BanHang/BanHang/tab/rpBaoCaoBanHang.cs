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
    public partial class rpBaoCaoBanHang : UserControl
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public rpBaoCaoBanHang()
        {
            InitializeComponent();
            ReportLoad();
            
        }
        public void ReportLoad()
        {
            string tungay = Utilities.DateToString.NgayVN(theodoi_tungay.Value.Date);
            string denngay = Utilities.DateToString.NgayVN(theodoi_denngay.Value.Date);

            string sql = " SELECT ROW_NUMBER() OVER (ORDER BY hd.NGAYLAP  DESC) [MODIFYBY], hd.MAHD, MAKH, TENKH, DIACHI, SODT, hd.TONGTIEN, hd.TRACHUHANG, hd.NHAPQUY, GHICHU,  CONVERT(VARCHAR(20),NGAYLAP,103) AS NGAYLAP, hd.CREATEBY, hd.CREATEDATE, hd.MODIFYDATE   ";
            sql += " FROM HOADON hd ";
            sql += " WHERE  CONVERT(DATETIME,hd.NGAYLAP,103) BETWEEN CONVERT(DATETIME,'" + tungay + "',103) AND CONVERT(DATETIME,'" + denngay + "',103) ";
            sql += " ORDER BY hd.NGAYLAP ASC";

            DataTable bang = DAL.LinQConnection.getDataTable(sql);
            this.reportViewer1.LocalReport.DataSources.Clear();

            ReportParameter p1 = new ReportParameter("tungay", tungay);
            ReportParameter p2 = new ReportParameter("denngay", denngay);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dsHoaDon", bang));

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

        }
    }
}