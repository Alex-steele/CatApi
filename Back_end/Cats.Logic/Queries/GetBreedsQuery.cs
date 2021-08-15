using Cats.Logic.Mappers.Interfaces;
using Cats.Logic.Models;
using Cats.Logic.Queries.Interfaces;
using Cats.Logic.Wrappers;
using Cats.Service.Services.Interfaces;
using System.Threading.Tasks;
using Cats.Logic.Validators.Interfaces;

namespace Cats.Logic.Queries
{
    public class GetBreedsQuery : IGetBreedsQuery
    {
        private readonly IGetBreedsValidator validator;
        private readonly ICatService catService;
        private readonly IBreedMapper mapper;

        public GetBreedsQuery(
            IGetBreedsValidator validator,
            ICatService catService,
            IBreedMapper mapper)
        {
            this.validator = validator;
            this.catService = catService;
            this.mapper = mapper;
        }

        public async Task<ResultWrapper<BreedModel[]>> ExecuteAsync(string searchTerm)
        {
            var validationResult = await validator.ValidateAsync(searchTerm);

            if (!validationResult.IsValid)
            {
                return ResultWrapper<BreedModel[]>.ValidationError(validationResult); 
            }

            var breeds = await catService.GetBreeds(searchTerm);

            return breeds.Length == 0 
                ? ResultWrapper<BreedModel[]>.NotFound 
                : ResultWrapper<BreedModel[]>.Success(mapper.Map(breeds));
        }
    }
}
