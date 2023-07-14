using ChatService.Dtos;
using ChatService.Entities;
using ChatService.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers(CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(await _userService.List(cancellationToken)), "application/json");
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(UserCreationDto user, CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(await _userService.Add(new User(user), cancellationToken)), "application/json");
        }
    }
}
