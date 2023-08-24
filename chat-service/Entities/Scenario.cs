namespace MeetingService.Entities
{
    public class Scenario : EntityBase
    {
        public Scenario() : base()
        {
            Roles = new List<Role>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<Role> Roles { get; set; }
    }
}
