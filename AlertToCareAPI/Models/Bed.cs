﻿using System.Diagnostics.CodeAnalysis;
namespace AlertToCareAPI.Models
{
    [ExcludeFromCodeCoverage]
    
    //ReSharper disable all
    public class Bed
    {
        public int Id { get; set; }
        public string BedNo { get; set; }
        public string IcuId { get; set; }
        public bool IsOccupied { get; set; }
    }
    //ReSharper restore all
}
