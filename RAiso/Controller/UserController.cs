using RAiso.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RAiso.Controller
{
    public class UserController
    {
        public static String CheckUsername(String name)
        {
            String res = "";
            if (name.Equals("")) res = "Username must be filled";
            return res;
        }
        public static String CheckPassword(String password)
        {
            String res = "";
            if (password.Equals("")) res = "Password must be filled";
            return res;
        }
        public static String ValidateLogin(String name, String password) 
        {
            String res = CheckUsername(name);
            if(res.Equals("")) res = CheckPassword(password);
            if(res.Equals("")) res = UserHandler.HandleLogin(name, password);
            return res;
        }
        public static String CheckUsernameRegister(String name)
        {
            String res = "";
            if (name.Equals("")) res = "Username must be filled";
            else if (name.Length < 5 || name.Length > 50) res = "Username must 5 and 50 characters";
            return res;
        }
        public static String CheckDOB(String dob)
        {
            String res = "";
            if (dob.Equals("")) res = "Date of Birth must be filled";
            else if ((DateTime.Now - DateTime.Parse(dob)).TotalDays < 365) res = "Must be at least 1 year age";
            return res;
        }
        public static String CheckGender(String gender)
        {
            String res = "";
            if (gender.Equals("")) res = "Gender must be selected";
            return res;
        }
        public static String CheckAddress(String address)
        {
            String res = "";
            if (address.Equals("")) res = "Address must be filled";
            return res;
        }
        public static String CheckPasswordRegister(String password)
        {
            String res = "";
            if (password.Equals("")) res = "Password must be filled";
            else if (!Regex.IsMatch(password, "^[a-zA-Z0-9]*$")) res = "Password must be alphanumeric";
            return res;
        }
        public static String CheckPhone(String phone)
        {
            String res = "";
            if (phone.Equals("")) res = "Phone must be filled";
            return res;
        }
        public static String ValidateRegister(String name, String dob, String gender, String address, String password, String phone)
        {
            String res = CheckUsernameRegister(name);
            if(res.Equals("")) res = CheckDOB(dob);
            if(res.Equals("")) res = CheckGender(gender);
            if(res.Equals("")) res = CheckAddress(address);
            if(res.Equals("")) res = CheckPasswordRegister(password);
            if(res.Equals("")) res = CheckPhone(phone);
            if(res.Equals("")) res = UserHandler.HandleRegister(name, DateTime.Parse(dob), gender, address, password, phone);
            return res;
        }
        public static String GetRole(String name)
        {
            return UserHandler.GetRole(name);
        }
        public static void InsertUser(String name, DateTime dob, String gender, String address, String password, String phone)
        {
            UserHandler.HandleInsert(name, dob, gender, address, password, phone);
        }
    }
}