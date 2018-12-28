using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class ReminderPatientSelection : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ReminderNurseDAO dao = new ReminderNurseDAO();
            List<ReminderPatientDetailsObj> patientlist = dao.getPatientDetails();
            if (patientlist != null)
            {
                GridViewPatientDetails.DataSource = patientlist;
                GridViewPatientDetails.DataBind();
            }
            
        }

        protected void GridViewPatientDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectRow = GridViewPatientDetails.SelectedIndex;
            GridViewRow theRow = GridViewPatientDetails.Rows[selectRow];
            Session["NRIC"] = theRow.Cells[0].Text;
            Session["Name"] = theRow.Cells[1].Text;
            Session["Gender"] = theRow.Cells[2].Text;
            Session["Email"] = theRow.Cells[3].Text;
            Response.Redirect("~/ReminderNurse.aspx");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            List<ReminderPatientDetailsObj> tdList = new List<ReminderPatientDetailsObj>();
            ReminderNurseDAO dao = new ReminderNurseDAO();
            tdList = dao.getPatientSearch(TextBoxSearching.Text);

            GridViewPatientDetails.DataSource = tdList;
            GridViewPatientDetails.DataBind();
        }

        protected void ButtonSelectAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReminderPatientSelection.aspx");
        }
    }
}