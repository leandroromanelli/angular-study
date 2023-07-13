using ChatService.Contexts;
using ChatService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ChatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TestContext _context;

        public UserController(TestContext context)
        {
            _context = context;

            _context.Users.Add(new User()
            {
                Name = "string",
            });
            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers(CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(await _context.Users.ToListAsync(cancellationToken)), "application/json");
        }
    }
}
