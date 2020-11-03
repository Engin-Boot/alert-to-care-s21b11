
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

using System.Linq;

namespace AlertToCareAPI.Repo
{
    public class IcuConfigrationRepository : IIcuConfigurationRepository
    {
        private readonly DataContext _context;

        public IcuConfigrationRepository(DataContext context)
        {
            _context = context;
        }

        public void AddNewIcu(Icu icu)
        {
            /* if (icu == null)
             {
                 throw new ArgumentNullException(nameof(icu));
             }*/


            if (_context.IcusInfo.Find(icu.Id) != null)
            {

                throw new SQLiteException(SQLiteErrorCode.Constraint_PrimaryKey, "ID already exists");

            }
            if (!CheckLayoutId(icu.LayoutId))
            {
                throw new SQLiteException(SQLiteErrorCode.Constraint, "Layout Id not Registered");
            }
            else
            {
                _context.IcusInfo.Add(icu);
                _context.SaveChanges();
            }



        }
        public bool ConfigureBeds(string icuId, int bedCount)
        {
            string icu = icuId;


            if (CheckIcuIdAndBedCountIsValid(icu, bedCount))
            {
                Bed configurebeds;

                for (int i = 1; i <= bedCount; i++)
                {
                    configurebeds = new Bed();
                    configurebeds.BedNo = "B00" + i;
                    configurebeds.IcuId = icu;
                    //configurebeds.IsOccupied = 0;
                    _context.BedsInfo.Add(configurebeds);
                    _context.SaveChanges();
                    //string bedno = "B00" + i;
                    //int status = 0;
                    // _context.BedsInfo.FromSqlRaw($"INSERT INTO BedsInfo(BedNo,IcuId,IsOccupied) VALUES ({bedno},{IcuId},{status})");
                    //_context.SaveChanges();
                }


                return true;
            }
            else
            {
                return false;
            }

        }
        private bool CheckIcuIdAndBedCountIsValid(string icuId, int bedCount)
        {
            var icuList = _context.IcusInfo.ToList();
            try
            {
                icuList.First(icu => icu.Id == icuId && icu.BedCount == bedCount);
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        private bool CheckLayoutId(string layoutid)
        {
            if (_context.LayoutInfo.Find(layoutid) != null)
                return true;
            return false;
        }


        public IEnumerable<Icu> GetAllIcus()
        {
            var icUs = _context.IcusInfo.ToList();
            return icUs;
        }

        public void RemoveIcu(Icu icu)
        {
            if (icu == null)
            {
                throw new ArgumentNullException(nameof(icu));
            }


            _context.IcusInfo.Remove(icu);
        }


        /* public void UpdateIcu(Icu icu)
         {

         }*/

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); //To save changes into the database
        }

        public Icu GetIcuById(string id)
        {
            return _context.IcusInfo.Find(id);
        }
        public IEnumerable<Layout> GetAllLayouts()
        {
            return _context.LayoutInfo.ToList();
        }
    }
}
