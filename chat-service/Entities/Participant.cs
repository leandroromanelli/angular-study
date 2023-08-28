namespace MeetingService.Entities
{
    public class Participant : EntityBase
    {
        public Participant() : base()
        {
        }

        public string Name { get; set; }
        public string ReferenceId { get; set; }
        public string Token { get; set; }
        public string ConnectionId { get; set; }

        public Guid RoleId { get; set; }
        public ParticipantRole Role { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
