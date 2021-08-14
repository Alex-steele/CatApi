using Cats.Logic.Models.QueryModels;
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
        /// Returns all breeds which are prefixed with the prefix property of the input model
        /// </summary>
        /// <param name="model">Simple model containing prefix of breed name</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(GetBreedsModel model)
        {
            var result = await getBreedQuery.ExecuteAsync(model);

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
