using AlertToCare.Data;
using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Controllers
{
    [Route("api/monitor")]
    [ApiController]
    public class PatientMonitoringController : ControllerBase
    {
        private readonly IMonitoringRepo _repo;

        public PatientMonitoringController(IMonitoringRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vitals>> GetVitals()
        {
            var _vitals = _repo.GetAllVitals();
            return Ok(_vitals);
        }

        [HttpGet("{id}")]
        public ActionResult<Vitals> GetVitalsById(string id)
        {
            var _vitals = _repo.CheckVitals(id);
            return Ok(_vitals);
        }
    }

}
