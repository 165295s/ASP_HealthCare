using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EAD_Project.Controller
{
    public class VisitorManagementController
    {
        public void BindDummyRow(GridView view)
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("VisitorName");
            dummy.Columns.Add("ArrivalTime");
            dummy.Columns.Add("StayDuration");
            dummy.Rows.Add();
            view.DataSource = dummy;
            view.DataBind();
        }
    }
}