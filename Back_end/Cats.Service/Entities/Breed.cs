using System.Text.Json.Serialization;

namespace Cats.Service.Entities
{
    public class Breed
    {
        [JsonPropertyName("weight")]
        public Weight Weight { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("temperament")]
        public string Temperament { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("life_span")]
        public string LifeSpan { get; set; }

        [JsonPropertyName("indoor")]
        public int? Indoor { get; set; }

        [JsonPropertyName("lap")]
        public int? Lap { get; set; }

        [JsonPropertyName("affection_level")]
        public int? AffectionLevel { get; set; }

        [JsonPropertyName("child_friendly")]
        public int? ChildFriendly { get; set; }

        [JsonPropertyName("dog_friendly")]
        public int? DogFriendly { get; set; }

        [JsonPropertyName("energy_level")]
        public int? EnergyLevel { get; set; }

        [JsonPropertyName("grooming")]
        public int? Grooming { get; set; }

        [JsonPropertyName("health_issues")]
        public int? HealthIssues { get; set; }

        [JsonPropertyName("intelligence")]
        public int? Intelligence { get; set; }

        [JsonPropertyName("shedding_level")]
        public int? SheddingLevel { get; set; }

        [JsonPropertyName("social_needs")]
        public int? SocialNeeds { get; set; }

        [JsonPropertyName("vocalisation")]
        public int? Vocalisation { get; set; }

        [JsonPropertyName("hairless")]
        public int? Hairless { get; set; }

        [JsonPropertyName("rare")]
        public int? Rare { get; set; }

        [JsonPropertyName("wikipedia_url")]
        public string WikipediaUrl { get; set; }

        [JsonPropertyName("hypoallergenic")]
        public int? Hypoallergenic { get; set; }

        [JsonPropertyName("reference_image_id")]
        public string ReferenceImageId { get; set; }
    }
}
