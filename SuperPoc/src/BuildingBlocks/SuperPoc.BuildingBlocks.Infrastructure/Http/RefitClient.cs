using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace SuperPoc.BuildingBlocks.Infrastructure.Http
{
    public static class RefitClientsExtensions
    {
        public static IServiceCollection AddRefitClients(this IServiceCollection services)
        {
            services.AddRefitClient<IExternalCatalogApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://external-api.com"));

            return services;
        }
    }

    public interface IExternalCatalogApi
    {
        [Get("/products/{id}")]
        Task<ProductDto> GetProductAsync(Guid id);
    }

    public record ProductDto(Guid Id, string Name, decimal Price);
}