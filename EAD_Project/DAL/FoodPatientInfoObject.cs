using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class FoodPatientInfoObject
    {
        public String NRIC { get; set; }
        public int WardNo { get; set; }
        public String Condition { get; set; }
        public String Diet { get; set; }
        public String PatientName { get; set; }
    }
}