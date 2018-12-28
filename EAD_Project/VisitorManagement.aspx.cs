using EAD_Project.Controller;
using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class VisitorManagement : System.Web.UI.Page
    {
        VisitorManagementDAO vmDAO = new VisitorManagementDAO();
        VisitorManagementController controller = new VisitorManagementController();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnCfmPatient.UniqueID;
            controller.BindDummyRow(PatientVisitGridView);
            if (Session["PatientNRIC1"] != null)
            {
                string PatientName = vmDAO.CheckPatient(Session["PatientNRIC1"].ToString());
                if (PatientName == Session["PatientName1"].ToString())
                {
                    lblError.Visible = false;

                    lblPatientNRIC1.Visible = true;
                    lblPatientNRICDetails.Visible = true;
                    lblPatientNRICDetails.Text = Session["PatientNRIC1"].ToString();
                    lblPatientName1.Visible = true;
                    lblPatientNameDetails.Visible = true;
                    lblPatientNameDetails.Text = Session["PatientName1"].ToString();
                }
                else
                {
                    lblError.Visible = true;
                }

            }
            
        }

        protected void btnCfmPatient_Click(object sender, EventArgs e)
        {
            Session["PatientNRIC1"] = tbPatientNRIC.Text;
            Session["PatientName1"] = tbPatientName.Text;
            Response.Redirect("~/VisitorManagement.aspx");
        }
    }
}