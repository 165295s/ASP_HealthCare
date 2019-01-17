using EAD_Project.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EAD_Project
{
    public partial class AuditTrailLog2 : System.Web.UI.Page
    {
        AuditTrailController ATO = new AuditTrailController();

        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Session["userName"].ToString();
            string ToA = Session["ToA"].ToString();

            AuditLogTable.DataSource = ATO.GetLookupAdmin();
            AuditLogTable.DataBind();
            AuditLogTable.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        protected void ExportExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=AuditLogExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export All Pages
                AuditLogTable.AllowPaging = false;
                DataTable dt = ATO.GetLookupAdmin();
                AuditLogTable.DataSource = dt;
                AuditLogTable.DataBind();

                foreach (TableCell cell in AuditLogTable.HeaderRow.Cells)
                {
                    cell.BackColor = AuditLogTable.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in AuditLogTable.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = AuditLogTable.AlternatingRowStyle.BackColor;

                        }
                        else
                        {
                            cell.BackColor = AuditLogTable.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                AuditLogTable.RenderControl(hw);
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();


            }




        }
    }
}