using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    public class Bed
    {
        public string  Id { get; set; }
        public string  IcuId { get; set; }
        public bool IsOccupied { get; set; }
    }
}
