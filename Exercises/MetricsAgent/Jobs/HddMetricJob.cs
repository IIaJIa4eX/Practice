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
    public class HddMetricJob : IJob
    {       

        private IHddMetricsRepository _repository;
        private PerformanceCounter _hddRCounter;
        private PerformanceCounter _hddWCounter;

        public HddMetricJob(IHddMetricsRepository repository)
        {
            _repository = repository;

            _hddRCounter = new PerformanceCounter("PhysicalDisk", "Disk Reads/sec", "_Total");
            _hddWCounter = new PerformanceCounter("PhysicalDisk", "Disk Writes/sec", "_Total");
        }
        public Task Execute(IJobExecutionContext context)
        {


            var readInSec= Convert.ToInt32(_hddRCounter.NextValue());
            var writeInSec = Convert.ToInt32(_hddWCounter.NextValue());

            var time = DateTimeOffset.UtcNow.ToLocalTime();
            _repository.Create(new Models.HddMetric
            {
                Time = time,
                Value = readInSec + writeInSec
            });
            return Task.CompletedTask;

        }
    }
}
