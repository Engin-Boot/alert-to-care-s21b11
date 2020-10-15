using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public interface IMonitoringRepo
    {
        public bool CheckVitalsAreOk(double Spo2, double Resprate, double Bpm /*string Id*/);
        public bool SpoMonitoring(int PatientId);
        public bool RespRateMonitoring(int PatientId);
        public bool BpmMonitoring(int PatientId);

        public IEnumerable<Vitals> GetAllVitals();
    }
}
