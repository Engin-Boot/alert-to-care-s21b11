using System.Collections.Generic;
using System.Linq;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCareAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class IcuConfigController : ControllerBase
    {
        private readonly DataContext _context;

        public IcuConfigController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Icu>> GetAllIcus()
        {
            var ICUs = _context.IcusInfo.ToList();

            return Ok(ICUs);
        }
    }
}