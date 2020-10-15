using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public class MockVitalsRepo : IMonitoringRepo
    {
        public IEnumerable<Vitals> GetAllVitals()
        {
            var vitals = new List<Vitals>
            {
                new Vitals { PatientId = "P001", Bpm = 78, RespRate = 100, Spo2 = 98.01 },
                new Vitals { PatientId = "P002", Bpm = 79, RespRate = 101, Spo2 = 98.02 },
                new Vitals { PatientId = "P003", Bpm = 80, RespRate = 102, Spo2 = 98.03 },
                new Vitals { PatientId = "P004", Bpm = 81, RespRate = 103, Spo2 = 98.04 }
            };


            return vitals;
        }

       public  Vitals CheckVitals(string Id)
        {
            return new Vitals { PatientId = "P001", Bpm = 78, RespRate = 100, Spo2 = 98.01 };
        }
    }
}
