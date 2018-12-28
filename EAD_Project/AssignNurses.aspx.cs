using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class AssignNurses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssignNursesDAO myObj = new AssignNursesDAO();
            List<AssignNursesObject> myTD = new List<AssignNursesObject>();
            myTD = myObj.getNurseName();
            NurseList.DataSource = myTD;
            NurseList.DataBind();

        }

        protected void NurseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssignNursesDAO myObj = new AssignNursesDAO();
            int myTD = new int();

            int selectRow = NurseList.SelectedIndex;
            GridViewRow theRow = NurseList.Rows[selectRow];

            string selectedWard = Session["selectedWard"].ToString();
            myTD = myObj.updateNurseIntoShift(theRow.Cells[0].Text, theRow.Cells[1].Text, selectedWard);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            AssignNursesDAO myObj = new AssignNursesDAO();
            Button btn = (Button)sender;
            GridViewRow theRow = (GridViewRow)btn.NamingContainer;
            string selectedWard = Session["selectedWard"].ToString();
            myObj.DeleteNurseIntoShift(theRow.Cells[0].Text, theRow.Cells[1].Text, selectedWard);

        }
    }
}