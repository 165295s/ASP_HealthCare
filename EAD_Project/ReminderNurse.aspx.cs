using EAD_Project.DAL;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project

{ public partial class ReminderNurse : System.Web.UI.Page
    {
        ReminderNurseDAO oDAO = new ReminderNurseDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NRIC"] != null && Session["Name"] != null && Session["Gender"] != null && Session["Email"] != null)
            {
                TextBoxNRIC.Text = Session["NRIC"].ToString();
                TextBoxName.Text = Session["Name"].ToString();
                TextBoxGender.Text = Session["Gender"].ToString();
                TextBoxEmail.Text = Session["Email"].ToString();
            }
            else
            {
                Response.Redirect("~/ReminderPatientSelection.aspx");
            }
           

            if (Page.IsPostBack == false)
            {
                List<ReminderNurseObject> list = new List<ReminderNurseObject>();
                list = oDAO.getMedicine();
                try
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        DropDownListMedicines.Items.Add(list[i].Medicine);

                    }
                }
                catch (System.NullReferenceException)
                {

                }
                
            }

            if (!this.IsPostBack)
            {
                ReminderNurseDAO myTD = new ReminderNurseDAO();

            }

            

            ReminderNurseDAO reminderNurse = new ReminderNurseDAO();
            List<ReminderNurseObject> tdList = new List<ReminderNurseObject>();
            tdList = reminderNurse.getDetailsByNRIC(TextBoxNRIC.Text);
            GridViewDetails.DataSource = tdList;
            GridViewDetails.DataBind();
            
            

        }

        protected void TextBoxMedicines_TextChanged(object sender, EventArgs e)
        {
            TextBoxMedicines.Text = DropDownListMedicines.SelectedItem.Text;
        }

        protected void DropDownListMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (DropDownListMedicines.SelectedItem.Text != "---Please Select---")
            {
                if (!TextBoxMedicines.Text.Contains(DropDownListMedicines.SelectedItem.Text))
                {
                    TextBoxMedicines.Text += DropDownListMedicines.SelectedItem.Text + ", ";
                }
                
            }
             
        }

        protected void DropDownListDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxDuration.Text = DropDownListDuration.SelectedItem.Text;
        }

        protected void btnSelectMedicine_Click(object sender, EventArgs e)
        {
            if (TextBoxMedicines.Text != "" && TextBoxDuration.Text != "")
            {
                ReminderNurseDAO reminderNurse = new ReminderNurseDAO();
                reminderNurse.InsertTD(TextBoxNRIC.Text ,TextBoxMedicines.Text, TextBoxDuration.Text, TextBoxNotes.Text);
                Response.Redirect("ReminderNurse.aspx");
            }
            else
            {
                StringBuilder errormsg = new StringBuilder();
                if (TextBoxMedicines.Text == "")
                {
                    errormsg.AppendLine(" * Please select medicine(s)<br>");
                }

                if (TextBoxDuration.Text == "")
                {
                    errormsg.AppendLine(" * Please select a duration<br>");
                }

                LabelErrorMsg.Text = errormsg.ToString();
            }
            

            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReminderPatientSelection.aspx");
        }

        protected void ButtonSendPatient_Click(object sender, EventArgs e)
        {
            SendEmail(TextBoxEmail.Text, TextBoxNRIC.Text, TextBoxName.Text);
            Response.Redirect("~/ReminderNurse.aspx");
        }

        private void SendEmail(string Email, string PatientNRIC, string name)
        {
            var apiKey = System.Configuration.ConfigurationManager.AppSettings["SendGridKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@BayHealthHospital.com", "BayHealth Hospital");
            var to = new EmailAddress(Email, "Web User");
            var plainTextContent = "";
            var subject = "Reminder to take medicine";

            List<ReminderNurseObject> tdList = new List<ReminderNurseObject>();
            ReminderNurseDAO reminderNurse = new ReminderNurseDAO();
            ReminderNurseObject obj = reminderNurse.getNurseDetails(Session["ssLogin"].ToString());
            tdList = reminderNurse.getDetailsByNRIC(PatientNRIC);

            StringBuilder sbMedicineReminder = new StringBuilder();
            sbMedicineReminder.Append("Dear " + name + ",<br/><br/>");
            sbMedicineReminder.Append("Please remember to take your medicine");
            sbMedicineReminder.Append("<br/>");
            if (tdList.Count > 0)
            {
                sbMedicineReminder.Append("<table><tr> <th>Medicine</th>  <th>Duration</th>  <th>Notes</th> </tr>");
                for (int i=0; i<tdList.Count; i++)
                {
                    sbMedicineReminder.Append("<tr> <td>" + tdList[i].Medicine + "</td><td>" + tdList[i].Duration + "</td> <td>" + tdList[i].Notes + "</td> </tr>");
                }
                sbMedicineReminder.Append("</table>");
            }
            sbMedicineReminder.Append("<br/><br/>");
            sbMedicineReminder.Append("By: " + obj.NurseName + "<br/>");
            sbMedicineReminder.Append("Mobile No: " + obj.NurseMobileNo + "<br/>");
            sbMedicineReminder.Append("Email Address: " + obj.NurseEmail + "<br/>");
            sbMedicineReminder.Append("<b>BayHealth Hospital</b>");
            var htmlContent = sbMedicineReminder.ToString();
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            client.SendEmailAsync(msg);
            reminderNurse.deleteMedicineDetails(PatientNRIC);
        }

        protected void GridViewDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectRow = GridViewDetails.SelectedIndex;
            GridViewRow theRow = GridViewDetails.Rows[selectRow];
            string Medicine = theRow.Cells[0].Text;
            string Duration = theRow.Cells[1].Text;
            string Notes = theRow.Cells[2].Text;

            ReminderNurseDAO reminderNurse = new ReminderNurseDAO();
            reminderNurse.deleteRow(Medicine, Duration, Notes);
            Response.Redirect("~/ReminderNurse.aspx");

        }

    }
}