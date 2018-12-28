using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dynamsoft.Barcode;

namespace EAD_Project
{
    public partial class Testing : System.Web.UI.Page
    {

        QueueDAO qDAO = new QueueDAO();
        QueueObject Qobj = new QueueObject();
        QueueAdminDAO qaDAO = new QueueAdminDAO();


        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        ChangePasswordDAO cdao = new ChangePasswordDAO();

        protected void Button1_Click(object sender, EventArgs e)
        {
            int minutes = 65;
            TimeSpan span = TimeSpan.FromMinutes(minutes);
            TextBox1.Text= span.TotalHours.ToString() + "hours " + span.Minutes.ToString() + "minutes";
            int num= decimal.ToInt32(Convert.ToDecimal(1.9999999999));
            Response.Write(num);



        }
        

        //DateTime Today = DateTime.Now;
        
        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}