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
    public class NetWorkMetricsAgentController : ControllerBase
    {

        private readonly ILogger<NetWorkMetricsAgentController> _logger;

        public NetWorkMetricsAgentController(ILogger<NetWorkMetricsAgentController> logger)
        {

            _logger = logger;
        }

        [HttpGet("api/metrics/network/from/{fromTime}/to/{toTime}")]
        public IActionResult GetNetWorkMetrics(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetNetWorkMetrics в NetWorkMetricsAgentController: {fromTime}, {toTime}");
            return Ok();
        }
    }
}
