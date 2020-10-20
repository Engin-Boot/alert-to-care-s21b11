using AlertToCareAPI.Models;
using System.Collections.Generic;

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
