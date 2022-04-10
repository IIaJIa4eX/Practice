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
    public class RamMetricsAgentUnitTests
    {
        private RamMetricsAgent controller;
        public RamMetricsAgentUnitTests()
        {
            controller = new RamMetricsAgent();
        }
        [Fact]
        public void GetMetrics_ReturnsOk()
        {

            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetAvailableRamMetrics(fromTime,
            toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
