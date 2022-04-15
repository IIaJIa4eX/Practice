﻿using Microsoft.AspNetCore.Http;
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
    public class RamMetricsAgentController : ControllerBase
    {

        private readonly ILogger<RamMetricsAgentController> _logger;

        public RamMetricsAgentController(ILogger<RamMetricsAgentController> logger)
        {

            _logger = logger;
        }



        [HttpGet("api/metrics/ram/available/from/{fromTime}/to/{toTime}")]
        public IActionResult GetAvailableRamMetrics(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetAvailableRamMetrics в RamMetricsAgentController: {fromTime}, {toTime}");
            return Ok();
        }
    }
}
