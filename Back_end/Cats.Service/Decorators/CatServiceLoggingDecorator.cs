using System.Diagnostics;
using Cats.Service.Entities;
using Cats.Service.Services.Interfaces;
using Serilog;
using System.Threading.Tasks;

namespace Cats.Service.Decorators
{
    public class CatServiceLoggingDecorator : ICatService
    {
        private readonly ICatService innerService;
        private readonly ILogger logger;

        public CatServiceLoggingDecorator(ICatService innerCatService, ILogger logger)
        {
            this.innerService = innerCatService;
            this.logger = logger;
        }

        public async Task<Breed[]> GetBreeds(string searchTerm)
        {
            var sw = Stopwatch.StartNew();
            var breeds = await innerService.GetBreeds(searchTerm);
            sw.Stop();
            var elapsedMillis = sw.ElapsedMilliseconds;

            logger.Information($"Attempted to retrieve breeds containing search term '{searchTerm}' - Elapsed ms: {elapsedMillis}");

            return breeds;
        }
    }
}
