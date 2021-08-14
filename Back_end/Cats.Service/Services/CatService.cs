using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Cats.Service.Entities;
using Cats.Service.Services.Interfaces;

namespace Cats.Service.Services
{
    public class CatService : ICatService
    {
        private static readonly HttpClient client = new HttpClient();
        private const string connectionString = "https://api.thecatapi.com/v1/breeds/search?q=";

        public CatService()
        {
            client.DefaultRequestHeaders.Add("x-api-key", "2132a5a5-4070-4671-b1ed-576bd9130921");
        }

        /// <summary>
        /// Returns all breeds which are prefixed with the input
        /// </summary>
        /// <param name="prefix">Prefix of breed name</param>
        /// <returns></returns>
        public async Task<Breed[]> GetBreeds(string prefix)
        {
            var serializedBreeds = await client.GetStreamAsync(connectionString + prefix);
            var breeds = await JsonSerializer.DeserializeAsync<Breed[]>(serializedBreeds);

            return breeds;
        }
    }
}
