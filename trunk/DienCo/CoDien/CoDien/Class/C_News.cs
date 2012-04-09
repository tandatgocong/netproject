using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoDien.DB;
using System.Data;

namespace CoDien.Class
{
    public class C_News
    {
        static log4net.ILog logger = log4net.LogManager.GetLogger("File");
        static DIENCODataContext db = new DIENCODataContext();
        public static NEW getNewsByID(int Id)
        {
            try
            {
                var query = from q in db.NEWs where q.NEWSID == Id select q;
                return query.SingleOrDefault();
            }
            catch (Exception ex)
            {
                logger.Error("Get News : " + ex.Message);
            }
            return null;
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
                logger.Error("Load Page : " + ex.Message);
            }
            return false;


        }
        public static DataTable getNews(string title) {
            string sql = "SELECT ROW_NUMBER() OVER (ORDER BY NEWSID  DESC) [STT],NEWSID,NEWSTILE,NEWIMG,NEWSDICRIPTION,NEWSCONTENT,CONVERT(VARCHAR(20),CREATEDATE,103) AS 'CREATEDATE' FROM  NEWS ORDER BY NEWSID DESC";
            if (!"".Equals(title))
            {
                sql = "SELECT ROW_NUMBER() OVER (ORDER BY NEWSID  DESC) [STT],NEWSID,NEWSTILE,NEWIMG,NEWSDICRIPTION,NEWSCONTENT,CONVERT(VARCHAR(20),CREATEDATE,103) AS 'CREATEDATE' FROM  NEWS WHERE NEWSTILE LIKE N'%" + title + "%' ORDER BY NEWSID DESC";
            }
            return LinQConnection.getDataTable(sql);
        }
        public static bool InsertNews(NEW news){
         try
            {
                db.NEWs.InsertOnSubmit(news);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Add News : " + ex.Message);
            }
            return false;
        }
        public static int DeleteNews(string newsid)
        {
            try
            {
              return  LinQConnection.ExecuteCommand("DELETE FROM NEWS WHERE NEWSID='" + newsid + "'");
            }
            catch (Exception ex)
            {
                logger.Error("Add News : " + ex.Message);
            }
            return 0;
        }

    }
}