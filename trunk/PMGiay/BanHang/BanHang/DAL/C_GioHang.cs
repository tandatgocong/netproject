using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BanHang.DAL
{
    static class C_GioHang
    {
        public static DataTable tb;
        public static int _soluong;
        public static decimal _tongtien;
        public static decimal _trachuhang;
        public static decimal _nhapquy;

        public static void loadGH()
        {
            _soluong = 0;
            _tongtien = 0;
            _trachuhang = 0;
            _nhapquy = 0;

            tb = new DataTable("GIOHANG");
            tb.Columns.Add("MANHAP", typeof(string));
            tb.Columns.Add("MAHANG", typeof(string));
            tb.Columns.Add("TENHANG", typeof(string));
            tb.Columns.Add("SIZE", typeof(string));
            tb.Columns.Add("SOLUONG", typeof(int));
            tb.Columns.Add("DONGIA", typeof(float));
            tb.Columns.Add("THANHTIEN", typeof(decimal));
            tb.Columns.Add("TRACHUHANG", typeof(decimal));
            tb.Columns.Add("NHAPQUY", typeof(decimal));

        }
    }
}
