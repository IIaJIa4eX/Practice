using Dapper;
using MetricsProject_ver1.DAL.Models;
using MetricsProject_ver1.Mapper;
using System;

namespace MetricsProject_ver1.DAL.Repositories.MetricsRepositories
{
    public class NetWorkMetricsRepository : INetWorkMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;";

        public NetWorkMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }
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
