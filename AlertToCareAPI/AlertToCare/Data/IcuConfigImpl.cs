using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public class IcuConfigImpl : IIcuConfigRepo
    {
        readonly string cs = @"URI=file:C:\BootCamp\CaseStudy2\alert-to-care-s22b6\test.db"; //Path to database file
        System.Data.SQLite.SQLiteConnection con;
        System.Data.SQLite.SQLiteCommand cmd;

        public bool AddNewIcu(Icu icu)
        {
            if (icu != null)
            {
                con = new SQLiteConnection(cs);
                con.Open();
                cmd = new SQLiteCommand(con);
                cmd.CommandText = "INSERT INTO Icu(Bed_Count, LayOut) VALUES('"+ icu.BedCount + "','"+ icu.LayoutId+"')" ;
                return true;
            }
            return false;
        }

        public IEnumerable<Icu> GetAllIcus()
        {
            throw new NotImplementedException();
        }

        public bool RemoveIcu(Icu icu, string Id)
        {
            if(icu != null)
            {
                con = new SQLiteConnection(cs);
                con.Open();
                cmd.CommandText = "DELETE FROM Icu WHERE IcuId = "+ Id;
                return true;
            }
            return false;
        }

        /*
         * public bool UpdateIcu(string id, Icu icu)
        {
            if (icu != null)
            {
                con = new SQLiteConnection(cs);
                con.Open();
                cmd.CommandText = "DELETE FROM Icu WHERE id";
                return true;
            }
            return false;
        }
        */
    }
}
