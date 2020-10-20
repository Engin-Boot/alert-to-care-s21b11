using System.Collections.Generic;
using AlertToCare.Data;
using AlertToCareAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCareAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class IcuConfigController : ControllerBase
    {
        private readonly IIcuConfigRepo _repository;

        public IcuConfigController(IIcuConfigRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Icu>> GetAllIcus()
        {
            var ICUs = _repository.GetAllIcus();

            return Ok(ICUs);
        }

        [HttpGet("{id}")]
        public ActionResult<Icu> GetBedStatus(string id)
        {
            return _repository.GetIcuById(id);
        }

        [HttpPost]
        public ActionResult AddIcu(Icu icu)
        {
            _repository.AddNewIcu(icu);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]

        public ActionResult UpdateIcu(string id, Icu icu)
        {
            var IcuModelFromRepository = _repository.GetIcuById(id);
            if (IcuModelFromRepository == null)
            {
                return NotFound();
            }
            IcuModelFromRepository.BedCount = icu.BedCount;
            IcuModelFromRepository.LayoutId = icu.LayoutId;

            _repository.UpdateIcu(icu);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteIcu(string id)
        {
            var IcuModelFromRepository = _repository.GetIcuById(id);
            if (IcuModelFromRepository == null)
            {
                return NotFound();
            }
           
            _repository.RemoveIcu(IcuModelFromRepository);
            _repository.SaveChanges();

            return NoContent(); 
        }
    }
}