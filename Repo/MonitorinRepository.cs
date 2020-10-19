using AlertToCare.Data;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Repo
{
    public class MonitorinRepository : IMonitoringRepo
    {
        private readonly DataContext _context;

        public MonitorinRepository(DataContext context)
        {
            _context = context;
        }

        public string CheckVitals(Vital vital)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vital> GetAllVitals()
        {
            var _vitals = _context.VitalsInfo.ToList();

            return _vitals;
        }
    }
}
