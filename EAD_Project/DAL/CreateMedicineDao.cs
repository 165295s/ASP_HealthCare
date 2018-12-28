using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace EAD_Project.DAL
{
    public class CreateMedicineDao
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        public void insertMedicine(string VisitorNRIC, String MedName, int Quantity)
        {

         



             con.Open();
            String Query = "Insert into MedicineCart (VisitorNRIC,MedicineName,Quantity) values (@paraVisitorNRIC,@paraMedName , @paraQuantity)";
            SqlCommand InsertCon = new SqlCommand(Query, con);
            InsertCon.Parameters.AddWithValue("@paraVisitorNRIC", VisitorNRIC);
            InsertCon.Parameters.AddWithValue("@paraMedName", MedName);
            InsertCon.Parameters.AddWithValue("@paraQuantity", Quantity);


            InsertCon.ExecuteNonQuery();
            con.Close(); 


        }

       
            public void UpdateMedicine(String VisitorNRIC,String MedName, int Quantity)
            {





                con.Open();
                String Query = "Update MedicineCart set VisitorNRIC = @paraVisitorNRIC,MedicineName=@paraMedName , Quantity=@paraQuantity where MedicineName=@paraMedName";
                SqlCommand UpdateCon = new SqlCommand(Query, con);
                UpdateCon.Parameters.AddWithValue("@paraVisitorNRIC", VisitorNRIC);
                UpdateCon.Parameters.AddWithValue("@paraMedName", MedName);
                UpdateCon.Parameters.AddWithValue("@paraQuantity", Quantity);

                UpdateCon.ExecuteNonQuery();
                con.Close();


            }

        public void DeleteMedicine(String VisitorNRIC, String MedName, int Quantity)
        {
            con.Open();
            String Query = "Delete from MedicineCart where MedicineName=@paraMedName and VisitorNRIC = @paraVisitorNRIC";
            SqlCommand DeleteCon = new SqlCommand(Query, con);
            DeleteCon.Parameters.AddWithValue("@paraVisitorNRIC", VisitorNRIC);
            DeleteCon.Parameters.AddWithValue("@paraMedName", MedName);
            DeleteCon.Parameters.AddWithValue("@paraQuantity", Quantity);

            DeleteCon.ExecuteNonQuery();
            con.Close();


        }

        public void DeleteAllMedicine(string VisitorNRIC)
        {
            con.Open();
            string sqlTrunc = "Delete from MedicineCart where VisitorNRIC = @paraVisitorNRIC";
            SqlCommand cmd = new SqlCommand(sqlTrunc, con);
            cmd.Parameters.AddWithValue("@paraVisitorNRIC", VisitorNRIC);
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public List<Medicine> getMedCart(string VisitorNRIC,string MedName , int Quantity )
        {
            // Step 2 : declare a list to hold collection of customer's timeDeposit
            //           DataSet instance and dataTable instance 

            List<Medicine> tdList = new List<Medicine>();
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised customer id
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From MedicineCart where VisitorNRIC = '" + VisitorNRIC + "'");
          


            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 


            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular customer 

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableTD"].Rows)
                {
                    Medicine med = new Medicine();


                    med.MedicineName = row["MedicineName"].ToString();
                    med.Quantity = Convert.ToInt32(row["Quantity"]);
                  

                    tdList.Add(med);
                }
            }
            else
            {
                tdList = null;
            }

            return tdList;
        }

        public List<Medicine> getMedCartForCheckout(string VisitorNRIC)
        {
            // Step 2 : declare a list to hold collection of customer's timeDeposit
            //           DataSet instance and dataTable instance 

            List<Medicine> tdList = new List<Medicine>();
            String DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised customer id
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From MedicineCart where VisitorNRIC = '" + VisitorNRIC + "'");



            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 


            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular customer 

            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableTD"].Rows)
                {
                    Medicine med = new Medicine();


                    med.MedicineName = row["MedicineName"].ToString();
                    med.Quantity = Convert.ToInt32(row["Quantity"]);


                    tdList.Add(med);
                }
            }
            else
            {
                tdList = null;
            }

            return tdList;
        }

    }
}
