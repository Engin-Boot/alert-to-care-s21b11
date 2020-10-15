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

        //[HttpGet]
        //public ActionResult<IEnumerable<Vitals>> GetVitals()
        //{
        //    var _vitals = _repo.GetAllVitals();
        //    return Ok(_vitals);
        //}



        //[HttpGet("{id}")]
        //public ActionResult<Vitals> GetVitalsById(string id)
        //{
        //    var _vitals = _repo.CheckVitals(id);
        //    return Ok(_vitals);
        //}


        [HttpGet("RespRate/{id}")]
        public string MonitorRespRates(int id)
        {
            if (_repo.RespRateMonitoring(id) == false)
            {
                return "Resperatory rate is not normal for the patient id : " + id +", Please consult doctor";
            }
            return "Resperatory rate is good for the patient id : " + id;
        }

        [HttpGet("Spo2/{id}")]
        public string Monitorspo2s(int id)
        {
            if (_repo.SpoMonitoring(id) == false)
            {
                return "Spo2  is not ok for the patient id : " + id + ", Please consult doctor";
            }
            return "Spo2 is good for the patient id : " + id;
        }

        [HttpGet("Bpm/{id}")]
        public string Monitorbpms(int id)
        {
            if (_repo.BpmMonitoring(id) == false)
            {
                return "BPM  is not ok for the patient id : " + id + ", Please consult doctor";
            }
            return "BPM is good for the patient id : " + id;
        }
    }

}
