using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EAD_Project
{
    /// <summary>
    /// Summary description for VisitorManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class VisitorManagementService : System.Web.Services.WebService
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        [WebMethod]
        public List<VisitorManagementOBJ> getAllVisitors(string PatientNRIC)
        {
            List<VisitorManagementOBJ> list = new List<VisitorManagementOBJ>();
            VisitorManagementDAO vmDAO = new VisitorManagementDAO();
            conn.Open();
            string updateQuery = "update PatientVisit set StayDuration = GETDATE() - ArrivalTime";
            SqlCommand UpdateCom = new SqlCommand(updateQuery, conn);
            UpdateCom.ExecuteNonQuery();
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

        [WebMethod]
        public int checkVisitorCnt(string PatientNRIC)
        {
            conn.Open();
            string query = "select count(*) from PatientVisit where PatientNRIC = '" + PatientNRIC + "'";
            SqlCommand com = new SqlCommand(query, conn);
            int VisitorCount = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();

            return VisitorCount;
        }

        [WebMethod]
        public int checkVisitor(string VisitorNRIC)
        {
            conn.Open();
            string query = "select count(*) from Visitor where NRIC = '" + VisitorNRIC + "'";
            SqlCommand com = new SqlCommand(query, conn);
            int CheckVisitor = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();

            return CheckVisitor;
        }

        [WebMethod]
        public void InsertPatientVisitDetails(string VisitorNRIC, string PatientNRIC)
        {
            conn.Open();
            string query = "select count(*) from PatientVisit where VisitorNRIC = '" + VisitorNRIC + "'";
            SqlCommand com = new SqlCommand(query, conn);
            int CheckVisitorExists = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();

            
            if (checkVisitor(VisitorNRIC) == 1)
            {
                conn.Open();
                if (CheckVisitorExists <= 0)
                {
                    string Insertquery = "Insert into PatientVisit (VisitorNRIC, PatientNRIC, ArrivalTime, StayDuration) values (@paraVisitorNRIC, @paraPatientNRIC, GETDATE(), GETDATE());";
                    SqlCommand InsertCom = new SqlCommand(Insertquery, conn);
                    InsertCom.Parameters.AddWithValue("@paraVisitorNRIC", VisitorNRIC);
                    InsertCom.Parameters.AddWithValue("@paraPatientNRIC", PatientNRIC);
                    InsertCom.ExecuteNonQuery();
                }
                else
                {
                    string UpdateQuery = "Update PatientVisit set PatientNRIC=@paraPatientNRIC, ArrivalTime=GETDATE(),  StayDuration=GETDATE() where VisitorNRIC = '" + VisitorNRIC + "'";
                    SqlCommand UpdateCom = new SqlCommand(UpdateQuery, conn);
                    UpdateCom.Parameters.AddWithValue("@paraPatientNRIC", PatientNRIC);
                    UpdateCom.ExecuteNonQuery();
                }
                
            }

            conn.Close();
        }

        [WebMethod]
        public int VisitorLeaveCheck(string VisitorNRIC)
        {
            conn.Open();
            string query = "select count(*) from PatientVisit where VisitorNRIC = '" + VisitorNRIC + "'";
            SqlCommand com = new SqlCommand(query, conn);
            int CheckVisitorExists = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();

            return CheckVisitorExists;
        }

        [WebMethod]
        public void VisitorLeave(string VisitorNRIC)
        {
            int CheckVisitorExists = VisitorLeaveCheck(VisitorNRIC);
            conn.Open();
            if (CheckVisitorExists > 0)
            {
                string query = "Delete from PatientVisit where VisitorNRIC = '" + VisitorNRIC + "'";
                SqlCommand deleteCom = new SqlCommand(query, conn);
                deleteCom.ExecuteNonQuery();
            }
            conn.Close();
            
        }
    }

    
}
