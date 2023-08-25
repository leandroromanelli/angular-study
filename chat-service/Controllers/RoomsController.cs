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

        [HttpPost("{scenarioId:guid}")]
        public async Task<ActionResult<RoomResponseDto>> Add([FromRoute] string tenant, [FromRoute] Guid scenarioId, [FromBody] RoomCreationDto roomCreationDto, CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(new RoomResponseDto(await _roomService.AddRoom(tenant, roomCreationDto.ToEntity(scenarioId), cancellationToken)), Formatting.Indented), "application/json");
        }

        [HttpGet("{referenceId:guid}")]
        public async Task<ActionResult<RoomResponseDto>> Get([FromRoute] string tenant, [FromRoute] Guid referenceId, CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(new RoomResponseDto(await _roomService.Get(tenant, referenceId, cancellationToken)), Formatting.Indented), "application/json");
        }

        [HttpGet()]
        public async Task<ActionResult<RoomResponseDto>> List([FromRoute] string tenant, CancellationToken cancellationToken)
        {
            var result = await _roomService.List(tenant, cancellationToken);
            return Content(JsonConvert.SerializeObject(result.Select(r => new RoomResponseDto(r)), Formatting.Indented), "application/json");
        }
    }
}
