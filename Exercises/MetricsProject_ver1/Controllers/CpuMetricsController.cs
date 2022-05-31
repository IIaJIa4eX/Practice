using AutoMapper;
using MetricsProject_ver1.DAL.Models;
using MetricsProject_ver1.DAL.Repositories.MetricsRepositories;
using MetricsProject_ver1.DTO;
using MetricsProject_ver1.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Controllers
{
    //to review
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {

        private readonly ILogger<CpuMetricsController> _logger;
        private ICpuMetricsRepository _repository;
        private readonly IMapper _mapper;

        public CpuMetricsController(ILogger<CpuMetricsController> logger, ICpuMetricsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _logger.LogDebug(1, "Конструткор отработал в CpuMetricsController");

        }

        [HttpGet("agent/{agentId}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId)
        {
            try
            {
                _logger.LogInformation($"Данные метода GetMetricsFromAgent в CpuMetricsController: {agentId}");

                IList<CpuMetric> metrics = _repository.GetAgentMetricById(agentId);
                List<CpuMetricDTO> Metrics = new List<CpuMetricDTO>();

                foreach (var metric in metrics)
                {
                    Metrics.Add(_mapper.Map<CpuMetricDTO>(metric));
                }

                _logger.LogInformation($"Отработал метод GetMetricsFromAgent");
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
                IList<CpuMetric> metrics = _repository.GetMetricsFromAllCluster();
                List<CpuMetricDTO> Metrics = new List<CpuMetricDTO>();

                foreach (var metric in metrics)
                {
                    Metrics.Add(_mapper.Map<CpuMetricDTO>(metric));
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
            try
            {
                _logger.LogInformation($"Данные метода GetMetricsByTimePeriod в CpuMetricsController: от {fromTime} до {toTime}");

                IList<CpuMetric> metrics = _repository.GetMetricsByTimePeriod(fromTime, toTime);
                List<CpuMetricDTO> Metrics = new List<CpuMetricDTO>();

                foreach (var metric in metrics)
                {
                    Metrics.Add(_mapper.Map<CpuMetricDTO>(metric));

                }
                return Ok(Metrics);
            }
            catch
            {

            }
            _logger.LogInformation($"Отработал метод GetMetricsFromAgent");
            return Ok("Что-то пошло не так");

        }



    }
}
