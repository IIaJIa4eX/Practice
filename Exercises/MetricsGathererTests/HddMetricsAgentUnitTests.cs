using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using MetricsAgent.Requests.HddMetricRequests;
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
    public class HddMetricsAgentUnitTests
    {
        private HddMetricsAgentController controller;
        private Mock<IHddMetricsRepository> _mock;
        private Mock<ILogger<HddMetricsAgentController>> _mockLog;
        private Mock<IMapper> mockMap;
        public HddMetricsAgentUnitTests()
        {
            _mockLog = new Mock<ILogger<HddMetricsAgentController>>();
            ILogger<HddMetricsAgentController> logger = _mockLog.Object;
            _mock = new Mock<IHddMetricsRepository>();
            mockMap = new Mock<IMapper>();
            controller = new HddMetricsAgentController(logger, _mock.Object, mockMap.Object);
        }


        [Fact]
        public void GetMetrics_ReturnsOk()
        {

            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetHddMetrics(fromTime,
            toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {

            _mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();
            var result = controller.Create(new
            MetricsAgent.Requests.HddMetricCreateRequest
            {
                Time = new DateTimeOffset(2022, 4, 22, 15, 30, 00, new TimeSpan(+3, 0, 0)),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
        {
            var Req = new HddMetricGetByTimePeriodRequest();
            Req.fromTime = new DateTimeOffset(2022, 4, 22, 15, 30, 00, new TimeSpan(+3, 0, 0));
            Req.toTime = new DateTimeOffset(2022, 4, 22, 15, 30, 00, new TimeSpan(+3, 0, 0)); ;

            _mock.Setup(repository => repository.GetByTimePeriod(
                It.IsAny<DateTimeOffset>(),
                It.IsAny<DateTimeOffset>()))
                .Verifiable();

            var result = controller.GetByTimePeriod(Req);

            _mock.Verify(repository => repository.GetByTimePeriod(It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.AtMostOnce());
        }
    }

       
}
