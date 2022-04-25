using MetricsProject_ver1.Client;
using MetricsProject_ver1.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MetricsProject_ver1.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {

        private readonly ILogger<HddMetricsController> _logger;

        private MetricsAgentClient metricsAgentClient;
        public HddMetricsController(ILogger<HddMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "Конструткор отработал в HddMetricsController");
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
           [FromRoute] int agentId,
           [FromRoute] DateTimeOffset fromTime,
           [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"starting new request to metrics agent");

            var metrics = metricsAgentClient.GetAllHddMetrics(new GetAllHddMetricsApiRequest //Разобраться, какой реквест должен уходить
            {
                fromTime = fromTime,
                toTime = toTime
            });

            return Ok(metrics);
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetMetricsFromAllCluster в HddMetricsController: {fromTime}, {toTime}");
            return Ok();
        }
    }
}
