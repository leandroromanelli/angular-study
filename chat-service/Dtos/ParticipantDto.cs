using MeetingService.Entities;

namespace MeetingService.Dtos
{
    public class ParticipantDto
    {
        public ParticipantDto()
        {
            
        }

        public ParticipantDto(Participant p) : this() 
        {
            Name = p.Name;
            Role = (int)p.Role;
        }

        public string Name { get; set; }
        public int Role { get; set; }

        public Participant ToEntity()
        {
            return new Participant()
            {
                Name = Name,
                Role = (OpenTokSDK.Role)Role
            };
        }
    }
}