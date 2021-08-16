using System.Threading.Tasks;

namespace Cats.Service.Adapters.Interfaces
{
    public interface IHttpClient
    {
        /// <summary>
        /// Sends an asynchronous GET request to the provided url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns>Deserialized response</returns>
        Task<T> GetAndDeserializeAsync<T>(string url) where T : class;
        public void AddDefaultRequestHeader(string name, string value);
    }
}
