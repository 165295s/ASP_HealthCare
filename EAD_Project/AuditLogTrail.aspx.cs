using EAD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class AuditLogTrail : System.Web.UI.Page
    {
        AuditTrailController ATO = new AuditTrailController();
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Session["userName"].ToString();
            string ToA = Session["ToA"].ToString();

            AuditTable.DataSource = ATO.GetLookup(userName, ToA);
            AuditTable.DataBind();
            AuditTable.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
    }
}