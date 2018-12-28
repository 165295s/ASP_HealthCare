using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace EAD_Project
{
    public partial class PatientCareList1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get selectedWard etc.
            string selectedWardTransfered = (string)(Session["selectedWard"]);
            string shiftDateStart = (string)(Session["shiftDateStart"]);
            string shiftTimeStart = (string)(Session["shiftTimeStart"]);
            string shiftDateEnd = (string)(Session["shiftDateEnd"]);
            string shiftTimeEnd = (string)(Session["shiftTimeEnd"]);

            //databind
            PatientCareDAO myObj = new PatientCareDAO();
            List<PatientCareObject> myTD = new List<PatientCareObject>();
            myTD = myObj.getPatientByWardNo(selectedWardTransfered);
            gvPatientList.DataSource = myTD;
            gvPatientList.DataBind();

            startDate.Text = shiftDateStart;
            startTime.Text = shiftTimeStart;
            endDate.Text = shiftDateEnd;
            endTime.Text = shiftTimeEnd;
        }

        protected void searchBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool exist = searchBox.Text.Contains("AA");
            if (exist == true)
            {
                MessageBox.Show("Text exists at index position" + searchBox.Text.IndexOf("AA").ToString());
            }
            else
            {
                MessageBox.Show("Text doesn't exists");
            }

        }
    }
}