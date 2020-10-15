using AlertToCare.Data;
using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Controllers
{
    [Route("api/icuoccupancy")]
    [ApiController]
    public class IcuOccupancyController : ControllerBase
    {
        private readonly IPatientRepo _repo;

        public IcuOccupancyController(IPatientRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatients()
        {
            var _patients = _repo.GetDetailsOfAllPatients();
            return Ok(_patients);
        }
    }
}
