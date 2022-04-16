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
    public class DotNetMetricsAgentUnitTests
    {
        private DotNetMetricsAgentController _controller;
        private Mock<IDotNetMetricsRepository> _mock;
        private Mock<ILogger<DotNetMetricsAgentController>> _mockLog;
        public DotNetMetricsAgentUnitTests()
        {
            _mockLog = new Mock<ILogger<DotNetMetricsAgentController>>();
            ILogger<DotNetMetricsAgentController> logger = _mockLog.Object;

            _mock = new Mock<IDotNetMetricsRepository>();
            _controller = new DotNetMetricsAgentController(_mock.Object, logger);
        }


        [Fact]
        public void GetMetrics_ReturnsOk()
        {

            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);
            //Act
            var result = _controller.GetDotNetErrorsCount(fromTime,
            toTime);
            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {

            _mock.Setup(repository => repository.Create(It.IsAny<DotNetMetric>())).Verifiable();
            var result = _controller.Create(new
            MetricsAgent.Requests.DotNetMetricCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value = 50
            });
            _mock.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtMostOnce());
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

            var result = _controller.GetByTimePeriod(ts1, ts2);

            _mock.Verify(repository => repository.GetByTimePeriod(
                It.IsAny<TimeSpan>(),
                It.IsAny<TimeSpan>()),
                Times.AtMostOnce());
        }
    }
}
