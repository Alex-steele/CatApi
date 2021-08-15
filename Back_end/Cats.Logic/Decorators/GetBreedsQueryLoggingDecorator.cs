using System.Linq;
using Cats.Logic.Models;
using Cats.Logic.Queries.Interfaces;
using Cats.Logic.Wrappers;
using Serilog;
using System.Threading.Tasks;
using Cats.Logic.Wrappers.Enums;

namespace Cats.Logic.Decorators
{
    public class GetBreedsQueryLoggingDecorator : IGetBreedsQuery
    {
        private readonly IGetBreedsQuery innerQuery;
        private readonly ILogger logger;

        public GetBreedsQueryLoggingDecorator(IGetBreedsQuery innerQuery, ILogger logger)
        {
            this.innerQuery = innerQuery;
            this.logger = logger;
        }

        public async Task<ResultWrapper<BreedModel[]>> ExecuteAsync(string searchTerm)
        {
            var result = await innerQuery.ExecuteAsync(searchTerm);

            switch (result.Result)
            {
                case Result.ValidationError:
                    logger.Warning($"Validation error given for search term '{searchTerm}'");
                    break;
                case Result.NotFound:
                    logger.Information($"No results found for search term '{searchTerm}'");
                    break;
                case Result.Success:
                    logger.Information($"Retrieved the following breeds for search term '{searchTerm}': {string.Join(", ", result.Payload.Select(x => x.Name))}");
                    break;
                default:
                    logger.Warning("Unexpected result");
                    break;
            }

            return result;
        }
    }
}
