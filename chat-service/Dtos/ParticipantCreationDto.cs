using MeetingService.Entities;
using Newtonsoft.Json;

namespace MeetingService.Dtos
{
    public class ParticipantCreationDto
    {
        public string Name { get; set; }
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