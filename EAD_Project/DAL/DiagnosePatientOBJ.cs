using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class DiagnosePatientOBJ
    {
        public string PatientNRIC { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int HeartPulse { get; set; }
        public string BloodPressure { get; set; }
        public double Tempreture { get; set; }
        public string Test { get; set; }
        public string Symtoms { get; set; }
        public string Chronic { get; set; }
        public string Drugs { get; set; }
        public string Notes { get; set; }
        public DateTime Diagnose_date { get; set; }

        public DiagnosePatientOBJ()
        {

        }
    }
}