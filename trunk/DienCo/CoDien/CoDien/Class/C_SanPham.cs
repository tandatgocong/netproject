using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoDien.DB;
using System.Data;

namespace CoDien.Class
{
    public class C_SanPham
    {
        static log4net.ILog logger = log4net.LogManager.GetLogger("File");
        static DIENCODataContext database = new DIENCODataContext();
        public static List<LOAISANPHAM> GetLoaiSanPham()
        {
            var query = from q in database.LOAISANPHAMs select q;
            return query.ToList();
        }
        public static SANPHAM findSanPhamById(int spID)
        {
            var query = from q in database.SANPHAMs where q.MASP==spID select q;
            return query.SingleOrDefault();
        }
        public static List<HIEUSANPHAM> GetHieuSanPham()
        {
            var query = from q in database.HIEUSANPHAMs select q;
            return query.ToList();
        }
        public static bool InsertSanPham(SANPHAM sp)
        {
            try
            {
                database.SANPHAMs.InsertOnSubmit(sp);
                database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Add SANPHAMs : " + ex.Message);
            }
            return false;
        }
        public static DataTable getSANPHAM()
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY MASP  DESC) [STT],*  FROM  SANPHAM ORDER BY CREATEDATE DESC ";
            return LinQConnection.getDataTable(sql);
        }
        public static DataTable search(string maloai, string mahieu, string tensp)
        {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY MASP  DESC) [STT],*  FROM  SANPHAM WHERE MALOAI='" + maloai + "' AND MAHIEU='" + mahieu + "'";
            if (!"".Equals(tensp))
            {
                sql += " AND TENSP LIKE '%" + tensp + "%'";
            }
            sql += " ORDER BY CREATEDATE DESC ";
            return LinQConnection.getDataTable(sql);
        }
        public static int DeleteSP(string masp)
        {
            try
            {
                return LinQConnection.ExecuteCommand("DELETE FROM SANPHAM WHERE MASP='" + masp + "'");
            }
            catch (Exception ex)
            {
                logger.Error("Add SANPHAMs : " + ex.Message);
            }
            return 0;
        }

        public static int UpdateSanPham(string masp, string spMoi, string spBanChay)
        {
            try
            {
                return LinQConnection.ExecuteCommand("UPDATE  SANPHAM SET SAPMOI='" + spMoi + "',BANCHAY='" + spBanChay + "' WHERE MASP='" + masp + "'");
            }
            catch (Exception ex)
            {
                logger.Error("Add News : " + ex.Message);
            }
            return 0;
        }

        public static SANPHAM getSanPham(int masp)
        {
            var query = from q in database.SANPHAMs where q.MASP == masp select q;
            return query.SingleOrDefault();
        }
      
        public static bool UpdateSanPham()
        {
            try
            {
                database.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Add SANPHAMs : " + ex.Message);
            }
            return false;
        }
    }
}
