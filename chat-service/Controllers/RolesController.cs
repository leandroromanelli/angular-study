using MeetingService.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenTokSDK;

namespace MeetingService.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        public RolesController()
        {
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoleDto>> ListRoles()
        {

            return Content(JsonConvert.SerializeObject(
                new List<RoleDto>()
                {
                    new RoleDto((int)Role.PUBLISHER, Role.PUBLISHER.ToString().ToLower()),
                    new RoleDto((int)Role.SUBSCRIBER, Role.SUBSCRIBER.ToString().ToLower()),
                    new RoleDto((int)Role.MODERATOR, Role.MODERATOR.ToString().ToLower()),
                }, Formatting.Indented), "application/json");
        }
    }
}
