using MetricsAgent.DAL.Interfaces;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class NetWorkMetricJob : IJob
    {

        private INetWorkMetricsRepository _repository;
        private PerformanceCounter _netCounter;

        public NetWorkMetricJob(INetWorkMetricsRepository repository)
        {
            _repository = repository;
            _netCounter = new PerformanceCounter("Network Interface", "Bytes Total/sec");
        }
        public Task Execute(IJobExecutionContext context)
        {


            var netUsageInPercents = Convert.ToInt32(_netCounter.NextValue());
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new Models.NetWorkMetric
            {
                Time = time,
                Value = netUsageInPercents
            });
            return Task.CompletedTask;

        }
    }
}
