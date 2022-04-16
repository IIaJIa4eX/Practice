using MetricsAgent.DAL;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
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
        private INetWorkMetricsRepository _repository;
        private readonly ILogger<NetWorkMetricsAgentController> _logger;

        public NetWorkMetricsAgentController(INetWorkMetricsRepository repository, ILogger<NetWorkMetricsAgentController> logger)
        {
            _repository = repository;
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

        [HttpPost("create")]
        public IActionResult Create([FromBody] NetWorkMetricCreateRequest request)
        {
            _logger.LogInformation($"Данные метода Create в NetWorkMetricsAgentController: {request.Time}, {request.Value}");
            _repository.Create(new NetWorkMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }

        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetByTimePeriod в NetWorkMetricsAgentController: {fromTime}, {toTime}");

            try
            {
                var metrics = _repository.GetByTimePeriod(fromTime, toTime);
                var response = new AllNetWorkMetricsResponse()
                {
                    Metrics = new List<NetWorkMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(new NetWorkMetricDto
                    {
                        Time = metric.Time,
                        Value = metric.Value,
                        Id = metric.Id
                    });
                }
                return Ok(response);
            }
            catch
            {

            }
            _logger.LogInformation($"Отработал метод GetByTimePeriod");
            return Ok();
        }
    }
}
