using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.Web.Configuration;
using EAD_Project.DAL;
using EAD_Project.Controller;

namespace EAD_Project.Registration
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.BtnEmail.UniqueID;
            if (Session["ssRole"] == null)
            {
                Response.Redirect("~/MainPage.aspx");
            }
        }

        
        ResetPasswordController RPC = new ResetPasswordController();

        protected void BtnOTPSubmit_Click(object sender, EventArgs e)
        {
            Session["Reset"] = "Hello";
            bool isValid = RPC.ValidateUser(TbEmail.Text, Session["ssRole"].ToString(), Request.QueryString["Forgotten"]);
            if (isValid == true)
            {
                Lblconfirmation.Visible = true;
                LblTitle.Text = "Email sent confirmation";
                LblNRIC.Visible = false;
                TbEmail.Visible = false;
                BtnEmail.Visible = false;
            }
            else
            {
                Lblconfirmation.Visible = true;
                LblTitle.Text = "Email sent confirmation";
                Lblconfirmation.Text = "The email " + TbEmail.Text + " is not recognized";
                LblNRIC.Visible = false;
                TbEmail.Visible = false;
                BtnEmail.Visible = false;
            }
            
        }
        
        

       
        
    }
}