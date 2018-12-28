using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class QueueCheck : System.Web.UI.Page
    {
        QueueDAO qDAO = new QueueDAO();
        QueueObject Qobj = new QueueObject();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ssLogin"] == null || Session["User"].ToString() != "Visitor")
                {
                    Session["ssRole"] = "Visitor";
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch (NullReferenceException)
            {
                Session["ssRole"] = "Visitor";
                Response.Redirect("~/Login.aspx");
            }

            lblHiddenUser.Text = Session["ssLogin"].ToString();
            lblHiddenUser.Style["display"] = "none";
            qDAO.insertUser(Session["ssLogin"].ToString());

            Qobj = qDAO.retriveQDetailsByUserName(Session["ssLogin"].ToString());
            tbQueueNo.Text = Qobj.QueueNum.ToString();
            tbNumBefore.Text = Qobj.pplInQueue.ToString();

            if (tbQueueNo.Text != 0.ToString() || qDAO.getQCounter(Session["ssLogin"].ToString()) != 0)
            {
                btnTakeQueue.Enabled = false;
            }
            if (Qobj.WaitingTime > 0)
            {
                TimeSpan span = TimeSpan.FromMinutes(Qobj.WaitingTime);
                lblDirection.Text = "You have to wait for " + decimal.ToInt32(Convert.ToDecimal(span.TotalHours)) + "hours " + span.Minutes + "mins";
            }else if (Qobj.WaitingTime <= 0 && Qobj.QueueNum > 0)
            {
                lblDirection.Text = "Please make your way down to BayHealth Hospital";
            }

            int QCounterNum = qDAO.getQCounter(Session["ssLogin"].ToString());
            if (QCounterNum != 0)
            {
                lblCounter.Text = "It is your turn, please go to counter " + QCounterNum;
            }

            if (btnTakeQueue.Enabled == true)
            {
                btnLeaveQueue.Enabled = false;
            }
            else if (btnTakeQueue.Enabled == false)
            {
                btnLeaveQueue.Enabled = true;
            }
        }

        protected void btnTakeQueue_Click(object sender, EventArgs e)
        {
            if (tbQueueNo.Text == 0.ToString())
            {
                int MaxQNum = qDAO.getMaxQNum() + 1;
                tbQueueNo.Text = MaxQNum.ToString();
            }
            
            qDAO.updateQDetailsByUserName(Session["ssLogin"].ToString(), Convert.ToInt32(tbQueueNo.Text));
            int QCount = qDAO.getQCnt(Session["ssLogin"].ToString());
            tbNumBefore.Text = QCount.ToString();
            Response.Redirect("~/QueueCheck.aspx");
        }

        protected void btnLeaveQueue_Click(object sender, EventArgs e)
        {
            qDAO.LeaveQueue(Session["ssLogin"].ToString());
            Response.Redirect("~/QueueCheck.aspx");
        }
    }
}