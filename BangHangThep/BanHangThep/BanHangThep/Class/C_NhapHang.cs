using BanHangThep.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangThep.Class
{
    class C_NhapHang
    {
        static BHTHepDataContext db = new BHTHepDataContext();
        public static List<NHAP_HANG> getListNhapHang()
        {
            try
            {
                var query = from dottc in db.NHAP_HANGs orderby dottc.MAHANG descending select dottc;
                return query.ToList();
            }
            catch (Exception ex)
            {
              //  log.Error(ex.Message);
            }
            return null;
        }
        public static NHAP_HANG findbyMaHang(string shs)
        {
            try
            {
                var query = from q in db.NHAP_HANGs where q.MAHANG == shs select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                //log.Error("" + ex.Message);
            }
            return null;
        }

    }
}
