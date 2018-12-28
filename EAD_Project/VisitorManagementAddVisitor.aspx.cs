using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dynamsoft.Barcode;
using EAD_Project.DAL;
using EAD_Project.Controller;

namespace EAD_Project
{
    public partial class VisitorManagement_AddVisitor_ : System.Web.UI.Page
    {
        VisitorManagementDAO vmDAO = new VisitorManagementDAO();
        PatientVisitArrivalDAO pvDAO = new PatientVisitArrivalDAO();
        PatientVisitArrivalController Controller = new PatientVisitArrivalController();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btnCfmPatient.UniqueID;
            if (Session["PatientNRIC2"] != null)
            {
                lblError.Visible = false;
                int VisitorCount = pvDAO.checkVisitorCnt(Session["PatientNRIC2"].ToString());
                string PatientName = vmDAO.CheckPatient(Session["PatientNRIC2"].ToString());
                if (PatientName == Session["PatientName2"].ToString())
                {
                    if (VisitorCount <= 3)
                    {
                        string Fullurl = "CaptureBarcode.aspx?PatientNRIC=" + Session["PatientNRIC2"].ToString() + "&PatientName=" + Session["PatientName2"].ToString();
                        Controller.OpenNewBrowserWindow(Fullurl, this);
                    }
                    else
                    {
                        lblMaxReached.Visible = true;
                    }
                    
                }
                else
                {
                    lblError.Visible = true;
                }
                Session["PatientNRIC2"] = null;
                Session["PatientName2"] = null;

            }
                
        }

        protected void btnCfmPatient_Click(object sender, EventArgs e)
        {
            Session["PatientNRIC2"] = tbPatientNRIC.Text;
            Session["PatientName2"] = tbPatientName.Text;
            Response.Redirect("~/VisitorManagementAddVisitor.aspx");
            
        }

        
    }
}