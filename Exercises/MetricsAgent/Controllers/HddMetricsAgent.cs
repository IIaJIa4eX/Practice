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
    public class HddMetricsAgent : ControllerBase
    {

        [HttpGet("api/metrics/hdd/left/from/{fromTime}/to/{toTime}.")]
        public IActionResult GetHddMetrics(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}
