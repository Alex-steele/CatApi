using Cats.Logic.Mappers;
using Cats.Logic.Mappers.Interfaces;
using Cats.Logic.Queries;
using Cats.Logic.Queries.Interfaces;
using Cats.Logic.Validators;
using Cats.Logic.Validators.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cats.Logic.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureLogicLayerServices(this IServiceCollection services)
        {
            services.AddTransient<IGetBreedsQuery, GetBreedsQuery>();
            services.AddTransient<IBreedMapper, BreedMapper>();
            services.AddTransient<IGetBreedsValidator, GetBreedsValidator>();

            return services;
        }
    }
}
