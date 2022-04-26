using MetricsProject_ver1.DAL.Models;
using System;

namespace MetricsProject_ver1.DAL.Repositories.MetricsRepositories
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;";
        public void AddMetric(CpuMetric item)
        {

        }

        public CpuMetric GetAgentMetricById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
