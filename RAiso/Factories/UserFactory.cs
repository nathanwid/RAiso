using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Factories
{
    public class UserFactory
    {
        public static MsUser Create(int id, string username, string gender, DateTime dob, string phone, string address, string password, string role)
        {
            MsUser user = new MsUser()
            {
                UserID = id,
                UserName = username,
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