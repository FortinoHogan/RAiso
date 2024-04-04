using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Repository
{
    public class UserRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static MsUser GetUser(String name, String password) 
        {
            return (from u in db.MsUsers 
                    where u.UserName == name 
                    && u.UserPassword == password
                    select u).FirstOrDefault();
        }
        public static MsUser GetUserByName(String name)
        {
            return (from u in db.MsUsers
                    where u.UserName == name
                    select u).FirstOrDefault();
        }
        public static MsUser GetUserById(String Id)
        {
            int id = Convert.ToInt32(Id);
            return (from u in db.MsUsers
                    where u.UserId == id
                    select u).FirstOrDefault();
        }
        public static MsUser GetLastUser()
        {
            return (from u in db.MsUsers
                    select u).ToList().LastOrDefault();
        }
        public static void InsertUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }
        public static void UpdateUser(String name, DateTime dob, String gender, String address, String password, String phone, int Id)
        {
            MsUser user = db.MsUsers.Find(Id);
            user.UserName = name;
            user.UserDOB = dob;
            user.UserGender = gender;
            user.UserAddress = address;
            user.UserPassword = password;
            user.UserPhone = phone;
            db.SaveChanges();
        }
    }
}