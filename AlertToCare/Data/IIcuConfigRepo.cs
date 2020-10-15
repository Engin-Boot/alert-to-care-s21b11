using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public interface IIcuConfigRepo
    {
        public bool AddNewIcu(Icu icu);
        public bool RemoveIcu(Icu icu, string id);
        //public bool UpdateIcu(string id, Icu icu);
        public IEnumerable<Icu> GetAllIcus();
    }
}
