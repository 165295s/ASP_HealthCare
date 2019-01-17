using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Data;

namespace EAD_Project.DAL
{
    public class LoginDAO
    {   
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

        static string Test = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();

        LoginObject L = new LoginObject();
        public LoginObject UserLogin(string role, string UserName)
        {

            conn.Open();
            string checkuser = "select count(*) from " + role + " where NRIC='" + UserName + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            L.User = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (L.User == 1)
            {
                conn.Open();
                string checkPasswordQuery = "select password from " + role + " where NRIC='" + UserName + "'";
                SqlCommand passCom = new SqlCommand(checkPasswordQuery, conn);
                L.password = passCom.ExecuteScalar().ToString();

                //CHRIS CODE
                //Retrieve the Salt
                string retrieveSalt = "SELECT Salt from " + role + " WHERE NRIC='" + UserName + "'";
                SqlCommand passCom_Salt = new SqlCommand(retrieveSalt, conn);
                L.salt = passCom_Salt.ExecuteScalar().ToString();


            }
            conn.Close();

            return L;
        }

        public LoginObject resetPassword(string Email, string role)
        {
            conn.Open();
            string checkEmail = "select count(*) from " + role + " where CONVERT(VARCHAR, Email) ='" + Email + "'";
            SqlCommand com = new SqlCommand(checkEmail, conn);
            L.User = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if (L.User == 1)
            {
                conn.Open();
                string getUserName = "select NRIC from " + role + " where CONVERT(VARCHAR, Email) = '" + Email + "'";
                SqlCommand UserCom = new SqlCommand(getUserName, conn);
                string username = UserCom.ExecuteScalar().ToString();
                L.UserName = UserCom.ExecuteScalar().ToString();

                Guid guid = Guid.NewGuid();
                DateTime Currenttime = DateTime.Now;
                string resetPassword = "Insert into tblResetPasswordRequests (Id, NRIC, ResetRequestDateTime) values (@paraUniqueID, @paraUserName, @paraCurrentDate)";
                SqlCommand InsertCMD = new SqlCommand(resetPassword, conn);
                InsertCMD.Parameters.AddWithValue("@paraUniqueID", guid);
                InsertCMD.Parameters.AddWithValue("@paraUserName", username);
                InsertCMD.Parameters.AddWithValue("@paraCurrentDate", Currenttime);
                InsertCMD.ExecuteNonQuery();
                L.UniqueID = guid;
            }
            conn.Close();

            return L;
        }

        public static int getDBattempts(string userId)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

            conn.Open();
            string sql = "select Retry_Attempt FROM Visitor WHERE NRIC = @username";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@username", userId);
            int h = Convert.ToInt32(command.ExecuteScalar());

            conn.Close();
            return h;
        }
        public static void plusOneToAttempt(string userId)
        {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

            int curr = getDBattempts(userId);
            int newVal = curr + 1;



            conn.Open();
            String Query = "update Visitor set Retry_Attempt=@att where NRIC=@username";
            SqlCommand UpdateCon = new SqlCommand(Query, conn);
            UpdateCon.Parameters.AddWithValue("@username", userId);
            UpdateCon.Parameters.AddWithValue("@att", newVal);

            UpdateCon.ExecuteNonQuery();
            conn.Close();


        }

        //KENNETH CODE
        public int auditLogLoginFail(string userid, DateTime TimeOfAction, string CertID, string ActionLF, string EventID, string IpAddress)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(Test))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO AuditLogs(userName, action, timeOfAction, eventsId, certifiedRollsId, IpAddress) VALUES(@userName, @action, @timeOfAction, @EventsID, @CertID, @IpAddress)"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("@userName", userid);
                            cmd.Parameters.AddWithValue("@action", ActionLF);
                            cmd.Parameters.AddWithValue("@timeOfAction", TimeOfAction);
                            cmd.Parameters.AddWithValue("@EventsID", EventID);
                            cmd.Parameters.AddWithValue("@CertID", CertID);
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

        public int auditLogLoginSuccess(string userid, DateTime TimeOfAction, string CertID, string ActionLS, string EventID, string IpAddress)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(Test))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO AuditLogs(userName, action, timeOfAction, eventsId, certifiedRollsId, IpAddress) VALUES(@userName, @action, @timeOfAction, @EventsID, @CertID, @IpAddress)"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("@userName", userid);
                            cmd.Parameters.AddWithValue("@action", ActionLS);
                            cmd.Parameters.AddWithValue("@timeOfAction", TimeOfAction);
                            cmd.Parameters.AddWithValue("@EventsID", EventID);
                            cmd.Parameters.AddWithValue("@CertID", CertID);
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

        





        //RUBBISH BELOW
        /* public void plusOneToAttempt(string userId)
         {

             int curr = getDBattempts(userId);
             int newVal = curr + 1;

             try
             {
                 using (SqlConnection con = new SqlConnection()) // parameterized queries handles sql injections!!
                 {
                     using (SqlCommand cmd = new SqlCommand("update Visitor set Retry_Attempt=@att where NRIC=@username"))
                     {
                         using (SqlDataAdapter sda = new SqlDataAdapter())
                         {

                             cmd.Parameters.AddWithValue("@username", userId);
                             cmd.Parameters.AddWithValue("@att", newVal);

                             cmd.Connection = con;
                             con.Open();
                             cmd.ExecuteNonQuery();
                             con.Close();
                         }
                     }
                 }



             }
             catch (Exception ex)
             {
             }

         }

     */

    }
}