using MeetingService.Dtos;
using MeetingService.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeetingService.Controllers
{
    [Route("/api/[controller]/{tenant}")]
    [ApiController]
    public class ScenariosController : ControllerBase
    {
        private readonly IScenarioService _scenarioService;

        public ScenariosController(IScenarioService scenarioService)
        {
            _scenarioService = scenarioService;
        }

        [HttpPost]
        public async Task<ActionResult<ScenarioResponseDto>> Add([FromRoute] string tenant, [FromBody] ScenarioCreationDto scenarioDto, CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(new ScenarioResponseDto(await _scenarioService.Add(tenant, scenarioDto.ToEntity(), cancellationToken)), Formatting.Indented), "application/json");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScenarioResponseDto>>> Get([FromRoute] string tenant, CancellationToken cancellationToken)
        {
            var result = await _scenarioService.List(tenant, cancellationToken);
            return Content(JsonConvert.SerializeObject(result.Select(r => new ScenarioResponseDto(r)), Formatting.Indented), "application/json");
        }
    }
}
