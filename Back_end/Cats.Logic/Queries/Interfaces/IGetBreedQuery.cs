using Cats.Logic.Models;
using System.Threading.Tasks;
using Cats.Logic.Models.QueryModels;
using Cats.Logic.Wrappers;

namespace Cats.Logic.Queries.Interfaces
{
    public interface IGetBreedQuery
    {
        Task<ResultWrapper<BreedModel[]>> ExecuteAsync(GetBreedsModel model);
    }
}
