using AquiAmigao.Core.Entity;
using AquiAmigao.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiAmigaoMongoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpGet("{id}", Name = "GetPost")]
        public IActionResult GetPost(string id)
        {
            return Ok(_postService.GetPost(id));
        }

        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            _postService.AddPost(post);
            return CreatedAtRoute("GetPost", new { id = post.Id }, post);
        }
    }
}
