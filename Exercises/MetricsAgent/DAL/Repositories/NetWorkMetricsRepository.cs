using Dapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.DAL
{


    public class NetWorkMetricsRepository : INetWorkMetricsRepository
    {

        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public NetWorkMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
        }


        public void Create(NetWorkMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {

                connection.Execute("INSERT INTO networkmetrics(value, time) VALUES(@value, @time)",
                new
                {
                    value = item.Value,
                    time = item.Time.ToUnixTimeSeconds()
                });
            }


        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM networkmetrics WHERE id=@id",
                new
                {
                    id = id
                });
            }

        }

        public void Update(NetWorkMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE networkmetrics SET value = @value, time = @time WHERE id = @id",
                new
                {
                    value = item.Value,
                    time = item.Time.ToUnixTimeSeconds(),
                    id = item.Id
                });
            }
        }

        public IList<NetWorkMetric> GetAll()
        {

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<NetWorkMetric>("SELECT Id, Time, Value FROM networkmetrics").ToList();
            }

        }

        public NetWorkMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<NetWorkMetric>("SELECT Id, Time, Value FROM networkmetrics WHERE id = @id",
                new { id = id });
            }

        }


        public IList<NetWorkMetric> GetByTimePeriod(DateTimeOffset fromTime, DateTimeOffset toTime)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<NetWorkMetric>("SELECT * FROM networkmetrics WHERE time >= @fromTime AND time <= @toTime",
                    new
                    {
                        fromTime = fromTime.ToUnixTimeSeconds(),
                        toTime = toTime.ToUnixTimeSeconds()
                    }).ToList();
            }
        }

        public NetWorkMetric GetLastValue()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {

                return connection.QuerySingle<NetWorkMetric>("SELECT Id, Value, Time FROM networkmetrics WHERE Time = (SELECT MAX(Time) FROM networkmetrics)");
            }
        }
    }
}
