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
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController controller;
        private Mock<IHddMetricsRepository> _mock;
        private Mock<ILogger<HddMetricsController>> _mockLog;
        private Mock<IMapper> mockMap;
        public HddMetricsControllerUnitTests()
        {
            _mockLog = new Mock<ILogger<HddMetricsController>>();
            ILogger<HddMetricsController> logger = _mockLog.Object;
            _mock = new Mock<IHddMetricsRepository>();
            mockMap = new Mock<IMapper>();
            controller = new HddMetricsController(logger, _mock.Object, mockMap.Object);
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = new DateTimeOffset(2022, 4, 22, 15, 30, 00, new TimeSpan(+3, 0, 0));
            var toTime = new DateTimeOffset(2022, 4, 22, 15, 30, 00, new TimeSpan(+3, 0, 0));
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

