﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
