using MetricsProject_ver1.DAL.Models;
using System;

namespace MetricsProject_ver1.DAL.Repositories.MetricsRepositories
{
    public class NetWorkMetricsRepository : INetWorkMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;";
        public void AddMetric(NetWorkMetric item)
        {
            throw new NotImplementedException();
        }

        public NetWorkMetric GetAgentMetricById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
