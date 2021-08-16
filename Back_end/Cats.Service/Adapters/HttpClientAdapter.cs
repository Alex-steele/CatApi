using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Cats.Service.Adapters.Interfaces;
using Serilog;
using Exception = System.Exception;

namespace Cats.Service.Adapters
{
    public class HttpClientAdapter : IHttpClient
    {
        private readonly HttpClient innerHttpClient;
        private readonly ILogger logger = Log.Logger;

        public HttpClientAdapter(IHttpClientFactory httpClientFactory)
        {
            innerHttpClient = httpClientFactory.CreateClient();
        }

        /// <summary>
        /// Sends an asynchronous GET request to the provided url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns>Deserialized response</returns>
        public async Task<T> GetAndDeserializeAsync<T>(string url) where T : class
        {
            T result;
            try
            {
                var response = await innerHttpClient.GetStreamAsync(url);
                result = await JsonSerializer.DeserializeAsync<T>(response);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "There was an error while contacting the cat API");
                throw;
            }

            return result;
        }

        public void AddDefaultRequestHeader(string name, string value)
        {
            innerHttpClient.DefaultRequestHeaders.Add(name, value);
        }
    }
}
