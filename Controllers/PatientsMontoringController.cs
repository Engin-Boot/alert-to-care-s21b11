using System.Collections.Generic;
using System.Linq;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCareAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PatientsMonitoringController : ControllerBase
    {
        private readonly DataContext _context;

        public PatientsMonitoringController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vital>> GetVitals()
        {
            var vitals = _context.VitalsInfo.ToList();

            return Ok(vitals);
        }
    }
}