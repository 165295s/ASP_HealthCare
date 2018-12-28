using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class ReminderNurseObject
    {
        public string Medicine { get; set; }
        public string Duration { get; set; }
        public string Notes { get; set; }
        public string NRIC { get; set; }
        public string Name { get; set; }
        public string NurseName { get; set; }
        public string NurseEmail { get; set; }
        public int NurseMobileNo { get; set; }
    }
}