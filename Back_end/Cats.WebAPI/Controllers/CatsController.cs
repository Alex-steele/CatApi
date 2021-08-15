using Cats.Logic.Queries.Interfaces;
using Cats.Logic.Wrappers;
using Cats.Logic.Wrappers.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cats.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatsController : ControllerBase
    {
        private readonly IGetBreedQuery getBreedQuery;

        public CatsController(IGetBreedQuery getBreedQuery)
        {
            this.getBreedQuery = getBreedQuery;
        }

        /// <summary>
        /// Gets breeds by search term
        /// </summary>
        /// <param name="searchTerm">Term contained in the breed name</param>
        /// <returns>All breeds containing the search term</returns>
        /// <response code="200">Returns all breeds containing the search term</response>
        /// <response code="404">If there are no breeds containing the search term</response>
        [HttpGet("{searchTerm}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string searchTerm)
        {
            var result = await getBreedQuery.ExecuteAsync(searchTerm);

            return ProcessResult(result);
        }

        private IActionResult ProcessResult<T>(ResultWrapper<T> resultWrapper)
        {
            return resultWrapper.Result switch
            {
                Result.Success => Ok(resultWrapper.Payload),
                Result.NotFound => NotFound(),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }
    }
}
