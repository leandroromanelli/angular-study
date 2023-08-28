using MeetingService.Dtos;
using MeetingService.Entities;
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
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public ScenariosController(JsonSerializerSettings jsonSerializerSettings, IScenarioService scenarioService)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
            _scenarioService = scenarioService;
        }

        [HttpPost]
        public async Task<ActionResult<Scenario>> Add([FromRoute] string tenant, [FromBody] ScenarioCreationDto scenarioDto, CancellationToken cancellationToken)
        {
            try
            {
                await _scenarioService.Add(tenant, scenarioDto.ToEntity(), cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scenario>>> Get([FromRoute] string tenant, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _scenarioService.List(tenant, cancellationToken);
                return Content(JsonConvert.SerializeObject(result, Formatting.Indented, _jsonSerializerSettings), "application/json");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
