using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cats.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatsController : ControllerBase
    {
        public CatsController()
        {
        }
    }
}
