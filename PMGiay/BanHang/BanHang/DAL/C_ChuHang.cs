using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHang.Database;
using log4net;

namespace BanHang.DAL
{
    class C_ChuHang
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_ChuHang).Name);
        
        static qlBangHangDataContext db = new qlBangHangDataContext();
        
        public static List<CHUHANG> getList()
        {
            var query = from duong in db.CHUHANGs select duong;
            return query.ToList();
        }

        public static CHUHANG findbyChuHang(string mach)
        {
            var query = from duong in db.CHUHANGs where duong.MACHUHANG == mach select duong;
            return query.SingleOrDefault();
        }
        public static bool Insert(CHUHANG duong)
        {
            try
            {
                db.CHUHANGs.InsertOnSubmit(duong);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Them Ten chu hang Loi " + ex.Message);
            }
            return false;
        }
        public static bool Update()
        {
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }
        public static bool Delete(CHUHANG dh)
        {
            try
            {
                db.CHUHANGs.DeleteOnSubmit(dh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }

        

    }
}
