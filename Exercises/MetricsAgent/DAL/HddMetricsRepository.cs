using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{

    public interface IHddMetricsRepository : IRepository<HddMetric>
    {

    }

    public class HddMetricsRepository : IHddMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";


        public void Create(HddMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "INSERT INTO hddmetrics(value, time)VALUES(@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);

            cmd.Parameters.AddWithValue("@time", item.Time.TotalSeconds);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<HddMetric> GetAll()
        {
            throw new NotImplementedException();
        }

        public HddMetric GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<HddMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);

            cmd.CommandText = "SELECT * FROM hddmetrics WHERE time >= @fromTime AND time <= @toTime";
            cmd.Parameters.AddWithValue("@fromTime", fromTime.TotalSeconds);
            cmd.Parameters.AddWithValue("@toTime", toTime.TotalSeconds);
            cmd.Prepare();
            var returnList = new List<HddMetric>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new HddMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = TimeSpan.FromSeconds(reader.GetInt32(2))
                    });
                }
            }
            return returnList;
        }

        public void Update(HddMetric item)
        {
            throw new NotImplementedException();
        }

    }
}
