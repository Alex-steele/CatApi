using Cats.Logic.Mappers.Interfaces;
using Cats.Logic.Models;
using Cats.Service.Entities;
using System.Linq;

namespace Cats.Logic.Mappers
{
    public class BreedMapper : IBreedMapper
    {
        public BreedModel[] Map(Breed[] breeds)
        {
            return breeds.Select(x => new BreedModel
            {
                Weight = new WeightModel
                {
                    Imperial = x.Weight.Imperial,
                    Metric = x.Weight.Metric
                },
                Id = x.Id,
                Name = x.Name,
                CfaUrl = x.CfaUrl,
                VetstreetUrl = x.VetstreetUrl,
                VcahospitalsUrl = x.VcahospitalsUrl,
                Temperament = x.Temperament,
                Origin = x.Origin,
                CountryCodes = x.CountryCodes,
                CountryCode = x.CountryCode,
                Description = x.Description,
                LifeSpan = x.LifeSpan,
                Indoor = MapIntToBool(x.Indoor),
                Lap = MapIntToBool(x.Lap),
                AltNames = x.AltNames,
                Adaptability = x.Adaptability,
                AffectionLevel = x.AffectionLevel,
                ChildFriendly = x.ChildFriendly,
                DogFriendly = x.DogFriendly,
                EnergyLevel = x.EnergyLevel,
                Grooming = x.Grooming,
                HealthIssues = x.HealthIssues,
                Intelligence = x.Intelligence,
                SheddingLevel = x.SheddingLevel,
                SocialNeeds = x.SocialNeeds,
                StrangerFriendly = x.StrangerFriendly,
                Vocalisation = x.Vocalisation,
                Experimental = MapIntToBool(x.Experimental),
                Hairless = MapIntToBool(x.Hairless),
                Natural = MapIntToBool(x.Natural),
                Rare = MapIntToBool(x.Rare),
                Rex = MapIntToBool(x.Rex),
                SuppressedTail = MapIntToBool(x.SuppressedTail),
                ShortLegs = MapIntToBool(x.ShortLegs),
                WikipediaUrl = x.WikipediaUrl,
                Hypoallergenic = MapIntToBool(x.Hypoallergenic),
                ReferenceImageId = x.ReferenceImageId
            }).ToArray();
        }

        private static bool MapIntToBool(int input) => input == 1;
    }
}
