using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public interface IRamMetricsRepository : IRepository<RamMetric>
    {

    }
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public void Create(RamMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "INSERT INTO rammetrics(value, time)VALUES(@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);

            cmd.Parameters.AddWithValue("@time", item.Time.TotalSeconds);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<RamMetric> GetAll()
        {
            throw new NotImplementedException();
        }

        public RamMetric GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<RamMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "SELECT * FROM rammetrics WHERE time >= @fromTime AND time <= @toTime";
            cmd.Parameters.AddWithValue("@fromTime", fromTime.TotalSeconds);
            cmd.Parameters.AddWithValue("@toTime", toTime.TotalSeconds);
            cmd.Prepare();
            var returnList = new List<RamMetric>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new RamMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(2))
                    });
                }
            }
            return returnList;
        }

        public void Update(RamMetric item)
        {
            throw new NotImplementedException();
        }
    }
}
