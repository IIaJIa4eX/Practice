using MetricsAgent.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent
{
    public class Startup
    {

        private List<string> dbs = new List<string>() { "cpumetrics", "dotnetmetrics", "hddmetrics", "networkmetrics", "rammetrics" };
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            ConfigureSqlLiteConnection(services);
            services.AddScoped<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddScoped<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddScoped<IHddMetricsRepository, HddMetricsRepository>();
            services.AddScoped<INetWorkMetricsRepository, NetWorkMetricsRepository>();
            services.AddScoped<IRamMetricsRepository, RamMetricsRepository>();
            
            services.AddMvc().AddNewtonsoftJson();
        }

        private void ConfigureSqlLiteConnection(IServiceCollection services)
        {
            const string connectionString = "Data Source = metrics.db; Version = 3; Pooling = true; Max Pool Size = 100; ";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            PrepareSchema(connection);
            PrepareData(connection);
        }

        private void PrepareData(SQLiteConnection connection)
        {
            TimeSpan ts1 = new TimeSpan(12, 00, 00);
            TimeSpan ts2 = new TimeSpan(12, 10, 00);
            TimeSpan ts3 = new TimeSpan(12, 20, 00);
            
            using (var cmd = new SQLiteCommand(connection))
            {
                foreach (string item in dbs)
                {
                    cmd.CommandText = $"INSERT INTO {item}(value, time)VALUES(@value, @time)";
                    cmd.Parameters.AddWithValue("@value", 600);
                    cmd.Parameters.AddWithValue("@time", ts1.TotalSeconds);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = $"INSERT INTO {item}(value, time)VALUES(@value, @time)";
                    cmd.Parameters.AddWithValue("@value", 700);
                    cmd.Parameters.AddWithValue("@time", ts2.TotalSeconds);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = $"INSERT INTO {item}(value, time)VALUES(@value, @time)";
                    cmd.Parameters.AddWithValue("@value", 800);
                    cmd.Parameters.AddWithValue("@time", ts3.TotalSeconds);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void PrepareSchema(SQLiteConnection connection)
        {
            using (var command = new SQLiteCommand(connection))
            {
                foreach (string item in dbs)
                {
                    command.CommandText = $"DROP TABLE IF EXISTS {item}";
                    command.ExecuteNonQuery();

                    command.CommandText = $@"CREATE TABLE {item}(id INTEGER
                    PRIMARY KEY,
                    value INT, time INT)";
                    command.ExecuteNonQuery();
                }

            }
        }


            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
