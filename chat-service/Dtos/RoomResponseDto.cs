using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class RoomResponseDto : RoomCreationDto
    {
        public RoomResponseDto(Room room) : base()
        {
            RoomName = room.Name;
            ReferenceId = room.Id;
            Participants = room.Participants.Select(p => new ParticipantDto(p)).ToList();
        }

        [JsonProperty("referenceId")]
        public Guid ReferenceId { get; set; }
    }
}
