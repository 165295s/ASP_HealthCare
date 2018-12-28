using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class VisitorManagementOBJ
    {
        public string VisitorNRIC { get; set; }
        public string PatientNRIC { get; set; }
        public string VisitorName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string StayDuration { get; set; }

        public VisitorManagementOBJ()
        {

        }

    }
}