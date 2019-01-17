using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAD_Project.Controller
{
    public class DiagnosePatientController
    {
        public void AuditLogDiagnoseSuccess(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            DiagnosePatientDAO DP = new DiagnosePatientDAO();
            DP.auditLogDiagnoseNew(UserName, TimeOfAction, EventID, Action, CertifiedRollsId, IpAddress);
        }

        public void AuditLogDiagnoseFail(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            DiagnosePatientDAO DP = new DiagnosePatientDAO();
            DP.auditLogDiagnoseNew(UserName, TimeOfAction, EventID, Action, CertifiedRollsId, IpAddress);
        }

        public void AuditLogDiagnoseDelete(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            DiagnosePatientDAO DP = new DiagnosePatientDAO();
            DP.auditLogDiagnoseDelete(UserName, TimeOfAction, EventID, Action, CertifiedRollsId, IpAddress);
        }



    }
}