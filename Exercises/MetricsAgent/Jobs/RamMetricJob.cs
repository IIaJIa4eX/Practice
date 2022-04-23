using MetricsAgent.DAL.Interfaces;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
     //to review
    public class RamMetricJob : IJob
    {
        private IRamMetricsRepository _repository;
        private PerformanceCounter _ramCounter;

        public RamMetricJob(IRamMetricsRepository repository)
        {
            _repository = repository;
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        public Task Execute(IJobExecutionContext context)
        {

            var ramUsageInPercents = Convert.ToInt32(_ramCounter.NextValue());
            var time = DateTimeOffset.UtcNow.ToLocalTime();
            _repository.Create(new Models.RamMetric
            {
                Time = time,
                Value = ramUsageInPercents
            });
            return Task.CompletedTask;

        }
    }
}
