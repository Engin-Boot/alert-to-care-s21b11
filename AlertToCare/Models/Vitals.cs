using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Models
{
    public class Vitals
    {
        public int PatientId { get; set; }
        public double Bpm { get; set; }
        public double Spo2 { get; set; }
        public double RespRate { get; set; }
    }
}
