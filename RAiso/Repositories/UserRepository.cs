using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repositories
{
    public class UserRepository
    {
        private static LocalDatabaseEntities db = DBSingleton.GetInstance();

        public static void AddUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public static MsUser GetLastUser()
        {
            return db.MsUsers.ToList().LastOrDefault();
        }

        public static String GetUsername(string name)
        {
            var username = (from x in db.MsUsers where x.UserName == name select x.UserName).FirstOrDefault();

            if (username != null) return username.ToString();
            else return null;
        }

        public static MsUser GetUserByName(string name)
        {
            return (from x in db.MsUsers where x.UserName.Equals(name) select x).FirstOrDefault();
        }

        public static MsUser GetUserCredentials(string username, string password)
        {
            return (from x in db.MsUsers where x.UserName == username && x.UserPassword == password select x).FirstOrDefault();
        }

        public static MsUser GetUserById(int id)
        {
            return (from x in db.MsUsers where x.UserID == id select x).FirstOrDefault();
        }

        public static void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}