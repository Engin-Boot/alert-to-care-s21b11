using AlertToCareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Bed> BedsInfo { get; set; }
        public DbSet<Icu> IcusInfo { get; set; }
        public DbSet<Patient> PatientsInfo { get; set; }
        public DbSet<Vital> VitalsInfo { get; set; }
    }
}
