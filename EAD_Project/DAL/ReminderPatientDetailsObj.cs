using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class ReminderPatientDetailsObj
    {
        public string NRIC { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        public ReminderPatientDetailsObj()
        {

        }
    }
}