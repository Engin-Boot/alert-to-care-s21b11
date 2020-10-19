using AlertToCare.Data;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            _context.IcusInfo.Remove(icu);
        }
            

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
