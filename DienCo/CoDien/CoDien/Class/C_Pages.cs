using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using CoDien.DB;
using System.Data;

namespace CoDien.Class
{
    public class C_Pages
    {
        static log4net.ILog logger = log4net.LogManager.GetLogger("File");
        static DIENCODataContext db = new DIENCODataContext();
        public static PAGE getPage(string pageID) {
            try
            {
                var query = from q in db.PAGEs where q.MAPAGES == pageID select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Error("Load Page : " + ex.Message);
            }
            return null;
        }
        public static bool Update() {
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Load Page : " + ex.Message);
            }
            return false;


        }

    }
}