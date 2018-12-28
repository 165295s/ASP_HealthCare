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
    public class AssignNursesDAO
    {
        public List<AssignNursesObject> getNurseName()
        {
            //Get connection string from web.config
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            List<AssignNursesObject> nurseList = new List<AssignNursesObject>();
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer
            //by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT NRIC, Name FROM Nurse WHERE");
            sqlCommand.AppendLine("ShiftID IS NULL;");

            //Instantiate SqlConnection instance and SqlDataAdapter instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset
            da.Fill(ds, "NurseTable");

            int rec_cnt = ds.Tables["NurseTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["NurseTable"].Rows) //Sql command returns
                {
                    AssignNursesObject nurseObj = new AssignNursesObject();

                    nurseObj.NRIC = row["NRIC"].ToString();
                    nurseObj.Name = row["Name"].ToString();

                    nurseList.Add(nurseObj);
                }
            }
            else
            {
                nurseList = null;
            }
            return nurseList;
        }

        public int updateNurseIntoShift(string nurseName, string nurseNRIC, string selectedWard)
        {
            int result = 0;

            //Get connection string from web.config
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            //sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("UPDATE NurseShifts");
            sqlCommand.AppendLine("SET NurseName = @paraNurseName, NurseNRIC = @paraNurseNRIC");
            sqlCommand.AppendLine("WHERE Ward = @paraSelectedWard");

            //Instantiate SqlConnection instance and SqlDataAdapter instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlCommand.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("paraNurseName", nurseName);
            sqlCmd.Parameters.AddWithValue("paraNurseNRIC", nurseNRIC);
            sqlCmd.Parameters.AddWithValue("paraSelectedWard", selectedWard);

            //open connection
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        public int DeleteNurseIntoShift(string nurseName, string nurseNRIC, string selectedWard)
        {
            int result = 0;

            //Get connection string from web.config
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            //sql statement
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("UPDATE NurseShifts");
            sqlCommand.AppendLine("SET NurseName = @paraNurseName, NurseNRIC = @paraNurseNRIC");
            sqlCommand.AppendLine("WHERE Ward = @paraSelectedWard and CONVERT(NVARCHAR(MAX), NurseName) = @paraNurseName1 and NurseNRIC = @paraNurseNRIC1");

            //Instantiate SqlConnection instance and SqlDataAdapter instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlCommand.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("paraNurseName", "");
            sqlCmd.Parameters.AddWithValue("paraNurseNRIC", "");
            sqlCmd.Parameters.AddWithValue("paraNurseName1", nurseName);
            sqlCmd.Parameters.AddWithValue("paraNurseNRIC1", nurseNRIC);
            sqlCmd.Parameters.AddWithValue("paraSelectedWard", selectedWard);

            //open connection
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

    }

    
}