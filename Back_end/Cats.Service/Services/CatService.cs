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
        private IConfigurationRoot ConfigRoot;

        public CatService(IConfiguration configRoot)
        {
            ConfigRoot = (IConfigurationRoot) configRoot;
            Client.DefaultRequestHeaders.Add("x-api-key", ConfigRoot["Keys:ApiKey"]);
        }

        /// <summary>
        /// Gets breeds by search term
        /// </summary>
        /// <param name="searchTerm">Term contained in the breed name</param>
        /// <returns>All breeds containing the search term</returns>
        public async Task<Breed[]> GetBreeds(string searchTerm)
        {
            var serializedBreeds = await Client.GetStreamAsync(ConfigRoot.GetConnectionString("BreedSearchUrl") + searchTerm);
            var breeds = await JsonSerializer.DeserializeAsync<Breed[]>(serializedBreeds);

            return breeds;
        }
    }
}
