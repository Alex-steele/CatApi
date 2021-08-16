using Cats.Logic.Decorators;
using Cats.Logic.Queries;
using Cats.Logic.Queries.Interfaces;
using Cats.Logic.Validators;
using Cats.Logic.Validators.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Cats.Logic.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureLogicLayerServices(this IServiceCollection services)
        {
            services.AddTransient<IGetBreedsValidator, GetBreedsValidator>();
            services.AddTransient<IGetBreedsQuery, GetBreedsQuery>();
            services.Decorate<IGetBreedsQuery>((inner, provider) =>
                new GetBreedsQueryLoggingDecorator(inner, Log.Logger));
            services.AddTransient<IGetImageUrlsQuery, GetImageUrlsQuery>();

            return services;
        }
    }
}
