using BanHangThep.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangThep.Class
{
    static class C_GioHang
    {
        public static DataTable tb;
        public static double _tongtien_hang;
        public static double _tongtien_ban;
        public static int stt;
        public static void loadGH()
        {
            _tongtien_hang = 0;
            _tongtien_ban = 0;
            stt = 1;
            tb = new DataTable("GIOHANG");
            tb.Columns.Add("STT", typeof(int));
            tb.Columns.Add("MAHANG", typeof(string));
            tb.Columns.Add("TENHANG", typeof(string));
            tb.Columns.Add("DVT", typeof(string));
            tb.Columns.Add("SOLUONG", typeof(float));
            tb.Columns.Add("DGNHAP", typeof(float));
            tb.Columns.Add("DGBAN", typeof(float));
            tb.Columns.Add("TONGTIENNHAP", typeof(double));
            tb.Columns.Add("TONGTIENBAN", typeof(double));
          
        }

        public static string IdentityHoaDon()
        {
            string year = DateTime.Now.Year.ToString().Substring(2);
            string month = "01";
            if (DateTime.Now.Month < 10)
            {
                month = "0" + DateTime.Now.Month.ToString();
            }
            else
                month = DateTime.Now.Month.ToString();
            string kytumacdinh = year + month;
            year = year + month;
            string id = kytumacdinh + "0001";
            try
            {

                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
                BHTHepDataContext db = new BHTHepDataContext();
                db.Connection.Open();

                string sql = " SELECT MAX(MAHD) as 'MAHD' FROM HOADON  ORDER BY MAHD DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table != null && table.Rows.Count > 0)
                {
                    if (table.Rows[0][0].ToString().Trim().Substring(0, 4).Equals(year))
                    {
                        int number = 1;
                        id = obj.ID(year, table.Rows[0][0].ToString().Trim(), "0000", number) + "";
                    }
                    else
                    {
                        id = obj.ID(year, year + "0000", "0000") + "";
                    }
                }
                else
                {
                    id = obj.ID(year, year + "0000", "0000") + "";
                }

                db.Connection.Close();
            }
            catch (Exception)
            {

            }

            return id;

        }

    }
}
