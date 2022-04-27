using Dapper;
using MetricsProject_ver1.DAL.Models;
using MetricsProject_ver1.Mapper;
using System;

namespace MetricsProject_ver1.DAL.Repositories.MetricsRepositories
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;";

        public RamMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }

        public void AddMetric(RamMetric item)
        {
            throw new NotImplementedException();
        }

        public RamMetric GetAgentMetricById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
