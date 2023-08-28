using MeetingService.Dtos;
using MeetingService.Entities;
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
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public RoomsController(JsonSerializerSettings jsonSerializerSettings, IRoomService roomService)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
            _roomService = roomService;
        }

        [HttpPost("{scenarioId:guid}")]
        public async Task<ActionResult<Room>> Add([FromRoute] string tenant, [FromRoute] Guid scenarioId, [FromBody] RoomCreationDto roomCreationDto, CancellationToken cancellationToken)
        {
            try
            {
                await _roomService.Add(tenant, roomCreationDto.ToEntity(scenarioId), cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{referenceId:guid}")]
        public async Task<ActionResult<Room>> Get([FromRoute] string tenant, [FromRoute] Guid referenceId, CancellationToken cancellationToken)
        {
            var result = await _roomService.GetComplete(tenant, referenceId, cancellationToken);
            return Content(JsonConvert.SerializeObject(result, Formatting.Indented, _jsonSerializerSettings), "application/json");
        }

        [HttpGet()]
        public async Task<ActionResult<Room>> List([FromRoute] string tenant, CancellationToken cancellationToken)
        {
            var result = await _roomService.List(tenant, cancellationToken);
            return Content(JsonConvert.SerializeObject(result, Formatting.Indented, _jsonSerializerSettings), "application/json");
        }
    }
}
