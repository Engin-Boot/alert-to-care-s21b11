using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public class PatientDetailsImpl : IPatientRepo
    {
        readonly string cs = @"URI=file:C:\BootCamp\CaseStudy2\alert-to-care-s22b6\test.db"; 
        public IEnumerable<Patient> GetDetailsOfAllPatients()
        {
            throw new NotImplementedException();
        }

        public bool AddNewPatient(Patient patient)
        {
            if(patient != null)
            {
                using var con = new SQLiteConnection(cs);
                con.Open();
                using var cmd = new SQLiteCommand(con);
                cmd.CommandText = "INSERT INTO PatientInfo(name, address,Age,ContactNumber, IcuId,BedId) " +
                    "VALUES('" + patient.PatientName + "','" + patient.Address + "','"
                    + patient.Age + "'," + patient.ContactNumber + "," + patient.IcuId + "," + patient.BedId + "," +
                    patient.Vital + "')";

                //Check above format mainly for vitals how to take it?
                cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }
                
        public bool RemovePatient(int PatientId)
        {
            Patient _patient = new Patient();
            if(_patient != null)
            {
                using var con = new SQLiteConnection(cs);
                con.Open();
                using var cmd = new SQLiteCommand(con);
                cmd.CommandText = "DELETE FROM PatientInfo WHERE PatientId = " + PatientId;
                return true;
            }
            return false;
        }

        public void UpdatePatient(int id, Patient patient)
        {
            throw new NotImplementedException();
        }
        public bool BedStatus(string id)
        {
            using var con = new SQLiteConnection(cs);
            con.Open();
            string stm = "select name from patientsDetails where bedId =" + id;
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            string status = null;
            if (rdr.Read())
            {
                status = rdr.GetString(0);
            }

            if (status != null)
            {
                return true;
            }
            return false;
        }
    }
}
