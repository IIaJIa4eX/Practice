using AutoMapper;
using MetricsProject_ver1.Controllers;
using MetricsProject_ver1.DAL.Repositories.MetricsRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MetricsManagerTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController controller;
        private Mock<IRamMetricsRepository> _mock;
        private Mock<ILogger<RamMetricsController>> _mockLog;
        private Mock<IMapper> mockMap;
        public RamMetricsControllerUnitTests()
        {
            _mockLog = new Mock<ILogger<RamMetricsController>>();
            ILogger<RamMetricsController> logger = _mockLog.Object;
            _mock = new Mock<IRamMetricsRepository>();
            mockMap = new Mock<IMapper>();

            controller = new RamMetricsController( logger, _mock.Object, mockMap.Object);
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetricsFromAgent(agentId);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAllCluster_ReturnsOk()
        {

            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetMetricsFromAllCluster();
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
