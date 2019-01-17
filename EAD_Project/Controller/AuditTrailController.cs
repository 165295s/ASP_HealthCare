using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EAD_Project.Controller
{
    public class AuditTrailController
    {
        AuditTrailDAO AT = new AuditTrailDAO();
        public DataTable GetLookup(string userName, string TOA) {
            return AT.getLookup(userName, TOA);
        }
        public DataTable GetLookupAdmin()
        {
            return AT.getLookupAdmin();
        }
    }
}