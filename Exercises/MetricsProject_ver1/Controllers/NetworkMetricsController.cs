using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {


        private readonly ILogger<NetworkMetricsController> _logger;

        public NetworkMetricsController(ILogger<NetworkMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "Конструткор отработал в NetworkMetricsController");
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
           [FromRoute] int agentId,
           [FromRoute] TimeSpan fromTime,
           [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetMetricsFromAgent в NetworkMetricsController: {agentId}, {fromTime}, {toTime}");

            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {

            _logger.LogInformation($"Данные метода GetMetricsFromAllCluster в NetworkMetricsController: {fromTime}, {toTime}");
            return Ok();
        }
    }
}
