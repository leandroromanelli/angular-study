using MeetingService.Dtos;
using MeetingService.Entities;
using MeetingService.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeetingService.Controllers
{
    [Route("/api/[controller]/{tenant}")]
    [ApiController]
    public class ParticipantRolesController : ControllerBase
    {
        private readonly IParticipantRoleService _roleService;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public ParticipantRolesController(JsonSerializerSettings jsonSerializerSettings, IParticipantRoleService roleService)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
            _roleService = roleService;
        }

        [HttpPost("{scenarioId:guid}")]
        public async Task<ActionResult<ParticipantRole>> Add([FromRoute] string tenant, [FromRoute] Guid scenarioId, [FromBody] RoleCreationDto roleDto, CancellationToken cancellationToken)
        {
            try
            {
                await _roleService.Add(tenant, roleDto.ToEntity(scenarioId), cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{scenarioId:guid}")]
        public async Task<ActionResult<IEnumerable<ParticipantRole>>> Get([FromRoute] string tenant, [FromRoute] Guid scenarioId, CancellationToken cancellationToken)
        {
            var result = await _roleService.GetByScenario(tenant, scenarioId, cancellationToken);
            return Content(JsonConvert.SerializeObject(result, Formatting.Indented, _jsonSerializerSettings), "application/json");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantRole>>> List([FromRoute] string tenant, CancellationToken cancellationToken)
        {
            var result = await _roleService.List(tenant, cancellationToken);
            return Content(JsonConvert.SerializeObject(result, Formatting.Indented, _jsonSerializerSettings), "application/json");
        }
    }
}
