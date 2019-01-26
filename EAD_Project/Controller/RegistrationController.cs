using EAD_Project.DAL;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace EAD_Project.Controller
{
    public class RegistrationController
    {
        VisitorDAO visitorDAO = new VisitorDAO();


        public void InsertVisitor(string nric, string name, string password, string gender, int mobileNumber, string email, string accountLocked)
        {
            
            //hash password here
            //Generate a new salt 
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltByte = new byte[8];
            rng.GetBytes(saltByte);
            string salt = Convert.ToBase64String(saltByte);

            SHA512Managed hashing = new SHA512Managed();
            string pwdWithSalt = password + salt;
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
            string savedPasswordHash = Convert.ToBase64String(hashWithSalt);

            visitorDAO.InsertVisitor(nric, name, savedPasswordHash, gender, mobileNumber, email, accountLocked, salt);

        }

        public void SendConfirmationEmail(string nric, string name, string email)
        {
            var apiKey = System.Configuration.ConfigurationManager.AppSettings["SendGridKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@BayHealthHospital.com", "BayHealth Hospital");
            var to = new EmailAddress(email, "Web User");
            var plainTextContent = "";

            //TODO: CHANGE NRIC TO SOMETHING ELSE, FOR TESTING PURPOSES ONLY
            var subject = "Please confirm your Email";
            Uri uri = HttpContext.Current.Request.Url;
            StringBuilder sbConfirmEmail = new StringBuilder();
            sbConfirmEmail.Append("Dear " + name + ",<br/><br/>");
            sbConfirmEmail.Append("Please click on the following link to confirm your email address");
            sbConfirmEmail.Append("<br/>");
            sbConfirmEmail.Append("<a href=\" http://localhost:" + uri.Port + "/ConfirmEmail.aspx?confirm=" + nric + "\">Confirm your email</a>");
            //make a new page when onload, change accountlocked to "false"
            sbConfirmEmail.Append("<br/><br/>");
            sbConfirmEmail.Append("<b>BayHealth Hospital</b>");
            var htmlContent = sbConfirmEmail.ToString();
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            client.SendEmailAsync(msg);

        }

        public void ConfirmEmail(string nric)
        {
            visitorDAO.ConfirmAccount(nric);
        }
    }
}