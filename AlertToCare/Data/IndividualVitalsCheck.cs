using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public static class IndividualVitalsCheck
    {
        public static bool BpmIsOk(double bpm, double minBpm, double maxBpm)
        {
            if (bpm < minBpm || bpm > maxBpm)
                return false;
            return true;
        }

        public static bool Spo2IsOk(double spo2, double minSpo2)
        {
            if (spo2 < minSpo2)
                return false;
            return true;
        }
        public static bool RespRateIsOk(double respRate, double minRespRate, double maxRespRate)
        {
            if (respRate < minRespRate || respRate > maxRespRate)
                return false;
            return true;
        }

        public static bool Spo2AndRespRateAreOk(double spo2, double Resprate)
        {
            if (Spo2IsOk(spo2, 90) && RespRateIsOk(Resprate, 30, 95))
                return true;
            return false;
        }
    }
}
