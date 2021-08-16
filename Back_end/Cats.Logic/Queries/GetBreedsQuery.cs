using Cats.Logic.Mappers;
using Cats.Logic.Models;
using Cats.Logic.Queries.Interfaces;
using Cats.Logic.Validators.Interfaces;
using Cats.Logic.Wrappers;
using Cats.Service.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Cats.Logic.Queries
{
    public class GetBreedsQuery : IGetBreedsQuery
    {
        private readonly IGetBreedsValidator validator;
        private readonly ICatService catService;

        public GetBreedsQuery(
            IGetBreedsValidator validator,
            ICatService catService)
        {
            this.validator = validator;
            this.catService = catService;
        }

        public async Task<ResultWrapper<BreedModel[]>> ExecuteAsync(string searchTerm)
        {
            var validationResult = await validator.ValidateAsync(searchTerm);

            if (!validationResult.IsValid)
            {
                return ResultWrapper<BreedModel[]>.ValidationError(validationResult);
            }

            var breeds = (await catService.GetBreeds(searchTerm))
                .OrderBy(x => x.Name.ToLower().StartsWith(searchTerm.ToLower()) ? 1 : 2)
                .ToArray();

            return breeds.Length == 0
                ? ResultWrapper<BreedModel[]>.NotFound
                : ResultWrapper<BreedModel[]>.Success(new BreedMapper().Map(breeds));
        }
    }
}
