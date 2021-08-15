using Cats.Logic.Models;
using Cats.Logic.Wrappers;
using System.Threading.Tasks;

namespace Cats.Logic.Queries.Interfaces
{
    public interface IGetBreedsQuery
    {
        Task<ResultWrapper<BreedModel[]>> ExecuteAsync(string searchTerm);
    }
}
