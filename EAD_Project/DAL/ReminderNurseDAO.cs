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
    public class ReminderNurseDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);


        public List<ReminderNurseObject> getMedicine()
        {
            List<ReminderNurseObject> list = new List<ReminderNurseObject>();
            DataSet ds = new DataSet();
            conn.Open();

            string query = "select Medicine from Medicine";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "ReminderNurseTbl");
            int rec_cnt = ds.Tables["ReminderNurseTbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["ReminderNurseTbl"].Rows)
                {
                    ReminderNurseObject obj = new ReminderNurseObject();
                    obj.Medicine = row["Medicine"].ToString();
                    list.Add(obj);
                }
            }
            else
            {
                list = null;
            }
            conn.Close();
            return list;

        }

        public List<ReminderNurseObject> getDuration()
        {
            List<ReminderNurseObject> list = new List<ReminderNurseObject>();
            DataSet ds = new DataSet();
            conn.Open();

            string query = "select Duration from ReminderNurse;";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "ReminderNurseTbl");
            int rec_cnt = ds.Tables["ReminderNurseTbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["ReminderNurseTbl"].Rows)
                {
                    ReminderNurseObject obj = new ReminderNurseObject();
                    obj.Medicine = row["Duration"].ToString();
                    list.Add(obj);
                }
            }
            else
            {
                list = null;
            }
            conn.Close();
            return list;

        }

        public List<ReminderNurseObject> getNotes()
        {
            List<ReminderNurseObject> list = new List<ReminderNurseObject>();
            DataSet ds = new DataSet();
            conn.Open();

            string query = "select Notes from ReminderNurse;";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "ReminderNurseTbl");
            int rec_cnt = ds.Tables["ReminderNurseTbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["ReminderNurseTbl"].Rows)
                {
                    ReminderNurseObject obj = new ReminderNurseObject();
                    obj.Medicine = row["Notes"].ToString();
                    list.Add(obj);
                }
            }
            else
            {
                list = null;
            }
            conn.Close();
            return list;

        }

        public void InsertPatientNRIC(string PatientNRIC)
        {
            conn.Open();
            string query = "INSERT INTO ReminderNurse(PatientNRIC) values (@paraPatientNRIC)";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd = new SqlCommand(query, conn);
            sqlCmd.Parameters.AddWithValue("@paraPatientNRIC", PatientNRIC);
            sqlCmd.ExecuteNonQuery();
            conn.Close();
        } 

        public List<ReminderNurseObject> getDetailsByNRIC(string PatientNRIC)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            List<ReminderNurseObject> jobList = new List<ReminderNurseObject>();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;


            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * From ReminderNurse where PatientNRIC='" + PatientNRIC  + "'");

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset to a table
            da.Fill(ds, "GridViewDetails");

            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["GridViewDetails"].Rows.Count;
            if (rec_cnt == 0)
            {
                jobList = null;
            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["GridViewDetails"].Rows)
                {
                    ReminderNurseObject objRte = new ReminderNurseObject();
                    objRte.Medicine = Convert.ToString(row["Medicine"]);
                    objRte.Duration = row["Duration"].ToString();
                    objRte.Notes = Convert.ToString(row["Notes"]);


                    jobList.Add(objRte);
                }
            }
            return jobList;
        }

        public int InsertTD(string PatientNRIC, string Medicine, string Duration, string Notes)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO ReminderNurse(PatientNRIC, Medicine, Duration, Notes)");
            sqlStr.AppendLine("VALUES (@paraPatientNRIC, @paraMedicine, @paraDuration, @paraNotes)");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraPatientNRIC", PatientNRIC);
            sqlCmd.Parameters.AddWithValue("@paraMedicine", Medicine);
            sqlCmd.Parameters.AddWithValue("@paraDuration", Duration);
            sqlCmd.Parameters.AddWithValue("@paraNotes", Notes);

            myConn.Open();
            try
            {
                result = sqlCmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {

            }
            

            myConn.Close();

            return result;
        }

        //Get patient details
        public List<ReminderPatientDetailsObj> getPatientDetails()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            List<ReminderPatientDetailsObj> list = new List<ReminderPatientDetailsObj>();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;


            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT NRIC, Name, Gender, Email From Patient");

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset to a table
            da.Fill(ds, "GridViewPatientDetails");

            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["GridViewPatientDetails"].Rows.Count;
            if (rec_cnt == 0)
            {
                list = null;
            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["GridViewPatientDetails"].Rows)
                {
                    ReminderPatientDetailsObj objRte = new ReminderPatientDetailsObj();
                    objRte.NRIC = row["NRIC"].ToString();
                    objRte.Name = row["Name"].ToString();
                    objRte.Gender = row["Gender"].ToString();
                    objRte.Email = row["Email"].ToString();


                    list.Add(objRte);
                }
            }
            return list;
        }

        public void deleteMedicineDetails(string patientNRIC)
        {
            conn.Open();
            string query = "Delete from ReminderNurse where PatientNRIC ='" + patientNRIC +"'";
            SqlCommand com = new SqlCommand(query, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteRow(string Medicine, string Duration, string Notes)
        {
            conn.Open();
            string query = "Delete from ReminderNurse where Medicine = '" + Medicine + "'and Duration = '" + Duration + "'";
            SqlCommand com = new SqlCommand(query, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }

        public List<ReminderPatientDetailsObj> getPatientSearch(string patientNRIC)
        {
            List<ReminderPatientDetailsObj> list = new List<ReminderPatientDetailsObj>();
            DataSet ds = new DataSet();
            conn.Open();

            string query = "select * from Patient where NRIC ='" + patientNRIC +"'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "Patient");
            int rec_cnt = ds.Tables["Patient"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["Patient"].Rows)
                {
                    ReminderPatientDetailsObj obj = new ReminderPatientDetailsObj();
                    obj.NRIC = row["NRIC"].ToString();
                    obj.Name = row["Name"].ToString();
                    obj.Gender = row["Gender"].ToString();
                    obj.Email = row["Email"].ToString();
                    list.Add(obj);
                }
            }
            else
            {
                list = null;
            }
            conn.Close();
            return list;

        }

        public ReminderNurseObject getNurseDetails(string NurseNRIC)
        {
            ReminderNurseObject obj = new ReminderNurseObject();
            DataSet ds = new DataSet();
            conn.Open();

            string query = "select Name, Email, [Mobile Number] from Nurse where NRIC ='" + NurseNRIC + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "Nursetbl");
            int rec_cnt = ds.Tables["Nursetbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["Nursetbl"].Rows[0];
                obj.NurseName = row["Name"].ToString();
                obj.NurseMobileNo = Convert.ToInt32(row["Mobile Number"]);
                obj.NurseEmail = row["Email"].ToString();
            }
            else
            {
                obj = null;
            }
            conn.Close();
            return obj;
        }
    }
}