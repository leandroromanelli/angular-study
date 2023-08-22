using MeetingService.Dtos;
using MeetingService.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeetingService.Controllers
{
    [Route("/api/[controller]/{tenant}")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<ActionResult<RoomResponseDto>> AddRoom([FromRoute] string tenant, [FromBody] RoomCreationDto roomCreationDto, CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(new RoomResponseDto(await _roomService.AddRoom(tenant, roomCreationDto.ToEntity(), cancellationToken)), Formatting.Indented), "application/json");
        }

        [HttpGet("{referenceId:guid}")]
        public async Task<ActionResult<RoomResponseDto>> GetRoom([FromRoute] string tenant, [FromRoute] Guid referenceId, CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(new RoomResponseDto(await _roomService.Find(tenant, referenceId, cancellationToken)), Formatting.Indented), "application/json");
        }
    }
}
