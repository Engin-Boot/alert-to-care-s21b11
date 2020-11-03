using System.Collections.Generic;
using System.Linq;

using AlertToCareAPI.Repo;
using AlertToCareAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCareAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PatientsMonitoringController : ControllerBase
    {
        private readonly IMonitoringRepo _repository;

        public PatientsMonitoringController(IMonitoringRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("{icuID}")]
        public ActionResult GetAlerts(string icuId)
        {
            IEnumerable<Alert> alerts = _repository.GetAllActiveAlerts(icuId);
            if(alerts.Count()==0)
            {
                return Ok(alerts);
            }
            return Ok(alerts);
        }

        [HttpGet("disable/{id}")]
        public ActionResult ChangeStatusOfAlert(string id)
        {
            
            var isStatusChanged = _repository.AlertChangeStatus(id);
            return Ok(isStatusChanged);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveAlertOfDischargedPat(string id)
        {
            var isAlertRemoved = _repository.RemoveAlertsOfPatient(id);
            return Ok(isAlertRemoved);
        }

        [HttpGet("Unoccbed/{icuID}")]
        public ActionResult GetUnoccupiedBeds(string icuId)
        {
            var unoccBeds = _repository.GetAllUnOccupiedBeds(icuId);
            if(unoccBeds.Count()!=0)
            {
                return Ok(unoccBeds);
            }
            else
            {
                return BadRequest(unoccBeds);
            }
        }

        /*[HttpGet("sample")]
        public Alert Testing()
        {
            Alert alert = new Alert();
            alert.Id = "AL5";
            alert.Message = "testing";
            alert.PatientId = "hello";
            alert.IsActive = 1;
            alert.BedId = "B01";
            return alert;
        }*/
    }
}
