using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class CaptureBarcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PatientNRIC"] == null || Request.QueryString["PatientName"] == null)
            {
                Response.Redirect("~/VisitorManagementAddVisitor.aspx");
            }
            lblPatientNRIC.Text = Request.QueryString["PatientNRIC"];
            lblPatientName.Text = Request.QueryString["PatientName"];
        }
    }
}