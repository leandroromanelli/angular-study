using MeetingService.Entities;

namespace MeetingService.Dtos
{
    public class ScenarioResponseDto : ResponseDto
    {
        public ScenarioResponseDto(Scenario scenario) : base(scenario.Id)
        {
            Name = scenario.Name;
            Description = scenario.Description;
            Roles = scenario.Roles.Select(r => new RoleResponseDto(r)).ToList();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<RoleResponseDto> Roles { get; set; }
    }
}
