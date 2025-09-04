using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace SuperPoc.BuildingBlocks.Infrastructure.Messaging;

public static class MassTransitBus
{
    public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services, string rabbitMqUri)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqUri);

            });
        });
            
        return services;
    }
}