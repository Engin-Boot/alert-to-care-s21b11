using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public interface IMonitoringRepo
    {
        public Vitals CheckVitals(string Id);
        public IEnumerable<Vitals> GetAllVitals();
    }
}
