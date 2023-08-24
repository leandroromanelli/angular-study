using MeetingService.Entities;

namespace MeetingService.Interfaces.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<IEnumerable<Role>> GetByScenario(string tenant, Guid scenarioId, CancellationToken cancellationToken);
    }
}
