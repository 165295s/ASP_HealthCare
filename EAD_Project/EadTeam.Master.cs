using EAD_Project.Controller;
using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class EadTeam : System.Web.UI.MasterPage
    {
        MasterPageController MC = new MasterPageController();
        MasterPageDAO dao = new MasterPageDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPageName = "";
            bool hasAccess = false;
            string role = (string)(Session["ssRole"]);

            ImgBtnLogOut.CausesValidation = false;
            if (Session["User"] != null)
            {
                LblWelcome.Text = "Welcome, " + dao.getName(Session["ssLogin"].ToString(), Session["User"].ToString());
                LblWelcome.Visible = true;
                ImgBtnLogOut.Visible = true;
                MC.ShowUserFunction(Session["User"].ToString(), form1);
            }
            MC.GetQueueCounter(form1);
            //CHRIS CODE BELOW
            try
            {
                // Every time user visits a page
                // Get his current page name
                // And make sure he has access right
                currentPageName = GetCurrentPageName();
                hasAccess = MC.GetAccessControl(role, currentPageName);
                Console.WriteLine(currentPageName);
                if (hasAccess == false)
                {
                    //CATCH ERRORS INTO ERROR LOG
                    //ErrorLog.WriteErrorLog(fullname + " tried to access a prohibited site: " + currentPageName + " \r\nWith their Administrative Status of: " + role + ".");


                    // DO NOT allow user to access this page
                    //html.Attributes.CssStyle.Add("display", "none");
                    ScriptManager.RegisterStartupScript(Page, GetType(), "AlertUnauthorised", "alert('Unathorised Access!');window.location.href='Login.aspx';", true);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ImgBtnLogOut_Click(object sender, ImageClickEventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("~/MainPage.aspx");
        }

        //CHRIS CODE BELOW
        public string GetCurrentPageName()
        {
            string urlPath = Request.Url.AbsolutePath;
            FileInfo fileInfo = new FileInfo(urlPath);
            string pageName = fileInfo.Name;
            return pageName;
        }


    }
}