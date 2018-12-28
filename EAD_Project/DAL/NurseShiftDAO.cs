using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using static EAD_Project.Nurses_Shift;

namespace EAD_Project
{
    public class NurseShiftDAO
    {
        public List<NurseShiftObject> getWardNoL1()
        {
            //Get connection string from web.config
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            List<NurseShiftObject> nurseShiftList = new List<NurseShiftObject>();
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer
            //by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * FROM WardL1"); 

            //Instantiate SqlConnection instance and SqlDataAdapter instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset
            da.Fill(ds, "WardTable");

            int rec_cnt = ds.Tables["WardTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["WardTable"].Rows) //Sql command returns
                {
                    NurseShiftObject nurseShiftObj = new NurseShiftObject();

                    nurseShiftObj.Ward = row["Ward"].ToString();

                    nurseShiftList.Add(nurseShiftObj);
                }
            }
            else
            {
                nurseShiftList = null;
            }
            return nurseShiftList;
        }


        public List<NurseShiftObject> getWardNoL2()
        {
            //Get connection string from web.config
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            List<NurseShiftObject> nurseShiftList = new List<NurseShiftObject>();
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer
            //by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * FROM WardL2");

            //Instantiate SqlConnection instance and SqlDataAdapter instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset
            da.Fill(ds, "WardTable");

            int rec_cnt = ds.Tables["WardTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["WardTable"].Rows) //Sql command returns
                {
                    NurseShiftObject nurseShiftObj = new NurseShiftObject();

                    nurseShiftObj.Ward = row["Ward"].ToString();

                    nurseShiftList.Add(nurseShiftObj);
                }
            }
            else
            {
                nurseShiftList = null;
            }
            return nurseShiftList;
        }

        public List<NurseShiftObject> getWardNoL3()
        {
            //Get connection string from web.config
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            List<NurseShiftObject> nurseShiftList = new List<NurseShiftObject>();
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer
            //by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * FROM WardL3");

            //Instantiate SqlConnection instance and SqlDataAdapter instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset
            da.Fill(ds, "WardTable");

            int rec_cnt = ds.Tables["WardTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["WardTable"].Rows) //Sql command returns
                {
                    NurseShiftObject nurseShiftObj = new NurseShiftObject();

                    nurseShiftObj.Ward = row["Ward"].ToString();

                    nurseShiftList.Add(nurseShiftObj);
                }
            }
            else
            {
                nurseShiftList = null;
            }
            return nurseShiftList;
        }
    
    }
}