using System.Text.Json.Serialization;

namespace Cats.Service.Entities
{
    public class Weight
    {
        [JsonPropertyName("metric")]
        public string Metric { get; set; }
    }
}
