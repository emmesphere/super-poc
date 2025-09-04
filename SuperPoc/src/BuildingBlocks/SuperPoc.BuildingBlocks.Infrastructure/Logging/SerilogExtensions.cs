using Microsoft.Extensions.Hosting;
using Serilog;

namespace SuperPoc.BuildingBlocks.Infrastructure.Logging;

public static class SerilogExtensions
{
    public static IHostBuilder UseSerilogLogging(this IHostBuilder hostBuilder) =>
        hostBuilder.UseSerilog((context, config) =>
        {
            config.ReadFrom.Configuration(context.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day);
        });
}