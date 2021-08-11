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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicUser>>> GetUsers([FromQuery] int start, [FromQuery] int take)
        {
            try
            {
                var users = await _userService.GetUsers(start, take);

                if(users != null)
                {
                    return Ok(users);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An exception has occurred when trying to fetch users.");
                return StatusCode(500);
            }
        }
    }
}