using ChatService.Dtos;
using ChatService.Entities;
using ChatService.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<ActionResult<Room>> AddRoom([FromBody] RoomCreationDto roomCreationDto, CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(await _roomService.AddRoom(new Room(roomCreationDto), cancellationToken)), "application/json");
        }

        [HttpGet]
        public async Task<ActionResult<Room>> GetSession([FromQuery] string name, CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(await _roomService.Find(name, cancellationToken)), "application/json");
        }
    }
}
