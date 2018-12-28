using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class QueueAdminDAO
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();

       

        public List<QueueObject> getNextUser(int CounterNum)
        {
            List<QueueObject> QList = new List<QueueObject>();
            DataTable tdData = new DataTable();
            QueueObject Qobj = new QueueObject();
            conn.Open();

            string query = "select top 1 VisitorNRIC, Name, QueueNum, [TimeStamp] from Visitor inner join QueueServe on Visitor.NRIC = QueueServe.VisitorNRIC where CounterNum = '" + CounterNum + "' and QueueNum > 0";
            da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "QueueServetbl");
            int rec_cnt = ds.Tables["QueueServetbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["QueueServetbl"].Rows[0];
                Qobj.VisitorNRIC = row["VisitorNRIC"].ToString();
                Qobj.VisitorName = row["Name"].ToString();
                Qobj.QueueNum = Convert.ToInt32(row["QueueNum"]);
                Qobj.TimeStamp = Convert.ToDateTime(row["TimeStamp"]);
                QList.Add(Qobj);
            }
            else
            {
                QList = null;
            }
            conn.Close();


            return QList;
        }

        public List<QueueObject> getQHold()
        {
            List<QueueObject> QList = new List<QueueObject>();
            DataTable tdData = new DataTable();
            conn.Open();

            string query = "select VisitorNRIC, Name, QueueNum, [TimeStamp] from Visitor inner join QueueOnHold on Visitor.NRIC = QueueOnHold.VisitorNRIC  where QueueNum > 0 order by [TimeStamp]";
            da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "QueueHoldtbl");
            int rec_cnt = ds.Tables["QueueHoldtbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["QueueHoldtbl"].Rows)
                {
                    QueueObject Qobj = new QueueObject();
                    Qobj.VisitorNRIC = row["VisitorNRIC"].ToString();
                    Qobj.VisitorName = row["Name"].ToString();
                    Qobj.QueueNum = Convert.ToInt32(row["QueueNum"]);
                    Qobj.TimeStamp = Convert.ToDateTime(row["TimeStamp"]);
                    QList.Add(Qobj);
                }

            }
            else
            {
                QList = null;
            }
            conn.Close();


            return QList;
        }

        public void InsertVisitor(string VisitorNRIC, int QueueNum, DateTime TimeStamp, int counterNum)
        {
            string query = "Insert into QueueServe(VisitorNRIC, QueueNum, TimeStamp, CounterNum) values (@paraVisitorNRIC, @paraQueueNum, @paraTimeStamp, @paraCounterNum)";
            SqlCommand InsertCom = new SqlCommand(query, conn);
            InsertCom.Parameters.AddWithValue("@paraVisitorNRIC", VisitorNRIC);
            InsertCom.Parameters.AddWithValue("@paraQueueNum", QueueNum);
            InsertCom.Parameters.AddWithValue("@paraTimeStamp", TimeStamp);
            InsertCom.Parameters.AddWithValue("@paraCounterNum", counterNum);
            InsertCom.ExecuteNonQuery();

        }

        public void GetNextVisitor(int CounterNum)
        {
            DataTable tdData = new DataTable();
            conn.Open();

            string query = "select Top 1 * from QueueCheck where QueueNum > 0 order by [TimeStamp]";
            da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "QueueServetb");
            int rec_cnt = ds.Tables["QueueServetb"].Rows.Count;
            if (rec_cnt > 0)
            {
                QueueObject Qobj = new QueueObject();
                DataRow row = ds.Tables["QueueServetb"].Rows[0];
                Qobj.VisitorNRIC = row["VisitorNRIC"].ToString();
                Qobj.QueueNum = Convert.ToInt32(row["QueueNum"]);
                Qobj.TimeStamp = Convert.ToDateTime(row["TimeStamp"]);

                string checkquery = "select count(*) from QueueServe where visitorNRIC='" + Qobj.VisitorNRIC + "'";
                SqlCommand com = new SqlCommand(checkquery, conn);
                int userExists = Convert.ToInt32(com.ExecuteScalar().ToString());

                if (userExists == 1)
                {
                    string deleteQuery = "Delete From QueueServe where visitorNRIC='" + Qobj.VisitorNRIC + "'";
                    SqlCommand deleteCom = new SqlCommand(deleteQuery, conn);
                    deleteCom.ExecuteNonQuery();
                }

                InsertVisitor(Qobj.VisitorNRIC, Qobj.QueueNum, Qobj.TimeStamp, CounterNum);

                string Updatequery = "Update QueueCheck set QueueNum = @paraQueueNum, pplInQueue = @parapplInQueue, WaitingTime = @paraWaitingTime , [TimeStamp] = @paraTimeStamp where visitorNRIC='" + Qobj.VisitorNRIC + "'";
                SqlCommand UpdateCom = new SqlCommand(Updatequery, conn);
                UpdateCom.Parameters.AddWithValue("@paraQueueNum", 0);
                UpdateCom.Parameters.AddWithValue("@parapplInQueue", 0);
                UpdateCom.Parameters.AddWithValue("@paraWaitingTime", 0);
                UpdateCom.Parameters.AddWithValue("@paraTimeStamp", 0);
                UpdateCom.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void InsertQueueHold(int CounterNum)
        {
            DataTable tdData = new DataTable();
            conn.Open();
            string query = "select VisitorNRIC, QueueNum, [TimeStamp] from QueueServe where CounterNum = '" + CounterNum + "'";
            da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "QueueHoldTable");
            int rec_cnt = ds.Tables["QueueHoldTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                QueueObject Qobj = new QueueObject();
                DataRow row = ds.Tables["QueueHoldTable"].Rows[0];
                Qobj.VisitorNRIC = row["VisitorNRIC"].ToString();
                Qobj.QueueNum = Convert.ToInt32(row["QueueNum"]);
                Qobj.TimeStamp = Convert.ToDateTime(row["TimeStamp"]);

                string checkquery = "select count(*) from QueueOnHold where visitorNRIC='" + Qobj.VisitorNRIC + "'";
                SqlCommand com = new SqlCommand(checkquery, conn);
                int userExists = Convert.ToInt32(com.ExecuteScalar().ToString());

                if (userExists == 1)
                {
                    string deleteQuery = "Delete From QueueOnHold where visitorNRIC='" + Qobj.VisitorNRIC + "'";
                    SqlCommand deleteCom = new SqlCommand(deleteQuery, conn);
                    deleteCom.ExecuteNonQuery();
                }

                string InsertQuery = "Insert into QueueOnHold(VisitorNRIC, QueueNum, TimeStamp, CounterNum) values (@paraVisitorNRIC, @paraQueueNum, @paraTimeStamp, @paraCounterNum)";
                SqlCommand InsertCom = new SqlCommand(InsertQuery, conn);
                InsertCom.Parameters.AddWithValue("@paraVisitorNRIC", Qobj.VisitorNRIC);
                InsertCom.Parameters.AddWithValue("@paraQueueNum", Qobj.QueueNum);
                InsertCom.Parameters.AddWithValue("@paraTimeStamp", Qobj.TimeStamp);
                InsertCom.Parameters.AddWithValue("@paraCounterNum", CounterNum);
                InsertCom.ExecuteNonQuery();

                string Updatequery = "Update QueueServe set QueueNum = @paraQueueNum, [TimeStamp] = @paraTimeStamp, CounterNum = @paraCounterNum where visitorNRIC='" + Qobj.VisitorNRIC + "'";
                SqlCommand UpdateCom = new SqlCommand(Updatequery, conn);
                UpdateCom.Parameters.AddWithValue("@paraQueueNum", 0);
                UpdateCom.Parameters.AddWithValue("@paraTimeStamp", 0);
                UpdateCom.Parameters.AddWithValue("@paraCounterNum", 0);
                UpdateCom.ExecuteNonQuery();
            }

            conn.Close();
        }

        public void ServeOnHoldQ(string VisitorNRIC, int QueueNum, DateTime TimeStamp, int CounterNum)
        {
            conn.Open();
            string checkquery = "select count(*) from QueueServe where visitorNRIC='" + VisitorNRIC + "'";
            SqlCommand com = new SqlCommand(checkquery, conn);
            int userExists = Convert.ToInt32(com.ExecuteScalar().ToString());

            if (userExists == 1)
            {
                string deleteQuery = "Delete From QueueServe where visitorNRIC='" + VisitorNRIC + "'";
                SqlCommand deleteCom = new SqlCommand(deleteQuery, conn);
                deleteCom.ExecuteNonQuery();
            }
            string checkquery2 = "select count(*) from QueueServe where CounterNum='" + CounterNum + "'";
            SqlCommand com2 = new SqlCommand(checkquery2, conn);
            int CounterExists = Convert.ToInt32(com2.ExecuteScalar().ToString());

            if (CounterExists == 1)
            {
                string deleteQuery = "Delete From QueueServe where CounterNum='" + CounterNum + "'";
                SqlCommand deleteCom = new SqlCommand(deleteQuery, conn);
                deleteCom.ExecuteNonQuery();
            }


            InsertVisitor(VisitorNRIC, QueueNum, TimeStamp, CounterNum);

            string Updatequery = "Update QueueOnHold set QueueNum = @paraQueueNum, [TimeStamp] = @paraTimeStamp, CounterNum = @paraCounterNum where visitorNRIC='" + VisitorNRIC + "'";
            SqlCommand UpdateCom = new SqlCommand(Updatequery, conn);
            UpdateCom.Parameters.AddWithValue("@paraQueueNum", 0);
            UpdateCom.Parameters.AddWithValue("@paraTimeStamp", 0);
            UpdateCom.Parameters.AddWithValue("@paraCounterNum", 0);
            UpdateCom.ExecuteNonQuery();

            conn.Close();
        }

        public void removeDuplicateRows()
        {
            conn.Open();
            string query = "With QueueCTE As (Select *, ROW_NUMBER() Over(Partition By CounterNum order by [TimeStamp] desc) as RowNumber from QueueServe) Delete from QueueCTE where RowNumber > 1";
            SqlCommand com = new SqlCommand(query, conn);
            com.ExecuteNonQuery();
            conn.Close();
        }


        public void UpdateQCounterNum(int CounterNum)
        {
            conn.Open();
            string selectQuery = "select VisitorNRIC from QueueServe where CounterNum = '" + CounterNum + "'";
            SqlCommand com = new SqlCommand(selectQuery, conn);
            try
            {
                string VisitorNRIC = com.ExecuteScalar().ToString();
                string UpdateQuery = "Update QueueCheck set CounterNum = @paraCounterNum where VisitorNRIC = '" + VisitorNRIC + "'";
                SqlCommand UpdateCom = new SqlCommand(UpdateQuery, conn);
                UpdateCom.Parameters.AddWithValue("@paraCounterNum", CounterNum);
                UpdateCom.ExecuteNonQuery();
                conn.Close();
                
            }
            catch (NullReferenceException)
            {
                
            }

            conn.Close();

        }

        public string getPreviousVisitor(int CounterNum)
        {
            conn.Open();
            string VisitorNRIC = "";
            string selectQuery = "select VisitorNRIC from QueueServe where CounterNum = '" + CounterNum + "'";
            SqlCommand com = new SqlCommand(selectQuery, conn);
            try
            {
                VisitorNRIC = com.ExecuteScalar().ToString();
                conn.Close();
            }
            catch (NullReferenceException)
            {
                VisitorNRIC = "";
            }
            conn.Close();
            return VisitorNRIC;
        }

        public void RemoveQueueCounter(string VisitorNRIC)
        {
            conn.Open();

            string checkquery = "select count(*) from QueueServe where visitorNRIC='" + VisitorNRIC + "'";
            SqlCommand com1 = new SqlCommand(checkquery, conn);
            int userExists = Convert.ToInt32(com1.ExecuteScalar().ToString());

            if (userExists == 0)
            {
                string UpdateQuery = "Update QueueCheck set CounterNum = @paraCounterNum where VisitorNRIC = '" + VisitorNRIC + "'";
                SqlCommand UpdateCom = new SqlCommand(UpdateQuery, conn);
                UpdateCom.Parameters.AddWithValue("@paraCounterNum", 0);
                UpdateCom.ExecuteNonQuery();
            }

            conn.Close();
            
        }

        public void DeleteLastVisitor(int CounterNum)
        {
            conn.Open();
            string query = "select count(*) from QueueCheck where QueueNum > 0";
            SqlCommand com = new SqlCommand(query, conn);
            int Exists = Convert.ToInt32(com.ExecuteScalar().ToString());

            if (Exists == 0)
            {
                string deleteQuery = "delete from QueueServe where CounterNum = '" + CounterNum + "'";
                SqlCommand DeleteCom = new SqlCommand(deleteQuery, conn);
                DeleteCom.ExecuteNonQuery();
            }
            conn.Close();
        }

        public int ValidateOnHoldUser(string nric)
        {
            conn.Open();
            string query = "select count(*) from QueueOnHold where VisitorNRIC = '" + nric + "' and QueueNum > 0";
            SqlCommand com = new SqlCommand(query, conn);
            int Exists = Convert.ToInt32(com.ExecuteScalar().ToString());
            conn.Close();
            return Exists;
        }

        public void ServeQHold(string NRIC, int CounterNum)
        {
            conn.Open();
            string selectQuery = "select VisitorNRIC, Name, QueueNum, [TimeStamp] from Visitor inner join QueueOnHold on QueueOnHold.VisitorNRIC = Visitor.NRIC where VisitorNRIC = '" + NRIC + "'";
            da = new SqlDataAdapter(selectQuery, conn);
            da.Fill(ds, "QueueServeHoldTbl");
            int rec_cnt = ds.Tables["QueueServeHoldTbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                QueueObject Qobj = new QueueObject();
                DataRow row = ds.Tables["QueueServeHoldTbl"].Rows[0];
                Qobj.VisitorNRIC = row["VisitorNRIC"].ToString();
                Qobj.VisitorName = row["Name"].ToString();
                Qobj.QueueNum = Convert.ToInt32(row["QueueNum"]);
                Qobj.TimeStamp = Convert.ToDateTime(row["TimeStamp"]);

                string checkquery = "select count(*) from QueueServe where visitorNRIC='" + Qobj.VisitorNRIC + "'";
                SqlCommand com = new SqlCommand(checkquery, conn);
                int userExists = Convert.ToInt32(com.ExecuteScalar().ToString());

                if (userExists == 1)
                {
                    string deleteQuery = "Delete From QueueServe where visitorNRIC='" + Qobj.VisitorNRIC + "'";
                    SqlCommand deleteCom = new SqlCommand(deleteQuery, conn);
                    deleteCom.ExecuteNonQuery();
                }

                string checkquery2 = "select count(*) from QueueServe where CounterNum='" + CounterNum + "'";
                SqlCommand com2 = new SqlCommand(checkquery2, conn);
                int CounterExists = Convert.ToInt32(com2.ExecuteScalar().ToString());

                if (CounterExists == 1)
                {
                    string deleteQuery = "Delete From QueueServe where CounterNum='" + CounterNum + "'";
                    SqlCommand deleteCom = new SqlCommand(deleteQuery, conn);
                    deleteCom.ExecuteNonQuery();
                }


                InsertVisitor(Qobj.VisitorNRIC, Qobj.QueueNum, Qobj.TimeStamp, CounterNum);

                string Updatequery = "Update QueueOnHold set QueueNum = @paraQueueNum, [TimeStamp] = @paraTimeStamp, CounterNum = @paraCounterNum where visitorNRIC='" + Qobj.VisitorNRIC + "'";
                SqlCommand UpdateCom = new SqlCommand(Updatequery, conn);
                UpdateCom.Parameters.AddWithValue("@paraQueueNum", 0);
                UpdateCom.Parameters.AddWithValue("@paraTimeStamp", 0);
                UpdateCom.Parameters.AddWithValue("@paraCounterNum", 0);
                UpdateCom.ExecuteNonQuery();

            }
            conn.Close();
        }
    }
}