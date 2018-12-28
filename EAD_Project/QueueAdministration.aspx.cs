using EAD_Project.Controller;
using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class QueueAdministration : System.Web.UI.Page
    {
        QueueAdminDAO qaDAO = new QueueAdminDAO();
        QueueAdminController qaController = new QueueAdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCounter.Text = "Counter " + Request.QueryString["Counter"];
            if (Request.QueryString["Counter"] == null)
            {
                Response.Redirect("~/MainPage.aspx");
            }

            qaController.BindDummyRow(QListGridView);

            List<QueueObject> QList2 = qaDAO.getNextUser(Convert.ToInt32(lblCounter.Text.Substring(7)));
            if (QList2 != null)
            {
                CurrentlyServedGridView.DataSource = QList2;
                CurrentlyServedGridView.DataBind();
            }

            /*List<QueueObject> QList3 = qaDAO.getQHold();
            if (QList3 != null)
            {
                OnHoldGridView.DataSource = QList3;
                OnHoldGridView.DataBind();
            }*/

            qaController.BindDummyRow(OnHoldGridView);
        }

        

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string previousVisitorNRIC = qaDAO.getPreviousVisitor(Convert.ToInt32(lblCounter.Text.Substring(7)));

            qaDAO.DeleteLastVisitor(Convert.ToInt32(lblCounter.Text.Substring(7)));
            qaDAO.GetNextVisitor(Convert.ToInt32(lblCounter.Text.Substring(7)));
            qaDAO.removeDuplicateRows();
            qaDAO.UpdateQCounterNum(Convert.ToInt32(lblCounter.Text.Substring(7)));

            qaDAO.RemoveQueueCounter(previousVisitorNRIC);
            Response.Redirect("~/QueueAdministration.aspx?Counter=" + Convert.ToInt32(lblCounter.Text.Substring(7)));
        }

        protected void btnHold_Click(object sender, EventArgs e)
        {
            qaDAO.InsertQueueHold(Convert.ToInt32(lblCounter.Text.Substring(7)));
            Response.Redirect("~/QueueAdministration.aspx?Counter=" + Convert.ToInt32(lblCounter.Text.Substring(7)));
        }

        protected void OnHoldGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            string previousVisitorNRIC = qaDAO.getPreviousVisitor(Convert.ToInt32(lblCounter.Text.Substring(7)));

            int selectRow = OnHoldGridView.SelectedIndex;
            GridViewRow theRow = OnHoldGridView.Rows[selectRow];
            string VisitorNRIC = theRow.Cells[0].Text;
            int QueueNum = Convert.ToInt32(theRow.Cells[2].Text);
            DateTime TimeStamp = Convert.ToDateTime(theRow.Cells[3].Text);
            qaDAO.ServeOnHoldQ(VisitorNRIC, QueueNum, TimeStamp, Convert.ToInt32(lblCounter.Text.Substring(7)));
            qaDAO.UpdateQCounterNum(Convert.ToInt32(lblCounter.Text.Substring(7)));

            qaDAO.RemoveQueueCounter(previousVisitorNRIC);
            Response.Redirect("~/QueueAdministration.aspx?Counter=" + Convert.ToInt32(lblCounter.Text.Substring(7)));
        }

        protected void btnServeOnHold_Click(object sender, EventArgs e)
        {
            if (qaDAO.ValidateOnHoldUser(tbInputNRIC.Text) == 0)
            {
                lblOnHoldExists.Visible = true;
                lblOnHoldExists.Text = tbInputNRIC.Text + " is not put on hold";
            }

            if (qaDAO.ValidateOnHoldUser(tbInputNRIC.Text) > 0)
            {
                lblOnHoldExists.Visible = false;
                string previousVisitorNRIC = qaDAO.getPreviousVisitor(Convert.ToInt32(lblCounter.Text.Substring(7)));

                qaDAO.ServeQHold(tbInputNRIC.Text, Convert.ToInt32(lblCounter.Text.Substring(7)));
                qaDAO.UpdateQCounterNum(Convert.ToInt32(lblCounter.Text.Substring(7)));
                qaDAO.RemoveQueueCounter(previousVisitorNRIC);

                Response.Redirect("~/QueueAdministration.aspx?Counter=" + Convert.ToInt32(lblCounter.Text.Substring(7)));
            }
        }
    }
}