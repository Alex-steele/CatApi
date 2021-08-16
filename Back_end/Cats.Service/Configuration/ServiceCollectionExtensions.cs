using Cats.Service.Adapters;
using Cats.Service.Adapters.Interfaces;
using Cats.Service.Decorators;
using Cats.Service.Services;
using Cats.Service.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Cats.Service.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServiceLayerServices(this IServiceCollection services)
        {
            services.AddTransient<IHttpClient, HttpClientAdapter>();
            services.AddTransient<ICatService, CatService>();
            services.Decorate<ICatService>((inner, provider) =>
                new CatServiceLoggingDecorator(inner, Log.Logger));

            return services;
        }
    }
}
