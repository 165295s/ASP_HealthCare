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
    public class MedicinePriceDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        public void insertMedicinePrice(string visitorNRIC ,decimal TotalPrice, String MedName)
        {
            con.Open();
            String Query = "Insert into MedicinePrice (VisitorNRIC,TotalPrice,Name) values (@paraVisitorNRIC,@paraTotalPrice,@paraMedName)";
            SqlCommand InsertCon = new SqlCommand(Query, con);
            InsertCon.Parameters.AddWithValue("@paraVisitorNRIC", visitorNRIC);
            InsertCon.Parameters.AddWithValue("@paraTotalPrice", TotalPrice);
            InsertCon.Parameters.AddWithValue("@paraMedName", MedName);


            InsertCon.ExecuteNonQuery();
            con.Close();


        }
        public void DeleteMedicinePrice(string visitorNRIC, String MedName)
        {
            con.Open();
            String Query = "Delete from MedicinePrice where Name=@paraMedName and VisitorNRIC=@paraVisitorNRIC";
            SqlCommand DeleteCon = new SqlCommand(Query, con);
            DeleteCon.Parameters.AddWithValue("@paraMedName", MedName);
            DeleteCon.Parameters.AddWithValue("@paraVisitorNRIC", visitorNRIC);
            DeleteCon.ExecuteNonQuery();
            con.Close();


        }

        public void DeleteAllMedicinePrice(string visitorNRIC)
        {
            con.Open();
            string sqlTrunc = "Delete from MedicinePrice where VisitorNRIC=@paraVisitorNRIC";
            SqlCommand cmd = new SqlCommand(sqlTrunc, con);
            cmd.Parameters.AddWithValue("@paraVisitorNRIC", visitorNRIC);
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public void UpdateMedicinePrice(string visitorNRIC,String MedName,Double TotalPrice)
        {

            con.Open();
            String Query = "Update MedicinePrice set Name=@paraMedName , TotalPrice=@paraTotalPrice where Name=@paraMedName and VisitorNRIC=@paraVisitorNRIC";
            SqlCommand UpdateCon = new SqlCommand(Query, con);
            UpdateCon.Parameters.AddWithValue("@paraMedName", MedName);
            UpdateCon.Parameters.AddWithValue("@paraTotalPrice", TotalPrice);
            UpdateCon.Parameters.AddWithValue("@paraVisitorNRIC", visitorNRIC);
            UpdateCon.ExecuteNonQuery();
            con.Close();


        }

        public int auditLogMedicineNew(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(DBConnect))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO auditLogs(userName, action, timeOfAction, eventsId, certifiedRollsId, IpAddress) VALUES(@userName, @action, @timeOfAction, @eventsID, @certifiedRollsId, @IpAddress)"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("@userName", UserName);
                            cmd.Parameters.AddWithValue("@action", Action);
                            cmd.Parameters.AddWithValue("@timeOfAction", TimeOfAction);
                            cmd.Parameters.AddWithValue("@eventsID", EventID);
                            cmd.Parameters.AddWithValue("@certifiedRollsId", CertifiedRollsId);
                            cmd.Parameters.AddWithValue("@IpAddress", IpAddress);

                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            return result;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public int auditLogMedicineDelete(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(DBConnect))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO auditLogs(userName, action, timeOfAction, eventsId, certifiedRollsId, IpAddress) VALUES(@userName, @action, @timeOfAction, @eventsID, @certifiedRollsId, @IpAddress)"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("@userName", UserName);
                            cmd.Parameters.AddWithValue("@action", Action);
                            cmd.Parameters.AddWithValue("@timeOfAction", TimeOfAction);
                            cmd.Parameters.AddWithValue("@eventsID", EventID);
                            cmd.Parameters.AddWithValue("@certifiedRollsId", CertifiedRollsId);
                            cmd.Parameters.AddWithValue("@IpAddress", IpAddress);

                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            return result;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public int auditLogMedicineUpdate(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(DBConnect))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO auditLogs(userName, action, timeOfAction, eventsId, certifiedRollsId, IpAddress) VALUES(@userName, @action, @timeOfAction, @eventsID, @certifiedRollsId, @IpAddress)"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("@userName", UserName);
                            cmd.Parameters.AddWithValue("@action", Action);
                            cmd.Parameters.AddWithValue("@timeOfAction", TimeOfAction);
                            cmd.Parameters.AddWithValue("@eventsID", EventID);
                            cmd.Parameters.AddWithValue("@certifiedRollsId", CertifiedRollsId);
                            cmd.Parameters.AddWithValue("@IpAddress", IpAddress);

                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            return result;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        /*public void GetMedicinePrice()
                {





                    con.Open();
                    String Query = "Select sum(TotalPrice) from MedicinePrice ";
                    SqlCommand UpdateCon = new SqlCommand(Query, con);
        //            UpdateCon.Parameters.AddWithValue("@paraMedName", MedName);
          //          UpdateCon.Parameters.AddWithValue("@paraTotalPrice", TotalPrice);

                    retrievecon.ExecuteNonQuery();
                    con.Close();


                }*/

    }
}