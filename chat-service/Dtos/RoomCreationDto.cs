using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class RoomCreationDto
    {
        public RoomCreationDto()
        {
        }

        [JsonProperty("roomName")]
        public string RoomName { get; set; }
        
        [JsonProperty("users")]
        public List<ParticipantDto> Participants { get; set; }

        public Room ToEntity()
        {
            return new Room()
            {
                Name = RoomName,
                Participants = Participants.Select(p => p.ToEntity()).ToList()
            };
        }
    }
}
