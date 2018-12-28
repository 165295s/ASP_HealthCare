using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class FoodOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string selectedNRIC = (string)(Session["NRIC"]);

            FoodDAO myDAO = new FoodDAO();
            List<FoodObject> myTD = new List<FoodObject>();
            myTD = myDAO.FoodOrderDetails(selectedNRIC);
            FoodOrderView.DataSource = myTD;
            FoodOrderView.DataBind();


        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            FoodDAO myDAO = new FoodDAO();
            FoodOrderView.DataSource = "";
            FoodOrderView.DataBind();
            string myStringVariable = "Food Order List has been cleared";
            myDAO.DeleteFoodOrderList();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(' " + myStringVariable + " ');", true);

            

        }
        protected void gv_DataBound(object sender, EventArgs e)
        {
            ClearButton.Visible = FoodOrderView.Rows.Count > 0;
           
        }
    }
}