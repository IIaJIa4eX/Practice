using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{

    public interface INetWorkMetricsRepository : IRepository<NetWorkMetric>
    {

    }
    public class NetWorkMetricsRepository : INetWorkMetricsRepository
    {

        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public void Create(NetWorkMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "INSERT INTO networkmetrics(value, time)VALUES(@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);

            cmd.Parameters.AddWithValue("@time", item.Time.TotalSeconds);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<NetWorkMetric> GetAll()
        {
            throw new NotImplementedException();
        }

        public NetWorkMetric GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<NetWorkMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "SELECT * FROM networkmetrics WHERE time >= @fromTime AND time <= @toTime";
            cmd.Parameters.AddWithValue("@fromTime", fromTime.TotalSeconds);
            cmd.Parameters.AddWithValue("@toTime", toTime.TotalSeconds);
            cmd.Prepare();
            var returnList = new List<NetWorkMetric>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new NetWorkMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(2))
                    });
                }
            }
            return returnList;
        }

        public void Update(NetWorkMetric item)
        {
            throw new NotImplementedException();
        }
    }
}
