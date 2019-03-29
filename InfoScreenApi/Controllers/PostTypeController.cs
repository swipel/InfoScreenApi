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
    public class PostTypeController : ControllerBase
    {
        readonly PostTypeManager _postTypeManager = new PostTypeManager();

        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postTypeManager.GetAllPostType();
            return Ok(posts);
        }
    }
}