using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanHang.Database;
using log4net;

namespace BanHang.DAL
{
    class C_QLQuy
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(C_ChuHang).Name);

        static qlBangHangDataContext db = new qlBangHangDataContext();

        public static TIENQUY getQuy()
        {
            var query = from duong in db.TIENQUYs select duong;
            return query.SingleOrDefault();
        }

        public static void NhapXuatQuy(decimal sotien, string ghichu)
        {
            try
            {
                TIENQUY tq = getQuy();
                decimal dutruoc = tq.TONGSOTIEN.Value;
                NHATKY_TIENQUY nk = new NHATKY_TIENQUY();
                nk.DUTRUOC = dutruoc;
                nk.NGAYDU = tq.NGAYNHAP;
                nk.TIENNHAP = sotien;
                nk.QUYNHAP = dutruoc + sotien;
                nk.GHICHU = ghichu;
                nk.NGAYNHAP= DateTime.Now;
                nk.CREATEBY = DAL.C_USERS._userName;
                nk.CREATEDATE = DateTime.Now.Date;
                decimal  tt = dutruoc + sotien;
                DAL.LinQConnection.ExecuteCommand("UPDATE TIENQUY SET TONGSOTIEN=" + tt + " ,NGAYNHAP=getDate() ");
                db.NHATKY_TIENQUYs.InsertOnSubmit(nk);
                db.SubmitChanges();
               
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }

        }
    }
}
