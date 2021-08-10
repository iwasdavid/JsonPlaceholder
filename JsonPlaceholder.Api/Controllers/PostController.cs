using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JsonPlaceholder.Business.Interfaces;
using JsonPlaceholder.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JsonPlaceholder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ILogger<UserController> _logger;

        public PostController(IPostService postService, ILogger<UserController> logger)
        {
            _postService = postService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/user/{userId}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts(string userId, [FromQuery] int start, [FromQuery] int take)
        {
            try
            {
                var posts = await _postService.GetPosts(userId, start, take);

                if (posts != null)
                {
                    return Ok(posts);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception has occurred when trying to fetch posts.");
                return StatusCode(500);
            }
        }
    }
}
