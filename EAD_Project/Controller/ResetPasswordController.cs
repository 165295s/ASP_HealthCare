using EAD_Project.DAL;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EAD_Project.Controller
{
    public class ResetPasswordController
    {

        LoginDAO LDAO = new LoginDAO();
        ChangePasswordDAO CDAO = new ChangePasswordDAO();
        LoginObject L = new LoginObject();
        private void Execute(string Email, string UniqueID, string Username, string role, string forgotten)
        {
            var apiKey = System.Configuration.ConfigurationManager.AppSettings["SendGridKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@BayHealthHospital.com", "BayHealth Hospital");
            var to = new EmailAddress(Email, "Web User");
            var plainTextContent = "";
            if (forgotten == "Password")
            {
                var subject = "Reset your Password";
                Uri uri = HttpContext.Current.Request.Url;
                StringBuilder sbResetPassword = new StringBuilder();
                sbResetPassword.Append("Dear " + role + ",<br/><br/>");
                sbResetPassword.Append("Please click on the following link to reset your password");
                sbResetPassword.Append("<br/>");
                sbResetPassword.Append("<a href=\" http://localhost:" + uri.Port + "/ResetPassword.aspx?uid=" + UniqueID + "&Role=" + role + "\">Reset your password</a>");
                sbResetPassword.Append("<br/><br/>");
                sbResetPassword.Append("<b>BayHealth Hospital</b>");
                var htmlContent = sbResetPassword.ToString();
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                client.SendEmailAsync(msg);
            }else if (forgotten == "Username")
            {
                var subject = "Recover username";
                StringBuilder sbForgotUserName = new StringBuilder();
                sbForgotUserName.Append("Dear " + role + ", <br><br>");
                sbForgotUserName.Append("Your UserName is " + Username);
                sbForgotUserName.Append("<br/><br/>");
                sbForgotUserName.Append("<b>BayHealth Hospital</b>");
                var htmlContent = sbForgotUserName.ToString();
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                client.SendEmailAsync(msg);
            }
            
            
            
            
            
        }

        public bool ValidateUser(string Email, string Role, string forgotten)
        {
            bool isValid;
            L = LDAO.resetPassword(Email, Role);
            if (L.User == 1)
            {
                isValid = true;
                Execute(Email, L.UniqueID.ToString(), L.UserName, Role, forgotten);
                CDAO.deleteSameRecord();
            }
            else
            {
                isValid = false;
            }


            return isValid;
        }
        //CHRIS CODE
        public bool changePassword(string guid, string password, string role)
        {
            return CDAO.changePassword(guid, password, role);
        }
    }
}