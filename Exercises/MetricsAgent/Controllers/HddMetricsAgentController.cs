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
    public class HddMetricsAgentController : ControllerBase
    {
        private IHddMetricsRepository _repository;
        private readonly ILogger<HddMetricsAgentController> _logger;

        public HddMetricsAgentController(ILogger<HddMetricsAgentController> logger, IHddMetricsRepository repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("left/from/{fromTime}/to/{toTime}.")]
        public IActionResult GetHddMetrics(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetHddMetrics в HddMetricsAgentController: {fromTime}, {toTime}");
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            _logger.LogInformation($"Данные метода Create в HddMetricsAgentController: {request.Time}, {request.Value}");
            _repository.Create(new HddMetric
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
            _logger.LogInformation($"Данные метода GetByTimePeriod в HddMetricsAgentController: {fromTime}, {toTime}");

            try
            {
                var metrics = _repository.GetByTimePeriod(fromTime, toTime);
                var response = new AllHddMetricsResponse()
                {
                    Metrics = new List<HddMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(new HddMetricDto
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
