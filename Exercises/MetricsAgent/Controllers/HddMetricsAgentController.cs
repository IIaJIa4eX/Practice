using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HddMetricsAgentController : ControllerBase
    {
        private readonly ILogger<HddMetricsAgentController> _logger;

        public HddMetricsAgentController(ILogger<HddMetricsAgentController> logger)
        {

            _logger = logger;
        }

        [HttpGet("api/metrics/hdd/left/from/{fromTime}/to/{toTime}.")]
        public IActionResult GetHddMetrics(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetHddMetrics в HddMetricsAgentController: {fromTime}, {toTime}");
            return Ok();
        }
    }
}
