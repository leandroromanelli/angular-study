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
        private readonly OpenTok _opentok;

        public RoomController(IConfiguration configuration, TestContext context)
        {
            _configuration = configuration;
            _context = context;
            _opentok = new OpenTok(int.Parse(_configuration["ApiKey"]), _configuration["ApiSecret"]);
        }

        [HttpPost]
        public async Task<ActionResult<Room>> AddRoom([FromBody] RoomCreationDto roomCreationDto, CancellationToken cancellationToken)
        {
            var isInsert = false;

            var room = new Room(roomCreationDto);

            var dbRoom = await _context.Rooms
                                       .Where(r => r.RoomName == room.RoomName)
                                       .Include(r => r.UserRooms)
                                       .FirstOrDefaultAsync(cancellationToken);

            if (dbRoom == null)
            {
                isInsert = true;
                dbRoom = room;

                var session = _opentok.CreateSession();

                room.SessionId = session.Id;
            }

            foreach (var user in room.Users)
            {
                var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Name == user.Name, cancellationToken);

                if (dbUser == null)
                {
                    dbUser = user;
                    _context.Users.Add(dbUser);
                }

                if (dbRoom.UserRooms.Any(r => r.UserId == dbUser.Id))
                    continue;

                dbRoom.UserRooms.Add(new UserRoom(dbUser.Id, dbRoom.Id, _opentok.GenerateToken(dbRoom.SessionId)));
            }

            if (isInsert)
                _context.Rooms.Add(dbRoom);
            else
                _context.Rooms.Update(dbRoom);

            await _context.SaveChangesAsync(cancellationToken);

            return Content(JsonConvert.SerializeObject(dbRoom), "application/json");
        }

        [HttpGet]
        public async Task<ActionResult<Room>> GetSession([FromQuery] string name, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms
                                     .Where(r => r.RoomName == name)
                                     .Include(r => r.UserRooms)
                                     .FirstOrDefaultAsync(cancellationToken);

            return Content(JsonConvert.SerializeObject(room), "application/json");
        }
    }
}
