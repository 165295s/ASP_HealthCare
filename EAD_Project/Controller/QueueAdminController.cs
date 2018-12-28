using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EAD_Project.Controller
{
    public class QueueAdminController
    {
        public void BindDummyRow(GridView view)
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("VisitorNRIC");
            dummy.Columns.Add("VisitorName");
            dummy.Columns.Add("QueueNum");
            dummy.Columns.Add("Timestamp");
            dummy.Rows.Add();
            view.DataSource = dummy;
            view.DataBind();
        }
    }
}