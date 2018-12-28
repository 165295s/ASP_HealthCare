using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class VisitorManagementDAO
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        public string CheckPatient(string PatientNRIC)
        {
            string PatientName = "";
            conn.Open();
            string checkQuery = "Select count(*) from Patient where NRIC = '" + PatientNRIC + "'";
            SqlCommand CheckCom = new SqlCommand(checkQuery, conn);
            int CheckPatient = Convert.ToInt32(CheckCom.ExecuteScalar().ToString());
            if (CheckPatient == 1)
            {
                string NameQuery = "select Name from Patient where NRIC = '" + PatientNRIC + "'";
                SqlCommand NameCom = new SqlCommand(NameQuery, conn);
                PatientName = NameCom.ExecuteScalar().ToString();
            }
            conn.Close();
            return PatientName;
        }

        public void updateStayDuration()
        {
            string updateQuery = "update PatientVisit set StayDuration = GETDATE() - ArrivalTime";
            SqlCommand UpdateCom = new SqlCommand(updateQuery, conn);
            UpdateCom.ExecuteNonQuery();

        }

        public List<VisitorManagementOBJ> getAllVisitors(string PatientNRIC)
        {
            List<VisitorManagementOBJ> list = new List<VisitorManagementOBJ>();
            conn.Open();
            updateStayDuration();
            string Selectquery = "select Name, ArrivalTime, StayDuration from PatientVisit pv inner join Visitor v on pv.VisitorNRIC = v.NRIC where PatientNRIC = '" + PatientNRIC + "'";
            da = new SqlDataAdapter(Selectquery, conn);
            da.Fill(ds, "PatientVisitTbl");
            int rec_cnt = ds.Tables["PatientVisitTbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["PatientVisitTbl"].Rows)
                {
                    VisitorManagementOBJ obj = new VisitorManagementOBJ();
                    obj.VisitorName = row["Name"].ToString();
                    obj.ArrivalTime = Convert.ToDateTime(row["ArrivalTime"]);
                    obj.StayDuration = Convert.ToDateTime(row["StayDuration"]).ToString("HH:mm:ss");
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
    }
}