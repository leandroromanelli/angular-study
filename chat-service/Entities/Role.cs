namespace MeetingService.Entities
{
    public class Role : EntityBase
    {
        public Role() : base()
        {
            
        }

        public string Name { get; set; }
        public OpenTokSDK.Role VonageRole { get; set; }

        public Guid ScenarioId { get; set; }
        public Scenario Scenario { get; set; }
        public string Permissions { get; set; }
    }
}
