using Dapper;
using MetricsProject_ver1.DAL.Models;
using MetricsProject_ver1.DAL.Repositories.Common;
using MetricsProject_ver1.Mapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsProject_ver1.DAL.Repositories.MetricsRepositories
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;";
       

        public CpuMetricsRepository(ICpuMetricsRepository repository)
        {         

            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }

        public void AddMetric(CpuMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {

                connection.Execute("INSERT INTO cpumetrics (value, time, agentId) VALUES(@value, @time, @agentId)",
                new
                {
                    value = item.Value,
                    time = item.Time.ToUnixTimeSeconds(),
                    agentId = item.agentId
                });
            }
        }


        public IList<CpuMetric> GetMetricsByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {


                return connection.Query<CpuMetric>("SELECT * FROM cpumetrics WHERE Time >= @fromTime AND Time <= @toTime",
                    new
                    {
                        fromTime = fromTime.ToUnixTimeSeconds(),
                        toTime = toTime.ToUnixTimeSeconds()
                    }).ToList();
            }
        }

        public IList<CpuMetric> GetMetricsFromAllCluster()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<CpuMetric>("SELECT * FROM cpumetrics").ToList();
            }
        }

        public IList<CpuMetric> GetAgentMetricById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {

                return connection.Query<CpuMetric>("SELECT * FROM cpumetrics WHERE Id = @id",
                    new
                    {
                        id = id
                    }).ToList();
            }
        }
    }
}
