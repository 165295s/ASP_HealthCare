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
    public class onlineAppointmentDAO
    {

        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //Get connection string from web.config
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

        /*public onlineAppointmentObject getBookAppointment(string doctorName, string date, string timing)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from onlineAppointment where"); 
            sqlCommand.AppendLine("doctorName = @paraDoctorName");
            sqlCommand.AppendLine("date = @paraDate");
            sqlCommand.AppendLine("timing = @paraTiming");

            onlineAppointmentObject obj = new onlineAppointmentObject();

            da = new SqlDataAdapter(sqlCommand.ToString(), conn);
            da.Fill(ds, "onlineAppointment");
            int rec_cnt = ds.Tables["onlineAppointment"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["onlineAppointment"].Rows[0];  // Sql command returns only one record
                obj.doctorName = row["doctorName"].ToString();
                obj.date = row["date"].ToString();
                obj.timing = row["timing"].ToString();
                obj.remarks = row["remarks"].ToString();
                obj.availability = row["availability"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;

            
        }

        public List<onlineAppointmentObject> getDoctorNames()
        {
            List<onlineAppointmentObject> ApptList = new List<onlineAppointmentObject>();
            conn.Open();

            string query = "Select * from onlineAppointment";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "onlineAppointment");
            int rec_cnt = ds.Tables["onlineAppointment"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["onlineAppointment"].Rows[0];  
                obj.doctorName = row["doctorName"].ToString();
                obj.date = row["date"].ToString();
                obj.timing = row["timing"].ToString();
                obj.remarks = row["remarks"].ToString();
                obj.availability = row["availability"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;

            return ApptList;
        }*/

        public List<onlineAppointmentObject> getDoctorName()
        {
            List<onlineAppointmentObject> list = new List<onlineAppointmentObject>();
            DataSet ds = new DataSet();
            conn.Open();

            string query = "select Name from Doctor;";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "OnlineApptTbl");
            int rec_cnt = ds.Tables["OnlineApptTbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["OnlineApptTbl"].Rows)
                {
                    onlineAppointmentObject obj = new onlineAppointmentObject();
                    obj.doctorName = row["Name"].ToString();
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

        public List<onlineAppointmentObject> getTiming(string DocName)
        {
            List<onlineAppointmentObject> list = new List<onlineAppointmentObject>();
            DataSet ds = new DataSet();
            conn.Open();

            string query = "select timing from onlineAppointment where doctorName = '" + DocName + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "OnlineApptTbl");
            int rec_cnt = ds.Tables["OnlineApptTbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["OnlineApptTbl"].Rows)
                {
                    onlineAppointmentObject obj = new onlineAppointmentObject();
                    obj.date = row["timing"].ToString();
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

        public List<onlineAppointmentObject> getDate(string DocName)
        {
            List<onlineAppointmentObject> list = new List<onlineAppointmentObject>();
            DataSet ds = new DataSet();
            conn.Open();

            string query = "select date from onlineAppointment where doctorName = '" + DocName + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "OnlineApptTbl");
            int rec_cnt = ds.Tables["OnlineApptTbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["OnlineApptTbl"].Rows)
                {
                    onlineAppointmentObject obj = new onlineAppointmentObject();
                    obj.date = row["date"].ToString();
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

        public List<onlineAppointmentObject> getReason(string DocName)
        {
            List<onlineAppointmentObject> list = new List<onlineAppointmentObject>();
            DataSet ds = new DataSet();
            conn.Open();

            string query = "select reason from onlineAppointment where doctorName = '" + DocName + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "OnlineApptTbl");
            int rec_cnt = ds.Tables["OnlineApptTbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["OnlineApptTbl"].Rows)
                {
                    onlineAppointmentObject obj = new onlineAppointmentObject();
                    obj.date = row["reason"].ToString();
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

        public List<onlineAppointmentObject> getApptDetails()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            List<onlineAppointmentObject> onlineAppointment = new List<onlineAppointmentObject>();

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;


            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * From onlineAppointment");

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset to a table
            da.Fill(ds, "GridViewApptDetails");

            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["GridViewApptDetails"].Rows.Count;
            if (rec_cnt == 0)
            {
                onlineAppointment = null;
            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["GridViewApptDetails"].Rows)
                {
                    onlineAppointmentObject objAppt = new onlineAppointmentObject();
                    objAppt.doctorName = Convert.ToString(row["doctorName"]);
                    objAppt.reason = row["reason"].ToString();
                    objAppt.date = Convert.ToString(row["date"]);
                    objAppt.timing = Convert.ToString(row["timing"]);
                    

                    onlineAppointment.Add(objAppt);
                }
            }
            return onlineAppointment;



        }


        public int InsertTD(string doctorName, string date, string timing, string reason)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO onlineAppointment(doctorName, date, timing, reason)");
            sqlStr.AppendLine("VALUES (@paraname, @paradate, @paratiming, @parareason)");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraname", doctorName);
            sqlCmd.Parameters.AddWithValue("@paradate", date);
            sqlCmd.Parameters.AddWithValue("@paratiming", timing);
            sqlCmd.Parameters.AddWithValue("@parareason", reason);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int checkAppt(string Doctorname, string timing, string date)
        {
            conn.Open();
            string query = "select count(*) from onlineAppointment where doctorName = '" + Doctorname + "' and timing = '" + timing + "' and date= '" + date + "'";
            SqlCommand com = new SqlCommand(query, conn);
            int CheckAppointment = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            return CheckAppointment;
        }


    }
}