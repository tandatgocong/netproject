using BanHangThep.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHangThep.Class
{
    class C_USERS
    {
        public static string _fullName = null;
        public static string _userName = null;
        public static string _roles = null;
        public static string _maphong = null;
        public static string _maquyen = null;
        public bool AddNew(USER user)
        {
            try
            {
                BHTHepDataContext db = new BHTHepDataContext();
                db.USERs.InsertOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        public bool DeleteUser(USER user)
        {
            try
            {
                BHTHepDataContext db = new BHTHepDataContext();
                db.USERs.DeleteOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            { }
            return false;
        }

        public bool UserLogin(string userName, string passWord)
        {
            BHTHepDataContext db = new BHTHepDataContext();
            var data = from user in db.USERs where user.USERNAME == userName && user.PASSWORD == passWord && user.ENABLED == true select user;
            USER userLogin = data.SingleOrDefault();
            if (userLogin != null)
            {
                USER userlogin = (USER)data.SingleOrDefault();
                _userName = userlogin.USERNAME;
                _fullName = userlogin.FULLNAME;
                _roles = userlogin.ROLEID;
                return true;
            }
            return false;
        }

        public static int ChangePass(string username, string passold, string passNew)
        {
            BHTHepDataContext db = new BHTHepDataContext();
            var data = from user in db.USERs where user.USERNAME == username select user;
            USER u = data.SingleOrDefault();
            if (passold.Equals(passold) == true)
            {
                try
                {
                    u.PASSWORD = passNew;
                    db.SubmitChanges();
                    return 1;
                }
                catch (Exception)
                {

                }
                return 0;
            }
            return -1;

        }

    }
}
