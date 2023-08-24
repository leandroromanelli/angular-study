using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class RoleResponseDto : ResponseDto
    {
        public RoleResponseDto(Role role) : base(role.Id)
        {
            Name = role.Name;
            Scenario = new ScenarioResponseDto(role.Scenario);
            VonageRole = role.VonageRole;
            Permissions = role.Permissions;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("scenario")]
        public ScenarioResponseDto Scenario { get; set; }

        [JsonProperty("vonage_role")]
        public OpenTokSDK.Role VonageRole { get; set; }
        
        [JsonProperty("json_permissions")]
        public string Permissions { get; set; }
    }
}
