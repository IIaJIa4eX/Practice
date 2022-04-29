using AutoMapper;
using MetricsProject_ver1.DAL.Models;
using MetricsProject_ver1.DAL.Repositories.MetricsRepositories;
using MetricsProject_ver1.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Controllers
{
    [Route("api/metrics/network")]
    [ApiController]
    public class NetWorkMetricsController : ControllerBase
    {

        private readonly ILogger<NetWorkMetricsController> _logger;
        private INetWorkMetricsRepository _repository;
        private readonly IMapper _mapper;

        public NetWorkMetricsController(ILogger<NetWorkMetricsController> logger, INetWorkMetricsRepository repository, IMapper mapper)
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

            IList<NetWorkMetric> metrics = _repository.GetAgentMetricById(agentId);
            List<NetWorkMetricDTO> Metrics = new List<NetWorkMetricDTO>();

            foreach (var metric in metrics)
            {
                Metrics.Add(_mapper.Map<NetWorkMetricDTO>(metric));
            }

            _logger.LogInformation($"Отработал метод GetMetricsFromAgent");
            return Ok(Metrics);

        }

        [HttpGet("cluster")]
        public IActionResult GetMetricsFromAllCluster()
        {

            IList<NetWorkMetric> metrics = _repository.GetMetricsFromAllCluster();
            List<NetWorkMetricDTO> Metrics = new List<NetWorkMetricDTO>();

            foreach (var metric in metrics)
            {
                Metrics.Add(_mapper.Map<NetWorkMetricDTO>(metric));
            }

            _logger.LogInformation($"Отработал метод GetMetricsFromAllCluster");
            return Ok(Metrics);
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsByTimePeriod([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"Данные метода GetMetricsByTimePeriod в DotNetMetricsController: от {fromTime} до {toTime}");

            IList<NetWorkMetric> metrics = _repository.GetMetricsByTimePeriod(fromTime, toTime);
            List<NetWorkMetricDTO> Metrics = new List<NetWorkMetricDTO>();

            foreach (var metric in metrics)
            {
                Metrics.Add(_mapper.Map<NetWorkMetricDTO>(metric));
            }

            _logger.LogInformation($"Отработал метод GetMetricsFromAgent");
            return Ok(Metrics);

        }
    }
}
