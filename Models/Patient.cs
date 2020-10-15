using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class Patient
    {
        public string Id { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string IcuId { get; set; }
        public string BedId  { get; set; }
        public string ContantNumber { get; set; }
    }
}
