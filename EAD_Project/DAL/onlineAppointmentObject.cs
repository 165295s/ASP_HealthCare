using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class onlineAppointmentObject
    {
        public onlineAppointmentObject()
        {

        }
        public string doctorName { get; set; }
        public string date { get; set; }
        public string timing { get; set; }
        public string reason { get; set; }
    }
}