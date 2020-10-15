using AlertToCare.Data;
using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Controllers
{
    [Route("api/icuconfig")]
    public class IcuConfigController : ControllerBase
    {
        private readonly IIcuConfigRepo _repo;

        public IcuConfigController(IIcuConfigRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Icu>> GetIcuDetails()
        {
            var _ICUs = _repo.GetAllIcus();
            return Ok(_ICUs);
        }

        [HttpPost]
        // POST api/<ConfigurationController>
        public string AddIcu([FromBody] Models.Icu value)
        {
            var res = _repo.AddNewIcu(value);
            return "New Icu Added :" + res.ToString();
        }

        [HttpPost]
        public string RemovingIcu([FromBody] Models.Icu value, string id)
        {
            var res = _repo.RemoveIcu(value, id);
            return "Specified ICU removed successfully"+ res.ToString(); 
        }
    }
}
