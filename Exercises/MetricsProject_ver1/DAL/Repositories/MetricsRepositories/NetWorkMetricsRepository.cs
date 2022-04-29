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
    public class NetWorkMetricsRepository : INetWorkMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;";


        public NetWorkMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }

        public void AddMetric(NetWorkMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {

                connection.Execute("INSERT INTO networkmetrics (value, time, agentId) VALUES(@value, @time, @agentId)",
                new
                {
                    value = item.Value,
                    time = item.Time.ToUnixTimeSeconds(),
                    agentId = item.agentId
                });
            }
        }


        public IList<NetWorkMetric> GetMetricsByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {


                return connection.Query<NetWorkMetric>("SELECT * FROM networkmetrics WHERE Time >= @fromTime AND Time <= @toTime",
                    new
                    {
                        fromTime = fromTime.ToUnixTimeSeconds(),
                        toTime = toTime.ToUnixTimeSeconds()
                    }).ToList();
            }
        }

        public IList<NetWorkMetric> GetMetricsFromAllCluster()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<NetWorkMetric>("SELECT * FROM networkmetrics").ToList();
            }
        }

        public IList<NetWorkMetric> GetAgentMetricById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {

                return connection.Query<NetWorkMetric>("SELECT * FROM networkmetrics WHERE Id = @id",
                    new
                    {
                        id = id
                    }).ToList();
            }
        }
    }
}
