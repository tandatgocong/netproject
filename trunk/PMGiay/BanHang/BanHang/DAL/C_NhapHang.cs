using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHang.Database;
using log4net;

namespace BanHang.DAL
{
    class C_NhapHang
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_NhapHang).Name);

        static qlBangHangDataContext db = new qlBangHangDataContext();

        public static List<NHAP_HANG> getList()
        {
            var query = from nh in db.NHAP_HANGs where nh.SLBAN != nh.SLNHAP select nh;
            return query.ToList();
        }

        public static bool Insert(NHAP_HANG tb)
        {
            try
            {
                db.NHAP_HANGs.InsertOnSubmit(tb);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
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
        

        //public static void UpdateBaoThay(string danhbo, string result)
        //{
        //    try
        //    {
        //        string sql = "UPDATE NHAP_HANG SET BAOTHAY='" + result + "',  MODIFYBY='" + DAL.SYS.C_USERS._userName + "', MODIFYDATE='" + DateTime.Now + "' WHERE DANHBO='" + danhbo + "' ";
        //        DAL.LinQConnection.ExecuteCommand(sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //}

        public static bool Delete(NHAP_HANG dh)
        {
            try
            {
                db.NHAP_HANGs.DeleteOnSubmit(dh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return false;
        }
        public static NHAP_HANG finByMaNhap(int ma)
        {
            try
            {
                db = new qlBangHangDataContext();
                var query = from q in db.NHAP_HANGs where q.MANHAP == ma select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        //public static NHAP_HANG finByLoTrinh(string lotrinh)
        //{
        //    try
        //    {
        //        var query = from q in db.NHAP_HANGs where q.LOTRINH == lotrinh select q;
        //        return query.SingleOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //    return null;
        //}

        
        

        //public static List<NHAP_HANG> getAllKHACHHANG()
        //{
        //    var query = from q in db.NHAP_HANGs select q;
        //    return query.ToList();
        //}
       

    }
}
