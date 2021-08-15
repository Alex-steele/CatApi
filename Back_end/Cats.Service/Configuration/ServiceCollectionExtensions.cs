using Cats.Service.Services;
using Cats.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cats.Service.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServiceLayerServices(this IServiceCollection services)
        {
            services.AddTransient<ICatService, CatService>();

            return services;
        }
    }
}
