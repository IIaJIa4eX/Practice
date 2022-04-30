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
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        //to review
        private readonly ILogger<DotNetMetricsController> _logger;
        private IDotNetMetricsRepository _repository;
        private readonly IMapper _mapper;

        public DotNetMetricsController(ILogger<DotNetMetricsController> logger, IDotNetMetricsRepository repository, IMapper mapper)
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
                IList<DotNetMetric> metrics = _repository.GetAgentMetricById(agentId);
                List<DotNetMetricDTO> Metrics = new List<DotNetMetricDTO>();

                foreach (var metric in metrics)
                {
                    Metrics.Add(_mapper.Map<DotNetMetricDTO>(metric));
                }
                return Ok(Metrics);
            }
            catch
            {

            }
            _logger.LogInformation($"Отработал метод GetMetricsFromAgent");
            return Ok("Что-то пошло не так");

        }

        [HttpGet("cluster")]
        public IActionResult GetMetricsFromAllCluster()
        {

            try
            {
                IList<DotNetMetric> metrics = _repository.GetMetricsFromAllCluster();
                List<DotNetMetricDTO> Metrics = new List<DotNetMetricDTO>();

                foreach (var metric in metrics)
                {
                    Metrics.Add(_mapper.Map<DotNetMetricDTO>(metric));
                }
                return Ok(Metrics);
            }
            catch
            {

            }
            _logger.LogInformation($"Отработал метод GetMetricsFromAllCluster");
            return Ok("Что-то пошло не так");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsByTimePeriod([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation($"Данные метода GetMetricsByTimePeriod в DotNetMetricsController: от {fromTime} до {toTime}");

            IList<DotNetMetric> metrics = _repository.GetMetricsByTimePeriod(fromTime, toTime);
            List<DotNetMetricDTO> Metrics = new List<DotNetMetricDTO>();

            foreach (var metric in metrics)
            {
                Metrics.Add(_mapper.Map<DotNetMetricDTO>(metric));
            }

            _logger.LogInformation($"Отработал метод GetMetricsFromAgent");
            return Ok(Metrics);

        }
    }
}
