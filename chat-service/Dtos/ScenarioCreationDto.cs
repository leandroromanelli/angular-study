using MeetingService.Entities;

namespace MeetingService.Dtos
{
    public class ScenarioCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Scenario ToEntity()
        {
            return new Scenario()
            {
                Name = Name,
                Description = Description
            };
        }
    }
}
