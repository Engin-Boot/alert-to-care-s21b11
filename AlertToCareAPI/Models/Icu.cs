using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class Icu
    {
        public string Id { get; set; }
        public int BedCount { get; set; }
        public string LayoutId { get; set; }
    }
}
