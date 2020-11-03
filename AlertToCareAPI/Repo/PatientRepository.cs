
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace AlertToCareAPI.Repo
{
    public class PatientRepository : IPatientRepo
    {
        private readonly DataContext _context;

        public PatientRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddNewPatient(Patient patient)
        {
            /*if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }*/
            //_context.BedsInfo.FromSqlRaw($"UPDATE BedsInfo SET IsOccupied = 1  WHERE BedNo = {patient.BedId} And IcuId={patient.IcuId}");
            if (_context.PatientsInfo.Find(patient.Id) != null)
            {

                throw new SQLiteException(SQLiteErrorCode.Constraint_PrimaryKey, "Patient ID already exists");

            }
            Bed validBedResponse = CheckValidityofPatientDetails(patient);
            if (validBedResponse == null)
            {
                return false;

            }
            else
            {
                _context.PatientsInfo.Add(patient);
                _context.SaveChanges();
                ChangeStatus(validBedResponse, true);
                return true;
            }

        }

        private Bed CheckValidityofPatientDetails(Patient patient)
        {
            Bed validBed = CheckIfBedAndIcuExists(patient);
            if (validBed != null)
            {
                if (validBed.IsOccupied == false)
                {
                    return validBed;
                }
                return null;
            }
            return null;




        }
        private Bed CheckIfBedAndIcuExists(Patient patient)
        {
            var bedsList = _context.BedsInfo.ToList();
            try
            {
                var result = bedsList.First(item => item.BedNo == patient.BedId && item.IcuId == patient.IcuId);
                return result;
            }
            catch (Exception)
            {

                return null;
            }


        }


        /* public void updateStatusofBeds(string BedId,string IcuId)
         {
        // _context.BedsInfo.FromSqlRaw($"UPDATE BedsInfo SET IsOccupied = {status}  WHERE BedNo = {BedId} And IcuId = {IcuId}");
            var BedsList= _context.BedsInfo.ToList();
            var result = BedsList.First(item => item.BedNo == BedId && item.IcuId == IcuId);
            changeStatus(result, true);
         }*/
        private void ChangeStatus(Bed bed, bool status)
        {
            bed.IsOccupied = status;
            _context.Update(bed);
            _context.SaveChanges();

        }

        public IEnumerable<Patient> GetDetailsOfAllPatients()
        {
            var patients = _context.PatientsInfo.ToList();
            return patients;
        }

        public Patient GetPatientById(string id)
        {
            return _context.PatientsInfo.Find(id);

        }


        public void RemovePatient(Patient patient, string icuId)
        {
            /* if (patient == null)
             {
                 throw new ArgumentNullException(nameof(patient));
             }*/

            //Make the bed occupied available then remove the patient
            // _context.BedsInfo.FromSqlRaw($"UPDATE BedsInfo SET IsOccupied = 0 WHERE Id = {patient.Id}");
            var bedsList = _context.BedsInfo.ToList();
            var result = bedsList.First(item => item.BedNo == patient.BedId && item.IcuId == icuId);
            ChangeStatus(result, false);
            _context.PatientsInfo.Remove(patient);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); //To save changes into the database
        }


        /*  public void UpdatePatient(Patient newpatient,Patient oldpatient)
          {
              //Nothing to do here
              var BedsList = _context.BedsInfo.ToList();
              Bed response=CheckValidityofPatientDetails(newpatient);
              if(response!=null)
              {
                  var result = BedsList.First(item => item.BedNo == oldpatient.BedId && item.IcuId == oldpatient.IcuId);
                  ChangeStatus(result, false);
                  ChangeStatus(response, true);

              }
          }*/

        public IEnumerable<Bed> GetAvailableBeds()
        {
            var bedsList = _context.BedsInfo.ToList();
            try
            {
                var availableBeds = bedsList.Where(bed => bed.IsOccupied == false);
                return availableBeds;
            }

            catch (Exception)
            {
                return null;
            }
        }
        public IEnumerable<Bed> GetSpecificIcuAvailableBeds(string icuId)
        {
            try
            {
                var bedsList = _context.BedsInfo.ToList();
                var availableBeds = bedsList.Where(bed => bed.IsOccupied == false && bed.IcuId == icuId);
                return availableBeds;
            }

            catch (Exception)
            {
                return null;
            }
        }
        public bool CheckIcuExists(string icuId)
        {
            try
            {
                var bedsList = _context.BedsInfo.ToList();
                var availableBeds = bedsList.First(item => item.IcuId == icuId);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
        public Patient GetPatientByIcuAndBed(string bedNo, string icuId)
        {


            var patientsList = _context.PatientsInfo.ToList();
            var patient = patientsList.Find(item => item.IcuId == icuId && item.BedId == bedNo);
            return patient;



        }
    }
}
