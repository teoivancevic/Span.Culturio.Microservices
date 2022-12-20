using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Microservices.Users.Models;
using Span.Culturio.Microservices.Users.Services;

namespace Span.Culturio.Microservices.Users.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize]

    public class UsersController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UsersController(ILogger<UsersController> logger, IUserService userService, IConfiguration configuration)
        {
            _logger = logger;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers([FromQuery] int pageSize, [FromQuery] int pageIndex)
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            if (user is null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<UserDto>> GetUserByUsername(string username)
        {
            var user = await _userService.GetUserByUsername(username);
            if (user is null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

    }
}

