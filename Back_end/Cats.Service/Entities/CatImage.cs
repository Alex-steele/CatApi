using System.Text.Json.Serialization;

namespace Cats.Service.Entities
{
    public class CatImage
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
