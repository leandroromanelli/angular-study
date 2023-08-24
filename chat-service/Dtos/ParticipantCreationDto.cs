using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class ParticipantCreationDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("roleId")]
        public Guid RoleId { get; set; }

        public Participant ToEntity()
        {
            return new Participant()
            {
                Name = Name,
                RoleId = RoleId
            };
        }
    }
}