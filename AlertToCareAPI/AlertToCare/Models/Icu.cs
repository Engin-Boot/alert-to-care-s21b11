using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Models
{
    public class Icu
    {
        public string IcuId { get; set; }
        public string LayoutId { get; set; }

        public int BedCount { get; set; }
        public List<Bed> Beds { get; set; }
    }
}
