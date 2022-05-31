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
    public class NetworkMetricsControllerUnitTests
    {
        private NetWorkMetricsController controller;
        private Mock<INetWorkMetricsRepository> _mock;
        private Mock<ILogger<NetWorkMetricsController>> _mockLog;
        private Mock<IMapper> mockMap;
        public NetworkMetricsControllerUnitTests()
        {
            _mockLog = new Mock<ILogger<NetWorkMetricsController>>();
            ILogger<NetWorkMetricsController> logger = _mockLog.Object;
            _mock = new Mock<INetWorkMetricsRepository>();
            mockMap = new Mock<IMapper>();

            controller = new NetWorkMetricsController(logger, _mock.Object, mockMap.Object);
        }
        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
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
