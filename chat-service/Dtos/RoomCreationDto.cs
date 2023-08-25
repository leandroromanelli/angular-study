using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class RoomCreationDto
    {
        public string Name { get; set; }
        public List<ParticipantCreationDto> Participants { get; set; }

        public Room ToEntity(Guid scenarioId)
        {
            return new Room()
            {
                Name = Name,
                ScenarioId = scenarioId,
                Participants = Participants.Select(p => p.ToEntity()).ToList()
            };
        }
    }
}
