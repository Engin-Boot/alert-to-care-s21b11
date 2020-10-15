using AlertToCareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public interface IMonitoringRepo
    {
        public string CheckVitals(Vital vital);
        public IEnumerable<Vital> GetAllVitals();
    }
}
