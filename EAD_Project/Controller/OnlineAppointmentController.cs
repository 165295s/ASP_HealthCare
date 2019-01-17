using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAD_Project.Controller
{
    public class OnlineAppointmentController
    {
        public void AuditLogAppointmentSuccess(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            OnlineAppointmentDAO OA = new OnlineAppointmentDAO();
            OA.auditLogAppointmentNew(UserName, TimeOfAction, EventID, Action, CertifiedRollsId, IpAddress);
        }

        public void AuditLogAppointmentFail(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            OnlineAppointmentDAO OA = new OnlineAppointmentDAO();
            OA.auditLogAppointmentNew(UserName, TimeOfAction, EventID, Action, CertifiedRollsId, IpAddress);
        }
    }
}