using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoScreenApi.Manager;
using InfoScreenApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoScreenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntervalController : ControllerBase
    {
        readonly IntervalManager _intervalManager = new IntervalManager();
        
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IntervalDTO interval = _intervalManager.GetInterval();
            return Ok(interval);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put(IntervalDTO interval)
        {
            int success = _intervalManager.UpdateInterval(interval);
            if (success == 1)
                return Ok();
            return BadRequest();
        }
    }
}