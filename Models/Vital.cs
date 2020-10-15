using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class Vital
    {
        public string Id { get; set; }
        public double Bpm { get; set; }
        public double Spo2{ get; set; }
        public double RespRate { get; set; }
    }
}
