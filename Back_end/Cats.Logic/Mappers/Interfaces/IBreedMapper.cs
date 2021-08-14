using Cats.Logic.Models;
using Cats.Service.Entities;

namespace Cats.Logic.Mappers.Interfaces
{
    public interface IBreedMapper
    {
        BreedModel[] Map(Breed[] breeds);
    }
}
