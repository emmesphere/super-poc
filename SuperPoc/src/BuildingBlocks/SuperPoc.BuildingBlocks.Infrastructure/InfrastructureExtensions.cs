using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SuperPoc.BuildingBlocks.Infrastructure.BackgroundJobs;
using SuperPoc.BuildingBlocks.Infrastructure.Http;
using SuperPoc.BuildingBlocks.Infrastructure.Mail;
using SuperPoc.BuildingBlocks.Infrastructure.Messaging;
using SuperPoc.BuildingBlocks.Infrastructure.Observability;
using SuperPoc.BuildingBlocks.Infrastructure.Options;
using SuperPoc.BuildingBlocks.Infrastructure.Persistence;
using SuperPoc.BuildingBlocks.Infrastructure.Resilience;

namespace SuperPoc.BuildingBlocks.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionsStringsOptions>(configuration.GetSection("ConnectionStrings"));
        services.Configure<MessagingOptions>(configuration.GetSection("Messaging"));
        services.Configure<SmtpOptions>(configuration.GetSection("Smtp"));
        services.Configure<ObservabilityOptions>(configuration.GetSection("Observability"));

        services.AddBackgroundJobs();
        services.AddRefitClients();
        // Logging
        services.AddMessaging(configuration);
        services.AddObservability(configuration);
        services.AddMail();
        services.AddPersistence();
        services.AddResilience();
        
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>((provider, options) =>
        {
            var connectionString = provider.GetRequiredService<IOptions<ConnectionsStringsOptions>>().Value;
            options.UseSqlServer(connectionString.DefaultConnection);
        });
        
        return services;
    }

    private static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
    {
        // var messagingOptions = configuration.GetSection("Messaging").Get<MessagingOptions>()
        // ?? throw new InvalidOperationException("Messaging configuration missing");
        services.AddSingleton(provider =>
        {
            var messagingOptions = provider.GetRequiredService<IOptions<MessagingOptions>>().Value;
            services.AddMassTransitWithRabbitMq(messagingOptions.RabbitMq);
            services.AddRebusWithAzureServiceBus(messagingOptions.AzureServiceBus);
            services.AddWolverineWithRabbitMq(messagingOptions.RabbitMq);
            
            return services;
        });
        return services;
    }
    
    private static IServiceCollection AddResilience(this IServiceCollection services)
    {
        services.AddHttpClient("external")
            .AddPolicyHandler(PollyPolicies.GetRetryPolicy())
            .AddPolicyHandler(PollyPolicies.GetCircuitBreakerPolicy());

        return services;
    }
    
    private static IServiceCollection AddBackgroundJobs(this IServiceCollection services)
    {
        services.AddSingleton(provider =>
        {
            var connectionStrings = provider.GetRequiredService<IOptions<ConnectionsStringsOptions>>().Value;

            services.AddQuartzJobs();
            services.AddHangfireJobs(connectionStrings.DefaultConnection);

            return services;
        });

        return services;
    }
    
    private static IServiceCollection AddMail(this IServiceCollection services)
    {
        services.AddSingleton(provider =>
        {
            var smtpOptions = provider.GetRequiredService<IOptions<SmtpOptions>>().Value;
            return new MailService(
                smtpOptions.Host,
                smtpOptions.Port,
                smtpOptions.Username,
                smtpOptions.Password);
        });

        return services;
    }

    private static IServiceCollection AddObservability(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection("Observability").Get<ObservabilityOptions>() 
                      ?? throw new InvalidOperationException("Observability configuration missing");
        
        services.AddOpenTelemetryExtension(options!.ServiceName);
        
        return services;
    }
    
}