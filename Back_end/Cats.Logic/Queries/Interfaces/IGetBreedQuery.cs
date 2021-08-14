using Cats.Logic.Models;
using System.Threading.Tasks;

namespace Cats.Logic.Queries.Interfaces
{
    public interface IGetBreedQuery
    {
        Task<BreedModel[]> ExecuteAsync(string model);
    }
}
