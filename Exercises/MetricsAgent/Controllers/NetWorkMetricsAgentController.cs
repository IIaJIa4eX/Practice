using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Requests.NetWorkMetricRequests;
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
    public class NetWorkMetricsAgentController : ControllerBase
    {
        private INetWorkMetricsRepository _repository;
        private readonly ILogger<NetWorkMetricsAgentController> _logger;
        private readonly IMapper _mapper;

        public NetWorkMetricsAgentController(INetWorkMetricsRepository repository, ILogger<NetWorkMetricsAgentController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

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


        [HttpGet("all")]
        public IActionResult GetAll()
        {

            IList<NetWorkMetric> metrics = _repository.GetAll();
            var response = new AllNetWorkMetricsResponse()
            {
                Metrics = new List<NetWorkMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<NetWorkMetricDto>(metric));
            }

            _logger.LogInformation($"Отработал метод GetAll");
            return Ok(response.Metrics);
        }





        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod([FromRoute] NetWorkMetricGetByTimePeriodRequest req)
        {
            _logger.LogInformation($"Данные метода GetByTimePeriod в NetWorkMetricsAgentController: {req.fromTime}, {req.toTime}");

            try
            {
                var metrics = _repository.GetByTimePeriod(req.fromTime, req.toTime);
                var response = new AllNetWorkMetricsResponse()
                {
                    Metrics = new List<NetWorkMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<NetWorkMetricDto>(metric));

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
