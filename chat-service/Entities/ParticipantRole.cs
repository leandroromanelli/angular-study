namespace MeetingService.Entities
{
    public class ParticipantRole : EntityBase
    {
        public ParticipantRole() : base()
        {
            
        }

        public string Name { get; set; }
        public OpenTokSDK.Role VonageRole { get; set; }

        public string Permissions { get; set; }

        public Guid ScenarioId { get; set; }
        public Scenario Scenario { get; set; }
    }
}
