﻿using MetricsAgent.DAL;
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
    public class CpuMetricsAgentController : ControllerBase
    {

        private ICpuMetricsRepository _repository;
        private readonly ILogger<CpuMetricsAgentController> _logger;


        public CpuMetricsAgentController(ICpuMetricsRepository repository, ILogger<CpuMetricsAgentController> logger)
        {
            _repository = repository;
            _logger = logger;
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

            var metrics = _repository.GetAll();
            var response = new AllCpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(new CpuMetricDto
                {
                    Time = metric.Time,
                    Value = metric.Value,
                    Id = metric.Id
                });
            }
            _logger.LogInformation($"Отработал метод GetAll");
            return Ok(response);
        }



        [HttpGet("api/metrics/cpu/from/{fromTime}/to/{toTime}")]
        public IActionResult GetCpuMetrics(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetCpuMetrics в CpuMetricsAgentController: {fromTime}, {toTime}");
            return Ok();
        }

        [HttpGet("getbytimeperiod/from/{fromTime}/to/{toTime}")]
        public IActionResult GetByTimePeriod(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetByTimePeriod в CpuMetricsAgentController: {fromTime}, {toTime}");

            try
            {
                var metrics = _repository.GetByTimePeriod(fromTime, toTime);
                var response = new AllCpuMetricsResponse()
                {
                    Metrics = new List<CpuMetricDto>()
                };
                foreach (var metric in metrics)
                {
                    response.Metrics.Add(new CpuMetricDto
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
