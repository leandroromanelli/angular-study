using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class RoleCreationDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("scenarioId")]
        public Guid ScenarioId { get; set; }

        [JsonProperty("vonage_role")]
        public OpenTokSDK.Role VonageRole { get; set; }
        
        [JsonProperty("json_permissions")]
        public string Permissions { get; set; }

        public Role ToEntity()
        {
            return new Role()
            {
                Name = Name,
                ScenarioId = ScenarioId,
                VonageRole = VonageRole,
                Permissions = Permissions,
            };
        }
    }
}
