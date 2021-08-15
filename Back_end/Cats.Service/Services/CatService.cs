using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Cats.Service.Entities;
using Cats.Service.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Cats.Service.Services
{
    public class CatService : ICatService
    {
        private static readonly HttpClient Client = new HttpClient();
        private readonly IConfigurationRoot configRoot;

        public CatService(IConfiguration configRoot)
        {
            this.configRoot = (IConfigurationRoot) configRoot;
            Client.DefaultRequestHeaders.Add("x-api-key", this.configRoot["Keys:ApiKey"]);
        }

        /// <summary>
        /// Gets breeds by search term
        /// </summary>
        /// <param name="searchTerm">Term contained in the breed name</param>
        /// <returns>All breeds containing the search term</returns>
        public async Task<Breed[]> GetBreeds(string searchTerm)
        {
            var serializedBreeds = await Client.GetStreamAsync(configRoot.GetConnectionString("BreedSearchUrl") + searchTerm);
            var breeds = await JsonSerializer.DeserializeAsync<Breed[]>(serializedBreeds);

            return breeds;
        }
    }
}
