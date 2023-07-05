using chat_service.Contexts;
using chat_service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chat_service.Controllers
{

    [Produces("application/json")]
    [ApiController]
    [Route("dummydata")]
    public class DummyDataController : Controller
    {
        private readonly TestContext _context;

        public DummyDataController(TestContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DummyData>>> List(CancellationToken cancellationToken)
        {
            var dummy = await _context.DummyData.ToListAsync(cancellationToken);

            return Ok(dummy);
        }
    }
}
