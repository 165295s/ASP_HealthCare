using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class QueueDAO
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        QueueObject Qobj = new QueueObject();
        
        public void insertUser(string UserName)
        {
            conn.Open();
            string query = "select count(*) from QueueCheck where visitorNRIC='" + UserName + "'";
            SqlCommand com = new SqlCommand(query, conn);
            int userExists = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            if(userExists == 0)
            {
                conn.Open();
                string query2 = "Insert into QueueCheck (VisitorNRIC, QueueNum, pplInQueue, WaitingTime) values (@paraVisitorNRIC, @paraQueueNum, @parapplInQueue, @paraWaitingTime)";
                SqlCommand InsertCom = new SqlCommand(query2, conn);
                InsertCom.Parameters.AddWithValue("@paraVisitorNRIC", UserName);
                InsertCom.Parameters.AddWithValue("@paraQueueNum", 0);
                InsertCom.Parameters.AddWithValue("@parapplInQueue", 0);
                InsertCom.Parameters.AddWithValue("@paraWaitingTime", -1);
                InsertCom.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void updateQDetailsByUserName(string UserName, int queueNum)
        {
            conn.Open();
            string query = "Update QueueCheck set QueueNum = @paraQueueNum, TimeStamp=@paraTimeStamp, CounterNum = @paraCounterNum where visitorNRIC='" + UserName + "'";
            SqlCommand updateCom = new SqlCommand(query, conn);
            updateCom.Parameters.AddWithValue("@paraQueueNum", queueNum);
            updateCom.Parameters.AddWithValue("@paraTimeStamp", DateTime.Now);
            updateCom.Parameters.AddWithValue("@paraCounterNum", 0);
            updateCom.ExecuteNonQuery();
            conn.Close();
        }

        public void updateQCount(string UserName, int pplInQueue, int WaitingTime)
        {
            conn.Open();
            string query = "Update QueueCheck set pplInQueue = @parapplInQueue, WaitingTime=@paraWaitingTime where visitorNRIC='" + UserName + "'";
            SqlCommand updateCom = new SqlCommand(query, conn);
            updateCom.Parameters.AddWithValue("@parapplInQueue", pplInQueue);
            updateCom.Parameters.AddWithValue("@paraWaitingTime", WaitingTime);
            updateCom.ExecuteNonQuery();
            conn.Close();
        }

        public QueueObject retriveQDetailsByUserName(string UserName)
        {
            int QCount = getQCnt(UserName);
            updateQCount(UserName, QCount, QCount * 15);

            conn.Open();
            string query = "Select QueueNum, pplInQueue, WaitingTime from QueueCheck where visitorNRIC='" + UserName + "'";
            da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "queueCheckTable");
            int rec_count = ds.Tables["queueCheckTable"].Rows.Count;
            if (rec_count > 0)
            {
                DataRow row = ds.Tables["queueCheckTable"].Rows[0];
                Qobj.QueueNum = Convert.ToInt32(row["QueueNum"]);
                Qobj.pplInQueue = Convert.ToInt32(row["pplInQueue"]);
                Qobj.WaitingTime = Convert.ToInt32(row["WaitingTime"]);
            }
            else
            {
                Qobj = null;
            }
            conn.Close();

            return Qobj;
        }

        public int getQCnt(string UserName)
        {
            conn.Open();
            string query = "select count(*) from QueueCheck where QueueNum > 0 AND QueueNum < (select QueueNum from QueueCheck where VisitorNRIC='" + UserName + "')";
            SqlCommand com = new SqlCommand(query, conn);
            int Qcount = Convert.ToInt32(com.ExecuteScalar());
            conn.Close();
            return Qcount;
        }



        public int getMaxQNum()
        {
            conn.Open();
            string query = "Select max(QueueNum) from QueueCheck";
            SqlCommand com = new SqlCommand(query, conn);
            int MaxQNum = Convert.ToInt32(com.ExecuteScalar());
            conn.Close();
            return MaxQNum;

        }

        public int getQCounter(string username)
        {
            conn.Open();
            string query = "select CounterNum from QueueCheck where VisitorNRIC = '" + username + "'";
            SqlCommand com = new SqlCommand(query, conn);
            int counterNum = Convert.ToInt32(com.ExecuteScalar());
            conn.Close();
            return counterNum;
        }

        //Leave queue
        public void LeaveQueue(string username)
        {
            conn.Open();
            string query = "Update QueueCheck set pplInQueue = @parapplInQueue, WaitingTime=@paraWaitingTime, CounterNum=@paraCounterNum, QueueNum=@paraQueueNum, [TimeStamp]=@paraTimeStamp where visitorNRIC='" + username + "'";
            SqlCommand updateCom = new SqlCommand(query, conn);
            updateCom.Parameters.AddWithValue("@parapplInQueue", 0);
            updateCom.Parameters.AddWithValue("@paraWaitingTime", 0);
            updateCom.Parameters.AddWithValue("@paraCounterNum", 0);
            updateCom.Parameters.AddWithValue("@paraQueueNum", 0);
            updateCom.Parameters.AddWithValue("@paraTimeStamp", 0);
            updateCom.ExecuteNonQuery();

            string query2 = "Update QueueOnHold set QueueNum=@paraQueueNum, CounterNum=@paraCounterNum, [TimeStamp]=@paraTimeStamp where visitorNRIC='" + username + "'";
            SqlCommand updateCom2 = new SqlCommand(query2, conn);
            updateCom2.Parameters.AddWithValue("@paraCounterNum", 0);
            updateCom2.Parameters.AddWithValue("@paraQueueNum", 0);
            updateCom2.Parameters.AddWithValue("@paraTimeStamp", 0);
            updateCom2.ExecuteNonQuery();


            string Checkquery = "select count(*) from QueueServe where VisitorNRIC='" + username + "'";
            SqlCommand com = new SqlCommand(Checkquery, conn);
            int check = Convert.ToInt32(com.ExecuteScalar());
            if (check == 1)
            {
                string DeleteQuery = "Delete from QueueServe where VisitorNRIC='" + username + "'";
                SqlCommand DeleteCom = new SqlCommand(DeleteQuery, conn);
                DeleteCom.ExecuteNonQuery();
            }
            conn.Close();
        }

    }
}