using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class VisitorDAO
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);

        public void InsertVisitor(string nric, string name, string password, string gender, int mobileNumber, string email, string accountLocked, string salt)
        {
            con.Open();
            string query = "INSERT into Visitor(nric, name, password, gender, [mobile Number], email, accountLocked, salt) values (@paraNric, @paraName, @paraPassword, @paraGender, @paraMobileNum, @paraEmail, @paraAccountLocked, @paraSalt)";

            SqlCommand InsertCon = new SqlCommand(query, con);
            InsertCon.Parameters.AddWithValue("@paraNric", nric);
            InsertCon.Parameters.AddWithValue("@paraName", name);
            InsertCon.Parameters.AddWithValue("@paraPassword", password);
            InsertCon.Parameters.AddWithValue("@paraGender", gender);
            InsertCon.Parameters.AddWithValue("@paraMobileNum", mobileNumber);
            InsertCon.Parameters.AddWithValue("@paraEmail", email);
            InsertCon.Parameters.AddWithValue("@paraAccountLocked", accountLocked);
            InsertCon.Parameters.AddWithValue("@paraSalt", salt);

            InsertCon.ExecuteNonQuery();
            con.Close();

        }

        public void ConfirmAccount(string nric)
        {
            con.Open();
            string query = "UPDATE Visitor SET AccountLocked = 'false' WHERE nric = @paraNric";

            SqlCommand updateCon = new SqlCommand(query, con);
            updateCon.Parameters.AddWithValue("@paraNric", nric);

            updateCon.ExecuteNonQuery();
            con.Close();

        }
    }
}