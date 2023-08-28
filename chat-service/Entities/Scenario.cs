namespace MeetingService.Entities
{
    public class Scenario : EntityBase
    {
        public Scenario() : base()
        {
            Roles = new List<ParticipantRole>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<ParticipantRole> Roles { get; set; }
    }
}
