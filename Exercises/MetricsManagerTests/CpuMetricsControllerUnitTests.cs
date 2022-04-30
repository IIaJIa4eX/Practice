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
    public class CpuMetricsControllerUnitTests
    {

        private CpuMetricsController controller;
        private Mock<ICpuMetricsRepository> mock;
        private Mock<ILogger<CpuMetricsController>> mockLog;
        private Mock<IMapper> mockMap;

        public CpuMetricsControllerUnitTests()
        {
            mockLog = new Mock<ILogger<CpuMetricsController>>();
            ILogger<CpuMetricsController> logger = mockLog.Object;
            mock = new Mock<ICpuMetricsRepository>();
            mockMap = new Mock<IMapper>();
            controller = new CpuMetricsController(logger,mock.Object, mockMap.Object);
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

                //Act
                var result = controller.GetMetricsFromAllCluster();
                // Assert
                _ = Assert.IsAssignableFrom<IActionResult>(result);
            }

            

    }
}
