using RAiso.Model;
using RAiso.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Handlers
{
    public class UserHandler
    {
        public static int GenerateID()
        {
            MsUser lastUser = UserRepository.GetLastUser();

            if (lastUser == null)
            {
                return 1;
            }
            else
            {
                int lastId = lastUser.UserID;
                int newId = lastId + 1;
                return newId;
            }
        }

        public static void AddUser(MsUser user)
        {
            UserRepository.AddUser(user);
        }

        public static String GetUsername(string name)
        {
            return UserRepository.GetUsername(name);
        }

        public static MsUser GetUserCredentials(string username, string password)
        {
            return UserRepository.GetUserCredentials(username, password);
        }

        public static MsUser GetUserById(int id)
        {
            return UserRepository.GetUserById(id);
        }

        public static Boolean Update(int id, string username, string password, string gender, string phone, string address, DateTime dob)
        {
            MsUser user = UserRepository.GetUserById(id);
            MsUser checkUsername = UserRepository.GetUserByName(username);
            if (checkUsername == null || checkUsername.UserID == user.UserID)
            {
                user.UserName = username;
                user.UserPassword = password;
                user.UserGender = gender;
                user.UserPhone = phone;
                user.UserAddress = address;
                user.UserDOB = dob;
                UserRepository.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}