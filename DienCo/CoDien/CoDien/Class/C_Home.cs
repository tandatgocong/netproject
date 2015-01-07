using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace CoDien.Class
{
    public class C_Home
    {
        public static DataTable getSANPHAM_BANCHAY()
        {
            string sql = "SELECT TOP(20) *  FROM  SANPHAM WHERE BANCHAY='1' ORDER BY CREATEDATE DESC ";
            return LinQConnection.getDataTable(sql);
        }
        public static DataTable getSANPHAM_MOI()
        {
            string sql = "SELECT TOP(20) *  FROM  SANPHAM WHERE SAPMOI='1' ORDER BY CREATEDATE DESC";
            return LinQConnection.getDataTable(sql);
        }

        public static DataTable getSANPHAM(string page, string type)
        {
            string sql = "SELECT  *  FROM  SANPHAM  ORDER BY SAPMOI DESC";
            if (page != null && type == null)
            {
                sql = "SELECT  *  FROM  SANPHAM WHERE MALOAI='"+page+"'  ORDER BY SAPMOI DESC";
            }
            else if (page != null && type != null)
            {
                sql = "SELECT  *  FROM  SANPHAM WHERE MALOAI='" + page + "' AND MAHIEU='"+type+"'  ORDER BY SAPMOI DESC";
            }
            return LinQConnection.getDataTable(sql);
        }
        public static DataTable SearchSP( string search)
        {
            string sql = "SELECT  *  FROM  SANPHAM  WHERE TENSP LIKE '%"+search+"%' ORDER BY SAPMOI DESC";
            return LinQConnection.getDataTable(sql);
        }
    }
}