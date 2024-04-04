using RAiso.Factory;
using RAiso.Model;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Handler
{
    public class UserHandler
    {
        public static String HandleLogin(String name, String password)
        {
            MsUser user = UserRepository.GetUser(name, password);
            return user != null ? "Success" : "Username or Password is incorrect";
        }
        public static String HandleRegister(String name)
        {
            MsUser user = UserRepository.GetUserByName(name);
            return user == null ? "Success" : "Username already exists";
        }
        private static int GenerateID()
        {
            int id = 0;
            MsUser user = UserRepository.GetLastUser();
            if(user == null)
            {
                id = 1;
            }
            else
            {
                id = user.UserId;
                id++;
            }
            return id;
        }
        public static void HandleInsert(String name, DateTime dob, String gender, String address, String password, String phone)
        {
            MsUser user = UserFactory.CreateUser(GenerateID(), name, dob, gender, address, password, phone, "Customer");
            UserRepository.InsertUser(user);
        }
        public static String GetRole(String Id)
        {
            MsUser user = UserRepository.GetUserById(Id);
            return user.UserRole;
        }
        public static MsUser GetUserByName(String name)
        {
            MsUser user = UserRepository.GetUserByName(name);
            return user;
        }
        public static MsUser GetUserById(String Id)
        {
            MsUser user = UserRepository.GetUserById(Id);
            return user;
        }
        public static String HandleUpdate(String name, String nameFirst)
        {
            MsUser user = UserRepository.GetUserByName(name);
            if (name.Equals(nameFirst)) return "Success";
            else return user == null ? "Success" : "Username already exists";
        }
        public static void UpdateUser(String name, DateTime dob, String gender, String address, String password, String phone, int Id)
        {
            UserRepository.UpdateUser(name, dob, gender, address, password, phone, Id);
        }
    }
}