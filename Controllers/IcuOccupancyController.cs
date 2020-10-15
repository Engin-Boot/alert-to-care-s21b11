using System.Collections.Generic;
using System.Linq;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCareAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class IcuOccupancyController : ControllerBase
    {
        private readonly DataContext _context;

        public IcuOccupancyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAllPatients()
        {
            var patients = _context.PatientsInfo.ToList();

            return Ok(patients);
        }
    }
}