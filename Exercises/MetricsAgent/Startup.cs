using AutoMapper;
using Core;
using Dapper;
using FluentMigrator.Runner;
using MetricsAgent.DAL;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL.Migrations;
using MetricsAgent.Jobs;
using MetricsAgent.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent
{
    public class Startup
    {

        const string ConnectionString = "Data Source = metrics.db; Version = 3;";
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
            services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddSingleton<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddSingleton<IHddMetricsRepository, HddMetricsRepository>();
            services.AddSingleton<INetWorkMetricsRepository, NetWorkMetricsRepository>();
            services.AddSingleton<IRamMetricsRepository, RamMetricsRepository>();
            services.AddTransient<INotifierMediatorService, NotifierMediatorService>();
            services.AddMvc().AddNewtonsoftJson();

            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddFluentMigratorCore()
           .ConfigureRunner(rb => rb
                       .AddSQLite()
                       .WithGlobalConnectionString(ConnectionString)
                       .ScanIn(typeof(FirstMigration).Assembly).For.Migrations()
                       ).AddLogging(lb => lb
                       .AddFluentMigratorConsole());


            services.AddHostedService<QuartzHostedService>();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton(new JobSchedule(
            jobType: typeof(CpuMetricJob),
            cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<RamMetricJob>();
            services.AddSingleton(new JobSchedule(
            jobType: typeof(RamMetricJob),
            cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<NetWorkMetricJob>();
            services.AddSingleton(new JobSchedule(
            jobType: typeof(NetWorkMetricJob),
            cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<DotNetMetricJob>();
            services.AddSingleton(new JobSchedule(
            jobType: typeof(DotNetMetricJob),
            cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<HddMetricJob>();
            services.AddSingleton(new JobSchedule(
            jobType: typeof(HddMetricJob),
            cronExpression: "0/5 * * * * ?"));



        }

        private void ConfigureSqlLiteConnection(IServiceCollection services)
        {
            //const string connectionString = "Data Source = metrics.db; Version = 3; Pooling = true; Max Pool Size = 100; ";
            var connection = new SQLiteConnection(ConnectionString);
            connection.Open();



            //PrepareSchema(connection);
            //PrepareData(connection);
        }

        private void PrepareData(SQLiteConnection connection)
        {
            TimeSpan ts1 = new TimeSpan(12, 00, 12);
            TimeSpan ts2 = new TimeSpan(12, 10, 12);
            TimeSpan ts3 = new TimeSpan(1, 12, 20, 12);
            
            using (var cmd = new SQLiteCommand(connection))
            {
                foreach (string item in dbs)
                {
                    connection.Execute($"INSERT INTO {item}(value, time) VALUES(@value, @time)",
                        new
                    {
                        value = 600,
                        time = ts1.TotalSeconds
                    });

                    connection.Execute($"INSERT INTO {item}(value, time) VALUES(@value, @time)",
                    new
                    {
                        value = 700,
                        time = ts2.TotalSeconds
                    });

                    connection.Execute($"INSERT INTO {item}(value, time) VALUES(@value, @time)",
                    new
                    {
                        value = 800,
                        time = ts3.TotalSeconds
                    });
                }
            }
        }
        //private void PrepareSchema(SQLiteConnection connection)
        //{
        //    using (var command = new SQLiteCommand(connection))
        //    {
        //        foreach (string item in dbs)
        //        {
        //            command.CommandText = $"DROP TABLE IF EXISTS {item}";
        //            command.ExecuteNonQuery();

        //            command.CommandText = $@"CREATE TABLE {item}(id INTEGER
        //            PRIMARY KEY,
        //            value INT, time INT)";
        //            command.ExecuteNonQuery();
        //        }

        //    }
        //}


            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //migrationRunner.MigrateUp();

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

            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            migrator.MigrateUp();
            
        }
    }
}
