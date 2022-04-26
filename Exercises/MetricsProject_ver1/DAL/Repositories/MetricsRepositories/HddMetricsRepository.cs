using MetricsProject_ver1.DAL.Models;
using System;

namespace MetricsProject_ver1.DAL.Repositories.MetricsRepositories
{
    public class HddMetricsRepository : IHddMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;";
        public void AddMetric(HddMetric item)
        {
            throw new NotImplementedException();
        }

        public HddMetric GetAgentMetricById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
