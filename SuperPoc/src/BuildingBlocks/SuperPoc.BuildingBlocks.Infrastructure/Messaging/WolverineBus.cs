
using Microsoft.Extensions.DependencyInjection;
using Wolverine;
using Wolverine.RabbitMQ;

namespace SuperPoc.BuildingBlocks.Infrastructure.Messaging;

public static class WolverineBus
{
    public static IServiceCollection AddWolverineWithRabbitMq(this IServiceCollection services, string rabbitMqUri)
    {
        services.AddWolverine(opts =>
        {
            opts.UseRabbitMq(rabbitMqUri);
        });
        
        return services;
    }
}