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
    public class DiagnosePatientDAO
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        DiagnosePatientOBJ DPobj = new DiagnosePatientOBJ();
        

        public List<DiagnosePatientOBJ> RetrivePatientNRIC()
        {
            List<DiagnosePatientOBJ> DPList = new List<DiagnosePatientOBJ>();
            con.Open();
            
            string query = "Select * from Patient";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "PatientTbl");
            int rec_cnt = ds.Tables["PatientTbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["PatientTbl"].Rows)
                {
                    DiagnosePatientOBJ DPobj2 = new DiagnosePatientOBJ();
                    DPobj2.PatientNRIC = row["NRIC"].ToString();
                    DPList.Add(DPobj2);
                }
            }
            else
            {
                DPList = null;
            }
            con.Close();
            return DPList;
        }

        public void insertDiagnosePatient(string patientNRIC)
        {
            con.Open();
            string query = "select count(*) from InsertDiagnosePatient where Id = '" + patientNRIC + "'";
            SqlCommand com = new SqlCommand(query, con);
            int CheckPatient = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (CheckPatient == 0)
            {
                string insertQuery = "Insert into InsertDiagnosePatient (Id, Diagnose_Date) values (@paraPatientNRIC, 0)";
                SqlCommand Insertcom = new SqlCommand(insertQuery, con);
                Insertcom.Parameters.AddWithValue("@paraPatientNRIC", patientNRIC);
                try
                {
                    Insertcom.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException)
                {

                }
                
            }
            con.Close();
        }

        public DiagnosePatientOBJ retrievePatientDetailsByNRIC(String PatientNRIC)
        {
            con.Open();

            
            string query = "select Name, FLOOR(DATEDIFF(DAY, DOB, GETDATE())/365.25) As Age, Gender, [Mobile Number], Email, HeartPulse, BloodPressure, Tempreture, Test, Symtoms, Chronic, Drugs, Notes from Patient p inner join InsertDiagnosePatient IDP on p.NRIC = IDP.Id where p.NRIC= '" + PatientNRIC + "'";

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "TablePatient");
            int rec_count = ds.Tables["TablePatient"].Rows.Count;
            if (rec_count > 0)
            {
                
                DataRow row = ds.Tables["TablePatient"].Rows[0];
                DPobj.Name = row["Name"].ToString();
                DPobj.Age = Convert.ToInt32(row["Age"]);
                DPobj.Gender = row["Gender"].ToString();
                DPobj.MobileNo = row["Mobile Number"].ToString();
                DPobj.Email = row["Email"].ToString();
                try
                {
                    DPobj.HeartPulse = Convert.ToInt32(row["HeartPulse"].ToString());
                    DPobj.BloodPressure = row["BloodPressure"].ToString();
                    DPobj.Tempreture = Convert.ToInt32(row["Tempreture"].ToString());

                    DPobj.Test = row["Test"].ToString(); //checkboxlist how?

                    DPobj.Symtoms = row["Symtoms"].ToString();
                    DPobj.Chronic = row["Chronic"].ToString();
                    DPobj.Drugs = row["Drugs"].ToString();
                    DPobj.Notes = row["Notes"].ToString();
                }
                catch (System.FormatException)
                {

                }
                
            }
            else
            {
                DPobj = null;
            }
            con.Close();
            return DPobj;

        }

        
        public List<DiagnosePatientOBJ> getTDbyPatientId(string PatientNRIC)
        {
            
            con.Open();
            List<DiagnosePatientOBJ> list = new List<DiagnosePatientOBJ>();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT *, FLOOR(DATEDIFF(DAY, DOB, GETDATE())/365.25) As Age From InsertDiagnosePatient i inner join Patient p on i.Id = p.NRIC where p.NRIC = '" + PatientNRIC + "'");

            
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), con);
            
            da.Fill(ds, "TableTD");

            
            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {

                foreach(DataRow row in ds.Tables["TableTD"].Rows)
                {
                    if (Convert.ToDateTime(row["Diagnose_Date"]) != Convert.ToDateTime("1 / 1 / 1900 12:00:00 AM"))
                    {
                        DiagnosePatientOBJ myTD = new DiagnosePatientOBJ();
                        myTD.PatientNRIC = row["Id"].ToString();
                        myTD.Name = row["Name"].ToString();
                        myTD.Age = Convert.ToInt32(row["Age"]);
                        myTD.Gender = row["Gender"].ToString();
                        myTD.MobileNo = row["Mobile Number"].ToString();
                        myTD.Email = row["Email"].ToString();
                        try
                        {
                            myTD.BloodPressure = row["BloodPressure"].ToString();
                            myTD.Tempreture = Convert.ToDouble(row["Tempreture"].ToString());
                            myTD.Test = row["Test"].ToString();
                            myTD.Symtoms = row["Symtoms"].ToString();
                            myTD.Chronic = row["Chronic"].ToString();
                            myTD.Drugs = row["Drugs"].ToString();
                            myTD.Notes = row["Notes"].ToString();
                            myTD.HeartPulse = Convert.ToInt32(row["HeartPulse"]);
                            myTD.Diagnose_date = Convert.ToDateTime(row["Diagnose_Date"]);
                        }
                        catch (System.FormatException)
                        {

                        }
                        list.Add(myTD);
                    }
                    
                }

                
                        
            }
            else
            {
                list = null;
            }
            con.Close();

            return list;
        }

        public DiagnosePatientOBJ FillFormbyPatientId(string PatientNRIC)
        {

            con.Open();
            DiagnosePatientOBJ myTD = new DiagnosePatientOBJ();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT *, FLOOR(DATEDIFF(DAY, DOB, GETDATE())/365.25) As Age From InsertDiagnosePatient i inner join Patient p on i.Id = p.NRIC where p.NRIC = '" + PatientNRIC + "'");


            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), con);

            da.Fill(ds, "TableTD");


            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {

                    DataRow row = ds.Tables["TableTD"].Rows[0];
                    myTD.PatientNRIC = row["Id"].ToString();
                    myTD.Name = row["Name"].ToString();
                    myTD.Age = Convert.ToInt32(row["Age"]);
                    myTD.Gender = row["Gender"].ToString();
                    myTD.MobileNo = row["Mobile Number"].ToString();
                    myTD.Email = row["Email"].ToString();
                    try
                    {
                        myTD.BloodPressure = row["BloodPressure"].ToString();
                        myTD.Tempreture = Convert.ToDouble(row["Tempreture"].ToString());
                        myTD.Test = row["Test"].ToString();
                        myTD.Symtoms = row["Symtoms"].ToString();
                        myTD.Chronic = row["Chronic"].ToString();
                        myTD.Drugs = row["Drugs"].ToString();
                        myTD.Notes = row["Notes"].ToString();
                        myTD.HeartPulse = Convert.ToInt32(row["HeartPulse"]);
                        myTD.Diagnose_date = Convert.ToDateTime(row["Diagnose_Date"]);
                    }
                    catch (System.FormatException)
                    {

                    }



            }
            else
            {
                myTD = null;
            }
            con.Close();

            return myTD;
        }


    }
}