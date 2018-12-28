using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using static EAD_Project.Patient_Care;
using System.Collections.Generic;

namespace EAD_Project.DAL
{
    public class PatientCareDAO
    {
        public List<PatientCareObject> getPatientByWardNo(string wardNo)
        {
            //Get connection string from web.config
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            List<PatientCareObject> patList = new List<PatientCareObject>();
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer
            //by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT NRIC, WardNo, Medication, Name FROM Patient WHERE");
            sqlCommand.AppendLine("wardNo = @paraWardNo");

            //Instantiate SqlConnection instance and SqlDataAdapter instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            //add value to parameter 
            da.SelectCommand.Parameters.AddWithValue("paraWardNo", wardNo);

            // fill dataset
            da.Fill(ds, "PatientTable");

            int rec_cnt = ds.Tables["PatientTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["PatientTable"].Rows) //Sql command returns
                {
                    PatientCareObject patObj = new PatientCareObject();

                    patObj.NRIC = row["NRIC"].ToString();
                    patObj.WardNo = row["WardNo"].ToString();
                    patObj.Medication = row["Medication"].ToString();
                    patObj.Name = row["Name"].ToString();

                    patList.Add(patObj);
                }
            }
            else
            {
                patList = null;
            }
            return patList;
        }
    }
}