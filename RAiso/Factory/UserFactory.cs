using RAiso.Model;
using RAiso.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factory
{
    public class UserFactory
    {
        DatabaseEntities db = DatabaseSingleton.GetInstance();
        public static MsUser CreateUser(int id, String name, DateTime dob, String gender, String address, String password, String phone, String role)
        {
            MsUser user = new MsUser
            {
                UserId = id,
                UserName = name,
                UserGender = gender,
                UserDOB = dob,
                UserPhone = phone,
                UserAddress = address,
                UserPassword = password,
                UserRole = role
            };
            return user;
        }
    }
}