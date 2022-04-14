using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamMetricsAgentController : ControllerBase
    {
        [HttpGet("api/metrics/ram/available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetAvailableRamMetrics(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}
