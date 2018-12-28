using Google.Authenticator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EAD_Project.DAL;

namespace EAD_Project
{
    public partial class GoogleAuthenticator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(Request.QueryString["key"]))
            {
                Response.Redirect("~/GoogleAuthenticator.aspx?key=" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10));
            }

            // string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            //this.lblSecretKey.Text = Request.QueryString["key"];

            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            //var setupInfo = tfa.GenerateSetupCode("Test Two Factor", "user@example.com", Request.QueryString["key"], 300, 300);
            var setupInfo = tfa.GenerateSetupCode("BayHealth Payment", "Aik Kee", /*key*/Request.QueryString["key"], 300, 300);

            string qrCodeImageUrl = setupInfo.QrCodeSetupImageUrl;
            string manualEntrySetupCode = setupInfo.ManualEntryKey;

            this.imgQrCode.ImageUrl = qrCodeImageUrl;
            //  this.lblManualSetupCode.Text = manualEntrySetupCode;
        }

        protected void ButtonValidate_Click(object sender, EventArgs e)
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            var result = tfa.ValidateTwoFactorPIN(Request.QueryString["key"], this.TextBoxGooglePin.Text);

        //    string ResetPass = LoginBLL.ResetPass(username);

            if (result)
            {
                SMS.SMSSoapClient send = new SMS.SMSSoapClient();

                 String Message = "Dear "+ (String)(Session["Name"])+","+" you have bought something on " + (DateTime)(Session["date"])+" it cost a total of "+ (string)(Session["Price"]+" and will be credited from your account: "+ (String)(Session["BankAccNumber"]));
                 String s = send.sendMessage("IT13", "642560", (string)(Session["PhoneNumber"]), Message);
                CreateMedicineDao cmd = new CreateMedicineDao();
                cmd.DeleteAllMedicine(Session["ssLogin"].ToString());
                MedicinePriceDAO mpd = new MedicinePriceDAO();
                mpd.DeleteAllMedicinePrice(Session["ssLogin"].ToString());
                Response.Redirect("Checkout.aspx");

                // this.lblValidationResult.Text = this.TextBoxGooglePin.Text + " is a valid PIN at UTC time " + DateTime.UtcNow.ToString();
                //this.lblValidationResult.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                this.lblValidationResult.Text = this.TextBoxGooglePin.Text + " is not a valid PIN at UTC time " + DateTime.UtcNow.ToString();
                this.lblValidationResult.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}