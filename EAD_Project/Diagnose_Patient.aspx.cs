using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class Diagnose_Patient : System.Web.UI.Page
    {
        DiagnosePatientDAO dpDAO = new DiagnosePatientDAO();
        DiagnosePatientOBJ dpObj = new DiagnosePatientOBJ();
        InsertDiagnosePatientDAO idpDAO = new InsertDiagnosePatientDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<DiagnosePatientOBJ> DPList = dpDAO.RetrivePatientNRIC();

            if (Page.IsPostBack == false)
            {
                for (int i = 0; i < DPList.Count; i++)
                {
                    ddlID.Items.Add(DPList[i].PatientNRIC);
                }
            }

            
        }

        protected void BtnInsert(object sender, EventArgs e)
        {
            GridView1.DataSource = "";
            GridView1.DataBind();
            string AllCheckedItems2 = "";
            string myStringVariable = "Insert/ Update SUCCESSFUL";
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    string CheckedItems;
                    CheckedItems = item + ",";
                    AllCheckedItems2 = AllCheckedItems2 + CheckedItems;
                }
            }
            try
            {
                idpDAO.InsertDiagnose(ddlID.SelectedItem.Text, Convert.ToInt32(tbPulse.Text), tbPressure.Text, Convert.ToDouble(tbTempreture.Text), AllCheckedItems2, tbSymtoms.Text, tbChronic.Text, tbDrugs.Text, tbNotes.Text);
            }
            catch (System.FormatException)
            {

            }
            
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

            tbName.Text = "";
            tbAge.Text = "";
            tbGender.Text = "";
            tbMobile.Text = "";
            tbEmail.Text = "";
            tbPulse.Text = "";
            tbPressure.Text = "";
            tbTempreture.Text = "";
            tbSymtoms.Text = "";
            tbChronic.Text = "";
            tbDrugs.Text = "";
            tbNotes.Text = "";
            CheckBoxList1.ClearSelection();
            ddlSymptoms.SelectedIndex = -1;
            ddlChronic.SelectedIndex = -1;
            ddlDrugs.SelectedIndex = -1;
            ddlID.SelectedIndex = -1;


        }

        protected void DDLid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlID.SelectedItem.Text != "--Select--")
            {
                tbSymtoms.Text = "";
                tbChronic.Text = "";
                tbDrugs.Text = "";
                tbNotes.Text = "";
                dpDAO.insertDiagnosePatient(ddlID.SelectedItem.Text);
                dpObj = dpDAO.FillFormbyPatientId(ddlID.SelectedItem.Text);
                if (dpObj != null)
                {
                    tbName.Text = dpObj.Name;
                    tbAge.Text = dpObj.Age.ToString();
                    tbGender.Text = dpObj.Gender;
                    tbMobile.Text = dpObj.MobileNo;
                    tbEmail.Text = dpObj.Email;

                }

                List<DiagnosePatientOBJ> list = dpDAO.getTDbyPatientId(ddlID.SelectedItem.Text);
                GridView1.DataSource = list;
                GridView1.DataBind();

                if (dpObj == null)
                {
                    tbName.Text = "";
                    tbAge.Text = "";
                    tbGender.Text = "";
                    tbMobile.Text = "";
                    tbEmail.Text = "";
                    tbPulse.Text = "";
                    tbPressure.Text = "";
                    tbTempreture.Text = "";
                    tbSymtoms.Text = "";
                    tbChronic.Text = "";
                    tbDrugs.Text = "";
                    tbNotes.Text = "";
                    CheckBoxList1.ClearSelection();
                    ddlSymptoms.SelectedIndex = -1;
                    ddlChronic.SelectedIndex = -1;
                    ddlDrugs.SelectedIndex = -1;
                    GridView1.DataSource = "";
                    GridView1.DataBind();
                }
                
                
                
                
            }
            else if(ddlID.SelectedItem.Text == "--Select--")
            {
                tbName.Text =  "";
                tbAge.Text = "";
                tbGender.Text = "";
                tbMobile.Text = "";
                tbEmail.Text = "";
                tbPulse.Text = "";
                tbPressure.Text = "";
                tbTempreture.Text = "";
                tbSymtoms.Text = "";
                tbChronic.Text = "";
                tbDrugs.Text = "";
                tbNotes.Text = "";
                CheckBoxList1.ClearSelection();
                ddlSymptoms.SelectedIndex = -1;
                ddlChronic.SelectedIndex = -1;
                ddlDrugs.SelectedIndex = -1;
                GridView1.DataSource = "";
                GridView1.DataBind();
            }

        }

        protected void ddlChronic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!tbChronic.Text.Contains(ddlChronic.SelectedItem.Text))
            {
                tbChronic.Text += ddlChronic.SelectedItem.Text + ", " + Environment.NewLine;
            }

        }

        protected void ddlSymtoms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!tbSymtoms.Text.Contains(ddlSymptoms.SelectedItem.Text))
            {
                tbSymtoms.Text += ddlSymptoms.SelectedItem.Text + ", " + Environment.NewLine;
            }

        }

        protected void ddlDrugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!tbDrugs.Text.Contains(ddlDrugs.SelectedItem.Text))
            {
                tbDrugs.Text += ddlDrugs.SelectedItem.Text + ", " + Environment.NewLine;
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = "";
            GridView1.DataBind();
            string myStringVariable = "Delete Successful";
            idpDAO.DeleteDiagnose(ddlID.SelectedItem.Text);
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

            tbName.Text = "";
            tbAge.Text = "";
            tbGender.Text = "";
            tbMobile.Text = "";
            tbEmail.Text = "";
            tbPulse.Text = "";
            tbPressure.Text = "";
            tbTempreture.Text = "";
            tbSymtoms.Text = "";
            tbChronic.Text = "";
            tbDrugs.Text = "";
            tbNotes.Text = "";
            CheckBoxList1.ClearSelection();
            ddlSymptoms.SelectedIndex = -1;
            ddlChronic.SelectedIndex = -1;
            ddlDrugs.SelectedIndex = -1;
            ddlID.SelectedIndex = -1;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectRow = GridView1.SelectedIndex;
            GridViewRow theRow = GridView1.Rows[selectRow];
            CheckBoxList1.ClearSelection();
            tbPulse.Text = theRow.Cells[6].Text;
            tbPressure.Text = theRow.Cells[7].Text;
            tbTempreture.Text = theRow.Cells[8].Text;

            string word = theRow.Cells[9].Text;
            try
            {
                string[] ckItems = word.Split(new String[] { "," }, StringSplitOptions.None);
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    for (int i = 0; i < ckItems.Length; i++)
                    {
                        if (item.Text == ckItems[i])
                        {
                            item.Selected = true;
                        }

                    }
                }
            }
            catch (System.NullReferenceException)
            {

            }

            try
            {
                tbSymtoms.Text = theRow.Cells[10].Text;
                tbChronic.Text = theRow.Cells[11].Text;
                tbDrugs.Text = theRow.Cells[12].Text;
                tbNotes.Text = theRow.Cells[13].Text;
            }
            catch (System.NullReferenceException)
            {

            }
        }

        protected void btnGridViewDelete_Click(object sender, EventArgs e)
        {
            InsertDiagnosePatientDAO ipDAO = new InsertDiagnosePatientDAO();
            Button btn = (Button)sender;
            GridViewRow theRow = (GridViewRow)btn.NamingContainer;

      
           ipDAO.DeleteDiagnoseByRow(theRow.Cells[0].Text, theRow.Cells[14].Text);
        }
    }
}