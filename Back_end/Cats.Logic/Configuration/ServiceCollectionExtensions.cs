using Cats.Logic.Mappers;
using Cats.Logic.Mappers.Interfaces;
using Cats.Logic.Queries;
using Cats.Logic.Queries.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cats.Logic.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureLogicLayerServices(this IServiceCollection services)
        {
            services.AddTransient<IGetBreedQuery, GetBreedQuery>();
            services.AddTransient<IBreedMapper, BreedMapper>();

            return services;
        }
    }
}
