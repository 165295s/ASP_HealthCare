using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.IO;

namespace EAD_Project
{
    public partial class Checkout : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //Button3.Visible=true;
            // if (Session["MedicineName"] != null && Session["Quantity"] != null)
            //  {
            //   string MedName = Session["MedicineName"].ToString();
            //int Quantity = Convert.ToInt32(Session["Quantity"]);
            //     TextBox5.Text = MedName;
            //   TextBox6.Text = Convert.ToString(Quantity);

            List<Medicine> medicine = new List<Medicine>();
            CreateMedicineDao cmd = new CreateMedicineDao();
            // medicine = cmd.getMedCart(Session["MedicineName"].ToString(), Convert.ToInt32(Session["Quantity"].ToString()));
            medicine = cmd.getMedCartForCheckout(Session["ssLogin"].ToString());
            GridView1.DataSource = medicine;
            GridView1.DataBind();

            //   int QuantityB = Convert.ToInt32(TextBox6.Text);
            //    String MedNameB = TextBox5.Text.ToString();


            //   }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
            //Setting the connection string
            //Opening the connection
            conn.Open();
            //Setting the command
            SqlCommand sc = new SqlCommand("SELECT SUM(TotalPrice) As TotalCount from MedicinePrice where VisitorNRIC = '" + Session["ssLogin"].ToString() + "'", conn);
            //Creating object of reader
            SqlDataReader reader;
            //Executing the reader
            reader = sc.ExecuteReader();
            while (reader.Read())
            {
                //Get the Sum of Column from Database
                TextBox4.Text = reader["TotalCount"].ToString();
            }
            conn.Close();

            LabelTime.Text = Convert.ToString(DateTime.Now);


        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button7_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CreateMedicineDao cmd = new CreateMedicineDao();
            MedicinePriceDAO mpd = new MedicinePriceDAO();
            mpd.DeleteAllMedicinePrice(Session["ssLogin"].ToString());
            cmd.DeleteAllMedicine(Session["ssLogin"].ToString());
            Response.Redirect("MedicineOnline.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox7.Text == "" || TextBox8.Text == "" || TextBox9.Text == "" || TextBox10.Text == "")
            {
                string myStringVariable = "Pls Enter All Fields Before ComFirming Payment";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TextBox7.Text, "^[a-zA-Z]"))
            {
                string myStringVariable = "Please enter onli letters for Name";

                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);
            }
            else if (!(System.Text.RegularExpressions.Regex.IsMatch(TextBox9.Text, "^[89]\\d{7}$")) || String.IsNullOrEmpty(TextBox9.Text))
            {
                string myStringVariable = "Phone No. must be 8digit NUMBERS!!";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);
            }
            else if (!(System.Text.RegularExpressions.Regex.IsMatch(TextBox10.Text, "^[45]\\d{7}$")) || String.IsNullOrEmpty(TextBox9.Text))
            {
                string myStringVariable = "Bank Account No. must in Numbers and Contain 8 Numbers ";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);
            }
            else
            {
                String Name = TextBox7.Text.Trim();
                Session["Name"] = Name;

                string PhoneNumber = TextBox9.Text.Trim();
                Session["PhoneNumber"] = PhoneNumber;

                DateTime date = Convert.ToDateTime(LabelTime.Text);
                Session["date"] = date;

                String Price = TextBox4.Text;
                Session["Price"] = Price;

                String BankAccNumber = TextBox10.Text.Trim();
                Session["BankAccnumber"] = BankAccNumber;


                Response.Redirect("GoogleAuthenticator.aspx");


            }
        }
        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
      
        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
