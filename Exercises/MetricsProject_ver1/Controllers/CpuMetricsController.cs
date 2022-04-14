using MetricsProject_ver1.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsProject_ver1.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {

        private readonly ILogger<CpuMetricsController> _logger;

        public CpuMetricsController(ILogger<CpuMetricsController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "Конструткор отработал в CpuMetricsController");
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAllCluster(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

        [HttpGet("sql-test")]
        public IActionResult TryToSqlLite()
        {
            string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                using var cmd = new SQLiteCommand(stm, con);
                string version = cmd.ExecuteScalar().ToString();
                return Ok(version);
            }
        }

        [HttpGet("sql-read-write-test")]
        public IActionResult TryToInsertAndRead()
        {
            // Создаём строку подключения в виде базы данных в оперативной

            string connectionString = "Data Source=:memory:";
            // Создаём соединение с базой данных
            using (var connection = new SQLiteConnection(connectionString))
            {
                // Открываем соединение
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DROP TABLE IF EXISTS cpumetrics";
                    // Отправляем запрос в базу данных
                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE cpumetrics(id INTEGER
                    PRIMARY KEY,
                    value INT, time INT)";
                    command.ExecuteNonQuery();

                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(10, 1)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(50, 2)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(75, 4)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO cpumetrics(value, time)VALUES(90, 5)";
                    command.ExecuteNonQuery();

                    // Создаём строку для выборки данных из базы
                    // LIMIT 3 обозначает, что мы достанем только 3 записи
                    string readQuery = "SELECT * FROM cpumetrics LIMIT 3";
                    // Создаём массив, в который запишем объекты с данными из
                    //базы данных
                    var returnArray = new CpuMetric[3];
                    // Изменяем текст команды на наш запрос чтения
                    command.CommandText = readQuery;
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        var counter = 0;
                        while (reader.Read())
                        {
                            returnArray[counter] = new CpuMetric
                            {
                                Id = reader.GetInt32(0), 
                                Value = reader.GetInt32(1), 
                                    Time = reader.GetInt64(2)
                            };
                            counter++;
                        }
                    }

                    return Ok(returnArray);
                }

            }
        }

    }
}
