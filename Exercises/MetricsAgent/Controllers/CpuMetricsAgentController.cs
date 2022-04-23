using AutoMapper;
using Core;
using Dapper;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Requests.CpuMetricRequests;
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
    public class CpuMetricsAgentController : ControllerBase
    {

        private ICpuMetricsRepository _repository;
        private readonly ILogger<CpuMetricsAgentController> _logger;
        private readonly INotifierMediatorService _notifierMediatorService;
        private readonly IMapper _mapper;

        public CpuMetricsAgentController(ICpuMetricsRepository repository, ILogger<CpuMetricsAgentController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            _logger.LogInformation($"Данные метода Create в CpuMetricsAgentController: {request.Time}, {request.Value}");
            _repository.Create(new CpuMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {

            IList<CpuMetric> metrics = _repository.GetAll();
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
            }

            _logger.LogInformation($"Отработал метод GetAll");
            return Ok(response);
        }



        [HttpGet("api/metrics/cpu/from/{fromTime}/to/{toTime}")]
        public IActionResult GetCpuMetrics(CpuMetricGetByTimePeriodRequest req)
        {
            _logger.LogInformation($"Данные метода GetCpuMetrics в CpuMetricsAgentController: {req.fromTime}, {req.toTime}");
            return Ok();
        }


        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod([FromRoute] CpuMetricGetByTimePeriodRequest req)
        {
            _logger.LogInformation($"Данные метода GetByTimePeriod в CpuMetricsAgentController: {req.fromTime}, {req.toTime}");

           
            
            try
            {
                var metrics = _repository.GetByTimePeriod(req.fromTime,req.toTime);
                var response = new AllCpuMetricsResponse()
                {
                    Metrics = new List<CpuMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
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
