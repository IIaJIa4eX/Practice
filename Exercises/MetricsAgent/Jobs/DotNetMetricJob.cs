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
    public class DotNetMetricJob : IJob
    {
        private IDotNetMetricsRepository _repository;
        private PerformanceCounter _gcCounter;

        public DotNetMetricJob(IDotNetMetricsRepository repository)
        {
            _repository = repository;
           
            _gcCounter = new PerformanceCounter(".NET CLR Memory", "Allocated Bytes/sec", "_Global_");
        }
        public Task Execute(IJobExecutionContext context)
        {
            int gcInBytes;
            try
            {
                gcInBytes = Convert.ToInt32(_gcCounter.NextValue());
            }
            catch
            {
                gcInBytes = 0;
            }
            var time = DateTimeOffset.UtcNow.ToLocalTime();
            _repository.Create(new Models.DotNetMetric
            {
                Time = time,
                Value = gcInBytes
            });
            return Task.CompletedTask;

        }
    }
}
