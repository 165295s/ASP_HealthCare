using EAD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImgBtnNurseLogin_Click(object sender, ImageClickEventArgs e)
        {
            Session["ssRole"] = LblNurse.Text;
            Response.Redirect("Login.aspx");
        }

        protected void ImgBtnDoctorLogin_Click(object sender, ImageClickEventArgs e)
        {
            Session["ssRole"] = LblDoctor.Text;
            Response.Redirect("Login.aspx");
        }

        protected void ImgBtnPatientLogin_Click(object sender, ImageClickEventArgs e)
        {
            Session["ssRole"] = LblPatient.Text;
            Response.Redirect("Login.aspx");  
        }

        protected void ImgBtnAdminLogin_Click(object sender, ImageClickEventArgs e)
        {
            Session["ssRole"] = LblAdmin.Text;
            Response.Redirect("Login.aspx");
        }

        protected void ImgBtnVisitorLogin_Click(object sender, ImageClickEventArgs e)
        {
            Session["ssRole"] = LblVisitor.Text;
            Response.Redirect("Login.aspx");
        }
    }
}