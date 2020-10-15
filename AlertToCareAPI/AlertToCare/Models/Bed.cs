using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Models
{
    public class Bed
    {
        public string BedId { get; set; }
        public string IcuId { get; set; }
        public bool CurrentStatus { get; set; }
    }
}
