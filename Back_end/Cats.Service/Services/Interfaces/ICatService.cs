using System.Threading.Tasks;
using Cats.Service.Entities;

namespace Cats.Service.Services.Interfaces
{
    public interface ICatService
    {
        Task<Breed[]> GetBreeds(string searchTerm);
        Task<string[]> GetImageUrls(string id);
    }
}
