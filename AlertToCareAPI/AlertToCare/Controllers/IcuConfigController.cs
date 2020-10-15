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
    }
}
