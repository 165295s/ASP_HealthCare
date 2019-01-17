using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EAD_Project.DAL;
using System.Text;
using EAD_Project.Controller;

namespace EAD_Project
{
    public partial class Login : System.Web.UI.Page
    {

        LoginController LC = new LoginController();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnLogin.UniqueID;
            if (Session["ssRole"] == null)
            {
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                LblLogin.Text = Session["ssRole"].ToString() + " Login";
            }



            LblResetPassword.Visible = true;
            LblResetPassword.Text = "Forgot <a href=\"SendEmailLink.aspx?Forgotten=Username\">Username</a> or <a href=\"SendEmailLink.aspx?Forgotten=Password\">Password</a>?";

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String userId = tbUsername.Text;
            string userid = tbUsername.Text.ToString().Trim();
            string ActionLF = "Login Failed";
            string ActionLS = "Login Success";
            DateTime TimeOfAction = DateTime.Now;
            string EventID = "null";
            string CertID = "null";
            string IpAddress = GetIPAddress();

            Session["userName"] = userId;
            string timestring = TimeOfAction.ToString("MMM dd yyyy  h:mmtt");
            DateTime.Now.ToString("ToA");
            Session["ToA"] = timestring;

            int tries = LoginController.GetDBattempts(userId);
           // String accountLocked = LoginController.GetAccountLockedInfo(userId);
            string role = Session["ssRole"].ToString();
            string loginValidate = LC.ErrMsg(role, tbUsername.Text, tbPassword.Text);
            
            if (tries < 3)
            {
                if (loginValidate == string.Empty)
                {
                    Session["ssLogin"] = tbUsername.Text;
                    Session["User"] = role;

                    //log success
                    LC.AuditLogLoginSuccess(userid, TimeOfAction, CertID, ActionLS, EventID, IpAddress);

                    Response.Redirect("MainPage.aspx");
                }
                else
                {
                    //log fail
                    LC.AuditLogLoginFail(userid, TimeOfAction, CertID, ActionLF, EventID, IpAddress);

                    LoginController.plusOneToAttempt(userId);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Userid or password is not valid. Please try again.');</script>");

                    LblErr.Visible = true;
                    LblErr.Text = loginValidate;
                }

            } else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Your Account has been locked');</script>");

            }


        }

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }


    }
}