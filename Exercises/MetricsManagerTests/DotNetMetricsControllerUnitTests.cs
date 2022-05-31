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
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController _controller;
        private Mock<IDotNetMetricsRepository> _mock;
        private Mock<ILogger<DotNetMetricsController>> _mockLog;
        private Mock<IMapper> mockMap;
        public DotNetMetricsControllerUnitTests()
        {
            _mockLog = new Mock<ILogger<DotNetMetricsController>>();
            ILogger<DotNetMetricsController> logger = _mockLog.Object;
            _mock = new Mock<IDotNetMetricsRepository>();
            mockMap = new Mock<IMapper>();
            _controller = new DotNetMetricsController(logger, _mock.Object, mockMap.Object);
        }


        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = _controller.GetMetricsFromAgent(agentId);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromAllCluster_ReturnsOk()
        {

            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = _controller.GetMetricsFromAllCluster();
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
