namespace MeetingService.Entities
{
    public class Message : EntityBase
    {
        public Message() : base()
        {            
        }

        public string Content { get; set; }
        public DateTime DateTime { get; set; }

        public Guid ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }

    }
}
