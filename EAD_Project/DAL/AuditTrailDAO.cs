using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class AuditTrailDAO
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

        public DataTable getLookup(string username, string toa) {
            conn.Open();
            DataTable dt = new DataTable();
            string cmd = "SELECT userName, action, timeOfAction FROM AuditLogs WHERE userName = @username AND timeOfAction= @TOA";
            SqlCommand InsertCMD = new SqlCommand(cmd, conn);
            InsertCMD.Parameters.AddWithValue("@username", username);
            InsertCMD.Parameters.AddWithValue("@TOA", toa);
            SqlDataReader rdr;
            rdr = InsertCMD.ExecuteReader();
            dt.Load(rdr);
            conn.Close();
            return dt;

        }
        public DataTable getLookupAdmin()
        {
            conn.Open();
            DataTable dt = new DataTable();
            string cmd = "SELECT * FROM AuditLogs";
            SqlCommand InsertCMD = new SqlCommand(cmd, conn);
            SqlDataReader rdr;
            rdr = InsertCMD.ExecuteReader();
            dt.Load(rdr);
            conn.Close();
            return dt;

        }
    }
}