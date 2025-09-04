using Hangfire;
using Microsoft.Extensions.DependencyInjection;

namespace SuperPoc.BuildingBlocks.Infrastructure.BackgroundJobs;

public static class HangfireScheduler
{
    public static IServiceCollection AddHangfireJobs(this IServiceCollection services, string connectionString)
    {
        services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
        services.AddHangfireServer();

        return services;
    }
}