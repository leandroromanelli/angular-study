namespace MeetingService.Entities;
public class Room : EntityBase
{
    public Room() : base()
    {
        Participants = new List<Participant>();
    }

    public string SessionId { get; set; }    
    public string Name { get; set; }

    public Guid ScenarioId { get; set; }
    public Scenario Scenario { get; set; }

    public List<Participant> Participants { get; set; }
}