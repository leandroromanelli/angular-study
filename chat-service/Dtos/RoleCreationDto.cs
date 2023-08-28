using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class RoleCreationDto
    {
        public string Name { get; set; }
        public OpenTokSDK.Role VonageRole { get; set; }
        public string Permissions { get; set; }

        public ParticipantRole ToEntity(Guid scenarioId)
        {
            return new ParticipantRole()
            {
                Name = Name,
                ScenarioId = scenarioId,
                VonageRole = VonageRole,
                Permissions = Permissions,
            };
        }
    }
}
