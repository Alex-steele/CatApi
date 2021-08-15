using Cats.Logic.Mappers.Interfaces;
using Cats.Logic.Models;
using Cats.Logic.Queries.Interfaces;
using Cats.Logic.Wrappers;
using Cats.Service.Services.Interfaces;
using System.Threading.Tasks;

namespace Cats.Logic.Queries
{
    public class GetBreedQuery : IGetBreedQuery
    {
        private readonly ICatService catService;
        private readonly IBreedMapper mapper;

        public GetBreedQuery(
            ICatService catService,
            IBreedMapper mapper)
        {
            this.catService = catService;
            this.mapper = mapper;
        }

        public async Task<ResultWrapper<BreedModel[]>> ExecuteAsync(string prefix)
        {
            var breeds = await catService.GetBreeds(prefix);

            return ResultWrapper<BreedModel[]>.Success(mapper.Map(breeds));
        }
    }
}
