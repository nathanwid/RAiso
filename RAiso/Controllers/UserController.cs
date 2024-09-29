using RAiso.Factories;
using RAiso.Handlers;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RAiso.Controllers
{
    public class UserController
    {
        public static int GenerateID()
        {
            return UserHandler.GenerateID();
        }

        public static String Register(string username, string password, string gender, string phone, string address, string role, DateTime dob)
        {
            int id = GenerateID();

            if (String.IsNullOrEmpty(username))
            {
                return "Username must be filled";
            }
            else if (username.Length < 5 || username.Length > 50)
            {
                return "Username must be between 5 and 50 characters";
            }
            else if (username == UserHandler.GetUsername(username))
            {
                return "Username already taken";
            }
            else if (String.IsNullOrEmpty(gender))
            {
                return "Gender must be selected";
            }
            else if (dob == DateTime.MinValue || DateTime.Now.AddYears(-1) < dob)
            {
                return "User must be at least 1 year old";
            }
            else if (String.IsNullOrEmpty(phone))
            {
                return "Phone number must be filled";
            }
            else if (phone.Any(char.IsLetter))
            {
                return "Phone number must be digits only";
            }
            else if (String.IsNullOrEmpty(address))
            {
                return "Address must be filled";
            }
            else if (String.IsNullOrEmpty(password))
            {
                return "Password must be filled";
            }
            else if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                return "Password must be alphanumeric";
            }
            else
            {
                MsUser newUser = UserFactory.Create(id, username, gender, dob, phone, address, password, role);
                UserHandler.AddUser(newUser);
                return "Success";
            }
        }

        public static String Login(string username, string password, bool rememberMe)
        {
            var user = UserHandler.GetUserCredentials(username, password);

            if (user == null)
            {
                return "User not exist";
            }
            else
            {
                HttpContext.Current.Session["user"] = user;

                if (rememberMe == true)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }

                return "Success";
            }
        }

        public static MsUser GetUserById(int id)
        {
            return UserHandler.GetUserById(id);
        }

        public static String UpdateProfile(int id, string username, string password, string gender, string phone, string address, DateTime dob)
        {
            if (String.IsNullOrEmpty(username))
            {
                return "Username must be filled";
            }
            else if (username.Length < 5 || username.Length > 50)
            {
                return "Username must be between 5 and 50 characters";
            }
            else if (String.IsNullOrEmpty(gender))
            {
                return "Gender must be selected";
            }
            else if (dob == DateTime.MinValue || DateTime.Now.AddYears(-1) < dob)
            {
                return "User must be at least 1 year old";
            }
            else if (String.IsNullOrEmpty(phone))
            {
                return "Phone number must be filled";
            }
            else if (phone.Any(char.IsLetter))
            {
                return "Phone number must be digits only";
            }
            else if (String.IsNullOrEmpty(address))
            {
                return "Address must be filled";
            }
            else if (String.IsNullOrEmpty(password))
            {
                return "Password must be filled";
            }
            else if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                return "Password must be alphanumeric";
            }
            else
            {
                Boolean response = UserHandler.Update(id, username, password, gender, phone, address, dob);
                if (response == true)
                {
                    return "Success";
                }
                else
                {
                    return "Username has already been taken!";
                }
            }
        }
    }
}