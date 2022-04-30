using AutoMapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Requests.HddMetricRequests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MetricsAgent.Controllers
{
     //to review
    [Route("api/[controller]")]
    [ApiController]
    public class HddMetricsAgentController : ControllerBase
    {
        private IHddMetricsRepository _repository;
        private readonly ILogger<HddMetricsAgentController> _logger;
        private readonly IMapper _mapper;


        public HddMetricsAgentController(ILogger<HddMetricsAgentController> logger, IHddMetricsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

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

        [HttpGet("all")]
        public IActionResult GetAll()
        {

            IList<HddMetric> metrics = _repository.GetAll();
            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
            }

            _logger.LogInformation($"Отработал метод GetAll");
            return Ok(response.Metrics);
        }



        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod([FromRoute] HddMetricGetByTimePeriodRequest req)
        {
            _logger.LogInformation($"Данные метода GetByTimePeriod в HddMetricsAgentController: {req.fromTime}, {req.toTime}");

            try
            {
                var metrics = _repository.GetByTimePeriod(req.fromTime, req.toTime);
                var response = new AllHddMetricsResponse()
                {
                    Metrics = new List<HddMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
                }
                return Ok(response.Metrics);
            }
            catch
            {

            }
            _logger.LogInformation($"Отработал метод GetByTimePeriod");
            return Ok();
        }
    }
}
