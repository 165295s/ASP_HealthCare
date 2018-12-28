using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using EAD_Project.DAL;
using EAD_Project.Controller;

namespace EAD_Project.Registration
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        ChangePasswordDAO cpDAO = new ChangePasswordDAO();
        ResetPasswordController rpController = new ResetPasswordController();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnReset.UniqueID;
            if (!IsPostBack)
            {
                if ( Request.QueryString["uid"] == null || cpDAO.checkUser(Request.QueryString["uid"]) == false)
                {
                    LblLogin.Visible = true;
                    LblTitle.Text = "Invalid password reset link";
                    LblLogin.Text = "Your password reset link has either expired or is invalid.";
                    LblTitle.ForeColor = System.Drawing.Color.Red;
                    LblLogin.ForeColor = System.Drawing.Color.Red; 
                    lblPassword.Visible = false;
                    lblCfmPassword.Visible = false;
                    tbPassword.Visible = false;
                    tbCfmPassword.Visible = false;
                    btnReset.Visible = false;
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            bool result = rpController.changePassword(Request.QueryString["uid"], tbPassword.Text, Request.QueryString["Role"]);
            LblLogin.Visible = true;
            Session["ssRole"] = Request.QueryString["Role"];
            LblLogin.Text = "Your password has been reset. Please <a href=\"Login.aspx\"> click here to login</a>";
            LblTitle.Text = "Reset password confirmation";
            lblPassword.Visible = false;
            lblCfmPassword.Visible = false;
            tbPassword.Visible = false;
            tbCfmPassword.Visible = false;
            btnReset.Visible = false;
        }
    }
}