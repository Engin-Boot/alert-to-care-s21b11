using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public interface IIcuConfigRepo
    {
        void AddNewIcu(Icu icu);
        void RemoveIcu(string id);
        void UpdateIcu(string id, Icu icu);
        public IEnumerable<Icu> GetAllIcus();
    }
}
