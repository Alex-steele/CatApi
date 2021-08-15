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
                Weight = x.Weight?.Metric,
                Id = x.Id,
                Name = x.Name,
                Temperament = x.Temperament,
                Origin = x.Origin,
                Description = x.Description,
                LifeSpan = x.LifeSpan,
                Indoor = MapIntToBool(x.Indoor),
                Lap = MapIntToBool(x.Lap),
                AffectionLevel = x.AffectionLevel,
                ChildFriendly = x.ChildFriendly,
                DogFriendly = x.DogFriendly,
                EnergyLevel = x.EnergyLevel,
                Grooming = x.Grooming,
                HealthIssues = x.HealthIssues,
                Intelligence = x.Intelligence,
                SheddingLevel = x.SheddingLevel,
                SocialNeeds = x.SocialNeeds,
                Vocalisation = x.Vocalisation,
                Hairless = MapIntToBool(x.Hairless),
                Rare = MapIntToBool(x.Rare),
                WikipediaUrl = x.WikipediaUrl,
                Hypoallergenic = MapIntToBool(x.Hypoallergenic),
                ReferenceImageId = x.ReferenceImageId
            }).ToArray();
        }

        private static bool? MapIntToBool(int? input) => input == null ? (bool?) null : input == 1;
    }
}
