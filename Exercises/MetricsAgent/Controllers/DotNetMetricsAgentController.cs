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
    public class DotNetMetricsAgentController : ControllerBase
    {

        private readonly ILogger<DotNetMetricsAgentController> _logger;

        public DotNetMetricsAgentController(ILogger<DotNetMetricsAgentController> logger)
        {
            
            _logger = logger;
        }

        [HttpGet("api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}")]
        public IActionResult GetDotNetErrorsCount(
        [FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"Данные метода GetDotNetErrorsCount в DotNetMetricsAgentController: {fromTime}, {toTime}");
            return Ok();
        }
    }
}
