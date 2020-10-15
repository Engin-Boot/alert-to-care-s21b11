using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    interface IPatientRepo
    {
        void AddNewPatient(Patient patient);
        void RemovePatient(string id);
        void UpdatePatient(string id, Patient patient);
        IEnumerable<Patient> GetDetailsOfAllPatients();

    }
}
