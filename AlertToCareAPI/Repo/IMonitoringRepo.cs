using AlertToCareAPI.Models;
using System.Collections.Generic;

namespace AlertToCareAPI.Repo
{

    public interface IMonitoringRepo
    {
        public IEnumerable<Alert> GetAllActiveAlerts(string icuId);
        public bool AlertChangeStatus(string id);
        public bool RemoveAlertsOfPatient(string id);
        public IEnumerable<Bed> GetAllUnOccupiedBeds(string icuId);
        public bool SaveChanges();
    }
}
