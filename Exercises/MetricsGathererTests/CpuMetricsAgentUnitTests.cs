using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
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
        private CpuMetricsAgentController controller;
        private Mock<ICpuMetricsRepository> mock;
        private Mock<ILogger<CpuMetricsAgentController>> mockLog;
        private Mock<IMapper> mockMap;

        public CpuMetricsAgentUnitTests()
        {
            mockLog = new Mock<ILogger<CpuMetricsAgentController>>();
            ILogger<CpuMetricsAgentController> logger = mockLog.Object;
            mock = new Mock<ICpuMetricsRepository>();
            mockMap = new Mock<IMapper>();
            controller = new CpuMetricsAgentController(mock.Object, logger, mockMap.Object);
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

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {

            mock.Setup(repository =>repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            var result = controller.Create(new
            MetricsAgent.Requests.CpuMetricCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()),Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
        {
            TimeSpan ts1 = new TimeSpan(12, 00, 00);
            TimeSpan ts2 = new TimeSpan(12, 10, 00);

            mock.Setup(repository => repository.GetByTimePeriod(
                It.IsAny<TimeSpan>(),
                It.IsAny<TimeSpan>()))
                .Verifiable();

            var result = controller.GetByTimePeriod(ts1,ts2);

            mock.Verify(repository => repository.GetByTimePeriod(
                It.IsAny<TimeSpan>(),
                It.IsAny<TimeSpan>()),
                Times.AtMostOnce());
        }





    }
}
