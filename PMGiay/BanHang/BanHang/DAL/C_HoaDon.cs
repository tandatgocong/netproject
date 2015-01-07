using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using BanHang.Database;

namespace BanHang.DAL
{
    class C_HoaDon
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_HoaDon).Name);

        static qlBangHangDataContext db = new qlBangHangDataContext();

        public static List<HOADON> getList()
        {
            var query = from duong in db.HOADONs select duong;
            return query.ToList();
        }

        public static HOADON findbyChuHang(string mach)
        {
            var query = from duong in db.HOADONs where duong.MAHD == mach select duong;
            return query.SingleOrDefault();
        }
        public static bool Insert(HOADON duong)
        {
            try
            {
                db.HOADONs.InsertOnSubmit(duong);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Them Hoa don  Loi " + ex.Message);
            }
            return false;
        }

        public static bool InsertCT(CT_HOADON duong)
        {
            try
            {
                db.CT_HOADONs.InsertOnSubmit(duong);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error("Them Hoa don  Loi " + ex.Message);
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
        public static bool Delete(HOADON dh)
        {
            try
            {
                db.HOADONs.DeleteOnSubmit(dh);
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
