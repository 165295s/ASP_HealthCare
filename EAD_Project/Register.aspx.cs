using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EAD_Project.Controller;
using EAD_Project.DAL;

namespace EAD_Project
{
    public partial class Register : System.Web.UI.Page
    {
        RegistrationController RC = new RegistrationController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            
                Visitor visitor = new Visitor();

                visitor.nric = tb_Nric.Text;
                visitor.name = tb_Name.Text;
                visitor.password = tb_Password.Text;
                visitor.gender = rb_GenderList.SelectedItem.ToString();
                visitor.mobile_number = int.Parse(tb_Number.Text);
                visitor.email = tb_Email.Text;

            try
            {
                RC.InsertVisitor(visitor.nric, visitor.name, visitor.password, visitor.gender, visitor.mobile_number, visitor.email, visitor.accountLocked);
            } catch (Exception)
            {
                Server.Transfer("Custom_Error_Page.aspx");
            }
                //send email function here
                RC.SendConfirmationEmail(visitor.nric, visitor.name, visitor.email);
                Response.Redirect("EmailSend.aspx");
            
        }

    }
}