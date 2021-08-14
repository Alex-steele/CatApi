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

        [JsonPropertyName("cfa_url")]
        public string CfaUrl { get; set; }

        [JsonPropertyName("vetstreet_url")]
        public string VetstreetUrl { get; set; }

        [JsonPropertyName("vcahospitals_url")]
        public string VcahospitalsUrl { get; set; }

        [JsonPropertyName("temperament")]
        public string Temperament { get; set; }

        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonPropertyName("country_codes")]
        public string CountryCodes { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("life_span")]
        public string LifeSpan { get; set; }

        [JsonPropertyName("indoor")]
        public bool Indoor { get; set; }

        [JsonPropertyName("lap")]
        public bool Lap { get; set; }

        [JsonPropertyName("alt_names")]
        public string AltNames { get; set; }

        [JsonPropertyName("adaptability")]
        public int Adaptability { get; set; }

        [JsonPropertyName("affection_level")]
        public int AffectionLevel { get; set; }

        [JsonPropertyName("child_friendly")]
        public int ChildFriendly { get; set; }

        [JsonPropertyName("dog_friendly")]
        public int DogFriendly { get; set; }

        [JsonPropertyName("energy_level")]
        public int EnergyLevel { get; set; }

        [JsonPropertyName("grooming")]
        public int Grooming { get; set; }

        [JsonPropertyName("health_issues")]
        public int HealthIssues { get; set; }

        [JsonPropertyName("intelligence")]
        public int Intelligence { get; set; }

        [JsonPropertyName("shedding_level")]
        public int SheddingLevel { get; set; }

        [JsonPropertyName("social_needs")]
        public int SocialNeeds { get; set; }

        [JsonPropertyName("stranger_friendly")]
        public int StrangerFriendly { get; set; }

        [JsonPropertyName("vocalisation")]
        public int Vocalisation { get; set; }

        [JsonPropertyName("experimental")]
        public bool Experimental { get; set; }

        [JsonPropertyName("hairless")]
        public bool Hairless { get; set; }

        [JsonPropertyName("natural")]
        public bool Natural { get; set; }

        [JsonPropertyName("rare")]
        public bool Rare { get; set; }

        [JsonPropertyName("rex")]
        public bool Rex { get; set; }

        [JsonPropertyName("suppressed_tail")]
        public bool SuppressedTail { get; set; }

        [JsonPropertyName("short_legs")]
        public bool ShortLegs { get; set; }

        [JsonPropertyName("wikipedia_url")]
        public string WikipediaUrl { get; set; }

        [JsonPropertyName("hypoallergenic")]
        public bool Hypoallergenic { get; set; }

        [JsonPropertyName("reference_image_id")]
        public string ReferenceImageId { get; set; }
    }
}
