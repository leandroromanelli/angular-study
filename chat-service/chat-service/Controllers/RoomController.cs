using ChatService.Contexts;
using ChatService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OpenTokSDK;

namespace ChatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TestContext _context;

        public RoomController(IConfiguration configuration, TestContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet("roomName")]
        public async Task<ActionResult<string>> GetSession([FromRoute] string roomName, CancellationToken cancellationToken)
        {
            var opentok = new OpenTok(int.Parse(_configuration["ApiKey"]), _configuration["ApiSecret"]);

            var room = await _context.Rooms.Where(r => r.RoomName == roomName).FirstOrDefaultAsync(cancellationToken);

            if (room == null)
            {
                room = new Room()
                {
                    SessionId = (await opentok.CreateSessionAsync()).Id,
                    RoomName = roomName
                };

                _context.Add(room);
            }

            room.Token = opentok.GenerateToken(room.SessionId);

            _context.SaveChanges();

            return Ok(JsonConvert.SerializeObject(new { sessionId =  room.SessionId, token = room.Token, apiKey = _configuration["ApiKey"] }));
        }
    }
}
