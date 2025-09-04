using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace SuperPoc.BuildingBlocks.Infrastructure.BackgroundJobs;

public static class QuartzScheduler
{
    public static IServiceCollection AddQuartzJobs(this IServiceCollection services)
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();
        });

        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });

        return services;
    }
}