using System.Threading.Tasks;
using Cats.Logic.Wrappers;

namespace Cats.Logic.Queries.Interfaces
{
    public interface IGetImageUrlsQuery
    {
        Task<ResultWrapper<string[]>> ExecuteAsync(string id);
    }
}