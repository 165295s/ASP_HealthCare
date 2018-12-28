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
    public class FoodPatientInfoDAO
    {


      

        public List<FoodPatientInfoObject> getCurrentTdRte(String pNRIC)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<FoodPatientInfoObject> rteList = new List<FoodPatientInfoObject>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * From FoodPatientInfoDb ");
            sqlCommand.AppendLine("where PatientNRIC = @paraPNRIC");

            

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

           
           
            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraPNRIC", pNRIC);
            // fill dataset to a table
            da.Fill(ds, "tdRateTable");

            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["tdRateTable"].Rows.Count;
            if (rec_cnt == 0)
            {
                rteList = null;
            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["tdRateTable"].Rows)
                {
                    FoodPatientInfoObject objRte = new FoodPatientInfoObject();
                    objRte.NRIC  = row["PatientNRIC"].ToString();
                    objRte.WardNo = Convert.ToInt32(row["WardNo"]);
                    objRte.Condition = row["Condition"].ToString();
                    objRte.Diet = row["Diet"].ToString();
                    objRte.PatientName = row["PatientName"].ToString();
               
                    rteList.Add(objRte);
                }
            }
            return rteList;
        }



        
       
    }

}