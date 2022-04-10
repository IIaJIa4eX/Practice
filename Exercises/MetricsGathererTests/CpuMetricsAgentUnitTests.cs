using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MetricsAgentTests
{
    public class CpuMetricsAgentUnitTests
    {
        private CpuMetricsAgent controller;
        public CpuMetricsAgentUnitTests()
        {
            controller = new CpuMetricsAgent();
        }
        [Fact]
        public void GetMetrics_ReturnsOk()
        {

            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetCpuMetrics(fromTime,
            toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
