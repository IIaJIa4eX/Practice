using AutoMapper;
using FluentMigrator.Runner;
using MetricsProject_ver1.Client;
using MetricsProject_ver1.DAL.Repositories.AgentRepositories;
using MetricsProject_ver1.DAL.Repositories.IAgentsRepositories;
using MetricsProject_ver1.DAL.Repositories.MetricsRepositories;
using MetricsProject_ver1.Jobs;
using MetricsProject_ver1.Mapper;
using MetricsProject_ver1.Migrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;

namespace MetricsProject_ver1
{
    public class Startup
    {
        const string ConnectionString = "Data Source = metrics.db; Version = 3;";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            
            services.AddHttpClient();
            
            services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();
            services.AddSingleton<IDotNetMetricsRepository, DotNetMetricsRepository>();
            services.AddSingleton<IHddMetricsRepository, HddMetricsRepository>();
            services.AddSingleton<INetWorkMetricsRepository, NetWorkMetricsRepository>();
            services.AddSingleton<IRamMetricsRepository, RamMetricsRepository>();
            services.AddSingleton<IAgentRepository, AgentRepository>();
            services.AddSingleton<IMetricsAgentClient, MetricsAgentClient>();
            services.AddMvc().AddNewtonsoftJson();

            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddHttpClient<IMetricsAgentClient,
                MetricsAgentClient>().AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(1000)));

            services.AddFluentMigratorCore()
           .ConfigureRunner(rb => rb
                       .AddSQLite()
                       .WithGlobalConnectionString(ConnectionString)
                       .ScanIn(typeof(Migrations_1).Assembly).For.Migrations()
                       ).AddLogging(lb => lb
                       .AddFluentMigratorConsole());

            services.AddHostedService<QuartzHostedService>();
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton(new JobSchedule(
            jobType: typeof(CpuMetricJob),
            cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<NetWorkMetricJob>();
            services.AddSingleton(new JobSchedule(
            jobType: typeof(NetWorkMetricJob),
            cronExpression: "0/5 * * * * ?"));

            services.AddSingleton<RamMetricJob>();
            services.AddSingleton(new JobSchedule(
            jobType: typeof(RamMetricJob),
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
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

            migrationRunner.MigrateUp();
        }
    }
}
