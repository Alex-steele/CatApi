using Microsoft.AspNetCore.Mvc;

namespace Cats.WebAPI.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public IActionResult Error() => Problem();
    }
}
