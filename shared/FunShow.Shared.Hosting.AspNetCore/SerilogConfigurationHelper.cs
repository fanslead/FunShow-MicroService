using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace FunShow.Shared.Hosting.AspNetCore
{
    public static class SerilogConfigurationHelper
    {
        public static void Configure(string applicationName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
    #if DEBUG
                    .MinimumLevel.Debug()
    #else
                    .MinimumLevel.Information()
    #endif
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", $"{applicationName}")
                .WriteTo.Async(c => c.File("Logs/logs.txt"))
                // .WriteTo.Elasticsearch(
                //     new ElasticsearchSinkOptions(new Uri(configuration["ElasticSearch:Url"]))
                //     {
                //         AutoRegisterTemplate = true,
                //         AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                //         IndexFormat = "Walk-log-{0:yyyy.MM}"
                //     })
                .WriteTo.Async(c => c.Console())
                .CreateLogger();
        }
    }
}