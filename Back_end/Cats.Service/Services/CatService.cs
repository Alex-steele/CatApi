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
        private const string connectionString = "https://api.thecatapi.com/v1/breeds/search?q=sib";

        public CatService()
        {
            client.DefaultRequestHeaders.Add("x-api-key", "2132a5a5-4070-4671-b1ed-576bd9130921");
        }

        public async Task<Breed[]> GetBreeds(string id)
        {
            var serializedBreeds = await client.GetStreamAsync(connectionString + id);
            var breeds = await JsonSerializer.DeserializeAsync<Breed[]>(serializedBreeds);

            return breeds;
        }
    }
}
