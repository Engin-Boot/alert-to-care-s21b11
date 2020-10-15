using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    interface IMonitoringRepo
    {
        public string CheckVitals(string Id);
        public IEnumerable<Vitals> GetAllVitals();
    }
}
