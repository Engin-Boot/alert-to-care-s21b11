using AlertToCareAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public interface IIcuConfigRepo
    {
        void AddNewIcu(Icu icu);
        void RemoveIcu(Icu icu);
        void UpdateIcu(Icu icu);
        Icu GetIcuById(string id);
        IEnumerable<Icu> GetAllIcus();
        bool SaveChanges();
    }
}
