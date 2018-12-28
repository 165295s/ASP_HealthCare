using System;
using System.Drawing;
using System.Text;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using EAD_Project.DAL;
using System.Collections.Generic;

namespace EAD_Project
{
    public partial class Patient_Care : System.Web.UI.Page
    {
        //page load
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //cancel button click
        protected void cancelBut_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        //confirm Button Click
        protected void confirmBut_Click(object sender, EventArgs e)
        {   
            //Missing date validation
            if (shiftDateStart.Text == "" || shiftDateEnd.Text == "")
            {
                //Does not display missing dates error
                errorPanel.Visible = true;
                errorLabel.Visible = true;
                errorLabel.Text = "*Please input dates";
                dateStar.Visible = true;
            }

            //Validate startdate < enddate
            else if (Convert.ToDateTime(shiftDateStart.Text) > Convert.ToDateTime(shiftDateEnd.Text))
            {
                errorPanel.Visible = true;
                errorLabel.Visible = true;
                errorLabel.Text = "*start of shift's date must be before, or same as shift's end date";
                dateStar.Visible = true;
            }

            //Missing Time Validation
            else if (shiftTimeStart.Text == "" || shiftTimeEnd.Text == "")
            {

                //Does not display missing dates error
                errorPanel.Visible = true;
                errorLabel.Visible = true;
                errorLabel.Text = "*Please input time";
                timeStar.Visible = true;
            }           

            else if (wardList.SelectedValue == "--Select--")
            {
                //Display missing ward number error
                errorPanel.Visible = true;
                errorLabel.Visible = true;
                errorLabel.Text = "Please select a ward you are in charge today";
                wardStar.Visible = true;
            }
            else
            {
                //initialise Patient Care Object and DAO
                PatientCareObject patObj = new PatientCareObject();
                PatientCareDAO patDAO = new PatientCareDAO();

                //Does not display missing ward number error
                errorLabel.Text = String.Empty;
                errorLabel.Visible = false;
                errorPanel.Visible = false;
                dateStar.Visible = false;
                timeStar.Visible = false;
                wardStar.Visible = false;


                //set ward value into a variable etc.
                Session["selectedWard"] = wardList.SelectedValue.ToString();
                Session["shiftDateStart"] = shiftDateStart.Text;
                Session["shiftTimeStart"] = shiftTimeStart.Text.ToString();
                Session["shiftDateEnd"] = shiftDateEnd.Text;
                Session["shiftTimeEnd"] = shiftTimeEnd.Text.ToString();

                Response.Redirect("PatientCareList.aspx");
            }
            
        }

        //reset button click
        protected void resetBut_Click(object sender, EventArgs e)
        {
            shiftDateStart.Text = "";
            shiftDateEnd.Text = "";
            wardList.ClearSelection();
            shiftTimeStart.Text = "";
            shiftTimeEnd.Text = "";

            errorLabel.Text = String.Empty;
            errorLabel.Visible = false;
            errorPanel.Visible = false;
            dateStar.Visible = false;
            timeStar.Visible = false;
            wardStar.Visible = false;

        }

    }
}