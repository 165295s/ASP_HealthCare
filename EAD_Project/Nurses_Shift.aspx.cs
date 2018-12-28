using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class Nurses_Shift : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //databind
            NurseShiftDAO myObj = new NurseShiftDAO();
            List<NurseShiftObject> myTD = new List<NurseShiftObject>();
            myTD = myObj.getWardNoL1();
            wardList.DataSource = myTD;
            wardList.DataBind();

            NurseShiftDAO myObj2 = new NurseShiftDAO();
            List<NurseShiftObject> myTD2 = new List<NurseShiftObject>();
            myTD2 = myObj2.getWardNoL2();
            wardList2.DataSource = myTD2;
            wardList2.DataBind();

            NurseShiftDAO myObj3 = new NurseShiftDAO();
            List<NurseShiftObject> myTD3 = new List<NurseShiftObject>();
            myTD3 = myObj3.getWardNoL3();
            wardList3.DataSource = myTD3;
            wardList3.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

        }

        protected void wardList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectRow = wardList.SelectedIndex;
            GridViewRow theRow = wardList.Rows[selectRow];
            Message.Text = "You have selected " + theRow.Cells[0].Text;
            Session["selectedWard"] = theRow.Cells[0].Text;
            Response.Redirect("~/AssignNurses.aspx");
        }

        protected void wardList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectRow = wardList2.SelectedIndex;
            GridViewRow theRow = wardList2.Rows[selectRow];
            Message.Text = "You have selected " + theRow.Cells[0].Text;
            Session["selectedWard"] = theRow.Cells[0].Text;
            Response.Redirect("~/AssignNurses.aspx");
        }

        protected void wardList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectRow = wardList3.SelectedIndex;
            GridViewRow theRow = wardList3.Rows[selectRow];
            Message.Text = "You have selected " + theRow.Cells[0].Text;
            Session["selectedWard"] = theRow.Cells[0].Text;
            Response.Redirect("~/AssignNurses.aspx");
        }
    }
}