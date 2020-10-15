using AlertToCareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public interface IPatientRepo
    {
        public bool AddNewPatient(Patient patient);
        public bool RemovePatient(int PatientId);
        public void UpdatePatient(int id, Patient patient);
        public bool BedStatus(string id);
        IEnumerable<Patient> GetDetailsOfAllPatients();

    }
}
