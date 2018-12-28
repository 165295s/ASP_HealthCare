using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAD_Project.DAL
{
    public class QueueObject
    {
        public string VisitorNRIC { get; set; }
        public string VisitorName { get; set; }
        public int CounterNum { get; set; }
        public int QueueNum { get; set; }
        public int pplInQueue { get; set; }
        public int WaitingTime { get; set; }
        public DateTime TimeStamp { get; set; }

        public QueueObject()
        {

        }
    }
}