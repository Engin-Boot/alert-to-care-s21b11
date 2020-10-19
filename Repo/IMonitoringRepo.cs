using AlertToCareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public interface IMonitoringRepo
    {
        public bool CheckVitals(Vital vital);
        Vital GetVitalsById(string id);
        public IEnumerable<Vital> GetAllVitals();
    }
}
