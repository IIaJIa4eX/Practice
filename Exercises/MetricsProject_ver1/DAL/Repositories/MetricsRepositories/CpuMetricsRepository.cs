using Dapper;
using MetricsProject_ver1.DAL.Models;
using MetricsProject_ver1.Mapper;
using System;
using System.Data.SQLite;

namespace MetricsProject_ver1.DAL.Repositories.MetricsRepositories
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;";

        public CpuMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }
        public void AddMetric(CpuMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {

                connection.Execute("INSERT INTO cpumetrics (value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time.ToUnixTimeSeconds() // toad add agenid  и dateime
                });
            }
        }

        public CpuMetric GetAgentMetricById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
