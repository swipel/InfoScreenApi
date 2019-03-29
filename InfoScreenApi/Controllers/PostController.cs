using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using InfoScreenApi.Manager;
using InfoScreenApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoScreenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        readonly PostManager _postManager = new PostManager();

        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postManager.GetAllPost();
            return Ok(posts);
        }

        [HttpPost]
        public IActionResult Post(PostDTO postDto)
        {            
            int success = _postManager.CreatePost(postDto);
            if (success == 1)
            {
                return Ok(postDto);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(PostDTO postDto)
        {
            int success = _postManager.UpdatePost(postDto);
            if (success == 1)
            {
                return Ok(postDto);
            }
            return BadRequest();
        }
        
        [HttpDelete]
        public IActionResult Delete(PostDTO postDto)
        {
            int success = _postManager.DeletePost(postDto);
            if (success == 1)
            {
                return Ok(postDto);
            }
            return BadRequest();
        }
    }
}