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
    public class DotNetMetricsAgentController : ControllerBase
    {
        private IDotNetMetricsRepository _repository;
        private readonly ILogger<DotNetMetricsAgentController> _logger;

        public DotNetMetricsAgentController(IDotNetMetricsRepository repository, ILogger<DotNetMetricsAgentController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            _logger.LogInformation($"Данные метода Create в CpuMetricsAgentController: {request.Time}, {request.Value}");
            _repository.Create(new DotNetMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }

        [HttpGet("errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetDotNetErrorsCount(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetDotNetErrorsCount в DotNetMetricsAgentController: {fromTime}, {toTime}");
            return Ok();
        }

        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetByTimePeriod в DotNetMetricsAgentController: {fromTime}, {toTime}");

            try
            {
                var metrics = _repository.GetByTimePeriod(fromTime, toTime);
                var response = new AllDotNetMetricsResponse()
                {
                    Metrics = new List<DotNetMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(new DotNetMetricDto
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
