﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Models
{
    public class Patient
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }
        public string IcuId { get; set; }
        public string BedId { get; set; }
        public Vitals vitals { get; set; }
        public PatientAddress Address { get; set; }


    }
}