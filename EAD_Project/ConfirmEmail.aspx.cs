using EAD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class ConfirmEmail : System.Web.UI.Page
    {
        RegistrationController RC = new RegistrationController();
        protected void Page_Load(object sender, EventArgs e)
        {
            string nric = Request.QueryString["confirm"];

            RC.ConfirmEmail(nric);
        }
    }
}