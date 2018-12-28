using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EAD_Project.Controller
{
    public class LoginController
    {
        LoginDAO LoginOBJ = new LoginDAO();

        public string ErrMsg(string role, string username, string password)
        {
            StringBuilder sb = new StringBuilder();
            LoginObject L = new LoginObject();
            L = LoginOBJ.UserLogin(role, username);


            SHA512Managed hashing = new SHA512Managed();
            string pwdWithSalt = password + L.salt;
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
            string savedPasswordHash = Convert.ToBase64String(hashWithSalt);
            if (L.User != 1)
            {
                sb.Append("Incorrect username is entered<br>");
            }

            if (L.password != savedPasswordHash)
            {
                sb.Append("Incorrect password is entered");
            }

            return sb.ToString();
        }
        public static int GetDBattempts(string userId)
        {
            return LoginDAO.getDBattempts(userId);
        }
      

        public static void plusOneToAttempt(String userId)
        {

            LoginDAO.plusOneToAttempt(userId);
        }
       
    }
}