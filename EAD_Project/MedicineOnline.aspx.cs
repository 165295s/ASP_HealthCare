using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 using EAD_Project.DAL;


namespace EAD_Project
{
    public partial class MedicineOnline : System.Web.UI.Page
    {

        CreateMedicineDao cmd = new CreateMedicineDao();
        MedicinePriceDAO mpd = new MedicinePriceDAO();
        List<Medicine> medicine = new List<Medicine>();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ssLogin"] == null || Session["User"].ToString() != "Visitor")
                {
                    Session["ssRole"] = "Visitor";
                    Response.Redirect("~/Custom_Error_Page.aspx");
                }
            }
            catch (NullReferenceException)
            {
                Session["ssRole"] = "Visitor";
                Response.Redirect("~/Login.aspx");
            }
        }
        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Accessing BoundField Column

        }



        /* 
         * protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

            con.Open();

            String Query = "select count(*)from MedicineCart where MedicineName ='" + Label2.Text.ToString() + "'";

            SqlCommand InsertCon = new SqlCommand(Query, con);

            int count = Convert.ToInt32(InsertCon.ExecuteScalar());

            con.Close();

            if (count > 0)
                
            {
                Label20.Text = "Item has already been added pls update it if u wanna change:)";
                String MedName = Label2.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox1.Text);
                medicine = cmd.getMedCart(MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();

            }

            else
            {
                String MedName = Label2.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox1.Text);


                cmd.insertMedicine(MedName, Quantity);

                medicine = cmd.getMedCart(MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();
            }
        }
        */




        /* TextBox16.Text = GridView1.SelectedRow.Cells[1].Text;
         TextBox17.Text = GridView1.SelectedRow.Cells[2].Text;*/





        protected void btnClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

            con.Open();

            String Query = "select count(*)from MedicineCart where MedicineName ='" + Label2.Text.ToString() + "' and VisitorNRIC = '" + Session["ssLogin"].ToString() + "'";

            SqlCommand InsertCon = new SqlCommand(Query, con);

            int count = Convert.ToInt32(InsertCon.ExecuteScalar());

            con.Close();

            if (TextBox1.Text == "")
            {
                // Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "**pls enter a Quantity**";

                string myStringVariable = "Pls enter a Quantity!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            else if (count > 0)

            {
                Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "Item has already been added pls update it if u wanna change:)";
                string myStringVariable = "Item has already been added pls update it if u wanna change:)";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                String MedName = Label2.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox1.Text);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();

            }
            else if (Convert.ToInt32(TextBox1.Text) < 1)
            {
                string myStringVariable = "Quantity cannot be less than 1 :)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

            }

            else
            {

                string myStringVariable = "Item Successfully Added:)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

                String MedName = Label2.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox1.Text);
                decimal Price = Convert.ToDecimal(Label21.Text);
                decimal TotalPrice = Quantity * Price;
                mpd.insertMedicinePrice(Session["ssLogin"].ToString(), TotalPrice,MedName);
                cmd.insertMedicine(Session["ssLogin"].ToString(), MedName, Quantity);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();

             
            }

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            TextBox16.Text = row.Cells[1].Text;
            TextBox17.Text = row.Cells[2].Text;

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            if (TextBox16.Text == "" || TextBox17.Text == "")
            {
                Label20.Text = "*Pls Select A Medicine to Update*";
            }
            else if (Convert.ToInt32(TextBox17.Text) < 1)
            {
                Label20.Text = "*Quantity cannot be less than 1*";

            }
            else
            {   Double Price;
                Label20.ForeColor = System.Drawing.Color.Green;
                Label20.Text = "Item Successfully Updated:)";
                String MedName = TextBox16.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox17.Text);
                cmd.UpdateMedicine(Session["ssLogin"].ToString(), MedName, Quantity);
                if (MedName == "Lozenges")
                {
                    Price = 2.85;

                }
                else if (MedName == "Antibiotics")
                {
                    Price = 2.50;
                }
                else if (MedName == "Cough Syrup")
                {
                    Price = 5.0;
                }

                else
                {
                    Price = 5.0;

                }
                double TotalPrice = Quantity * Price;
                mpd.UpdateMedicinePrice(Session["ssLogin"].ToString(), MedName,TotalPrice);

                // mpd.DeleteMedicinePrice(MedName);


                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();
                TextBox16.Text = String.Empty;
                TextBox17.Text = String.Empty;
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (TextBox16.Text == "" || TextBox17.Text == "")
            {
                Label20.Text = "*Pls Select A Medicine to Delete*";
            }
            else
            {
                Label20.ForeColor = System.Drawing.Color.Green;
                Label20.Text = "*Item Successfully Deleted*";

                String MedName = TextBox16.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox17.Text);
                mpd.DeleteMedicinePrice(Session["ssLogin"].ToString(), MedName);
                cmd.DeleteMedicine(Session["ssLogin"].ToString(), MedName, Quantity);
                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();
                TextBox16.Text = String.Empty;
                TextBox17.Text = String.Empty;

            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                string myStringVariable = "Please Buy Something Before You Checkout!";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);
            }
            else
            {

                 // Session["MedicineName"] = Label2.Text.ToString();

                  //Session["Quantity"] = Convert.ToInt32(TextBox1.Text);

                Response.Redirect("Checkout.aspx");
            }

        }
    
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

            con.Open();

            String Query = "select count(*)from MedicineCart where MedicineName ='" + Label3.Text.ToString() + "' and VisitorNRIC = '" + Session["ssLogin"].ToString() + "'";

            SqlCommand InsertCon = new SqlCommand(Query, con);

            int count = Convert.ToInt32(InsertCon.ExecuteScalar());

            con.Close();

            if (TextBox9.Text == "")
            {
                // Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "**pls enter a Quantity**";

                string myStringVariable = "Pls enter a Quantity!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            else if (count > 0)

            {
                Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "Item has already been added pls update it if u wanna change:)";
                string myStringVariable = "Item has already been added pls update it if u wanna change:)";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                String MedName = Label3.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox9.Text);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();

            }
            else if (Convert.ToInt32(TextBox9.Text) < 1)
            {
                string myStringVariable = "Quantity cannot be less than 1 :)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

            }

            else
            {

                string myStringVariable = "Item Successfully Added:)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

                String MedName = Label3.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox9.Text);
                decimal Price = Convert.ToDecimal(Label22.Text);
                decimal TotalPrice = Quantity * Price;
                mpd.insertMedicinePrice(Session["ssLogin"].ToString(), TotalPrice,MedName);

                cmd.insertMedicine(Session["ssLogin"].ToString(), MedName, Quantity);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();
            }
        }

      

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

            con.Open();

            String Query = "select count(*)from MedicineCart where MedicineName ='" + Label4.Text.ToString() + "' and VisitorNRIC = '" + Session["ssLogin"].ToString() + "'";

            SqlCommand InsertCon = new SqlCommand(Query, con);

            int count = Convert.ToInt32(InsertCon.ExecuteScalar());

            con.Close();

            if (TextBox10.Text == "")
            {
                // Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "**pls enter a Quantity**";

                string myStringVariable = "Pls enter a Quantity!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            else if (count > 0)

            {
                Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "Item has already been added pls update it if u wanna change:)";
                string myStringVariable = "Item has already been added pls update it if u wanna change:)";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                String MedName = Label4.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox10.Text);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();

            }
            else if (Convert.ToInt32(TextBox10.Text) < 1)
            {
                string myStringVariable = "Quantity cannot be less than 1 :)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

            }

            else
            {

                string myStringVariable = "Item Successfully Added:)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

                String MedName = Label4.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox10.Text);
                decimal Price = Convert.ToDecimal(Label23.Text);
                decimal TotalPrice = Quantity * Price;
                mpd.insertMedicinePrice(Session["ssLogin"].ToString(), TotalPrice, MedName);
                cmd.insertMedicine(Session["ssLogin"].ToString(), MedName, Quantity);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

            con.Open();

            String Query = "select count(*)from MedicineCart where MedicineName ='" + Label5.Text.ToString() + "' and VisitorNRIC = '" + Session["ssLogin"].ToString() + "'";

            SqlCommand InsertCon = new SqlCommand(Query, con);

            int count = Convert.ToInt32(InsertCon.ExecuteScalar());

            con.Close();

            if (TextBox11.Text == "")
            {
                // Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "**pls enter a Quantity**";

                string myStringVariable = "Pls enter a Quantity!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            else if (count > 0)

            {
                Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "Item has already been added pls update it if u wanna change:)";
                string myStringVariable = "Item has already been added pls update it if u wanna change:)";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                String MedName = Label5.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox11.Text);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();

            }
            else if (Convert.ToInt32(TextBox11.Text) < 1)
            {
                string myStringVariable = "Quantity cannot be less than 1 :)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

            }

            else
            {

                string myStringVariable = "Item Successfully Added:)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

                String MedName = Label5.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox11.Text);
                decimal Price = Convert.ToDecimal(Label24.Text);
                decimal TotalPrice = Quantity * Price;
                mpd.insertMedicinePrice(Session["ssLogin"].ToString(), TotalPrice, MedName);
                cmd.insertMedicine(Session["ssLogin"].ToString(), MedName, Quantity);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

            con.Open();

            String Query = "select count(*)from MedicineCart where MedicineName ='" + Label6.Text.ToString() + "' and VisitorNRIC = '" + Session["ssLogin"].ToString() + "'";

            SqlCommand InsertCon = new SqlCommand(Query, con);

            int count = Convert.ToInt32(InsertCon.ExecuteScalar());

            con.Close();

            if (TextBox12.Text == "")
            {
                // Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "**pls enter a Quantity**";

                string myStringVariable = "Pls enter a Quantity!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            else if (count > 0)

            {
                Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "Item has already been added pls update it if u wanna change:)";
                string myStringVariable = "Item has already been added pls update it if u wanna change:)";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                String MedName = Label6.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox12.Text);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();

            }
            else if (Convert.ToInt32(TextBox12.Text) < 1)
            {
                string myStringVariable = "Quantity cannot be less than 1 :)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

            }

            else
            {

                string myStringVariable = "Item Successfully Added:)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

                String MedName = Label6.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox12.Text);
                decimal Price = Convert.ToDecimal(Label25.Text);
                decimal TotalPrice = Quantity * Price;
                mpd.insertMedicinePrice(Session["ssLogin"].ToString(), TotalPrice, MedName);
                cmd.insertMedicine(Session["ssLogin"].ToString(), MedName, Quantity);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

            con.Open();

            String Query = "select count(*)from MedicineCart where MedicineName ='" + Label7.Text.ToString() + "' and VisitorNRIC = '" + Session["ssLogin"].ToString() + "'";

            SqlCommand InsertCon = new SqlCommand(Query, con);

            int count = Convert.ToInt32(InsertCon.ExecuteScalar());

            con.Close();

            if (TextBox13.Text == "")
            {
                // Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "**pls enter a Quantity**";

                string myStringVariable = "Pls enter a Quantity!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            else if (count > 0)

            {
                Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "Item has already been added pls update it if u wanna change:)";
                string myStringVariable = "Item has already been added pls update it if u wanna change:)";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                String MedName = Label7.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox13.Text);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();

            }
            else if (Convert.ToInt32(TextBox13.Text) < 1)
            {
                string myStringVariable = "Quantity cannot be less than 1 :)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

            }

            else
            {

                string myStringVariable = "Item Successfully Added:)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

                String MedName = Label7.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox13.Text);
                decimal Price = Convert.ToDecimal(Label26.Text);
                decimal TotalPrice = Quantity * Price;
                mpd.insertMedicinePrice(Session["ssLogin"].ToString(), TotalPrice, MedName);
                cmd.insertMedicine(Session["ssLogin"].ToString(), MedName, Quantity);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();
            }

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

            con.Open();

            String Query = "select count(*)from MedicineCart where MedicineName ='" + Label8.Text.ToString() + "' and VisitorNRIC = '" + Session["ssLogin"].ToString() + "'";

            SqlCommand InsertCon = new SqlCommand(Query, con);

            int count = Convert.ToInt32(InsertCon.ExecuteScalar());

            con.Close();

            if (TextBox14.Text == "")
            {
                // Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "**pls enter a Quantity**";

                string myStringVariable = "Pls enter a Quantity!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            else if (count > 0)

            {
                Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "Item has already been added pls update it if u wanna change:)";
                string myStringVariable = "Item has already been added pls update it if u wanna change:)";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                String MedName = Label8.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox14.Text);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();

            }
            else if (Convert.ToInt32(TextBox14.Text) < 1)
            {
                string myStringVariable = "Quantity cannot be less than 1 :)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

            }

            else
            {

                string myStringVariable = "Item Successfully Added:)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

                String MedName = Label8.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox14.Text);
                decimal Price = Convert.ToDecimal(Label27.Text);
                decimal TotalPrice = Quantity * Price;
                mpd.insertMedicinePrice(Session["ssLogin"].ToString(), TotalPrice, MedName);
                cmd.insertMedicine(Session["ssLogin"].ToString(), MedName, Quantity);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

            con.Open();

            String Query = "select count(*)from MedicineCart where MedicineName ='" + Label9.Text.ToString() + "' and VisitorNRIC = '" + Session["ssLogin"].ToString() + "'";

            SqlCommand InsertCon = new SqlCommand(Query, con);

            int count = Convert.ToInt32(InsertCon.ExecuteScalar());

            con.Close();

            if (TextBox15.Text == "")
            {
                // Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "**pls enter a Quantity**";

                string myStringVariable = "Pls enter a Quantity!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            else if (count > 0)

            {
                Label20.ForeColor = System.Drawing.Color.Red;
                // Label20.Text = "Item has already been added pls update it if u wanna change:)";
                string myStringVariable = "Item has already been added pls update it if u wanna change:)";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                String MedName = Label9.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox15.Text);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();

            }
            else if (Convert.ToInt32(TextBox15.Text) < 1)
            {
                string myStringVariable = "Quantity cannot be less than 1 :)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

            }

            else
            {

                string myStringVariable = "Item Successfully Added:)";
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('" + myStringVariable + "');", true);

                String MedName = Label9.Text.ToString();
                int Quantity = Convert.ToInt32(TextBox15.Text);
                decimal Price = Convert.ToDecimal(Label28.Text);
                decimal TotalPrice = Quantity * Price;
                mpd.insertMedicinePrice(Session["ssLogin"].ToString(), TotalPrice, MedName);
                cmd.insertMedicine(Session["ssLogin"].ToString(), MedName, Quantity);

                medicine = cmd.getMedCart(Session["ssLogin"].ToString(), MedName, Quantity);

                GridView1.DataSource = medicine;
                GridView1.DataBind();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}