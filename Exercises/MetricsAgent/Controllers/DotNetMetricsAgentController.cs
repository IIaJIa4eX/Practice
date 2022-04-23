using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Requests.DotNetMetricRequests;
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
    //to review
    [Route("api/[controller]")]
    [ApiController]
    public class DotNetMetricsAgentController : ControllerBase
    {
        private IDotNetMetricsRepository _repository;
        private readonly ILogger<DotNetMetricsAgentController> _logger;
        private readonly IMapper _mapper;
        public DotNetMetricsAgentController(IDotNetMetricsRepository repository, ILogger<DotNetMetricsAgentController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

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

        [HttpGet("all")]
        public IActionResult GetAll()
        {

            IList<DotNetMetric> metrics = _repository.GetAll();
            var response = new AllDotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
            }

            _logger.LogInformation($"Отработал метод GetAll");
            return Ok(response);
        }


        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod([FromRoute] DotNetMetricGetByTimePeriodRequest req)
        {
            _logger.LogInformation($"Данные метода GetByTimePeriod в DotNetMetricsAgentController: {req.fromTime}, {req.toTime}");

            try
            {
                var metrics = _repository.GetByTimePeriod(req.fromTime, req.toTime);
                var response = new AllDotNetMetricsResponse()
                {
                    Metrics = new List<DotNetMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
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
