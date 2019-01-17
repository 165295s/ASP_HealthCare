using EAD_Project.Controller;
using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class OnlineAppointment : System.Web.UI.Page
    {
        OnlineAppointmentDAO oDAO = new OnlineAppointmentDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelSpecify.Visible = false;
            TextBoxOthers.Visible = false;

            
            if (Session["SuccessfulMessage"] != null)
            {
                LabelSuccessfulMsg.Text = Session["SuccessfulMessage"].ToString();
                ButtonBookAppointment.Attributes.Add("onclick", "return confirm(" + Session["SuccessfulMessage"].ToString() + ");");
                Session["SuccessfulMessage"] = null;
            }
            else
            {
                LabelSuccessfulMsg.Text = "";
            }

            if (Page.IsPostBack == false)
            {
                List<OnlineAppointmentObject> list = new List<OnlineAppointmentObject>();
                list = oDAO.getDoctorName();
                for (int i=0; i<list.Count; i++)
                {
                    DropDownListDoc.Items.Add(list[i].doctorName);
                    
                }
            }


            if (!this.IsPostBack)
            {
                OnlineAppointmentDAO myTD = new OnlineAppointmentDAO();

            }

            OnlineAppointmentDAO onlineApp = new OnlineAppointmentDAO();
            List<OnlineAppointmentObject> tdList = new List<OnlineAppointmentObject>();
            tdList = onlineApp.getApptDetails();
            GridViewApptDetails.DataSource = tdList;
            GridViewApptDetails.DataBind();



        }


        protected void CalendarDate_SelectionChanged(object sender, EventArgs e)
        {
            TextBoxBookDate.Text = CalendarDate.SelectedDate.ToString("dd/MM/yyyy");
            TextBoxDate.Text = CalendarDate.SelectedDate.ToString("dd/MM/yyyy");
        }


        protected void DropDownListDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxDocShift.Text = DropDownListDoc.SelectedItem.Text;
        }


        protected void DropDownListTimings_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBoxTiming.Text = DropDownListTimings.SelectedItem.Text;
        }

        protected void CheckBoxListOptions_SelectedIndexChanged1(object sender, EventArgs e)
        {
            String CheckItem2 = "";
            foreach (ListItem item in CheckBoxListOptions.Items)
            {
                if (item.Selected)
                {
                    if (item.Text != "Other...")
                    {
                        String CheckItem = "";
                        CheckItem = item + ", ";
                        CheckItem2 = CheckItem2 + CheckItem;
                    }

                    if (item.Text == "Other...")
                    {
                        LabelSpecify.Visible = true;
                        TextBoxOthers.Visible = true;
                    }
                    
                }

            }
            TextBoxReason.Text = CheckItem2;

            
        }


        protected void ButtonBookAppointment_Click(object sender, EventArgs e)
        {
            string userid = Session["ssLogin"].ToString();
            string ActionLF = "Book Appointment Failed";
            string ActionLS = "Book Appointment Success";
            DateTime TimeOfAction = DateTime.Now;
            string EventID = "null";
            string CertID = "null";
            string IpAddress = GetIPAddress();

            OnlineAppointmentController AC = new OnlineAppointmentController();
            OnlineAppointmentDAO onlineApp = new OnlineAppointmentDAO();
            if (TextBoxDocShift.Text != "" && TextBoxDate.Text != "" && TextBoxTiming.Text != "" && TextBoxReason.Text != "")
            {
                if (TextBoxOthers.Text != "")
                {
                    if (onlineApp.checkAppt(TextBoxDocShift.Text, TextBoxTiming.Text, TextBoxDate.Text) == 1)
                    {
                        
                        LabelErrorMsg.Text = "Doctor is booked";
                    }
                    else
                    {
                        onlineApp.InsertTD(TextBoxDocShift.Text, TextBoxDate.Text, TextBoxTiming.Text, TextBoxReason.Text + TextBoxOthers.Text);
                        //log success
                        AC.AuditLogAppointmentSuccess(userid, TimeOfAction, CertID, ActionLS, EventID, IpAddress);


                        Session["SuccessfulMessage"] = "Your appointment is successfully booked!";
                        Response.Redirect("OnlineAppointment.aspx");
                        
                        
                    }
                    
                }
                else
                {
                    if (onlineApp.checkAppt(TextBoxDocShift.Text, TextBoxTiming.Text, TextBoxDate.Text) == 1)
                    {
                        //log fail
                        AC.AuditLogAppointmentFail(userid, TimeOfAction, CertID, ActionLF, EventID, IpAddress);
                        LabelErrorMsg.Text = "Doctor is booked!";
                    }
                    else
                    {
                        onlineApp.InsertTD(TextBoxDocShift.Text, TextBoxDate.Text, TextBoxTiming.Text, TextBoxReason.Text);
                        AC.AuditLogAppointmentSuccess(userid, TimeOfAction, CertID, ActionLS, EventID, IpAddress);

                        Session["SuccessfulMessage"] = "Your appointment is successfully booked!";

                        Response.Redirect("OnlineAppointment.aspx");
                    }
                    
                }
                
            }
            else
            {
                StringBuilder errormsg = new StringBuilder();
                
                if (TextBoxDocShift.Text == "")
                {
                    errormsg.AppendLine(" * Please select a doctor<br>");
                }

                if (TextBoxDate.Text == "")
                {
                    errormsg.AppendLine(" * Please select a date<br>");
                }

                if (TextBoxTiming.Text == "")
                {
                    errormsg.AppendLine(" * Please select a timing<br>");
                }

                if (TextBoxReason.Text == "")
                {
                    errormsg.AppendLine(" * Please state your reason<br>");
                }
                LabelErrorMsg.Text = errormsg.ToString();
                
            }

            

           
        }

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

    }
}