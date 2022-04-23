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
        private string _instance = "Realtek PCIe GbE Family Controller _2";
        public NetWorkMetricJob(INetWorkMetricsRepository repository)
        {
            _repository = repository;
            _netCounter = new PerformanceCounter("Network Interface", "Bytes Total/sec", _instance);
        }
        public Task Execute(IJobExecutionContext context)
        {
            var netUsageInBytes = Convert.ToInt32(_netCounter.NextValue());
            var time = DateTimeOffset.UtcNow.ToLocalTime();
            _repository.Create(new Models.NetWorkMetric

            {
                Time = time,
                Value = netUsageInBytes
            });
            return Task.CompletedTask;

        }
    }
}
