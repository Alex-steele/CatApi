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
        private readonly IGetBreedsQuery getBreedsQuery;
        private readonly IGetImageUrlsQuery getImageUrlsQuery;

        public CatsController(IGetBreedsQuery getBreedsQuery, IGetImageUrlsQuery getImageUrlsQuery)
        {
            this.getBreedsQuery = getBreedsQuery;
            this.getImageUrlsQuery = getImageUrlsQuery;
        }

        /// <summary>
        /// Gets breeds by search term
        /// </summary>
        /// <param name="searchTerm">Term contained in the breed name</param>
        /// <returns>All breeds containing the search term, with breeds prefixed by the search term at the top</returns>
        /// <response code="200">Returns all breeds containing the search term, with breeds prefixed by the search term at the top</response>
        /// <response code="404">If there are no breeds containing the search term</response>
        /// <response code="400">If the search term is invalid</response>
        /// <response code="404">If the app throws an error</response>
        [HttpGet("breeds/{searchTerm}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBreeds(string searchTerm)
        {
            var result = await getBreedsQuery.ExecuteAsync(searchTerm);

            return ProcessResult(result);
        }

        /// <summary>
        /// Gets image urls by id
        /// </summary>
        /// <param name="id">Breed id</param>
        /// <returns>Array of image urls</returns>
        /// <response code="200">Returns array of image urls</response>
        /// <response code="404">If there are no image urls for the given id</response>
        /// <response code="500">If the app throws an error</response>
        [HttpGet("images/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetImageUrls(string id)
        {
            var result = await getImageUrlsQuery.ExecuteAsync(id);

            return ProcessResult(result);
        }

        private IActionResult ProcessResult<T>(ResultWrapper<T> resultWrapper)
        {
            return resultWrapper.Result switch
            {
                Result.Success => Ok(resultWrapper.Payload),
                Result.NotFound => NotFound(),
                Result.ValidationError => new BadRequestObjectResult(resultWrapper.Validation),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }
    }
}
