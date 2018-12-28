using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EAD_Project
{
    /// <summary>
    /// Summary description for QueueService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class QueueService : System.Web.Services.WebService
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        QueueDAO qDAO = new QueueDAO();

        [WebMethod]
        public List<QueueObject> getAllUserInQ()
        {
            List<QueueObject> QList = new List<QueueObject>();
            DataTable tdData = new DataTable();
            conn.Open();

            string query = "select * from Visitor inner join QueueCheck on Visitor.NRIC = QueueCheck.VisitorNRIC order by TimeStamp";
            da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "QueueChecktbl");
            int rec_cnt = ds.Tables["QueueChecktbl"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["QueueChecktbl"].Rows)
                {
                    QueueObject Qobj2 = new QueueObject();
                    Qobj2.VisitorNRIC = row["VisitorNRIC"].ToString();
                    Qobj2.VisitorName = row["Name"].ToString();
                    Qobj2.QueueNum = Convert.ToInt32(row["QueueNum"]);
                    Qobj2.TimeStamp = Convert.ToDateTime(row["TimeStamp"]);
                    if (Qobj2.QueueNum > 0)
                    {
                        QList.Add(Qobj2);
                    }

                }

            }
            else
            {
                QList = null;
            }
            conn.Close();


            return QList;
        }

        [WebMethod]
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

        [WebMethod]
        public QueueObject retriveQDetailsByUserName(string UserName)
        {
            int QCount = qDAO.getQCnt(UserName);
            qDAO.updateQCount(UserName, QCount, QCount * 15);

            conn.Open();
            QueueObject Qobj = new QueueObject();
            string query = "Select QueueNum, pplInQueue, WaitingTime, CounterNum from QueueCheck where visitorNRIC='" + UserName + "'";
            da = new SqlDataAdapter(query, conn);
            da.Fill(ds, "queueCheckTable");
            int rec_count = ds.Tables["queueCheckTable"].Rows.Count;
            if (rec_count > 0)
            {
                DataRow row = ds.Tables["queueCheckTable"].Rows[0];
                Qobj.QueueNum = Convert.ToInt32(row["QueueNum"]);
                Qobj.pplInQueue = Convert.ToInt32(row["pplInQueue"]);
                Qobj.WaitingTime = Convert.ToInt32(row["WaitingTime"]);
                Qobj.CounterNum = Convert.ToInt32(row["CounterNum"]);
            }
            else
            {
                Qobj = null;
            }
            conn.Close();

            return Qobj;
        }

        [WebMethod]
        public List<QueueObject> getQHoldSearch(string visitorNRIC)
        {
            List<QueueObject> QList = new List<QueueObject>();
            DataTable tdData = new DataTable();
            conn.Open();

            string query = "select VisitorNRIC, Name, QueueNum, [TimeStamp] from Visitor inner join QueueOnHold on Visitor.NRIC = QueueOnHold.VisitorNRIC  where QueueNum > 0 and VisitorNRIC like '" + visitorNRIC + "' + '%' order by [TimeStamp]";
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
    }
}
