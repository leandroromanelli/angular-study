﻿using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class RoomCreationDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("participants")]
        public List<ParticipantCreationDto> Participants { get; set; }

        [JsonProperty("scenarioId")]
        public Guid ScenarioId { get; set; }

        public Room ToEntity()
        {
            return new Room()
            {
                Name = Name,
                ScenarioId = ScenarioId,
                Participants = Participants.Select(p => p.ToEntity()).ToList()
            };
        }
    }
}
