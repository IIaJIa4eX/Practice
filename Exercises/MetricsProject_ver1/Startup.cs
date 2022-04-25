using FluentMigrator.Runner;
using MetricsProject_ver1.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
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
            services.AddMvc().AddNewtonsoftJson();
            services.AddHttpClient();
            services.AddControllers();

            services.AddHttpClient<IMetricsAgentClient,
                MetricsAgentClient>().AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(1000)));

            services.AddFluentMigratorCore()
           .ConfigureRunner(rb => rb
                       .AddSQLite()
                       .WithGlobalConnectionString(ConnectionString)
                       .ScanIn(typeof(Startup).Assembly).For.Migrations()
                       ).AddLogging(lb => lb
                       .AddFluentMigratorConsole());

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

            using var scope = app.ApplicationServices.CreateScope();
            var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            migrator.MigrateUp();
        }
    }
}
