using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EAD_Project.DAL
{
    public class ChangePasswordDAO
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        bool cpResult = false;

        public bool checkUser(string guid)
        {
            bool Exist = false;
            conn.Open();
            string checkExist = "select count(*) from tblResetPasswordRequests where Id='" + guid + "'";
            SqlCommand com = new SqlCommand(checkExist, conn);
            int Check = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (Check == 1)
            {
                Exist = true;
            }
            conn.Close();
            return Exist;
        }

        //CHRIS CODE
        public bool changePassword(string guid, string password, string role)
        {
            try
            {
                conn.Open();
                string getUserName = "Select NRIC from tblResetPasswordRequests where Id='" + guid + "'";
                SqlCommand com = new SqlCommand(getUserName, conn);
                string NRIC = com.ExecuteScalar().ToString();


                //Generate a new salt 
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] saltByte = new byte[8];
                rng.GetBytes(saltByte);
                string salt = Convert.ToBase64String(saltByte);

                //Hash password with the salt 
                SHA512Managed hashing = new SHA512Managed();
                string pwdWithSalt = password + salt;
                byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                string savedPasswordHash = Convert.ToBase64String(hashWithSalt);

                //Update into DB
                string resetPass = "Update " + role + " set Password=@Password, Salt=@Salt where NRIC='" + NRIC + "'";
                SqlCommand ResetCom = new SqlCommand(resetPass, conn);
                ResetCom.Parameters.AddWithValue("@Password", savedPasswordHash);
                ResetCom.Parameters.AddWithValue("@Salt", salt);
                ResetCom.ExecuteNonQuery();

                string deleteRecord = "Delete from tblResetPasswordRequests where Id='" + guid + "'";
                SqlCommand DeleteCom = new SqlCommand(deleteRecord, conn);
                DeleteCom.ExecuteNonQuery();

                conn.Close();
                cpResult = true;
            }
            catch (Exception ex)
            {

            }
            return cpResult;
        }


        public void deleteSameRecord()
        {
            conn.Open();
            string query1 = "With ResetPasswordRequestsCTE As (Select *, ROW_NUMBER() Over(Partition By NRIC order by ResetRequestDateTime desc) as RowNumber from tblResetPasswordRequests) Delete from ResetPasswordRequestsCTE where RowNumber > 1";
            SqlCommand com = new SqlCommand(query1, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }
    }
}