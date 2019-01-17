using EAD_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EAD_Project.Controller
{
    public class MedicineOnlineController
    {
        public void AuditLogMedicineSuccess(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            MedicinePriceDAO MP = new MedicinePriceDAO();
            MP.auditLogMedicineNew(UserName, TimeOfAction, EventID, Action, CertifiedRollsId, IpAddress);
        }

        public void AuditLogMedicineFail(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            MedicinePriceDAO MP = new MedicinePriceDAO();
            MP.auditLogMedicineNew(UserName, TimeOfAction, EventID, Action, CertifiedRollsId, IpAddress);
        }

        public void AuditLogMedicineDelete(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            MedicinePriceDAO MP = new MedicinePriceDAO();
            MP.auditLogMedicineDelete(UserName, TimeOfAction, EventID, Action, CertifiedRollsId, IpAddress);
        }

        public void AuditLogMedicineUpdate(string UserName, DateTime TimeOfAction, string EventID, string Action, string CertifiedRollsId, string IpAddress)
        {
            MedicinePriceDAO MP = new MedicinePriceDAO();
            MP.auditLogMedicineUpdate(UserName, TimeOfAction, EventID, Action, CertifiedRollsId, IpAddress);
        }
    }
}