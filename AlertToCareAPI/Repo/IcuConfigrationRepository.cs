using AlertToCare.Data;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AlertToCareAPI.Repo
{
    public class IcuConfigrationRepository : IIcuConfigRepo
    {
        private readonly DataContext _context;

        public IcuConfigrationRepository(DataContext context)
        {
            _context = context;
        }

        public void AddNewIcu(Icu icu)
        {
            if (icu == null)
            {
                throw new ArgumentNullException(nameof(icu));
            }
            _context.IcusInfo.Add(icu);
            _context.SaveChanges();
        }

      
        public IEnumerable<Icu> GetAllIcus()
        {
            var ICUs = _context.IcusInfo.ToList();
            return ICUs;
        }

        public void RemoveIcu(Icu icu)
        {
            if (icu == null)
            {
                throw new ArgumentNullException(nameof(icu));
            }
            /*
            //If beds of the Icu are occupied throw an exception
            var occupiedBeds = _context.PatientsInfo.FromSqlRaw($"SELECT * FROM PatientsInfo WHERE IcuId = {icu.Id}").ToList();

            if (occupiedBeds.Count() > 0)
            {
                throw new Exception("ICU cann't be removed still got some occupied beds !!");
            }
            //Remove the beds of the corresponding ICU from the bed table
            _context.BedsInfo.FromSqlRaw($"DELETE FROM BedsInfo WHERE IcuId = {icu.Id}");
            */

            _context.IcusInfo.Remove(icu);
        }

        [ExcludeFromCodeCoverage]
        public void UpdateIcu(Icu icu)
        {
            //Phew ... Nothing to do here
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); //To save changes into the database
        }

        public Icu GetIcuById(string id)
        {
            return _context.IcusInfo.Find(id);
        }
    }
}
