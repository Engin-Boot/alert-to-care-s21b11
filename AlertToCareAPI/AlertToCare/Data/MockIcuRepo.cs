using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace AlertToCare.Data
{
    public class MockIcuRepo : IIcuConfigRepo
    {
        public void AddNewIcu(Icu icu)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Icu> GetAllIcus()
        {
            var beds = new List<Bed>
            {
                new Bed{ IcuId="I001", BedId="B001", CurrentStatus=true},
                new Bed{ IcuId="I001", BedId="B001", CurrentStatus=true},
                new Bed{ IcuId="I001", BedId="B001", CurrentStatus=true}
            };
            var ICUs = new List<Icu>
            {
                new Icu{ IcuId="I001", BedCount=10, Beds=beds, LayoutId="L001"},
                 new Icu{ IcuId="I001", BedCount=10, Beds=beds, LayoutId="L001"},
                  new Icu{ IcuId="I001", BedCount=10, Beds=beds, LayoutId="L001"}
            };

            return ICUs;
        }

        public void RemoveIcu(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateIcu(string id, Icu icu)
        {
            throw new NotImplementedException();
        }
    }
}
