using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Models
{
    public class Bed
    {
        public int BedId { get; set; }
        public int IcuId { get; set; }
        public bool CurrentStatus { get; set; }
    }
}
