using ChatService.Entities;
using ChatService.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatService.Controllers
{

    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class DummyDataController : Controller
    {
        private readonly IDummyDataService _dummyDataService;
        public DummyDataController(IDummyDataService dummyDataService)
        {
            _dummyDataService = dummyDataService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DummyData>>> List(CancellationToken cancellationToken)
        {
            return Content(JsonConvert.SerializeObject(await _dummyDataService.List(cancellationToken)), "application/json");
        }
    }
}
