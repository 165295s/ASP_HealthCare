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
                    Response.Redirect("MainPage.aspx");
                }
                else
                {
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


    }
}