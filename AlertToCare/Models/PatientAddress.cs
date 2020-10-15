using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Models
{
    public class PatientAddress
    {
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string LandMark { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
    }
}
