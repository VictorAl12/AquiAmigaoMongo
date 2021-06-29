using AquiAmigao.Core.Entity;
using AquiAmigao.Core.Interface;
using AquiAmigao.Core.Model;
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
            var response = _postService.GetPosts();
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpGet("{id}", Name = "GetPost")]
        public IActionResult GetPost(string id)
        {
            var response = _postService.GetPost(id);
            return new ObjectResult(response) { StatusCode = 200 };
        }

        [HttpPost]
        public IActionResult AddPost(PostRequest request)
        {
            var response =_postService.AddPost(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpPut]
        public IActionResult UpdatePost(PostRequest request)
        {
            var response = _postService.UpdatePost(request);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(string id)
        {
            var response = _postService.DeleteUsuario(id);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
