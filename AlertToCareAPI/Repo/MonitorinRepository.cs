using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using System;
using System.Collections.Generic;

using System.Linq;

namespace AlertToCareAPI.Repo
{
    public class MonitorinRepository : IMonitoringRepo
    {
        private readonly DataContext _context;
        public MonitorinRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Alert> GetAllActiveAlerts(string icuId)
        {
            var alertList = _context.AlertsInfo.ToList();
            try
            {
                var result = alertList.FindAll(item => item.IsActive == 1 && item.IcuId == icuId);
                return result;
            }
            catch (Exception)
            {
                return new List<Alert> {};
                 
            }

            
        }

        public IEnumerable<Bed> GetAllUnOccupiedBeds(string icuId)
        {
            var beds = _context.BedsInfo.ToList();
            try
            {
                var result = beds.FindAll(item => item.IsOccupied && item.IcuId == icuId);
                return result;
            }
            catch (Exception)
            {
                return new List<Bed> {};
            }
        }


        public bool AlertChangeStatus(string id)
        {

            var alertList = _context.AlertsInfo.ToList();
            var alert = alertList.First(item => item.Id == id);
            var x = alert.IsActive == 0 ? alert.IsActive = 1 : alert.IsActive = 0;
            //if (alert.IsActive == 0)
            //{
            //    alert.IsActive = 1;
            //}
            //else
            //{
            //    alert.IsActive = 0;
            //}

            _context.Update(alert);
            _context.SaveChanges();
            return true;
        }

        public bool RemoveAlertsOfPatient(string id)
        {
            var alertList = _context.AlertsInfo.ToList();
            var alertsToDelete = alertList.FindAll(item => item.PatientId == id);
            foreach (var alert in alertsToDelete)
            {
                _context.AlertsInfo.Remove(alert);
                _context.SaveChanges();
            }
            return true;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); //To save changes into the database
        }
    }
}
