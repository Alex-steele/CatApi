using System.Linq;
using Cats.Service.Entities;
using Cats.Service.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Cats.Service.Adapters.Interfaces;

namespace Cats.Service.Services
{
    public class CatService : ICatService
    {
        private readonly IConfigurationRoot configRoot;
        private readonly IHttpClient client;

        public CatService(IHttpClient client, IConfiguration configRoot)
        {
            this.configRoot = (IConfigurationRoot)configRoot;
            this.client = client;
            client.AddDefaultRequestHeader("x-api-key", configRoot["Keys:ApiKey"]);
        }

        /// <summary>
        /// Gets breeds by search term
        /// </summary>
        /// <param name="searchTerm">Term contained in the breed name</param>
        /// <returns>All breeds containing the search term</returns>
        public async Task<Breed[]> GetBreeds(string searchTerm)
        {
            return await client.GetAndDeserializeAsync<Breed[]>(configRoot.GetConnectionString("BreedSearchUrl") + searchTerm)
                   ?? new Breed[0];
        }

        /// <summary>
        /// Gets image urls by id
        /// </summary>
        /// <param name="id">Breed id</param>
        /// <returns>Array of image urls</returns>
        public async Task<string[]> GetImageUrls(string id)
        {
            return (await client.GetAndDeserializeAsync<CatImage[]>(configRoot.GetConnectionString("ImageUrl") + id))
                   ?.Select(x => x.Url)
                   .ToArray()
                   ?? new string[0];
        }
    }
}
