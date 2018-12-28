using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class PatientVisitArrivalDAO
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        public int checkVisitorCnt(string PatientNRIC)
        {
            conn.Open();
            string query = "select count(*) from PatientVisit where PatientNRIC = '" + PatientNRIC + "'";
            SqlCommand com = new SqlCommand(query, conn);
            int VisitorCount = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();

            return VisitorCount;
        }
    }
}