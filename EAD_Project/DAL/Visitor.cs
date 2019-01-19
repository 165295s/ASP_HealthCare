using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class Visitor
    {
        public string nric { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public int mobile_number { get; set; }
        public string email { get; set; }
        public int retry_attempt { get; set; } = 0;
        public string accountLocked { get; set; } = "true" ;//TODO: not boolean? check later
        public string salt { get; set; }

    }
}