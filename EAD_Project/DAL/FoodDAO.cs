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
    public class FoodDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public int insertData(String Main,String Meat, String Fruit, String Vegetable, String Side, String Drink, String Request, String Meal, String NRIC, String Name, int WardNo)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    // Execute NonQuery return an integer value
            SqlCommand sqlCmd = new SqlCommand();
            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO FoodDb (Main, Meat, Fruit, Vegetable, Side, Drink, Request, Meal, NRIC, Name, WardNo, Date )");
            sqlStr.AppendLine("VALUES (@paraMain, @paraMeat, @paraFruit, @paraVegetable, @paraSide, @paraDrink, @paraRequest, @paraMeal, @paraNRIC, @paraName, @paraWardNo, GETDATE() )");



            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraMain", Main);
            sqlCmd.Parameters.AddWithValue("@paraMeat", Meat);
            sqlCmd.Parameters.AddWithValue("@paraFruit",Fruit);
            sqlCmd.Parameters.AddWithValue("@paraVegetable", Vegetable);
            sqlCmd.Parameters.AddWithValue("@paraSide", Side);
            sqlCmd.Parameters.AddWithValue("@paraDrink", Drink);
            sqlCmd.Parameters.AddWithValue("@paraRequest", Request);
            sqlCmd.Parameters.AddWithValue("@paraMeal", Meal);
            sqlCmd.Parameters.AddWithValue("@paraNRIC", NRIC);
            sqlCmd.Parameters.AddWithValue("@paraName", Name);
            sqlCmd.Parameters.AddWithValue("@paraWardNo", WardNo);
          




            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;

        }
        public List<FoodObject> FoodOrderDetails(String NRIC)
        {
            // Step 2 : declare a list to hold collection of patient's FoodOrders
            //           DataSet instance and dataTable instance 

            List<FoodObject> tdList = new List<FoodObject>();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;


            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised NRIC
            //          where TD is not matured yet

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT NRIC, Name, WardNo, Meal, Main, Meat, Fruit, Vegetable, Side, Drink, Request, Date FROM FoodDb");
            sqlStr.AppendLine("where  NRIC = @paraNRIC");


            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraNRIC", NRIC);
            
            // Step 5 :add value to parameter 


            // Step 6: fill dataset
            da.Fill(ds, "Tables");

            // Step 7: Iterate the rows from TableTD above to create a collection of TD
            //         for this particular food  

            int rec_cnt = ds.Tables["Tables"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["Tables"].Rows)
                {
                    FoodObject myTD = new FoodObject();

                    // Step 8 Set attribute of timeDeposit instance for each row of record in TableTD

                    myTD.NRIC = row["NRIC"].ToString();
                    myTD.Name = row["Name"].ToString();
                    myTD.WardNo = row["WardNo"].ToString();
                    myTD.Meal = row["Meal"].ToString();
                    myTD.Main = row["Main"].ToString();
                    myTD.Meat = row["Meat"].ToString();
                    myTD.Fruit = row["Fruit"].ToString();
                    myTD.Vegetable = row["Vegetable"].ToString();
                    myTD.Side = row["Side"].ToString();
                    myTD.Drink = row["Drink"].ToString();
                    myTD.Request = row["Request"].ToString();
                    myTD.Date = Convert.ToDateTime( row["Date"]);


                    //  Step 9: Add each food instance to list
                    tdList.Add(myTD);
                }
            }
            else
            {
                tdList = null;
            }

            return tdList;
        }
        public void DeleteFoodOrderList()
        {
            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            string Checkquery = "DELETE  FROM FoodDb";
            SqlCommand CheckCom = new SqlCommand(Checkquery, myConn);
            CheckCom.ExecuteNonQuery();

            myConn.Close();
            
          
        }
        public Boolean checkMeal(string NRIC, string Meal)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from FoodDb Where NRIC = @paraNRIC and Meal = @paraMeal");


            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset

            da.SelectCommand.Parameters.AddWithValue("@paraNRIC", NRIC);
            da.SelectCommand.Parameters.AddWithValue("@paraMeal", Meal);


            da.Fill(ds, "FoodDb");
            int rec_cnt = ds.Tables["FoodDb"].Rows.Count;
            if (rec_cnt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}