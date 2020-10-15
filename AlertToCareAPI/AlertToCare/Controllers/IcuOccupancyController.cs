using AlertToCare.Data;
using AlertToCare.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet("bedStatus/{id}")]
        public object BedStatus(string id)
        {
            try
            {
                return Ok(_repo.BedStatus(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                Console.ReadLine();
                return HttpStatusCode.InternalServerError;
            }
        }
        [HttpGet("discharge/{id}")]
        public object Removepatient(int id) //discharge patient
        {
            try
            {

                return Ok(_repo.RemovePatient(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                Console.ReadLine();
                return HttpStatusCode.InternalServerError;
            }
        }

        [HttpPost]
        public string AddPatient([FromBody] Models.Patient value)
        {
            var res = _repo.AddNewPatient(value);
            return "Patient Added:" + res.ToString();
        }

    }
}
