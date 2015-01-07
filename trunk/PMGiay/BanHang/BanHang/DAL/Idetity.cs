using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BanHang.Database;
using System.Data;

namespace BanHang.DAL
{
    class Idetity
    {
        public static string IdentityBienNhan()
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
            string id = kytumacdinh + "0000";
            try
            {

                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
                qlBangHangDataContext db = new qlBangHangDataContext();
                db.Connection.Open();

                string sql = " SELECT MAX(MAHANG) as 'MAHANG' FROM NHAP_HANG  ORDER BY MAHANG DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
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
                qlBangHangDataContext db = new qlBangHangDataContext();
                db.Connection.Open();

                string sql = " SELECT MAX(MAHD) as 'MAHD' FROM HOADON  ORDER BY MAHD DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if ( table !=null && table.Rows.Count > 0)
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


        public static string IdentityChuHang()
        {
            string year = DateTime.Now.Year.ToString().Substring(2);
            string kytumacdinh = year + "CH";
            string id = kytumacdinh + "0001";
            try
            {

                String_Indentity.String_Indentity obj = new String_Indentity.String_Indentity();
                qlBangHangDataContext db = new qlBangHangDataContext();
                db.Connection.Open();

                string sql = " SELECT MAX(CHUHANG) as 'CHUHANG' FROM NHAP_HANG WHERE CHUHANG LIKE '%CH%'  ORDER BY CHUHANG DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    if (table.Rows[0][0].ToString().Trim().Substring(0, 2).Equals(year))
                    {
                        int number = 1;
                        id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000", number) + "";
                    }
                    else
                    {
                        id = obj.ID(year + "CH", year + "CH" + "0000", "0000") + "";
                    }
                }
                else
                {
                    id = obj.ID(kytumacdinh, table.Rows[0][0].ToString().Trim(), "0000") + "";
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
