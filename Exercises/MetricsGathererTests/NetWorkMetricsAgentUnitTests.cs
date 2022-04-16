using MetricsAgent.Controllers;
using MetricsAgent.DAL;
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
    public class NetWorkMetricsAgentUnitTests
    {
        private NetWorkMetricsAgentController controller;
        private Mock<INetWorkMetricsRepository> _mock;
        private Mock<ILogger<NetWorkMetricsAgentController>> _mockLog;
        public NetWorkMetricsAgentUnitTests()
        {
            _mockLog = new Mock<ILogger<NetWorkMetricsAgentController>>();
            ILogger<NetWorkMetricsAgentController> logger = _mockLog.Object;

            _mock = new Mock<INetWorkMetricsRepository>();
            controller = new NetWorkMetricsAgentController(_mock.Object, logger);
        }


        [Fact]
        public void GetMetrics_ReturnsOk()
        {

            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = controller.GetNetWorkMetrics(fromTime,
            toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }


        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {

            _mock.Setup(repository => repository.Create(It.IsAny<NetWorkMetric>())).Verifiable();
            var result = controller.Create(new
            MetricsAgent.Requests.NetWorkMetricCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<NetWorkMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetByTimePeriod_ShouldCall_GetByTimePeriod_From_Repository()
        {
            TimeSpan ts1 = new TimeSpan(12, 00, 00);
            TimeSpan ts2 = new TimeSpan(12, 10, 00);

            _mock.Setup(repository => repository.GetByTimePeriod(
                It.IsAny<TimeSpan>(),
                It.IsAny<TimeSpan>()))
                .Verifiable();

            var result = controller.GetByTimePeriod(ts1, ts2);

            _mock.Verify(repository => repository.GetByTimePeriod(
                It.IsAny<TimeSpan>(),
                It.IsAny<TimeSpan>()),
                Times.AtMostOnce());
        }

    }
}
