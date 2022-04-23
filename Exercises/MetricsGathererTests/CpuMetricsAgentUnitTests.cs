using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests;
using MetricsAgent.Requests.CpuMetricRequests;
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

 
            var Req = new CpuMetricGetByTimePeriodRequest();
            Req.fromTime = new DateTimeOffset(2022, 4, 22, 15, 30, 00, new TimeSpan(+3, 0, 0));
            Req.toTime = new DateTimeOffset(2022, 4, 22, 15, 30, 00, new TimeSpan(+3, 0, 0)); ;
            //Act
            var result = controller.GetCpuMetrics(Req);
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
                Time = new DateTimeOffset(2022, 4, 22, 15, 30, 00, new TimeSpan(+3, 0, 0)),
                Value = 50
            });
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()),Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
        {
            var Req = new CpuMetricGetByTimePeriodRequest();
            Req.fromTime = new DateTimeOffset(2022, 4, 22, 15, 30, 00, new TimeSpan(+3, 0, 0));
            Req.toTime = new DateTimeOffset(2022, 4, 22, 15, 30, 00, new TimeSpan(+3, 0, 0)); ;

            mock.Setup(repository => repository.GetByTimePeriod(
                It.IsAny<DateTimeOffset>(),
                It.IsAny<DateTimeOffset>()))
                .Verifiable();

            var result = controller.GetByTimePeriod(Req);

            mock.Verify(repository => repository.GetByTimePeriod(
                It.IsAny<DateTimeOffset>(),
                It.IsAny<DateTimeOffset>()),
                Times.AtMostOnce());
        }





    }
}
