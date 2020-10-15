using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public class MonitoringVitalsImpl : IMonitoringRepo
    {
        readonly string cs = @"URI=file:C:\BootCamp\CaseStudy2\alert-to-care-s22b6\test.db";
        System.Data.SQLite.SQLiteConnection con;

        public bool BpmMonitoring(int PatientId)
        {
            con = new SQLiteConnection(cs);
            con.Open();
            string stm = "select bpm from PatientInfo where id =" + PatientId;
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            bool status = false;
            if (rdr.Read())
            {
                var bpm = rdr.GetDouble(0);
                if (IndividualVitalsCheck.BpmIsOk(bpm, 70, 150) == true)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            return status;
        }

        public bool RespRateMonitoring(int PatientId)
        {

            con = new SQLiteConnection(cs);
            con.Open();
            string stm = "select respRate from PatientInfo where id =" + PatientId;
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            bool status = false;
            if (rdr.Read())
            {
                var respRate = rdr.GetDouble(0);
                if (IndividualVitalsCheck.RespRateIsOk(respRate, 30, 95) == true)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            return status;
        }

        public bool SpoMonitoring(int PatientId)
        {
            con = new SQLiteConnection(cs);
            con.Open();
            string stm = "select spo2 from PatientInfo where id =" + PatientId;
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            bool status = false;
            if (rdr.Read())
            {
                var spo2 = rdr.GetDouble(0);
                if (IndividualVitalsCheck.Spo2IsOk(spo2, 90) == true)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            return status;
        }

        public bool CheckVitalsAreOk(double Spo2, double Resprate, double Bpm)
        {
            if (IndividualVitalsCheck.Spo2AndRespRateAreOk(Spo2, Resprate) && IndividualVitalsCheck.BpmIsOk(Bpm, 70, 150))
                return true;
            return false;
        }

        public IEnumerable<Vitals> GetAllVitals()
        {
            throw new NotImplementedException();
        }
    }
}
