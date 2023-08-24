using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class ParticipantResponseDto : ResponseDto
    {
        public ParticipantResponseDto(Participant participant) : base(participant.Id) 
        {
            Name = participant.Name;
            Role = new RoleResponseDto(participant.Role);
        }
                
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("role")]
        public RoleResponseDto Role { get; set; }
    }
}