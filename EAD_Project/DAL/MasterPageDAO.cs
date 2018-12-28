using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class MasterPageDAO
    {
        //Chris Var Declaration 
        bool hasAccess = true;
        bool pageFound = false;

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString);
        public string getName(string NRIC, string role)
        {
            conn.Open();
            string query = "select Name from " + role + " where NRIC='" + NRIC + "'";
            SqlCommand com = new SqlCommand(query, conn);
            string Name = com.ExecuteScalar().ToString();
            return Name;
        }

        //CHRIS CODE BELOW
        public bool AccessRight(string role, string currentPageName)
        {
            try
            {


                // To check user's access right
                // We need to validate against pageList.json
                // To check if the page user wants to visit
                // Is listed in the json file
                if (currentPageName != "UsersLogin" && currentPageName != "Default")
                {
                    // read JSON directly from a file
                    using (StreamReader file = new StreamReader(HttpContext.Current.Server.MapPath("./JSON/AccessControl.json")))
                    using (JsonTextReader reader = new JsonTextReader(file))
                    {
                        JObject o2 = (JObject)JToken.ReadFrom(reader);

                        var accessRight = o2["accessRight"];
                        JToken pages = null;
                        foreach (var i in accessRight)
                        {
                            var roles = i["role"].ToString();
                            if (roles == role)
                            {
                                pages = i["page"];
                                break;
                            }
                        }

                        foreach (var p in pages)
                        {
                            var individualPage = p;
                            if (p.ToString() == currentPageName)
                            {
                                hasAccess = true;
                                pageFound = true;
                                break;
                            }
                        }

                        if (pageFound == false)
                        {
                            hasAccess = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.WriteErrorLog(ex.ToString());
            }
            return hasAccess;
        }

    }
}
