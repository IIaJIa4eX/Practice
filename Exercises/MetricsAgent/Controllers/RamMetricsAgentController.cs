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
    public class RamMetricsAgentController : ControllerBase
    {

        private IRamMetricsRepository _repository;
        private readonly ILogger<RamMetricsAgentController> _logger;

        public RamMetricsAgentController(IRamMetricsRepository repository, ILogger<RamMetricsAgentController> logger)
        {
            _repository = repository;
            _logger = logger;
        }



        [HttpGet("available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetAvailableRamMetrics(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetAvailableRamMetrics в RamMetricsAgentController: {fromTime}, {toTime}");
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            _logger.LogInformation($"Данные метода Create в RamMetricsAgentController: {request.Time}, {request.Value}");
            _repository.Create(new RamMetric
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
            _logger.LogInformation($"Данные метода GetByTimePeriod в RamMetricsAgentController: {fromTime}, {toTime}");

            try
            {
                var metrics = _repository.GetByTimePeriod(fromTime, toTime);
                var response = new AllRamMetricsResponse()
                {
                    Metrics = new List<RamMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(new RamMetricDto
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
