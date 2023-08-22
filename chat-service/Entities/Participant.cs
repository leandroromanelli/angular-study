using OpenTokSDK;

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
        public Role Role { get; set; }
    }
}
