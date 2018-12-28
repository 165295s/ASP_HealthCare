using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class InsertDiagnosePatientDAO
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

        public void InsertDiagnose(String PatientNRIC, int HeartPulse, string BloodPressure, double Tempreture, string Checkitems, string Symtoms, string Chronic, string Drugs, string Notes)
        {
            con.Open();
           string query = "Insert into InsertDiagnosePatient (Id, HeartPulse, BloodPressure, Tempreture, Test, Symtoms, Chronic, Drugs, Notes, Diagnose_Date) values (@paraPatientNRIC, @paraHeartPulse, @paraBloodPressure, @paraTempreture, @paraTest, @paraSymtoms, @paraChronic, @paraDrugs, @paraNotes, GETDATE())";
           SqlCommand InsertCom = new SqlCommand(query, con);
           InsertCom.Parameters.AddWithValue("@paraPatientNRIC", PatientNRIC);
           InsertCom.Parameters.AddWithValue("@paraHeartPulse", HeartPulse);
           InsertCom.Parameters.AddWithValue("@paraBloodPressure", BloodPressure);
           InsertCom.Parameters.AddWithValue("@paraTempreture", Tempreture);
           InsertCom.Parameters.AddWithValue("@paraTest", Checkitems);
           InsertCom.Parameters.AddWithValue("@paraSymtoms", Symtoms);
           InsertCom.Parameters.AddWithValue("@paraChronic", Chronic);
           InsertCom.Parameters.AddWithValue("@paraDrugs", Drugs);
           InsertCom.Parameters.AddWithValue("@paraNotes", Notes);
           InsertCom.ExecuteNonQuery();
           con.Close();
        }

        public void DeleteDiagnose(String PatientNRIC)
        {
            con.Open();
            string Checkquery = "Delete from InsertDiagnosePatient where Id = '" + PatientNRIC + "'";
            SqlCommand CheckCom = new SqlCommand(Checkquery, con);
            CheckCom.ExecuteNonQuery();

            con.Close();
        }

        public void DeleteDiagnoseByRow(String PatientNRIC, String DiagnoseDateTime)
        {
            con.Open();
            string Checkquery = "Delete from InsertDiagnosePatient where Id = '" + PatientNRIC + "' AND Diagnose_Date = '" + Convert.ToDateTime(DiagnoseDateTime).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            SqlCommand CheckCom = new SqlCommand(Checkquery, con);
            CheckCom.ExecuteNonQuery();

            con.Close();
        }

    }
}