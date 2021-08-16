using Cats.Logic.Wrappers;
using Cats.Service.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Cats.Logic.Queries.Interfaces;

namespace Cats.Logic.Queries
{
    public class GetImageUrlsQuery : IGetImageUrlsQuery
    {
        private readonly ICatService catService;

        public GetImageUrlsQuery(ICatService catService)
        {
            this.catService = catService;
        }

        public async Task<ResultWrapper<string[]>> ExecuteAsync(string id)
        {
            var urls = (await catService.GetImageUrls(id)).ToArray();

            return urls.Length == 0
                ? ResultWrapper<string[]>.NotFound
                : ResultWrapper<string[]>.Success(urls);
        }
    }
}
