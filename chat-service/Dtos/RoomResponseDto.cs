using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class RoomResponseDto : ResponseDto
    {
        public RoomResponseDto(Room room): base(room.Id)
        {
            Name = room.Name;
            Scenario = new ScenarioResponseDto(room.Scenario);
            Participants = room.Participants.Select(p => new ParticipantResponseDto(p)).ToList();
        }


        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("participants")]
        public List<ParticipantResponseDto> Participants { get; set; }

        [JsonProperty("scenario")]
        public ScenarioResponseDto Scenario { get; set; }

    }
}
