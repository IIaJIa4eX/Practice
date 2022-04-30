using AutoMapper;
using MetricsProject_ver1.Client;
using MetricsProject_ver1.DAL.Models;
using MetricsProject_ver1.DAL.Repositories.MetricsRepositories;
using MetricsProject_ver1.DTO;
using MetricsProject_ver1.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MetricsProject_ver1.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {

        private readonly ILogger<HddMetricsController> _logger;
        private IHddMetricsRepository _repository;
        private readonly IMapper _mapper;

        public HddMetricsController(ILogger<HddMetricsController> logger, IHddMetricsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _logger.LogDebug(1, "Конструткор отработал в CpuMetricsController");

        }

        [HttpGet("agent/{agentId}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId)
        {
            _logger.LogInformation($"Данные метода GetMetricsFromAgent в DotNetMetricsController: {agentId}");

            try
            {
                IList<HddMetric> metrics = _repository.GetAgentMetricById(agentId);
                List<HddMetricDTO> Metrics = new List<HddMetricDTO>();

                foreach (var metric in metrics)
                {
                    Metrics.Add(_mapper.Map<HddMetricDTO>(metric));
                }
                return Ok(Metrics);
            }
            catch
            {

            }
            _logger.LogInformation($"Отработал метод GetMetricsFromAgent");
            return Ok();

        }

        [HttpGet("cluster")]
        public IActionResult GetMetricsFromAllCluster()
        {
            try
            {
                IList<HddMetric> metrics = _repository.GetMetricsFromAllCluster();
                List<HddMetricDTO> Metrics = new List<HddMetricDTO>();

                foreach (var metric in metrics)
                {
                    Metrics.Add(_mapper.Map<HddMetricDTO>(metric));
                }
                return Ok(Metrics);
            }
            catch
            {

            }
            _logger.LogInformation($"Отработал метод GetMetricsFromAllCluster");
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsByTimePeriod([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"Данные метода GetMetricsByTimePeriod в DotNetMetricsController: от {fromTime} до {toTime}");

            IList<HddMetric> metrics = _repository.GetMetricsByTimePeriod(fromTime, toTime);
            List<HddMetricDTO> Metrics = new List<HddMetricDTO>();

            foreach (var metric in metrics)
            {
                Metrics.Add(_mapper.Map<HddMetricDTO>(metric));
            }

            _logger.LogInformation($"Отработал метод GetMetricsFromAgent");
            return Ok(Metrics);

        }
    }
}
