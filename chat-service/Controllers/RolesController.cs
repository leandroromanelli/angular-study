using MeetingService.Dtos;
using MeetingService.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeetingService.Controllers
{
    [Route("/api/[controller]/{tenant}")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("{scenarioId:guid}")]
        public async Task<ActionResult<RoleResponseDto>> Add([FromRoute] string tenant, [FromBody] RoleCreationDto roleDto, CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(new RoleResponseDto(await _roleService.Add(tenant, roleDto.ToEntity(), cancellationToken)), Formatting.Indented), "application/json");
        }

        [HttpGet("{scenarioId:guid}")]
        public async Task<ActionResult<IEnumerable<RoleResponseDto>>> Get([FromRoute] string tenant, [FromRoute] Guid scenarioId, CancellationToken cancellationToken)
        {
            var result = await _roleService.GetByScenario(tenant, scenarioId, cancellationToken);
            return Content(JsonConvert.SerializeObject(result.Select(r => new RoleResponseDto(r)), Formatting.Indented), "application/json");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleResponseDto>>> List([FromRoute] string tenant, CancellationToken cancellationToken)
        {
            var result = await _roleService.List(tenant, cancellationToken);
            return Content(JsonConvert.SerializeObject(result.Select(r => new RoleResponseDto(r)), Formatting.Indented), "application/json");
        }
    }
}
