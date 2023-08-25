using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class RoleCreationDto
    {
        public string Name { get; set; }
        public OpenTokSDK.Role VonageRole { get; set; }
        public string Permissions { get; set; }

        public Role ToEntity(Guid scenarioId)
        {
            return new Role()
            {
                Name = Name,
                ScenarioId = scenarioId,
                VonageRole = VonageRole,
                Permissions = Permissions,
            };
        }
    }
}
