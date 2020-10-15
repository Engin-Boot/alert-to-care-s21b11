using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public class MockPatientRepo : IPatientRepo
    {
        public void AddNewPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetDetailsOfAllPatients()
        {
            var pd = new PatientAddress();
            pd.HouseNumber = "001";
            pd.City = "Delhi";
            pd.Street = "420";
            pd.LandMark = "India Gate";
            pd.State = "Delhi";
            pd.PinCode = 110091;

            var patients = new List<Patient>
            {
                new Patient{ PatientId="P001", Address=pd, Age=50, BedId="B001", ContactNumber="100", IcuId="I001", PatientName="Virat"}
            };

            return patients;
        }

        public void RemovePatient(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePatient(string id, Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
