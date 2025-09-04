using Microsoft.Extensions.DependencyInjection;
using Rebus.Config;

namespace SuperPoc.BuildingBlocks.Infrastructure.Messaging;

public static class RebusBus
{
    public static IServiceCollection AddRebusWithAzureServiceBus(this IServiceCollection services,
        string connectionString)
    {
        services.AddRebus(configure => configure.Transport(t => t.UseAzureServiceBus(connectionString, "my-queue")));

        return services;
    }
}