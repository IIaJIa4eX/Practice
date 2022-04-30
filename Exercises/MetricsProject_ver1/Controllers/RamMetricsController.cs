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
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {

        private readonly ILogger<RamMetricsController> _logger;
        private IRamMetricsRepository _repository;
        private readonly IMapper _mapper;

        public RamMetricsController(ILogger<RamMetricsController> logger, IRamMetricsRepository repository, IMapper mapper)
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
                IList<RamMetric> metrics = _repository.GetAgentMetricById(agentId);
                List<RamMetricDTO> Metrics = new List<RamMetricDTO>();

                foreach (var metric in metrics)
                {
                    Metrics.Add(_mapper.Map<RamMetricDTO>(metric));
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
                IList<RamMetric> metrics = _repository.GetMetricsFromAllCluster();
                List<RamMetricDTO> Metrics = new List<RamMetricDTO>();

                foreach (var metric in metrics)
                {
                    Metrics.Add(_mapper.Map<RamMetricDTO>(metric));
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

            IList<RamMetric> metrics = _repository.GetMetricsByTimePeriod(fromTime, toTime);
            List<RamMetricDTO> Metrics = new List<RamMetricDTO>();

            foreach (var metric in metrics)
            {
                Metrics.Add(_mapper.Map<RamMetricDTO>(metric));
            }

            _logger.LogInformation($"Отработал метод GetMetricsFromAgent");
            return Ok(Metrics);

        }
    }
}
