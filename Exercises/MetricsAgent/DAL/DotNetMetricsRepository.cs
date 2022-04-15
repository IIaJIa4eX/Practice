using MetricsAgent.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
        public interface IDotNetMetricsRepository : IRepository<DotNetMetric>
        {

        }

        public class DotNetMetricsRepository : IDotNetMetricsRepository
        {
            private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";


            public void Create(DotNetMetric item)
            {
                using var connection = new SQLiteConnection(ConnectionString);
                connection.Open();
                using var cmd = new SQLiteCommand(connection);

                cmd.CommandText = "INSERT INTO dotnetmetrics(value, time)VALUES(@value, @time)";
                cmd.Parameters.AddWithValue("@value", item.Value);

                cmd.Parameters.AddWithValue("@time", item.Time.TotalSeconds);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

            }

                public IList<CpuMetric> GetByTimePeriod()
                {
                    using var connection = new SQLiteConnection(ConnectionString);
                    connection.Open();
                    using var cmd = new SQLiteCommand(connection);

                    cmd.CommandText = "SELECT * FROM dotnetmetrics WHERE "; //TODO
                    var returnList = new List<CpuMetric>();

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            returnList.Add(new CpuMetric
                            {
                                Id = reader.GetInt32(0),
                                Value = reader.GetInt32(1),
                                Time = TimeSpan.FromSeconds(reader.GetInt32(2))
                            });
                        }
                 }
            return returnList;
        }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

            public IList<DotNetMetric> GetAll()
            {
                throw new NotImplementedException();
            }

            public DotNetMetric GetById(int id)
            {
                throw new NotImplementedException();
            }

            public void Update(DotNetMetric item)
            {
                throw new NotImplementedException();
            }
        }

}
