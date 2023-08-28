using MeetingService.Entities;

namespace MeetingService.Interfaces.Repositories
{
    public interface IScenarioRepository : IRepository<Scenario>
    {
        Task<Scenario> GetByName(string tenant, string name, CancellationToken cancellationToken);
    }
}
