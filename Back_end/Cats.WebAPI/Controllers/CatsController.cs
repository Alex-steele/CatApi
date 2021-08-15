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
        /// Gets breeds by prefix
        /// </summary>
        /// <param name="prefix">Prefix of the breed name</param>
        /// <returns>All breeds prefixed with the input</returns>
        /// <response code="200">Returns all breeds prefixed with the input</response>
        /// <response code="404">If there are no breeds prefixed by the input</response>
        [HttpGet("{prefix}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string prefix)
        {
            var result = await getBreedQuery.ExecuteAsync(prefix);

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
