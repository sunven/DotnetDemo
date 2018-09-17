using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JWT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new [] { "value1", "value2" };
        }
    }
}
