using AlertToCareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public interface IPatientRepo
    {
        bool SaveChanges();

        Patient GetPatientById(string id);
        public void AddNewPatient(Patient patient);
        public void RemovePatient(Patient patient);
        public void UpdatePatient(Patient patient);
        IEnumerable<Patient> GetDetailsOfAllPatients();

    }
}
