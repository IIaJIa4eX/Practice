using Dapper;
using MetricsProject_ver1.DAL.Models;
using MetricsProject_ver1.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.DAL.Repositories.MetricsRepositories
{
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;";

        public DotNetMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }
        public void AddMetric(DotNetMetric item)
        {
            throw new NotImplementedException();
        }

        public DotNetMetric GetAgentMetricById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
